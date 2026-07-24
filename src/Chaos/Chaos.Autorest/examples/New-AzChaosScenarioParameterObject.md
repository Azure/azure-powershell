### Example 1: Create a required scenario parameter
```powershell
New-AzChaosScenarioParameterObject -Name 'region' -Type 'string' -Required $true -Description 'The Azure region to target.'
```

```output
Name   Type   Required
----   ----   --------
region string True
```

Creates an in-memory required scenario parameter. Pass the result to `New-AzChaosScenario -Parameter`.

### Example 2: Create an optional scenario parameter with a default
```powershell
New-AzChaosScenarioParameterObject -Name 'duration' -Type 'string' -Required $false -Default 'PT10M'
```

```output
Name     Type   Required Default
----     ----   -------- -------
duration string False    PT10M
```

Creates an optional scenario parameter with a default value of ten minutes.
