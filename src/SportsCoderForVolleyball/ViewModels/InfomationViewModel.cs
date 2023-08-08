using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class InfomationViewModel : BindableBase
    {
        public ReactiveProperty<string> Message { get; set; } = Data.Instance.Message.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> GameLeftTeamAttackPoint { get; set; } = Data.Instance.MessageLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> GameRightTeamAttackPoint { get; set; } = Data.Instance.MessageRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayAttackPointInfomation { get; set; } = Data.Instance.isDisplayInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}