using System.Windows;
using DontForgetThePresents.Core.Messenger;
using GalaSoft.MvvmLight.Messaging;

namespace DontForgetThePresents.Views.ChildWindowViews
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
