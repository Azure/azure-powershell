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
* Migrated to Chaos Studio V2 API 2026-05-01-preview.
    - Removed V1 experiment, execution, capability, target and model helper cmdlets.
    - Added workspace, recommendation, scenario, configuration, validation, permission, run, discovery, evaluation and model helper cmdlets.
* Added `Start-AzChaosScenarioRun` with configuration validation and guards for unevaluated catalog scenarios.
* Added `Invoke-AzChaosWorkspaceScenarioEvaluation` for discovery and evaluation, and `Initialize-AzChaosWorkspace` for identity-safe setup.
* Added `Repair-AzChaosScenarioConfigurationResourcePermission -WhatIfMode` for service-side simulation, distinct from `-WhatIf`.
* Corrected scenario action and managed identity examples.
* Raised the minimum Az.Accounts version from 5.0.2 to 5.5.1.

## Version 0.1.2
* Fixed module name in module metadata

## Version 0.1.1
* Upgraded nuget package to signed package.

## Version 0.1.0
* First preview release for module Az.Chaos
