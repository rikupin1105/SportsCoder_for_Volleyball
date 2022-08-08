using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> BackGroundColor { get; set; } = Control.Instance.BackGroundColor.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}