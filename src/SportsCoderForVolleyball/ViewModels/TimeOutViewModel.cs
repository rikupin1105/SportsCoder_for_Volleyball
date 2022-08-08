using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class TimeOutViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayLeftTimeout { get; set; } = Control.Instance.IsDisplayLeftTimeout.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayRightTimeout { get; set; } = Control.Instance.IsDisplayRightTimeout.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}