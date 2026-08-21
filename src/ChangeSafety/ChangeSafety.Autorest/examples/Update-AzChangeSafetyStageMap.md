### Example 1: Update a StageMap with additional stages
```powershell
Update-AzChangeSafetyStageMap -Name "prod-deployment-stages" `
    -ResourceGroupName "rg-changeops" `
    -Stage @(
        @{ name = "canary"; sequence = 1 },
        @{ name = "staging"; sequence = 2 },
        @{ name = "production"; sequence = 3 }
    )
```

```output
Name                   ResourceGroupName ProvisioningState
----                   ----------------- -----------------
prod-deployment-stages rg-changeops      Succeeded
```

Updates an existing StageMap to add a new staging stage between canary and production.

### Example 2: Update a StageMap stage variables
```powershell
Update-AzChangeSafetyStageMap -Name "regional-rollout" `
    -ResourceGroupName "rg-changeops" `
    -Stage @(
        @{ 
            name = "eastus-canary"
            sequence = 1
            stageVariables = @{
                region = "eastus"
                replicas = 2
                enableMonitoring = $true
                timeout = 3600
            }
        }
    )
```

Updates stage variables for an existing StageMap stage.

