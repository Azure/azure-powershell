function Get-AzLabServicesLab_ListByLabName {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab])]
[CmdletBinding(PositionalBinding=$false)]
param(    
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [System.String]
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [SupportsWildcards()]
    [System.String]
    ${WildcardName},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

process {
    $currentLab = $PSBoundParameters.WildcardName
    $PSBoundParameters.Remove('WildcardName') > $null
    
    if ($(& $PSScriptRoot\Utilities\CheckForWildcards.ps1 -ResourceId $currentLab))
    {
        # Powershell Wildcards
        if ($PSBoundParameters.ContainsKey('ResourceGroupName')) {
            return Az.LabServices.private\Get-AzLabServicesLab_List1 @PSBoundParameters |  Where-Object { $_.Name -like $currentLab }
        } else {
            return Az.LabServices.private\Get-AzLabServicesLab_List @PSBoundParameters |  Where-Object { $_.Name -like $currentLab }
        }
    }
    else
    {        
        # Get all labs by name across RGs
        $PSBoundParameters.Add('Filter', "Name eq '$currentLab'")
        if ($PSBoundParameters.ContainsKey('ResourceGroupName')) {
            return Az.LabServices.private\Get-AzLabServicesLab_List1 @PSBoundParameters
        } else {
            return Az.LabServices.private\Get-AzLabServicesLab_List1 @PSBoundParameters
        }
    }
    
}

}
