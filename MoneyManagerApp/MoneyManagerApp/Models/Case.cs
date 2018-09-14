using MoneyManagerApp.Models.Base;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManagerApp.Models
{
    public class Case : ModelBase
    {
        private string title;
        private string description;
        private string location;

        [JsonProperty("expenses")]
        public List<Expense> Expenses { get; set; } = new List<Expense>();

        [JsonProperty("title")]
        public string Title
        {
            get => title;
            set => this.RaiseAndSetIfChanged(ref title, value);
        }

        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }

        [JsonProperty("location")]
        public string Location
        {
            get => location;
            set => this.RaiseAndSetIfChanged(ref location, value);
        }
    }
}