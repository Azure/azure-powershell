<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Upcoming Release

## Version 0.3.0
* Added support for operation of Synapse LinkedService
    - Add `Get-AzSynapseLinkedService` cmdlet
    - Add `Remove-AzSynapseLinkedService` cmdlet
    - Add `Set-AzSynapseLinkedService` cmdlet
    - Add `New-AzSynapseLinkedService` cmdlet
* Added support for operation of Synapse Notebook
    - Add `Get-AzSynapseNotebook` cmdlet
    - Add `Export-AzSynapseNotebook` cmdlet
    - Add `Remove-AzSynapseNotebook` cmdlet
    - Add `Set-AzSynapseNotebook` cmdlet
    - Add `New-AzSynapseNotebook` cmdlet
    - Add `Import-AzSynapseNotebook` cmdlet
* Added support for operation of Synapse Pipeline
    - Add `Get-AzSynapsePipeline` cmdlet
    - Add `Remove-AzSynapsePipeline` cmdlet
    - Add `Set-AzSynapsePipeline` cmdlet
    - Add `New-AzSynapsePipeline` cmdlet
    - Add `Get-AzSynapseActivityRun` cmdlet
    - Add `Get-AzSynapsePipelineRun` cmdlet
    - Add `Invoke-AzSynapsePipeline` cmdlet
    - Add `Stop-AzSynapsePipelineRun` cmdlet
* Added support for operation of Synapse Trigger
    - Add `Get-AzSynapseTrigger` cmdlet
    - Add `Remove-AzSynapseTrigger` cmdlet
    - Add `Set-AzSynapseTrigger` cmdlet
    - Add `New-AzSynapseTrigger` cmdlet
    - Add `Add-AzSynapseTriggerSubscription` cmdlet
    - Add `Get-AzSynapseTriggerSubscriptionStatus` cmdlet
    - Add `Remove-AzSynapseTriggerSubscription` cmdlet
    - Add `Start-AzSynapseTrigger` cmdlet
    - Add `Stop-AzSynapseTrigger` cmdlet
    - Add `Get-AzSynapseTriggerRun` cmdlet
* Added support for operation of Synapse DataFlow
    - Add `Get-AzSynapseDataFlow` cmdlet
    - Add `Remove-AzSynapseDataFlow` cmdlet
    - Add `Set-AzSynapseDataFlow` cmdlet
    - Add `New-AzSynapseDataFlow` cmdlet
* Added support for operation of Synapse Dataset
    - Add `Get-AzSynapseDataset` cmdlet
    - Add `Remove-AzSynapseDataset` cmdlet
    - Add `Set-AzSynapseDataset` cmdlet
    - Add `New-AzSynapseDataset` cmdlet
* Removed parameter sets related 'create from backup' and 'create from restore point' from the `New-AzSynapseSqlPool` cmdlet
* Removed parameter sets related 'pause' and 'resume' from the `Update-AzSynapseSqlPool`
* Added support for operation of Synapse Sql pool
    - Add `Get-AzSynapseSqlPoolRestorePoint` cmdlet
    - Add `Restore-AzSynapseSqlPool` cmdlet
    - Add `Resume-AzSynapseSqlPool` cmdlet
    - Add `Suspend-AzSynapseSqlPool` cmdlet

## Version 0.2.0

* Added support for gen3 Sql Pools
    - For `Get-AzSynapseSqlPool`, `New-AzSynapseSqlPool`, ` Remove-AzSynapseSqlPool`, ` Test-AzSynapseSqlPool` and `Update-AzSynapseSqlPool` cmdlet
        - Add Version parameter to cmdlets to specify version 3. 
        - For this release, these cmdlets will not work unless a customer's subscription is on the allowlist.
* Added support for gen3 Sql Databases
    - Add `Get-AzSynapseSqlDatabase` cmdlet
    - Add `New-AzSynapseSqlDatabase` cmdlet
    - Add `Remove-AzSynapseSqlDatabase` cmdlet
    - Add `Update-AzSynapseSqlDatabase` cmdlet
    - Add `Test-AzSynapseSqlDatabase` cmdlet
* Added support for operation of Synapse IntegrationRuntime
    - Add `Get-AzSynapseIntegrationRuntime` cmdlet
    - Add `Get-AzSynapseIntegrationRuntimeKey` cmdlet
    - Add `Get-AzSynapseIntegrationRuntimeMetric` cmdlet
    - Add `Get-AzSynapseIntegrationRuntimeNode` cmdlet
    - Add `Invoke-AzSynapseIntegrationRuntimeUpgrade` cmdlet
    - Add `New-AzSynapseIntegrationRuntimeKey` cmdlet
    - Add `Remove-AzSynapseIntegrationRuntime` cmdlet
    - Add `Remove-AzSynapseIntegrationRuntimeNode` cmdlet
    - Add `Set-AzSynapseIntegrationRuntime` cmdlet
    - Add `Sync-AzSynapseIntegrationRuntimeCredential` cmdlet
    - Add `Update-AzSynapseIntegrationRuntime` cmdlet
    - Add `Update-AzSynapseIntegrationRuntimeNode` cmdlet

## Version 0.1.2

* Changed some property names and types of output for the following cmdlets
    - For `Get-AzSynapseSparkJob`, `Submit-AzSynapseSparkJob`, ` Get-AzSynapseSparkSession` and `Start-AzSynapseSparkSession` cmdlet
        - Change JobType's type from `string` to `SparkJobType?`
        - Change AppInfo's type from `IDictionary<string, string>` to `IReadOnlyDictionary<string, string>`
        - Change ErrorInfo's type from `IList<ErrorInformation>` to `IReadOnlyList<SparkServiceError>`
        - Change Log's type from `IList<string>` to `IReadOnlyList<string>`
        - Change `Scheduler` to `Scheduler`
        - Change `PluginInfo` to `Plugin`
        - Change `ErrorInfo` to `Errors`
        - Change `Log` to `LogLines`
* Added support for operation of Synapse access control
    - Add `Get-AzSynapseRoleDefinition` cmdlet
    - Add `New-AzSynapseRoleAssignment` cmdlet
    - Add `Remove-AzSynapseRoleAssignment` cmdlet
    - Add `Get-AzSynapseRoleAssignment` cmdlet

## Version 0.1.1

* Added support for operation of Synapse FirewallRule
    - Add `New-AzSynapseFirewallRule` cmdlet 
    - Add `Remove-AzSynapseFirewallRule` cmdlet 
    - Add `Get-AzSynapseFirewallRule` cmdlet 
    - Add `Update-AzSynapseFirewallRule` cmdlet 
* Removed '-DisallowAllConnection' parameter from the 'New-AzSynapseWorkspace' cmdlet
* Updated parameter set for New-AzSynapseSparkPool to fix node count issue for auto scale

## Version 0.1.0

* Preview release of `Az.Synapse` module
