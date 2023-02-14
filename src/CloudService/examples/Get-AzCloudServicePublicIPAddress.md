### Example 1: Get instance level public IP addresses for a given cloud service name.
```powershell
Get-AzCloudServicePublicIPAddress -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
```

Gets the instance level public IP addresses for a given cloud service name.

### Example 2: Get instance level public IP addresses for a given cloud service object.
```powershell
$cs = Get-AzCloudService -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
<<<<<<< HEAD
Get-AzCloudServicePublicIPAddress -InputObject $cs
=======
Get-AzCloudServicePublicIPAddress -CloudService $cs
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Gets the instance level public IP addresses for a given cloud service object.

