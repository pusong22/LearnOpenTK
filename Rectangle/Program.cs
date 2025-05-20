using LearnOpenTK.Rectangle;
using OpenTK.Windowing.Desktop;

GameWindowSettings GameWindowSettings = GameWindowSettings.Default;

NativeWindowSettings NativeWindowSettings = NativeWindowSettings.Default;
using (var window = new RectangleWindow(GameWindowSettings, NativeWindowSettings))
{
    window.Run();
}