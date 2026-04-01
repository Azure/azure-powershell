using System.Linq;

namespace Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models
{
    // require partial class in order to add a property to the model

    public partial class PolicyAssignmentSummary
    {
        /// <summary>
        /// The count of compliant resources in the policy assignment summary.
        /// </summary>
        public int? ResultCompliantResource
        {
            get
            {
                // Safely handle null ResultResourceDetail
                var complianceDetail = this.ResultResourceDetail?
                    .FirstOrDefault(detail => detail.ComplianceState == "compliant");

                // Return the count if found, otherwise return 0
                return complianceDetail?.Count ?? 0;
            }
        }
    }
}