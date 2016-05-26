using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Automation.Models;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Automation.Common;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The HybridRunbookWorkerGroup object.
    /// </summary>
    public class HybridRunbookWorkerGroup
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="HybridRunbookWorkerGroup"/> class. 
        /// </summary>
        /// <param name="resourceGroupName">
        ///  The resource group name.
        /// </param>
        /// <param name="accountName">
        /// The account name.
        /// </param>
        /// <exception cref="System.ArgumentException"
        /// </exception>
        
        public  HybridRunbookWorkerGroup()
        {

        }

        public HybridRunbookWorkerGroup(string resourceGroupName, string accountName, Azure.Management.Automation.Models.HybridRunbookWorkerGroup hybridRunbookWorkerGroup)
        {

            Requires.Argument("accountName", accountName).NotNull();
            Requires.Argument("hybridRunbookWorkerGroup", hybridRunbookWorkerGroup).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = accountName;
            
            this.Name = hybridRunbookWorkerGroup.Name;
            
            
            RunbookWorker = new List<HybridRunbookWorker>();
            foreach (var worker in hybridRunbookWorkerGroup.HybridRunbookWorkers)
            {
                var hbworker = new HybridRunbookWorker(worker.IpAddress, worker.Name, worker.RegistrationDateTime);                
                this.RunbookWorker.Add(hbworker);
            }
        }
        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automaiton account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the hybrid worker group name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a list of Runbook Workers 
        /// </summary>
        public List<HybridRunbookWorker> RunbookWorker { get; set; }

        
    }
}
