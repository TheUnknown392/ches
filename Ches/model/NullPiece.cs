using Raylib_cs;
using gamemaster;
namespace model
{
    public class NullPiece : Piece
    {
        public NullPiece(Piece_Color color){
            this.color = color;
            this.kind = PieceKindEnum.UNKNOWN;
        }
    }

}
