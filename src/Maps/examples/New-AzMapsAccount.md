### Example 1: Create a Maps Account.
```powershell
<<<<<<< HEAD
New-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 -SkuName S0 -Location eastus
```

```output
=======
PS C:\> New-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 -SkuName S0 -Location eastus

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount01 Microsoft.Maps/accounts Gen1
```

This command creates a Maps Account.A Maps Account holds the keys which allow access to the Maps REST APIs.
