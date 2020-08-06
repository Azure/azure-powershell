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
