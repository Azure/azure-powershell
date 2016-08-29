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
    Adds a new Vip, adds endpoint, removes endpoint and removes vip
#>

function Test-AdditionalVipLifecycle
{
    # Virtual Machine cmdlets are now showing a non-terminating error message for ResourceNotFound
    # To continue script, $ErrorActionPreference should be set to 'SilentlyContinue'.
    $ErrorActionPreference='SilentlyContinue';

    # Setup
    $vmname = getAssetName
    $vipName = getAssetName
    $serviceName = getAssetName
    $storageAccountName = getAssetName
    $location="West US"
    $endpoint = getAssetName

    $subscription = Get-AzureSubscription -Current
    New-AzureStorageAccount -StorageAccountName $storageAccountName -Location $location
    Set-AzureSubscription -SubscriptionId $subscription.SubscriptionId -CurrentStorageAccountName $storageAccountName

    $image = get-azurevmimage | Where-Object {$_.OS -eq 'Windows'} | Select-Object -First 1 -ExpandProperty ImageName
        
    New-AzureVMConfig -ImageName $image -Name $vmname -InstanceSize "Small" |
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Add-AzureProvisioningConfig -Windows -AdminUsername azuretest -Password "Pa@!!w0rd" |
    New-AzureVM -ServiceName $serviceName -Location $location 

    #Test

    $deployment = Get-AzureDeployment -ServiceName $serviceName
    Assert-AreEqual $deployment.VirtualIPs.Count "1"

    #add vip

    Add-AzureVirtualIP -ServiceName $serviceName -VirtualIPName $vipName
    $deployment = Get-AzureDeployment -ServiceName $serviceName
    Assert-AreEqual $deployment.VirtualIPs.Count "2"

    Assert-True { [string]::IsNullOrWhiteSpace($deployment.VirtualIPs[1].Address) }

    # add endpoint

    Get-AzureVM -ServiceName $serviceName| Add-AzureEndpoint -Name $endpoint -Protocol tcp -LocalPort 1001 -PublicPort 444 -VirtualIPName $vipName | Update-AzureVM
    $deployment = Get-AzureDeployment -ServiceName $serviceName
    Assert-AreEqual $deployment.VirtualIPs.Count "2"

    Assert-False { [string]::IsNullOrWhiteSpace($deployment.VirtualIPs[1].Address) }

    #remove Endpoint

    Get-AzureVM -ServiceName $serviceName| Remove-AzureEndpoint -Name $endpoint | Update-AzureVM
    $deployment = Get-AzureDeployment -ServiceName $serviceName
    Assert-AreEqual $deployment.VirtualIPs.Count "2"

    Assert-True { [string]::IsNullOrWhiteSpace($deployment.VirtualIPs[1].Address) }

    #remove Vip

    Remove-AzureVirtualIP -ServiceName $serviceName -VirtualIPName $vipName -Force
    $deployment = Get-AzureDeployment -ServiceName $serviceName
    Assert-AreEqual $deployment.VirtualIPs.Count "1"

    #cleanup

    Remove-AzureService -ServiceName $serviceName -Force -DeleteAll
    #sleep so that the service & deployments are removed
    #Start-Sleep -Seconds 120
    Remove-AzureStorageAccount -StorageAccountName $storageAccountName
}

function CreateMultivipDeployment($vmname, $vipName, $serviceName, $storageAccountName, $location, $endpoint)
{
    $subscription = Get-AzureSubscription -Current
    New-AzureStorageAccount -StorageAccountName $storageAccountName -Location $location
    Set-AzureSubscription -SubscriptionId $subscription.SubscriptionId -CurrentStorageAccountName $storageAccountName

    $image = get-azurevmimage | Where-Object {$_.OS -eq 'Windows'} | Select-Object -First 1 -ExpandProperty ImageName
        
    New-AzureVMConfig -ImageName $image -Name $vmname -InstanceSize "Small" |
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Add-AzureProvisioningConfig -Windows -AdminUsername azuretest -Password "Pa@!!w0rd" |
    New-AzureVM -ServiceName $serviceName -Location $location 

    #add vip

    Add-AzureVirtualIP -ServiceName $serviceName -VirtualIPName $vipName
    $deployment = Get-AzureDeployment -ServiceName $serviceName
    Assert-AreEqual $deployment.VirtualIPs.Count "2"

    Assert-True { [string]::IsNullOrWhiteSpace($deployment.VirtualIPs[1].Address) }

    # add endpoint

    Get-AzureVM -ServiceName $serviceName| Add-AzureEndpoint -Name $endpoint -Protocol tcp -LocalPort 1001 -PublicPort 444 -VirtualIPName $vipName | Update-AzureVM
    $deployment = Get-AzureDeployment -ServiceName $serviceName
    Assert-AreEqual $deployment.VirtualIPs.Count "2"

    Assert-False { [string]::IsNullOrWhiteSpace($deployment.VirtualIPs[1].Address) }
}

