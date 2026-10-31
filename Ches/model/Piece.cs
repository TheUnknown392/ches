using Raylib_cs;
using gamemaster;
namespace model{
        public abstract class Piece{

            public ushort x { get; set; }
            public ushort y { get; set; }
            public PieceKindEnum kind;

            public Model model { get; set; }
            public BoundingBox boundingBox { get; set; }

            public Piece_Color color { get; set; }

            public void getBoundingBox(Model model)
            {
                this.boundingBox = Raylib.GetModelBoundingBox(model);
            } 
            public void getBoundingBox()
            {
                this.boundingBox = Raylib.GetModelBoundingBox(this.model);
            }
            
    }
}
