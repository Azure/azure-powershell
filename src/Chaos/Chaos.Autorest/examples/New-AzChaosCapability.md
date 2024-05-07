### Example 1: Create a Capability resource that extends a Target resource.
```powershell
New-AzChaosCapability -Name Shutdown-1.0 -ParentProviderNamespace Microsoft.Compute -ParentResourceName exampleVM -ParentResourceType virtualMachines -ResourceGroupName azps_test_group_chaos -TargetName microsoft-virtualmachine
```

```output
Description                  :
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/exampleVM/providers/Microsoft.Chaos/targets/
                               microsoft-virtualmachine/capabilities/Shutdown-1.0
Name                         : Shutdown-1.0
ParametersSchema             : https://schema-tc.eastus.chaos-prod.azure.com/targetTypes/Microsoft-VirtualMachine/capabilityTypes/Shutdown-1.0/parametersSchema.json
Publisher                    : microsoft
ResourceGroupName            : azps_test_group_chaos
SystemDataCreatedAt          : 2024-03-18 10:28:43 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-18 11:35:18 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TargetType                   : virtualmachine
Type                         : Microsoft.Chaos/targets/capabilities
Urn                          : urn:csci:microsoft:virtualMachine:shutdown/1.0
```

Create a Capability resource that extends a Target resource.