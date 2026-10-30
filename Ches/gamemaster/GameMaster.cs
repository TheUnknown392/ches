using Raylib_cs;
using System.Numerics;
using model;
namespace gamemaster
{


    public static class GameMaster
    {
        public static BoardPiece[,] BoardStatus = new BoardPiece[8,8];
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

            for (int row = 0; row < 8; row ++)
            {
                for (int col = 0; col < 8; col++){
                    BoardStatus[row, col].kind = PieceKindEnum.UNKNOWN;
                    BoardStatus[row, col].color = Piece_Color.UNKNOWN;
                }
            }

            for (int col = 0; col < 8; col++)
            {
                BoardStatus[2 - 1, col].kind = our.pawn.kind;
                BoardStatus[2 - 1, col].color = our.pawn.color;

                BoardStatus[8 - 1, col].kind = opponent.pawn.kind;
                BoardStatus[8 - 1, col].color = opponent.pawn.color;
            }
            for (int i = 0; i < 8; i++){

                BoardStatus[1 - 1, i].color = our.pawn.color;
                BoardStatus[7 - 1, i].color = opponent.pawn.color;

                BoardStatus[1 - 1, i].kind = DEFAULT_PIECES[i];
                BoardStatus[7 - 1, i].kind = DEFAULT_PIECES[i];
            }

        }

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
