function Add-AzStackHciVMVirtualMachineDataDisk {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20230901Preview.IVirtualMachineInstance])]
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
    
    if (($ResourceId -match $vmRegex) -or ($Name -and $ResourceGroupName -and $SubscriptionId)){
        if ($ResourceId -match $vmRegex){
            $SubscriptionId = $($Matches['subscriptionId'])
            $ResourceGroupName = $($Matches['resourceGroupName'])
            $Name = $($Matches['machineName'])
        }
        $null = $PSBoundParameters.Remove("Name")
        $null = $PSBoundParameters.Remove("ResourceGroupName")
        $null = $PSBoundParameters.Remove("SubscriptionId")
        $null = $PSBoundParameters.Remove("ResourceId")
        $resourceUri = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.HybridCompute/machines/" + $Name
        $PSBoundParameters.Add("ResourceUri", $resourceUri)
        } else {
            Write-Error "One or more input parameters are invalid. Resource ID is: $ResourceId, name is $name, resource group name is $resourcegroupname, subscription id is $subscriptionid" 
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
    
        $vm = Az.StackHciVM.internal\Get-AzStackHciVMVirtualMachine @PSBoundParameters
        $disks = $vm.StorageProfileDataDisk
    
        foreach ($disk in $disks){
            $DataDisk = @{Id = $disk.Id}
            [void]$StorageProfileDataDisk.Add($DataDisk)
        }
    
        $PSBoundParameters.Add('StorageProfileDataDisk',  $StorageProfileDataDisk)
        return Az.StackHciVM.internal\Update-AzStackHciVMVirtualMachine @PSBoundParameters
    }