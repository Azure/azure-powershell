
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

function Create-RoleAssignments(
    [string]$objectId,
    [string]$saId) {

    $storageBlobDataContributorRoleDefinitionId = [System.Guid]::parse($RoleDefinitionIds.StorageBlobDataContributorId)
    $contributorRoleDefinitionId = [System.Guid]::parse($RoleDefinitionIds.ContributorId)
    $existingRoleAssignments = Get-AzRoleAssignment -ObjectId $objectId -Scope $saId -ErrorVariable notPresent -ErrorAction SilentlyContinue

    if (-not $existingRoleAssignments) {
        Write-Host "Creating role assignments for object" $objectId
        $output = New-AzRoleAssignment -ObjectId $objectId -Scope $saId -RoleDefinitionId $storageBlobDataContributorRoleDefinitionId
        $output = New-AzRoleAssignment -ObjectId $objectId -Scope $saId -RoleDefinitionId $contributorRoleDefinitionId
    }
}

<#
.Synopsis
Initialises the infrastructure for the migrate project.
.Description
The Initialize-AzMigrateReplicationInfrastructure cmdlet initialises the infrastructure for the migrate project.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/initialize-azmigratereplicationinfrastructure
#>
function Initialize-AzMigrateReplicationInfrastructure {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName = 'agentlessVMware', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    
    param(
        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Resource Group of the Azure Migrate Project in the current subscription.
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the name of the Azure Migrate project to be used for server migration.
        ${ProjectName},

        [Parameter(Mandatory)]
        [ValidateSet("agentlessVMware")]
        [ArgumentCompleter( { "agentlessVMware" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the server migration scenario for which the replication infrastructure needs to be initialized.
        ${Scenario},

        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the target Azure region for server migrations.
        ${TargetRegion},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Storage Account Id to be used for private endpoint scenario.
        ${CacheStorageAccountId},

        [Parameter()]
        [System.String]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        # Azure Subscription ID.
        ${SubscriptionId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        Import-Module Az.Resources
        Import-Module Az.Storage
        Import-Module Az.RecoveryServices
        Import-Module $PSScriptRoot\Helper\AzStackHCICommonSettings.ps1
        
        # Validate user specified target region
        $TargetRegion = $TargetRegion.ToLower()
        $allAvailableAzureLocations = Get-AzLocation
        $matchingLocationByLocationName = $allAvailableAzureLocations | Where-Object { $_.Location -eq $TargetRegion }
        $matchingLocationByDisplayName = $allAvailableAzureLocations | Where-Object { $_.DisplayName -eq $TargetRegion }
       
        if ($matchingLocationByLocationName) {
            $TargetRegion = $matchingLocationByLocationName.Location
        }
        elseif ($matchingLocationByDisplayName) {
            $TargetRegion = $matchingLocationByDisplayName.Location
        }
        elseif ($TargetRegion -match "euap") {
        }
        else {
            throw "Creation of resources required for replication failed due to invalid location. Run Get-AzLocation to verify the validity of the location and retry this step."
        }
       
        # Get/Set SubscriptionId
        if (($null -eq $SubscriptionId) -or ($SubscriptionId -eq "")) {
            $context = Get-AzContext
            $SubscriptionId = $context.Subscription.Id
            if (($null -eq $SubscriptionId) -or ($SubscriptionId -eq "")) {
                throw "Please login to Azure to select a subscription."
            }
        }
        else {
            Select-AzSubscription -SubscriptionId $SubscriptionId
        }
        $context = Get-AzContext
        Write-Host "Using Subscription Id: ", $SubscriptionId
        Write-Host "Selected Target Region: ", $TargetRegion
        
        $rg = Get-AzResourceGroup -Name $ResourceGroupName -ErrorVariable notPresent -ErrorAction SilentlyContinue
        if (!$rg) {
            Write-Host "Creating Resource Group ", $ResourceGroupName
            $output = New-AzResourceGroup -Name $ResourceGroupName -Location $TargetRegion
            Write-Host $ResourceGroupName, " created."
        }
        Write-Host "Selected resource group : ", $ResourceGroupName

        $LogStringCreated = "Created : "
        $LogStringSkipping = " already exists."

        $userObject = Get-AzADUser -UserPrincipalName $context.Subscription.ExtendedProperties.Account

        if (-not $userObject) {
            $userObject = Get-AzADUser -Mail $context.Subscription.ExtendedProperties.Account
        }

        if (-not $userObject) {
            $mailNickname = "{0}#EXT#" -f $($context.Account.Id -replace '@', '_')

            $userObject = Get-AzADUser | 
            Where-Object { $_.MailNickname -eq $mailNickname }
        }

        if (-not $userObject) {
            $userObject = Get-AzADServicePrincipal -ApplicationID $context.Account.Id
        }

        if (-not $userObject) {
            throw 'User Object Id Not Found!'
        }

        # Hash code source code
        $Source = @"
using System;
public class HashFunctions
{
public static int hashForArtifact(String artifact)
{
    int hash = 0;
    int al = artifact.Length;
    int tl = 0;
    char[] ac = artifact.ToCharArray();
    while (tl < al)
    {
        hash = ((hash << 5) - hash) + ac[tl++] | 0;
    }
    return Math.Abs(hash);
}
}
"@

        #Get vault name from SMS solution.
        $smsSolution = Get-AzMigrateSolution -MigrateProjectName $ProjectName -ResourceGroupName $ResourceGroupName -Name "Servers-Migration-ServerMigration"
        if (-not $smsSolution.DetailExtendedDetail.AdditionalProperties.vaultId) {
            throw 'Azure Migrate appliance not configured. Setup Azure Migrate appliance before proceeding.'
        }
        $VaultName = $smsSolution.DetailExtendedDetail.AdditionalProperties.vaultId.Split("/")[8]
        $VaultDetails = Get-AzRecoveryServicesVault -ResourceGroupName $ResourceGroupName -Name $VaultName
        $isPublicScenario = $VaultDetails.Properties.PrivateEndpointStateForSiteRecovery -eq "None"


        # Get all appliances and sites in the project from SDS solution.
        $sdsSolution = Get-AzMigrateSolution -MigrateProjectName $ProjectName -ResourceGroupName $ResourceGroupName -Name "Servers-Discovery-ServerDiscovery"
        $appMap = @{}

        if ($null -ne $sdsSolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"]) {
            $appMapV2 = $sdsSolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"] | ConvertFrom-Json
            # Fetch all appliance from V2 map first. Then these can be updated if found again in V3 map.
            foreach ($item in $appMapV2) {
                $appMap[$item.ApplianceName] = $item.SiteId
            }
        }

        if ($null -ne $sdsSolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"]) {
            $appMapV3 = $sdsSolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"] | ConvertFrom-Json
            foreach ($item in $appMapV3) {
                $t = $item.psobject.properties
                $appMap[$t.Name] = $t.Value.SiteId
            }
        }

        if ($null -eq $sdsSolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"] -And
            $null -eq $sdsSolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"] ) {
            throw "Server Discovery Solution missing Appliance Details. Invalid Solution."           
        }

        foreach ($eachApp in $appMap.GetEnumerator()) {
            $SiteName = $eachApp.Value.Split("/")[8]
            $applianceName = $eachApp.Key

            # User cannot change location if it's already set in mapping.
            $mappingName = "containermapping"
            $allFabrics = Get-AzMigrateReplicationFabric -ResourceGroupName $ResourceGroupName -ResourceName $VaultName

            foreach ($fabric in $allFabrics) {
                if (($fabric.Property.CustomDetail.InstanceType -eq "VMwareV2") -and ($fabric.Property.CustomDetail.VmwareSiteId.Split("/")[8] -eq $SiteName)) {
                    $fabricName = $fabric.Name
                    $HashCodeInput = $fabric.Id
                    $peContainers = Get-AzMigrateReplicationProtectionContainer -FabricName $fabric.Name -ResourceGroupName $ResourceGroupName -ResourceName $VaultName
                    $peContainer = $peContainers[0]
                    $existingMapping = Get-AzMigrateReplicationProtectionContainerMapping -ResourceGroupName $ResourceGroupName -ResourceName $VaultName -FabricName $fabric.Name -ProtectionContainerName $peContainer.Name -MappingName $mappingName -ErrorVariable notPresent -ErrorAction SilentlyContinue
                    if (($existingMapping) -and ($existingMapping.ProviderSpecificDetail.TargetLocation -ne $TargetRegion)) {
                        $targetRegionMismatchExceptionMsg = $ProjectName + " is already configured for migrating servers to " + $TargetRegion + ". Target Region cannot be modified once configured."
                        throw $targetRegionMismatchExceptionMsg
                    }

                    if (($isPublicScenario) -and ($CacheStorageAccountId) -and ($existingMapping) -and ($existingMapping.ProviderSpecificDetail.StorageAccountId -ne $CacheStorageAccountId)) {
                        $saMismatchExceptionMsg = $applianceName + " is already configured for migrating servers with storage account " + $existingMapping.ProviderSpecificDetail.StorageAccountId + ". Storage account cannot be modified once configured."
                        throw $saMismatchExceptionMsg
                    }
                }
            }

            $job = Start-Job -ScriptBlock {
                Add-Type -TypeDefinition $args[0] -Language CSharp 
                $hash = [HashFunctions]::hashForArtifact($args[1]) 
                $hash
            } -ArgumentList $Source, $HashCodeInput
            Wait-Job $job
            $hash = Receive-Job $job

            Write-Host "Initiating Artifact Creation for Appliance: ", $applianceName
            $MigratePrefix = "migrate"
            
            if ($isPublicScenario) {
                # Phase 1
                # Storage account
                if ([string]::IsNullOrEmpty($CacheStorageAccountId)) {
                    if (!$existingMapping) {
                        $ReplicationStorageAcName = $MigratePrefix + "rsa" + $hash
                        $StorageType = "Microsoft.Storage/storageAccounts"
                        $StorageApiVersion = "2017-10-01" 
                        $ReplicationStorageProperties = @{
                            encryption               = @{
                                services  = @{
                                    blob  = @{enabled = $true };
                                    file  = @{enabled = $true };
                                    table = @{enabled = $true };
                                    queue = @{enabled = $true }
                                };
                                keySource = "Microsoft.Storage"
                            };
                            supportsHttpsTrafficOnly = $true
                        }
                        $ResourceTag = @{"Migrate Project" = $ProjectName }
                        $StorageSku = @{name = "Standard_LRS" }
                        $ResourceKind = "Storage"

                        $replicationStorageAccount = Get-AzResource -ResourceGroupName $ResourceGroupName -Name $ReplicationStorageAcName -ErrorVariable notPresent -ErrorAction SilentlyContinue
                        if (!$replicationStorageAccount) {
                            $output = New-AzResource -ResourceGroupName $ResourceGroupName -Location $TargetRegion -Properties  $ReplicationStorageProperties -ResourceName $ReplicationStorageAcName -ResourceType  $StorageType -ApiVersion $StorageApiVersion -Kind  $ResourceKind -Sku  $StorageSku -Tag $ResourceTag -Force
                            Write-Host $LogStringCreated, $ReplicationStorageAcName
                        }
                        elseif ($replicationStorageAccount.Location -ne $TargetRegion){
                            throw "Storage account with name '$($ReplicationStorageAcName)' already exists in '$($replicationStorageAccount.Location)'. You can either migrate to '$($replicationStorageAccount.Location)' or delete the existing storage account."
                        }
                        else {
                             Write-Host $ReplicationStorageAcName, $LogStringSkipping
                        }

                        # Locks
                        $CommonLockName = $ProjectName + "lock"
                        $lockNotes = "This is in use by Azure Migrate project"
                        $rsaLock = Get-AzResourceLock -LockName $CommonLockName -ResourceName $ReplicationStorageAcName -ResourceType $StorageType -ResourceGroupName $ResourceGroupName -ErrorVariable notPresent -ErrorAction SilentlyContinue
                        if (!$rsaLock) {
                            $output = New-AzResourceLock -LockLevel CanNotDelete -LockName $CommonLockName -ResourceName $ReplicationStorageAcName -ResourceType $StorageType -ResourceGroupName $ResourceGroupName -LockNotes $lockNotes -Force
                            Write-Host $LogStringCreated, $CommonLockName, " for ", $ReplicationStorageAcName
                        }
                        else {
                            Write-Host $CommonLockName, " for ", $ReplicationStorageAcName, $LogStringSkipping
                        }
                    }
                }
                else {
                    $ReplicationStorageAcName = $CacheStorageAccountId.Split("/")[-1]
                    $response = Get-AzResource -ResourceId $CacheStorageAccountId -ErrorVariable notPresent -ErrorAction SilentlyContinue
                    if ($response -eq $null) {
                        throw "Storage account '$($CacheStorageAccountId)' does not exist."
                    }
                }

                # Intermediate phase
                # RoleAssignments
                $applianceDetails = Get-AzMigrateReplicationRecoveryServicesProvider -ResourceGroupName $ResourceGroupName -ResourceName $VaultName
                if ($applianceDetails.length -eq 1){
                    $applianceSpnId = $applianceDetails.ResourceAccessIdentityDetailObjectId
                }
                else {
                    foreach ($appliance in $applianceDetails){
                        if ($appliance.FabricFriendlyName -eq $fabricName){
                            $applianceSpnId = $appliance.ResourceAccessIdentityDetailObjectId
                        }
                    }
                }

                $vaultMsiPrincipalId = $VaultDetails.Identity.PrincipalId

                if ($applianceSpnId -eq $null) {
                    Write-Host "The appliance '$($applianceName)' does not have SPN enabled. Please enable and retry the operation."
                    continue
                }

                if ($vaultMsiPrincipalId -eq $null) {
                    Write-Host "The vault '$($VaultName)' does not have MSI enabled. Please enable system assigned MSI and retry the operation."
                    continue
                }

                $rsaStorageAccount = Get-AzResource -ResourceName $ReplicationStorageAcName -ResourceGroupName $ResourceGroupName
                for ($i = 1; $i -le 18; $i++) {
                    Write-Host "Waiting for" $ReplicationStorageAcName "to be available... $( $i * 10 ) seconds" -InformationAction Continue
                    Start-Sleep -Seconds 10
                    $rsaStorageAccount = Get-AzResource -ResourceName $ReplicationStorageAcName -ResourceGroupName $ResourceGroupName
                    if ($rsaStorageAccount) {
                        break
                    }
                }

                Create-RoleAssignments $applianceSpnId $rsaStorageAccount.Id
                Create-RoleAssignments $vaultMsiPrincipalId $rsaStorageAccount.Id

                for ($i = 1; $i -le 18; $i++) {
                    Write-Information "Waiting for Role Assignments to be available... $( $i * 10 ) seconds" -InformationAction Continue
                    Start-Sleep -Seconds 10

                    $applianceRoleAssignment = Get-AzRoleAssignment -ObjectId $applianceSpnId -Scope $rsaStorageAccount.Id -ErrorVariable notPresent -ErrorAction SilentlyContinue
                    $vaultRoleAssignments = Get-AzRoleAssignment -ObjectId $vaultMsiPrincipalId -Scope $rsaStorageAccount.Id -ErrorVariable notPresent -ErrorAction SilentlyContinue

                    if ($applianceRoleAssignment -and $vaultRoleAssignments) {
                        break
                    }
                }
           }
           else {
               $rsaStorageAccount = Get-AzResource -ResourceId $CacheStorageAccountId -ErrorVariable notPresent -ErrorAction SilentlyContinue
               if ($rsaStorageAccount -eq $null) {
                   throw "Storage account '$($CacheStorageAccountId)' does not exist."
               }

               Import-Module Az.Network
               $res = Get-AzPrivateEndpointConnection -privatelinkresourceid $CacheStorageAccountId -ErrorVariable notPresent -ErrorAction SilentlyContinue
               if (($res -eq $null) -or ($res.PrivateEndpoint -eq $null) -or ($res.PrivateEndpoint.Count -eq 0)) {
                   throw "Storage account '$($CacheStorageAccountId)' is not private endpoint enabled."
               }
           }

            # Policy
            $policyName = $MigratePrefix + $SiteName + "policy"
            $existingPolicyObject = Get-AzMigrateReplicationPolicy -PolicyName $policyName -ResourceGroupName $ResourceGroupName -ResourceName $VaultName -ErrorVariable notPresent -ErrorAction SilentlyContinue
            if (!$existingPolicyObject) {
                $providerSpecificPolicy = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.VMwareCbtPolicyCreationInput]::new()
                $providerSpecificPolicy.AppConsistentFrequencyInMinute = 240
                $providerSpecificPolicy.InstanceType = "VMwareCbt"
                $providerSpecificPolicy.RecoveryPointHistoryInMinute = 360
                $providerSpecificPolicy.CrashConsistentFrequencyInMinute = 60
                $existingPolicyObject = New-AzMigrateReplicationPolicy -PolicyName $policyName -ResourceGroupName $ResourceGroupName -ResourceName $VaultName -ProviderSpecificInput $providerSpecificPolicy
                Write-Host $LogStringCreated, $policyName
            }
            else {
                Write-Host $policyName, $LogStringSkipping
            }

            # Policy-container mapping
            $mappingName = "containermapping"
            $allFabrics = Get-AzMigrateReplicationFabric -ResourceGroupName $ResourceGroupName -ResourceName $VaultName
            foreach ($fabric in $allFabrics) {
                if (($fabric.Property.CustomDetail.InstanceType -eq "VMwareV2") -and ($fabric.Property.CustomDetail.VmwareSiteId.Split("/")[8] -eq $SiteName)) {
                    $peContainers = Get-AzMigrateReplicationProtectionContainer -FabricName $fabric.Name -ResourceGroupName $ResourceGroupName -ResourceName $VaultName
                    $peContainer = $peContainers[0]
                    $existingMapping = Get-AzMigrateReplicationProtectionContainerMapping -ResourceGroupName $ResourceGroupName -ResourceName $VaultName -FabricName $fabric.Name -ProtectionContainerName $peContainer.Name -MappingName $mappingName -ErrorVariable notPresent -ErrorAction SilentlyContinue
                    if ($existingMapping) {
                        Write-Host $mappingName, " for ", $applianceName, $LogStringSkipping
                    }
                    else {
                        $providerSpecificInput = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.VMwareCbtContainerMappingInput]::new()
                        $providerSpecificInput.InstanceType = "VMwareCbt"
                        $providerSpecificInput.TargetLocation = $TargetRegion
                        
                        # If mapping does not exist, it means green field scenario. Hence, no service bus/KV required.
                        $providerSpecificInput.StorageAccountId = $rsaStorageAccount.Id

                        $output = New-AzMigrateReplicationProtectionContainerMapping -FabricName $fabric.Name -MappingName $mappingName -ProtectionContainerName $peContainer.Name -ResourceGroupName $ResourceGroupName -ResourceName $VaultName -PolicyId $existingPolicyObject.Id -ProviderSpecificInput $providerSpecificInput -TargetProtectionContainerId  "Microsoft Azure"
                        Write-Host $LogStringCreated, $mappingName, " for ", $applianceName
                    }
                }
            }
        }
        Write-Host "Finished successfully."
        return $true
    }
}