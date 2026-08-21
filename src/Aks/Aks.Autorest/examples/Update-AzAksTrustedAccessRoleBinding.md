### Example 1: Update the trusted access role binding 
```powershell
Update-AzAksTrustedAccessRoleBinding -Name testBinding -ResourceGroupName AKS_TEST_RG -ResourceName AKS_Test_Cluster -Role 'Microsoft.MachineLearningServices/workspaces/inference-v1'
```

```output
Id                           : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.ContainerService/managedClusters/AKS_Test_Cluster/trustedAccessRoleBindings/testBinding
Name                         : testBinding
ProvisioningState            : Succeeded
ResourceGroupName            : AKS_TEST_RG
Role                         : {Microsoft.MachineLearningServices/workspaces/inference-v1}
SourceResourceId             : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.MachineLearningServices/workspaces/TestAML001
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.ContainerService/managedClusters/trustedAccessRoleBindings
```

Update the trusted access role binding.

