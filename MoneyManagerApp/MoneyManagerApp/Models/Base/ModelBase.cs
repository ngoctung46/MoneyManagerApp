using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManagerApp.Models.Base
{
    public abstract class ModelBase : ReactiveObject
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}