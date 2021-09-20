using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using PropertyChanged;

namespace VedroidLab2.ViewModels {
    /// <summary>
    ///     Base view-model with implementation of INotifyPropertyChanged interface
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    abstract class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Inform view, that some property have changed
        /// </summary>
        /// <param name="propertyName">
        ///     Caller property name
        /// </param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}