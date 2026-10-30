using Raylib_cs;
using gamemaster;
namespace model{
    public class Board
    {

        
        public static int[,] map = {
            {}
        };
        public Model model { get; set; }
        public float scale { get; set; }
        public BoundingBox boundingBox { get; set; }
        public Board(Model model, float scale){
            this.model = model;
            this.scale = scale;
        }
        public Board(string url, float scale){
            this.model = Raylib.LoadModel(url);
            if (!Raylib.IsModelValid(this.model))
            {
                Raylib.TraceLog(TraceLogLevel.Error,$"Could not load Chess Board model. URL: {url}");
                Environment.Exit(-1);
            }
            this.scale = scale;
            this.boundingBox = Raylib.GetModelBoundingBox(this.model);
            
        }
        public void unloadModel(){
            Raylib.UnloadModel(this.model);
        }
    }
}
