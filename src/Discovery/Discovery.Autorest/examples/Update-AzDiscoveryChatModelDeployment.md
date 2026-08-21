### Example 1: Update a chat model deployment with tags
```powershell
Update-AzDiscoveryChatModelDeployment -ResourceGroupName "my-rg" -WorkspaceName "my-workspace" -Name "my-chat-model" -Tag @{Environment="Production"}
```

```output
Location    Name                ResourceGroupName    ProvisioningState
--------    ----                -----------------    -----------------
eastus      my-chat-model       my-rg                Succeeded
```

Updates the tags of an existing chat model deployment.
