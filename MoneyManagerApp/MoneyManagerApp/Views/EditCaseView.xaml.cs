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
    public partial class EditCaseView : ContentPageBase<EditCaseViewModel>
    {
        public EditCaseView()
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
            d(this.Bind(ViewModel, vm => vm.Case.Title, v => v.TitleEntry.Text));
            d(this.Bind(ViewModel, vm => vm.Case.Description, v => v.DescriptionEntry.Text));
            d(this.Bind(ViewModel, vm => vm.Case.Location, v => v.LocationEntry.Text));
            d(this.BindCommand(ViewModel, vm => vm.CancelCmd, v => v.CancelButton));
            d(this.BindCommand(ViewModel, vm => vm.SaveCmd, v => v.SaveButton));
        }
    }
}