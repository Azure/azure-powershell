### Example 1:  Cancel a Job 
```powershell
PS C:\> Stop-AzDataBoxJob -Name "Powershell10" -ResourceGroupName "resourceGroupName" -Reason "Powershell demo job"
PS C:\> Get-AzDataBoxJob -Name "Powershell10" -ResourceGroupName "resourceGroupName"

Name         Location Status    TransferType  SkuName IdentityType DeliveryType Detail
----         -------- ------    ------------  ------- ------------ ------------ ------
Powershell10 WestUS   Cancelled ImportToAzure DataBox UserAssigned NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

Cancel a job 

