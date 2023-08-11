using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Shared;

namespace SportsCoderForVolleyball.VerticalLeft.ViewModels
{
    public class CommonMessageViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayCommonMessage { get; set; } = UI.Instance.IsDisplayMessage.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string?> Message { get; set; } = UI.Instance.Message.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}
