using MoneyManagerApp.Factory;
using MoneyManagerApp.Interfaces;
using MoneyManagerApp.ViewModels;
using MoneyManagerApp.Views;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MoneyManagerApp
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public RoutingState Router { get; protected set; }

        public AppBootstrapper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

            // Register services here
            Locator.CurrentMutable.Register(() => ServiceFactory.CreateCaseService(), typeof(ICaseService));
            Locator.CurrentMutable.Register(() => ServiceFactory.CreateExpenseService(), typeof(IExpenseService));
            // Register views here
            Locator.CurrentMutable.Register(() => new MainView(), typeof(IViewFor<MainViewModel>));
            Locator.CurrentMutable.Register(() => new CaseView(), typeof(IViewFor<CaseViewModel>));
            Locator.CurrentMutable.Register(() => new EditCaseView(), typeof(IViewFor<EditCaseViewModel>));

            this.Router.NavigateAndReset
                .Execute(new MainViewModel(Locator.CurrentMutable.GetService<ICaseService>()))
                .Subscribe();
        }

        public Page CreateMainPage()
        {
            return new RoutedViewHost();
        }
    }
}