<#
.SYNOPSIS
    Test Multivip VipMobility
#>
function Test-AdditionalVipMobility
{
    # Virtual Machine cmdlets are now showing a non-terminating error message for ResourceNotFound
    # To continue script, $ErrorActionPreference should be set to 'SilentlyContinue'.
    $ErrorActionPreference='SilentlyContinue';

    # Setup
    $vmname = getAssetName
    $vipName = getAssetName
    $serviceName = getAssetName
    $storageAccountName = getAssetName
    $location="West US"
    $endpoint = getAssetName
    $reservedIPName = getAssetName
    $label = "New Reserved IP"

    New-AzureReservedIP -ReservedIPName $reservedIPName -Label $label -Location $location
    
    CreateMultivipDeployment $vmname $vipName $serviceName $storageAccountName $location $endpoint

    #Test

    Set-AzureReservedIPAssociation -ReservedIPName $reservedIPName -ServiceName $serviceName -VirtualIPName $vipName

    $reservedIP = Get-AzureReservedIP -ReservedIPName $reservedIPName
    $deployment = Get-AzureDeployment -ServiceName $serviceName

    # Assert
    Assert-NotNull($reservedIP)
    Assert-AreEqual $reservedIP.Location $location
    Assert-AreEqual $reservedIP.Label $label
    Assert-AreEqual $reservedIP.VirtualIPName $vipName
    Assert-True { $reservedIP.InUse }
    Assert-AreEqual $reservedIP.ServiceName $serviceName
    Assert-AreEqual $deployment.VirtualIPs[1].Address $reservedIP.Address
    Assert-AreEqual $deployment.VirtualIPs[1].ReservedIPName $reservedIPName

    Remove-AzureReservedIPAssociation -ReservedIPName $reservedIPName -ServiceName $serviceName -VirtualIPName $vipName -Force
    $reservedIP = Get-AzureReservedIP -ReservedIPName $reservedIPName
    $deployment = Get-AzureDeployment -ServiceName $serviceName
    Assert-False { $reservedIP.InUse }
    Assert-True { [string]::IsNullOrWhiteSpace($deployment.VirtualIPs[1].ReservedIPName) }
    Assert-True { [string]::IsNullOrWhiteSpace($reservedIP.VirtualIPName) }
    Assert-True { [string]::IsNullOrWhiteSpace($reservedIP.ServiceName) }
    Assert-True { [string]::IsNullOrWhiteSpace($reservedIP.DeploymentName) }

    #cleanup

    Remove-AzureService -ServiceName $serviceName -Force -DeleteAll
    Remove-AzureReservedIP -ReservedIPName $reservedIPName -Force
    
    #sleep so that the service & deployments are removed
    #Start-Sleep -Seconds 120

    Remove-AzureStorageAccount -StorageAccountName $storageAccountName
}

<#
.SYNOPSIS
    Reserve Existing deployment IP in Multivip deployment
