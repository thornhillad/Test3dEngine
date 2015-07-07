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
    class ModelRenderTarget
    {
        private Size2F _DPI {get;set;}
        private RenderTarget _RenderTarget {get;set;}
        private SharpDX.Direct2D1.FeatureLevel _FeatureLevel{get;set;}
        private PixelFormat _PixelFormat{get;set;}
        private RenderTargetType _RenderType{get;set;}
        private RenderTargetUsage _RenderUsage{get;set;}

        public RenderTarget CreateRenderTarget(SharpDX.Direct2D1.FeatureLevel PFeatureLevel, PixelFormat PPixelFormat, RenderTargetType PRenderTargetType, RenderTargetUsage PRenderTargetUsage, Surface PBackBuffer, FactoryD2D PFactory)
        {
            this._FeatureLevel = PFeatureLevel;
            this._PixelFormat = PPixelFormat;
            this._RenderType = PRenderTargetType;
            this._RenderUsage = PRenderTargetUsage;
            _DPI = PFactory.DesktopDpi;

            _RenderTarget = new RenderTarget(PFactory, PBackBuffer, new RenderTargetProperties()
            {
                DpiX = _DPI.Width,
                DpiY = _DPI.Height,
                MinLevel = _FeatureLevel,
                PixelFormat = _PixelFormat,
                Type = _RenderType, 
                Usage= _RenderUsage

            });

            return _RenderTarget;
        }

         
            
    }
}
            //// Create Direct2D factory
            //using (var factory = new FactoryD2D())
            //{
            //    // Get desktop DPI
            //    var dpi = factory.DesktopDpi;

            //    // Create bitmap render target from DXGI surface
            //    renderTarget = new RenderTarget(factory, backBuffer, new RenderTargetProperties()
            //    {
            //        DpiX = dpi.Width,
            //        DpiY = dpi.Height,
            //        MinLevel = SharpDX.Direct2D1.FeatureLevel.Level_DEFAULT,
            //        PixelFormat = new PixelFormat(Format.Unknown, SharpDX.Direct2D1.AlphaMode.Ignore),
            //        Type = RenderTargetType.Default,
            //        Usage = RenderTargetUsage.None
            //    });
            //}