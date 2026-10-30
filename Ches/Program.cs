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

Renderer render = new Renderer();
Cursor3D cursor = new Cursor3D("Character", new Camera3D{
    Position = new Vector3(0f, 2f, 2f),
    Target = new Vector3(0f, 1f, 0f),
    Up = new Vector3(0f, 1f, 0f),
    FovY = 60f,
    Projection = CameraProjection.Perspective
}, 0.0f,0.5f, render);

float a = 0.5f;
float b = 0.5f;

float mid = MathF.Sqrt((a * a) * (b * b));

while (!Raylib.WindowShouldClose())
{
    //Raylib.UpdateCamera(ref render.camera.getCameraRef(), CameraMode.ThirdPerson);
    if (Raylib.IsKeyDown(KeyboardKey.Q)) break;

    cursor.handleCursor();

    Raylib.BeginDrawing();
      Raylib.ClearBackground(Color.RayWhite);
      render.BeginRender3D();
        Raylib.DrawGrid(20, 1f);
        Raylib.DrawLine3D(Vector3.Zero, new Vector3(5f, 0f, 0f), Color.Red);
        Raylib.DrawLine3D(Vector3.Zero, new Vector3(0f, 5f, 0f), Color.Yellow);
        Raylib.DrawLine3D(Vector3.Zero, new Vector3(0f, 0f, 5f), Color.Green);
        render.DrawBoard();
        render.DrawBoardPieces();
        cursor.DrawCursor();
      render.EndRender3D();
    Raylib.EndDrawing();
}
render.unload();
Raylib.CloseWindow();
