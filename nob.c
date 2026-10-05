#define NOB_IMPLEMENTATION


#include "./thirdparty/nob.h"

#define SRC "./Reports/Proposal/"
#define BLD "build/"

int main(int argc, char *argv[]){
    NOB_GO_REBUILD_URSELF(argc, argv);
    Nob_Cmd cmd = {0};
    if(!nob_mkdir_if_not_exists(SRC BLD)) return 1;
    if(!nob_set_current_dir(SRC)) return 1;
    
    nob_cmd_append(&cmd, "latexmk", "-xelatex", "-outdir="BLD, "latex.tex");
    
    if (!nob_cmd_run(&cmd)) return 1;
    return 0;
}
