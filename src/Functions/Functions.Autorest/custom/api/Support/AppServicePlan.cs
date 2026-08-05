namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models
{
    public partial class AppServicePlan :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IAppServicePlan,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IAppServicePlanInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        // This gets set via PowerShell. For more info, please see custom/HelperScripts/HelperFunctions.ps1 
        /// <summary>The Service plan worker type.</summary>       
        public string WorkerType { get; set; }
    }
}
