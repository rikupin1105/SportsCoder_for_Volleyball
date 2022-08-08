using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class SetViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayGetSet { get; set; } = Data.Instance.IsDisplayGetSet.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamRight { get; set; } = Data.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamLeft { get; set; } = Data.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetLeft { get; set; } = Data.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetRight { get; set; } = Data.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> ColorCodeLeftTeam { get; set; } = Data.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> ColorCodeRightTeam { get; set; } = Data.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}