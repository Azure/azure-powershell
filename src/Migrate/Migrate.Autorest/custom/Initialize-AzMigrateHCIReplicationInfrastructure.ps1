
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

<#
.Synopsis
Initializes the infrastructure for the migrate project.
.Description
The Initialize-AzMigrateHCIReplicationInfrastructure cmdlet initializes the infrastructure for the migrate project in AzStackHCI scenario.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/initialize-azmigratehcireplicationinfrastructure
#>

function Initialize-AzMigrateHCIReplicationInfrastructure {
    [OutputType([System.Boolean], ParameterSetName = 'AzStackHCI')]
    [CmdletBinding(DefaultParameterSetName = 'AzStackHCI', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Storage Account ARM Id to be used for private endpoint scenario.
        ${CacheStorageAccountId},

        [Parameter()]
        [System.String]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        # Azure Subscription ID.
        ${SubscriptionId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the source appliance name for the AzStackHCI scenario.
        ${SourceApplianceName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the target appliance name for the AzStackHCI scenario.
        ${TargetApplianceName},

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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru},
    
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
        Import-Module $PSScriptRoot\Helper\AzStackHCICommonSettings.ps1
        Import-Module $PSScriptRoot\Helper\CommonHelper.ps1

        CheckResourcesModuleDependency
        CheckStorageModuleDependency
        Import-Module Az.Resources
        Import-Module Az.Storage

        $context = Get-AzContext
        # Get SubscriptionId
        if ([string]::IsNullOrEmpty($SubscriptionId)) {
            Write-Host "No -SubscriptionId provided. Using the one from Get-AzContext."

            $SubscriptionId = $context.Subscription.Id
            if ([string]::IsNullOrEmpty($SubscriptionId)) {
                throw "Please login to Azure to select a subscription."
            }
        }
        Write-Host "*Selected Subscription Id: '$($SubscriptionId)'."
    
        # Get resource group
        $resourceGroup = Get-AzResourceGroup -Name $ResourceGroupName -ErrorVariable notPresent -ErrorAction SilentlyContinue
        if ($null -eq $resourceGroup) {
            throw "Resource group '$($ResourceGroupName)' does not exist in the subscription. Please create the resource group and try again."
        }
        Write-Host "*Selected Resource Group: '$($ResourceGroupName)'."

        # Verify user validity
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

        # Get Migrate Project
        $migrateProject = Az.Migrate\Get-AzMigrateProject `
            -Name $ProjectName `
            -ResourceGroupName $ResourceGroupName `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $migrateProject) {
            throw "Migrate project '$($ProjectName)' not found."
        }

        # Access Discovery Service
        $discoverySolutionName = "Servers-Discovery-ServerDiscovery"
        $discoverySolution = Az.Migrate\Get-AzMigrateSolution `
            -SubscriptionId $SubscriptionId `
            -ResourceGroupName $ResourceGroupName `
            -MigrateProjectName $ProjectName `
            -Name $discoverySolutionName `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($discoverySolution.Name -ne $discoverySolutionName) {
            throw "Server Discovery Solution not found."
        }

        # Get Appliances Mapping
        $appMap = @{}
        if ($null -ne $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"]) {
            $appMapV2 = $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"] | ConvertFrom-Json
            # Fetch all appliance from V2 map first. Then these can be updated if found again in V3 map.
            foreach ($item in $appMapV2) {
                $appMap[$item.ApplianceName.ToLower()] = $item.SiteId
            }
        }
    
        if ($null -ne $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"]) {
            $appMapV3 = $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"] | ConvertFrom-Json
            foreach ($item in $appMapV3) {
                $t = $item.psobject.properties
                $appMap[$t.Name.ToLower()] = $t.Value.SiteId
            }
        }

        if ($null -eq $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"] -And
            $null -eq $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"] ) {
            throw "Server Discovery Solution missing Appliance Details. Invalid Solution."           
        }

        $hyperVSiteTypeRegex = "(?<=/Microsoft.OffAzure/HyperVSites/).*$"
        $vmwareSiteTypeRegex = "(?<=/Microsoft.OffAzure/VMwareSites/).*$"

        # Validate SourceApplianceName & TargetApplianceName
        $sourceSiteId = $appMap[$SourceApplianceName.ToLower()]
        $targetSiteId = $appMap[$TargetApplianceName.ToLower()]
        if ($sourceSiteId -match $hyperVSiteTypeRegex -and $targetSiteId -match $hyperVSiteTypeRegex) {
            $instanceType = $AzStackHCIInstanceTypes.HyperVToAzStackHCI
        }
        elseif ($sourceSiteId -match $vmwareSiteTypeRegex -and $targetSiteId -match $hyperVSiteTypeRegex) {
            $instanceType = $AzStackHCIInstanceTypes.VMwareToAzStackHCI
        }
        else {
            throw "Error encountered in matching the given source appliance name '$SourceApplianceName' and target appliance name '$TargetApplianceName'. Please verify the VM site type to be either for HyperV or VMware for both source and target appliances, and the appliance names are correct."
        }

        # Get Data Replication Service, or the AMH solution
        $amhSolution = Az.Migrate\Get-AzMigrateSolution `
            -ResourceGroupName $ResourceGroupName `
            -MigrateProjectName $ProjectName `
            -Name "Servers-Migration-ServerMigration_DataReplication" `
            -SubscriptionId $SubscriptionId `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $amhSolution) {
            throw "No Data Replication Service Solution found. Please verify your appliance setup."
        }

        # Get Source and Target Fabrics
        $allFabrics = Az.Migrate\Get-AzMigrateHCIReplicationFabric -ResourceGroupName $ResourceGroupName
        foreach ($fabric in $allFabrics) {
            if ($fabric.Property.CustomProperty.MigrationSolutionId -ne $amhSolution.Id) {
                continue
            }

            if (($instanceType -eq $AzStackHCIInstanceTypes.HyperVToAzStackHCI) -and
                ($fabric.Property.CustomProperty.InstanceType -ceq $FabricInstanceTypes.HyperVInstance)) {
                $sourceFabric = $fabric
            }
            elseif (($instanceType -eq $AzStackHCIInstanceTypes.VMwareToAzStackHCI) -and
                ($fabric.Property.CustomProperty.InstanceType -ceq $FabricInstanceTypes.VMwareInstance)) {
                $sourceFabric = $fabric
            }
            elseif ($fabric.Property.CustomProperty.InstanceType -ceq $FabricInstanceTypes.AzStackHCIInstance) {
                $targetFabric = $fabric
            }

            if (($null -ne $sourceFabric) -and ($null -ne $targetFabric)) {
                break
            }
        }

        if ($null -eq $sourceFabric) {
            throw "Source Fabric not found. Please verify your appliance setup."
        }
        Write-Host "*Selected Source Fabric: '$($sourceFabric.Name)'."

        if ($null -eq $targetFabric) {
            throw "Target Fabric not found. Please verify your appliance setup."
        }
        Write-Host "*Selected Target Fabric: '$($targetFabric.Name)'."

        # Get Source and Target Dras from Fabrics
        $sourceDras = Az.Migrate.Internal\Get-AzMigrateDra `
            -FabricName $sourceFabric.Name `
            -ResourceGroupName $ResourceGroupName `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $sourceDras) {
            throw "Source Dra found. Please verify your appliance setup."
        }
        $sourceDra = $sourceDras[0]
        Write-Host "*Selected Source Dra: '$($sourceDra.Name)'."

        $targetDras = Az.Migrate.Internal\Get-AzMigrateDra `
            -FabricName $targetFabric.Name `
            -ResourceGroupName $ResourceGroupName `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $targetDras) {
            throw "Source Dra found. Please verify your appliance setup."
        }
        $targetDra = $targetDras[0]
        Write-Host "*Selected Target Dra: '$($targetDra.Name)'."
        
        # Get Replication Vault
        $replicationVaultName = $amhSolution.DetailExtendedDetail["vaultId"].Split("/")[8]
        $replicationVault = Az.Migrate.Internal\Get-AzMigrateVault `
            -ResourceGroupName $ResourceGroupName `
            -Name $replicationVaultName
        if ($null -eq $replicationVault) {
            throw "No Replication Vault found in Resource Group '$($ResourceGroupName)'."
        }

        # Put Policy
        $policyName = $replicationVault.Name + $instanceType + "policy"
        $policy = Az.Migrate.Internal\Get-AzMigratePolicy `
            -ResourceGroupName $ResourceGroupName `
            -Name $policyName `
            -VaultName $replicationVault.Name `
            -SubscriptionId $SubscriptionId `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        
        # Default policy is found
        if ($null -ne $policy) {
            # Give time for create/update to reach a terminal state. Timeout after 10min
            if ($policy.Property.ProvisioningState -eq [ProvisioningState]::Creating -or
                $policy.Property.ProvisioningState -eq [ProvisioningState]::Updating) {
                Write-Host "Policy '$($policyName)' found in Provisioning State '$($policy.Property.ProvisioningState)'."

                for ($i = 0; $i -lt 20; $i++) {
                    Start-Sleep -Seconds 30
                    $policy = Az.Migrate.Internal\Get-AzMigratePolicy -InputObject $policy

                    if (-not (
                            $policy.Property.ProvisioningState -eq [ProvisioningState]::Creating -or
                            $policy.Property.ProvisioningState -eq [ProvisioningState]::Updating)) {
                        break
                    }
                }

                # Make sure Policy is no longer in Creating or Updating state
                if ($policy.Property.ProvisioningState -eq [ProvisioningState]::Creating -or
                    $policy.Property.ProvisioningState -eq [ProvisioningState]::Updating) {
                    throw "Policy '$($policyName)' times out with Provisioning State: '$($policy.Property.ProvisioningState)'. Please re-run this command or contact support if help needed."
                }
            }

            # Check and remove if policy is in a bad terminal state
            if ($policy.Property.ProvisioningState -eq [ProvisioningState]::Canceled -or
                $policy.Property.ProvisioningState -eq [ProvisioningState]::Failed) {
                Write-Host "Policy '$($policyName)' found but in an unusable terminal Provisioning State '$($policy.Property.ProvisioningState)'.`nRemoving policy..."
                    
                # Remove policy
                try {
                    Az.Migrate.Internal\Remove-AzMigratePolicy -InputObject $policy | Out-Null
                }
                catch {
                    if ($_.Exception.Message -notmatch "Status: OK") {
                        throw $_.Exception.Message
                    }
                }

                Start-Sleep -Seconds 30
                $policy = Az.Migrate.Internal\Get-AzMigratePolicy `
                    -InputObject $policy `
                    -ErrorVariable notPresent `
                    -ErrorAction SilentlyContinue

                # Make sure Policy is no longer in Canceled or Failed state
                if ($null -ne $policy -and
                    ($policy.Property.ProvisioningState -eq [ProvisioningState]::Canceled -or
                    $policy.Property.ProvisioningState -eq [ProvisioningState]::Failed)) {
                    throw "Failed to change the Provisioning State of policy '$($policyName)'by removing. Please re-run this command or contact support if help needed."
                }
            }

            # Give time to remove policy. Timeout after 10min
            if ($null -eq $policy -and $policy.Property.ProvisioningState -eq [ProvisioningState]::Deleting) {
                Write-Host "Policy '$($policyName)' found in Provisioning State '$($policy.Property.ProvisioningState)'."

                for ($i = 0; $i -lt 20; $i++) {
                    Start-Sleep -Seconds 30
                    $policy = Az.Migrate.Internal\Get-AzMigratePolicy `
                        -InputObject $policy `
                        -ErrorVariable notPresent `
                        -ErrorAction SilentlyContinue
                    
                    if ($null -eq $policy -or $policy.Property.ProvisioningState -eq [ProvisioningState]::Deleted) {
                        break
                    }
                    elseif ($policy.Property.ProvisioningState -eq [ProvisioningState]::Deleting) {
                        continue
                    }

                    throw "Policy '$($policyName)' has an unexpected Provisioning State of '$($policy.Property.ProvisioningState)' during removal process. Please re-run this command or contact support if help needed."
                }

                # Make sure Policy is no longer in Deleting state
                if ($null -ne $policy -and $policy.Property.ProvisioningState -eq [ProvisioningState]::Deleting) {
                    throw "Policy '$($policyName)' times out with Provisioning State: '$($policy.Property.ProvisioningState)'. Please re-run this command or contact support if help needed."
                }
            }

            # Indicate policy was removed
            if ($null -eq $policy -or $policy.Property.ProvisioningState -eq [ProvisioningState]::Deleted) {
                Write-Host "Policy '$($policyName)' was removed."
            }
        }

        # Refresh local policy object if exists
        if ($null -ne $policy) {
            $policy = Az.Migrate.Internal\Get-AzMigratePolicy -InputObject $policy
        }

        # Create policy if not found or previously deleted
        if ($null -eq $policy -or $policy.Property.ProvisioningState -eq [ProvisioningState]::Deleted) {
            Write-Host "Creating Policy..."

            $params = @{
                InstanceType                     = $instanceType;
                RecoveryPointHistoryInMinute     = $ReplicationDetails.PolicyDetails.DefaultRecoveryPointHistoryInMinutes;
                CrashConsistentFrequencyInMinute = $ReplicationDetails.PolicyDetails.DefaultCrashConsistentFrequencyInMinutes;
                AppConsistentFrequencyInMinute   = $ReplicationDetails.PolicyDetails.DefaultAppConsistentFrequencyInMinutes;
            }

            # Setup Policy deployment parameters
            $policyProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.PolicyModelProperties]::new()
            if ($instanceType -eq $AzStackHCIInstanceTypes.HyperVToAzStackHCI) {
                $policyCustomProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.HyperVToAzStackHcipolicyModelCustomProperties]::new()
            }
            elseif ($instanceType -eq $AzStackHCIInstanceTypes.VMwareToAzStackHCI) {
                $policyCustomProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.VMwareToAzStackHcipolicyModelCustomProperties]::new()
            }
            else {
                throw "Instance type '$($instanceType)' is not supported. Currently, for AzStackHCI scenario, only HyperV and VMware as the source is supported."
            }
            $policyCustomProperties.InstanceType = $params.InstanceType
            $policyCustomProperties.RecoveryPointHistoryInMinute = $params.RecoveryPointHistoryInMinute
            $policyCustomProperties.CrashConsistentFrequencyInMinute = $params.CrashConsistentFrequencyInMinute
            $policyCustomProperties.AppConsistentFrequencyInMinute = $params.AppConsistentFrequencyInMinute
            $policyProperties.CustomProperty = $policyCustomProperties
        
            try {
                Az.Migrate.Internal\New-AzMigratePolicy `
                    -Name $policyName `
                    -ResourceGroupName $ResourceGroupName `
                    -VaultName $replicationVaultName `
                    -Property $policyProperties `
                    -SubscriptionId $SubscriptionId `
                    -NoWait | Out-Null
            }
            catch {
                if ($_.Exception.Message -notmatch "Status: OK") {
                    throw $_.Exception.Message
                }
            }

            # Check Policy creation status every 30s. Timeout after 10min
            for ($i = 0; $i -lt 20; $i++) {
                Start-Sleep -Seconds 30
                $policy = Az.Migrate.Internal\Get-AzMigratePolicy `
                    -ResourceGroupName $ResourceGroupName `
                    -Name $policyName `
                    -VaultName $replicationVault.Name `
                    -SubscriptionId $SubscriptionId `
                    -ErrorVariable notPresent `
                    -ErrorAction SilentlyContinue
                if ($null -eq $policy) {
                    throw "Unexpected error occurred during policy creation. Please re-run this command or contact support if help needed."
                }
                
                # Stop if policy reaches a terminal state
                if ($policy.Property.ProvisioningState -eq [ProvisioningState]::Succeeded -or
                    $policy.Property.ProvisioningState -eq [ProvisioningState]::Deleted -or
                    $policy.Property.ProvisioningState -eq [ProvisioningState]::Canceled -or
                    $policy.Property.ProvisioningState -eq [ProvisioningState]::Failed) {
                    break
                }
            }

            # Make sure Policy is in a terminal state
            if (-not (
                    $policy.Property.ProvisioningState -eq [ProvisioningState]::Succeeded -or
                    $policy.Property.ProvisioningState -eq [ProvisioningState]::Deleted -or
                    $policy.Property.ProvisioningState -eq [ProvisioningState]::Canceled -or
                    $policy.Property.ProvisioningState -eq [ProvisioningState]::Failed)) {
                throw "Policy '$($policyName)' times out with Provisioning State: '$($policy.Property.ProvisioningState)' during creation process. Please re-run this command or contact support if help needed."
            }
        }
        
        if ($policy.Property.ProvisioningState -ne [ProvisioningState]::Succeeded) {
            throw "Policy '$($policyName)' has an unexpected Provisioning State of '$($policy.Property.ProvisioningState)'. Please re-run this command or contact support if help needed."
        }

        $policy = Az.Migrate.Internal\Get-AzMigratePolicy `
            -ResourceGroupName $ResourceGroupName `
            -Name $policyName `
            -VaultName $replicationVault.Name `
            -SubscriptionId $SubscriptionId `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $policy) {
            throw "Unexpected error occurred during policy creation. Please re-run this command or contact support if help needed."
        }
        elseif ($policy.Property.ProvisioningState -ne [ProvisioningState]::Succeeded) {
            throw "Policy '$($policyName)' has an unexpected Provisioning State of '$($policy.Property.ProvisioningState)'. Please re-run this command or contact support if help needed."
        }
        else {
            Write-Host "*Selected Policy: '$($policyName)'."
        }

        # Put Cache Storage Account
        $amhSolution = Az.Migrate\Get-AzMigrateSolution `
            -ResourceGroupName $ResourceGroupName `
            -MigrateProjectName $ProjectName `
            -Name "Servers-Migration-ServerMigration_DataReplication" `
            -SubscriptionId $SubscriptionId `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $amhSolution) {
            throw "No Data Replication Service Solution found. Please verify your appliance setup."
        }

        $amhStoredStorageAccountId = $amhSolution.DetailExtendedDetail["replicationStorageAccountId"]
        
        # Record of rsa found in AMH solution
        if (![string]::IsNullOrEmpty($amhStoredStorageAccountId)) {
            $amhStoredStorageAccountName = $amhStoredStorageAccountId.Split("/")[8]
            $amhStoredStorageAccount = Get-AzStorageAccount `
                -ResourceGroupName $ResourceGroupName `
                -Name $amhStoredStorageAccountName `
                -ErrorVariable notPresent `
                -ErrorAction SilentlyContinue

            # Wait for amhStoredStorageAccount to reach a terminal state
            if ($null -ne $amhStoredStorageAccount -and
                $null -ne $amhStoredStorageAccount.ProvisioningState -and
                $amhStoredStorageAccount.ProvisioningState -ne [StorageAccountProvisioningState]::Succeeded) {
                # Check rsa state every 30s if not Succeeded already. Timeout after 10min
                for ($i = 0; $i -lt 20; $i++) {
                    Start-Sleep -Seconds 30
                    $amhStoredStorageAccount = Get-AzStorageAccount `
                        -ResourceGroupName $ResourceGroupName `
                        -Name $amhStoredStorageAccountName `
                        -ErrorVariable notPresent `
                        -ErrorAction SilentlyContinue
                        # Stop if amhStoredStorageAccount is not found or in a terminal state
                    if ($null -eq $amhStoredStorageAccount -or
                        $null -eq $amhStoredStorageAccount.ProvisioningState -or
                        $amhStoredStorageAccount.ProvisioningState -eq [StorageAccountProvisioningState]::Succeeded) {
                        break
                    }
                }
            }
            
            # amhStoredStorageAccount exists and in Succeeded state
            if ($null -ne $amhStoredStorageAccount -and
                $amhStoredStorageAccount.ProvisioningState -eq [StorageAccountProvisioningState]::Succeeded) {
                # Use amhStoredStorageAccount and ignore user provided Cache Storage Account Id
                if (![string]::IsNullOrEmpty($CacheStorageAccountId) -and $amhStoredStorageAccount.Id -ne $CacheStorageAccountId) {
                    Write-Host "A Cache Storage Account '$($amhStoredStorageAccountName)' has been linked already. The given -CacheStorageAccountId '$($CacheStorageAccountId)' will be ignored."
                }

                $cacheStorageAccount = $amhStoredStorageAccount
            }
            elseif ($null -eq $amhStoredStorageAccount -or $null -eq $amhStoredStorageAccount.ProvisioningState) {
                # amhStoredStorageAccount is found but in a bad state, so log to ask user to remove
                if ($null -ne $amhStoredStorageAccount -and $null -eq $amhStoredStorageAccount.ProvisioningState) {
                    Write-Host "A previously linked Cache Storage Account with Id '$($amhStoredStorageAccountId)' is found but in a unusable state. Please remove it manually and re-run this command."
                }

                # amhStoredStorageAccount is not found or in a bad state but AMH has a record of it, so remove the record
                if ($amhSolution.DetailExtendedDetail.ContainsKey("replicationStorageAccountId")) {
                    $amhSolution.DetailExtendedDetail.Remove("replicationStorageAccountId") | Out-Null
                    $amhSolution.DetailExtendedDetail.Add("replicationStorageAccountId", $null) | Out-Null
                    Az.Migrate.Internal\Set-AzMigrateSolution `
                        -MigrateProjectName $ProjectName `
                        -Name $amhSolution.Name `
                        -ResourceGroupName $ResourceGroupName `
                        -DetailExtendedDetail $amhSolution.DetailExtendedDetail.AdditionalProperties | Out-Null
                }
            }
            else {
                throw "A linked Cache Storage Account with Id '$($amhStoredStorageAccountId)' times out with Provisioning State: '$($amhStoredStorageAccount.ProvisioningState)'. Please re-run this command or contact support if help needed."
            }

            $amhSolution = Az.Migrate\Get-AzMigrateSolution `
                -ResourceGroupName $ResourceGroupName `
                -MigrateProjectName $ProjectName `
                -Name "Servers-Migration-ServerMigration_DataReplication" `
                -SubscriptionId $SubscriptionId `
                -ErrorVariable notPresent `
                -ErrorAction SilentlyContinue
                # Check if AMH record is removed
            if (($null -eq $amhStoredStorageAccount -or $null -eq $amhStoredStorageAccount.ProvisioningState) -and
                ![string]::IsNullOrEmpty($amhSolution.DetailExtendedDetail["replicationStorageAccountId"])) {
                throw "Unexpected error occurred in unlinking Cache Storage Account with Id '$($amhSolution.DetailExtendedDetail["replicationStorageAccountId"])'. Please re-run this command or contact support if help needed."
            }
        }

        # No linked Cache Storage Account found in AMH solution but user provides a Cache Storage Account Id
        if ($null -eq $cacheStorageAccount -and ![string]::IsNullOrEmpty($CacheStorageAccountId)) {
            $userProvidedStorageAccountIdSegs = $CacheStorageAccountId.Split("/")
            if ($userProvidedStorageAccountIdSegs.Count -ne 9) {
                throw "Invalid Cache Storage Account Id '$($CacheStorageAccountId)' provided. Please provide a valid one."
            }

            $userProvidedStorageAccountName = ($userProvidedStorageAccountIdSegs[8]).ToLower()

            # Check if user provided Cache Storage Account exists
            $userProvidedStorageAccount = Get-AzStorageAccount `
                -ResourceGroupName $ResourceGroupName `
                -Name $userProvidedStorageAccountName `
                -ErrorVariable notPresent `
                -ErrorAction SilentlyContinue

            # Wait for userProvidedStorageAccount to reach a terminal state
            if ($null -ne $userProvidedStorageAccount -and
                $null -ne $userProvidedStorageAccount.ProvisioningState -and
                $userProvidedStorageAccount.ProvisioningState -ne [StorageAccountProvisioningState]::Succeeded) {
                # Check rsa state every 30s if not Succeeded already. Timeout after 10min
                for ($i = 0; $i -lt 20; $i++) {
                    Start-Sleep -Seconds 30
                    $userProvidedStorageAccount = Get-AzStorageAccount `
                        -ResourceGroupName $ResourceGroupName `
                        -Name $userProvidedStorageAccountName `
                        -ErrorVariable notPresent `
                        -ErrorAction SilentlyContinue
                    # Stop if userProvidedStorageAccount is not found or in a terminal state
                    if ($null -eq $userProvidedStorageAccount -or
                        $null -eq $userProvidedStorageAccount.ProvisioningState -or
                        $userProvidedStorageAccount.ProvisioningState -eq [StorageAccountProvisioningState]::Succeeded) {
                        break
                    }
                }
            }

            if ($null -ne $userProvidedStorageAccount -and
                $userProvidedStorageAccount.ProvisioningState -eq [StorageAccountProvisioningState]::Succeeded) {
                $cacheStorageAccount = $userProvidedStorageAccount
            }
            elseif ($null -eq $userProvidedStorageAccount) {
                throw "Cache Storage Account with Id '$($CacheStorageAccountId)' is not found. Please re-run this command without -CacheStorageAccountId to create one automatically or re-create the Cache Storage Account yourself and try again."
            }
            elseif ($null -eq $userProvidedStorageAccount.ProvisioningState) {
                throw "Cache Storage Account with Id '$($CacheStorageAccountId)' is found but in an unusable state. Please re-run this command without -CacheStorageAccountId to create one automatically or re-create the Cache Storage Account yourself and try again."
            }
            else {
                throw "Cache Storage Account with Id '$($CacheStorageAccountId)' is found but times out with Provisioning State: '$($userProvidedStorageAccount.ProvisioningState)'. Please re-run this command or contact support if help needed."
            }
        }

        # No Cache Storage Account found or provided, so create one
        if ($null -eq $cacheStorageAccount) {
            $suffix = (GenerateHashForArtifact -Artifact "$($sourceSiteId)/$($SourceApplianceName)").ToString()
            if ($suffixHash.Length -gt 14) {
                $suffix = $suffixHash.Substring(0, 14)
            }
            $cacheStorageAccountName = "migratersa" + $suffix
            $cacheStorageAccountId = "/subscriptions/$($SubscriptionId)/resourceGroups/$($ResourceGroupName)/providers/Microsoft.Storage/storageAccounts/$($cacheStorageAccountName)"

            # Check if default Cache Storage Account already exists, which it shoudln't
            $cacheStorageAccount = Get-AzStorageAccount `
                -ResourceGroupName $ResourceGroupName `
                -Name $cacheStorageAccountName `
                -ErrorVariable notPresent `
                -ErrorAction SilentlyContinue
            if ($null -ne $cacheStorageAccount) {
                throw "Unexpected error encountered: Cache Storage Account '$($cacheStorageAccountName)' already exists. Please re-run this command to create a different one or contact support if help needed."
            }

            Write-Host "Creating Cache Storage Account with default name '$($cacheStorageAccountName)'..."

            $params = @{
                name                                = $cacheStorageAccountName;
                location                            = $migrateProject.Location;
                migrateProjectName                  = $migrateProject.Name;
                skuName                             = "Standard_LRS";
                tags                                = @{ "Migrate Project" = $migrateProject.Name };
                kind                                = "StorageV2";
                encryption                          = @{ services = @{blob = @{ enabled = $true }; file = @{ enabled = $true } } };
            }

            # Create Cache Storage Account
            $cacheStorageAccount = New-AzStorageAccount `
                -ResourceGroupName $ResourceGroupName `
                -Name $params.name `
                -SkuName $params.skuName `
                -Location $params.location `
                -Kind $params.kind `
                -Tags $params.tags `
                -AllowBlobPublicAccess $true

            if ($null -ne $cacheStorageAccount -and
                $null -ne $cacheStorageAccount.ProvisioningState -and
                $cacheStorageAccount.ProvisioningState -ne [StorageAccountProvisioningState]::Succeeded) {
                # Check rsa state every 30s if not Succeeded already. Timeout after 10min
                for ($i = 0; $i -lt 20; $i++) {
                    Start-Sleep -Seconds 30
                    $cacheStorageAccount = Get-AzStorageAccount `
                        -ResourceGroupName $ResourceGroupName `
                        -Name $params.name `
                        -ErrorVariable notPresent `
                        -ErrorAction SilentlyContinue
                    # Stop if cacheStorageAccount is not found or in a terminal state
                    if ($null -eq $cacheStorageAccount -or
                        $null -eq $cacheStorageAccount.ProvisioningState -or
                        $cacheStorageAccount.ProvisioningState -eq [StorageAccountProvisioningState]::Succeeded) {
                        break
                    }
                }
            }

            if ($null -eq $cacheStorageAccount -or $null -eq $cacheStorageAccount.ProvisioningState) {
                throw "Unexpected error occurs during Cache Storgae Account creation process. Please re-run this command or provide -CacheStorageAccountId of the one created own your own."
            }
            elseif ($cacheStorageAccount.ProvisioningState -ne [StorageAccountProvisioningState]::Succeeded) {
                throw "Cache Storage Account with Id '$($cacheStorageAccount.Id)' times out with Provisioning State: '$($cacheStorageAccount.ProvisioningState)' during creation process. Please remove it manually and re-run this command or contact support if help needed."
            }
        }

        # Sanity check
        if ($null -eq $cacheStorageAccount -or
            $null -eq $cacheStorageAccount.ProvisioningState -or
            $cacheStorageAccount.ProvisioningState -ne [StorageAccountProvisioningState]::Succeeded) {
            throw "Unexpected error occurs during Cache Storgae Account selection process. Please re-run this command or contact support if help needed."
        }

        $params = @{
            contributorRoleDefId                = [System.Guid]::parse($RoleDefinitionIds.ContributorId);
            storageBlobDataContributorRoleDefId = [System.Guid]::parse($RoleDefinitionIds.StorageBlobDataContributorId);
            sourceAppAadId                      = $sourceDra.ResourceAccessIdentityObjectId;
            targetAppAadId                      = $targetDra.ResourceAccessIdentityObjectId;
        }

        # Grant Source Dra AAD App access to Cache Storage Account as "Contributor"
        $hasAadAppAccess = Get-AzRoleAssignment `
            -ObjectId $params.sourceAppAadId `
            -RoleDefinitionId $params.contributorRoleDefId `
            -Scope $cacheStorageAccount.Id `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $hasAadAppAccess) {
            New-AzRoleAssignment `
                -ObjectId $params.sourceAppAadId `
                -RoleDefinitionId $params.contributorRoleDefId `
                -Scope $cacheStorageAccount.Id | Out-Null
        }

        # Grant Source Dra AAD App access to Cache Storage Account as "StorageBlobDataContributor"
        $hasAadAppAccess = Get-AzRoleAssignment `
            -ObjectId $params.sourceAppAadId `
            -RoleDefinitionId $params.storageBlobDataContributorRoleDefId `
            -Scope $cacheStorageAccount.Id `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $hasAadAppAccess) {
            New-AzRoleAssignment `
                -ObjectId $params.sourceAppAadId `
                -RoleDefinitionId $params.storageBlobDataContributorRoleDefId `
                -Scope $cacheStorageAccount.Id | Out-Null
        }

        # Grant Target Dra AAD App access to Cache Storage Account as "Contributor"
        $hasAadAppAccess = Get-AzRoleAssignment `
            -ObjectId $params.targetAppAadId `
            -RoleDefinitionId $params.contributorRoleDefId `
            -Scope $cacheStorageAccount.Id `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $hasAadAppAccess) {
            New-AzRoleAssignment `
                -ObjectId $params.targetAppAadId `
                -RoleDefinitionId $params.contributorRoleDefId `
                -Scope $cacheStorageAccount.Id | Out-Null
        }

        # Grant Target Dra AAD App access to Cache Storage Account as "StorageBlobDataContributor"
        $hasAadAppAccess = Get-AzRoleAssignment `
            -ObjectId $params.targetAppAadId `
            -RoleDefinitionId $params.storageBlobDataContributorRoleDefId `
            -Scope $cacheStorageAccount.Id `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $hasAadAppAccess) {
            New-AzRoleAssignment `
                -ObjectId $params.targetAppAadId `
                -RoleDefinitionId $params.storageBlobDataContributorRoleDefId `
                -Scope $cacheStorageAccount.Id | Out-Null
        }

        # Give time for role assignments to be created. Times out after 2min
        $rsaPermissionGranted = $false
        for ($i = 0; $i -lt 4; $i++) {
            # Check Source Dra AAD App access to Cache Storage Account as "Contributor"
            $hasAadAppAccess = Get-AzRoleAssignment `
                -ObjectId $params.sourceAppAadId `
                -RoleDefinitionId $params.contributorRoleDefId `
                -Scope $cacheStorageAccount.Id `
                -ErrorVariable notPresent `
                -ErrorAction SilentlyContinue
            $rsaPermissionGranted = $null -ne $hasAadAppAccess

            # Check Source Dra AAD App access to Cache Storage Account as "StorageBlobDataContributor"
            $hasAadAppAccess = Get-AzRoleAssignment `
                -ObjectId $params.sourceAppAadId `
                -RoleDefinitionId $params.storageBlobDataContributorRoleDefId `
                -Scope $cacheStorageAccount.Id `
                -ErrorVariable notPresent `
                -ErrorAction SilentlyContinue
            $rsaPermissionGranted = $rsaPermissionGranted -and ($null -ne $hasAadAppAccess)

            # Check Target Dra AAD App access to Cache Storage Account as "Contributor"
            $hasAadAppAccess = Get-AzRoleAssignment `
                -ObjectId $params.targetAppAadId `
                -RoleDefinitionId $params.contributorRoleDefId `
                -Scope $cacheStorageAccount.Id `
                -ErrorVariable notPresent `
                -ErrorAction SilentlyContinue
            $rsaPermissionGranted = $rsaPermissionGranted -and ($null -ne $hasAadAppAccess)

            # Check Target Dra AAD App access to Cache Storage Account as "StorageBlobDataContributor"
            $hasAadAppAccess = Get-AzRoleAssignment `
                -ObjectId $params.targetAppAadId `
                -RoleDefinitionId $params.storageBlobDataContributorRoleDefId `
                -Scope $cacheStorageAccount.Id `
                -ErrorVariable notPresent `
                -ErrorAction SilentlyContinue
            $rsaPermissionGranted = $rsaPermissionGranted -and ($null -ne $hasAadAppAccess)

            if ($rsaPermissionGranted) {
                break
            }

            Start-Sleep -Seconds 30
        }

        if (!$rsaPermissionGranted) {
            throw "Failed to grant Cache Storage Account permissions. Please re-run this command or contact support if help needed."
        }

        $amhSolution = Az.Migrate\Get-AzMigrateSolution `
            -ResourceGroupName $ResourceGroupName `
            -MigrateProjectName $ProjectName `
            -Name "Servers-Migration-ServerMigration_DataReplication" `
            -SubscriptionId $SubscriptionId
        if ($amhSolution.DetailExtendedDetail.ContainsKey("replicationStorageAccountId")) {
            $amhStoredStorageAccountId = $amhSolution.DetailExtendedDetail["replicationStorageAccountId"]
            if ([string]::IsNullOrEmpty($amhStoredStorageAccountId)) {
                # Remove "replicationStorageAccountId" key
                $amhSolution.DetailExtendedDetail.Remove("replicationStorageAccountId")  | Out-Null
            }
            elseif ($amhStoredStorageAccountId -ne $cacheStorageAccount.Id) {
                # Record of rsa mismatch
                throw "Unexpected error occurred in linking Cache Storage Account with Id '$($cacheStorageAccount.Id)'. Please re-run this command or contact support if help needed."
            }
        }

        # Update AMH record with chosen Cache Storage Account
        if (!$amhSolution.DetailExtendedDetail.ContainsKey("replicationStorageAccountId")) {
            $amhSolution.DetailExtendedDetail.Add("replicationStorageAccountId", $cacheStorageAccount.Id)
            Az.Migrate.Internal\Set-AzMigrateSolution `
                -MigrateProjectName $ProjectName `
                -Name $amhSolution.Name `
                -ResourceGroupName $ResourceGroupName `
                -DetailExtendedDetail $amhSolution.DetailExtendedDetail.AdditionalProperties | Out-Null
        }

        Write-Host "*Selected Cache Storage Account: '$($cacheStorageAccount.StorageAccountName)' in Resource Group '$($ResourceGroupName)' at Location '$($cacheStorageAccount.Location)' for Migrate Project '$($migrateProject.Name)'."

        # Put replication extension
        $replicationExtensionName = ($sourceFabric.Id -split '/')[-1] + "-" + ($targetFabric.Id -split '/')[-1] + "-MigReplicationExtn"
        $replicationExtension = Az.Migrate.Internal\Get-AzMigrateReplicationExtension `
            -ResourceGroupName $ResourceGroupName `
            -Name $replicationExtensionName `
            -VaultName $replicationVaultName `
            -SubscriptionId $SubscriptionId `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue

        # Remove replication extension if does not match the selected Cache Storage Account
        if ($null -ne $replicationExtension -and $replicationExtension.Property.CustomProperty.StorageAccountId -ne $cacheStorageAccount.Id) {
            Write-Host "Replication Extension '$($replicationExtensionName)' found but linked to a different Cache Storage Account '$($replicationExtension.Property.CustomProperty.StorageAccountId)'."
        
            try {
                Az.Migrate.Internal\Remove-AzMigrateReplicationExtension -InputObject $replicationExtension | Out-Null
            }
            catch {
                if ($_.Exception.Message -notmatch "Status: OK") {
                    throw $_.Exception.Message
                }
            }

            Write-Host "Removing Replication Extension and waiting for 2 minutes..."
            Start-Sleep -Seconds 120
            $replicationExtension = Az.Migrate.Internal\Get-AzMigrateReplicationExtension `
                -InputObject $replicationExtension `
                -ErrorVariable notPresent `
                -ErrorAction SilentlyContinue

            if ($null -eq $replicationExtension) {
                Write-Host "Replication Extension '$($replicationExtensionName)' was removed."
            }
        }

        # Replication extension exists
        if ($null -ne $replicationExtension) {
            # Give time for create/update to reach a terminal state. Timeout after 10min
            if ($replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Creating -or
                $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Updating) {
                Write-Host "Replication Extension '$($replicationExtensionName)' found in Provisioning State '$($replicationExtension.Property.ProvisioningState)'."

                for ($i = 0; $i -lt 20; $i++) {
                    Start-Sleep -Seconds 30
                    $replicationExtension = Az.Migrate.Internal\Get-AzMigrateReplicationExtension `
                        -InputObject $replicationExtension `
                        -ErrorVariable notPresent `
                        -ErrorAction SilentlyContinue

                    if (-not (
                            $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Creating -or
                            $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Updating)) {
                        break
                    }
                }

                # Make sure replication extension is no longer in Creating or Updating state
                if ($replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Creating -or
                    $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Updating) {
                    throw "Replication Extension '$($replicationExtensionName)' times out with Provisioning State: '$($replicationExtension.Property.ProvisioningState)'. Please re-run this command or contact support if help needed."
                }
            }

            # Check and remove if replication extension is in a bad terminal state
            if ($replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Canceled -or
                $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Failed) {
                Write-Host "Replication Extension '$($replicationExtensionName)' found but in an unusable terminal Provisioning State '$($replicationExtension.Property.ProvisioningState)'.`nRemoving Replication Extension..."
                    
                # Remove replication extension
                try {
                    Az.Migrate.Internal\Remove-AzMigrateReplicationExtension -InputObject $replicationExtension | Out-Null
                }
                catch {
                    if ($_.Exception.Message -notmatch "Status: OK") {
                        throw $_.Exception.Message
                    }
                }

                Start-Sleep -Seconds 30
                $replicationExtension = Az.Migrate.Internal\Get-AzMigrateReplicationExtension `
                    -InputObject $replicationExtension `
                    -ErrorVariable notPresent `
                    -ErrorAction SilentlyContinue

                # Make sure replication extension is no longer in Canceled or Failed state
                if ($null -ne $replicationExtension -and
                    ($replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Canceled -or
                    $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Failed)) {
                    throw "Failed to change the Provisioning State of Replication Extension '$($replicationExtensionName)'by removing. Please re-run this command or contact support if help needed."
                }
            }

            # Give time to remove replication extension. Timeout after 10min
            if ($null -ne $replicationExtension -and
                $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Deleting) {
                Write-Host "Replication Extension '$($replicationExtensionName)' found in Provisioning State '$($replicationExtension.Property.ProvisioningState)'."

                for ($i = 0; $i -lt 20; $i++) {
                    Start-Sleep -Seconds 30
                    $replicationExtension = Az.Migrate.Internal\Get-AzMigrateReplicationExtension `
                        -InputObject $replicationExtension `
                        -ErrorVariable notPresent `
                        -ErrorAction SilentlyContinue

                    if ($null -eq $replicationExtension -or $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Deleted) {
                        break
                    }
                    elseif ($replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Deleting) {
                        continue
                    }

                    throw "Replication Extension '$($replicationExtensionName)' has an unexpected Provisioning State of '$($replicationExtension.Property.ProvisioningState)' during removal process. Please re-run this command or contact support if help needed."
                }

                # Make sure replication extension is no longer in Deleting state
                if ($null -ne $replicationExtension -and $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Deleting) {
                    throw "Replication Extension '$($replicationExtensionName)' times out with Provisioning State: '$($replicationExtension.Property.ProvisioningState)'. Please re-run this command or contact support if help needed."
                }
            }

            # Indicate replication extension was removed
            if ($null -eq $replicationExtension -or $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Deleted) {
                Write-Host "Replication Extension '$($replicationExtensionName)' was removed."
            }
        }

        # Refresh local replication extension object if exists
        if ($null -ne $replicationExtension) {
            $replicationExtension = Az.Migrate.Internal\Get-AzMigrateReplicationExtension -InputObject $replicationExtension
        }

        # Create replication extension if not found or previously deleted
        if ($null -eq $replicationExtension -or $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Deleted) {
            Write-Host "Waiting 2 minutes for permissions to sync before creating Replication Extension..."
            Start-Sleep -Seconds 120

            Write-Host "Creating Replication Extension..."
            $params = @{
                InstanceType                = $instanceType;
                SourceFabricArmId           = $sourceFabric.Id;
                TargetFabricArmId           = $targetFabric.Id;
                StorageAccountId            = $cacheStorageAccount.Id;
                StorageAccountSasSecretName = $null;
            }

            # Setup Replication Extension deployment parameters
            $replicationExtensionProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ReplicationExtensionModelProperties]::new()
        
            if ($instanceType -eq $AzStackHCIInstanceTypes.HyperVToAzStackHCI) {
                $replicationExtensionCustomProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.HyperVToAzStackHcireplicationExtensionModelCustomProperties]::new()
                $replicationExtensionCustomProperties.HyperVFabricArmId = $params.SourceFabricArmId
                
            }
            elseif ($instanceType -eq $AzStackHCIInstanceTypes.VMwareToAzStackHCI) {
                $replicationExtensionCustomProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.VMwareToAzStackHcireplicationExtensionModelCustomProperties]::new()
                $replicationExtensionCustomProperties.VMwareFabricArmId = $params.SourceFabricArmId
            }
            else {
                throw "Currently, for AzStackHCI scenario, only HyperV and VMware as the source is supported."
            }
            $replicationExtensionCustomProperties.InstanceType = $params.InstanceType
            $replicationExtensionCustomProperties.AzStackHCIFabricArmId = $params.TargetFabricArmId
            $replicationExtensionCustomProperties.StorageAccountId = $params.StorageAccountId
            $replicationExtensionCustomProperties.StorageAccountSasSecretName = $params.StorageAccountSasSecretName
            $replicationExtensionProperties.CustomProperty = $replicationExtensionCustomProperties

            try {
                Az.Migrate.Internal\New-AzMigrateReplicationExtension `
                    -Name $replicationExtensionName `
                    -ResourceGroupName $ResourceGroupName `
                    -VaultName $replicationVaultName `
                    -Property $replicationExtensionProperties `
                    -SubscriptionId $SubscriptionId `
                    -NoWait | Out-Null
            }
            catch {
                if ($_.Exception.Message -notmatch "Status: OK") {
                    throw $_.Exception.Message
                }
            }

            # Check replication extension creation status every 30s. Timeout after 10min
            for ($i = 0; $i -lt 20; $i++) {
                Start-Sleep -Seconds 30
                $replicationExtension = Az.Migrate.Internal\Get-AzMigrateReplicationExtension `
                    -ResourceGroupName $ResourceGroupName `
                    -Name $replicationExtensionName `
                    -VaultName $replicationVaultName `
                    -SubscriptionId $SubscriptionId `
                    -ErrorVariable notPresent `
                    -ErrorAction SilentlyContinue
                if ($null -eq $replicationExtension) {
                    throw "Unexpected error occurred during Replication Extension creation. Please re-run this command or contact support if help needed."
                }
                
                # Stop if replication extension reaches a terminal state
                if ($replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Succeeded -or
                    $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Deleted -or
                    $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Canceled -or
                    $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Failed) {
                    break
                }
            }

            # Make sure replicationExtension is in a terminal state
            if (-not (
                    $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Succeeded -or
                    $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Deleted -or
                    $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Canceled -or
                    $replicationExtension.Property.ProvisioningState -eq [ProvisioningState]::Failed)) {
                throw "Replication Extension '$($replicationExtensionName)' times out with Provisioning State: '$($replicationExtension.Property.ProvisioningState)' during creation process. Please re-run this command or contact support if help needed."
            }
        }
        
        if ($replicationExtension.Property.ProvisioningState -ne [ProvisioningState]::Succeeded) {
            throw "Replication Extension '$($replicationExtensionName)' has an unexpected Provisioning State of '$($replicationExtension.Property.ProvisioningState)'. Please re-run this command or contact support if help needed."
        }

        $replicationExtension = Az.Migrate.Internal\Get-AzMigrateReplicationExtension `
            -ResourceGroupName $ResourceGroupName `
            -Name $replicationExtensionName `
            -VaultName $replicationVaultName `
            -SubscriptionId $SubscriptionId `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $replicationExtension) {
            throw "Unexpected error occurred during Replication Extension creation. Please re-run this command or contact support if help needed."
        }
        elseif ($replicationExtension.Property.ProvisioningState -ne [ProvisioningState]::Succeeded) {
            throw "Replication Extension '$($replicationExtensionName)' has an unexpected Provisioning State of '$($replicationExtension.Property.ProvisioningState)'. Please re-run this command or contact support if help needed."
        }
        else {
            Write-Host "*Selected Replication Extension: '$($replicationExtensionName)'."
        }

        if ($PassThru) {
            return $true
        }
    }
}