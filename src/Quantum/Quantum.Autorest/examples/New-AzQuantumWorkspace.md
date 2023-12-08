### Example 1: Creates or updates a workspace resource.
```powershell
$object = New-AzQuantumProviderObject -Id "ionq" -Sku "pay-as-you-go-cred"
New-AzQuantumWorkspace -Name azps-qw -ResourceGroupName azps_test_group_quantum -Location eastus -IdentityType 'SystemAssigned' -Provider $object -StorageAccount "/subscriptions/{subId}/resourceGroups/azps_test_group_quantum/providers/Microsoft.Storage/storageAccounts/azpssa"
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   azps-qw azps_test_group_quantum
```

Creates or updates a workspace resource.