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

$JobQueryWaitTimeInSeconds = 30
$StorageAccountID = "/subscriptions/c183865e-6077-46f2-a3b1-deb0f4f4650a/resourceGroups/siterecoveryprod1/providers/Microsoft.Storage/storageAccounts/storavrai"
$AzureNetworkID = "/subscriptions/c183865e-6077-46f2-a3b1-deb0f4f4650a/resourceGroups/siterecoveryProd1/providers/Microsoft.Network/virtualNetworks/vnetavrai"
$RecoveryResourceGroupID = "/subscriptions/c183865e-6077-46f2-a3b1-deb0f4f4650a/resourceGroups/siterecoveryprod1"
$ResourceGroupName = "siterecoveryprod1"
$VaultNameToBeCreated = "tempVault"
$VaultLocationToBeCreated = "westus"
$VaultName = "b2aRSvaultprod17012017"
$FabricNameToBeCreated = "ReleaseFabric"
$PrimaryFabricName = "CP-B3L30108-01.ntdev.corp.microsoft.com"
$PolicyName = "Policy1"
$PrimaryProtectionContainerName = "E2AClP25"
$ProtectionContainerMappingName = "E2AClP25mapping"
$PrimaryNetworkFriendlyName = "corp"
$NetworkMappingName = "corpmap"
$VMName = "E2AVMP25"
$RecoveryPlanName = "RPSwag1"

# Enumerate vaults and set Azure Recovery Services Vault Settings
$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $ResourceGroupName -Name $VaultName
Assert-NotNull($vault)
Assert-True { $vault.Count -eq 1 }
Assert-NotNull($vault.Name)
Assert-NotNull($vault.ID)
Set-AzureRmSiteRecoveryVaultSettings -ARSVault $vault

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
        [int] $JobQueryWaitTimeInSeconds = 60
        )
        $isJobLeftForProcessing = $true;
        do
        {
            $Job = Get-AzureRMSiteRecoveryJob -Name $JobId
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
		        Start-Sleep -Seconds $JobQueryWaitTimeInSeconds
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
function WaitForIRCompletion
{ 
	param(
        [PSObject] $VM,
        [int] $JobQueryWaitTimeInSeconds = 60
        )
        $isProcessingLeft = $true
        $IRjobs = $null

        do
        {
            $IRjobs = Get-AzureRMSiteRecoveryJob -TargetObjectId $VM.Name | Sort-Object StartTime -Descending | select -First 5 | Where-Object{$_.JobType -eq "IrCompletion"}
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
		        Start-Sleep -Seconds $JobQueryWaitTimeInSeconds
	        }
        }While($isProcessingLeft)

        $IRjobs
        WaitForJobCompletion -JobId $IRjobs[0].Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds
}
<#
.SYNOPSIS
Site Recovery Enumeration Tests
#>
function Test-SiteRecoveryEnumerationTests
{
	# Enumerate Vaults
	$vaults = Get-AzureRmSiteRecoveryVault
	Assert-True { $vaults.Count -gt 0 }
	Assert-NotNull($vaults)
	foreach($vault in $vaults)
	{
		Assert-NotNull($vault.Name)
		Assert-NotNull($vault.ID)
	}

	# Enumerate Recovery Services Providers
	$rsps = Get-AzureRmSiteRecoveryFabric | Get-AzureRmSiteRecoveryServicesProvider
	Assert-True { $rsps.Count -gt 0 }
	Assert-NotNull($rsps)
	foreach($rsp in $rsps)
	{
		Assert-NotNull($rsp.Name)
		Assert-NotNull($rsp.ID)
	}

	# Enumerate Protection Containers
	$protectionContainers = Get-AzureRmSiteRecoveryFabric | Get-AzureRmSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)
	}
}

<#
.SYNOPSIS
Site Recovery Create Policy Test
#>
function Test-SiteRecoveryCreatePolicy
{
	# Create profile
	$Job = New-AzureRMSiteRecoveryPolicy -Name $PolicyName -ReplicationProvider HyperVReplicaAzure -ReplicationFrequencyInSeconds 30 -RecoveryPoints 1 -ApplicationConsistentSnapshotFrequencyInHours 0 -Encryption Disable -RecoveryAzureStorageAccountId $StorageAccountID 
	# WaitForJobCompletion -JobId $Job.Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds

	# Get a profile created (with name ppAzure)
	$Policy = Get-AzureRmSiteRecoveryPolicy -Name $PolicyName
	Assert-True { $Policy.Count -gt 0 }
	Assert-NotNull($Policy)
}

