using System;
using System.Windows.Input;

namespace VedroidLab2.Commands {
    class RelayCommand : ICommand {
        public RelayCommand(Action action, Func<bool> canExecute = null) {
            this.action_     = action;
            this.canExecute_ = canExecute;
        }

        public bool CanExecute(object parameter) =>
            this.canExecute_?.Invoke() ?? true;

        public void Execute(object parameter) =>
            this.action_?.Invoke();

        public event EventHandler CanExecuteChanged = (sender, args) => {};

        protected Action     action_;
        protected Func<bool> canExecute_;
    }
}