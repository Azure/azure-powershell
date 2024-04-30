### Example 1: Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription
```powershell
$HostResourceId = (Get-AzConnectedKubernetes -ClusterName azps-connect -ResourceGroupName azps_test_cluster).Id
$ClusterExtensionId = (Get-AzKubernetesExtension -ClusterName azps-connect -ClusterType ConnectedClusters -ResourceGroupName azps_test_cluster -Name azps-extension).Id
Update-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation -ClusterExtensionId $ClusterExtensionId -HostResourceId $HostResourceId -Namespace azps-namespace -Tag @{"Key1"="Value1"}
```

```output
Location Name                Namespace      ResourceGroupName
-------- ----                ---------      -----------------
eastus   azps-customlocation azps-namespace azps_test_cluster
```

Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.

### Example 2: Updates a Custom Location
```powershell
$obj = Get-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation
Update-AzCustomLocation -InputObject $obj -Tag @{"Key1"="Value1"}
```

```output
Location Name                Namespace      ResourceGroupName
-------- ----                ---------      -----------------
eastus   azps-customlocation azps-namespace azps_test_cluster
```

Updates a Custom Location.

### Example 2: Updates a Custom Location with disable system assigned identity
```powershell
Update-AzCustomLocation -Name azps-customlocation -ResourceGroupName joyer-test -EnableSystemAssignedIdentity 0 -Tag @{"aaa"= "111"}
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
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
Location                     : eastus
Name                         : azps-customlocation
Namespace                    : azps-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 4/30/2024 7:57:50 AM
SystemDataCreatedBy          : v-jiaji@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/30/2024 8:08:55 AM
SystemDataLastModifiedBy     : v-jiaji@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "aaa": "111"
                               }
Type                         : Microsoft.ExtendedLocation/customLocations
```

This command updates a Custom Location with disable system assigned identity.