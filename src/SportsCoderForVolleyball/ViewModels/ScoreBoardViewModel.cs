using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class ScoreBoardViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayScoreboard { get; set; } = Data.Instance.IsDisplayScoreboard.ObserveProperty(x => x.Value).ToReactiveProperty();

        //UI部品
        public ReactiveProperty<int> Set { get; set; } = Data.Instance.Set.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamRight { get; set; } = Data.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamLeft { get; set; } = Data.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointLeft { get; set; } = Data.Instance.PointLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointRight { get; set; } = Data.Instance.PointRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetLeft { get; set; } = Data.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetRight { get; set; } = Data.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsLeftServe { get; set; } = Data.Instance.IsLeftServe.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsRightServe { get; set; } = Data.Instance.IsRightServe.ObserveProperty(x => x.Value).ToReactiveProperty();

        //色
        public ReactiveProperty<string> ColorCodeLeftTeam { get; set; } = Data.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> ColorCodeRightTeam { get; set; } = Data.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();

    }
}