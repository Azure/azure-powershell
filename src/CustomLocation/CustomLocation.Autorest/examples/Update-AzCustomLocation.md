### Example 1: Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.
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

### Example 2: Updates a Custom Location.
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

### Example 3: Updates a Custom Location with disable system assigned identity
```powershell
Update-AzCustomLocation -Name azps-customlocation -ResourceGroupName group01 -EnableSystemAssignedIdentity $false -Tag @{"aaa"= "111"}
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
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
Location                     : eastus
Name                         : azps-customlocation
Namespace                    : azps-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : group01
SystemDataCreatedAt          : 4/30/2024 7:57:50 AM
SystemDataCreatedBy          : user@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/30/2024 8:08:55 AM
SystemDataLastModifiedBy     : user@example.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "aaa": "111"
                               }
Type                         : Microsoft.ExtendedLocation/customLocations
```

This command updates a Custom Location with disable system assigned identity.