using Raylib_cs;
using gamemaster;
namespace model
{
    public class Pawn : Piece
    {
        public Pawn(Piece_Color color, Model model){
            this.color = color;
            this.model = model;
            this.kind = PieceKindEnum.Pawn;
            this.getBoundingBox(model);
        }

    }

}
