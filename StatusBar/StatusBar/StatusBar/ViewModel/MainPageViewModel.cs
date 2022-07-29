using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using StatusBar.ViewModel;
using Xamarin.Forms;
namespace StatusBar.ViewModel
{
    public class MainPageViewModel
    {
        public MainPageViewModel() 
        { 
        
        }

        public void Ocultar() 
        {
            DependencyService.Get<StatusBarViewModel>().OcultarStatusBar();
        }


        public void Mostrar()
        {
            DependencyService.Get<StatusBarViewModel>().MostrarStatusBar();
        }


        public void Traslucido() 
        {
            DependencyService.Get<StatusBarViewModel>().Traslucido();
        }


        public void Transparente()
        {
            DependencyService.Get<StatusBarViewModel>().Transparente();
        }


        public void CambiaColor()
        {
            DependencyService.Get<StatusBarViewModel>().CambiarColor();
        }


        public ICommand OcultarCommand => new Command(Ocultar);
        public ICommand MostrarCommand => new Command(Mostrar);
        public ICommand TraslucidoCommand => new Command(Traslucido);
        public ICommand TransparenteCommand => new Command(Transparente);
        public ICommand CambiaColorCommand => new Command(CambiaColor);

    }
}
