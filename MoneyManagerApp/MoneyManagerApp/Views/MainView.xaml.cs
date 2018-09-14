using MoneyManagerApp.Models;
using MoneyManagerApp.ViewModels;
using MoneyManagerApp.Views.Base;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyManagerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPageBase<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
            this.WhenActivated(Bind);
        }

        private void Bind(Action<IDisposable> d)
        {
            d(this.BindCommand(ViewModel, vm => vm.NavigateCmd, v => v.CaseListView, nameof(ListView.ItemSelected)));
            d(this.Bind(ViewModel, vm => vm.Case, v => v.CaseListView.SelectedItem));
            d(this.BindCommand(ViewModel, vm => vm.AddCmd, v => v.AddButton));
            d(ViewModel.InitCmd.Execute().Subscribe(_ =>
            {
                this.OneWayBind(ViewModel, vm => vm.Cases, v => v.CaseListView.ItemsSource);
                LoadingIndicator.IsRunning = false;
                CaseListView.IsVisible = true;
            }));
        }
    }
}