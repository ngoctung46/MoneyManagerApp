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
    public partial class CaseView : ContentPageBase<CaseViewModel>
    {
        public CaseView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, false);
            this.WhenActivated(Bind);
        }

        private void Bind(Action<IDisposable> d)
        {
            this.OneWayBind(ViewModel, vm => vm.Case.Title, v => v.Title);
            this.OneWayBind(ViewModel, vm => vm.Case.Location, v => v.LocationLabel.Text);
            this.OneWayBind(ViewModel, vm => vm.Case.CreatedAt, v => v.TimeLabel.Text,
                time => time.ToString("dd/MM/yyyy"));
            this.WhenAnyObservable(x => x.ViewModel.InitCmd)
                .Subscribe(_ => ExpenseListView.ItemsSource = ViewModel.Expenses);
            ViewModel.InitCmd.Execute().Subscribe();
        }
    }
}