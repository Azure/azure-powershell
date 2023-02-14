### Example 1: List all Maps Accounts under a subscription
```powershell
<<<<<<< HEAD
Get-AzMapsAccount
```

```output
=======
PS C:\> Get-AzMapsAccount

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount01 Microsoft.Maps/accounts Gen1
```

This command lists all Maps Accounts under a subscription.

### Example 2: List all Maps Accounts under a resource group
```powershell
<<<<<<< HEAD
Get-AzMapsAccount -ResourceGroupName azure-rg-test
```

```output
=======
PS C:\> Get-AzMapsAccount -ResourceGroupName azure-rg-test

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount01 Microsoft.Maps/accounts Gen1
```

This command lists all Maps Accounts under a resource group.

### Example 3: Get a Maps Account
```powershell
<<<<<<< HEAD
Get-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01
```

```output
=======
PS C:\> Get-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount01 Microsoft.Maps/accounts Gen1
```

This command gets a Maps Account.

### Example 4: Get a Maps Account by pipeline
```powershell
<<<<<<< HEAD
New-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 -SkuName S0 -Location eastus | Get-AzMapsAccount
```

```output
=======
PS C:\> New-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 -SkuName S0 -Location eastus | Get-AzMapsAccount

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount01 Microsoft.Maps/accounts Gen1
```

This command gets a Maps Account by pipeline.

