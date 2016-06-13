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

########################## Recovery Services Tests #############################

# Followings are the switch to control validation which can be tuned from outside later to control the test result in case of some product misbehaviour.

$Validate_EnableProtection_JobSucceeded = $true;
$Validate_DisableProtection_JobSucceeded = $true;

$Validate_PFO_JobSucceeded = $true;
$Validate_Commit_PFO_JobSucceeded = $true;
$Validate_Commit_Failback_JobSucceeded = $true;
$Validate_EnableProtection_WaitForCanFailover = $true;
$Validate_RRAfterFailback_JobSucceeded = $true;
$Validate_Failback_JobSucceeded = $true;
$Validate_TFO_JobSucceeded = $true;
$Validate_TFO_JobSuspended = $true;
$Validate_UFO_JobSucceeded = $true;
$Validate_TFO_JobSuspended = $true;
$Validate_PFORP_JobSucceeded = $true;
$Validate_PFOFailbackRP_JobSucceeded = $true;
$Validate_ProfileDissociation_JobSucceeded = $true;
$Validate_ProfileAssociation_JobSucceeded = $true;

#Test-EnableProtection 'E:\d\E2E_SKVault_Wednesday,January28,2015.VaultCredentials'

<#
.SYNOPSIS
Recovery Services DeleteAndDissociate Tests
#>
function Test-E2E_DeleteAndDissociate
{
	param([string] $vaultSettingsFilePath)
	#$vaultSettingsFilePath = $vaultFile;

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.Role -eq "Primary")
		{
	        foreach($profile in $protectionContainer.AvailableProtectionProfiles)
	        {        
                if ($profile.ReplicationProvider -eq "HyperVReplica")
                {
                    if ($profile.HyperVReplicaProviderSettingsObject.CanDissociate -eq $false)
					{
						continue;
					}

                    foreach ($association in $profile.HyperVReplicaProviderSettingsObject.AssociationDetail)
                    {
                        if ($association.AssociationStatus -eq "Paired")
                        {
                            # We have got the paired profile. Fire delete and dissociate
                            $pcPri = Get-AzureSiteRecoveryProtectionContainer -Id $association.PrimaryProtectionContainerId
                            $pcRec = Get-AzureSiteRecoveryProtectionContainer -Id $association.RecoveryProtectionContainerId
                            $job = Start-AzureSiteRecoveryProtectionProfileDissociationJob -PrimaryProtectionContainer $pcPri -RecoveryProtectionContainer $pcRec -ProtectionProfile $profile

							# Validate_ProfileDissociation_JobSucceeded
							if ($Validate_ProfileDissociation_JobSucceeded -eq $true)
							{
								WaitForJobCompletion -JobId $job.ID -NumOfSecondsToWait 600
								$job = Get-AzureSiteRecoveryJob -Id $job.ID
								Assert-True { $job.State -eq "Succeeded" }
							}

                            return;
                        }
                    }
                }
            }
        }
    }

    Assert-NotNull($job) "No PC found for E2E_DeleteAndDissociate"
}


<#
.SYNOPSIS
Recovery Services E2E_CreateAndAssociate Tests
#>
function Test-E2E_CreateAndAssociate
{
	param([string] $vaultSettingsFilePath)
	#$vaultSettingsFilePath = $vaultFile;

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
    $priPC = $null
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)
		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.Role -eq "")
		{
            if ($priPC -eq $null)
            {
                $priPC = $protectionContainer;
                continue;
            }

            # we have got second pc as well create profile and associate
            $pp = New-AzureSiteRecoveryProtectionProfileObject -ReplicationProvider HyperVReplica -ReplicationMethod Online -ReplicationFrequencyInSeconds 300 -RecoveryPoints 1 -ApplicationConsistentSnapshotFrequencyInHours 1 -CompressionEnabled -ReplicationPort 8083 -Authentication Kerberos -AllowReplicaDeletion

            $job = Start-AzureSiteRecoveryProtectionProfileAssociationJob -ProtectionProfile $pp -PrimaryProtectionContainer $priPC -RecoveryProtectionContainer $protectionContainer

			# Validate_ProfileAssociation_JobSucceeded
			if ($Validate_ProfileAssociation_JobSucceeded -eq $true)
			{
				WaitForJobCompletion -JobId $job.ID -NumOfSecondsToWait 600
                $job = Get-AzureSiteRecoveryJob -Id $job.ID
				Assert-True { $job.State -eq "Succeeded" }
			}

            return;
        }
    }

    Assert-NotNull($job) "No PC found for E2E_CreateAndAssociate"
}

