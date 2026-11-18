#include <stdio.h>
#include <string.h>
#include <stdbool.h>

#define NOB_IMPLEMENTATION
#define MAX_FLAG 256


#include "./thirdparty/nob.h"

#define PROPOSAL_SRC "./Reports/Proposal"
#define PROPOSAL_BLD "./build"

#define CHES_PROJECT "./Ches"

typedef struct{
    bool proposal;
    bool ches;
    bool all;
}Flag_option;

Flag_option flag_option = {
    .proposal = false,
    .ches = false,
    .all = true
};

typedef struct{
    // todo: put this in hash map
    // hashmap <char*[max_flags], char*>;
    const char *flags[MAX_FLAG];
    int flag_count;
}Flag;

int charOccurance(const Nob_String_View sv, const char ch){
    int counter = 0;
    for(int i = 0; i<=sv.count; i++){
        if(sv.data[i] == ch){
            ++counter;
        }
    }
    return counter;
}

Flag getFlag(int argc, char* argv[]){
    Flag flag = {0};
    if(argc<=0){
        return flag;
    }
    Nob_String_Builder flag_sb = {0};
    Nob_String_View flag_sv = {0};
    
    for(int i = 0; i < argc; i++){
        nob_sb_append_cstr(&flag_sb, argv[i]);
        nob_sb_append_cstr(&flag_sb, " ");
    }
    flag_sv = nob_sb_to_sv(flag_sb);

    flag.flag_count = charOccurance(flag_sv, ' ');

    for(int i = 0; i<flag.flag_count; i++){
        Nob_String_View temp = sv_chop_by_delim(&flag_sv,' ');
        flag.flags[i]=nob_temp_sv_to_cstr(temp);
    }
    return flag;
}

void setFlagOption(int argc,char *argv[]){
    Flag flag = getFlag(argc, argv);
    // if flag is provided, don't run all by default
    if(flag.flag_count>0){
        flag_option.all = false;
    }
    
    for(int i=0; i<flag.flag_count; i++){
        if(!strcmp(flag.flags[i],"ches")){
            flag_option.ches = true;
        }else if(!strcmp(flag.flags[i],"proposal")){
            flag_option.proposal = true;            
        }else{
            printf("spotted nothing");
        }
    }    
}

int run_proposal(Nob_Cmd *cmd, const char* SAVED_DIR){
    if(!nob_set_current_dir(PROPOSAL_SRC)) return 0;
    if(!nob_mkdir_if_not_exists(PROPOSAL_BLD)) return 0;
    nob_cmd_append(cmd, "latexmk", "-xelatex", "-outdir="PROPOSAL_BLD, "latex.tex");
    if (!nob_cmd_run(cmd)){
        nob_log(ERROR,"Could not run PROPOSAL");
        return 0;
    }
    if(!nob_set_current_dir(SAVED_DIR)) return 0;
    return 1;
}

int run_ches(Nob_Cmd *cmd){
    nob_cmd_append(cmd, "dotnet", "run", "--project", CHES_PROJECT);
    if (!nob_cmd_run(cmd)){
        nob_log(ERROR,"Could not run CHES");
        return 0;
    }
    return 1;
}

int main(int argc, char *argv[]){
    NOB_GO_REBUILD_URSELF(argc, argv);
    Nob_Cmd cmd = {0};
    nob_shift(argv,argc);

    const char *SAVED_DIR = nob_get_current_dir_temp();
    
    setFlagOption(argc,argv);
    
    if(flag_option.all){
        if(!run_proposal(&cmd, SAVED_DIR)) return 1;
        if(!run_ches(&cmd)) return 1;
        return 0;
    }
    
    if(flag_option.proposal){
        if(!run_proposal(&cmd, SAVED_DIR)) return 1;
    }
    
    if(flag_option.ches){
        if(!run_ches(&cmd)) return 1; 
    }

    
    return 0;
}
