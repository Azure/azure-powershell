using System.Linq;

namespace Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models
{
    // require partial class in order to add a property to the model

    public partial class Remediation
    {
        // Adding field to the class that can hold deployment details if requested 

        /// <summary>
        /// The details of the deployments caused by the remediation. 
        /// </summary>
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IRemediationDeployment> Deployments { get; set; }
    }
}