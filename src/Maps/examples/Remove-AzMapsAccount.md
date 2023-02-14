### Example 1: Delete a Maps Account
```powershell
<<<<<<< HEAD
Remove-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01
=======
PS C:\> Remove-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a Maps Account.

### Example 2: Delete a Maps Account by pipeline
```powershell
<<<<<<< HEAD
Get-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount02 | Remove-AzMapsAccount
=======
PS C:\> Get-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount02 | Remove-AzMapsAccount

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a Maps Account by pipeline.

