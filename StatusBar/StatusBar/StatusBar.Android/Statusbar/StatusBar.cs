using Android.App;
using Android.OS;
using Android.Views;
using Plugin.CurrentActivity;
using StatusBar.ViewModel;
using StatusBar.Droid.Statusbar;
using System;
using Xamarin.Forms;
[assembly: Dependency(typeof(Statusbar))]
namespace StatusBar.Droid.StatusBar
{
    class StatusBar : StatusBarViewModel
    {

        WindowManagerFlags _originalFlags;
        Window GetCurrentWindow() 
        {
            var window = CrossCurrentActivity.Current.Activity.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return window;
        }
        public void CambiarColor()
        {
            MostrarStatusBar();
            //VERIFICA LA VERSION DEL SDK DEL ANDROID
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() => 
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutStable;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Blue);
                });
            }
        }

        public void MostrarStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            attrs.Flags =_originalFlags;
            activity.Window.Attributes = attrs;
        }

        public void OcultarStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags |= WindowManagerFlags.Fullscreen;// la equivalencia se la define asi  |=
            activity.Window.Attributes = attrs;
        }

        public void Transparente()
        {
            MostrarStatusBar();
            //VERIFICA LA VERSION DEL SDK DEL ANDROID
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutFullscreen;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Transparent);
                });
            }
        }

        public void Traslucido()
        {
            MostrarStatusBar();
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags |= WindowManagerFlags.TranslucentStatus;// la equivalencia se la define asi  |=
            activity.Window.Attributes = attrs;
        }
    }
}