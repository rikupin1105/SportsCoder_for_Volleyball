using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Shared;

namespace SportsCoderForVolleyball.VerticalLeft.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayLeftMessage { get; set; } = UI.Instance.IsDisplayMessageLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayRightMessage { get; set; } = UI.Instance.IsDisplayMessageRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayTechnicalTimeout { get; set; } = UI.Instance.IsDisplayMessage.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string?> Message { get; set; } = UI.Instance.Message.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}
