using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Shared;

namespace SportsCoderForVolleyball.HorizonalBottom.ViewModels
{
    public class SeparatedMessageViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayLeftMessage { get; set; } = UI.Instance.IsDisplaySeparatedMessageLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayRightMessage { get; set; } = UI.Instance.IsDisplaySeparatedMessageRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayCommonMessage { get; set; } = UI.Instance.IsDisplayMessage.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string?> Message { get; set; } = UI.Instance.Message.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}