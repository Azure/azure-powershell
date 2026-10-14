### Example 1: Create a new chat model deployment
```powershell
New-AzDiscoveryChatModelDeployment -ResourceGroupName "my-rg" -WorkspaceName "my-workspace" -Name "my-chat-model" -Location "eastus" -ModelFormat "OpenAI" -ModelName "gpt-4o" -ModelVersion "2024-05-13" -SkuName "Standard" -Capacity 1
```

```output
Location    Name                ResourceGroupName    ProvisioningState
--------    ----                -----------------    -----------------
eastus      my-chat-model       my-rg                Succeeded
```

Creates a new chat model deployment under the specified workspace.
