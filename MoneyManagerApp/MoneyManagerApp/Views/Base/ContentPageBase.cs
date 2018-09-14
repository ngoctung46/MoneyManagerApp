using ReactiveUI.XamForms;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;

namespace MoneyManagerApp.Views.Base
{
    public class ContentPageBase<TViewModel>
        : ReactiveContentPage<TViewModel> where TViewModel : class
    {
        protected readonly CompositeDisposable SubscriptionDisposable = new CompositeDisposable();

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SubscriptionDisposable.Clear();
        }
    }
}