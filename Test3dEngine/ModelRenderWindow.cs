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
    class ModelRenderWindow
    {
        private RenderForm RenderWindowInstance { get; set; }
        private int _WindowLength;
        private int _WindowHeight;
        private FormStartPosition _FormPosition;

        public RenderForm CreateWindow(int PWindowHeight, int PWindowLength, FormStartPosition PScreenPosition)
        {
            this._WindowHeight = PWindowHeight;
            this._WindowLength = PWindowLength;
            this._FormPosition = PScreenPosition;
           
            RenderWindowInstance = new RenderForm();
            RenderWindowInstance.ClientSize = new System.Drawing.Size(_WindowLength, _WindowHeight);
            RenderWindowInstance.StartPosition = FormStartPosition.CenterScreen;
            return RenderWindowInstance;
        }


    }
}
