### Example 1: 
```powershell
Unregister-AzStackHCI
```

```output
Result: Success
```

Invoking on one of the cluster node

### Example 2:
```powershell
Unregister-AzStackHCI -ComputerName ClusterNode1
```

```output
Result: Success
```

Invoking from the management node

### Example 3: 
```powershell
Unregister-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ArmAccessToken etyer..ere= -GraphAccessToken acyee..rerrer -AccountId user1@corp1.com -ResourceName DemoHCICluster3 -ResourceGroupName DemoHCIRG -Confirm:$False
```

```output
Result: Success
```

Invoking from WAC


### Example 4: 
```powershell
Unregister-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ResourceName HciCluster1 -TenantId "c31c0dbb-ce27-4c78-ad26-a5f717c14557" -ResourceGroupName HciClusterRG -ArmAccessToken eerrer..ere= -GraphAccessToken acee..rerrer -AccountId user1@corp1.com -EnvironmentName AzureCloud -ComputerName node1hci -Credential Get-Credential
```

```output
Result: Success
```

Invoking with all the parameters


