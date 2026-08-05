### Example 1: Create a simple two-stage StageMap
```powershell
New-AzChangeSafetyStageMap -Name "prod-deployment-stages" `
    -ResourceGroupName "rg-changeops" `
    -Stage @(
        @{ name = "canary"; sequence = 1 },
        @{ name = "production"; sequence = 2 }
    )
```

```output
Name                   ResourceGroupName ProvisioningState
----                   ----------------- -----------------
prod-deployment-stages rg-changeops      Succeeded
```

Creates a StageMap with two stages: canary (runs first) and production (runs second).

### Example 2: Create a StageMap with stage variables
```powershell
New-AzChangeSafetyStageMap -Name "regional-rollout" `
    -ResourceGroupName "rg-changeops" `
    -Stage @(
        @{ 
            name = "eastus-canary"
            sequence = 1
            stageVariables = @{
                region = "eastus"
                replicas = 1
                enableMonitoring = $true
            }
        },
        @{ 
            name = "eastus-prod"
            sequence = 2
            stageVariables = @{
                region = "eastus"
                replicas = 3
                enableMonitoring = $true
            }
        },
        @{ 
            name = "westus-prod"
            sequence = 3
            stageVariables = @{
                region = "westus"
                replicas = 3
                enableMonitoring = $true
            }
        }
    )
```

```output
Name             ResourceGroupName ProvisioningState
----             ----------------- -----------------
regional-rollout rg-changeops      Succeeded
```

Creates a StageMap with three stages for regional rollout, each with stage-specific variables.

