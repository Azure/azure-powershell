### Example 1: Lists all the storage tasks
```powershell
Get-AzStorageActionTaskAssignment -ResourceGroupName joyer-test -StorageTaskName mytask1 | Format-List
```

```output
Id : subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/joyer-test/providers/microsoft.storage/storageaccounts/storagetasktest202402281/storagetaskassignments/testassign1

Id : subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/joyer-test/providers/microsoft.storage/storageaccounts/storagetasktest202402281/storagetaskassignments/testassign2
```

This command lists all the storage task assignments.

