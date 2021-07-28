namespace MinecraftDotNet.ClientSide

open System.Collections.Generic
open ObjectTK.Tools
open ObjectTK.Tools.Cameras
open OpenTK
open OpenTK.Graphics
open OpenTK.Graphics.OpenGL4

type RenderAction = delegate of projection: Matrix4 * modelView: Matrix4 -> unit

type McGameWindow(camera: Camera) =
    inherit DerpWindow(1024, 720, GraphicsMode.Default, "Minecraft .NET Edition")
    
    let renderActions = Queue<RenderAction>()
    
    let mutable projectionMatrix = Unchecked.defaultof<Matrix4>
    let mutable viewMatrix = Unchecked.defaultof<Matrix4>
    
    member _.AddRenderAction(action) =
        renderActions.Enqueue(action)
    
    override this.OnLoad(e) =
        base.OnLoad(e)
        GL.ClearColor(Color.MidnightBlue)
        
        GL.Enable(EnableCap.DepthTest)
        GL.DepthFunc(DepthFunction.Less)
    
    override this.OnRenderFrame(e) =
        base.OnRenderFrame(e)
        
        this.Title <- $"MC.NET - FPS {round this.RenderFrequency}"
        
        GL.Clear(ClearBufferMask.ColorBufferBit ||| ClearBufferMask.DepthBufferBit)
        
        this.SetupPerspective()
        
        camera.Update()
        
        for renderAction in renderActions do
            renderAction.Invoke(projectionMatrix, viewMatrix)
        
        this.SwapBuffers()
    
    override this.OnResize(e) =
        base.OnResize(e)
        
        GL.Viewport(0, 0, this.Width, this.Height)
    
    /// <summary>
    /// Sets a perspective projection matrix and applies the camera transformation on the modelview matrix.
    /// </summary>
    member private this.SetupPerspective() =
        let aspectRatio = float32 this.Width / float32 this.Height
        projectionMatrix <- Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 0.1f, 1000f)
        viewMatrix <- Matrix4.Identity
        viewMatrix <- camera.GetCameraTransform()
    