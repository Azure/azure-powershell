function Add-AzAzureStackHciVirtualMachineDataDisk {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Models.Api20221215Preview.IVirtualMachines])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Alias('VirtualMachineName')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # Name of the virtual machine
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${ResourceId},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String[]]
    # Data Disks - list of data disks to be attached to the virtual machine
    ${DataDiskIds}
)

  
  if ($PSCmdlet.Parameter -eq "ByResourceId"){
    if ($ResourceId -match $vmRegex){
        
        $subscriptionId = $($Matches['subscriptionId'])
        $resourceGroupName = $($Matches['resourceGroupName'])
        $resourceName = $($Matches['vmName'])
        $null = $PSBoundParameters.Remove("ResourceId")
        $PSBoundParameters.Add("Name", $resourceName)
        $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
        $null = $PSBoundParameters.Remove("SubscriptionId")
        $PSBoundParameters.Add("SubscriptionId", $subscriptionId)

    } else {             
        Write-Error "Virtual Machine Resource ID is invalid: $ResourceId"
    }
  }

    $StorageProfileDataDisk =  [System.Collections.ArrayList]::new()
    foreach ($DataDiskId in $DataDiskIds){
        if ($DataDiskId -notmatch $vhdRegex){
            Write-Error "Invalid Data Disk Id provided: $DataDiskId." -ErrorAction Stop
        }
        $DataDisk = @{Id = $DataDiskId}
        [void]$StorageProfileDataDisk.Add($DataDisk)
    }

    $null = $PSBoundParameters.Remove("DataDiskIds")
    $PSBoundParameters.Add('StorageProfileDataDisk',  $StorageProfileDataDisk)

    return Az.AzureStackHCI\Update-AzAzureStackHciVirtualMachine @PSBoundParameters
}