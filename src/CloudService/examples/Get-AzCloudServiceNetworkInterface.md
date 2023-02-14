### Example 1: Get network interfaces by a cloud service name
```powershell
Get-AzCloudServiceNetworkInterface -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
```

Gets all the network interfaces for a given cloud service name.

### Example 2: Get network interfaces by a cloud service object
```powershell
$cs = Get-AzCloudService -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
<<<<<<< HEAD
Get-AzCloudServiceNetworkInterface -InputObject $cs
=======
Get-AzCloudServiceNetworkInterface -CloudService $cs
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Gets all the network interfaces for a given cloud service object.

<<<<<<< HEAD
=======
### Example 3: Get network interfaces by a cloud service object and role instance name.
```powershell
Get-AzCloudServiceNetworkInterface -CloudServiceName $cs -RoleInstanceName WebRole1_IN_0
```

Gets all the network interfaces for a given cloud service object and role instance name.

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
