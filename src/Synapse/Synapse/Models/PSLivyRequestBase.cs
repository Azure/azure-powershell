using Microsoft.Azure.Synapse.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLivyRequestBase
    {
        // TODO: create a command to create instances of this class then pass it to Submit*Job command?
        public PSLivyRequestBase(LivyRequestBase jobCreationRequest)
        {
            this.Name = jobCreationRequest?.Name;
            this.File = jobCreationRequest?.File;
            this.ClassName = jobCreationRequest?.ClassName;
            this.Args = jobCreationRequest?.Args;
            this.Jars = jobCreationRequest?.Jars;
            this.Files = jobCreationRequest?.Files;
            this.Archives = jobCreationRequest?.Archives;
            this.Conf = jobCreationRequest?.Conf;
            this.DriverMemory = jobCreationRequest?.DriverMemory;
            this.DriverCores = jobCreationRequest?.DriverCores;
            this.ExecutorMemory = jobCreationRequest?.ExecutorMemory;
            this.ExecutorCores = jobCreationRequest?.NumExecutors;
            this.NumExecutors = jobCreationRequest?.NumExecutors;
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
        public IList<string> Args { get; set; }

        /// <summary>
        /// </summary>
        public IList<string> Jars { get; set; }

        /// <summary>
        /// </summary>
        public IList<string> Files { get; set; }

        /// <summary>
        /// </summary>
        public IList<string> Archives { get; set; }

        /// <summary>
        /// </summary>
        public IDictionary<string, string> Conf { get; set; }

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
        public int? NumExecutors { get; set; }
    }
}