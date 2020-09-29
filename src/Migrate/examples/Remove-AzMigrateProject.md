### Example 1: Delete (Default)
```powershell
PS C:\> Remove-AzMigrateProject -Name $projName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId

--No output--
```

Delete the migrate project.
Deleting non-existent project is a no-operation.