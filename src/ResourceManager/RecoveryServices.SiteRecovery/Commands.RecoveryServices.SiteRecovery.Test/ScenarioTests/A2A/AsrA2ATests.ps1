# encoding: utf-8
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

########################## Site Recovery Tests #############################

##Default Value ##

<#
.SYNOPSIS
    NewA2ADiskReplicationConfiguration creation test.
#>
function Test-NewA2ADiskReplicationConfiguration
{
    $recoveryStorageAccountId ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2a-rg/providers/Microsoft.Storage/storageAccounts/a2argdisks412"
    $logStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ltrgp1705152333/providers/Microsoft.Storage/storageAccounts/stagingsa2name1705152333"
    $vhdUri = "https://powershelltestdiag414.blob.core.windows.net/vhds/pslinV2-520180112143232.vhd"

    $v = New-AzureRmRecoveryServicesAsrAzureToAzureDiskReplicationConfig -VhdUri  $vhdUri `
        -RecoveryAzureStorageAccountId $recoveryStorageAccountId `
        -LogStorageAccountId   $logStorageAccountId

     Assert-True { $v.vhdUri -eq $vhdUri }
     Assert-True { $v.recoveryAzureStorageAccountId -eq $recoveryStorageAccountId  }
     Assert-True { $v.logStorageAccountId -eq $logStorageAccountId }
}


<#
.SYNOPSIS
    NewA2ADiskReplicationConfiguration creation test.
