### Example 1: Lists user assigned identity under a subscription
```powershell
PS C:\>  Get-AzUserAssignedIdentity

Location      Name                                ResourceGroupName
--------      ----                                -----------------
eastus        AzSecPackAutoConfigUA-eastus        AzSecPackAutoConfigRG
eastus        uai-pwsh01                          azure-rg-test
eastus2       AzSecPackAutoConfigUA-eastus2       AzSecPackAutoConfigRG
```

This command lists user assigned identity under a subscription.

### Example 2: List user assigned identity under a resource group
```powershell
PS C:\> Get-AzUserAssignedIdentity -ResourceGroupName azure-rg-test

Location Name       ResourceGroupName
-------- ----       -----------------
eastus   uai-pwsh01 azure-rg-test
```

This command lists user assigned identity under a resource group.

### Example 3: Get an user assigned identity
```powershell
PS C:\> Get-AzUserAssignedIdentity -ResourceGroupName azure-rg-test -Name uai-pwsh01

Location Name       ResourceGroupName
-------- ----       -----------------
eastus   uai-pwsh01 azure-rg-test
```

This command gets an user assigned identity.

### Example 4: Get an user assigned identity by pipeline
```powershell
PS C:\> New-AzUserAssignedIdentity -ResourceGroupName azure-rg-test -Name uai-pwsh01 -Location eastus
 | Get-AzUserAssignedIdentity

Location Name       ResourceGroupName
-------- ----       -----------------
eastus   uai-pwsh01 azure-rg-test
```

This command gets an user assigned identity by pipeline.