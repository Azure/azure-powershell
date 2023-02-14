### Example 1: Delete a Maps Creator resource
```powershell
<<<<<<< HEAD
Remove-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount03 -Name creator-01
=======
PS C:\> Remove-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount03 -Name creator-01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a Maps Creator resource.

### Example 2: Delete a Maps Creator resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01 | Remove-AzMapsCreator
=======
PS C:\> Get-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01 | Remove-AzMapsCreator

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a Maps Creator resource by pipeline.

