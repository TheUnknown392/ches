using Raylib_cs;
using gamemaster;
namespace model
{
    public class Rook : Piece
    {
        public Rook(Piece_Color color, Model model){
            this.color = color;
            this.model = model;
            this.kind = PieceKindEnum.Rook;
            this.getBoundingBox(model);
        }
    }

}
