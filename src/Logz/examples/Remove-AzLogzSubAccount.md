### Example 1: Delete a sub account resource
```powershell
<<<<<<< HEAD
Remove-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01 -Name logz01-subaccount01
=======
PS C:\> Remove-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01 -Name logz01-subaccount01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a sub account resource.

### Example 2: Delete a sub account resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01 -Name logz01-subaccount02 | Remove-AzLogzSubAccount
=======
PS C:\> Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01 -Name logz01-subaccount02 | Remove-AzLogzSubAccount

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a sub account resource by pipeline.

