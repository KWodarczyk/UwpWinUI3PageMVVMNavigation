using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestAppUWP.ViewModels
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {    
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }    
    }
}
