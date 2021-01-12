### Example 1: Get network interfaces by a cloud service name
```powershell
PS C:\> Get-AzCloudServiceNetworkInterfaces -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca

```

Gets all the network interfaces for a given cloud service name.

### Example 2: Get network interfaces by a cloud service object
```powershell
PS C:\> $cs = Get-AzCloudService -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
PS C:\> Get-AzCloudServiceNetworkInterfaces -CloudService $cs

```

Gets all the network interfaces for a given cloud service object.

### Example 3: Get network interfaces by a cloud service object and role instance name.
```powershell
PS C:\> Get-AzCloudServiceNetworkInterfaces -CloudService $cs -RoleInstanceName WebRole1_IN_0

```

Gets all the network interfaces for a given cloud service object and role instance name.

