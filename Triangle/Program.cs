using LearnOpenTK.Triangle;
using OpenTK.Windowing.Desktop;

GameWindowSettings GameWindowSettings = GameWindowSettings.Default;

NativeWindowSettings NativeWindowSettings = NativeWindowSettings.Default;
using (var window = new TriangleWindow(GameWindowSettings, NativeWindowSettings))
{
    window.Run();
}