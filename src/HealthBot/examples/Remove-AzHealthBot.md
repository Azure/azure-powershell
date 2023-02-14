### Example 1: Delete HealthBot by ResourceGroupName and Name
```powershell
<<<<<<< HEAD
Remove-AzHealthBot -Name yourihealthbot -ResourceGroupName youriTest
=======
PS C:\> Remove-AzHealthBot -Name yourihealthbot -ResourceGroupName youriTest

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Delete HealthBot by ResourceGroupName and Name

### Example 2: Delete HealthBot by InputObject
```powershell
<<<<<<< HEAD
$gethealthbot = Get-AzHealthBot -Name yourihealthbot1 -ResourceGroupName youriTest
Remove-AzHealthBot -InputObject $gethealthbot
=======
PS C:\> $gethealthbot = Get-AzHealthBot -Name yourihealthbot1 -ResourceGroupName youriTest
Remove-AzHealthBot -InputObject $gethealthbot

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Delete HealthBot by InputObject
