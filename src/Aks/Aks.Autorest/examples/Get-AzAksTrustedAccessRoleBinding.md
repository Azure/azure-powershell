### Example 1: List the trusted access role bindings
```powershell
Get-AzAksTrustedAccessRoleBinding -ResourceGroupName AKS_TEST_RG -ResourceName AKS_Test_Cluster
```

```output
Id                           : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.ContainerService/managedClusters/AKS_Test_Cluster/trustedAccessRoleBindings/testBinding
Name                         : testBinding
ProvisioningState            : Succeeded
ResourceGroupName            : AKS_TEST_RG
Role                         : {Microsoft.MachineLearningServices/workspaces/mlworkload}
SourceResourceId             : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.MachineLearningServices/workspaces/TestAML001
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.ContainerService/managedClusters/trustedAccessRoleBindings
```

List the trusted access role bindings.

### Example 2: Get the trusted access role binding
```powershell
Get-AzAksTrustedAccessRoleBinding -ResourceGroupName AKS_TEST_RG -ResourceName AKS_Test_Cluster -Name testBinding
```

```output
Id                           : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.ContainerService/managedClusters/AKS_Test_Cluster/trustedAccessRoleBindings/testBinding
Name                         : testBinding
ProvisioningState            : Succeeded
ResourceGroupName            : AKS_TEST_RG
Role                         : {Microsoft.MachineLearningServices/workspaces/mlworkload}
SourceResourceId             : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.MachineLearningServices/workspaces/TestAML001
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.ContainerService/managedClusters/trustedAccessRoleBindings
```

Get the trusted access role binding.
