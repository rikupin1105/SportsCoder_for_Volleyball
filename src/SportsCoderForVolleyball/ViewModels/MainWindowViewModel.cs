using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;
using SportsCoderForVolleyball.Shared;

namespace SportsCoderForVolleyball.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> BackGroundColor { get; set; } = UI.Instance.BackGroundColor.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}