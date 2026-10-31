using Raylib_cs;
using gamemaster;
namespace model
{
    public class Queen : Piece
    {
        public Queen(Piece_Color color, Model model){
            this.color = color;
            this.model = model;
            this.kind = PieceKindEnum.Queen;
            this.getBoundingBox(model);
        }
    }

}
