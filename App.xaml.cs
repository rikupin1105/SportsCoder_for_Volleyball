using SportsCoderForVolleyball.ViewModels;
using SportsCoderForVolleyball.Views;
using Prism.Ioc;
using System.Windows;

namespace SportsCoderForVolleyball
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ControlWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialogWindow<DialogWindow>("DialogWindow");

            containerRegistry.RegisterDialog<EndofSetDialog>("EndofSetDialog");
            containerRegistry.RegisterDialog<SettingDialog>("SettingDialog");
        }
    }
}
