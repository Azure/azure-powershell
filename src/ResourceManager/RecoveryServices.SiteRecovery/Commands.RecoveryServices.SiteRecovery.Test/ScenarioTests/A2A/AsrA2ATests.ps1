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

    $v = New-AzureToAzureDiskReplicationConfiguration -VhdUri  $vhdUri `
        -RecoveryAzureStorageAccountId $recoveryStorageAccountId `
        -LogStorageAccountId   $logStorageAccountId

     Assert-True { $v.vhdUri -eq $vhdUri }
     Assert-True { $v.recoveryAzureStorageAccountId -eq $recoveryStorageAccountId  }
     Assert-True { $v.logStorageAccountId -eq $logStorageAccountId }
}


<#
.SYNOPSIS 
    Test NewAsrNetworkMapping parametersets
#>
function Test-NewAsrNetworkMapping{
    param([string] $vaultSettingsFilePath)
        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault
     
        $pf = Get-ASRFabric -Name $primaryFabricName
        $rf = Get-ASRFabric -Name $recoveryFabricName
        get-asrNetworkMapping -primaryFabric $pf | Remove-AzureRmRecoveryServicesAsrNetworkMapping        ### AzureToAzure -new paramset        $job = New-AzureRmRecoveryServicesAsrNetworkMapping -AzureToAzure -Name "testnetworkMapping1" `        -PrimaryFabric $pf -PrimaryAzureNetworkId $PrimaryAzureNetworkId -RecoveryFabric $rf `        -RecoveryAzureNetworkId $RecoveryAzureNetworkId         WaitForJobCompletion -JobId $job.Name        get-asrNetworkMapping -Name "testnetworkMapping1" -primaryFabric $pf | Remove-AzureRmRecoveryServicesAsrNetworkMapping}

<#
.SYNOPSIS 
    Test GetAsrNetworkMapping parametersets
#>
function Test-GetAsrNetworkMapping
{
     param([string] $vaultSettingsFilePath)
        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault

    ### ByFabricObject
        get-asrFabric|get-asrNetworkMapping
        $pf = Get-ASRFabric -Name $primaryFabricName
        $rf = Get-ASRFabric -Name $recoveryFabricName
        $job = New-AzureRmRecoveryServicesAsrNetworkMapping -AzureToAzure -Name "testnetworkMapping1" `        -PrimaryFabric $pf -PrimaryAzureNetworkId $PrimaryAzureNetworkId -RecoveryFabric $rf `        -RecoveryAzureNetworkId $RecoveryAzureNetworkId
        WaitForJobCompletion -JobId $job.Name

        $networkMapping = Get-AzureRmRecoveryServicesAsrNetworkMapping -PrimaryFabric $pf
        Assert-notNull { $networkMapping }
        Get-AzureRmRecoveryServicesAsrNetworkMapping -PrimaryFabric $pf -Name $networkMapping[0].Name
        Assert-notNull { $networkMapping }

     ### ByObject (Default)
        $networkMapping = get-asrFabric|get-asrNetwork|get-asrNetworkMapping
        Assert-notNull { $networkMapping }
        $network = get-asrFabric|get-asrNetwork
}

<#
.SYNOPSIS 
    Test GetAsrFabric new parametersets
#>
function Test-NewAsrFabric {
    param([string] $vaultSettingsFilePath)
        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault
    ### AzureToAzure – new paramset         $fabricName = "TestFabric"        $fabJob=  New-AzureRmRecoveryServicesAsrFabric -Azure -Name $fabricName -Location "northeurope"        WaitForJobCompletion -JobId $fabJob.Name        $fab = Get-AzureRmRecoveryServicesAsrFabric -Name $fabricName        Assert-true { $fab.name -eq $fabricName }
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
    $RemoveJob = Remove-ASRPolicy -InputObject $Policy1
   
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
  
    #Remove-AzureRmRecoveryServices
    ### ByObject (Default)
    Get-asrProtectionContainer -name "azurepc1" -Fabric $pf | Remove-AzureRmRecoveryServicesAsrProtectionContainer
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
    #waitForJobCompletion -JobId $job.name
    $pc =  Get-ASRProtectionContainer -Name $primaryProtectionContainerName -Fabric $fabric

    $rf =  Get-AsrFabric -Name $recoveryFabricName
    
    $job = new-ASRProtectionContainer -Name $recoveryProtectionContainerName -Fabric  $rf
    #waitForJobCompletion -JobId $job.name
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
    # remove Mapping
    $Removepcm = Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping  -InputObject $pcm 
    WaitForJobCompletion -JobId $Removepcm.Name
}

<#
.SYNOPSIS
Azure to Azure replication of V1 Vm end to end 540 degree.
#>
function Test-A2AV1VmEndToEnd
{
    param([string] $vaultSettingsFilePath)

        $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-AzureRmRecoveryServicesAsrVaultContext -Vault $Vault
        
        $vmId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus/providers/Microsoft.ClassicCompute/virtualMachines/PSTestV1-1"
        $rpiName = "PSTestV1-1-RPI"
        $recoveryResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourcegroups/eastus-asr"
        $logStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus-asr/providers/Microsoft.ClassicStorage/storageAccounts/eastus8660cacheasr"
        $recoveryAzureStorageAccountId ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus-asr/providers/Microsoft.ClassicStorage/storageAccounts/eastus8660asr"
        $recoveryCloudServiceId ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus-asr/providers/Microsoft.ClassicCompute/domainNames/PSTestV1-17573-asr"
        $diskUri1 ="https://eastus8660.blob.core.windows.net/vhds/PSTestV1-1-os-3320.vhd"
        $diskUri2 = "https://eastus8660.blob.core.windows.net/vhds/PSTestV1-1-20180214-134107.vhd"
        $testNetwork = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/test123/providers/Microsoft.ClassicNetwork/virtualNetworks/test123"
        
        $logStorageAccountIdYtoX = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/test123/providers/Microsoft.ClassicStorage/storageAccounts/test1235311"
        $recoveryAzureStorageAccountIdYtoX ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus/providers/Microsoft.ClassicStorage/storageAccounts/eastus8660"
        $recoveryResourceGroupIdYtoX ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus"
        $recoveryCloudServiceIdYtoX ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus/providers/Microsoft.ClassicCompute/domainNames/PSTestV1-17573"

        
    $primaryFabricName = "vkvfab2"
    $recoveryFabricName = "vkvfab1"
    $primaryProtectionContainerName = "pcEastUs"
    $recoveryProtectionContainerName = "pcWestUs"
    $policyName1 = "eastUsToWestUs"
    $policyName2 = "wesUsToeastUs"
    $PrimaryProtectionContainerMapping = "pcmEastUs"
    $recoveryProtectionContainerMapping = "pcmWestUs"

        #$fabJob=  New-AzureRmRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location "eastus"        #WaitForJobCompletion -JobId $fabJob.Name

        #$fabJob=  New-AzureRmRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location "westus"        #WaitForJobCompletion -JobId $fabJob.Name

        $pf = get-AsrFabric -Name $primaryFabricName
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

        #Create Mapping
        $pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $policyXtoY -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
        WaitForJobCompletion -JobId $pcmjob.Name 
        $pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $recoveryProtectionContainerMapping -policy $policyYtoX -PrimaryProtectionContainer $rc -RecoveryProtectionContainer $pc
        WaitForJobCompletion -JobId $pcmjob.Name

        $pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc
        $pcmYtoX  = Get-ASRProtectionContainerMapping -Name $recoveryProtectionContainerMapping -ProtectionContainer $rc
        $disk1 = new-AzureToAzureDiskReplicationConfiguration -vhdUri  $diskUri1 `
            -RecoveryAzureStorageAccountId $recoveryAzureStorageAccountId `
            -LogStorageAccountId $logStorageAccountId  

        $disk2 = new-AzureToAzureDiskReplicationConfiguration -vhdUri  $diskUri2 `
            -RecoveryAzureStorageAccountId $recoveryAzureStorageAccountId `
            -LogStorageAccountId $logStorageAccountId  

       $enableDRjob = New-AzureRmRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vmId -Name $rpiName `
            -RecoveryCloudServiceId  $recoveryCloudServiceId -ProtectionContainerMapping $pcm `
            -RecoveryResourceGroupId  $RecoveryResourceGroupId -AzureToAzureDiskReplicationConfiguration $disk1,$disk2 

        WaitForJobCompletion -JobId $enableDRjob.Name
        $job = get-AsrJob -Name $enableDRjob.Name
        WaitForIRCompletion -affectedObjectId $job.TargetObjectId

        $rpi = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $rpiName
        do{
            [Microsoft.Azure.Test.TestUtilities]::Wait(10* 1000)
            $rPoints = Get-ASRRecoveryPoint -ReplicationProtectedItem $rpi
        }while ($rpoints.count -eq 0)

        $tfoJob = Start-AzureRmRecoveryServicesAsrTestFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery -RecoveryPoint $rpoints[0] `
            -CloudServiceCreationOption "UseRecoveryCloudService" -AzureVMNetworkId $testNetwork
        WaitForJobCompletion -JobId $tfoJob.Name
        $cleanupJob = Start-AzureRmRecoveryServicesAsrTestFailoverCleanupJob -ReplicationProtectedItem $rpi -Comment "testing done"
        WaitForJobCompletion -JobId $cleanupJob.Name

        $foJob = Start-AzureRmRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery
        WaitForJobCompletion -JobId $foJob.Name
        $commitJob = Start-AzureRmRecoveryServicesAsrCommitFailoverJob -ReplicationProtectedItem $rpi 
        WaitForJobCompletion -JobId $commitJob.Name

        $job = Update-AzureRmRecoveryServicesAsrProtectionDirection `
                -AzureToAzure `
                -LogStorageAccountId $logStorageAccountIdYtoX `
                -ProtectionContainerMapping $pcmYtoX  `
                -RecoveryAzureStorageAccountId $recoveryAzureStorageAccountIdYtoX `
                -RecoveryResourceGroupId $recoveryResourceGroupIdYtoX `
                -ReplicationProtectedItem $rpi `
                -RecoveryCloudServiceId  $recoveryCloudServiceIdYtoX
    
        WaitForJobCompletion -JobId $job.Name
        $job = get-AsrJob -Name $job.Name
        WaitForIRCompletion -affectedObjectId $job.TargetObjectId
        
        $rpi = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $rc -Name $rpiName
        
        $foJob = Start-AzureRmRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery
        WaitForJobCompletion -JobId $foJob.Name
        $commitJob = Start-AzureRmRecoveryServicesAsrCommitFailoverJob -ReplicationProtectedItem $rpi 
        WaitForJobCompletion -JobId $commitJob.Name
        $job = Update-AzureRmRecoveryServicesAsrProtectionDirection `
                -AzureToAzure `
                -LogStorageAccountId $logStorageAccountId `
                -ProtectionContainerMapping $pcmYtoX  `
                -RecoveryAzureStorageAccountId $recoveryAzureStorageAccountId `
                -RecoveryResourceGroupId $recoveryResourceGroupId `
                -ReplicationProtectedItem $rpi `
                -RecoveryCloudServiceId  $recoveryCloudServiceId

        $rpi = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $rpiName
        Remove-ASRReplicationProtectedItem -InputObject $rpi
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
        $logStorageAccountIdYtoX = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/krishnr/providers/Microsoft.Storage/storageAccounts/krishnrdiag562"
        $recoveryAzureStorageAccountIdYtoX ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus/providers/Microsoft.Storage/storageAccounts/eastusdisks566"
        $recoveryResourceGroupIdYtoX ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus"
        $recoveryAVSetIdYtoX = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/eastus/providers/Microsoft.Compute/availabilitySets/AVSET"
        
    $primaryFabricName = "vkvfab2"
    $recoveryFabricName = "vkvfab1"
    $primaryProtectionContainerName = "pcEastUs"
    $recoveryProtectionContainerName = "pcWestUs"
    $policyName1 = "eastUsToWestUs"
    $policyName2 = "wesUsToeastUs"
    $PrimaryProtectionContainerMapping = "pcmEastUs"
    $recoveryProtectionContainerMapping = "pcmWestUs"

        $pf = get-AsrFabric -Name $primaryFabricName
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
       # waitForJobCompletion -JobId $job1.name
        #waitForJobCompletion -JobId $job2.name

        $policyXtoY = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName1
        $policyYtoX = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName2

        # Create Mapping
        #$pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $policyXtoY -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
        #WaitForJobCompletion -JobId $pcmjob.Name 
        #$pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $recoveryProtectionContainerMapping -policy $policyYtoX -PrimaryProtectionContainer $rc -RecoveryProtectionContainer $pc
        #WaitForJobCompletion -JobId $pcmjob.Name

        $pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc
        
        $disk1 = new-AzureToAzureDiskReplicationConfiguration -VhdUri  $diskUri1 `
            -RecoveryAzureStorageAccountId $recoveryAzureStorageAccountId `
            -LogStorageAccountId $logStorageAccountId  

        $disk2 = new-AzureToAzureDiskReplicationConfiguration -VhdUri  $diskUri2 `
            -RecoveryAzureStorageAccountId $recoveryAzureStorageAccountId `
            -LogStorageAccountId $logStorageAccountId  

        $enableDRjob = New-AzureRmRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vmId -Name $rpiName `
            -ProtectionContainerMapping $pcm `
            -RecoveryResourceGroupId  $RecoveryResourceGroupId -AzureToAzureDiskReplicationConfiguration $disk1,$disk2
        WaitForJobCompletion -JobId $enableDRjob.Name
        $job = get-AsrJob -Name $enableDRjob.Name
        WaitForIRCompletion -affectedObjectId $job.TargetObjectId
     
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
                -ReplicationProtectedItem $rpi 
    
        WaitForJobCompletion -JobId $job.Name
        $job = get-AsrJob -Name $job.Name
        WaitForIRCompletion -affectedObjectId $job.TargetObjectId
        
        $rpi = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $rc -Name $rpiName
        
        $foJob = Start-AzureRmRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery
        WaitForJobCompletion -JobId $foJob.Name
        $commitJob = Start-AzureRmRecoveryServicesAsrCommitFailoverJob -ReplicationProtectedItem $rpi 
        WaitForJobCompletion -JobId $commitJob.Name
        $job = Update-AzureRmRecoveryServicesAsrProtectionDirection `
                -AzureToAzure `
                -LogStorageAccountId $logStorageAccountId `
                -ProtectionContainerMapping $pcmYtoX  `
                -RecoveryAzureStorageAccountId $recoveryAzureStorageAccountId `
                -RecoveryResourceGroupId $recoveryResourceGroupId `
                -ReplicationProtectedItem $rpi 

        $rpi = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $rpiName
        Remove-ASRReplicationProtectedItem -InputObject $rpi
}


<#
.SYNOPSIS
Site Recovery Create Recovery Plan Test
#>
function Test-A2AV2RecoveryPlanEndToEnd
{
    $rpiName1 = "PSLinV2-4"
    $rpiName2 = "psLinV2-2"
    $rpName = "a2aRPV2-2"

    $Vault = Get-AzureRMRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-AzureRmRecoveryServicesAsrVaultContext -Vault $Vault

    $pf = get-AsrFabric -Name $primaryFabricName
    $rf =  Get-AsrFabric -Name $recoveryFabricName
    
    $pc =  Get-ASRProtectionContainer -Name $primaryProtectionContainerName -Fabric $pf
    $rc =  Get-ASRProtectionContainer -Name $recoveryProtectionContainerName -Fabric $rf

    $rpi1 = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -friendlyName $rpiName1
    $rpi2 = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -friendlyName $rpiName2

    $Job = New-AzureRmRecoveryServicesAsrRecoveryPlan -Name $rpName -PrimaryFabric $pf -RecoveryFabric $rf -ReplicationProtectedItem $rpi1
    WaitForJobCompletion -JobId $Job.Name
    $recoveryPlan = Get-AsrRecoveryPlan -Name $rpName
    $recoveryPlan = Edit-ASRRecoveryPlan -RecoveryPlan $recoveryPlan -AppendGroup
    $recoveryPlan = Edit-ASRRecoveryPlan -RecoveryPlan $recoveryPlan -Group $recoveryPlan.Groups[3] -AddProtectedItems $rpi2
    $currentJob = Update-ASRRecoveryPlan -RecoveryPlan $recoveryPlan
    WaitForJobCompletion -JobId $currentJob.Name

    $currentJob = Start-ASRTestFailoverJob -RecoveryPlan $recoveryPlan -Direction PrimaryToRecovery -AzureVMNetworkId $testNetwork
    WaitForJobCompletion -JobId $currentJob.Name
    $currentJob = Start-ASRTestFailoverCleanupJob -RecoveryPlan $recoveryPlan -Comment "d"
    WaitForJobCompletion -JobId $currentJob.Name

    $currentJob = Start-ASRUnPlannedFailoverJob -RecoveryPlan $recoveryPlan -Direction PrimaryToRecovery
    WaitForJobCompletion -JobId $currentJob.Name 

    $currentJob = Start-AsrCommitFailoverJob -RecoveryPlan $recoveryPlan
    $currentJob
    WaitForJobCompletion -JobId $currentJob.Name
}

<#
.SYNOPSIS
Site Recovery Remove Recovery Plan Test
#>
function Test-RecoveryPlanJob
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $RP = Get-AsrRecoveryPlan -Name $RecoveryPlanName
    $RecoveryFabric = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $RecoveryFabricName

    $RecoveryNetwork = Get-AzureRmRecoveryServicesAsrNetwork -Fabric $RecoveryFabric | where { $_.FriendlyName -eq $RecoveryNetworkFriendlyName}

    $currentJob = Start-ASRTestFailoverJob -RecoveryPlan $RP -Direction PrimaryToRecovery -VMNetwork $RecoveryNetwork
    WaitForJobCompletion -JobId $currentJob.Name
    $currentJob = Start-ASRTestFailoverCleanupJob -RecoveryPlan $RP
    WaitForJobCompletion -JobId $currentJob.Name

    $currentJob = Start-ASRTestFailoverJob -RecoveryPlan $RP -Direction PrimaryToRecovery
    WaitForJobCompletion -JobId $currentJob.Name
    $currentJob = Start-ASRTestFailoverCleanupJob -RecoveryPlan $RP
    WaitForJobCompletion -JobId $currentJob.Name

    $currentJob = Start-ASRPlannedFailoverJob -RecoveryPlan $RP -Direction PrimaryToRecovery
    WaitForJobCompletion -JobId $currentJob.Name 

    $currentJob = Start-AsrCommitFailoverJob -RecoveryPlan $RP
    $currentJob
    WaitForJobCompletion -JobId $currentJob.Name

    $currentJob = Update-AsrProtectionDirection -RecoveryPlan $RP -Direction RecoveryToPrimary 
    $currentJob
    WaitForJobCompletion -JobId $currentJob.Name
    
    #timeout 1200

    $currentJob = Start-AsrUnPlannedFailoverJob -RecoveryPlan $RP -Direction RecoveryToPrimary
    $currentJob
    WaitForJobCompletion -JobId $currentJob.Name

    $currentJob = Start-AsrCommitFailoverJob -RecoveryPlan $RP
    $currentJob
    WaitForJobCompletion -JobId $currentJob.Name 
    #WaitForJobCompletion -JobId $Job.Name
}
<#
.SYNOPSIS
Site Recovery Remove Recovery Plan Test
#>
function Test-SiteRecoveryRemoveRecoveryPlan
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $RP = Get-AzureRmRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName
    $Job = Remove-AzureRmRecoveryServicesAsrRecoveryPlan -RecoveryPlan $RP
    #WaitForJobCompletion -JobId $Job.Name
}
