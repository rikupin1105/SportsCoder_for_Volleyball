using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;
using System.Collections.Generic;
using static SportsCoderForVolleyball.Models.Control;

namespace SportsCoderForVolleyball.ViewModels
{
    public class PointPerSetViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayPointParSet { get; set; } = Data.Instance.IsDisplayPointParSet.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<List<PointParSetInfomationSource>> PointParSetSource { get; set; } = Data.Instance.PointParSetSource.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}