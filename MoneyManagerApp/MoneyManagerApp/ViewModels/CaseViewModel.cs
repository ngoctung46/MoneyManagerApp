using MoneyManagerApp.Interfaces;
using MoneyManagerApp.Models;
using MoneyManagerApp.Service;
using MoneyManagerApp.ViewModels.Base;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.ViewModels
{
    public class CaseViewModel : ViewModelBase
    {
        private readonly CaseService service;
        private Case _case;
        public ObservableCollection<Expense> Expenses { get; set; }
        public ReactiveCommand<Unit, Unit> InitCmd { get; set; }

        public Case Case
        {
            get => _case;
            set => this.RaiseAndSetIfChanged(ref _case, value);
        }

        public CaseViewModel(ICaseService service, Case c, IScreen hostScreen = null) : base(hostScreen)
        {
            this.service = service as CaseService;
            _case = c;
            InitCmd = ReactiveCommand.CreateFromTask(Init);
        }

        private async Task Init()
        {
            var list = await service.GetExpenses(_case.Id);
            Expenses = new ObservableCollection<Expense>(list);
        }
    }
}