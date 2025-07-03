
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
Starts replication for the specified server.
.Description
The New-AzMigrateLocalServerReplication cmdlet starts the replication for a particular discovered server in the Azure Migrate project.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratelocalserverreplication
#>
function New-AzMigrateLocalServerReplication {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PreviewMessageAttribute("This cmdlet is based on a preview API version and may experience breaking changes in future releases.")]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.IJobModel])]
    [CmdletBinding(DefaultParameterSetName = 'ByIdDefaultUser', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'ByIdDefaultUser', Mandatory)]
        [Parameter(ParameterSetName = 'ByIdPowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the machine ARM ID of the discovered server to be migrated.
        ${MachineId}, 

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the storage path ARM ID where the VMs will be stored.
        ${TargetStoragePathId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Int32]
        # Specifies the number of CPU cores.
        ${TargetVMCPUCore},

        [Parameter(ParameterSetName = 'ByIdDefaultUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the logical network ARM ID that the VMs will use. 
        ${TargetVirtualSwitchId},

        [Parameter(ParameterSetName = 'ByIdDefaultUser')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the test logical network ARM ID that the VMs will use. 
        ${TargetTestVirtualSwitchId},

        [Parameter()]
        [ValidateSet("true" , "false")]
        [ArgumentCompleter( { "true" , "false" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies if RAM is dynamic or not. 
        ${IsDynamicMemoryEnabled},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Int64]
        # Specifies the target RAM size in MB. 
        ${TargetVMRam},

        [Parameter(ParameterSetName = 'ByIdPowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.AzLocalDiskInput[]]
        # Specifies the disks on the source server to be included for replication.
        ${DiskToInclude},

        [Parameter(ParameterSetName = 'ByIdPowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.AzLocalNicInput[]]
        # Specifies the NICs on the source server to be included for replication.
        ${NicToInclude},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the target Resource Group Id where the migrated VM resources will reside.
        ${TargetResourceGroupId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the name of the VM to be created.
        ${TargetVMName},

        [Parameter(ParameterSetName = 'ByIdDefaultUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Operating System disk for the source server to be migrated.
        ${OSDiskID},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the source appliance name for the AzLocal scenario.
        ${SourceApplianceName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the target appliance name for the AzLocal scenario.
        ${TargetApplianceName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
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
        Import-Module $PSScriptRoot\Helper\AzLocalCommonSettings.ps1
        Import-Module $PSScriptRoot\Helper\CommonHelper.ps1

        CheckResourceGraphModuleDependency
        CheckResourcesModuleDependency

        $HasTargetVMCPUCore = $PSBoundParameters.ContainsKey('TargetVMCPUCore')
        $HasIsDynamicMemoryEnabled = $PSBoundParameters.ContainsKey('IsDynamicMemoryEnabled')
        if ($HasIsDynamicMemoryEnabled) {
            $isDynamicRamEnabled = [System.Convert]::ToBoolean($IsDynamicMemoryEnabled)
        }
        $HasTargetVMRam = $PSBoundParameters.ContainsKey('TargetVMRam')
        $HasTargetTestVirtualSwitchId = $PSBoundParameters.ContainsKey('TargetTestVirtualSwitchId')
        $parameterSet = $PSCmdlet.ParameterSetName
        
        $MachineIdArray = $MachineId.Split("/")
        if ($MachineIdArray.Length -lt 11) {
            throw "Invalid machine ARM ID '$MachineId'"
        }
        $SiteType = $MachineIdArray[7]
        $SiteName = $MachineIdArray[8]
        $ResourceGroupName = $MachineIdArray[4]
        $MachineName = $MachineIdArray[10]

        # Get the source site and the discovered machine
        if (($SiteType -ne $SiteTypes.HyperVSites) -and ($SiteType -ne $SiteTypes.VMwareSites)) {
            throw "Site type is not supported. Site type '$SiteType'. Check MachineId provided."
        }
        
        if ($SiteType -eq $SiteTypes.HyperVSites) {
            $instanceType = $AzLocalInstanceTypes.HyperVToAzLocal
            $machine = InvokeAzMigrateGetCommandWithRetries `
                -CommandName 'Az.Migrate.Internal\Get-AzMigrateHyperVMachine' `
                -Parameters @{
                    'ResourceGroupName' = $ResourceGroupName;
                    'SiteName' = $SiteName;
                    'MachineName' = $MachineName;
                } `
                -ErrorMessage "Machine '$MachineName' not found in resource group '$ResourceGroupName' and site '$SiteName'."

            $siteObject = InvokeAzMigrateGetCommandWithRetries `
                -CommandName 'Az.Migrate.Internal\Get-AzMigrateHyperVSite' `
                -Parameters @{
                    'ResourceGroupName' = $ResourceGroupName;
                    'SiteName' = $SiteName;
                } `
                -ErrorMessage "Machine site '$SiteName' with Type '$SiteType' not found."
        }
        else {
            $instanceType = $AzLocalInstanceTypes.VMwareToAzLocal
            $machine = InvokeAzMigrateGetCommandWithRetries `
                -CommandName 'Az.Migrate.Internal\Get-AzMigrateMachine' `
                -Parameters @{
                    'ResourceGroupName' = $ResourceGroupName;
                    'SiteName' = $SiteName;
                    'MachineName' = $MachineName;
                } `
                -ErrorMessage "Machine '$MachineName' not found in resource group '$ResourceGroupName' and site '$SiteName'."

            $siteObject = InvokeAzMigrateGetCommandWithRetries `
                -CommandName 'Az.Migrate\Get-AzMigrateSite' `
                -Parameters @{
                    'ResourceGroupName' = $ResourceGroupName;
                    'SiteName' = $SiteName;
                } `
                -ErrorMessage "Machine site '$SiteName' with Type '$SiteType' not found."
        }

        # Validate the VM
        ValidateReplication -Machine $machine -MigrationType $instanceType
        
        # $siteObject is not null or exception would have been thrown
        $ProjectName = $siteObject.DiscoverySolutionId.Split("/")[8]

        # Get Data Replication Service, or the AMH solution
        $amhSolutionName = "Servers-Migration-ServerMigration_DataReplication"
        $amhSolution = InvokeAzMigrateGetCommandWithRetries `
            -CommandName 'Az.Migrate\Get-AzMigrateSolution' `
            -Parameters @{
                "ResourceGroupName" = $ResourceGroupName;
                "Name" = $amhSolutionName;
                "MigrateProjectName" = $ProjectName;
            } `
            -ErrorMessage "No Data Replication Service Solution '$amhSolutionName' found in resource group '$ResourceGroupName' and project '$ProjectName'. Please verify your appliance setup."
        
        # Validate replication vault
        $replicationVaultName = $amhSolution.DetailExtendedDetail["vaultId"].Split("/")[8]
        if ([string]::IsNullOrEmpty($replicationVaultName)) {
            throw "No Replication Vault found. Please verify your Azure Migrate project setup."
        }
        $replicationVault = InvokeAzMigrateGetCommandWithRetries `
            -CommandName "Az.Migrate.Internal\Get-AzMigrateVault" `
            -Parameters @{
                "ResourceGroupName" = $ResourceGroupName;
                "Name" = $replicationVaultName
            } `
            -ErrorMessage "No Replication Vault '$replicationVaultName' found in Resource Group '$ResourceGroupName'. Please verify your Azure Migrate project setup."

        # Access Discovery Service
        $discoverySolutionName = "Servers-Discovery-ServerDiscovery"
        $discoverySolution = InvokeAzMigrateGetCommandWithRetries `
            -CommandName "Az.Migrate\Get-AzMigrateSolution" `
            -Parameters @{
                "SubscriptionId" = $SubscriptionId;
                "ResourceGroupName" = $ResourceGroupName;
                "MigrateProjectName" = $ProjectName;
                "Name" = $discoverySolutionName;
            } `
            -ErrorMessage "Server Discovery Solution '$discoverySolutionName' not found."

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
        if (-not ($sourceSiteId -match $hyperVSiteTypeRegex -and $targetSiteId -match $hyperVSiteTypeRegex) -and
            -not ($sourceSiteId -match $vmwareSiteTypeRegex -and $targetSiteId -match $hyperVSiteTypeRegex)) {
            throw "Error encountered in matching the given source appliance name '$SourceApplianceName' and target appliance name '$TargetApplianceName'. Please verify the VM site type to be either for HyperV or VMware for both source and target appliances, and the appliance names are correct."
        }
        
        # Get healthy asrv2 fabrics in the resource group
        $allFabrics = Az.Migrate\Get-AzMigrateLocalReplicationFabric -ResourceGroupName $ResourceGroupName | Where-Object {
            $_.Property.ProvisioningState -eq [ProvisioningState]::Succeeded -and
            $_.Property.CustomProperty.MigrationSolutionId -eq $amhSolution.Id
        }

        # Filter for source fabric
        if ($instanceType -eq $AzLocalInstanceTypes.HyperVToAzLocal)
        {
            $fabricInstanceType = $FabricInstanceTypes.HyperVInstance
        }
        else { # $instanceType -eq $AzLocalInstanceTypes.VMwareToAzLocal
            $fabricInstanceType = $FabricInstanceTypes.VmwareInstance
        }

        $sourceFabric = $allFabrics | Where-Object {
            $_.Property.CustomProperty.InstanceType -ceq $fabricInstanceType -and
            $_.Name.StartsWith($SourceApplianceName, [System.StringComparison]::InvariantCultureIgnoreCase)
        }

        if ($null -eq $sourceFabric)
        {
            throw "Couldn't find connected source appliance with the name '$SourceApplianceName'. Deploy a source appliance by completing the Discover step of migration for your on-premises environment."
        }

        # Get source fabric agent (dra)
        $sourceDraErrorMessage = "The source appliance '$SourceApplianceName' is in a disconnected state. Ensure that the source appliance is running and has connectivity before proceeding."
        $sourceDras = InvokeAzMigrateGetCommandWithRetries `
            -CommandName 'Az.Migrate.Internal\Get-AzMigrateFabricAgent' `
            -Parameters @{
                FabricName = $sourceFabric.Name;
                ResourceGroupName = $ResourceGroupName
            } `
            -ErrorMessage $sourceDraErrorMessage
        $sourceDra = $sourceDras | Where-Object {
            $_.Property.MachineName -eq $SourceApplianceName -and
            $_.Property.CustomProperty.InstanceType -eq $fabricInstanceType -and
            $_.Property.IsResponsive -eq $true
        }

        if ($null -eq $sourceDra)
        {
            throw $sourceDraErrorMessage
        }
        $sourceDra = $sourceDra[0]

        # Filter for target fabric
        $fabricInstanceType = $FabricInstanceTypes.AzLocalInstance
        $targetFabric = $allFabrics | Where-Object {
            $_.Property.CustomProperty.InstanceType -ceq $fabricInstanceType -and
            $_.Name.StartsWith($TargetApplianceName, [System.StringComparison]::InvariantCultureIgnoreCase)
        }

        if ($null -eq $targetFabric)
        {
            throw "Couldn't find connected target appliance with the name '$TargetApplianceName'. Deploy a target appliance by completing the Configuration step of migration for your Azure Local environment."
        }

        # Get target fabric agent (dra)
        $targetDraErrorMessage = "The target appliance '$TargetApplianceName' is in a disconnected state. Ensure that the target appliance is running and has connectivity before proceeding."
        $targetDras = InvokeAzMigrateGetCommandWithRetries `
            -CommandName 'Az.Migrate.Internal\Get-AzMigrateFabricAgent' `
            -Parameters @{
                FabricName = $targetFabric.Name;
                ResourceGroupName = $ResourceGroupName
            } `
            -ErrorMessage $targetDraErrorMessage
        $targetDra = $targetDras | Where-Object {
            $_.Property.MachineName -eq $TargetApplianceName -and
            $_.Property.CustomProperty.InstanceType -eq $fabricInstanceType -and
            $_.Property.IsResponsive -eq $true
        }

        if ($null -eq $targetDra)
        {
            throw $targetDraErrorMessage
        }
        $targetDra = $targetDras[0]

        # Validate Policy
        $policyName = $replicationVaultName + $instanceType + "policy"
        $policy = InvokeAzMigrateGetCommandWithRetries `
            -CommandName 'Az.Migrate.Internal\Get-AzMigratePolicy' `
            -Parameters @{
                ResourceGroupName = $ResourceGroupName;
                Name = $policyName;
                VaultName = $replicationVaultName;
            } `
            -ErrorMessage "The replication policy '$policyName' not found. The replication infrastructure is not initialized. Run the Initialize-AzMigrateLocalReplicationInfrastructure command."
        if ($policy.Property.ProvisioningState -ne [ProvisioningState]::Succeeded) {
            throw "The replication policy '$policyName' is not in a valid state. The provisioning state is '$($policy.Property.ProvisioningState)'. Re-run the Initialize-AzMigrateLocalReplicationInfrastructure command."
        }

        # Validate Replication Extension
        $replicationExtensionName = ($sourceFabric.Id -split '/')[-1] + "-" + ($targetFabric.Id -split '/')[-1] + "-MigReplicationExtn"
        $replicationExtension = InvokeAzMigrateGetCommandWithRetries `
            -CommandName 'Az.Migrate.Internal\Get-AzMigrateReplicationExtension' `
            -Parameters @{
                ResourceGroupName = $ResourceGroupName;
                Name = $replicationExtensionName;
                VaultName = $replicationVaultName;
            } `
            -ErrorMessage "The replication extension '$replicationExtensionName' not found. The replication infrastructure is not initialized. Run the Initialize-AzMigrateLocalReplicationInfrastructure command."
        if ($replicationExtension.Property.ProvisioningState -ne [ProvisioningState]::Succeeded) {
            throw "The replication extension '$replicationExtensionName' is not in a valid state. The provisioning state is '$($replicationExtension.Property.ProvisioningState)'. Re-run the Initialize-AzMigrateLocalReplicationInfrastructure command."
        }
        
        # Get Target cluster
        $targetClusterId = $targetFabric.Property.CustomProperty.Cluster.ResourceName
        $targetClusterIdArray = $targetClusterId.Split("/")
        $targetSubscription = $targetClusterIdArray[2]
        $hciClusterArgQuery = GetHCIClusterARGQuery -HCIClusterID $targetClusterId
        $targetCluster = Az.ResourceGraph\Search-AzGraph -Query $hciClusterArgQuery -Subscription $targetSubscription
        if ($null -eq $targetCluster) {
            throw "Validate target cluster with id '$targetClusterId' exists. Check ARC resource bridge is running on this cluster."
        }
            
        # Get source appliance RunAsAccount
        if ($SiteType -eq $SiteTypes.HyperVSites) {
            $runAsAccounts = InvokeAzMigrateGetCommandWithRetries `
                -CommandName 'Az.Migrate.Internal\Get-AzMigrateHyperVRunAsAccount' `
                -Parameters @{
                    ResourceGroupName = $ResourceGroupName;
                    SiteName = $SiteName;
                } `
                -ErrorMessage "No run as account found for site '$SiteName'."

            $runAsAccount = $runAsAccounts | Where-Object { $_.CredentialType -eq $RunAsAccountCredentialTypes.HyperVFabric }
        }
        elseif ($SiteType -eq $SiteTypes.VMwareSites) {
            $runAsAccounts = InvokeAzMigrateGetCommandWithRetries `
                -CommandName 'Az.Migrate\Get-AzMigrateRunAsAccount' `
                -Parameters @{
                    ResourceGroupName = $ResourceGroupName;
                    SiteName = $SiteName;
                } `
                -ErrorMessage "No run as account found for site '$SiteName'."

            $runAsAccount = $runAsAccounts | Where-Object { $_.CredentialType -eq $RunAsAccountCredentialTypes.VMwareFabric }
        }

        # Validate TargetVMName
        if ($TargetVMName.length -gt 64 -or $TargetVMName.length -eq 0) {
            throw "The target virtual machine name must be between 1 and 64 characters long."
        }
        elseif ($TargetVMName -notmatch "^[^_\W][a-zA-Z0-9\-]{0,63}(?<![-._])$") {
            throw "The target virtual machine name must begin with a letter or number, and can contain only letters, numbers, or hyphens(-). The names cannot contain special characters \/""[]:|<>+=;,?*@&, whitespace, or begin with '_' or end with '.' or '-'."
        }
        elseif (IsReservedOrTrademarked($TargetVMName)) {
            throw "The target virtual machine name '$TargetVMName' or part of the name is a trademarked or reserved word."
        }

        # Construct create protected item request object
        $protectedItemProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.ProtectedItemModelProperties]::new()
        $protectedItemProperties.PolicyName = $policyName
        $protectedItemProperties.ReplicationExtensionName = $replicationExtensionName

        if ($SiteType -eq $SiteTypes.HyperVSites) {     
            $customProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.HyperVToAzStackHCIProtectedItemModelCustomProperties]::new()
            $isSourceDynamicMemoryEnabled = $machine.IsDynamicMemoryEnabled
        }
        elseif ($SiteType -eq $SiteTypes.VMwareSites) {  
            $customProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.VMwareToAzStackHCIProtectedItemModelCustomProperties]::new()
            $isSourceDynamicMemoryEnabled = $false
        }

        $customProperties.InstanceType = $instanceType
        $customProperties.CustomLocationRegion = $targetCluster.CustomLocationRegion
        $customProperties.FabricDiscoveryMachineId = $machine.Id
        $customProperties.RunAsAccountId = $runAsAccount.Id
        $customProperties.SourceFabricAgentName = $sourceDra.Name
        $customProperties.StorageContainerId = $TargetStoragePathId
        $customProperties.TargetArcClusterCustomLocationId = $targetCluster.CustomLocation
        $customProperties.TargetFabricAgentName = $targetDra.Name
        $customProperties.TargetHciClusterId = $targetClusterId
        $customProperties.TargetResourceGroupId = $TargetResourceGroupId
        $customProperties.TargetVMName = $TargetVMName
        $customProperties.TargetCpuCore = if ($HasTargetVMCPUCore) { $TargetVMCPUCore } else { $machine.NumberOfProcessorCore }
        $customProperties.IsDynamicRam = if ($HasIsDynamicMemoryEnabled) { $isDynamicRamEnabled } else {  $isSourceDynamicMemoryEnabled }
    
        # Determine target VM Hyper-V Generation
        if ($SiteType -eq $SiteTypes.HyperVSites) { 
            # Hyper-V source
            $customProperties.HyperVGeneration = $machine.Generation
        }
        else { 
            #Vmware source, non-BOIS VMs will be migrated to Gen2
            $customProperties.HyperVGeneration = if ($machine.Firmware -ieq "BIOS") { "1" } else { "2" }
        }

        # Validate TargetVMRam
        if ($HasTargetVMRam) {
            # TargetVMRam needs to be greater than 0
            if ($TargetVMRam -le 0) {
                throw "Specify a target RAM that is greater than 0"    
            }

            $customProperties.TargetMemoryInMegaByte = $TargetVMRam 
        }
        else
        {
            $customProperties.TargetMemoryInMegaByte = [System.Math]::Max($machine.AllocatedMemoryInMB, $RAMConfig.MinTargetMemoryInMB)
        }

        # Construct default dynamic memory config
        $memoryConfig = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.ProtectedItemDynamicMemoryConfig]::new()
        $memoryConfig.MinimumMemoryInMegaByte = [System.Math]::Min($customProperties.TargetMemoryInMegaByte, $RAMConfig.DefaultMinDynamicMemoryInMB)
        $memoryConfig.MaximumMemoryInMegaByte = [System.Math]::Max($customProperties.TargetMemoryInMegaByte, $RAMConfig.DefaultMaxDynamicMemoryInMB)
        $memoryConfig.TargetMemoryBufferPercentage = $RAMConfig.DefaultTargetMemoryBufferPercentage

        $customProperties.DynamicMemoryConfig = $memoryConfig
        
        # Disks and Nics
        [PSCustomObject[]]$disks = @()
        [PSCustomObject[]]$nics = @()
        if ($parameterSet -match 'DefaultUser') {
            if ($SiteType -eq $SiteTypes.HyperVSites) {
                $osDisk = $machine.Disk | Where-Object { $_.InstanceId -eq $OSDiskID }
                if ($null -eq $osDisk) {
                    throw "No Disk found with InstanceId $OSDiskID from discovered machine disks."
                }

                $diskName = Split-Path $osDisk.Path -leaf
                if (IsReservedOrTrademarked($diskName)) {
                    throw "The disk name $diskName or part of the name is a trademarked or reserved word."
                }
            }
            elseif ($SiteType -eq $SiteTypes.VMwareSites) {  
                $osDisk = $machine.Disk | Where-Object { $_.Uuid -eq $OSDiskID }
                if ($null -eq $osDisk) {
                    throw "No Disk found with Uuid $OSDiskID from discovered machine disks."
                }

                $diskName = Split-Path $osDisk.Path -leaf
                if (IsReservedOrTrademarked($diskName)) {
                    throw "The disk name $diskName or part of the name is a trademarked or reserved word."
                }
            }

            foreach ($sourceDisk in $machine.Disk) {
                $diskId = if ($SiteType -eq $SiteTypes.HyperVSites) { $sourceDisk.InstanceId } else { $sourceDisk.Uuid }
                $diskSize = if ($SiteType -eq $SiteTypes.HyperVSites) { $sourceDisk.MaxSizeInByte } else { $sourceDisk.MaxSizeInBytes }

                $DiskObject = [PSCustomObject]@{
                    DiskId         = $diskId
                    DiskSizeGb     = [long] [Math]::Ceiling($diskSize / 1GB)
                    DiskFileFormat = "VHDX"
                    IsDynamic      = $true
                    IsOSDisk       = $diskId -eq $OSDiskID
                }
                
                $disks += $DiskObject
            }
            
            foreach ($sourceNic in $machine.NetworkAdapter) {
                $NicObject = [PSCustomObject]@{
                    NicId                    = $sourceNic.NicId
                    TargetNetworkId          = $TargetVirtualSwitchId
                    TestNetworkId            = if ($HasTargetTestVirtualSwitchId) { $TargetTestVirtualSwitchId } else { $TargetVirtualSwitchId }
                    SelectionTypeForFailover = $VMNicSelection.SelectedByUser
                }
                $nics += $NicObject
            }
        }
        else
        {
            # PowerUser
            if ($null -eq $DiskToInclude -or $DiskToInclude.length -eq 0) {
                throw "Invalid DiskToInclude. At least one disk is required."
            }

            # Validate OSDisk is set.
            $osDisk = $DiskToInclude | Where-Object { $_.IsOSDisk }
            if (($null -eq $osDisk) -or ($osDisk.length -ne 1)) {
                throw "Invalid DiskToInclude. One disk must be designated as the OS disk."
            }
            
            # Validate DiskToInclude
            [PSCustomObject[]]$uniqueDisks = @()
            foreach ($disk in $DiskToInclude) {
                # VHD is not supported in Gen2 VMs
                if ($customProperties.HyperVGeneration -eq "2" -and $disk.DiskFileFormat -eq "VHD") {
                    throw "VHD disks are not supported in Hyper-V Generation 2 VMs. Please replace disk with id '$($disk.DiskId)' in -DiskToInclude by re-running New-AzMigrateLocalDiskMappingObject with 'VHDX' as Format."
                }

                # PhysicalSectorSize must be 512 for VHD format
                if ($disk.DiskFileFormat -eq "VHD" -and $disk.DiskPhysicalSectorSize -ne 512) {
                    throw "PhysicalSectorSize must be 512 for VHD format. Please replace disk with id '$($disk.DiskId)' in -DiskToInclude by re-running New-AzMigrateLocalDiskMappingObject with 512 as PhysicalSectorSize."
                }

                if ($SiteType -eq $SiteTypes.HyperVSites) {
                    $discoveredDisk = $machine.Disk | Where-Object { $_.InstanceId -eq $disk.DiskId }
                    if ($null -eq $discoveredDisk) {
                        throw "No Disk found with InstanceId '$($disk.DiskId)' from discovered machine disks."
                    }
                }
                elseif ($SiteType -eq $SiteTypes.VMwareSites) {  
                    $discoveredDisk = $machine.Disk | Where-Object { $_.Uuid -eq $disk.DiskId }
                    if ($null -eq $discoveredDisk) {
                        throw "No Disk found with Uuid '$($disk.DiskId)' from discovered machine disks."
                    }
                }

                $diskName = Split-Path -Path $discoveredDisk.Path -Leaf
                if (IsReservedOrTrademarked($diskName)) {
                    throw "The disk name $diskName or part of the name is a trademarked or reserved word."
                }

                if ($uniqueDisks.Contains($disk.DiskId)) {
                    throw "The disk id '$($disk.DiskId)' is already taken."
                }
                $uniqueDisks += $disk.DiskId

                $htDisk = @{}
                $disk.PSObject.Properties | ForEach-Object { $htDisk[$_.Name] = $_.Value }
                $disks += [PSCustomObject]$htDisk
            }

            # Validate NicToInclude
            [PSCustomObject[]]$uniqueNics = @()
            foreach ($nic in $NicToInclude) {
                $discoveredNic = $machine.NetworkAdapter | Where-Object { $_.NicId -eq $nic.NicId }
                if ($null -eq $discoveredNic) {
                    throw "The Nic id '$($nic.NicId)' is not found."
                }

                if ($uniqueNics.Contains($nic.NicId)) {
                    throw "The Nic id '$($nic.NicId)' is already included. Please remove the duplicate entry and try again."
                }

                $uniqueNics += $nic.NicId
                
                $htNic = @{}
                $nic.PSObject.Properties | ForEach-Object { $htNic[$_.Name] = $_.Value }

                if ($htNic.SelectionTypeForFailover -eq $VMNicSelection.SelectedByUser -and
                    [string]::IsNullOrEmpty($htNic.TargetNetworkId)) {
                    throw throw "The TargetVirtualSwitchId parameter is required when the CreateAtTarget flag is set to 'true'. NIC '$($htNic.NicId)'. Please utilize the New-AzMigrateLocalNicMappingObject command to properly create a Nic mapping object."
                }

                $nics += [PSCustomObject]$htNic
            }
        }

        if ($SiteType -eq $SiteTypes.HyperVSites) {     
            $customProperties.DisksToInclude = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.HyperVToAzStackHCIDiskInput[]]$disks
            $customProperties.NicsToInclude = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.HyperVToAzStackHCINicInput[]]$nics
        }
        elseif ($SiteType -eq $SiteTypes.VMwareSites) {     
            $customProperties.DisksToInclude = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.VMwareToAzStackHCIDiskInput[]]$disks
            $customProperties.NicsToInclude = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.VMwareToAzStackHCINicInput[]]$nics
        }
        
        $protectedItemProperties.CustomProperty = $customProperties

        if ($PSCmdlet.ShouldProcess($MachineId, "Replicate VM.")) {
            $operation = Az.Migrate.Internal\New-AzMigrateProtectedItem `
                -Name $MachineName `
                -ResourceGroupName $ResourceGroupName `
                -VaultName $replicationVaultName `
                -Property $protectedItemProperties `
                -NoWait:$true

            $jobName = $operation.Target.Split("/")[-1].Split("?")[0].Split("_")[0]
            return Az.Migrate.Internal\Get-AzMigrateLocalReplicationJob `
                -Name $jobName `
                -ResourceGroupName $ResourceGroupName `
                -VaultName $replicationVaultName
        }
    }
}