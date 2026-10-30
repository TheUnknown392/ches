using Raylib_cs;
using gamemaster;
namespace model
{
    public class Knight : Piece
    {
        public Knight(Piece_Color color, Model model){
            this.color = color;
            this.model = model;
            this.kind = PieceKindEnum.Knight;
        }
    }

}
