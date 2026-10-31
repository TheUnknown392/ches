using Raylib_cs;
using System.Numerics;
using model;
namespace gamemaster
{


    public static class GameMaster
    {
        public static Dictionary<Vector2, BoardPiece> BoardStatus = new Dictionary<Vector2, BoardPiece>();
        public static PieceKindEnum[] DEFAULT_PIECES =  {
            PieceKindEnum.Rook,
            PieceKindEnum.Knight,
            PieceKindEnum.Bishop,
            PieceKindEnum.Queen,
            PieceKindEnum.King,
            PieceKindEnum.Bishop,
            PieceKindEnum.Knight,
            PieceKindEnum.Rook            
        };


        private static void LoadOurPieces()
        {
            GameMaster.our.king = new King(Piece_Color.White, Raylib.LoadModel("Ches/assest/Chess/obj/White-King.obj"));
            GameMaster.our.queen = new Queen(Piece_Color.White, Raylib.LoadModel("Ches/assest/Chess/obj/White-Queen.obj"));
            GameMaster.our.bishop = new Bishop(Piece_Color.White, Raylib.LoadModel("Ches/assest/Chess/obj/White-Bishop.obj"));
            GameMaster.our.knight = new Knight(Piece_Color.White, Raylib.LoadModel("Ches/assest/Chess/obj/White-Knight.obj"));
            GameMaster.our.rook = new Rook(Piece_Color.White, Raylib.LoadModel("Ches/assest/Chess/obj/White-Rook.obj"));
            GameMaster.our.pawn = new Pawn(Piece_Color.White, Raylib.LoadModel("Ches/assest/Chess/obj/White-Pawn.obj"));
        }
        private static void LoadOpponentPieces()
        {
            GameMaster.opponent.king = new King(Piece_Color.Black, Raylib.LoadModel("Ches/assest/Chess/obj/Black-King.obj"));
            GameMaster.opponent.queen = new Queen(Piece_Color.Black, Raylib.LoadModel("Ches/assest/Chess/obj/Black-Queen.obj"));
            GameMaster.opponent.bishop = new Bishop(Piece_Color.Black, Raylib.LoadModel("Ches/assest/Chess/obj/Black-Bishop.obj"));
            GameMaster.opponent.knight = new Knight(Piece_Color.Black, Raylib.LoadModel("Ches/assest/Chess/obj/Black-Knight.obj"));
            GameMaster.opponent.rook = new Rook(Piece_Color.Black, Raylib.LoadModel("Ches/assest/Chess/obj/Black-Rook.obj"));
            GameMaster.opponent.pawn = new Pawn(Piece_Color.Black, Raylib.LoadModel("Ches/assest/Chess/obj/Black-Pawn.obj"));
        }
        static GameMaster()
        {
            LoadOurPieces();
            LoadOpponentPieces();
            initBoard();
            // default scale
            scale = 10f;
        }
        public struct Pieces
        {
            public Pawn pawn;
            public King king;
            public Queen queen;
            public Bishop bishop;
            public Knight knight;
            public Rook rook;
        }

        // todo: remove this
        public static float scale;

        public static Pieces our;
        public static Pieces opponent;

        public static void setScale(float scalef)
        {
            scale = scalef;
        }
        public static void initBoard(){
            for (int col = 0; col < 8; col++)
            {
                BoardStatus.TryAdd(new Vector2(2-1,col),new BoardPiece
                {
                    kind = PieceKindEnum.Pawn,
                    color = Piece_Color.White
                });
                BoardStatus.TryAdd(new Vector2(7-1,col),new BoardPiece
                {
                    kind = PieceKindEnum.Pawn,
                    color = Piece_Color.Black
                });
            }
            for (int i = 0; i < 8; i++){
                BoardStatus.TryAdd(new Vector2(1-1,i),new BoardPiece
                {
                    kind = DEFAULT_PIECES[i],
                    color = Piece_Color.White
                });
                
                BoardStatus.TryAdd(new Vector2(8-1,i),new BoardPiece
                {
                    kind = DEFAULT_PIECES[i],
                    color = Piece_Color.Black
                });
            }

        }
        // for standard displays, xy are swapped  forsome reason
        public static Vector2 standardToRenderPosition(Vector2 pos)
        {
            return new Vector2(
                (pos.X - 4.5f) / 2f,
                (4.5f - pos.Y) / 2f
            );
        }

        public static Vector2 standardToRenderPosition(float x, float z)
        {
            return standardToRenderPosition(new Vector2(x, z));
        }

        public static Vector2 renderToStandardPosition(Vector2 pos)
        {
            return new Vector2(
                pos.X * 2f + 4.5f,
                4.5f - pos.Y * 2f
            );
        }

        public static Vector2 renderToStandardPosition(float x, float z)
        {
            return renderToStandardPosition(new Vector2(x, z));
        }

        public static Piece getPieceByPieceKind(PieceKindEnum piece, Piece_Color color){
            switch (piece)
            {
                case PieceKindEnum.King:
                    if(color == Piece_Color.White){
                        return our.king;
                    }else if(color == Piece_Color.Black){
                        return opponent.king;
                    }
                    break;
                case PieceKindEnum.Queen:
                    if(color == Piece_Color.White){
                        return our.queen;
                    }else if(color == Piece_Color.Black){
                        return opponent.queen;
                    }
                    break;
                case PieceKindEnum.Bishop:
                    if(color == Piece_Color.White){
                        return our.bishop;
                    }else if(color == Piece_Color.Black){
                        return opponent.bishop;
                    }
                    break;
                case PieceKindEnum.Knight:
                    if(color == Piece_Color.White){
                        return our.knight;
                    }else if(color == Piece_Color.Black){
                        return opponent.knight;
                    }
                    break;
                case PieceKindEnum.Rook:
                    if(color == Piece_Color.White){
                        return our.rook;
                    }else if(color == Piece_Color.Black){
                        return opponent.rook;
                    }
                    break;
                case PieceKindEnum.Pawn:
                    if(color == Piece_Color.White){
                        return our.pawn;
                    }else if(color == Piece_Color.Black){
                        return opponent.pawn;
                    }
                    break;
                default:
                    Console.WriteLine("Unreachable code in getPieceByPieceKind reached");
                    Environment.Exit(-1);
                    break;
            }
            return new NullPiece(Piece_Color.UNKNOWN);
        }

}
}
