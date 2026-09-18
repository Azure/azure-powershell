### Example 1: Disable gateway for a connected Kubernetes cluster
```powershell
Set-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -DisableGateway
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disable gateway feature of a connected kubernete cluster.

### Example 2: Enable gateway for a connected Kubernetes cluster
```powershell
Set-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -GatewayResourceId $gatewayResourceId

```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command enables gateway feature of a connected kubernetes cluster.

### Example 3: Enable gateway for a connected Kubernetes cluster with InputObject
```powershell
# Get an existing cluster first
$inputObject = Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SubscriptionId $subscriptionId
# Enable gateway and set gateway resource Id 
$inputObject.GatewayEnabled=$true
$inputObject.GatewayResourceId=$gatewayResourceId
Set-AzConnectedKubernetes -InputObject $inputObject     

```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command enables gateway feature of a connected kubernetes cluster.

### Example 4: Enable workload identity of a connected kubernetes cluster with InputObject
```powershell
# Get an existing cluster first
$inputObject = Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SubscriptionId $subscriptionId
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

This command enables workload identity and OIDC Issuer Profile for a connected Kubernetes cluster

### Example 5: Disable workload identity of a connected kubernetes cluster with InputOjbect
```powershell
# Get an existing cluster first
$inputObject = Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SubscriptionId $subscriptionId
# Disable workload identity 
$inputObject.WorkloadIdentityEnabled=$falue
Set-AzConnectedKubernetes -InputObject $inputObject 
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disables workload identity of a connected kubernetes cluster

### Example 6: Disable workload identity of a connected kubernetes cluster
```powershell
Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SubscriptionId $subscriptionId | Set-AzConnectedKubernetes -WorkloadIdentityEnabled:$false
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disables workload identity of a connected kubernetes cluster