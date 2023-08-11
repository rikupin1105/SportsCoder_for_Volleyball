using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Shared;

namespace SportsCoderForVolleyball.HorizonalBottom.ViewModels
{
    public class InfomationViewModel : BindableBase
    {
        public ReactiveProperty<string?> Message { get; set; } = UI.Instance.Message.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string?> GameLeftTeamAttackPoint { get; set; } = UI.Instance.MessageLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string?> GameRightTeamAttackPoint { get; set; } = UI.Instance.MessageRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayAttackPointInfomation { get; set; } = UI.Instance.IsDisplayInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}