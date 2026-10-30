using Raylib_cs;
using gamemaster;
namespace model
{
    public class Bishop : Piece
    {
        public Bishop(Piece_Color color, Model model){
            this.color = color;
            this.model = model;
            this.kind = PieceKindEnum.Bishop;
        }
    }

}
