using OpenTK.Graphics.OpenGL4;

namespace LearnOpenTK.Common;
public class Shader
{
    public Shader(string vertexPath, string fragmentPath)
    {
        var shaderSource = File.ReadAllText(vertexPath);
        var vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, shaderSource);
        CompileShader(vertexShader);


        shaderSource = File.ReadAllText(fragmentPath);
        var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShader, shaderSource);
        CompileShader(fragmentShader);

        // merge into a shader program
        Handle = GL.CreateProgram();

        // Attach these shaders.
        GL.AttachShader(Handle, vertexShader);
        GL.AttachShader(Handle, fragmentShader);

        // Link
        LinkProgram(Handle);

        // free these shader.
        GL.DetachShader(Handle, vertexShader);
        GL.DetachShader(Handle, fragmentShader);
        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);


        //...
    }

    public int Handle { get; private set; }

    // enable shader program
    public void Use()
    {
        GL.UseProgram(Handle);
    }

    private static void CompileShader(int shader)
    {
        GL.CompileShader(shader);

        // check error
        GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
        if (code != (int)All.True)
        {
            var infoLog = GL.GetShaderInfoLog(shader);
            throw new Exception($"Error occurred when compile shader({shader}).\n\n{infoLog}");
        }
    }

    private static void LinkProgram(int program)
    {
        GL.LinkProgram(program);

        // check error
        GL.GetProgram(program, GetProgramParameterName.LinkStatus, out var code);
        if (code != (int)All.True)
        {
            throw new Exception($"Error occurred when link program({program})");
        }
    }
}
