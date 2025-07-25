### Example 1: Creates or updates a workspace with the specified parameters
```powershell
New-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlwork01 -Location eastus -ApplicationInsightId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/ml-rg-test/providers/microsoft.insights/components/insightsmlworkspace" -KeyVaultId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/ml-rg-test/providers/microsoft.keyvault/vaults/kmlworkspace" -StorageAccountId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/ml-rg-test/providers/microsoft.storage/storageaccounts/storagemlworkspace01" -IdentityType 'SystemAssigned' -Kind 'Default'
```

```output
Name     SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    Location ResourceGroupName     
----     ------------------- -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----    -------- -----------------     
mlwork01 6/6/2024 9:40:20 AM user@example.com      User                    6/7/2024 3:57:23 AM      user@example.com         User                         Default eastus   ml-rg-test
```

This command creates a workspace with the specified parameters.