<#
.SYNOPSIS
Recovery Services Enumeration Tests
#>
function Test-RecoveryServicesEnumerationTests
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate Protection Containers
	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.ConfigurationStatus -eq "Configured")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
			}
		}
	}
}

<#
.SYNOPSIS
Recovery Services Protection Tests
#>
function Test-RecoveryServicesProtectionTests
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enable protection for an un protected Protection Entity and 
	# Disable protection for a protected Protection Entity
	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.ConfigurationStatus -eq "Configured")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
				if ($protectionEntity.Protected)
				{
					Set-AzureSiteRecoveryProtectionEntity -ProtectionEntity $protectionEntity -Protection "Enable" -Force
					Update-AzureSiteRecoveryProtectionEntity -ProtectionEntity $protectionEntity
				}
				else
				{
					Set-AzureSiteRecoveryProtectionEntity -ProtectionEntity $protectionEntity -Protection "Disable" -Force
				}
			}
		}
	}
}

<#
.SYNOPSIS
Recovery Services Storage mapping tests and validation
#>
function Test-StorageMapping
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate Storages
	$storages = Get-AzureSiteRecoveryStorage -Server $servers[0]
	Assert-NotNull($storages)
	Assert-True { $storages.Count -gt 0 }
	foreach($storage in $storages)
	{
		Assert-NotNull($storage.Name)
		Assert-NotNull($storage.ID)
	}

	# Enumerate StorageMappings
	$storageMappings = Get-AzureSiteRecoveryStorageMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-True { $storageMappings.Count -eq 0 }

	# Create StorageMapping
	$job = New-AzureSiteRecoveryStorageMapping -PrimaryStorage $storages[0] -RecoveryStorage $storages[1]
	WaitForJobCompletion -JobId $job.ID

	# Enumerate StorageMappings
	$storageMappings = Get-AzureSiteRecoveryStorageMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-NotNull($storageMappings)
	Assert-True { $storageMappings.Count -eq 1 }
	Assert-NotNull($storageMappings[0].PrimaryServerId)
	Assert-NotNull($storageMappings[0].PrimaryStorageId)
	Assert-NotNull($storageMappings[0].RecoveryServerId)
	Assert-NotNull($storageMappings[0].RecoveryStorageId)
}

<#
.SYNOPSIS
Recovery Services Storage unmapping tests and validation
#>
function Test-StorageUnMapping
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate StorageMappings
	$storageMappings = Get-AzureSiteRecoveryStorageMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-NotNull($storageMappings)
	Assert-True { $storageMappings.Count -eq 1 }
	Assert-NotNull($storageMappings[0].PrimaryServerId)
	Assert-NotNull($storageMappings[0].PrimaryStorageId)
	Assert-NotNull($storageMappings[0].RecoveryServerId)
	Assert-NotNull($storageMappings[0].RecoveryStorageId)

	# Remove StorageMapping
	$job = Remove-AzureSiteRecoveryStorageMapping -StorageMapping $storageMappings[0]
	WaitForJobCompletion -JobId $job.ID

	# Enumerate StorageMappings
	$storageMappings = Get-AzureSiteRecoveryStorageMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-True { $storageMappings.Count -eq 0 }
}

