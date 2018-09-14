using MoneyManagerApp.Models.Base;
using MoneyManagerApp.Utility;
using Newtonsoft.Json;
using ReactiveUI;

namespace MoneyManagerApp.Models
{
    public class Expense : ModelBase
    {
        private string description;
        private double amount;
        private ExpenseType type;
        private string title;
        private string caseId;

        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }

        [JsonProperty("amount")]
        public double Amount
        {
            get => amount;
            set => this.RaiseAndSetIfChanged(ref amount, value);
        }

        [JsonProperty("type")]
        public ExpenseType Type
        {
            get => type;
            set => this.RaiseAndSetIfChanged(ref type, value);
        }

        [JsonProperty("title")]
        public string Title
        {
            get => title;
            set => this.RaiseAndSetIfChanged(ref title, value);
        }

        [JsonProperty("case_id")]
        public string CaseId
        {
            get => caseId;
            set => this.RaiseAndSetIfChanged(ref caseId, value);
        }

        public Expense()
        {
        }
    }
}