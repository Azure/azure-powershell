using Azure.Analytics.Synapse.Spark.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLivyRequestBase
    {
        // TODO: create a command to create instances of this class then pass it to Submit*Job command?
        public PSLivyRequestBase(SparkRequest jobCreationRequest)
        {
            this.Name = jobCreationRequest?.Name;
            this.File = jobCreationRequest?.File;
            this.ClassName = jobCreationRequest?.ClassName;
            this.Arguments = jobCreationRequest?.Arguments;
            this.Jars = jobCreationRequest?.Jars;
            this.Files = jobCreationRequest?.Files;
            this.Archives = jobCreationRequest?.Archives;
            this.Configuration = jobCreationRequest?.Configuration;
            this.DriverMemory = jobCreationRequest?.DriverMemory;
            this.DriverCores = jobCreationRequest?.DriverCores;
            this.ExecutorMemory = jobCreationRequest?.ExecutorMemory;
            this.ExecutorCores = jobCreationRequest?.ExecutorCores;
            this.ExecutorCount = jobCreationRequest?.ExecutorCount;
        }

        /// <summary>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<string> Arguments { get; set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<string> Jars { get; set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<string> Files { get; set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<string> Archives { get; set; }

        /// <summary>
        /// </summary>
        public IReadOnlyDictionary<string, string> Configuration { get; set; }

        /// <summary>
        /// </summary>
        public string DriverMemory { get; set; }

        /// <summary>
        /// </summary>
        public int? DriverCores { get; set; }

        /// <summary>
        /// </summary>
        public string ExecutorMemory { get; set; }

        /// <summary>
        /// </summary>
        public int? ExecutorCores { get; set; }

        /// <summary>
        /// </summary>
        public int? ExecutorCount { get; set; }
    }
}