#>
function Test-ReserveExistingDeploymentIPMultivip
{
    # Virtual Machine cmdlets are now showing a non-terminating error message for ResourceNotFound
    # To continue script, $ErrorActionPreference should be set to 'SilentlyContinue'.
    $ErrorActionPreference='SilentlyContinue';

    # Setup
    $vmname = getAssetName
    $vipName = getAssetName
    $serviceName = getAssetName
    $storageAccountName = getAssetName
    $location="West US"
    $endpoint = getAssetName
    $reservedIPName = getAssetName
    $label = "New Reserved IP"

    CreateMultivipDeployment $vmname $vipName $serviceName $storageAccountName $location $endpoint

    #test
    New-AzureReservedIP -ReservedIPName $reservedIPName -Label $label -Location $location -ServiceName $serviceName -VirtualIPName $vipName
    
    $reservedIP = Get-AzureReservedIP -ReservedIPName $reservedIPName
    $deployment = Get-AzureDeployment -ServiceName $serviceName

    # Assert
    Assert-NotNull($reservedIP)
    Assert-AreEqual $reservedIP.Location $location
    Assert-AreEqual $reservedIP.Label $label
    Assert-AreEqual $reservedIP.VirtualIPName $vipName
    Assert-True { $reservedIP.InUse }
    Assert-AreEqual $reservedIP.ServiceName $serviceName
    Assert-AreEqual $deployment.VirtualIPs[1].Address $reservedIP.Address
    Assert-AreEqual $deployment.VirtualIPs[1].ReservedIPName $reservedIPName

    #cleanup

    Remove-AzureService -ServiceName $serviceName -Force -DeleteAll
    Remove-AzureReservedIP -ReservedIPName $reservedIPName -Force
    
    #sleep to ensure deployments are cleaned
    #Start-Sleep -Seconds 120
    Remove-AzureStorageAccount -StorageAccountName $storageAccountName
}

function Test-SetLBEndpoint
{
    # Virtual Machine cmdlets are now showing a non-terminating error message for ResourceNotFound
    # To continue script, $ErrorActionPreference should be set to 'SilentlyContinue'.
    $ErrorActionPreference='SilentlyContinue';

    # Setup
    $vmname = getAssetName
    $vipName = getAssetName
    $serviceName = getAssetName
    $storageAccountName = getAssetName
    $location="West US"
    $endpoint = getAssetName
    $lbendpoint1 = getAssetName
    $lbendpoint2 = getAssetName
    $secondvmname = getAssetName
    $lbsetName = getAssetName
    
    CreateMultivipDeployment $vmname $vipName $serviceName $storageAccountName $location $endpoint

    #add the second VM

    $image = get-azurevmimage | Where-Object {$_.OS -eq 'Windows'} | Select-Object -First 1 -ExpandProperty ImageName
        
    New-AzureVMConfig -ImageName $image -Name $secondvmname -InstanceSize "Small" |
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Add-AzureProvisioningConfig -Windows -AdminUsername azuretest -Password "Pa@!!w0rd" |
    New-AzureVM -ServiceName $serviceName -Location $location 

    Get-AzureVM -ServiceName $serviceName -Name $vmname | Add-AzureEndpoint -Name $lbendpoint1 -Protocol tcp -LocalPort 1100 -PublicPort 448 -VirtualIPName $vipName  -LBSetName $lbsetName -ProbePort 1000 -ProbeProtocol tcp| Update-AzureVM
    Get-AzureVM -ServiceName $serviceName -Name $secondvmname | Add-AzureEndpoint -Name $lbendpoint2 -Protocol tcp -LocalPort 1100 -PublicPort 448 -VirtualIPName $vipName  -LBSetName $lbsetName -ProbePort 1000 -ProbeProtocol tcp| Update-AzureVM
    $deployment = Get-AzureDeployment -ServiceName $serviceName
    $updatedVip = $deployment.VirtualIPs[0].Name

    #set LB endpoint
    Set-AzureLoadBalancedEndpoint  -LBSetName $lbSetName -VirtualIPName $updatedVip -ServiceName $serviceName

    #get endpoint
    $updatedEP1 = Get-AzureVM -ServiceName $serviceName -Name $vmname | Get-AzureEndpoint -Name $lbendpoint1
    Assert-AreEqual $updatedEP1.VirtualIPName $updatedVip

    $updatedEP2 = Get-AzureVM -ServiceName $serviceName -Name $secondvmname | Get-AzureEndpoint -Name $lbendpoint2
    Assert-AreEqual $updatedEP1.VirtualIPName $updatedVip

    #cleanup
    Remove-AzureService -ServiceName $serviceName -Force -DeleteAll
    
    #Start-Sleep -Seconds 120
    Remove-AzureStorageAccount -StorageAccountName $storageAccountName
}