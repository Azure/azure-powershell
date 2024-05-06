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
$HostResourceId = (Get-AzConnectedKubernetes -ClusterName azps-connect -ResourceGroupName joyer-test).Id
$ClusterExtensionId = (Get-AzKubernetesExtension -ClusterName azps-connect -ClusterType ConnectedClusters -ResourceGroupName joyer-test -Name azps-extension).Id
New-AzCustomLocation -ResourceGroupName joyer-test -Name azps-customlocation -Location eastus -ClusterExtensionId $ClusterExtensionId -HostResourceId $HostResourceId -Namespace azps-namespace -EnableSystemAssignedIdentity
```

```output
AuthenticationType           : 
AuthenticationValue          : 
ClusterExtensionId           : {/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Kubernetes/ConnectedClusters/azps- 
                               connect/providers/Microsoft.KubernetesConfiguration/extensions/azps-extension}
DisplayName                  : 
HostResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Kubernetes/connectedClusters/azps-c 
                               onnect
HostType                     : Kubernetes
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/joyer-test/providers/microsoft.extendedlocation/customlocations/az 
                               ps-customlocation
IdentityPrincipalId          : 2c00f896-3cf8-42d2-b902-660cbcc51005
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : eastus
Name                         : azps-customlocation
Namespace                    : azps-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 4/30/2024 7:57:50 AM
SystemDataCreatedBy          : v-jiaji@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/30/2024 7:57:50 AM
SystemDataLastModifiedBy     : v-jiaji@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.ExtendedLocation/customLocations
```

The third command creates or updates a Custom Location that enable system assigned identity.