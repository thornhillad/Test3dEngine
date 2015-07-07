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
    static class Program
    {
        static void Main()
        {
            ThreeDeeObjects NewTestEngine = new ThreeDeeObjects();
            NewTestEngine.Create3dObjects();
        }
    }
}