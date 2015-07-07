using System;
using System.Windows.Forms;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;
using SharpDX.Windows;
using Device = SharpDX.Direct3D11.Device;
using FactoryD2D = SharpDX.Direct2D1.Factory;
using FactoryDXGI = SharpDX.DXGI.Factory1;

namespace Test3dEngine
{
    class ThreeDeeObjects
    {

        private Device GraphicsDevice;
        private SwapChain NewSwapChain;
        private SwapChainDescription SwapChainD;
        private ModelSwapChainDesc SwapChainCreator;
        private Surface BackBuffer;
        private ModelRenderTarget RenderTargetInstance;
        private RenderTarget RenderTarget;
        private RenderForm FormInstance;
        private ModelRenderWindow RenderWindowInstance;

        public void Create3dObjects() 
        
        {
            //Create RenderWindow
            RenderWindowInstance = new ModelRenderWindow();
            FormInstance = RenderWindowInstance.CreateWindow(1080,1240,FormStartPosition.CenterScreen);
            
            //Create SwapChain
            SwapChainCreator = new ModelSwapChainDesc();
            SwapChainD = SwapChainCreator.CreateSwapChain(2, Usage.RenderTargetOutput, FormInstance.Handle, true, 0, 0, new Rational(60, 1), Format.R8G8B8A8_UNorm, 1,0,SwapChainFlags.AllowModeSwitch, SwapEffect.Discard);

            //Create Device
            Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.BgraSupport, SwapChainD, out GraphicsDevice, out NewSwapChain);
                
            //Create Back buffer
            BackBuffer = Surface.FromSwapChain(NewSwapChain, 0);

            //Create Factory
            FactoryD2D FactoryInstance = new FactoryD2D();

            //Create RenderTarget
            RenderTargetInstance = new ModelRenderTarget();
            RenderTarget = RenderTargetInstance.CreateRenderTarget(SharpDX.Direct2D1.FeatureLevel.Level_DEFAULT, new PixelFormat(Format.Unknown, SharpDX.Direct2D1.AlphaMode.Ignore), RenderTargetType.Default, RenderTargetUsage.None, BackBuffer, FactoryInstance);


            RenderLoop.Run(FormInstance, () =>
            {

                RenderTarget.BeginDraw();
                RenderTarget.Transform = Matrix3x2.Identity;
                RenderTarget.Clear(Color.White);
                
                using (var brush = new SolidColorBrush(RenderTarget, Color.Red))
                {
                    //for (int x = 0; x < RenderTarget.Size.Width; x += 10)
                    //    RenderTarget.DrawLine(new Vector2(x, 0), new Vector2(x, RenderTarget.Size.Height), brush, 0.5f);

                    //for (int y = 0; y < RenderTarget.Size.Height; y += 10)
                    //    RenderTarget.DrawLine(new Vector2(0, y), new Vector2(RenderTarget.Size.Width, y), brush, 0.5f);
                    RenderTarget.DrawLine(new Vector2(300, 10), new Vector2(300, 300), brush,1.5f);
                   // RenderTarget.FillRectangle(new RectangleF(RenderTarget.Size.Width / 2 - 50, RenderTarget.Size.Height / 2 - 50, 100, 100), brush);
                }

              //  RenderTarget.DrawRectangle(
                   // new RectangleF(RenderTarget.Size.Width / 2 - 100, RenderTarget.Size.Height / 2 - 100, 200, 200),
                   // new SolidColorBrush(RenderTarget, Color.CornflowerBlue));

                RenderTarget.EndDraw();

                NewSwapChain.Present(0, PresentFlags.None);
            });

            RenderTarget.Dispose();
            NewSwapChain.Dispose();
            GraphicsDevice.Dispose();


        }

        //private RenderForm RenderWindow;
        
        //    Device CurrentDevice = new Device()
          
    
        //RenderLoop.Run(RenderWindow, RenderCallback);
        //    public void RenderCallback()
        //    {
        //        RenderWindow.Text = "hi";
               
        //    }
       
    }
}



