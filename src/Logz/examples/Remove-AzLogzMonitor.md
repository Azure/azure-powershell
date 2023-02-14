### Example 1: Delete a monitor resource
```powershell
<<<<<<< HEAD
Remove-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-portal01
=======
PS C:\> Remove-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-portal01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a monitor resource

### Example 2: Delete a monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-portal01 | Remove-AzLogzMonitor
=======
PS C:\> Get-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-portal01 | Remove-AzLogzMonitor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a monitor resource by pipeline