<#
.SYNOPSIS
Recovery Services Network mapping tests and validation
#>
function Test-NetworkMapping
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate Networks
	$networks = Get-AzureSiteRecoveryNetwork -Server $servers[0]
	Assert-NotNull($networks)
	Assert-True { $networks.Count -gt 0 }
	foreach($network in $networks)
	{
		Assert-NotNull($network.Name)
		Assert-NotNull($network.ID)
	}

	# Enumerate NetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-True { $networkMappings.Count -eq 0 }

	# Create NetworkMapping
	$job = New-AzureSiteRecoveryNetworkMapping -PrimaryNetwork $networks[0] -RecoveryNetwork $networks[1]
	WaitForJobCompletion -JobId $job.ID

	# Enumerate NetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-NotNull($networkMappings)
	Assert-True { $networkMappings.Count -eq 1 }
	Assert-NotNull($networkMappings[0].PrimaryServerId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkName)
	Assert-NotNull($networkMappings[0].RecoveryServerId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkName)
}

<#
.SYNOPSIS
Recovery Services Azure Network mapping tests and validation
#>
function Test-AzureNetworkMapping
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate Networks
	$networks = Get-AzureSiteRecoveryNetwork -Server $servers[0]
	Assert-NotNull($networks)
	Assert-True { $networks.Count -gt 0 }
	foreach($network in $networks)
	{
		Assert-NotNull($network.Name)
		Assert-NotNull($network.ID)
	}

	<#
	# Enumerate Azure VM Networks
	$azureVmNetworks = Get-AzureVNetSite
	Assert-NotNull($azureVmNetworks)
	Assert-True { $azureVmNetworks.Count -gt 0 }
	#>

	# Enumerate AzureNetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -Azure
	Assert-True { $networkMappings.Count -eq 0 }

	# Create AzureNetworkMapping
	# $subscription = Get-AzureSubscription -Current

	# TODO (sriramvu): There are few dependency issues on using Get-AzureVNetSite to get list of Azure VM Networks, will update the test.
	# Should setup NetworkManagementClient along with our two mgmt clients in RecoveryServicesTestsBase.cs
	# $job = New-AzureSiteRecoveryNetworkMapping -PrimaryNetwork $networks[0] -AzureSubscriptionId $subscription.SubscriptionId -AzureVMNetworkId $azureVmNetworks[0].Id
	# $job = New-AzureSiteRecoveryNetworkMapping -PrimaryNetwork $networks[0] -AzureSubscriptionId 62633f66-ce59-4114-b65d-a50beb5bd8d8 -AzureVMNetworkId "1d0ecfad-ac09-4222-b46f-2ab74839fe7e" # OneBox details
	$job = New-AzureSiteRecoveryNetworkMapping -PrimaryNetwork $networks[0] -AzureSubscriptionId a5aa5997-33e5-46cc-8ab8-8bd89b76b7ba -AzureVMNetworkId ecb3a462-664f-4f57-873e-d09b5925e1a1 # POD details
	WaitForJobCompletion -JobId $job.ID

	# Enumerate NetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -Azure
	Assert-NotNull($networkMappings)
	Assert-True { $networkMappings.Count -eq 1 }
	Assert-NotNull($networkMappings[0].PrimaryServerId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkName)
	Assert-NotNull($networkMappings[0].RecoveryServerId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkName)
}

<#
.SYNOPSIS
Recovery Services Network unmapping tests and validation
#>
function Test-NetworkUnMapping
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate NetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-NotNull($networkMappings)
	Assert-True { $networkMappings.Count -eq 1 }
	Assert-NotNull($networkMappings[0].PrimaryServerId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkName)
	Assert-NotNull($networkMappings[0].RecoveryServerId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkName)

	# Remove NetworkMapping
	$job = Remove-AzureSiteRecoveryNetworkMapping -NetworkMapping $networkMappings[0]
	WaitForJobCompletion -JobId $job.ID

	# Enumerate NetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-True { $networkMappings.Count -eq 0 }
}

<#
.SYNOPSIS
Recovery Services Azure Network unmapping tests and validation
#>
function Test-AzureNetworkUnMapping
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate Azure NetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -Azure
	Assert-NotNull($networkMappings)
	Assert-True { $networkMappings.Count -eq 1 }
	Assert-NotNull($networkMappings[0].PrimaryServerId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkName)
	Assert-NotNull($networkMappings[0].RecoveryServerId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkName)

	# Remove Azure NetworkMapping
	$job = Remove-AzureSiteRecoveryNetworkMapping -NetworkMapping $networkMappings[0]
	WaitForJobCompletion -JobId $job.ID

	# Enumerate Azure NetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -Azure
	Assert-True { $networkMappings.Count -eq 0 }
}

