function Get-AzLabServicesLab_LabPlan {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.LabPlan]
        ${LabPlan},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [System.String]
        ${Name},
        
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}

    )
    
    process {
        $PSBoundParameters = $LabPlan.BindResourceParameters($PSBoundParameters)
        
        $labPlanId = $LabPlan.Id
        $PSBoundParameters.Remove("LabPlan") > $null
        $PSBoundParameters.Remove("LabPlanName") > $null
        
        if ($PSBoundParameters.ContainsKey('Name')) {            
            # If there is a lab name do a get for the specific lab.
            return Az.LabServices.private\Get-AzLabServicesLab_Get @PSBoundParameters
        } else {
            # Get all labs for the lab plan.
            $PSBoundParameters.Remove("Filter") > $null
            $PSBoundParameters.Remove("ResourceGroupName") > $null
            $PSBoundParameters.Add("Filter","Properties/LabPlanId eq '$labPlanId'")
            return Az.LabServices.private\Get-AzLabServicesLab_List @PSBoundParameters
        }
        
    }
}