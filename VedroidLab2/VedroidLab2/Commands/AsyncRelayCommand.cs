using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VedroidLab2.Commands {
    public interface IAsyncCommand : ICommand {
        public Task ExecuteAsync();
        public bool CanExecute();
    }

    public class AsyncCommand : IAsyncCommand {
        public event EventHandler CanExecuteChanged;

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute = null) {
            this.execute_      = execute;
            this.canExecute_   = canExecute;
        }

        public bool CanExecute() {
            return !this.isExecuting_ && (this.canExecute_?.Invoke() ?? true);
        }

        public async Task ExecuteAsync() {
            if (this.CanExecute()) {
                try {
                    this.IsExecuting = true;
                    await this.execute_();
                }
                finally {
                    // TODO: add debuging this
                    this.IsExecuting = false;
                }
            }

            this.RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged() {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter) => this.CanExecute();
        void ICommand.Execute(object parameter)    => Task.Factory.StartNew(this.ExecuteAsync);

        private bool isExecuting_;

        public bool IsExecuting {
            get => this.isExecuting_;
            set {
                if (value == this.isExecuting_) {
                    return;
                }

                this.isExecuting_ = value;
                this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private readonly Func<Task>    execute_;
        private readonly Func<bool>    canExecute_;
    }
}
