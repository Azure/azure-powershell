namespace Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models
{
    public partial class PolicyState
    {
        // adding this so that I can modify the model to include PolicyEvaluationDetails
        
        /// <summary>
        /// Gets the policy evaluation details for the queried resource.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyEvaluationDetails PolicyEvaluationDetails { get => this.PolicyEvaluationDetail; }
    }
}
