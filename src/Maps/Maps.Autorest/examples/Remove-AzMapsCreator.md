### Example 1: Delete a Maps Creator resource
```powershell
Remove-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount03 -Name creator-01
```

This command deletes a Maps Creator resource.

### Example 2: Delete a Maps Creator resource by pipeline
```powershell
Get-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01 | Remove-AzMapsCreator
```

This command deletes a Maps Creator resource by pipeline.

