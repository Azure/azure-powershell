function Get-AzLabServicesPlanImage_LabPlan {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IImage])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.LabPlan]
        ${LabPlan},
   
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [System.String]
        ${Name},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    )
    
    process {

        $PSBoundParameters = $LabPlan.BindResourceParameters($PSBoundParameters)
        $PSBoundParameters.Remove("LabPlan") > $null

        if ($PSBoundParameters.ContainsKey('Name')) {

            return Az.LabServices.private\Get-AzLabServicesPlanImage_Get @PSBoundParameters
        } else {
            return Az.LabServices.private\Get-AzLabServicesPlanImage_List @PSBoundParameters
        }
    }
    
}
    