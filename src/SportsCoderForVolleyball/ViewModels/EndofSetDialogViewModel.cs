using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;

namespace SportsCoderForVolleyball.ViewModels
{
    public class EndofSetDialogViewModel : BindableBase, IDialogAware
    {
        public EndofSetDialogViewModel()
        {
            YesCommand.Subscribe(_ =>
            {
                RequestClose.Invoke(new DialogResult(ButtonResult.Yes));
            });
            NoCommand.Subscribe(_ =>
            {
                RequestClose.Invoke(new DialogResult(ButtonResult.No));
            });
        }

        public ReactiveCommand YesCommand { get; set; } = new();
        public ReactiveCommand NoCommand { get; set; } = new();
        public ReactiveProperty<string> Message { get; set; } = new();

        public string Title => "確認";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;
        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message.Value = parameters.GetValue<string>("message");
        }
    }
}
