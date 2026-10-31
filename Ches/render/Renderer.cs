using Raylib_cs;
using System.Numerics;
using gamemaster;
using model;

namespace render
{
    public class Renderer
    {
        // At scale 1, each square len is 0.05f
        private static float BOARD_SCALE = 10f; // square len = 0.5f

        public Camera camera;
        private Board board;
        public Renderer()
        {
            board = new Board("Ches/assest/Chess/obj/Board.obj", BOARD_SCALE);
            GameMaster.initBoard();
            camera = new Camera();
        }
        public void DrawBoard()
        {
            Raylib.DrawModel(board.model, new Vector3(0f, 1f, 0f), board.scale, Color.White);
        }
        private void DrawKing(Vector2 pos, Piece_Color color)
        {
            if (color == Piece_Color.White)
            {
                Raylib.DrawModel(GameMaster.our.king.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else if (color == Piece_Color.Black)
            {
                Raylib.DrawModel(GameMaster.opponent.king.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else
            {
                Console.WriteLine("Unknown Piece_Color found");
                Environment.Exit(-1);
            }
        }
        private void DrawQueen(Vector2 pos, Piece_Color color)
        {
            if (color == Piece_Color.White)
            {
                Raylib.DrawModel(GameMaster.our.queen.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else if (color == Piece_Color.Black)
            {
                Raylib.DrawModel(GameMaster.opponent.queen.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else
            {
                Console.WriteLine("Unknown Piece_Color found");
                Environment.Exit(-1);
            }
        }
        private void DrawBishop(Vector2 pos, Piece_Color color)
        {
            if (color == Piece_Color.White)
            {
                Raylib.DrawModel(GameMaster.our.bishop.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else if (color == Piece_Color.Black)
            {
                Raylib.DrawModel(GameMaster.opponent.bishop.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else
            {
                Console.WriteLine("Unknown Piece_Color found");
                Environment.Exit(-1);
            }
        }
        private void DrawKnight(Vector2 pos, Piece_Color color)
        {
            if (color == Piece_Color.White)
            {
                Raylib.DrawModel(GameMaster.our.knight.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else if (color == Piece_Color.Black)
            {
                Raylib.DrawModel(GameMaster.opponent.knight.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else
            {
                Console.WriteLine("Unknown Piece_Color found");
                Environment.Exit(-1);
            }
        }
        private void DrawRook(Vector2 pos, Piece_Color color)
        {
            if (color == Piece_Color.White)
            {
                Raylib.DrawModel(GameMaster.our.rook.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else if (color == Piece_Color.Black)
            {
                Raylib.DrawModel(GameMaster.opponent.rook.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else
            {
                Console.WriteLine("Unknown Piece_Color found");
                Environment.Exit(-1);
            }
        }
        private void DrawPawn(Vector2 pos, Piece_Color color)
        {
            if (color == Piece_Color.White)
            {
                Raylib.DrawModel(GameMaster.our.pawn.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else if (color == Piece_Color.Black)
            {
                Raylib.DrawModel(GameMaster.opponent.pawn.model, new Vector3(pos.X, 1f, pos.Y), GameMaster.scale, Color.White);
            }
            else
            {
                Console.WriteLine("Unknown Piece_Color found");
                Environment.Exit(-1);
            }
        }

        public void unload()
        {
            this.board.unloadModel();
        }
        public void BeginRender3D()
        {
            Raylib.BeginMode3D(this.camera.getCameraRef());
        }
        public void EndRender3D()
        {
            Raylib.EndMode3D();
        }

        public void DrawPiece(PieceKindEnum piece_kind, Piece_Color color, Vector2 pos)
        {
            pos = GameMaster.standardToRenderPosition(pos);
            switch (piece_kind)
            {
                case PieceKindEnum.King:
                    DrawKing(pos, color);
                    break;
                case PieceKindEnum.Queen:
                    DrawQueen(pos, color);
                    break;
                case PieceKindEnum.Bishop:
                    DrawBishop(pos, color);
                    break;
                case PieceKindEnum.Knight:
                    DrawKnight(pos, color);
                    break;
                case PieceKindEnum.Rook:
                    DrawRook(pos, color);
                    break;
                case PieceKindEnum.Pawn:
                    DrawPawn(pos, color);
                    break;
                case PieceKindEnum.UNKNOWN:
                    break;
                default:
                    Console.WriteLine("Unreachable code in DrawPiece reached");
                    Environment.Exit(-1);
                    break;
            }
        }
        public void DrawPiece(PieceKindEnum piece_kind, Piece_Color color, int x, int y)
        {
            DrawPiece(piece_kind, color, new Vector2(x, y));
        }
        // todo: change so it's easier to add some kind of animation.
        public void DrawBoardPieces(){
            for (int x = 0; x < 8; x++){
                for (int y = 0; y < 8; y++){
                    Vector2 currentPos = new Vector2(x, y);
                    if(GameMaster.BoardStatus.ContainsKey(currentPos)){
                        BoardPiece boardPiece;
                        GameMaster.BoardStatus.TryGetValue(currentPos, out boardPiece);
                        DrawPiece(boardPiece.kind,boardPiece.color,new Vector2(y+1,x+1));
                    }
                }
            }
        }
    }
}
