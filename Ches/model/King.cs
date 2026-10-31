using Raylib_cs;
using gamemaster;
namespace model
{
    public class King : Piece
    {
        public King(Piece_Color color, Model model){
            this.color = color;
            this.model = model;
            this.kind = PieceKindEnum.King;
            this.getBoundingBox(model);
        }
    }

}
