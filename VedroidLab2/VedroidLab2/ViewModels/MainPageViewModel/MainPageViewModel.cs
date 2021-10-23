using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using VedroidLab2.Commands;
using VedroidLab2.Helpers.DialogService;

namespace VedroidLab2.ViewModels {
    class MainPageViewModel : BaseViewModel {
        public string Title                => "Моя первая проба пера";
        public string MainEntryPlaceholder => "Например, Саша";

        public string MainEntryText { get; set; } = string.Empty;

        public ICommand MainButtonCommand =>
            new RelayCommand(this.MainButtonMethod, () => this.MainEntryText.Length > 0);

        private readonly IDialogService dialogService_ = DialogService.Instance;

        private async void MainButtonMethod() =>
            await this.dialogService_.ShowMessage($"Привет, {this.MainEntryText}!", this.Title);
    }
}