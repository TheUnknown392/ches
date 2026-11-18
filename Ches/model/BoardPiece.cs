using Raylib_cs;
namespace gamemaster{
    public struct BoardPiece
    {
        public PieceKindEnum kind;
        public Piece_Color color;
        public BoundingBox? boundingBox;

        private static BoardPiece emptyBoardPiece = new BoardPiece { kind = PieceKindEnum.None, color = Piece_Color.None, boundingBox = null };
        public static BoardPiece None(){
            return emptyBoardPiece;
        }

        public static bool operator ==(BoardPiece A, BoardPiece B){
            return A.kind == B.kind && A.color == B.color && A.boundingBox == B.boundingBox;
        }
        public static bool operator !=(BoardPiece A, BoardPiece B){
            return !(A == B);
        }
        public override bool Equals(Object? obj)
        {
            if (obj is BoardPiece){
                BoardPiece v = (BoardPiece)obj;
                return kind == v.kind && color == v.color && boundingBox == v.boundingBox;
            }
            return false;
        }
        public override int GetHashCode(){
            return kind.GetHashCode() ^ color.GetHashCode() ^ boundingBox.GetHashCode();
        }
    };

}