#>
function Test-NewA2AManagedDiskReplicationConfiguration
{
    $logStorageAccountId = "fdd"
    $DiskId = "diskId"
    $RecoveryResourceGroupId = "3"
    $RecoveryReplicaDiskAccountType = "Premium_LRS"
    $RecoveryTargetDiskAccountType = "Premium_LRS"

    $v = New-AzureRmRecoveryServicesAsrAzureToAzureDiskReplicationConfig -managed -LogStorageAccountId $logStorageAccountId `
         -DiskId "diskId" -RecoveryResourceGroupId  $RecoveryResourceGroupId -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
         -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType

     Assert-True { $v.LogStorageAccountId -eq $LogStorageAccountId }
     Assert-True { $v.DiskId -eq $DiskId  }
     Assert-True { $v.RecoveryResourceGroupId -eq $RecoveryResourceGroupId }
}

<#
.SYNOPSIS 
    Test GetAsrFabric new parametersets
#>
function Test-NewAsrFabric {

        
}


function Test-NewContainer{

        

}

function Test-NewPolicy{

        
}

function Test-ContainerMapping{
        $primaryPolicyName = getPrimaryPolicy
        $recoveryPolicyName = getRecoveryPolicy
        
        $primaryContainerMappingName = getPrimaryContainerMapping
        $recoveryContainerMappingName = getRecoveryContainerMapping
        
        $primaryContainerName = getPrimaryContainer
        $recoveryContainerName = getRecoveryContainer
        $vaultRgLocation = getVaultRgLocation
        $vaultName = getVaultName
        $vaultLocation = getVaultLocation
        $vaultRg = getVaultRg
        $primaryLocation = getPrimaryLocation
        $recoveryLocation = getRecoveryLocation
        $primaryFabricName = getPrimaryFabric
        $recoveryFabricName = getRecoveryFabric
        $RecoveryReplicaDiskAccountType = "Premium_LRS"
        $RecoveryTargetDiskAccountType = "Premium_LRS"

        New-AzureRmResourceGroup -name $vaultRg -location $vaultRgLocation --force
        [Microsoft.Azure.Test.TestUtilities]::Wait(20 * 1000)
    # vault Creation
        New-azureRmRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
        [Microsoft.Azure.Test.TestUtilities]::Wait(20 * 1000)
        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault
    # fabric Creation    
        ### AzureToAzure New paramset 
        $fabJob=  New-AzureRmRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzureRmRecoveryServicesAsrFabric -Name $primaryFabricName
        Assert-true { $fab.name -eq $primaryFabricName }
        Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

        $fabJob=  New-AzureRmRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzureRmRecoveryServicesAsrFabric -Name $recoveryFabricName
        Assert-true { $fab.name -eq $recoveryFabricName }
        Assert-AreEqual $fab.FabricSpecificDetails.Location $recoveryLocation
        $pf = get-asrFabric -Name $primaryFabricName
        $rf = get-asrFabric -Name $recoveryFabricName
        
        ### AzureToAzure (Default)
        $job = New-AzureRmRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $pf
        WaitForJobCompletion -JobId $Job.Name
        $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
        Assert-NotNull($pc)
        Assert-AreEqual $pc.Name $primaryContainerName

        $job = New-AzureRmRecoveryServicesAsrProtectionContainer -Name $recoveryContainerName -Fabric $rf
        WaitForJobCompletion -JobId $Job.Name
        $rc = Get-asrProtectionContainer -name $recoveryContainerName -Fabric $rf
    # policy creation 
        $Job1 = New-AzureRmRecoveryServicesAsrPolicy -Name $primaryPolicyName -AzureToAzure -RecoveryPointRetentionInHours 10  -ApplicationConsistentSnapshotFrequencyInHours 5
        $Job2 = New-AzureRmRecoveryServicesAsrPolicy -Name $recoveryPolicyName -AzureToAzure -RecoveryPointRetentionInHours 10  -ApplicationConsistentSnapshotFrequencyInHours 5
        waitForJobCompletion -JobId $job1.name
        waitForJobCompletion -JobId $job2.name

        $pp = Get-AzureRmRecoveryServicesAsrPolicy -Name $primaryPolicyName
        $rp = Get-AzureRmRecoveryServicesAsrPolicy -Name $recoveryPolicyName

        # Container Mapping
    
        # Create Mapping
        $pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $primaryContainerMappingName -policy $pp -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
        WaitForJobCompletion -JobId $pcmjob.Name 

        $pcm = Get-ASRProtectionContainerMapping -Name $primaryContainerMappingName -ProtectionContainer $pc
        Assert-NotNull($pcm)
        $rcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $recoveryContainerMappingName -policy $rp -PrimaryProtectionContainer $rc -RecoveryProtectionContainer $pc
        WaitForJobCompletion -JobId $rcmjob.Name 

        $rcm = Get-ASRProtectionContainerMapping -Name $recoveryContainerMappingName -ProtectionContainer $rc
        Assert-NotNull($rcm)
}

function Test-NetworkMapping{

        $primaryResourceRGName ="primaryRG"+$seed
        $primaryLocation = getPrimaryLocation
        $skuName = "Standard_LRS"

        $cacheAccountName = "caestea1ccgq" + $seed
        $primaryresourceGroup = New-AzureRmResourceGroup -name $primaryResourceRGName -location $primaryLocation -force
        
        $storageAccount = New-AzureRmStorageAccount -ResourceGroupName $primaryResourceRGName `
                          -Name $cacheAccountName `
                          -Location $primaryLocation `
                          -SkuName $skuName

        $primaryPolicyName = getPrimaryPolicy
        $recoveryPolicyName = getRecoveryPolicy
        
        $primaryContainerMappingName = getPrimaryContainerMapping
        $recoveryContainerMappingName = getRecoveryContainerMapping
        
        $primaryContainerName = getPrimaryContainer
        $recoveryContainerName = getRecoveryContainer
        $vaultRgLocation = getVaultRgLocation
        $vaultName = getVaultName
        $vaultLocation = getVaultLocation
        $vaultRg = getVaultRg
        
        $recoveryLocation = getRecoveryLocation
        $primaryFabricName = getPrimaryFabric
        $recoveryFabricName = getRecoveryFabric
        
        
        $primaryNetworkName = "primaryNetwork"+ $primaryLocation + $seed;
        $recoveryNetworkName = "recoveryNetwork"+ $primaryLocation + $seed;
        
        
        $recoveryResourceRGName = "recoveryRG"+$seed
        $vmName = "psTestswag"+$seed
        
        $primaryresourceGroup = New-AzureRmResourceGroup -name $primaryResourceRGName -location $primaryLocation -force
        $recoveryResourceGroup = New-AzureRmResourceGroup -name $recoveryResourceRGName -location $recoveryLocation -force
        

    $virtualNetwork = New-AzureRmVirtualNetwork `
          -ResourceGroupName $primaryresourceGroup.ResourceGroupName `
          -Location $primaryLocation `
          -Name $primaryNetworkName `
          -AddressPrefix 10.0.0.0/16 -Force
         $primaryNetworkId = $virtualNetwork.id

        
        $virtualNetwork = New-AzureRmVirtualNetwork `
          -ResourceGroupName $recoveryResourceGroup.ResourceGroupName `
          -Location $recoveryLocation `
          -Name $recoveryNetworkName `
          -AddressPrefix 10.0.0.0/16  -Force
         $recoveryNetworkId = $virtualNetwork.id


            $subnetName = "default"+$seed
            $addressPrefix = "192.168.1.0/24"
            $vnetName = "vnet"+$seed
            $vnetAddress = "192.168.0.0/16"
            $nicName = "myNic"+$seed
            $secureString ='Microsfot@123'

            $subnetConfig = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix $addressPrefix
            $vnet = New-AzureRmVirtualNetwork -ResourceGroupName $primaryResourceRGName -Location $primaryLocation -Name $vnetName -AddressPrefix $vnetAddress -Subnet $subnetConfig
  
            $nic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $primaryResourceRGName -Location $primaryLocation -SubnetId $vnet.Subnets[0].Id
  
            $securePassword = ConvertTo-SecureString $secureString -AsPlainText -Force

            $cred = New-Object System.Management.Automation.PSCredential ("azureuser", $securePassword)
    
            $nic = New-AzureRmNetworkInterface -Name myNic -ResourceGroupName $primaryResourceRGName -Location $primaryLocation -SubnetId $vnet.Subnets[0].Id -force
  
  
            $vmConfig = New-AzureRmVMConfig -VMName "vmName" -VMSize Standard_D1 | `
            Set-AzureRmVMOperatingSystem -Linux -ComputerName $vmName -Credential $cred | `
            Set-AzureRmVMSourceImage -PublisherName Canonical -Offer UbuntuServer -Skus 14.04.2-LTS -Version latest| `
            Add-AzureRmVMNetworkInterface -Id $nic.Id

            New-AzureRmVM -ResourceGroupName $primaryResourceRGName -Location $primaryLocation -VM $vmConfig
            $vm = get-azureRmVm -Name $vmName -ResourceGroupName -ResourceGroupName $primaryResourceRGName 
        New-AzureRmResourceGroup -name $vaultRg -location $vaultRgLocation -force
        [Microsoft.Azure.Test.TestUtilities]::Wait(20 * 1000)
    # vault Creation
        New-azureRmRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
        [Microsoft.Azure.Test.TestUtilities]::Wait(20 * 1000)
        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault
    # fabric Creation    
        ### AzureToAzure New paramset 
        $fabJob=  New-AzureRmRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzureRmRecoveryServicesAsrFabric -Name $primaryFabricName
        Assert-true { $fab.name -eq $primaryFabricName }
        Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

        $fabJob=  New-AzureRmRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzureRmRecoveryServicesAsrFabric -Name $recoveryFabricName
        Assert-true { $fab.name -eq $recoveryFabricName }
        Assert-AreEqual $fab.FabricSpecificDetails.Location $recoveryLocation
        $pf = get-asrFabric -Name $primaryFabricName
        $rf = get-asrFabric -Name $recoveryFabricName
        
        ### AzureToAzure (Default)
        $job = New-AzureRmRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $pf
        WaitForJobCompletion -JobId $Job.Name
        $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
        Assert-NotNull($pc)
        Assert-AreEqual $pc.Name $primaryContainerName

        $job = New-AzureRmRecoveryServicesAsrProtectionContainer -Name $recoveryContainerName -Fabric $rf
        WaitForJobCompletion -JobId $Job.Name
        $rc = Get-asrProtectionContainer -name $recoveryContainerName -Fabric $rf
    # policy creation 
        $Job1 = New-AzureRmRecoveryServicesAsrPolicy -Name $primaryPolicyName -AzureToAzure -RecoveryPointRetentionInHours 10  -ApplicationConsistentSnapshotFrequencyInHours 5
        $Job2 = New-AzureRmRecoveryServicesAsrPolicy -Name $recoveryPolicyName -AzureToAzure -RecoveryPointRetentionInHours 10  -ApplicationConsistentSnapshotFrequencyInHours 5
        waitForJobCompletion -JobId $job1.name
        waitForJobCompletion -JobId $job2.name

        $pp = Get-AzureRmRecoveryServicesAsrPolicy -Name $primaryPolicyName
        $rp = Get-AzureRmRecoveryServicesAsrPolicy -Name $recoveryPolicyName

        # Container Mapping
    
        # Create Mapping
        $pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $primaryContainerMappingName -policy $pp -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
        WaitForJobCompletion -JobId $pcmjob.Name 

        $pcm = Get-ASRProtectionContainerMapping -Name $primaryContainerMappingName -ProtectionContainer $pc
        Assert-NotNull($pcm)
        $rcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $recoveryContainerMappingName -policy $rp -PrimaryProtectionContainer $rc -RecoveryProtectionContainer $pc
        WaitForJobCompletion -JobId $rcmjob.Name 

        $rcm = Get-ASRProtectionContainerMapping -Name $recoveryContainerMappingName -ProtectionContainer $rc
        Assert-NotNull($rcm)

    
        $primaryNetworkMappingName = getPrimaryNetworkMapping
        $recoveryNetworkMappingName = getRecoveryNetworkMapping
        $job = New-AzureRmRecoveryServicesAsrNetworkMapping -AzureToAzure -Name $primaryNetworkMappingName `
        -PrimaryFabric $pf -PrimaryAzureNetworkId $PrimaryNetworkId -RecoveryFabric $rf `
        -RecoveryAzureNetworkId $RecoveryNetworkId
        WaitForJobCompletion -JobId $job.Name

        $job = New-AzureRmRecoveryServicesAsrNetworkMapping -AzureToAzure -Name $recoveryNetworkMappingName `
        -PrimaryFabric $rf -PrimaryAzureNetworkId $RecoveryNetworkId -RecoveryFabric $pf `
        -RecoveryAzureNetworkId $PrimaryNetworkId
        WaitForJobCompletion -JobId $job.Name

        $primaryNetworkMapping = Get-AzureRmRecoveryServicesAsrNetworkMapping -PrimaryFabric $pf
        $recoveryyNetworkMapping = Get-AzureRmRecoveryServicesAsrNetworkMapping -PrimaryFabric $rf
        Assert-notNull { $networkMapping }
        $networkMapping= Get-AzureRmRecoveryServicesAsrNetworkMapping -PrimaryFabric $pf -Name $primaryNetworkMappingName 
        Assert-notNull { $networkMapping }
        
        $diskId =  $vm.StorageProfile.OsDisk.ManagedDisk.Id
        $disk = New-AzureRmRecoveryServicesAsrAzureToAzureDiskReplicationConfig -managed -LogStorageAccountId $storageAccount.Id `
         -DiskId $diskId -RecoveryResourceGroupId  $recoveryResourceGroup.Id -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
         -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
        
        New-AzureRmRecoveryServicesAsrReplicationProtectedItem -AzureToAzure
             -AzureToAzureDiskReplicationConfiguration $disk -AzureVmId $vmId
             -Name $vmName -RecoveryVmName $vmName -ProtectionContainerMapping $pcm
             -RecoveryResourceGroupId $recoveryResourceGroup.Id

}

