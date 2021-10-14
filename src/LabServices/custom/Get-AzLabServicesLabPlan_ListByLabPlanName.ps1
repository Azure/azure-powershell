function Get-AzLabServicesLabPlan_ListByLabPlanName {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILabPlan])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [SupportsWildcards()]
    [System.String]
    ${PlanName},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

process {

    $currentLabPlan = $PSBoundParameters.PlanName
    $PSBoundParameters.Remove('PlanName') > $null
    if ($(& $PSScriptRoot\Utilities\CheckForWildcards.ps1 -ResourceId $currentLabPlan))
    {
        # Uses Powershell wildcards
        return Az.LabServices.private\Get-AzLabServicesLabPlan_List @PSBoundParameters |  Where-Object { $_.Name -like $currentLabPlan }
    }
    else
    {
        # Get all labPlans by name across RGs
        $PSBoundParameters.Add('Filter', "Name eq '$currentLabPlan'")
        return Az.LabServices.private\Get-AzLabServicesLabPlan_List @PSBoundParameters
    }
}

}
