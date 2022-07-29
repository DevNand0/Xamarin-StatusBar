using System;
using System.Collections.Generic;
using System.Text;

namespace StatusBar.ViewModel
{
    public interface StatusBarViewModel
    {
        void OcultarStatusBar();
        void MostrarStatusBar();
        void Traslucido();
        void Transparente();
        void CambiarColor();
    }
}