<#
.SYNOPSIS
Recovery Services Failback Tests
#>
function Test-Failback
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.Role -eq "Primary")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
				if ($protectionEntity.CanFailover -eq $true -and $protectionEntity.ActiveLocation -eq "Recovery")
				{
					$job = Start-AzureSiteRecoveryPlannedFailoverJob -Direction RecoveryToPrimary -ProtectionEntity $protectionEntity -WaitForCompletion
					
                    # Validate_Failback_JobSucceeded
                    if ($Validate_Failback_JobSucceeded -eq $true)
                    {
                        $job = Get-AzureSiteRecoveryJob -Id $job.ID
                        Assert-True { $job.State -eq "Succeeded" }
                    }

                    return;
				}
			}
		}
	}

    Assert-NotNull($job) "No VM found for failback"
}


<#
.SYNOPSIS
Recovery Services RRAfterFailback Tests
#>
function Test-RRAfterFailback
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.Role -eq "Primary")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
				if ($protectionEntity.CanReverseReplicate -eq $true -and $protectionEntity.ActiveLocation -eq "Recovery")
				{
					$job = Update-AzureSiteRecoveryProtectionDirection -ProtectionEntity $protectionEntity -Direction PrimaryToRecovery -WaitForCompletion
					
                    # Validate_PFO_JobSucceeded
                    if ($Validate_RRAfterFailback_JobSucceeded -eq $true)
                    {
                        $job = Get-AzureSiteRecoveryJob -Id $job.ID
                        Assert-True { $job.State -eq "Succeeded" }
                    }

                    return;
				}
			}
		}
	}

    Assert-NotNull($job) "No VM found for RRAfterFailback";
}


<#
.SYNOPSIS
Recovery Services Commit_PFO Tests
#>
function Test-RRAfterFailover
{
	param([string] $vaultSettingsFilePath)
	#$vaultSettingsFilePath = $vaultFile;

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.Role -eq "Primary")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
				if ($protectionEntity.CanReverseReplicate -eq $true)
				{
					$job = Update-AzureSiteRecoveryProtectionDirection -ProtectionEntity $protectionEntity -Direction RecoveryToPrimary -WaitForCompletion
					
                    # Validate_PFO_JobSucceeded
                    if ($Validate_Commit_PFO_JobSucceeded -eq $true)
                    {
                        $job = Get-AzureSiteRecoveryJob -Id $job.ID
                        Assert-True { $job.State -eq "Succeeded" }
                    }

                    # Validate_EnableProtection_WaitForCanFailover
                    if ($Validate_EnableProtection_WaitForCanFailover -eq $true)
                    {
                        WaitForCanFailover $protectionEntity.ProtectionContainerId $protectionEntity.ID 
                    }

                    return;
				}
			}
		}
	}

    Assert("No VM found for RR");
}

<#
.SYNOPSIS
Recovery Services Commit_PFO Tests
#>
function Test-CommitPFO
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.Role -eq "Primary")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
				if ($protectionEntity.CanCommit -eq $true)
				{
					$job = Start-AzureSiteRecoveryCommitFailoverJob -ProtectionEntity $protectionEntity  -Direction PrimaryToRecovery -WaitForCompletion
					
                    # Validate_PFO_JobSucceeded
                    if ($Validate_Commit_PFO_JobSucceeded -eq $true)
                    {
                        $job = Get-AzureSiteRecoveryJob -Id $job.ID
                        Assert-True { $job.State -eq "Succeeded" }
                    }

                    return;
				}
			}
		}
	}

    Assert-NotNull($job) "No VM found for Commit_PFO"
}


<#
.SYNOPSIS
Recovery Services PFO Tests
#>
function Test-PFO
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.Role -eq "Primary")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
				if ($protectionEntity.CanFailover -eq $true)
				{
					$job = Start-AzureSiteRecoveryPlannedFailoverJob -Direction PrimaryToRecovery -ProtectionEntity $protectionEntity -WaitForCompletion
					
                    # Validate_PFO_JobSucceeded
                    if ($Validate_PFO_JobSucceeded -eq $true)
                    {
                        $job = Get-AzureSiteRecoveryJob -Id $job.ID
                        Assert-True { $job.State -eq "Succeeded" }
                    }
                    
                    return;
				}
			}
		}
	}

    Assert-NotNull($job) "No VM found for PFO"
}

