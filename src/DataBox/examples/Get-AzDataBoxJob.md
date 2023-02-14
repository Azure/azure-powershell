### Example 1: Gets a particular job 

```powershell
<<<<<<< HEAD
Get-AzDataBoxJob -Name "Powershell10" -ResourceGroupName "resourceGroupName"  -SubscriptionId "SubscriptionId"
```

```output
=======
PS C:\> Get-AzDataBoxJob -Name "Powershell10" -ResourceGroupName "resourceGroupName"  -SubscriptionId "SubscriptionId"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name         Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----         -------- ------        ------------  ------- ------------ ------------ ------
Powershell10 WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

Gets a particular job 

### Example 2: List all job under a subscription 
```powershell
<<<<<<< HEAD
Get-AzDataBoxJob -SubscriptionId "SubscriptionId"
```

```output
=======
PS C:\>  Get-AzDataBoxJob -SubscriptionId "SubscriptionId"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name        Location      Status        TransferType    SkuName    IdentityType  DeliveryType Detail
----        --------      ------        ------------    -------    ------------  ------------ ------
brtestdbd  brazilsouth   DeviceOrdered ImportToAzure   DataBoxDisk None          NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxDiskJobDetails
testorder  uksouth       Cancelled     ImportToAzure   DataBoxDisk None          NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxDiskJobDetails
```

 List all job under a subscription 

### Example 3: List all job under a resourcegroup 
```powershell
<<<<<<< HEAD
Get-AzDataBoxJob -ResourceGroupName "resourceGroupName"
```

```output
=======
PS C:\>  Get-AzDataBoxJob -ResourceGroupName "resourceGroupName"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                   Location Status        TransferType    SkuName IdentityType   DeliveryType Detail
----                   -------- ------        ------------    ------- ------------   ------------ ------
abcbnkndnkndn          westus   DeviceOrdered ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
abcbnkndnkndn-Clone    westus   DeviceOrdered ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
abcOrder               westus   Cancelled     ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

 List all job under a resource group 