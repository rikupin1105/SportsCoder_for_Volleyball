using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class BlockPointViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayBlockPointInfomation { get; set; } = Data.Instance.IsDisplayBlockPointInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamBlockPoint { get; set; } = Data.Instance.GameLeftTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamBlockPoint { get; set; } = Data.Instance.GameRightTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}