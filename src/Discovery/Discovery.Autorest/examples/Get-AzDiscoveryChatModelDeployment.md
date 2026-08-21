### Example 1: List all chat model deployments in a workspace
```powershell
Get-AzDiscoveryChatModelDeployment -ResourceGroupName "my-rg" -WorkspaceName "my-workspace"
```

```output
Location    Name                ResourceGroupName
--------    ----                -----------------
eastus      my-chat-model       my-rg
```

Lists all chat model deployments under the specified workspace.

### Example 2: Get a specific chat model deployment
```powershell
Get-AzDiscoveryChatModelDeployment -ResourceGroupName "my-rg" -WorkspaceName "my-workspace" -Name "my-chat-model"
```

```output
Location    Name                ResourceGroupName    ProvisioningState
--------    ----                -----------------    -----------------
eastus      my-chat-model       my-rg                Succeeded
```

Gets a specific chat model deployment by name.
