using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class SetPointViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayRightSetPoint { get; set; } = Data.Instance.IsDisplayRightSetPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayLeftSetPoint { get; set; } = Data.Instance.IsDisplayLeftSetPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}