<#
.SYNOPSIS
Site Recovery remove Policy Test
#>
function Test-SiteRecoveryRemovePolicy
{
	# Get a policy created in previous test
	$Policy = Get-AzureRmSiteRecoveryPolicy -Name $PolicyName
	Assert-True { $Policy.Count -gt 0 }
	Assert-NotNull($Policy)

	# Delete the profile
	$Job = Remove-AzureRmSiteRecoveryPolicy -Policy $Policy
	# WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery new protection container mapping test
#>
function Test-CreateProtectionContainerMapping
{
	# Get the primary container and policy
	$Policy = Get-AzureRmSiteRecoveryPolicy -Name $PolicyName;
	$PrimaryProtectionContainer = Get-AzureRmSiteRecoveryFabric | Get-AzureRMSiteRecoveryProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	# Associate the profile
	$Job = New-AzureRmSiteRecoveryProtectionContainerMapping -Name $ProtectionContainerMappingName -Policy $Policy -PrimaryProtectionContainer $PrimaryProtectionContainer
	WaitForJobCompletion -JobId $Job.Name

	# Get protection conatiner mapping
	$ProtectionContainerMapping = Get-AzureRmSiteRecoveryProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer
	Assert-NotNull($ProtectionContainerMapping)
}


<#
.SYNOPSIS
Site Recovery remove protection container mapping test
#>
function Test-RemoveProtectionContainerMapping
{
	# Get the primary container
	$PrimaryProtectionContainer = Get-AzureRmSiteRecoveryFabric | Get-AzureRMSiteRecoveryProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	# Get protection conatiner mapping
	$ProtectionContainerMapping = Get-AzureRmSiteRecoveryProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer

	# Remove protection conatiner mapping
	$Job = Remove-AzureRmSiteRecoveryProtectionContainerMapping -ProtectionContainerMapping $ProtectionContainerMapping
	WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery Enable protection Test
#>
function Test-SiteRecoveryEnableDR
{
	# Get the primary container
	$PrimaryProtectionContainer = Get-AzureRmSiteRecoveryFabric | Get-AzureRMSiteRecoveryProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	# Get protection container mapping
	$ProtectionContainerMapping = Get-AzureRmSiteRecoveryProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer

	# Get protectable item
	$VM = Get-AzureRmSiteRecoveryProtectableItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer  

	# EnableDR
	$Job = New-AzureRmSiteRecoveryReplicationProtectedItem -ProtectableItem $VM -Name $VM.Name -ProtectionContainerMapping $ProtectionContainerMapping -RecoveryAzureStorageAccountId $StorageAccountID -RecoveryResourceGroupId $RecoveryResourceGroupID
	WaitForJobCompletion -JobId $Job.Name
	WaitForIRCompletion -VM $VM 
}

<#
.SYNOPSIS
Site Recovery Disable protection Test
#>
function Test-SiteRecoveryDisableDR
{
	# Get the primary container
	$PrimaryProtectionContainer = Get-AzureRmSiteRecoveryFabric | Get-AzureRMSiteRecoveryProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	# Get protected item
	$VM = Get-AzureRmSiteRecoveryReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer  

	# DisableDR
	$Job = Remove-AzureRmSiteRecoveryReplicationProtectedItem -ReplicationProtectedItem $VM
	WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery Create Recovery Plan Test
#>
function Test-SiteRecoveryCreateRecoveryPlan
{
	# Get the primary fabric and container
	$PrimaryFabric = Get-AzureRmSiteRecoveryFabric -FriendlyName $PrimaryFabricName
	$PrimaryProtectionContainer = Get-AzureRMSiteRecoveryProtectionContainer -FriendlyName $PrimaryProtectionContainerName -Fabric $PrimaryFabric
	$VM = Get-AzureRmSiteRecoveryReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer

	$Job = New-AzureRmSiteRecoveryRecoveryPlan -Name $RecoveryPlanName -PrimaryFabric $PrimaryFabric -Azure -FailoverDeploymentModel ResourceManager -ReplicationProtectedItem $VM
	WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery Enumerate Recovery Plan Test
#>
function Test-SiteRecoveryEnumerateRecoveryPlan
{
	$RP = Get-AzureRmSiteRecoveryRecoveryPlan -Name $RecoveryPlanName
	Assert-NotNull($RP)
	Assert-True { $RP.Count -gt 0 }
}

<#
.SYNOPSIS
Site Recovery Remove Recovery Plan Test
#>
function Test-SiteRecoveryRemoveRecoveryPlan
{
	$RP = Get-AzureRmSiteRecoveryRecoveryPlan -Name $RecoveryPlanName
	$Job = Remove-AzureRmSiteRecoveryRecoveryPlan -RecoveryPlan $RP
	WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery Vault CRUD Tests
#>
function Test-SiteRecoveryVaultCRUDTests
{
	# Create vault
	$vaultCreationResponse = New-AzureRmRecoveryServicesVault -Name $VaultNameToBeCreated -ResourceGroupName $ResourceGroupName -Location $VaultLocationToBeCreated
	Assert-NotNull($vaultCreationResponse.Name)
	Assert-NotNull($vaultCreationResponse.ID)
	Assert-NotNull($vaultCreationResponse.Type)

	# Enumerate Vaults
	$vaults = Get-AzureRmRecoveryServicesVault
	Assert-True { $vaults.Count -gt 0 }
	Assert-NotNull($vaults)
	foreach($vault in $vaults)
	{
		Assert-NotNull($vault.Name)
		Assert-NotNull($vault.ID)
		Assert-NotNull($vault.Type)
	}

	# Get the created vault
	$vaultToBeRemoved = Get-AzureRmRecoveryServicesVault -ResourceGroupName $ResourceGroupName -Name $VaultNameToBeCreated
	Assert-NotNull($vaultToBeRemoved.Name)
	Assert-NotNull($vaultToBeRemoved.ID)
	Assert-NotNull($vaultToBeRemoved.Type)

	# Remove Vault
	Remove-AzureRmRecoveryServicesVault -Vault $vaultToBeRemoved
	$vaults = Get-AzureRmRecoveryServicesVault -ResourceGroupName $ResourceGroupName -Name $VaultNameToBeCreated
	Assert-True { $vaults.Count -eq 0 }
}


<#
.SYNOPSIS
Site Recovery Fabric Tests New model
#>
function Test-SiteRecoveryFabricTest
{
	# Create Fabric
	$Job = New-AzureRmSiteRecoveryFabric -Name $FabricNameToBeCreated -Type HyperVSite
	Assert-NotNull($Job)

	# Enumerate Fabrics
	$fabrics =  Get-AzureRmSiteRecoveryFabric 
	Assert-True { $fabrics.Count -gt 0 }
	Assert-NotNull($fabrics)
	foreach($fabric in $fabrics)
	{
		Assert-NotNull($fabrics.Name)
		Assert-NotNull($fabrics.ID)
	}

	# Enumerate specific Fabric
	$fabric =  Get-AzureRmSiteRecoveryFabric -Name $FabricNameToBeCreated
	Assert-NotNull($fabric)
	Assert-NotNull($fabrics.Name)
	Assert-NotNull($fabrics.ID)

	# Remove specific fabric
	$Job = Remove-AzureRmSiteRecoveryFabric -Fabric $fabric
	Assert-NotNull($Job)
	# WaitForJobCompletion -JobId $Job.Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds
	$fabric =  Get-AzureRmSiteRecoveryFabric | Where-Object {$_.Name -eq $FabricNameToBeCreated }
	Assert-Null($fabric)
}


<#
.SYNOPSIS
Site Recovery New model End to End
#>
function Test-SiteRecoveryNewModelE2ETest
{
	# Enumerate Fabrics
	$fabrics =  Get-AzureRmSiteRecoveryFabric 
	Assert-True { $fabrics.Count -gt 0 }
	Assert-NotNull($fabrics)
	foreach($fabric in $fabrics)
	{
		Assert-NotNull($fabrics.Name)
		Assert-NotNull($fabrics.ID)
	}

	# Enumerate RSPs
	$rsps = Get-AzureRmSiteRecoveryFabric | Get-AzureRmSiteRecoveryServicesProvider
	Assert-True { $rsps.Count -gt 0 }
	Assert-NotNull($rsps)
	foreach($rsp in $rsps)
	{
		Assert-NotNull($rsp.Name)
	}

	# Create Policy
	$Job = New-AzureRMSiteRecoveryPolicy -Name $PolicyName -ReplicationProvider HyperVReplicaAzure -ReplicationFrequencyInSeconds 30 -RecoveryPoints 1 -ApplicationConsistentSnapshotFrequencyInHours 0 -Encryption Disable -RecoveryAzureStorageAccountId $StorageAccountID 
	WaitForJobCompletion -JobId $Job.Name

    $Policy = Get-AzureRMSiteRecoveryPolicy -Name $PolicyName
	Assert-NotNull($Policy)
	Assert-NotNull($Policy.Name)

	# Get conatiners
	$PrimaryProtectionContainer = Get-AzureRmSiteRecoveryFabric | Get-AzureRMSiteRecoveryProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }
	Assert-NotNull($PrimaryProtectionContainer)
	Assert-NotNull($PrimaryProtectionContainer.Name)

	# Create new Conatiner mapping 
	$Job = New-AzureRmSiteRecoveryProtectionContainerMapping -Name $ProtectionContainerMappingName -Policy $Policy -PrimaryProtectionContainer $PrimaryProtectionContainer
	WaitForJobCompletion -JobId $Job.Name

	# Get container mapping
	$ProtectionContainerMapping = Get-AzureRmSiteRecoveryProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer
	Assert-NotNull($ProtectionContainerMapping)
	Assert-NotNull($ProtectionContainerMapping.Name)

	# Get primary network
	$PrimaryNetwork = Get-AzureRmSiteRecoveryNetwork -Fabric $PrimaryFabric | where { $_.FriendlyName -eq "$PrimaryNetworkFriendlyName"}

	# Create network mapping
    $Job = New-AzureRmSiteRecoveryNetworkMapping -Name $NetworkMappingName -PrimaryNetwork $PrimaryNetwork -AzureVMNetworkId $AzureNetworkID
	WaitForJobCompletion -JobId $Job.Name

	# Get network mapping
	$NetworkMapping = Get-AzureRmSiteRecoveryNetworkMapping -PrimaryFabric $PrimaryFabric -Azure | where { $_.Name -eq $NetworkMappingName }

	# Get protectable item
	$protectable = Get-AzureRmSiteRecoveryProtectableItem -ProtectionContainer $PrimaryProtectionContainer -FriendlyName $VMName
	Assert-NotNull($protectable)
	Assert-NotNull($protectable.Name)

	# New replication protected item
	$Job = New-AzureRmSiteRecoveryReplicationProtectedItem -ProtectableItem $protectable -Name $protectable.Name -ProtectionContainerMapping $ProtectionContainerMapping -RecoveryAzureStorageAccountId $StorageAccountID -RecoveryResourceGroupId $RecoveryResourceGroupID
	WaitForJobCompletion -JobId $Job.Name
	WaitForIRCompletion -VM $protectable 
	Assert-NotNull($Job)

	# Get replication protected item
	$protected = Get-AzureRmSiteRecoveryReplicationProtectedItem -ProtectionContainer $PrimaryProtectionContainer -Name $protectable.Name
	Assert-NotNull($protected)
	Assert-NotNull($protected.Name)

	# Remove protected item
	$Job = Remove-AzureRmSiteRecoveryReplicationProtectedItem -ReplicationProtectedItem $protected
	WaitForJobCompletion -JobId $Job.Name
	$protected = Get-AzureRmSiteRecoveryReplicationProtectedItem -ProtectionContainer $PrimaryProtectionContainer | Where-Object {$_.Name -eq $protectable.Name} 
	Assert-Null($protected)

	# Remove network mapping
	$Job = Remove-AzureRmSiteRecoveryNetworkMapping -NetworkMapping $NetworkMapping
	WaitForJobCompletion -JobId $Job.Name

	# Remove conatiner mapping
	$Job = Remove-AzureRmSiteRecoveryProtectionContainerMapping -ProtectionContainerMapping $ProtectionContainerMapping
	WaitForJobCompletion -JobId $Job.Name
	$ProtectionContainerMapping = Get-AzureRmSiteRecoveryProtectionContainerMapping -ProtectionContainer $PrimaryProtectionContainer | Where-Object {$_.Name -eq $ProtectionContainerMappingName}
	Assert-Null($ProtectionContainerMapping)

	# Remove Policy
	$Job = Remove-AzureRMSiteRecoveryPolicy -Policy $Policy
	$Policy = Get-AzureRMSiteRecoveryPolicy | Where-Object {$_.Name -eq $PolicyName}
	Assert-Null($Policy)
}
