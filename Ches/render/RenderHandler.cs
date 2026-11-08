using Raylib_cs;
using System.Numerics;
using gamemaster;
using model;
namespace render{
    public class RenderHandler{
        
        private Camera camera;

        
        public RenderHandler(Camera camera){
            this.camera = camera;
        }
        
        public void DrawMousePos(){
            if(Raylib.IsKeyDown(KeyboardKey.M)){
                Vector2 mousePos = Raylib.GetMousePosition();
                Raylib.DrawText(mousePos.ToString(), 10, 10, 10, Color.Red);
            }
        }

        public RayCollision getPieceMouseCollision(Vector2 currentPiecePos){
            Vector2 mousePosition = Raylib.GetMousePosition();
            
            Ray ray = Raylib.GetScreenToWorldRay(mousePosition, camera.getCamera());

            BoundingBox pieceBB = getPieceRenderBoundingBox(currentPiecePos);
            return Raylib.GetRayCollisionBox(ray,pieceBB);
        }
        
        public RayCollision getPieceMouseCollision(Vector2 currentPiecePos, BoardPiece boardPiece)
        {
            Vector2 mousePosition = Raylib.GetMousePosition();

            Ray ray = Raylib.GetScreenToWorldRay(mousePosition, camera.getCamera());

            BoundingBox pieceBB = getPieceRenderBoundingBox(currentPiecePos);
            return Raylib.GetRayCollisionBox(ray, pieceBB);
        }


        public RayCollision getPieceMouseCollision(float x, float y){
            return getPieceMouseCollision(new Vector2(x,y));
        }
        
        public BoundingBox getPieceRenderBoundingBox(Vector2 currentPiecePos){
            BoardPiece boardPiece;
            GameMaster.BoardStatus.TryGetValue(currentPiecePos, out boardPiece);
            return GetPieceRenderingBoundingBox(boardPiece.kind, boardPiece.color, currentPiecePos);
        }
        
        public BoundingBox getPieceRenderBoundingBox(Vector2 currentPiecePos, BoardPiece boardPiece){
            return GetPieceRenderingBoundingBox(boardPiece.kind, boardPiece.color, currentPiecePos);
        }
        
        public static BoundingBox GetPieceRenderingBoundingBox(PieceKindEnum piece_kind, Piece_Color color, Vector2 standard_pos){
            BoundingBox Modelbb = GameMaster.getPieceByPieceKind(piece_kind, color).boundingBox;
            
            float renderX = CoordinateHandler.standardToRenderPosition(standard_pos.X+1, standard_pos.Y+1).X;
            float renderY = CoordinateHandler.standardToRenderPosition(standard_pos.X+1, standard_pos.Y+1).Y;

            Vector3 renderPos = new Vector3(renderX, 1f, renderY);  
            return new BoundingBox(
                Modelbb.Min*GameMaster.scale + renderPos,
                Modelbb.Max*GameMaster.scale + renderPos
            );
        }
        
         public BoardPiece getBoardPieceByMouse(){
             Vector2 mousePosition = Raylib.GetMousePosition();
             Ray ray = Raylib.GetScreenToWorldRay(mousePosition, camera.getCamera());
             foreach(KeyValuePair<Vector2, BoardPiece> kv in GameMaster.BoardStatus){
                 if(kv.Value.boundingBox == null) continue;
                
                 RayCollision collision = Raylib.GetRayCollisionBox(ray, (BoundingBox)kv.Value.boundingBox);
                 if(collision.Hit){
                     return kv.Value;
                 }
             }
             return new BoardPiece{
                 kind = PieceKindEnum.UNKNOWN,
                 color = Piece_Color.UNKNOWN,
                 boundingBox = null
             };
         }
         // todo: after defining renderhandler globally, get inputs directly by RenderHandler to update selectedpiece
         public void GetRendererInputs(){ 
             if(Raylib.IsMouseButtonPressed(MouseButton.Left)){
                 BoardPiece boardPiece = getBoardPieceByMouse();
                 if(boardPiece.kind != PieceKindEnum.UNKNOWN){
                     //GameMaster.ourSelectedBoardPiece.boardPiece.
                 }
                
             }
         }

    }
}
