### Example 1: Gets a particular job 

```powershell
Get-AzDataBoxJob -Name "Powershell10" -ResourceGroupName "resourceGroupName"  -SubscriptionId "SubscriptionId"
```

```output
Name         Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----         -------- ------        ------------  ------- ------------ ------------ ------
Powershell10 WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.DataBoxJobDetails
```

Gets a particular job 

### Example 2: List all job under a subscription 
```powershell
Get-AzDataBoxJob -SubscriptionId "SubscriptionId"
```

```output
Name        Location      Status        TransferType    SkuName    IdentityType  DeliveryType Detail
----        --------      ------        ------------    -------    ------------  ------------ ------
brtestdbd  brazilsouth   DeviceOrdered ImportToAzure   DataBoxDisk None          NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.DataBoxDiskJobDetails
testorder  uksouth       Cancelled     ImportToAzure   DataBoxDisk None          NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.DataBoxDiskJobDetails
```

 List all job under a subscription 

### Example 3: List all job under a resourcegroup 
```powershell
Get-AzDataBoxJob -ResourceGroupName "resourceGroupName"
```

```output
Name                   Location Status        TransferType    SkuName IdentityType   DeliveryType Detail
----                   -------- ------        ------------    ------- ------------   ------------ ------
abcbnkndnkndn          westus   DeviceOrdered ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.DataBoxJobDetails
abcbnkndnkndn-Clone    westus   DeviceOrdered ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.DataBoxJobDetails
abcOrder               westus   Cancelled     ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.DataBoxJobDetails
```

 List all job under a resource group 