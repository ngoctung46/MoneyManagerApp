using MoneyManagerApp.Interfaces;
using MoneyManagerApp.Models;
using MoneyManagerApp.Service;
using MoneyManagerApp.ViewModels.Base;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Case> Cases { get; set; }
        public ReactiveCommand<Unit, Unit> AddCmd { get; private set; }
        public ReactiveCommand<Unit, Unit> NavigateCmd { get; private set; }
        public ReactiveCommand<Unit, Unit> InitCmd { get; private set; }
        public Case Case { get; set; }
        private readonly CaseService service;

        public MainViewModel(ICaseService service, IScreen hostScreen = null)
            : base(hostScreen)
        {
            this.service = service as CaseService;
            AddCmd = ReactiveCommand.Create(Add);
            NavigateCmd = ReactiveCommand.Create(Navigate);
            InitCmd = ReactiveCommand.CreateFromTask(Init);
        }

        private async Task Init()
        {
            var list = await service.GetAll();
            Cases = new ObservableCollection<Case>(list);
        }

        private void Navigate()
        {
            HostScreen.Router.Navigate
                .Execute(new CaseViewModel(Locator.CurrentMutable.GetService<ICaseService>(), Case))
                .Subscribe();
        }

        private void Add()
        {
            HostScreen.Router.Navigate
                .Execute(new EditCaseViewModel(Locator.CurrentMutable.GetService<ICaseService>()))
                .Subscribe();
        }
    }
}