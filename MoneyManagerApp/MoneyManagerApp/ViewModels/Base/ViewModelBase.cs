using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManagerApp.ViewModels.Base
{
    public class ViewModelBase : ReactiveObject, IRoutableViewModel, ISupportsActivation
    {
        public ViewModelActivator Activator => viewModelActivator;

        public string UrlPathSegment { get; protected set; }

        public IScreen HostScreen { get; protected set; }

        protected readonly ViewModelActivator viewModelActivator = new ViewModelActivator();

        public ViewModelBase(IScreen hostScreen = null)
        {
            HostScreen = HostScreen ?? Locator.Current.GetService<IScreen>();
        }
    }
}