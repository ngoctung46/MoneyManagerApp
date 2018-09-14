using MoneyManagerApp.Interfaces;
using MoneyManagerApp.Models;
using MoneyManagerApp.Service;
using MoneyManagerApp.ViewModels.Base;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.ViewModels
{
    public class EditCaseViewModel : ViewModelBase
    {
        private Case _case;
        private readonly CaseService service;

        public Case Case
        {
            get => _case;
            set => this.RaiseAndSetIfChanged(ref _case, value);
        }

        public ReactiveCommand<Unit, Unit> SaveCmd { get; private set; }
        public ReactiveCommand<Unit, Unit> CancelCmd { get; private set; }

        public EditCaseViewModel(ICaseService service, IScreen hostScreen = null) : base(hostScreen)
        {
            this.service = service as CaseService;
            Case = new Case();
            var canSave = Case.WhenAnyValue(x => x.Title, x => x.Description, x => x.Location,
                (title, description, location) => !string.IsNullOrWhiteSpace(title) &&
                !string.IsNullOrWhiteSpace(description) &&
                !string.IsNullOrWhiteSpace(location));
            SaveCmd = ReactiveCommand.CreateFromTask(Save, canSave);
            CancelCmd = ReactiveCommand.CreateFromTask(Cancel);
        }

        private Task Save()
        {
            var newCase = service.AddOne(Case);
            Cancel();
            return Task.CompletedTask;
        }

        private Task Cancel()
        {
            HostScreen.Router.NavigateBack.Execute().Subscribe();
            return Task.CompletedTask;
        }
    }
}