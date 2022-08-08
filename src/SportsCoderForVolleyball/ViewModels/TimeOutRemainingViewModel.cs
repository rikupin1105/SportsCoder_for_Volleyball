using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class TimeOutRemainingViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayTimeoutRemaining { get; set; } = Data.Instance.IsDisplayTimeoutRemaining.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> TimeOutRight { get; set; } = Data.Instance.TimeOutRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> TimeOutLeft { get; set; } = Data.Instance.TimeOutLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}