### Example 1: Creates or updates a Custom Location in the specified Subscription and Resource Group.
```powershell
$HostResourceId = (Get-AzConnectedKubernetes -ClusterName azps-connect -ResourceGroupName azps_test_cluster).Id
$ClusterExtensionId = (Get-AzKubernetesExtension -ClusterName azps-connect -ClusterType ConnectedClusters -ResourceGroupName azps_test_cluster -Name azps-extension).Id
New-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation -Location eastus -ClusterExtensionId $ClusterExtensionId -HostResourceId $HostResourceId -Namespace azps-namespace
```

```output
Location Name                Namespace      ResourceGroupName
-------- ----                ---------      -----------------
eastus   azps-customlocation azps-namespace azps_test_cluster
```

Creates or updates a Custom Location in the specified Subscription and Resource Group.

### Example 2: Creates or updates a Custom Location that enable system assigned identity
```powershell
$HostResourceId = (Get-AzConnectedKubernetes -ClusterName azps-connect -ResourceGroupName group01).Id
$ClusterExtensionId = (Get-AzKubernetesExtension -ClusterName azps-connect -ClusterType ConnectedClusters -ResourceGroupName group01 -Name azps-extension).Id
New-AzCustomLocation -ResourceGroupName group01 -Name azps-customlocation -Location eastus -ClusterExtensionId $ClusterExtensionId -HostResourceId $HostResourceId -Namespace azps-namespace -EnableSystemAssignedIdentity
```

```output
AuthenticationType           : 
AuthenticationValue          : 
ClusterExtensionId           : {/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group01/providers/Microsoft.Kubernetes/ConnectedClusters/azps- 
                               connect/providers/Microsoft.KubernetesConfiguration/extensions/azps-extension}
DisplayName                  : 
HostResourceId               : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group01/providers/Microsoft.Kubernetes/connectedClusters/azps-c 
                               onnect
HostType                     : Kubernetes
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourcegroups/group01/providers/microsoft.extendedlocation/customlocations/az 
                               ps-customlocation
IdentityPrincipalId          : 11111111-2222-3333-4444-123456789123
IdentityTenantId             : 11111111-2222-3333-4444-123456789876
IdentityType                 : SystemAssigned
Location                     : eastus
Name                         : azps-customlocation
Namespace                    : azps-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : group01
SystemDataCreatedAt          : 4/30/2024 7:57:50 AM
SystemDataCreatedBy          : user@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/30/2024 7:57:50 AM
SystemDataLastModifiedBy     : user@example.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.ExtendedLocation/customLocations
```

The third command creates or updates a Custom Location that enable system assigned identity.