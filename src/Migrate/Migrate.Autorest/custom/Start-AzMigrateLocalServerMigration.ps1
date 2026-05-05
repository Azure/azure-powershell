
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
Starts the migration for the replicating server.
.Description
Starts the migration for the replicating server.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/start-azmigratelocalservermigration
#>
function Start-AzMigrateLocalServerMigration {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PreviewMessageAttribute("This cmdlet is based on a preview API version and may experience breaking changes in future releases.")]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.IJobModel])]
    [CmdletBinding(DefaultParameterSetName = 'ByID', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName = 'ByID', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replcating server for which migration needs to be initiated. The ID should be retrieved using the Get-AzMigrateLocalServerReplication cmdlet.
        ${TargetObjectID},

        [Parameter(ParameterSetName = 'ByInputObject', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity]
        # Specifies the replicating server for which migration needs to be initiated. The server object can be retrieved using the Get-AzMigrateLocalServerReplication cmdlet.
        ${InputObject},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        # Specifies whether the source server should be turned off post migration.
        ${TurnOffSourceServer},
    
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
        $helperPath = [System.IO.Path]::Combine($PSScriptRoot, "Helper", "AzLocalCommonSettings.ps1")
        Import-Module $helperPath
        $helperPath = [System.IO.Path]::Combine($PSScriptRoot, "Helper", "AzLocalCommonHelper.ps1")
        Import-Module $helperPath

        CheckResourceGraphModuleDependency
        CheckResourcesModuleDependency

        $performShutDown = $TurnOffSourceServer.IsPresent
        $parameterSet = $PSCmdlet.ParameterSetName

        if ($parameterSet -eq 'ByInputObject') {
            $TargetObjectID = $InputObject.Id
        }

        $protectedItemIdArray = $TargetObjectID.Split("/")
        $resourceGroupName = $protectedItemIdArray[4]
        $vaultName = $protectedItemIdArray[8]
        $protectedItemName = $protectedItemIdArray[10]

        $protectedItem = Az.Migrate.Internal\Get-AzMigrateProtectedItem `
            -ResourceGroupName $resourceGroupName `
            -VaultName $vaultName `
            -Name $protectedItemName `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $protectedItem) {
            throw "The replicating server doesn't exist. Please check the input and try again."
        }
        elseif (
            (!$protectedItem.Property.AllowedJob.contains("PlannedFailover")) -and
            (!$ProtectedItem.Property.AllowedJob.contains("Restart"))) {
            # AllowJob must contains either 'PlannedFailover' or 'Restart' to allow migration
            throw "The replicating server cannot be migrated right now. Current protection state is '$($protectedItem.Property.ProtectionStateDescription)'."
        }

        # Get ARC Resource Bridge info
        $targetClusterId = $protectedItem.Property.CustomProperty.TargetHciClusterId
        $targetClusterIdArray = $targetClusterId.Split("/")
        $targetSubscription = $targetClusterIdArray[2]
        $arbArgQuery = GetARGQueryForArcResourceBridge -HCIClusterID $targetClusterId
        $arbArgResult = Az.ResourceGraph\Search-AzGraph -Query $arbArgQuery -Subscription $targetSubscription
        if ($null -eq $arbArgResult) {
            throw "$($ArcResourceBridgeValidationMessages.NoClusters). Validate target cluster with id '$targetClusterId' exists."
        }
        elseif ($arbArgResult.statusOfTheBridge -ne "Running") {
            throw "$($ArcResourceBridgeValidationMessages.NotRunning). Make sure the Arc Resource Bridge is online before retrying."
        }

        # Get the instance type from the protected item
        $instanceType = $protectedItem.Property.CustomProperty.InstanceType

        # Setup PlannedFailover deployment parameters
        $properties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.PlannedFailoverModelProperties]::new()
        
        if ($instanceType -eq $AzLocalInstanceTypes.HyperVToAzLocal) {
            $customProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.HyperVToAzStackHciPlannedFailoverModelCustomProperties]::new()
        }
        elseif ($instanceType -eq $AzLocalInstanceTypes.VMwareToAzLocal) {
            $customProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.VMwareToAzStackHciPlannedFailoverModelCustomProperties]::new()
        }
        else {
            throw "Currently, for AzLocal scenario, only HyperV and VMware as the source is supported."
        }
        $customProperties.InstanceType = $instanceType
        $customProperties.ShutdownSourceVM = $performShutDown
        $properties.CustomProperty = $customProperties

        if ($PSCmdlet.ShouldProcess($TargetObjectID, "Migrate VM.")) {
            $operation = Az.Migrate.Internal\Invoke-AzMigratePlannedProtectedItemFailover `
                -ResourceGroupName $resourceGroupName `
                -VaultName $vaultName `
                -ProtectedItemName $protectedItemName `
                -Property $properties `
                -NoWait

            $jobName = $operation.Target.Split("/")[-1].Split("?")[0].Split("_")[0]
            return Az.Migrate.Internal\Get-AzMigrateLocalReplicationJob `
                -ResourceGroupName $resourceGroupName `
                -VaultName $vaultName `
                -JobName $jobName
        }
    }
}