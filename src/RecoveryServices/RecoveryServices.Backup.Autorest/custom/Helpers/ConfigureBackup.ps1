
#region begin AzureIaasVM
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
#endregion

#region begin AzureFileShare
    # validate AzureFileShare enable protection
    function Validate-AzureFileShareEnableProtectionRequest {
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

        param(
            [string]$AzureFileShareName,
            [string]$StorageAccountName
        )

        process {
            if([string]::IsNullOrEmpty($AzureFileShareName)){
                throw "Azure file share name can not be null or empty"
            }

            if([string]::IsNullOrEmpty($StorageAccountName)){
                throw "For Azure file share, Storage account name can not be empty"
            }
        }
    }

    # Get AzureFileShare protectable item
    function Get-AzureFileShareProtectableItem {
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

        param(
            [string]$AzureFileShareName,
            [string]$StorageAccountName,
            [string]$VaultName,
            [string]$ResourceGroupName,

            [Parameter(Mandatory=$false, HelpMessage='Subscription Id')]
            [System.String]
            ${SubscriptionId}
        )

        process {
            $null = $PSBoundParameters.Remove("AzureFileShareName")
            $null = $PSBoundParameters.Remove("StorageAccountName")

            $filter = Get-BackupManagementTypeFilter -DatasourceType "AzureFiles"
            $null = $PSBoundParameters.Add("Filter", $filter)

            $protectableItemList = Az.RecoveryServices.Internal\Get-AzRecoveryServicesBackupProtectableItem @PSBoundParameters

            if (protectableItemList.Count == 0)
            {
                Write-Debug "Container is not discovered"
            }

            $protectableObjectResource = $protectableItemList | Where-Object { $_.Property.FriendlyName -eq $AzureFileShareName -and $_.Property.ParentContainerFriendlyName -eq $StorageAccountName }

            return $protectableObjectResource[0]
        }
    }

    # Get AzureFileShare protectable object
    function Get-AzureFileShareProtectableObject {
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

        param(
            [string]$AzureFileShareName,
            [string]$StorageAccountName,
            [string]$VaultName,
            [string]$ResourceGroupName,

            [Parameter(Mandatory=$false, HelpMessage='Subscription Id')]
            [System.String]
            ${SubscriptionId}
        )

        process {
            # get registered storage accounts
            $isRegistered = $false
            $storageContainerName = $null

            $registeredStorageAccount = $null

            #TODO:            
            $filter = Get-BackupManagementTypeFilter -DatasourceType "AzureFiles"
            $null = $PSBoundParameters.Add("Filter", $filter)

            $null = $PSBoundParameters.Remove("AzureFileShareName")
            $null = $PSBoundParameters.Remove("StorageAccountName")

            $registeredStorageAccount = Az.RecoveryServices.Internal\Get-AzRecoveryServicesBackupProtectionContainer @PSBoundParameters | Where-object { ($_.Name -split ";")[-1] -eq $StorageAccountName }

            $null = $PSBoundParameters.Remove("Filter")

            if($registeredStorageAccount -ne $null){
                $isRegistered = $true
                $storageContainerName = "StorageContainer;" + $registeredStorageAccount.Name # TODO: - test if this works
                Write-Debug "Storage account was already registered"
            }
            
            # get unregistered storage account, trigger dicovery if not found
            $isBreak = $false
            $isRefreshed = $false # have we triggered discovery yet

            while((-not $isRegistered) -and (-not $isBreak)){
                $unregisteredStorageAccount = $null

                #TODO:
                $null = $PSBoundParameters.Add("Filter", $filter)
                $null = $PSBoundParameters.Add("FabricName", "Azure")

                $registeredStorageAccount = Az.RecoveryServices.Internal\Get-AzRecoveryServicesProtectableContainer @PSBoundParameters | Where-object { ($_.Name -split ";")[-1] -eq $StorageAccountName }                
                
                $null = $PSBoundParameters.Remove("FabricName")

                # refresh containers as the given storage account is not found
                if($unregisteredStorageAccount -eq $null -and (-not $isRefreshed)){
                    
                    # TODO: refreshContainer
                    Invoke-AzRecoveryServicesRefreshContainer @PSBoundParameters
                }
                else{
                    $isBreak = $true # we explicitly break while loop after second execution
                }

                $null = $PSBoundParameters.Remove("Filter")

                if($unregisteredStorageAccount -ne $null){
                    # unregistered
                    # check for source Id for storageAccountId in ProtectionContainerResource
                    $storageContainerName = $unregisteredStorageAccount.Name # TODO

                    $protectionContainerResource = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ProtectionContainerResource]::new()
                    $protectionContainerResource.Id = $unregisteredStorageAccount.Id
                    $protectionContainerResource.Name = $unregisteredStorageAccount.name

                    $azureStorageContainer = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureStorageContainer]::new()

                    $azureStorageContainer.FriendlyName = $StorageAccountName
                    $azureStorageContainer.BackupManagementType = "AzureStorage" # TODO: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.BackupManagementType.AzureStorage
                    $azureStorageContainer.sourceResourceId = $unregisteredStorageAccount.Property.ContainerId # TODO: check
                    $azureStorageContainer.resourceGroup = $ResourceGroupName
                    
                    $protectionContainerResource.Property = $azureStorageContainer

                    # TODO register container
                    $null = $PSBoundParameters.Add("ContainerName", $unregisteredStorageAccount.name)
                    $null = $PSBoundParameters.Add("Parameter", $protectionContainerResource)

                    Register-Container @PSBoundParameters

                    $null = $PSBoundParameters.Remove("ContainerName")
                    $null = $PSBoundParameters.Remove("Parameter")

                    $isRegistered = $true
                    Write-Debug "Registered a new storage account"
                }
            }

            # get protectable item, trigger inquiry if item not found
            $isInquired = $false
            $isBreak = $false
            $protectableObjectResource = $null            
            
            while(-not $isBreak){
                # TODO:
                $null = $PSBoundParameters.Add("AzureFileShareName", $AzureFileShareName)
                $null = $PSBoundParameters.Add("StorageAccountName", $StorageAccountName)

                $protectableObjectResource = Get-AzureFileShareProtectableItem @PSBoundParameters

                $null = $PSBoundParameters.Remove("AzureFileShareName")
                $null = $PSBoundParameters.Remove("StorageAccountName")

                # inquiry 
                if($protectableObjectResource -eq $null -and (-not $isInquired)){
                    
                    # TODO: TriggerInquiry                    
                    $filter = Get-WorkloadTypeFilter -DatasourceType "AzureFiles"
                    $null = $PSBoundParameters.Add("Filter", $filter)
                    $null = $PSBoundParameters.Add("ContainerName", $storageContainerName)

                    Invoke-AzRecoveryServicesInquireContainer @PSBoundParameters

                    $null = $PSBoundParameters.Remove("Filter")
                    $null = $PSBoundParameters.Remove("ContainerName")

                    $isInquired = $true
                    Write-Debug "Triggered protectable item inquiry"
                }
                else{
                    $isBreak = $true
                }
            }

            if($protectableObjectResource -eq $null){
                # Container is not discovered. Throw exception
                Write-Debug "Failed to discover FileShare {0} under {1}. Please make sure names are correct and FileShare is not deleted"

                Write-Error "File share is not discovered"
            }
        }
    }
#endregion
