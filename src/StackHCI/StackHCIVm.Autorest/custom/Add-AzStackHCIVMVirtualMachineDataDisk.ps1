function Add-AzStackHciVMVirtualMachineDataDisk {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20221215Preview.IVirtualMachines])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Alias('VirtualMachineName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # Name of the virtual machine
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The ARM Resource ID of the VM
    ${ResourceId},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String[]]
    # List of data disks to be attached to the virtual machine passed in Id format
    ${DataDiskIds},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String[]]
    # List of data disks to be attached to the virtual machine passed by Name 
    ${DataDiskNames},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # Resource Group of the Data Disks
    ${DataDiskResourceGroup}
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

    if($DataDiskIds){
        foreach ($DataDiskId in $DataDiskIds){
            if ($DataDiskId -notmatch $vhdRegex){
                Write-Error "Invalid Data Disk Id provided: $DataDiskId." -ErrorAction Stop
            }
            $DataDisk = @{Id = $DataDiskId}
            [void]$StorageProfileDataDisk.Add($DataDisk)
        }

        $null = $PSBoundParameters.Remove("DataDiskIds")
      
    } elseif ($DataDiskNames){
        $rg = $ResourceGroupName
        if($DataDiskResourceGroup){
          $rg = $DataDiskResourceGroup
        }

        foreach ($DataDiskName in $DataDiskNames){
            $DataDiskId = "/subscriptions/$SubscriptionId/resourceGroups/$rg/providers/Microsoft.AzureStackHCI/virtualharddisks/$DataDiskName"
            $DataDisk = @{Id = $DataDiskId}
            [void]$StorageProfileDataDisk.Add($DataDisk)
        }

        $null = $PSBoundParameters.Remove("DataDiskNames")
        $null = $PSBoundParameters.Remove("DataDiskResourceGroup")
    }

    $vm = Az.StackHciVM\Get-AzStackHciVMVirtualMachine @PSBoundParameters
    $disks = $vm.StorageProfileDataDisk

    foreach ($disk in $disks){
        $DataDisk = @{Id = $disk.Id}
        [void]$StorageProfileDataDisk.Add($DataDisk)
    }


    $PSBoundParameters.Add('StorageProfileDataDisk',  $StorageProfileDataDisk)


    return Az.StackHciVM\Update-AzStackHciVMVirtualMachine @PSBoundParameters
}