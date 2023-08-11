using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Shared;

namespace SportsCoderForVolleyball.HorizonalBottom.ViewModels
{
    public class SetViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayGetSet { get; set; } = UI.Instance.IsDisplayGetSet.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamRight { get; set; } = UI.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamLeft { get; set; } = UI.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetLeft { get; set; } = UI.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetRight { get; set; } = UI.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> ColorCodeLeftTeam { get; set; } = UI.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> ColorCodeRightTeam { get; set; } = UI.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}