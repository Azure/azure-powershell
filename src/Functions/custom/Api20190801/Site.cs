namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models
{
    public partial class Site :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.ISite,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.ISiteInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        	    
        // Function app settings. These gets set via PowerShell. For more info, please see custom/HelperScripts/HelperFunctions.ps1        

        public System.Collections.Hashtable ApplicationSettings { get; set; }

        public System.Collections.Hashtable SiteConfig { get; set; }
        
        public string Runtime { get; set; }

        public string OSType { get; set; }

        public string AppServicePlan { get; set; }        
        
    }
}
