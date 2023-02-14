### Example 1: Update a confluent organization by name
```powershell
<<<<<<< HEAD
Update-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-02-pwsh -Tag @{"key01" = "value01"}
```

```output
=======
PS C:\> pdate-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-02-pwsh -Tag @{"key01" = "value01"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                 Type
-------- ----                 ----
eastus   confluentorg-02-pwsh Microsoft.Confluent/organizations
```

This command updates a confluent organization by name.

### Example 2: Update a confluent organization by pipeline
```powershell
<<<<<<< HEAD
Get-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-02-pwsh | Update-AzConfluentOrganization -Tag @{"key01" = "value01"; "key02"="value02"}
```

```output
=======
PS C:\> Get-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-02-pwsh | Update-AzConfluentOrganization -Tag @{"key01" = "value01"; "key02"="value02"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                 Type
-------- ----                 ----
eastus   confluentorg-02-pwsh Microsoft.Confluent/organizations
```

This command updates a confluent organization by pipeline.

