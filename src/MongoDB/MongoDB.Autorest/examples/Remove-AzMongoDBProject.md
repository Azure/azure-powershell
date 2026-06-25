### Example 1: Remove a Project
```powershell
Remove-AzMongoDBProject -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -Name test-project-1
```

Deletes the MongoDB Atlas project. The operation is asynchronous; all clusters under the project must be deleted first.
