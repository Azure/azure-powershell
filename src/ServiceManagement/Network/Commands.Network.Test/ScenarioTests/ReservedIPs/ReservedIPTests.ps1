# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

########################################################################### IP Forwarding and VM cmdlets Scenario Tests ###################################################################

<#
.SYNOPSIS
Creates a new Azure reserved IP and deletes it
#>

function Test-AzureReservedIPSimpleOperations
{
    # Setup
    $name = getAssetName
    $label = "New Reserved IP"
    $location = "West US"

    # Test Create Reserved IP
    New-AzureReservedIP -ReservedIPName $name -Label $label -Location $location
    $reservedIP = Get-AzureReservedIP -ReservedIPName $name

    # Assert
    Assert-NotNull($reservedIP)
    Assert-AreEqual $reservedIP.Location $location
    Assert-AreEqual $reservedIP.Label $label

    #Test Remove reserved IP
    $removeReservedIP = Remove-AzureReservedIP -ReservedIPName $name -Force
    Assert-AreEqual $removeReservedIP.OperationStatus "Succeeded"
}

<#
.SYNOPSIS
    Brings up a new Azure VM with a Reserved IP
#>

function Test-CreateVMWithReservedIP
{
    # Virtual Machine cmdlets are now showing a non-terminating error message for ResourceNotFound
    # To continue script, $ErrorActionPreference should be set to 'SilentlyContinue'.
    $ErrorActionPreference='SilentlyContinue';

    # Setup
    $vmname = getAssetName
    $serviceName = getAssetName
    $storageAccountName = getAssetName
    $reservedIPName = getAssetName
    $label = "New Reserved IP"
    $location="West US"
    
    New-AzureReservedIP -ReservedIPName $reservedIPName -Label $label -Location $location
    $subscription = Get-AzureSubscription -Current
    New-AzureStorageAccount -StorageAccountName $storageAccountName -Location $location
    Set-AzureSubscription -SubscriptionId $subscription.SubscriptionId -CurrentStorageAccountName $storageAccountName
    $reservedIP = Get-AzureReservedIP -ReservedIPName $reservedIPName

    $image = get-azurevmimage | Where-Object {$_.OS -eq 'Windows'} | Select-Object -First 1 -ExpandProperty ImageName

    # Assert
    Assert-NotNull($reservedIP)
    Assert-AreEqual $reservedIP.Location $location
    Assert-AreEqual $reservedIP.Label $label
    Assert-False { $reservedIP.InUse }
        
    # Test
    New-AzureVMConfig -ImageName $image -Name $vmname -InstanceSize "Small" |
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Add-AzureProvisioningConfig -Windows -AdminUsername azuretest -Password "Pa@!!w0rd" |
    New-AzureVM -ServiceName $serviceName -Location $location -ReservedIPName $reservedIPName

    $reservedIP = Get-AzureReservedIP -ReservedIPName $reservedIPName
    
    # Assert
    Assert-NotNull($reservedIP)
    Assert-AreEqual $reservedIP.Location $location
    Assert-AreEqual $reservedIP.Label $label
    Assert-True { $reservedIP.InUse }
    Assert-AreEqual $reservedIP.ServiceName $serviceName

    Remove-AzureService -ServiceName $serviceName -Force -DeleteAll
    Remove-AzureReservedIP -ReservedIPName $reservedIPName -Force

    #Start-Sleep -Seconds 120
    Remove-AzureStorageAccount -StorageAccountName $storageAccountName
}

<#
.SYNOPSIS
    Reserve existing deployment IP
#>

function Test-ReserveExistingDeploymentIP
{
    # Virtual Machine cmdlets are now showing a non-terminating error message for ResourceNotFound
    # To continue script, $ErrorActionPreference should be set to 'SilentlyContinue'.
    $ErrorActionPreference='SilentlyContinue';

    # Setup
    $vmname = getAssetName
    $serviceName = getAssetName
    $storageAccountName = getAssetName
    $reservedIPName = getAssetName
    $label = "New Reserved IP"
    $location="West US"
    
    $subscription = Get-AzureSubscription -Current
    New-AzureStorageAccount -StorageAccountName $storageAccountName -Location $location
    Set-AzureSubscription -SubscriptionId $subscription.SubscriptionId -CurrentStorageAccountName $storageAccountName
    $image = get-azurevmimage | Where-Object {$_.OS -eq 'Windows'} | Select-Object -First 1 -ExpandProperty ImageName

    # Test
    New-AzureVMConfig -ImageName $image -Name $vmname -InstanceSize "Small" |
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Add-AzureProvisioningConfig -Windows -AdminUsername azuretest -Password "Pa@!!w0rd" |
    New-AzureVM -ServiceName $serviceName -Location $location 
    New-AzureReservedIP -ReservedIPName $reservedIPName -ServiceName $serviceName -Location $location -Label $label
    $reservedIP = Get-AzureReservedIP -ReservedIPName $reservedIPName

    # Assert
    Assert-NotNull($reservedIP)
    Assert-AreEqual $reservedIP.Location $location
    Assert-AreEqual $reservedIP.Label $label
    Assert-True { $reservedIP.InUse }
    Assert-AreEqual $reservedIP.ServiceName $serviceName

    Remove-AzureService -ServiceName $serviceName -Force -DeleteAll
    Remove-AzureReservedIP -ReservedIPName $reservedIPName -Force

    #Start-Sleep -Seconds 120
    Remove-AzureStorageAccount -StorageAccountName $storageAccountName
}

