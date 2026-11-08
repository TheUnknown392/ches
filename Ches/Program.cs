using System.Numerics;
using gamemaster;
using Raylib_cs;
using model;
using render;
using debug;

const int width = 1000;
const int height = 700;

Raylib.InitWindow(width, height, "Ches - 2.5D Chess");
Raylib.SetTargetFPS(60);

Camera camera = new Camera();
RenderHandler renderHandler = new RenderHandler(camera);
Renderer renderer = new Renderer(camera, renderHandler);

Cursor3D cursor = new Cursor3D("Character", new Camera3D{
    Position = new Vector3(0f, 2f, 2f),
    Target = new Vector3(0f, 1f, 0f),
    Up = new Vector3(0f, 1f, 0f),
    FovY = 60f,
    Projection = CameraProjection.Perspective
}, 0.0f,0.5f, camera);

float a = 0.5f;
float b = 0.5f;

float mid = MathF.Sqrt((a * a) * (b * b));

while (!Raylib.WindowShouldClose())
{
    //Raylib.UpdateCamera(ref renderer.camera.getCameraRef(), CameraMode.ThirdPerson);
    if (Raylib.IsKeyDown(KeyboardKey.Q)) break;

    cursor.handleCursor();
    renderer.GetRendererInputs();

    Raylib.BeginDrawing();
      Raylib.ClearBackground(Color.RayWhite);
      renderer.BeginRender3D();
        Raylib.DrawGrid(20, 1f);
        Raylib.DrawLine3D(Vector3.Zero, new Vector3(5f, 0f, 0f), Color.Red);
        Raylib.DrawLine3D(Vector3.Zero, new Vector3(0f, 5f, 0f), Color.Yellow);
        Raylib.DrawLine3D(Vector3.Zero, new Vector3(0f, 0f, 5f), Color.Green);
        renderer.DrawBoard();
        renderer.DrawBoardPieces();
                
        cursor.DrawCursor();
    renderer.EndRender3D();


    Raylib.EndDrawing();
}
renderer.unload();
Raylib.CloseWindow();
