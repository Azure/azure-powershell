### Example 1: Get instance level public IP addresses for a given cloud service name.
```powershell
PS C:\> Get-AzCloudServicePublicIPAddress -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca

```

Gets the instance level public IP addresses for a given cloud service name.

### Example 2: Get instance level public IP addresses for a given cloud service object.
```powershell
PS C:\> $cs = Get-AzCloudService -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
PS C:\> Get-AzCloudServicePublicIPAddress -CloudService $cs

```

Gets the instance level public IP addresses for a given cloud service object.

