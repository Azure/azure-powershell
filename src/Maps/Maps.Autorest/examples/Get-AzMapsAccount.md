### Example 1: List all Maps Accounts under a subscription
```powershell
PS C:\> Get-AzMapsAccount

Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount01 Microsoft.Maps/accounts Gen1
```

This command lists all Maps Accounts under a subscription.

### Example 2: List all Maps Accounts under a resource group
```powershell
PS C:\> Get-AzMapsAccount -ResourceGroupName azure-rg-test

Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount01 Microsoft.Maps/accounts Gen1
```

This command lists all Maps Accounts under a resource group.

### Example 3: Get a Maps Account
```powershell
PS C:\> Get-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01

Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount01 Microsoft.Maps/accounts Gen1
```

This command gets a Maps Account.

### Example 4: Get a Maps Account by pipeline
```powershell
PS C:\> New-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 -SkuName S0 -Location eastus | Get-AzMapsAccount

Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount01 Microsoft.Maps/accounts Gen1
```

This command gets a Maps Account by pipeline.

