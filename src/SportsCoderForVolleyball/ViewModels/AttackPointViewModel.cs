using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class AttackPointViewModel : BindableBase
    {
        public ReactiveProperty<int> GameLeftTeamAttackPoint { get; set; } = Data.Instance.GameLeftTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamAttackPoint { get; set; } = Data.Instance.GameRightTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayAttackPointInfomation { get; set; } = Data.Instance.IsDisplayAttackPointInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}