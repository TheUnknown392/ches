using System.Numerics;
using Raylib_cs;
using render;
namespace debug{
    public class Cursor3D{
        private Renderer renderer;
        public float cursor_speed;
        public Vector3 cursor_pos;
        public Vector3 cursor_dist;
        public float cursor_rad;
        public Camera3D camera;
        public bool cursor_view;
        public string name;

        public Vector3 prev_cursor_pos;

        public Cursor3D(string cursor_name, Camera3D camera, float cursor_rad,float cursor_speed, Renderer renderer){
            this.renderer = renderer;
            if(renderer == null){
                Raylib.TraceLog(TraceLogLevel.Error, "No renderer found for Cursor3D");
                Environment.Exit(-1);
            }
            this.cursor_speed = cursor_speed;
            this.name = cursor_name;
            this.cursor_rad = cursor_rad;
            this.camera = camera;
            this.cursor_dist = camera.Position;
            this.cursor_pos = camera.Target;
            this.prev_cursor_pos = cursor_pos;
            this.cursor_view = false;
            this.renderer.camera.addView(cursor_name,camera);
        }

        public void DrawCursor()
        {
            if (cursor_view)
            {
                this.camera.Target = cursor_pos;
                this.camera.Position = cursor_pos + cursor_dist;
                this.renderer.camera.setView(this.name);
                this.renderer.camera.addView(this.name, this.camera);
                if(cursor_pos != prev_cursor_pos){
                    Console.WriteLine($"DrawCursor. cursor_pos: {cursor_pos}, Camera: {this.camera}");
                    prev_cursor_pos = cursor_pos;
                }
                Raylib.DrawSphere(cursor_pos, cursor_rad, Color.Pink);
            }
        }

        public void handleCursor(){
            if(Raylib.IsKeyDown(KeyboardKey.W))
            {
                cursor_pos.Z -= cursor_speed * Raylib.GetFrameTime();
            }

            if(Raylib.IsKeyDown(KeyboardKey.S))
            {
                cursor_pos.Z += cursor_speed * Raylib.GetFrameTime();
            }

            if(Raylib.IsKeyDown(KeyboardKey.A))
            {
                cursor_pos.X -= cursor_speed * Raylib.GetFrameTime();
            }

            if(Raylib.IsKeyDown(KeyboardKey.D))
            {
                cursor_pos.X += cursor_speed * Raylib.GetFrameTime();
            }

            if (Raylib.IsKeyDown(KeyboardKey.LeftShift))
            {
                if(Raylib.IsKeyDown(KeyboardKey.N))
                {
                    cursor_pos.Y -= cursor_speed * Raylib.GetFrameTime();
                }
                if(Raylib.IsKeyDown(KeyboardKey.P))
                {
                    cursor_pos.Y += cursor_speed * Raylib.GetFrameTime();
                }
                if (Raylib.IsKeyPressed(KeyboardKey.C)) cursor_view = cursor_view^true;
      
                if (Raylib.IsKeyPressed(KeyboardKey.R)) cursor_pos = Vector3.Zero;
            }
        }        
    }
}
    
    
