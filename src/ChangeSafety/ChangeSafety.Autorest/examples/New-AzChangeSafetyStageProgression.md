### Example 1: Start a stage progression (set to InProgress)
```powershell
New-AzChangeSafetyStageProgression -Name "canary-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -StageReference "canary" `
    -Status "InProgress" `
    -Comment "Starting canary deployment"
```

```output
Name               ChangeRecordName StageReference Status     ProvisioningState
----               ---------------- -------------- ------     -----------------
canary-progression appDeploymentV2  canary         InProgress Succeeded
```

Creates a StageProgression to start the canary stage of a deployment. This puts the ChangeRecord in an active state for the specified stage.

### Example 2: Create a stage progression with stage variables
```powershell
New-AzChangeSafetyStageProgression -Name "prod-eastus-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -StageReference "eastus-prod" `
    -Status "InProgress" `
    -StageVariable @{
        region = "eastus"
        replicas = 3
        featureFlags = @("new-ui", "enhanced-logging")
    } `
    -Comment "Starting production deployment in East US"
```

```output
Name                    ChangeRecordName StageReference Status     ProvisioningState
----                    ---------------- -------------- ------     -----------------
prod-eastus-progression appDeploymentV2  eastus-prod    InProgress Succeeded
```

Creates a StageProgression with stage-specific variables that can be used during the deployment.

