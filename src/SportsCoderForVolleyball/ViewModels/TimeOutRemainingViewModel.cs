using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class TimeOutRemainingViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayTimeoutRemaining { get; set; } = Control.Instance.IsDisplayTimeoutRemaining.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> TimeOutRight { get; set; } = Control.Instance.TimeOutRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> TimeOutLeft { get; set; } = Control.Instance.TimeOutLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}