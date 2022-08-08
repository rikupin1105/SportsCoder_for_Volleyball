using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class ServePointViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayServePointInfomation { get; set; } = Control.Instance.IsDisplayServePointInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamServePoint { get; set; } = Control.Instance.GameLeftTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamServePoint { get; set; } = Control.Instance.GameRightTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}