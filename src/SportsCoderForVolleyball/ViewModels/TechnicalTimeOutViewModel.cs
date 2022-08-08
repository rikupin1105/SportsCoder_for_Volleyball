using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class TechnicalTimeOutViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayTechnicalTimeout { get; set; } = Control.Instance.IsDisplayTechnicalTimeout.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}