<#
.SYNOPSIS
Recovery Services PFORP Tests
#>
function Test-PFORP ($vaultSettingsFilePath)
{
	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$rps = Get-AzureSiteRecoveryRecoveryPlan ; $rps
	Assert-NotNull($rps)
	Assert-True { $rps.Count -gt 0 }
	foreach($rp in $rps)
	{
		Assert-NotNull($rps.Name)
		Assert-NotNull($rps.ID)

		$job = Start-AzureSiteRecoveryPlannedFailoverJob -Direction PrimaryToRecovery -RecoveryPlan $rp -WaitForCompletion
					
        # Validate_PFORP_JobSucceeded
        if ($Validate_PFORP_JobSucceeded -eq $true)
        {
            $job = Get-AzureSiteRecoveryJob -Id $job.ID
            Assert-True { $job.State -eq "Succeeded" }
        }

        return;
    }

    Assert("No RP found for PFO");
}


<#
.SYNOPSIS
Recovery Services TFORP Tests
#>
function Test-TFORP ($vaultSettingsFilePath)
{
	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$rps = Get-AzureSiteRecoveryRecoveryPlan ; $rps
	Assert-NotNull($rps)
	Assert-True { $rps.Count -gt 0 }
	foreach($rp in $rps)
	{
		Assert-NotNull($rps.Name)
		Assert-NotNull($rps.ID)

		$job = Start-AzureSiteRecoveryTestFailoverJob -Direction PrimaryToRecovery -RecoveryPlan $rp -WaitForCompletion
					
        # Validate_PFORP_JobSucceeded
        if ($Validate_PFORP_JobSucceeded -eq $true)
        {
            $job = Get-AzureSiteRecoveryJob -Id $job.ID
            Assert-True { $job.State -eq "Succeeded" }
        }

        return;
    }

    Assert("No RP found for TFORP");
}

<#
.SYNOPSIS
Recovery Services UFORP Tests
#>
function Test-UFORP ($vaultSettingsFilePath)
{
	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$rps = Get-AzureSiteRecoveryRecoveryPlan ; $rps
	Assert-NotNull($rps)
	Assert-True { $rps.Count -gt 0 }
	foreach($rp in $rps)
	{
		Assert-NotNull($rps.Name)
		Assert-NotNull($rps.ID)

		$job = Start-AzureSiteRecoveryUnplannedFailoverJob -Direction PrimaryToRecovery -RecoveryPlan $rp -PrimaryAction $true -WaitForCompletion
					
        # Validate_UFORP_JobSucceeded
        if ($Validate_PFORP_JobSucceeded -eq $true)
        {
            $job = Get-AzureSiteRecoveryJob -Id $job.ID
            Assert-True { $job.State -eq "Succeeded" }
        }

        return;
    }

    Assert("No RP found for UFORP");
}

