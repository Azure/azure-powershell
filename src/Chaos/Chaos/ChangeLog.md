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
* Re-targeted `Az.Chaos` to the Chaos Studio V2 `Microsoft.Chaos` `2026-05-01-preview` API.
    - Removed the V1 experiment cmdlets: `Get/New/Update/Remove-AzChaosExperiment`, `Start/Stop-AzChaosExperiment`, `Get-AzChaosExperimentExecution`, `Get-AzChaosExecutionExperimentDetail`, `Get/New/Update/Remove-AzChaosCapability`, `Get-AzChaosCapabilityType`, `Get/New/Update/Remove-AzChaosTarget`, `Get-AzChaosTargetType`.
    - Removed the V1 model helper cmdlets: `New-AzChaosActionObject`, `New-AzChaosBranchObject`, `New-AzChaosSelectorObject`, `New-AzChaosStepObject`.
* Added the V2 workspace cmdlets: `Get/New/Update/Remove-AzChaosWorkspace` and `Update-AzChaosWorkspaceRecommendation`.
* Added the V2 scenario cmdlets: `Get/New/Remove-AzChaosScenario`.
* Added the V2 scenario configuration cmdlets: `Get/New/Remove-AzChaosScenarioConfiguration`, `Test-AzChaosScenarioConfiguration`, `Invoke-AzChaosScenarioConfigurationExecution`, and `Repair-AzChaosScenarioConfigurationResourcePermission`.
* Added the V2 scenario run cmdlets: `Get/Stop-AzChaosScenarioRun`.
* Added `Get-AzChaosDiscoveredResource` to list the resources a workspace discovers.
* Added the V2 model helper cmdlets: `New-AzChaosScenarioActionObject`, `New-AzChaosScenarioParameterObject`, `New-AzChaosRunAfterObject`, `New-AzChaosExternalResourceObject`, `New-AzChaosKeyValuePairObject`, `New-AzChaosConfigurationFiltersObject`, and `New-AzChaosConfigurationExclusionsObject`.
* Added three workflow cmdlets that wrap the multi-step V2 operations:
    - `Start-AzChaosScenarioRun` validates a scenario configuration before it starts the run and guards catalog scenarios that the workspace has not evaluated.
    - `Invoke-AzChaosWorkspaceScenarioEvaluation` discovers and evaluates a workspace in one step.
    - `Initialize-AzChaosWorkspace` stands up a ready-to-use workspace end to end.
* Exposed the server-side `whatIf` field on `Repair-AzChaosScenarioConfigurationResourcePermission` as `-WhatIfMode`, distinct from the common `-WhatIf` switch.

## Version 0.1.2
* Fixed module name in module metadata

## Version 0.1.1
* Upgraded nuget package to signed package.

## Version 0.1.0
* First preview release for module Az.Chaos

