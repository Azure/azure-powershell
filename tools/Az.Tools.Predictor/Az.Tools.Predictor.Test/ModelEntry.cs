using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// Represents a command entry in the model files.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ModelEntry
    {
        /// <summary>
        /// The command in the model.
        /// </summary>
        [JsonProperty("suggestion", Required = Required.Always)]
        public string Command { get; set; }

        /// <summary>
        /// The description of the command in the model.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Description { get; set; }

        /// <summary>
        /// The prediction count in the model.
        /// </summary>
        [JsonProperty("suggestion count", Required = Required.Always)]
        public int PredictionCount { get; set; }

        /// <summary>
        /// The history count in the model.
        /// </summary>
        [JsonProperty("history count", Required = Required.Always)]
        public int HistoryCount { get; set; }

        /// <summary>
        /// Transforms the model entry into the client PredictiveCommand object.
        /// </summary>
        /// <returns>The PredictiveCommand object used on the client.</returns>
        public PredictiveCommand TransformEntry()
        {
            return new PredictiveCommand()
            {
                Command = this.Command,
                Description = this.Description
            };
        }
    }
}
