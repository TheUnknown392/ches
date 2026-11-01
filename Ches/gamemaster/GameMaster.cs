using Raylib_cs;
using System.Numerics;
using render;
using model;
namespace gamemaster
{


    public static class GameMaster
    {
        public const bool DEBUG = true;
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
            ourSelectedBoardPiece.boardPiece.color = Piece_Color.UNKNOWN;
            ourSelectedBoardPiece.boardPiece.kind = PieceKindEnum.UNKNOWN;
            ourSelectedBoardPiece.boardPiece.boundingBox = null;
            ourSelectedBoardPiece.standardPos = new Vector2(-1f, -1f);
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
        
        public static SelectedPiece ourSelectedBoardPiece;

        public static void setScale(float scalef)
        {
            scale = scalef;
        }
        public static void initBoard()
        {
            for (int col = 0; col < 8; col++)
            {
                Vector2 ourPawnVector = new Vector2(col,2 - 1);
                Vector2 opponentPawnVector = new Vector2(col,7 - 1);
                BoardStatus.TryAdd(ourPawnVector, new BoardPiece
                {
                    kind = PieceKindEnum.Pawn,
                    color = Piece_Color.White,
                    boundingBox = RenderHandler.GetPieceRenderingBoundingBox(PieceKindEnum.Pawn,Piece_Color.White,ourPawnVector)
                });
                BoardStatus.TryAdd(opponentPawnVector, new BoardPiece
                {
                    kind = PieceKindEnum.Pawn,
                    color = Piece_Color.Black,
                    boundingBox = RenderHandler.GetPieceRenderingBoundingBox(PieceKindEnum.Pawn,Piece_Color.Black,opponentPawnVector)
                });
            }
            for (int i = 0; i < 8; i++)
            {
                Vector2 ourPieceVector = new Vector2(i, 1 - 1);
                Vector2 opponentPieceVector = new Vector2(i, 8 - 1);
                BoardStatus.TryAdd(ourPieceVector, new BoardPiece
                {
                    kind = DEFAULT_PIECES[i],
                    color = Piece_Color.White,
                    boundingBox = RenderHandler.GetPieceRenderingBoundingBox(DEFAULT_PIECES[i],Piece_Color.White,ourPieceVector)      
                });

                BoardStatus.TryAdd(opponentPieceVector, new BoardPiece
                {
                    kind = DEFAULT_PIECES[i],
                    color = Piece_Color.Black,
                    boundingBox = RenderHandler.GetPieceRenderingBoundingBox(DEFAULT_PIECES[i],Piece_Color.Black,opponentPieceVector)      
                });
            }

        }
        public static Piece getPieceByPieceKind(PieceKindEnum piece, Piece_Color color)
        {
            switch (piece)
            {
                case PieceKindEnum.King:
                    if (color == Piece_Color.White)
                    {
                        return GameMaster.our.king;
                    }
                    else if (color == Piece_Color.Black)
                    {
                        return GameMaster.opponent.king;
                    }
                    break;
                case PieceKindEnum.Queen:
                    if (color == Piece_Color.White)
                    {
                        return GameMaster.our.queen;
                    }
                    else if (color == Piece_Color.Black)
                    {
                        return GameMaster.opponent.queen;
                    }
                    break;
                case PieceKindEnum.Bishop:
                    if (color == Piece_Color.White)
                    {
                        return GameMaster.our.bishop;
                    }
                    else if (color == Piece_Color.Black)
                    {
                        return GameMaster.opponent.bishop;
                    }
                    break;
                case PieceKindEnum.Knight:
                    if (color == Piece_Color.White)
                    {
                        return GameMaster.our.knight;
                    }
                    else if (color == Piece_Color.Black)
                    {
                        return GameMaster.opponent.knight;
                    }
                    break;
                case PieceKindEnum.Rook:
                    if (color == Piece_Color.White)
                    {
                        return GameMaster.our.rook;
                    }
                    else if (color == Piece_Color.Black)
                    {
                        return GameMaster.opponent.rook;
                    }
                    break;
                case PieceKindEnum.Pawn:
                    if (color == Piece_Color.White)
                    {
                        return GameMaster.our.pawn;
                    }
                    else if (color == Piece_Color.Black)
                    {
                        return GameMaster.opponent.pawn;
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
