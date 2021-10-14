function Update-AzLabServicesQuota_Set {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    param(
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [System.String]
        ${LabName},

        [Parameter(Mandatory)]
        [System.TimeSpan]
        ${LabQuota},
    
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    )
    
    process {

        $labQuota = $PSBoundParameters.LabQuota
        $PSBoundParameters.Remove("LabQuota") > $null
        $lab = Az.LabServices\Get-AzLabServices @PSBoundParameters
        # Need all vmprofile information to maintain existing properties.
        $virtualMachineProfile = $lab.VirtualMachineProfile
        $virtualMachineProfile.UsageQuota = $LabQuota

        $PSBoundParameters.Add("VirtualMachineProfile", $virtualMachineProfile)
        $PSBoundParameters.Remove("LabPlanName") > $null

        return Az.LabServices\Update-AzLabServices @PSBoundParameters

    }
    
}
    