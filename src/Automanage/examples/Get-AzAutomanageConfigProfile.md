### Example 1: List all configuration profiles under a subscription
```powershell
Get-AzAutomanageConfigProfile
```

```output
Location Name                         ResourceGroupName
-------- ----                         -----------------
eastus   confpro-pwsh01               automangerg
eastus   lucas-best-practices-devtest automangerg
```

This command lists all configuration profiles under a subscription.

### Example 2: List all configuration profiles under a resource group
```powershell
Get-AzAutomanageConfigProfile -ResourceGroupName automangerg
```

```output
Location Name                         ResourceGroupName
-------- ----                         -----------------
eastus   confpro-pwsh01               automangerg
eastus   lucas-best-practices-devtest automangerg
```

This command lists all configuration profiles under a resource group.

### Example 3: Get information about a configuration profile by name
```powershell
Get-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name lucas-best-practices-devtest
```

```output
Location Name                         ResourceGroupName
-------- ----                         -----------------
eastus   lucas-best-practices-devtest automangerg
```

This command gets information about a configuration profile by name.