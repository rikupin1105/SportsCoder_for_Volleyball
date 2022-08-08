using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class ServeErrorViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayServeErrorInfomation { get; set; } = Control.Instance.IsDisplayServeErrorInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamServeError { get; set; } = Control.Instance.GameLeftTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamServeError { get; set; } = Control.Instance.GameRightTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}