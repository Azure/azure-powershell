namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20180201
{
    public partial class Site :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20180201.ISite,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20180201.ISiteInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        	    
        // Function app settings. These gets set via PowerShell. For more info, please see custom/HelperScripts/HelperFunctions.ps1        

        public System.Collections.Hashtable ApplicationSettings { get; set; }
        
        public string RuntimeName { get; set; }
        
        public string HostVersion { get; set; }

        public string OSType { get; set; }

        public string AppServicePlan { get; set; }        
        
    }
}
