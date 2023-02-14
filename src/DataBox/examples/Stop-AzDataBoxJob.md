### Example 1:  Cancel a Job 
```powershell
<<<<<<< HEAD
Stop-AzDataBoxJob -Name "Powershell10" -ResourceGroupName "resourceGroupName" -Reason "Powershell demo job"
Get-AzDataBoxJob -Name "Powershell10" -ResourceGroupName "resourceGroupName"
```

```output
=======
PS C:\> Stop-AzDataBoxJob -Name "Powershell10" -ResourceGroupName "resourceGroupName" -Reason "Powershell demo job"
PS C:\> Get-AzDataBoxJob -Name "Powershell10" -ResourceGroupName "resourceGroupName"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name         Location Status    TransferType  SkuName IdentityType DeliveryType Detail
----         -------- ------    ------------  ------- ------------ ------------ ------
Powershell10 WestUS   Cancelled ImportToAzure DataBox UserAssigned NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

Cancel a job 

