using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayLeftMessage { get; set; } = Data.Instance.isDisplayMessageLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayRightMessage { get; set; } = Data.Instance.isDisplayMessageRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayTechnicalTimeout { get; set; } = Data.Instance.isDisplayMessage.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> Message { get; set; } = Data.Instance.Message.ObserveProperty(x=>x.Value).ToReactiveProperty();
    }
}