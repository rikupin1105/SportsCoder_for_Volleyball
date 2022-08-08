using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;
using System.Collections.Generic;

namespace SportsCoderForVolleyball.ViewModels
{
    public class PointPerSetViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayPointParSet { get; set; } = Control.Instance.IsDisplayPointParSet.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<List<Control.PointParSetInfomationSource>> PointParSetSource { get; set; } = Control.Instance.PointParSetSource.ObserveProperty(x => x.Value).ToReactiveProperty();

        public PointPerSetViewModel()
        {

        }
    }
}