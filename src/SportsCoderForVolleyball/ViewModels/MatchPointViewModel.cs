using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class MatchPointViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayLeftMatchPoint { get; set; } = Control.Instance.IsDisplayLeftMatchPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayRightMatchPoint { get; set; } = Control.Instance.IsDisplayRightMatchPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}