function Test-RemoveNetworkMapping{
        $vaultName = getVaultName
        $vaultLocation = getVaultLocation
        $vaultRg = getVaultRg
        $primaryLocation = getPrimaryLocation
        $recoveryLocation = getRecoveryLocation
        $primaryFabricName = getPrimaryFabric
        $recoveryFabricName = getRecoveryFabric
        $primaryNetworkMappingName = getPrimaryNetworkMapping
        $recoveryNetworkMappingName = getRecoveryNetworkMapping
        
        $job =  Get-AzureRmRecoveryServicesAsrNetworkMapping -PrimaryFabric $pf| Remove-ASRNetworkMapping
        WaitForJobCompletion -JobId $job.Name
        $job =  Get-AzureRmRecoveryServicesAsrNetworkMapping -PrimaryFabric $rf| Remove-ASRNetworkMapping
        WaitForJobCompletion -JobId $job.Name

}


function Test-RemoveContainerMapping{
        $vaultName = getVaultName
        $vaultLocation = getVaultLocation
        $vaultRg = getVaultRg
        $primaryLocation = getPrimaryLocation
        $recoveryLocation = getRecoveryLocation
        $primaryFabricName = getPrimaryFabric
        $recoveryFabricName = getRecoveryFabric
        $primaryContainerName = getPrimaryContainer
        $recoveryContainerName = getRecoveryContainer
        $primaryPolicyName = getPrimaryPolicy
        $recoveryPolicyName = getRecoveryPolicy

        $primaryContainerMappingName = getPrimaryContainerMapping
        $recoveryContainerMappingName = getRecoveryContainerMapping

        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault
        $pf = get-asrFabric -Name $primaryFabricName
        $rf = get-asrFabric -Name $recoveryFabricName
        $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
        $rc = Get-asrProtectionContainer -name $recoveryContainerName -Fabric $rf
        $pp = Get-AzureRmRecoveryServicesAsrPolicy -Name $primaryPolicyName
        $rp = Get-AzureRmRecoveryServicesAsrPolicy -Name $recoveryPolicyName

        $pcm = Get-ASRProtectionContainerMapping -Name $primaryContainerMappingName -ProtectionContainer $pc
        $rcm = Get-ASRProtectionContainerMapping -Name $recoveryContainerMappingName -ProtectionContainer $rc

        # remove Mapping
        $Removepcm = Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping  -InputObject $pcm 
        WaitForJobCompletion -JobId $Removepcm.Name
        $pcm = Get-ASRProtectionContainerMapping -ProtectionContainer $pc | where { $_.Name -eq $PrimaryProtectionContainerMapping}
        Assert-Null($pcm)
        $RemoveRCM = Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping  -InputObject $rcm 
        WaitForJobCompletion -JobId $RemoveRCM.Name
}


