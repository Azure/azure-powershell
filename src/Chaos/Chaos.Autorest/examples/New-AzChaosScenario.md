### Example 1: Create a scenario with a single action
```powershell
$action = New-AzChaosScenarioActionObject -Name 'stop-vm' -ActionId 'microsoft-compute-shutdown/1.0' -Duration 'PT10M'
New-AzChaosScenario -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Name contoso-scenario -Description 'Shut down the target virtual machine.' -Action $action
```

```output
Name             ResourceGroupName ProvisioningState
----             ----------------- -----------------
contoso-scenario contoso-rg        Succeeded
```

Creates the `contoso-scenario` scenario with one shutdown action built by `New-AzChaosScenarioActionObject`. Use the expanded parameter set when you want PowerShell to build the request body for you; `-Action` and `-Description` are required for this form.

### Example 2: Create a scenario from a JSON file
```powershell
New-AzChaosScenario -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Name contoso-scenario -JsonFilePath .\scenario.json
```

```output
Name             ResourceGroupName ProvisioningState
----             ----------------- -----------------
contoso-scenario contoso-rg        Succeeded
```

Creates a scenario from a hand-authored JSON payload on disk. Use `-JsonFilePath` when the full scenario body, including its description and actions, already exists in a file.
