using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSNotebookSessionProperties
    {
        public PSNotebookSessionProperties(NotebookSessionProperties notebookSessionProperties)
        {
            this.DriverMemory = notebookSessionProperties?.DriverMemory;
            this.DriverCores = notebookSessionProperties?.DriverCores;
            this.ExecutorMemory = notebookSessionProperties?.ExecutorMemory;
            this.ExecutorCores = notebookSessionProperties?.ExecutorCores;
            this.NumExecutors = notebookSessionProperties?.NumExecutors;
        }

        public string DriverMemory { get; set; }

        public int? DriverCores { get; set; }

        public string ExecutorMemory { get; set; }

        public int? ExecutorCores { get; set; }

        public int? NumExecutors { get; set; }
    }
}
