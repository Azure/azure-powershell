### Example 1: Lists all the storage tasks
```powershell
Get-AzStorageActionTaskAssignment -ResourceGroupName group001 -StorageTaskName mytask1 | Format-List
```

```output
Id : subscriptions/11111111-2222-3333-4444-123456789101/resourcegroups/group001/providers/microsoft.storage/storageaccounts/account001/storagetaskassignments/testassign1

Id : subscriptions/11111111-2222-3333-4444-123456789101/resourcegroups/group001/providers/microsoft.storage/storageaccounts/account001/storagetaskassignments/testassign2
```

This command lists all the storage task assignments.

