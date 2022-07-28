using BlankApp1.ViewModels;
using BlankApp1.Views;
using Prism.Ioc;
using System.Windows;

namespace BlankApp1
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
