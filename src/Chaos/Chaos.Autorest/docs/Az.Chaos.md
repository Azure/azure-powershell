---
Module Name: Az.Chaos
Module Guid: 50f50ac7-1d8a-49cd-b641-5bf6d1b83acd
Download Help Link: https://learn.microsoft.com/powershell/module/az.chaos
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Chaos Module
## Description
Microsoft Azure PowerShell: Chaos cmdlets

## Az.Chaos Cmdlets
### [Get-AzChaosDiscoveredResource](Get-AzChaosDiscoveredResource.md)
Get a discovered resource.

### [Get-AzChaosScenario](Get-AzChaosScenario.md)
Get a scenario.

### [Get-AzChaosScenarioConfiguration](Get-AzChaosScenarioConfiguration.md)
Get a scenario definition.

### [Get-AzChaosScenarioRun](Get-AzChaosScenarioRun.md)
Get a scenario run.
This endpoint is also the polling target for ScenarioConfigurations.execute and ScenarioRuns.cancel (final-state-via: location).
While the run is in progress the service returns 202 with a Location header pointing back to this URL; clients must keep polling until they receive 200, which carries the final ScenarioRun body.

### [Get-AzChaosWorkspace](Get-AzChaosWorkspace.md)
Get a Workspace resource.

### [Initialize-AzChaosWorkspace](Initialize-AzChaosWorkspace.md)
Stand up a ready-to-use Chaos Studio workspace end to end.

### [Invoke-AzChaosScenarioConfigurationExecution](Invoke-AzChaosScenarioConfigurationExecution.md)
Execute the scenario execution with the given scenario configuration.

### [Invoke-AzChaosWorkspaceScenarioEvaluation](Invoke-AzChaosWorkspaceScenarioEvaluation.md)
Evaluate a workspace end to end.

### [New-AzChaosActionDependencyObject](New-AzChaosActionDependencyObject.md)
Create an in-memory object for ActionDependency.

### [New-AzChaosKeyValuePairObject](New-AzChaosKeyValuePairObject.md)
Create an in-memory object for KeyValuePair.

### [New-AzChaosScenario](New-AzChaosScenario.md)
Create a scenario.

### [New-AzChaosScenarioActionObject](New-AzChaosScenarioActionObject.md)
Create an in-memory object for ScenarioAction.

### [New-AzChaosScenarioConfiguration](New-AzChaosScenarioConfiguration.md)
Create a scenario definition.

### [New-AzChaosScenarioParameterObject](New-AzChaosScenarioParameterObject.md)
Create an in-memory object for ScenarioParameter.

### [New-AzChaosWorkspace](New-AzChaosWorkspace.md)
Create a Workspace resource.

### [Remove-AzChaosScenario](Remove-AzChaosScenario.md)
Delete a scenario.

### [Remove-AzChaosScenarioConfiguration](Remove-AzChaosScenarioConfiguration.md)
Delete a scenario definition.

### [Remove-AzChaosWorkspace](Remove-AzChaosWorkspace.md)
Delete a Workspace resource.

### [Repair-AzChaosScenarioConfigurationResourcePermission](Repair-AzChaosScenarioConfigurationResourcePermission.md)
Fixes resource permissions for the given scenario configuration.

### [Start-AzChaosScenarioRun](Start-AzChaosScenarioRun.md)
Start a scenario run for a scenario configuration.

### [Stop-AzChaosScenarioRun](Stop-AzChaosScenarioRun.md)
Cancel the currently running scenario execution.

### [Test-AzChaosScenarioConfiguration](Test-AzChaosScenarioConfiguration.md)
Validate the given scenario configuration.

### [Update-AzChaosWorkspace](Update-AzChaosWorkspace.md)
Update a Workspace resource.

### [Update-AzChaosWorkspaceRecommendation](Update-AzChaosWorkspaceRecommendation.md)
Refreshes recommendation status for all scenarios in a given workspace.