<#
.SYNOPSIS
Recovery Services FailbackRP Tests
#>
function Test-FailbackRP ($vaultSettingsFilePath)
{
	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$rps = Get-AzureSiteRecoveryRecoveryPlan ; $rps
	Assert-NotNull($rps)
	Assert-True { $rps.Count -gt 0 }
	foreach($rp in $rps)
	{
		Assert-NotNull($rps.Name)
		Assert-NotNull($rps.ID)

		$job = Start-AzureSiteRecoveryPlannedFailoverJob -Direction RecoveryToPrimary -RecoveryPlan $rp -WaitForCompletion
					
        # Validate_PFORP_JobSucceeded
        if ($Validate_PFOFailbackRP_JobSucceeded -eq $true)
        {
            $job = Get-AzureSiteRecoveryJob -Id $job.ID
            Assert-True { $job.State -eq "Succeeded" }
        }

        return;
    }

    Assert("No RP found for FailbackRP");
}
<#
.SYNOPSIS
Recovery Services RRRP Tests
#>
function Test-RRRP ($vaultSettingsFilePath)
{
	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$rps = Get-AzureSiteRecoveryRecoveryPlan ; $rps
	Assert-NotNull($rps)
	Assert-True { $rps.Count -gt 0 }
	foreach($rp in $rps)
	{
		Assert-NotNull($rps.Name)
		Assert-NotNull($rps.ID)

		$job = Update-AzureSiteRecoveryProtectionDirection -RecoveryPlan $rp  -Direction PrimaryToRecovery -WaitForCompletion
					
        # Validate_RRRP_JobSucceeded
        if ($Validate_RRRP_JobSucceeded -eq $true)
        {
            $job = Get-AzureSiteRecoveryJob -Id $job.ID
            Assert-True { $job.State -eq "Succeeded" }
        }

        return;
    }

    Assert("No RP found for RRRP");
}

<#
.SYNOPSIS
Recovery Services CommitRP Tests
#>
function Test-CommitRP ($vaultSettingsFilePath)
{
	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$rps = Get-AzureSiteRecoveryRecoveryPlan ; $rps
	Assert-NotNull($rps)
	Assert-True { $rps.Count -gt 0 }
	foreach($rp in $rps)
	{
		Assert-NotNull($rps.Name)
		Assert-NotNull($rps.ID)

		$job = Start-AzureSiteRecoveryCommitFailoverJob -RecoveryPlan $rp  -Direction PrimaryToRecovery -WaitForCompletion
					
        # Validate_PFORP_JobSucceeded
        if ($Validate_PFOFailbackRP_JobSucceeded -eq $true)
        {
            $job = Get-AzureSiteRecoveryJob -Id $job.ID
            Assert-True { $job.State -eq "Succeeded" }
        }

        return;
    }

    Assert("No RP found for CommitRP");
}

<#
.SYNOPSIS
Recovery Services FailbackRP Tests
#>
function Test-FailbackRP ($vaultSettingsFilePath)
{
	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$rps = Get-AzureSiteRecoveryRecoveryPlan ; $rps
	Assert-NotNull($rps)
	Assert-True { $rps.Count -gt 0 }
	foreach($rp in $rps)
	{
		Assert-NotNull($rps.Name)
		Assert-NotNull($rps.ID)

		$job = Start-AzureSiteRecoveryPlannedFailoverJob -Direction RecoveryToPrimary -RecoveryPlan $rp -WaitForCompletion
					
        # Validate_PFORP_JobSucceeded
        if ($Validate_PFOFailbackRP_JobSucceeded -eq $true)
        {
            $job = Get-AzureSiteRecoveryJob -Id $job.ID
            Assert-True { $job.State -eq "Succeeded" }
        }

        return;
    }

    Assert("No RP found for PFO");
}

<#
.SYNOPSIS
Recovery Services PFO Tests
#>
function Test-UFO
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.Role -eq "Primary")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
				if ($protectionEntity.CanFailover -eq $true)
				{
					$job = Start-AzureSiteRecoveryUnplannedFailoverJob -Direction PrimaryToRecovery -ProtectionEntity $protectionEntity -WaitForCompletion
					
                    # Validate_UFO_JobSucceeded
                    if ($Validate_UFO_JobSucceeded -eq $true)
                    {
                        $job = Get-AzureSiteRecoveryJob -Id $job.ID
                        Assert-True { $job.State -eq "Succeeded" }
                    }
                    
                    return;
				}
			}
		}
	}

    Assert-NotNull($job) "No VM found for UFO"
}


