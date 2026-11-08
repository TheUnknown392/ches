using System.Numerics;
using Raylib_cs;
using gamemaster;
using model;
namespace debug{
    public class Cursor3D{
        private Camera cameras;
        public float cursor_speed;
        public Vector3 cursor_pos;
        public Vector3 cursor_dist;
        public float cursor_rad;
        public Camera3D cursor_camera3d;
        public bool cursor_view;
        public string name;

        public Vector3 prev_cursor_pos;

        public Cursor3D(string cursor_name, Camera3D cursor_camera3d, float cursor_rad,float cursor_speed, Camera cameras){
            this.cameras = cameras;
            this.cursor_speed = cursor_speed;
            this.name = cursor_name;
            this.cursor_rad = cursor_rad;
            this.cursor_camera3d = cursor_camera3d;
            this.cursor_dist = cursor_camera3d.Position;
            this.cursor_pos = cursor_camera3d.Target;
            this.prev_cursor_pos = cursor_pos;
            this.cursor_view = false;
            this.cameras.addView(this.name, this.cursor_camera3d);
        }

        public void DrawCursor()
        {
            if (cursor_view)
            {
                this.cursor_camera3d.Target = cursor_pos;
                this.cursor_camera3d.Position = cursor_pos + cursor_dist;
                
                this.cameras.addView(this.name, this.cursor_camera3d);
                this.cameras.setView(this.name);
                if(cursor_pos != prev_cursor_pos && GameMaster.DEBUG){
                    Console.WriteLine($"DrawCursor. cursor_pos: {cursor_pos}, Cameras: {this.cursor_camera3d}");
                    prev_cursor_pos = cursor_pos;
                }
                Raylib.DrawSphere(cursor_pos, cursor_rad, Color.Pink);
            }else{
                this.cameras.setView("default");
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
    
    
