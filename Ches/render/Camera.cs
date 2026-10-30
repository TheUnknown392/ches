using Raylib_cs;
using System.Numerics;
namespace render{
    public class Camera{
        private Camera3D camera;
        private Vector3 camera_distance = new Vector3(0f, 5f, 4.2f);
        // change this string to enum?
        private Dictionary<string, Camera3D> views = new Dictionary<string, Camera3D>();
        public Camera(){
            views.Add("default",new Camera3D
            {
                Position = camera_distance,
                Target = new Vector3(0f, 0f, 0f),
                Up = new Vector3(0f, 1f, 0f),
                FovY = 60f,
                Projection = CameraProjection.Perspective
            });
            setView("default");
        }
        public bool setView(string name){
            Camera3D temp;
            if(!getView(name, out temp)) return false;
            this.camera = temp;
            return true;
        }
        public void addView(string name,Camera3D camera){
            if(views.TryGetValue(name, out var temp)){
                views.Remove(name);
            }
            views.Add(name, camera);
        }
        public bool getView(string name, out Camera3D camera){
            return views.TryGetValue(name, out camera);
        }
        public Camera3D getCamera(){
            return this.camera;
        }
        public ref Camera3D getCameraRef(){
            return ref this.camera;
        }
    }
}
