### Example 1: Create a tenant of the AzureActiveDirectory by name 
```powershell
PS C:\> New-AzADB2CTenant -ResourceGroupName azure-rg-test -Name asdsdsadsad.onmicrosoft.com -Location 'United States' -Sku Standard -CountryCode US -DisplayName "azure.onmicrosoft.com"

Location Name                                 Type
-------- ----                                 ----
         d005debc-8b64-4008-829c-e68f7d9349ab
```

This command creates a tenant of the AzureActiveDirectory by name.

