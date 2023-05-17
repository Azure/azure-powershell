function IsComputeAzureVM {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [string]$VirtualMachineId
    )

    process {
        $classicCompute = "Microsoft.ClassicCompute".ToLower()
        $vmId = $VirtualMachineId.ToLower()
        return (($vmId -split $classicCompute).Count -le 1)
    }
}

# validate AzureVM enable protection
function Validate-AzureVMEnableProtectionRequest {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [string]$AzureVMName,
        [string]$CloudServiceName,
        [string]$VMResourceGroupName,
        [string]$Policy
    )

    process {
        if([string]::IsNullOrEmpty($AzureVMName)){
            throw "Azure VM name can not be null or empty"
        }

        if([string]::IsNullOrEmpty($CloudServiceName) -and [string]::IsNullOrEmpty($VMResourceGroupName)){
            throw "For Azure VM, both cloud service name and resource group name can not be empty."
        }
    }
}

# IsDiscoveryNeeded
function IsDiscoveryNeeded {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [string]$AzureVMName,
        [string]$VMResourceGroupName,
        [System.Boolean]$IsComputeAzureVM,
        [ref] $ProtectableObjectResource,
        [string]$VaultName,
        [string]$ResourceGroupName,
        [System.String]$DatasourceType,

        [Parameter(Mandatory=$false, HelpMessage='Subscription Id')]
        [System.String]
        ${SubscriptionId}
    )

    process {
        $isDiscoveryNeed = $true
        # $ProtectableObjectResource = $null # TODO: remove
        $vmVersion = ($IsComputeAzureVM) ? "Microsoft.Compute" : "Microsoft.ClassicCompute"
        $virtualMachineId = "/resourceGroups/" + $VMResourceGroupName + "/providers/" + $vmVersion + "/virtualMachines/" + $AzureVMName
        
        Write-Debug "VirtualMachineId: $virtualMachineId"
        
        $filter = Get-BackupManagementTypeFilter -DatasourceType $DatasourceType

        $protectableItemsList = $null
        $null = $PSBoundParameters.Remove('AzureVMName')
        $null = $PSBoundParameters.Remove('VMResourceGroupName')
        $null = $PSBoundParameters.Remove('IsComputeAzureVM')
        $null = $PSBoundParameters.Remove('ProtectableObjectResource')
        $null = $PSBoundParameters.Remove('DatasourceType')
        $PSBoundParameters.Add('Filter', $filter)
        $protectableItemsList = Az.RecoveryServices.Internal\Get-AzRecoveryServicesBackupProtectableItem @PSBoundParameters

        Write-Debug "Count of containers after BackupManagementType and friendlyName filter = $($protectableItemsList.Count)"

        if($protectableItemsList.Count -eq 0){
            Write-Debug "Container is not discovered"
            $isDiscoveryNeed = $true
        }
        else{
            foreach($protectableItem in $protectableItemsList){
                Write-Debug "filtering protectable item $($protectableItem.Property.FriendlyName)"

                $iaaSVMProtectableItem = $protectableItem.Property

                if($iaaSVMProtectableItem -ne $null -and $iaaSVMProtectableItem.FriendlyName -eq $AzureVMName -and $iaaSVMProtectableItem.VirtualMachineId.Contains($virtualMachineId)){
                    $ProtectableObjectResource.Value = $protectableItem
                    $isDiscoveryNeed = $false
                    Write-Debug "protectable item discovery successful"
                    break
                }
            }
        }
        return $isDiscoveryNeed
    }
}

# Get AzureVM protectable object
function Get-AzureVMProtectableObject {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [string]$AzureVMName,
        [string]$VMResourceGroupName,
        [System.Boolean]$IsComputeAzureVM,
        [System.String]$DatasourceType,
        [string]$VaultName,
        [string]$ResourceGroupName,

        [Parameter(Mandatory=$false, HelpMessage='Subscription Id')]
        [System.String]
        ${SubscriptionId}
    )

    process {
        $isDiscoveryNeeded = $false
        $protectableObjectResource = $null

        Write-Debug "Get-AzureVMProtectableObject: checking if discovery needed"
        $PSBoundParameters.Add('ProtectableObjectResource', [ref]$protectableObjectResource)
        $isDiscoveryNeeded = IsDiscoveryNeeded @PSBoundParameters

        if($isDiscoveryNeeded){
            Write-Debug "VM $AzureVMName is not yet discovered. Triggering Discovery."

            Write-Debug "Get-AzureVMProtectableObject: refresh container"
            
            $null = $PSBoundParameters.Remove('AzureVMName')
            $null = $PSBoundParameters.Remove('VMResourceGroupName')
            $null = $PSBoundParameters.Remove('IsComputeAzureVM')
            $null = $PSBoundParameters.Remove('DatasourceType')
            $null = $PSBoundParameters.Remove('ProtectableObjectResource')
            $PSBoundParameters.Add('Filter', $null)
            $refreshContainer = Invoke-AzRecoveryServicesRefreshContainer @PSBoundParameters

            $PSBoundParameters.Add('AzureVMName', $AzureVMName)
            $PSBoundParameters.Add('VMResourceGroupName', $VMResourceGroupName)
            $PSBoundParameters.Add('IsComputeAzureVM', $IsComputeAzureVM)
            $PSBoundParameters.Add('DatasourceType', $DatasourceType)
            $PSBoundParameters.Add('ProtectableObjectResource', [ref]$protectableObjectResource)

            $isDiscoveryNeeded = IsDiscoveryNeeded @PSBoundParameters
            
            if($isDiscoveryNeeded){
                # Container is not discovered. Throw exception
                $vmVersion = ($IsComputeAzureVM) ? "Microsoft.Compute" : "Microsoft.ClassicCompute"
                
                Write-Debug "Failed to discover VM $AzureVMName under $VMResourceGroupName $vmVersion. Please make sure names are correct and VM is not deleted"

                $errormsg = "The specified Azure Virtual Machine Not Found. Possible causes are
                    1. VM does not exist
                    2. The VM name or the Service name needs to be case sensitive
                    3. VM is already Protected with same or other Vault. Please Unprotect VM first and then try to protect it again.

                    Please contact Microsoft for further assistance"

                throw $errormsg
            }
        }

        if($protectableObjectResource -eq $null){
            # Container is not discovered. Throw exception
            $vmVersion = ($IsComputeAzureVM) ? "Microsoft.Compute" : "Microsoft.ClassicCompute"
                
            Write-Debug "Failed to discover VM $AzureVMName under $VMResourceGroupName $vmVersion. Please make sure names are correct and VM is not deleted"

            $errormsg = "The specified Azure Virtual Machine Not Found. Possible causes are
                1. VM does not exist
                2. The VM name or the Service name needs to be case sensitive
                3. VM is already Protected with same or other Vault. Please Unprotect VM first and then try to protect it again.

                Please contact Microsoft for further assistance"

            throw $errormsg
        }
        return $protectableObjectResource
    }
}