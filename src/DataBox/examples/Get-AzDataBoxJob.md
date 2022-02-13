### Example 1: Gets a particular job 

```powershell
PS C:\> Get-AzDataBoxJob -Name "Powershell10" -ResourceGroupName "resourceGroupName"  -SubscriptionId "SubscriptionId"

Name         Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----         -------- ------        ------------  ------- ------------ ------------ ------
Powershell10 WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

Gets a particular job 

### Example 2: List all job under a subscription 
```powershell
PS C:\>  Get-AzDataBoxJob -SubscriptionId "SubscriptionId"

Name        Location      Status        TransferType    SkuName    IdentityType  DeliveryType Detail
----        --------      ------        ------------    -------    ------------  ------------ ------
brtestdbd  brazilsouth   DeviceOrdered ImportToAzure   DataBoxDisk None          NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxDiskJobDetails
testorder  uksouth       Cancelled     ImportToAzure   DataBoxDisk None          NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxDiskJobDetails
```

 List all job under a subscription 

### Example 3: List all job under a resourcegroup 
```powershell
PS C:\>  Get-AzDataBoxJob -ResourceGroupName "resourceGroupName"

Name                   Location Status        TransferType    SkuName IdentityType   DeliveryType Detail
----                   -------- ------        ------------    ------- ------------   ------------ ------
abcbnkndnkndn          westus   DeviceOrdered ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
abcbnkndnkndn-Clone    westus   DeviceOrdered ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
abcOrder               westus   Cancelled     ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

 List all job under a resource group 