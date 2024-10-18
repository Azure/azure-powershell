### Example 1: Disable gateway feature of a connected kubernetes.
```powershell
Set-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -DisableGateway
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disable gateway feature of a connected kubernetes.

### Example 2: Enable gateway feature of connected kubernetes.
```powershell
Set-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -GatewayResourceId gatewayResourceId

```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disable gateway feature of a connected kubernetes.

### Example 3: Enable workload identity of a connected cluster with InputObject
```powershell
# Get an existing clustser first
$inputObject = Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SubscriptionId subscriptionId
# Enable workload identity and OIDC issuer profile
$inputObject.WorkloadIdentityEnabled=$true
$inputObject.OidcIssuerProfileEnabled=$true
Set-AzConnectedKubernetes -InputObject $inputObject 
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command enables workload identiy and Oidc Issuer Profile of a connected kubernetes

### Example 4: Disable workload identity of a connected cluster with InputOjbect
```powershell
# Get an existing clustser first
$inputObject = Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SubscriptionId subscriptionId
# Disable workload identity 
$inputObject.WorkloadIdentityEnabled=$falue
Set-AzConnectedKubernetes -InputObject $inputObject 
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disables workload identity of a connected kubernetes

