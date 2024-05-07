### Example 1: Create a Target resource that extends a tracked regional resource.
```powershell
$property = @{"type"="CertificateSubjectIssuer";"subject"="CN=example.subject"}
$propertyArr = @($property)
$identities = @{"identities"=$propertyArr}
Update-AzChaosTarget -Name microsoft-virtualmachine -ParentProviderNamespace Microsoft.Compute -ParentResourceName exampleVM -ParentResourceType virtualMachines -ResourceGroupName azps_test_group_chaos -Location eastus -Property $identities
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/exampleVM/providers/Microsoft.Chaos/targets/
                               microsoft-virtualmachine
Location                     : eastus
Name                         : microsoft-virtualmachine
Property                     : {
                               }
ResourceGroupName            : azps_test_group_chaos
SystemDataCreatedAt          : 2024-03-18 10:28:42 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-18 11:51:08 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Chaos/targets
```

Create a Target resource that extends a tracked regional resource.