<#
.SYNOPSIS
Recovery Services TFO Tests
#>
function Test-TFO
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.Role -eq "Primary")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
				if ($protectionEntity.CanFailover -eq $true)
				{
					$job = Start-AzureSiteRecoveryTestFailoverJob -Direction PrimaryToRecovery -ProtectionEntity $protectionEntity -WaitForCompletion
					
                    # Validate_TFO_JobSucceeded
                    if ($Validate_TFO_JobSuspended -eq $true)
                    {
                        $job = Get-AzureSiteRecoveryJob -Id $job.ID
                        Assert-True { $job.State -eq "Suspended" }
                    }
                    
                    # Resume Job
                    Resume-AzureSiteRecoveryJob -Id $job.ID
                    if ($Validate_TFO_JobSucceeded -eq $true)
                    {
                        $job = Get-AzureSiteRecoveryJob -Id $job.ID
                        Assert-True { $job.State -eq "Succeeded" }
                    }

                    return;
				}
			}
		}
	}

    Assert-NotNull($job) "No VM found for TFO"
}

<#
.SYNOPSIS
Recovery Services Enable Protection Tests
#>
function Test-EnableProtection
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.Role -eq "Primary")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
				if ($protectionEntity.Protected -eq $false)
				{
					$job = Set-AzureSiteRecoveryProtectionEntity -ProtectionEntity $protectionEntity -Protection "Enable" -Force -ProtectionProfile $protectionContainer.AvailableProtectionProfiles[0] -WaitForCompletion
    				Assert-NotNull($job.State) 
	    			Assert-NotNull($job.ID) 
					
                    # Validate_EnableProtection_JobSucceeded
                    if ($Validate_EnableProtection_JobSucceeded -eq $true)
                    {
                        $job = Get-AzureSiteRecoveryJob -Id $job.ID
                        Assert-True { $job.State -eq "Succeeded" } "Job state is not not Succeeded. $job.State "
                    }

                    # Validate_EnableProtection_WaitForCanFailover
                    if ($Validate_EnableProtection_WaitForCanFailover -eq $true)
                    {
                        WaitForCanFailover $protectionEntity.ProtectionContainerId $protectionEntity.ID 
                    }

                    return;
				}
			}
		}
	}

    Assert-NotNull($job)  "No VM found for Enable Protection"
}

<#
.SYNOPSIS
Recovery Services Enable Protection Tests
#>
function Test-DisableProtection
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.Role -eq "Primary")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
                Write-Output "Checking PE"
                $protectionEntity
				if ($protectionEntity.Protected -eq $true)
				{
                    Write-Output "Disabling protection for PE: " + $protectionEntity.Name + " (" + $protectionEntity.ID + ")"
					$job = Set-AzureSiteRecoveryProtectionEntity -ProtectionEntity $protectionEntity -Protection "Disable" -Force -WaitForCompletion
                    Assert-NotNull($job);

                    # Validate_DisableProtection_JobSucceeded
                    if ($Validate_DisableProtection_JobSucceeded -eq $true)
                    {
                        $job = Get-AzureSiteRecoveryJob -Id $job.ID
                        Assert-True { $job.State -eq "Succeeded" }
                    }

                    return;				
                }
			}
		}
	}
    
    Assert-NotNull($job) "No VM found for Disable Protection"
}

<#
.SYNOPSIS
Recovery Services Enable Protection Tests
#>
function WaitForCanFailover
{
    param([string] $pcId, [string] $peId)
    $count = 20
	do
	{
		Wait-Seconds 5
		$pes = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainerId $pcId;

        $count = $count -1;

    	Assert-True { $count -gt 0 } "Job did not reached desired state within 5*$count seconds."

	} while(-not ($pes[0].CanFailover -eq $true))
}

<#
.SYNOPSIS
Wait for job completion
Usage:
	WaitForJobCompletion -JobId $job.ID
	WaitForJobCompletion -JobId $job.ID -NumOfSecondsToWait 10
#>
function WaitForJobCompletion
{
    param([string] $JobId, [Int] $NumOfSecondsToWait = 120)
	$endStateDescription = @('Succeeded','Failed','Cancelled','Suspended')

	$timeElapse = 0;
	$interval = 5;
	do
	{
		Wait-Seconds $interval
		$timeElapse = $timeElapse + $interval
		$job = Get-AzureSiteRecoveryJob -Id $JobId;
	} while((-not ($endStateDescription -ccontains $job.State)) -and ($timeElapse -lt $NumOfSecondsToWait))

	Assert-True { $endStateDescription -ccontains $job.State } "Job did not reached desired state within $NumOfSecondsToWait seconds."
}