function Test-RemoveContainer{

        $vaultName = getVaultName
        $vaultLocation = getVaultLocation
        $vaultRg = getVaultRg
        $primaryLocation = getPrimaryLocation
        $recoveryLocation = getRecoveryLocation
        $primaryFabricName = getPrimaryFabric
        $recoveryFabricName = getRecoveryFabric
        $primaryContainerName = getPrimaryContainer
        $recoveryContainerName = getRecoveryContainer
        $primaryPolicyName = getPrimaryPolicy
        $recoveryPolicyName = getRecoveryPolicy

        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault
        $pf = get-asrFabric -Name $primaryFabricName
        $rf = get-asrFabric -Name $recoveryFabricName
        $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
        $rc = Get-asrProtectionContainer -name $recoveryContainerName -Fabric $rf
        $pp = Get-AzureRmRecoveryServicesAsrPolicy -Name $primaryPolicyName
        $rp = Get-AzureRmRecoveryServicesAsrPolicy -Name $recoveryPolicyName
    # remove policy
        $job = $pp | Remove-ASRPolicy
        WaitForJobCompletion -JobId $Job.Name
        $job = $rp | Remove-ASRPolicy
        WaitForJobCompletion -JobId $Job.Name
        
    #Remove-AzureRmRecoveryServices
        ### ByObject (Default)
        $job = $pc | Remove-AzureRmRecoveryServicesAsrProtectionContainer
        WaitForJobCompletion -JobId $Job.Name
        $pc = Get-asrProtectionContainer -Fabric $pf | where {$_.name -eq $primaryProtectionContainerName}
        Assert-Null($pc)
        $job = $rc | Remove-AzureRmRecoveryServicesAsrProtectionContainer
        WaitForJobCompletion -JobId $Job.Name
}


