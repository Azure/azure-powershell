function Get-AzLabServicesPlanImage_ListByDisplayName {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IImage])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
        [System.String]
        ${LabPlanName},
   
        [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [System.String]
        ${DisplayName},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    )
    
    process {
        
        $PSBoundParameters.Add('Filter',"Properties/DisplayName eq '$($PSBoundParameters.DisplayName)'")
        $PSBoundParameters.Remove('DisplayName') > $null
        return Az.LabServices\Get-AzLabServicesPlanImage @PSBoundParameters
    }
    
}
    