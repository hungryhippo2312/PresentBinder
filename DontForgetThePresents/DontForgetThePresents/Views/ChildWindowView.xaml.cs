using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using DontForgetThePresents.Core.Messenger;

namespace DontForgetThePresents.Views
{
    /// <summary>
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindowView : Window
    {
        public ChildWindowView(Window owner)
        {
            InitializeComponent();
            Owner = owner;

            Closing += (s, e) =>
                {
                    e.Cancel = true;
                    Messenger.Default.Send(new HideChildWindowMessage());
                };
        }
    }
}
