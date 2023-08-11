using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;
using SportsCoderForVolleyball.Shared;
using static SportsCoderForVolleyball.Models.Control;

namespace SportsCoderForVolleyball.ViewModels
{
    public class PointPerSetViewModel : BindableBase
    {
        public ReactiveProperty<string> TeamLeft { get; set; } = UI.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamRight { get; set; } = UI.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();

        public ReactiveProperty<int> TeamLeftSet { get; set; } = UI.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> TeamRightSet { get; set; } = UI.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();

        public ReactiveProperty<bool> IsDisplayPointParSet { get; set; } = UI.Instance.IsDisplayPointParSet.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReadOnlyReactiveCollection<PointParSetInfomationSource> PointParSetSource { get; set; } = Data.Instance.PointParSetSource.ToReadOnlyReactiveCollection();
    }
}