using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayLeftMessage { get; set; } = Data.Instance.IsDisplayMessageLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayRightMessage { get; set; } = Data.Instance.IsDisplayMessageRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayTechnicalTimeout { get; set; } = Data.Instance.IsDisplayMessage.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> Message { get; set; } = Data.Instance.Message.ObserveProperty(x=>x.Value).ToReactiveProperty();
    }
}