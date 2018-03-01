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
$vaultName = "A2APowershellTest"
$vaultLocation = "centraluseuap"
$vaultRg = "A2APowershellTestRg"
$primaryLocation = "eastasia" 
$recoveryLocation = "southeastasia"
$primaryFabricName = "a2aPrimaryFabric3"
$recoveryFabricName = "a2aRecoveryFabric3"
                         
$PrimaryAzureNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/powershellTest/providers/Microsoft.Network/virtualNetworks/powershellTest-vnet"
$RecoveryAzureNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2a-source-rg-southeastasia/providers/Microsoft.Network/virtualNetworks/a2a-source-rg-vnetasr"
$networkMappingName = "a2aNetworkMappingName"
$policyName1 = "policy1"
$policyName2 = "policy2"

$primaryProtectionContainerName = "primaryProtectionContainerName"
$PrimaryProtectionContainerMapping = "PrimaryProtectionContainerMapping"

$recoveryProtectionContainerName = "recoveryProtectionContainerName"
$recoveryProtectionContainerMapping = "B2AProtectionContainerMapping"

$V2Vm1Id = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/powershellTest/providers/Microsoft.Compute/virtualMachines/PTlinV2-5"
$RecoveryResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourcegroups/powershellTest-asr"
$rpiName1 = "6d754772-690e-49e4-8072-8b13385c2abb"
$AzureVMNetworkId = $PrimaryAzureNetworkId 

$B2ARecoveryStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/powershellTest/providers/Microsoft.Storage/storageAccounts/powershelltestdisks347"
$B2ACacheStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2a-rg/providers/Microsoft.Storage/storageAccounts/a2argdisks412"
$B2ARecoveryResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourcegroups/powershellTest"

$V1Vm1Id = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/v1ps/providers/Microsoft.ClassicCompute/virtualMachines/v1Azure2"
$v1rpiName1 = "v1AzureVM1"

$B2ARecoveryStorageAccountIdV1 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/v1ps/providers/Microsoft.ClassicStorage/storageAccounts/v1ps8416"
$B2ACacheStorageAccountIdV1 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/akagtestrg/providers/Microsoft.ClassicStorage/storageAccounts/akagteststracc"
$B2ARecoveryResourceGroupIdV1 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourcegroups/powershellTest"
##

<#
.SYNOPSIS
Wait for job completion
Usage:
    WaitForJobCompletion -JobId $Job.ID
    WaitForJobCompletion -JobId $Job.ID -NumOfSecondsToWait 10