<#
.SYNOPSIS
    Create a VM and associate a reserved IP with it
#>
function Test-SetAzureReservedIPAssociationSingleVip
{
    # Virtual Machine cmdlets are now showing a non-terminating error message for ResourceNotFound
    # To continue script, $ErrorActionPreference should be set to 'SilentlyContinue'.
    $ErrorActionPreference='SilentlyContinue';

    # Setup
    $vmname = getAssetName
    $serviceName = getAssetName
    $storageAccountName = getAssetName
    $reservedIPName = getAssetName
    $label = "New Reserved IP"
    $location="West US"
    
    New-AzureReservedIP -ReservedIPName $reservedIPName -Label $label -Location $location
    $subscription = Get-AzureSubscription -Current
    New-AzureStorageAccount -StorageAccountName $storageAccountName -Location $location
    Set-AzureSubscription -SubscriptionId $subscription.SubscriptionId -CurrentStorageAccountName $storageAccountName
    $reservedIP = Get-AzureReservedIP -ReservedIPName $reservedIPName

    $image = get-azurevmimage | Where-Object {$_.OS -eq 'Windows'} | Select-Object -First 1 -ExpandProperty ImageName

    # Assert
    Assert-NotNull($reservedIP)
    Assert-AreEqual $reservedIP.Location $location
    Assert-AreEqual $reservedIP.Label $label
    Assert-False { $reservedIP.InUse }
        
    # Test
    New-AzureVMConfig -ImageName $image -Name $vmname -InstanceSize "Small" |
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Add-AzureProvisioningConfig -Windows -AdminUsername azuretest -Password "Pa@!!w0rd" |
    New-AzureVM -ServiceName $serviceName -Location $location 

    Set-AzureReservedIPAssociation -ReservedIPName $reservedIPName -ServiceName $serviceName

    $reservedIP = Get-AzureReservedIP -ReservedIPName $reservedIPName
    
    # Assert
    Assert-NotNull($reservedIP)
    Assert-AreEqual $reservedIP.Location $location
    Assert-AreEqual $reservedIP.Label $label
    Assert-True { $reservedIP.InUse }
    Assert-AreEqual $reservedIP.ServiceName $serviceName

    Remove-AzureService -ServiceName $serviceName -Force -DeleteAll
    Remove-AzureReservedIP -ReservedIPName $reservedIPName -Force

    #Start-Sleep -Seconds 120
    Remove-AzureStorageAccount -StorageAccountName $storageAccountName
}

<#
.SYNOPSIS
    Create a VM with reserved IP and disassociate the reserved IP
#>

function Test-RemoveAzureReservedIPAssociationSingleVip
{
    # Virtual Machine cmdlets are now showing a non-terminating error message for ResourceNotFound
    # To continue script, $ErrorActionPreference should be set to 'SilentlyContinue'.
    $ErrorActionPreference='SilentlyContinue';

    # Setup
    $vmname = getAssetName
    $serviceName = getAssetName
    $storageAccountName = getAssetName
    $reservedIPName = getAssetName
    $label = "New Reserved IP"
    $location="West US"
    
    New-AzureReservedIP -ReservedIPName $reservedIPName -Label $label -Location $location
    $subscription = Get-AzureSubscription -Current
    New-AzureStorageAccount -StorageAccountName $storageAccountName -Location $location
    Set-AzureSubscription -SubscriptionId $subscription.SubscriptionId -CurrentStorageAccountName $storageAccountName
    $reservedIP = Get-AzureReservedIP -ReservedIPName $reservedIPName

    $image = get-azurevmimage | Where-Object {$_.OS -eq 'Windows'} | Select-Object -First 1 -ExpandProperty ImageName

    # Assert
    Assert-NotNull($reservedIP)
    Assert-AreEqual $reservedIP.Location $location
    Assert-AreEqual $reservedIP.Label $label
    Assert-False { $reservedIP.InUse }
        
    # Test
    New-AzureVMConfig -ImageName $image -Name $vmname -InstanceSize "Small" |
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Add-AzureProvisioningConfig -Windows -AdminUsername azuretest -Password "Pa@!!w0rd" |
    New-AzureVM -ServiceName $serviceName -Location $location -ReservedIPName $reservedIPName

    $reservedIP = Get-AzureReservedIP -ReservedIPName $reservedIPName
    
    # Assert
    Assert-NotNull($reservedIP)
    Assert-AreEqual $reservedIP.Location $location
    Assert-AreEqual $reservedIP.Label $label
    Assert-True { $reservedIP.InUse }
    Assert-AreEqual $reservedIP.ServiceName $serviceName

    Remove-AzureReservedIPAssociation -ReservedIPName $reservedIPName -ServiceName $serviceName -Force

    $reservedIP = Get-AzureReservedIP -ReservedIPName $reservedIPName
    # Assert
    Assert-NotNull($reservedIP)
    Assert-AreEqual $reservedIP.Location $location
    Assert-AreEqual $reservedIP.Label $label
    Assert-False { $reservedIP.InUse }

    Remove-AzureService -ServiceName $serviceName -Force -DeleteAll
    Remove-AzureReservedIP -ReservedIPName $reservedIPName -Force
    
    #sleep to ensure deployments are cleaned
    #Start-Sleep -Seconds 120
    Remove-AzureStorageAccount -StorageAccountName $storageAccountName
}