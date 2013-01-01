using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using DontForgetThePresents.Core.Messenger;

namespace DontForgetThePresents.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChildWindowView _childWindowView;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += (s, e) =>
                {
                    _childWindowView = new ChildWindowView(this);
                };
            Messenger.Default.Register<ShowChildWindowMessage>(this, (msg) => _childWindowView.ShowDialog());
            Messenger.Default.Register<HideChildWindowMessage>(this, (msg) => _childWindowView.Hide());
        }
    }
}