#>
function WaitForJobCompletion
{ 
    param(
        [string] $JobId,
        [int] $JobQueryWaitTimeInSeconds = 60,
        [string] $Message = "NA"
        )
        $isJobLeftForProcessing = $true;
        do
        {
            $Job = Get-AzureRmRecoveryServicesAsrJob -Name $JobId
            Write-Host $("Job Status:") -ForegroundColor Green
            $Job

            if($Job.State -eq "InProgress" -or $Job.State -eq "NotStarted")
            {
                $isJobLeftForProcessing = $true
            }
            else
            {
                $isJobLeftForProcessing = $false
            }

            if($isJobLeftForProcessing)
            {
                if($Message -ne "NA")
                {
                    Write-Host $Message -ForegroundColor Yellow
                }
                else
                {
                    Write-Host $($($Job.JobType) + " in Progress...") -ForegroundColor Yellow
                }
                Write-Host $("Waiting for: " + $JobQueryWaitTimeInSeconds.ToString() + " Seconds") -ForegroundColor Yellow
                [Microsoft.Azure.Test.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
            }else
            {
                if( !(($job.State -eq "Succeeded") -or ($job.State -eq "CompletedWithInformation")))
                {
                    throw "Job " + $JobId + "failed."
                }
            }
        }While($isJobLeftForProcessing)
}

<#
.SYNOPSIS
Wait for IR job completion
Usage:
    WaitForJobCompletion -VM $VM
    WaitForJobCompletion -VM $VM -NumOfSecondsToWait 10
#>
Function WaitForIRCompletion
{ 
    param(
        [PSObject] $affectedObjectId,
        [int] $JobQueryWaitTimeInSeconds = 60
        )
        $isProcessingLeft = $true
        $IRjobs = $null

        Write-Host $("IR in Progress...") -ForegroundColor Yellow
        do
        {
            $IRjobs = Get-AzureRmRecoveryServicesAsrJob -TargetObjectId $affectedObjectId | Sort-Object StartTime -Descending | select -First 2 | Where-Object{$_.JobType -eq "SecondaryIrCompletion"}
            if($IRjobs -eq $null -or $IRjobs.Count -ne 1)
            {
                $isProcessingLeft = $true
            }
            else
            {
                $isProcessingLeft = $false
            }

            if($isProcessingLeft)
            {
                Write-Host $("IR in Progress...") -ForegroundColor Yellow
                Write-Host $("Waiting for: " + $JobQueryWaitTimeInSeconds.ToString() + " Seconds") -ForegroundColor Yellow
                [Microsoft.Azure.Test.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
            }
        }While($isProcessingLeft)

        Write-Host $("Finalize IR jobs:") -ForegroundColor Green
        $IRjobs
        WaitForJobCompletion -JobId $IRjobs[0].Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds -Message $("Finalize IR in Progress...")
}

<#
.SYNOPSIS
    NewA2ADiskReplicationConfiguration creation test.
#>
function Test-NewA2ADiskReplicationConfiguration
{
    $recoveryStorageAccountId ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2a-rg/providers/Microsoft.Storage/storageAccounts/a2argdisks412"
    $logStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ltrgp1705152333/providers/Microsoft.Storage/storageAccounts/stagingsa2name1705152333"
    $vhdUri = "https://powershelltestdiag414.blob.core.windows.net/vhds/pslinV2-520180112143232.vhd"

    $v = New-ASRAzureToAzureDiskReplicationConfig -VhdUri  $vhdUri `
        -RecoveryAzureStorageAccountId $recoveryStorageAccountId `
        -LogStorageAccountId   $logStorageAccountId

     Assert-True { $v.vhdUri -eq $vhdUri }
     Assert-True { $v.recoveryAzureStorageAccountId -eq $recoveryStorageAccountId  }
     Assert-True { $v.logStorageAccountId -eq $logStorageAccountId }
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
        Assert-true { $networkMapping.name -eq "testnetworkMapping1"}
        Assert-true { $networkMapping.PrimaryNetworkId -eq $PrimaryAzureNetworkId}
        Assert-true { $networkMapping.RecoveryNetworkId -eq $RecoveryAzureNetworkId}
       
     ### ByObject (Default)
        $networkMapping = Get-ASRFabric|Get-ASRNetwork|Get-ASRNetworkMapping
        Assert-notNull { $networkMapping }
}

<#
.SYNOPSIS 
    Test GetAsrFabric new parametersets
#>
function Test-NewAsrFabric {
    param([string] $vaultSettingsFilePath)
        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault
    ### AzureToAzure New paramset 
        $fabricName = "TestFabricukwest"
        $fabJob=  New-AzureRmRecoveryServicesAsrFabric -Azure -Name $fabricName -Location "ukwest"
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzureRmRecoveryServicesAsrFabric -Name $fabricName
        Assert-true { $fab.name -eq $fabricName }
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

    $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-AzureRmRecoveryServicesAsrVaultContext -Vault $Vault
    $pf = get-asrFabric -Name $primaryFabricName

    ### AzureToAzure (Default)
    $job = New-AzureRmRecoveryServicesAsrProtectionContainer -Name "azurepc1" -Fabric $pf
    WaitForJobCompletion -JobId $Job.Name
    $pc = Get-asrProtectionContainer -name "azurepc1" -Fabric $pf
    Assert-NotNull($pc)
    Assert-true{$pc.name -eq "azurepc1"}
    #Remove-AzureRmRecoveryServices
    ### ByObject (Default)
    $job = $pc | Remove-AzureRmRecoveryServicesAsrProtectionContainer
    WaitForJobCompletion -JobId $Job.Name
    $pc = Get-asrProtectionContainer -Fabric $pf | where {$_.name -eq "azurepc1" }
     
    Assert-Null($pc)
}

<#
.SYNOPSIS
Site Recovery Protection Container Mapping  - new get remove
#>
function Test-A2AProtectionContainerMapping 
{
    param([string] $vaultSettingsFilePath)

    Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -Name $primaryFabricName
    
    $policyName1 = "TestPCMPolicy1"
    $PolicyName2 = "TestPCMPolicy2"
    $PrimaryProtectionContainerMapping ="pcmName"

    $job = new-ASRProtectionContainer -Name $primaryProtectionContainerName -Fabric  $fabric
    waitForJobCompletion -JobId $job.name
    $pc =  Get-ASRProtectionContainer -Name $primaryProtectionContainerName -Fabric $fabric

    $rf =  Get-AsrFabric -Name $recoveryFabricName
    
    $job = new-ASRProtectionContainer -Name $recoveryProtectionContainerName -Fabric  $rf
    waitForJobCompletion -JobId $job.name
    $rpc =  Get-ASRProtectionContainer -Name $recoveryProtectionContainerName -Fabric $rf
    
    $Job1 = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName1 -AzureToAzure -RecoveryPointRetentionInHours 10  -ApplicationConsistentSnapshotFrequencyInHours 5
    $Job2 = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName2 -AzureToAzure -RecoveryPointRetentionInHours 10  -ApplicationConsistentSnapshotFrequencyInHours 5
    waitForJobCompletion -JobId $job1.name
    waitForJobCompletion -JobId $job2.name

    $Policy1 = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName1
    $Policy2 = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName2

    # Create Mapping
    $pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $Policy1 -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rpc
    WaitForJobCompletion -JobId $pcmjob.Name 

    $pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc
    Assert-NotNull($pcm)
    Assert-true { $pcm.name -eq  $PrimaryProtectionContainerMapping}
    Assert-true { $pcm.PolicyId.ToLower()  -eq  $Policy1.Id.ToLower()}
    Assert-true { $pcm.TargetProtectionContainerId.ToLower() -eq $rpc.ID.ToLower()}
    Assert-true { $pcm.SourceProtectionContainerFriendlyName.ToLower() -eq $pc.friendlyname.ToLower()}
       
    # remove Mapping
    $Removepcm = Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping  -InputObject $pcm 
    WaitForJobCompletion -JobId $Removepcm.Name
    $pcm = Get-ASRProtectionContainerMapping -ProtectionContainer $pc | where { $_.Name -eq $PrimaryProtectionContainerMapping}
    Assert-Null($pcm)
}

<#
.SYNOPSIS
Azure to Azure replication of V2 Vm end to end 540 degree.
Without Assert if something goes wrong entity will not be found in next step.
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
