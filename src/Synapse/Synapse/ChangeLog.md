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
