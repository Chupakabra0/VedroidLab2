using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace VedroidLab2.Helpers.DialogService {
    public class DialogService : IDialogService {
        private static readonly Lazy<DialogService> instance_ = new Lazy<DialogService>(() => new DialogService());
        
        public static DialogService Instance => DialogService.instance_.Value;

        private static string cancelText_ = "OK";

        public async Task ShowError(string message, string title, string buttonText, Action afterHideCallback) {
            await Application.Current.MainPage.DisplayAlert(title, message, buttonText);
            afterHideCallback?.Invoke();
        }

        public async Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback) {
            await Application.Current.MainPage.DisplayAlert(title, error.Message, buttonText);
            afterHideCallback?.Invoke();
        }

        public async Task ShowMessage(string message, string title) {
            await Application.Current.MainPage.DisplayAlert(title, message, DialogService.cancelText_);
        }

        public async Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback) {
            await Application.Current.MainPage.DisplayAlert(title, message, buttonText);

            afterHideCallback?.Invoke();
        }

        public async Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText,
                                            Action<bool> afterHideCallback) {
            var result =
                await Application.Current.MainPage.DisplayAlert(title, message, buttonConfirmText, buttonCancelText);

            afterHideCallback?.Invoke(result);

            return result;
        }

        public async Task ShowMessageBox(string message, string title) {
            await Application.Current.MainPage.DisplayAlert(title, message, DialogService.cancelText_);
        }

        private DialogService() {
        }
    }
}