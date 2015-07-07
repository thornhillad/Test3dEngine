using System;
using System.Windows.Forms;
using SharpDX;
using SharpDX.DXGI;
//Microsoft DirectX Graphics Infrastructure (DXGI) handles enumerating graphics adapters, enumerating display modes, selecting buffer formats, 
//sharing resources between processes (such as, between applications and the Desktop Window Manager (DWM)), and presenting rendered frames to a window or monitor for display.
//You can use DXGI to present frames to a window, monitor, or other graphics component for eventual composition and display. You can also use DXGI to read the contents on a monitor.
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;
using SharpDX.Windows;


namespace Test3dEngine
{
    class ModelSwapChainDesc
    {
        //AT 12/06/2015 - Learning Direct X 11
        //This model class simply creates an object of the SwapChainDescription Struct.  Remember a struct is litreally just a structure comprising of variables.  Therefore it seems ideal to
        //create a model class to make it fully Object orientated
        //
        private SwapChainDescription _SwapChainDesc { get; set; }
        //BufferCount tells the swap chain how many buffers to create. We want one front buffer and one back buffer, so we'll typically put 2 in this value.
        private int _BufferCount { get; set; }
        //This value is required, and it tells DXGI what this swap chain is to be used for. There's only one value we will probably ever use here, and that is DXGI_USAGE_RENDER_TARGET_OUTPUT.
        private Usage _Usage { get; set; }
        private IntPtr _FormHandle { get; set; }
        private bool _IsWindowed { get; set; }
        //The following parameters construct the Mode Description. A ModeDescription structure describes the backbuffer display mode.
        //A back buffer is a render target whose contents will be sent to the device when GraphicsDevice.Present is called.
        //http://www.directxtutorial.com/lesson.aspx?lessonid=111-4-3
        private ModeDescription _ModeDescription { get; set; }
        private int _ModeDescriptionWidth { get; set; }
        private int _ModeDescriptionHeight { get; set; }
        private Rational _ModeDescriptionRefreshRate {get; set;}
        private Format _ModeDescriptionFormat{get; set;}
        //end of mode description parameters
        //The following parameters construct the Sample Description.  This tells the swap chain how to perform anti aliasing on each pixel.  http://hacksoflife.blogspot.co.uk/2011/04/so-many-aa-techniques-so-little-time.html
        private SampleDescription _SampleDescription { get; set; }
        private int _SampleDescriptionCount { get; set; }
        private int _SampleDescriptionQuality { get; set; }
        //end of sample description parameters
        private SwapChainFlags _SwapChainFlags { get; set; }
        private SwapEffect _SwapEffect { get; set; }

        public SwapChainDescription CreateSwapChain(int PBufferCount, Usage PUsage, IntPtr PFormHandle, bool PIsWindowed, int PModeDescriptionWidth, int PModeDescriptionHeight, Rational PModeDescriptionRefreshRate, Format PModeDescriptionFormat, int PSampleDescriptionCount, int PSampleDescriptionQuality, SwapChainFlags PSwapChainFlags, SwapEffect PSwapEffect)
        {

            this._BufferCount = PBufferCount;
            this._Usage = PUsage;
            this._FormHandle = PFormHandle;
            this._IsWindowed = PIsWindowed;
            this._ModeDescriptionWidth = PModeDescriptionWidth;
            this._ModeDescriptionHeight = PModeDescriptionHeight;
            this._ModeDescriptionRefreshRate = PModeDescriptionRefreshRate;
            this._ModeDescriptionFormat = PModeDescriptionFormat;
            this._SampleDescriptionCount = PSampleDescriptionCount;
            this._SampleDescriptionQuality = PSampleDescriptionQuality;
            this._SwapChainFlags = PSwapChainFlags;
            this._SwapEffect = PSwapEffect;
            _SampleDescription = new SampleDescription(_SampleDescriptionCount, _SampleDescriptionQuality);
            _ModeDescription = new ModeDescription(_ModeDescriptionWidth, _ModeDescriptionHeight, _ModeDescriptionRefreshRate, _ModeDescriptionFormat);
            _SwapChainDesc = new SwapChainDescription() { 
                BufferCount = _BufferCount,
                Usage=_Usage,
                OutputHandle=_FormHandle, 
                IsWindowed=_IsWindowed,
                ModeDescription=_ModeDescription,
                SampleDescription=_SampleDescription,
                Flags=_SwapChainFlags, 
                SwapEffect=_SwapEffect };

            return _SwapChainDesc;
        }

        //public IntPtr GetFormHandle() 
        //{
        //    IntPtr FormPointer = 1;
        //    return FormPointer;
        //}
        

    }
}