function Test-RemoveFabric{
        $vaultName = getVaultName
        $vaultLocation = getVaultLocation
        $vaultRg = getVaultRg
        $primaryLocation = getPrimaryLocation
        $recoveryLocation = getRecoveryLocation
        $primaryFabricName = getPrimaryFabric
        $recoveryFabricName = getRecoveryFabric
    
        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault
        $pf = get-asrFabric -Name $primaryFabricName
        $rf = get-asrFabric -Name $recoveryFabricName

    #remove fabric
        $job = $pf | Remove-ASRFabric
        WaitForJobCompletion -JobId $Job.Name
        $pc = Get-asrProtectionContainer -Fabric $pf | where {$_.name -eq $primaryProtectionContainerName}
        Assert-Null($pc)
        $job = $rc | Remove-AzureRmRecoveryServicesAsrProtectionContainer
        WaitForJobCompletion -JobId $Job.Name

}

<#
.SYNOPSIS 
    Test GetAsrNetworkMapping parametersets
#>
function Test-AsrA2ANetworkMapping
{
     param([string] $vaultSettingsFilePath)
        Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath


        
    ### ByFabricObject
        $pf = Get-ASRFabric -Name $primaryFabricName
        $rf = Get-ASRFabric -Name $recoveryFabricName
        $job = New-AzureRmRecoveryServicesAsrNetworkMapping -AzureToAzure -Name "testnetworkMapping1" `
        -PrimaryFabric $pf -PrimaryAzureNetworkId $PrimaryAzureNetworkId -RecoveryFabric $rf `
        -RecoveryAzureNetworkId $RecoveryAzureNetworkId
        WaitForJobCompletion -JobId $job.Name

        $networkMapping = Get-AzureRmRecoveryServicesAsrNetworkMapping -PrimaryFabric $pf
        Assert-notNull { $networkMapping }
        $networkMapping= Get-AzureRmRecoveryServicesAsrNetworkMapping -PrimaryFabric $pf -Name "testnetworkMapping1" 
        Assert-notNull { $networkMapping }

     ### ByObject (Default)
        $networkMapping = Get-ASRFabric|Get-ASRNetwork|Get-ASRNetworkMapping
        Assert-notNull { $networkMapping }
}


<#
.SYNOPSIS
Site Recovery Create Policy Test -new get remove
#>
function Test-A2ARecoveryPolicy
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $TestPolicy1 = "TestPolicy"
    Get-AzureRmRecoveryServicesAsrPolicy  |   Remove-ASRPolicy
    $Job = New-AzureRmRecoveryServicesAsrPolicy -Name $TestPolicy1 -AzureToAzure -RecoveryPointRetentionInHours 10  -ApplicationConsistentSnapshotFrequencyInHours 5 
    WaitForJobCompletion -JobId $Job.Name
    # Get a profile created (with name ppAzure)
    $Policy1 = Get-AzureRmRecoveryServicesAsrPolicy -Name $TestPolicy1
    Assert-NotNull($Policy1)
    $Job = Update-AzureRmRecoveryServicesAsrPolicy  -AzureToAzure -RecoveryPointRetentionInHours 15 -InputObject $Policy1
    WaitForJobCompletion -JobId $Job.Name

    $Policy1 = Get-AzureRmRecoveryServicesAsrPolicy -Name $TestPolicy1
    # policy time updated to 15*60 = 900
    Assert-true{$policy1.ReplicationProviderSettings.RecoveryPointHistory -eq 900 }

    $RemoveJob = Remove-ASRPolicy -InputObject $Policy1
    WaitForJobCompletion -JobId $RemoveJob.Name

    $policy1 = Get-ASRPolicy| where {$_.name -eq  $TestPolicy1}
    Assert-null($policy1)
}

<#
.SYNOPSIS
Site Recovery Create/Get/Remove Policy Test -new get remove
#>
function Test-NewRemoveA2AProtectionContainer
{
    param([string] $vaultSettingsFilePath)

    
}

<#
.SYNOPSIS
Site Recovery Protection Container Mapping  - new get remove
#>
function Test-A2AProtectionContainerMapping 
{
    param([string] $vaultSettingsFilePath)

    Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    
}

