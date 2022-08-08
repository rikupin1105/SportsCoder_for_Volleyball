using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class ServePointViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayServePointInfomation { get; set; } = Data.Instance.IsDisplayServePointInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamServePoint { get; set; } = Data.Instance.GameLeftTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamServePoint { get; set; } = Data.Instance.GameRightTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}