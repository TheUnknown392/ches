using Raylib_cs;
using gamemaster;
namespace model{
        public abstract class Piece{

            public ushort x { get; set; }
            public ushort y { get; set; }
            public PieceKindEnum kind;

            public Model model { get; set; }
    
            public Piece_Color color { get; set; }
    }
}
