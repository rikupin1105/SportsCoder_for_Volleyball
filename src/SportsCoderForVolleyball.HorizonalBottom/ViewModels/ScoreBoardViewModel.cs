using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Shared;

namespace SportsCoderForVolleyball.HorizonalBottom.ViewModels
{
    public class ScoreBoardViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayScoreboard { get; set; } = UI.Instance.IsDisplayScoreboard.ObserveProperty(x => x.Value).ToReactiveProperty();

        //UI部品
        public ReactiveProperty<int> Set { get; set; } = UI.Instance.Set.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamRight { get; set; } = UI.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamLeft { get; set; } = UI.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointLeft { get; set; } = UI.Instance.PointLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointRight { get; set; } = UI.Instance.PointRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetLeft { get; set; } = UI.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetRight { get; set; } = UI.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsLeftServe { get; set; } = UI.Instance.IsLeftServe.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsRightServe { get; set; } = UI.Instance.IsRightServe.ObserveProperty(x => x.Value).ToReactiveProperty();

        //色
        //public ReactiveProperty<string> ColorCodeLeftTeam { get; set; } = UI.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        //public ReactiveProperty<string> ColorCodeRightTeam { get; set; } = UI.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();

    }
}