<#
.SYNOPSIS
Azure to Azure replication of V2 Vm end to end 540 degree.
#>
function Test-A2AV2VmEndToEnd
{
    param([string] $vaultSettingsFilePath)

        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-AzureRmRecoveryServicesAsrVaultContext -Vault $Vault
        
        $vmId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus/providers/Microsoft.Compute/virtualMachines/PSTestV2-2"
        $rpiName = "PSTestV2-2-RPI"
        $recoveryResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourcegroups/eastus-asr"
        $logStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus-asr/providers/Microsoft.Storage/storageAccounts/eastusdisks566cacheasr"
        $recoveryAzureStorageAccountId ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus-asr/providers/Microsoft.Storage/storageAccounts/eastusdisks566asr"
        $diskUri1 ="https://eastusdisks566.blob.core.windows.net/vhds/PSTestV2-220180214101823.vhd"
        $diskUri2 = "https://eastusdisks566.blob.core.windows.net/vhds/PSTestV2-2-20180214-144548.vhd"
        $recoveryAVSetId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus-asr/providers/Microsoft.Compute/availabilitySets/AVSET-asr"
        $testNetwork = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus-asr/providers/Microsoft.Network/virtualNetworks/eastus-vnet-asr"
        $logStorageAccountIdYtoX = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/asrtesting-asr/providers/Microsoft.Storage/storageAccounts/filippostorageasr"
        $recoveryAzureStorageAccountIdYtoX ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus/providers/Microsoft.Storage/storageAccounts/eastusdisks566"
        $recoveryResourceGroupIdYtoX ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus"
        $recoveryAVSetIdYtoX = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus/providers/Microsoft.Compute/availabilitySets/AVSET"
        
        $PrimaryAzureNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus/providers/Microsoft.Network/virtualNetworks/eastus-vnet"
        $RecoveryAzureNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus-asr/providers/Microsoft.Network/virtualNetworks/eastus-vnet-asr"
    $primaryFabricName = "vkvfab2"
    $recoveryFabricName = "vkvfab1"
    $primaryProtectionContainerName = "pcEastUs"
    $recoveryProtectionContainerName = "pcWestUs"
    $policyName1 = "eastUsToWestUs"
    $policyName2 = "wesUsToeastUs"
    $PrimaryProtectionContainerMapping = "pcmEastUs"
    $recoveryProtectionContainerMapping = "pcmWestUs"

        $pf = Get-AsrFabric -Name $primaryFabricName
        $rf =  Get-AsrFabric -Name $recoveryFabricName
        $fabric =  Get-AsrFabric -Name $primaryFabricName
    
        $job = new-ASRProtectionContainer -Name $primaryProtectionContainerName -Fabric $pf
        waitForJobCompletion -JobId $job.name
        $job = new-ASRProtectionContainer -Name $recoveryProtectionContainerName -Fabric $rf
        waitForJobCompletion -JobId $job.name
        
        $pc =  Get-ASRProtectionContainer -Name $primaryProtectionContainerName -Fabric $pf
        $rc =  Get-ASRProtectionContainer -Name $recoveryProtectionContainerName -Fabric $rf

        $Job1 = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName1 -AzureToAzure -RecoveryPointRetentionInHours 10  -ApplicationConsistentSnapshotFrequencyInHours 5
        $Job2 = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName2 -AzureToAzure -RecoveryPointRetentionInHours 10  -ApplicationConsistentSnapshotFrequencyInHours 5
        waitForJobCompletion -JobId $job1.name
        waitForJobCompletion -JobId $job2.name

        $policyXtoY = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName1
        $policyYtoX = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName2

        # Create Mapping
        $pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $policyXtoY -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
        WaitForJobCompletion -JobId $pcmjob.Name 
        $pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $recoveryProtectionContainerMapping -policy $policyYtoX -PrimaryProtectionContainer $rc -RecoveryProtectionContainer $pc
        WaitForJobCompletion -JobId $pcmjob.Name

        $pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc
        
     # Create NetworkMapping 
        $job = New-AzureRmRecoveryServicesAsrNetworkMapping -AzureToAzure -Name "testnetworkMapping1" `
        -PrimaryFabric $pf -PrimaryAzureNetworkId $PrimaryAzureNetworkId -RecoveryFabric $rf `
        -RecoveryAzureNetworkId $RecoveryAzureNetworkId
        WaitForJobCompletion -JobId $job.Name
        
     # Create Reverse NetworkMapping 
        $job = New-AzureRmRecoveryServicesAsrNetworkMapping -AzureToAzure -Name "testnetworkMapping1rec" `
        -PrimaryFabric $rf -PrimaryAzureNetworkId  $RecoveryAzureNetworkId -RecoveryFabric $pf `
        -RecoveryAzureNetworkId $PrimaryAzureNetworkId

        WaitForJobCompletion -JobId $job.Name

        $disk1 = New-AsrAzureToAzureDiskReplicationConfig -VhdUri  $diskUri1 `
            -RecoveryAzureStorageAccountId $recoveryAzureStorageAccountId `
            -LogStorageAccountId $logStorageAccountId  

        $disk2 = New-AsrAzureToAzureDiskReplicationConfig -VhdUri  $diskUri2 `
            -RecoveryAzureStorageAccountId $recoveryAzureStorageAccountId `
            -LogStorageAccountId $logStorageAccountId  

        $enableDRjob = New-AzureRmRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vmId -Name $rpiName `
            -ProtectionContainerMapping $pcm `
            -RecoveryResourceGroupId  $RecoveryResourceGroupId -AzureToAzureDiskReplicationConfiguration $disk1,$disk2
        WaitForJobCompletion -JobId $enableDRjob.Name

        $job = get-AsrJob -Name $enableDRjob.Name
        WaitForIRCompletion -affectedObjectId $job.TargetObjectId
     
        $rpi = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $rpiName
        
        $setJob = Set-ASRReplicationProtectedItem -InputObject $RPI -RecoveryAvailabilitySet $recoveryAVSetId
        WaitForJobCompletion -JobId $setJob.Name

        $rpi = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $rpiName
        do{
            [Microsoft.Azure.Test.TestUtilities]::Wait(10* 1000)
            $rPoints = Get-ASRRecoveryPoint -ReplicationProtectedItem $rpi
        }while ($rpoints.count -eq 0)

        $tfoJob = Start-AzureRmRecoveryServicesAsrTestFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery -RecoveryPoint $rpoints[0] `
            -AzureVMNetworkId $testNetwork
        WaitForJobCompletion -JobId $tfoJob.Name
        $cleanupJob = Start-AzureRmRecoveryServicesAsrTestFailoverCleanupJob -ReplicationProtectedItem $rpi -Comment "testing done"
        WaitForJobCompletion -JobId $cleanupJob.Name
        
        $foJob = Start-AzureRmRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery
        WaitForJobCompletion -JobId $foJob.Name
        $commitJob = Start-AzureRmRecoveryServicesAsrCommitFailoverJob -ReplicationProtectedItem $rpi 
        WaitForJobCompletion -JobId $commitJob.Name

        $pcmYtoX = Get-ASRProtectionContainerMapping -Name $recoveryProtectionContainerMapping -ProtectionContainer $rc
        $job = Update-AzureRmRecoveryServicesAsrProtectionDirection `
                -AzureToAzure `
                -LogStorageAccountId $logStorageAccountIdYtoX `
                -ProtectionContainerMapping $pcmYtoX  `
                -RecoveryAzureStorageAccountId $recoveryAzureStorageAccountIdYtoX `
                -RecoveryResourceGroupId $recoveryResourceGroupIdYtoX `
                -ReplicationProtectedItem $rpi -RecoveryAvailabilitySetId $recoveryAVSetIdYtoX
}



<#
.SYNOPSIS
Azure to Azure replication of V2 Vm managed disk end to end 540 degree.
#>
function Test-A2AV2ManagedDisk
{
    param([string] $vaultSettingsFilePath)

        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName "pravk-eastus2euap-rg1" -Name "pravk-a2a-vault1"
        Set-AzureRmRecoveryServicesAsrVaultContext -Vault $Vault
        
        $vmId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/east/providers/Microsoft.Compute/virtualMachines/PS-mdVm1"
        $rpiName = "PS-mdVm1"
        $recoveryResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourcegroups/rr-ecy"
        $logStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ccyrgdef/providers/Microsoft.Storage/storageAccounts/testccy"
        $diskUri1 ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/east/providers/Microsoft.Compute/disks/PS-mdVm1_OsDisk_1_bc26a0fe932547f9aaded45e17a319ff"
        $diskUri2 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/EASTUS/providers/Microsoft.Compute/disks/TestMdDisk1"
        $recoveryAccountType = "PremiumLRS"
        $RecoveryTargetAccountType = "PremiumLRS"
        $recoveryAVSetId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/RR-ECY/providers/Microsoft.Compute/availabilitySets/abcde"
        $testNetwork = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2a-pri-rg-acan-sik-ecy/providers/Microsoft.Network/virtualNetworks/a2a-pri-vnet-acan-sik-ecy"
        
        $logStorageAccountIdYtoX = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/asrtesting-asr/providers/Microsoft.Storage/storageAccounts/filippostorageasr"
        $recoveryAzureStorageAccountIdYtoX ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus/providers/Microsoft.Storage/storageAccounts/eastusdisks566"
        $recoveryResourceGroupIdYtoX ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus"
        $recoveryAVSetIdYtoX = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus/providers/Microsoft.Compute/availabilitySets/AVSET"
        
        $PrimaryAzureNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/RR-ECY-asr/providers/Microsoft.Network/virtualNetworks/RR-ECY-vnet-asr"
        $RecoveryAzureNetworkId = $testNetwork
    $primaryFabricName = "vkvFabCCY"
    $recoveryFabricName = "vkvFabECY"
    $primaryProtectionContainerName = "pcccy"
    $recoveryProtectionContainerName = "pcecy"
    $policyName1 = "ccytoecy"
    $policyName2 = "ecytoccy"
    $PrimaryProtectionContainerMapping = "pcmEcy"
    $recoveryProtectionContainerMapping = "pcmCcy"

    
    #  $fabJob=  New-AzureRmRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location "centraluseuap"
    #    WaitForJobCompletion -JobId $fabJob.Name
    #$fabJob=  New-AzureRmRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location "eastus2euap"
    #    WaitForJobCompletion -JobId $fabJob.Name

        $pf = Get-AsrFabric -Name $primaryFabricName
        $rf =  Get-AsrFabric -Name $recoveryFabricName
        $fabric =  Get-AsrFabric -Name $primaryFabricName
    
        #$job = new-ASRProtectionContainer -Name $primaryProtectionContainerName -Fabric $pf
        #waitForJobCompletion -JobId $job.name
        #$job = new-ASRProtectionContainer -Name $recoveryProtectionContainerName -Fabric $rf
        #waitForJobCompletion -JobId $job.name
        
        $pc =  Get-ASRProtectionContainer -Name $primaryProtectionContainerName -Fabric $pf
        $rc =  Get-ASRProtectionContainer -Name $recoveryProtectionContainerName -Fabric $rf

        #$Job1 = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName1 -AzureToAzure -RecoveryPointRetentionInHours 10  -ApplicationConsistentSnapshotFrequencyInHours 5
        #$Job2 = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName2 -AzureToAzure -RecoveryPointRetentionInHours 10  -ApplicationConsistentSnapshotFrequencyInHours 5
        #waitForJobCompletion -JobId $job1.name
        #waitForJobCompletion -JobId $job2.name

        $policyXtoY = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName1
        $policyYtoX = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName2

        # Create Mapping
        #$pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $policyXtoY -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
        #WaitForJobCompletion -JobId $pcmjob.Name 
        ##$pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $recoveryProtectionContainerMapping -policy $policyYtoX -PrimaryProtectionContainer $rc -RecoveryProtectionContainer $pc
        #WaitForJobCompletion -JobId $pcmjob.Name

        $pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc
        
     # Create NetworkMapping 
        #$job = New-AzureRmRecoveryServicesAsrNetworkMapping -AzureToAzure -Name "testnetworkMapping1" `
        #-PrimaryFabric $pf -PrimaryAzureNetworkId $PrimaryAzureNetworkId -RecoveryFabric $rf `
        #-RecoveryAzureNetworkId $RecoveryAzureNetworkId
        #WaitForJobCompletion -JobId $job.Name
        
     # Create Reverse NetworkMapping 
        #$job = New-AzureRmRecoveryServicesAsrNetworkMapping -AzureToAzure -Name "testnetworkMapping1rec" `
        #-PrimaryFabric $rf -PrimaryAzureNetworkId  $RecoveryAzureNetworkId -RecoveryFabric $pf `
        #-RecoveryAzureNetworkId $PrimaryAzureNetworkId

        #WaitForJobCompletion -JobId $job.Name

        $disk1 = New-ASRAzureToAzureManagedDiskReplicationConfig -diskId  $diskUri1 `
            -RecoveryReplicaDiskAccountType $RecoveryTargetAccountType `
            -RecoveryTargetDiskAccountType $recoveryAccountType `
            -RecoveryResourceGroupId $RecoveryResourceGroupId `
            -LogStorageAccountId $logStorageAccountId   

        $disk2 = New-ASRAzureToAzureManagedDiskReplicationConfig -diskId  $diskUri2 `
            -RecoveryReplicaDiskAccountType $RecoveryTargetAccountType `
            -RecoveryTargetDiskAccountType $recoveryAccountType `
            -RecoveryResourceGroupId $RecoveryResourceGroupId `
            -LogStorageAccountId $logStorageAccountId  

        $enableDRjob = New-AzureRmRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vmId -Name $rpiName `
            -ProtectionContainerMapping $pcm -RecoveryAvailabilitySet $recoveryAVSetId `
            -RecoveryResourceGroupId  $RecoveryResourceGroupId -AzureToAzureManagedDiskReplicationConfiguration $disk1,$disk2
        WaitForJobCompletion -JobId $enableDRjob.Name

        $job = get-AsrJob -Name $enableDRjob.Name
        WaitForIRCompletion -affectedObjectId $job.TargetObjectId
     
        $rpi = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $rpiName
        
        $setJob = Set-ASRReplicationProtectedItem -InputObject $RPI -RecoveryAvailabilitySet $recoveryAVSetId
        WaitForJobCompletion -JobId $setJob.Name

        $rpi = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $rpiName
        do{
            [Microsoft.Azure.Test.TestUtilities]::Wait(10* 1000)
            $rPoints = Get-ASRRecoveryPoint -ReplicationProtectedItem $rpi
        }while ($rpoints.count -eq 0)

        $tfoJob = Start-AzureRmRecoveryServicesAsrTestFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery -RecoveryPoint $rpoints[0] `
            -AzureVMNetworkId $testNetwork
        WaitForJobCompletion -JobId $tfoJob.Name
        $cleanupJob = Start-AzureRmRecoveryServicesAsrTestFailoverCleanupJob -ReplicationProtectedItem $rpi -Comment "testing done"
        WaitForJobCompletion -JobId $cleanupJob.Name
        
        $foJob = Start-AzureRmRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery
        WaitForJobCompletion -JobId $foJob.Name
        $commitJob = Start-AzureRmRecoveryServicesAsrCommitFailoverJob -ReplicationProtectedItem $rpi 
        WaitForJobCompletion -JobId $commitJob.Name

        $pcmYtoX = Get-ASRProtectionContainerMapping -Name $recoveryProtectionContainerMapping -ProtectionContainer $rc
        $job = Update-AzureRmRecoveryServicesAsrProtectionDirection `
                -AzureToAzure `
                -LogStorageAccountId $logStorageAccountIdYtoX `
                -ProtectionContainerMapping $pcmYtoX  `
                -RecoveryAzureStorageAccountId $recoveryAzureStorageAccountIdYtoX `
                -RecoveryResourceGroupId $recoveryResourceGroupIdYtoX `
                -ReplicationProtectedItem $rpi -RecoveryAvailabilitySetId $recoveryAVSetIdYtoX
}