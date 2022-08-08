using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class ServeErrorViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayServeErrorInfomation { get; set; } = Data.Instance.IsDisplayServeErrorInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamServeError { get; set; } = Data.Instance.GameLeftTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamServeError { get; set; } = Data.Instance.GameRightTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}