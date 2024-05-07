### Example 1: Get a Capability Type resource for given Target Type and location.
```powershell
Get-AzChaosCapabilityType -LocationName eastus -TargetTypeName microsoft-virtualmachine
```

```output
Name         Location ResourceGroupName
----         -------- -----------------
Redeploy-1.0 eastus
Shutdown-1.0 eastus
```

Get a Capability Type resource for given Target Type and location.

### Example 2: Get a Capability Type resource for given Target Type and location.
```powershell
Get-AzChaosCapabilityType -LocationName eastus -TargetTypeName microsoft-virtualmachine -Name Shutdown-1.0
```

```output
AzureRbacAction              : {Microsoft.Compute/virtualMachines/poweroff/action, Microsoft.Compute/virtualMachines/start/action, Microsoft.Compute/virtualMachines/instanceView/read, Microsoft.Compute/virtua
                               lMachines/read…}
AzureRbacDataAction          :
Description                  :
DisplayName                  :
Id                           : /subscriptions/{subId}/providers/Microsoft.Chaos/locations/eastus/targetTypes/virtualmachine/capabilityTypes/Shutdown-1.0
Kind                         : Fault
Location                     : eastus
Name                         : Shutdown-1.0
ParametersSchema             : https://schema-tc.eastus.chaos-prod.azure.com/targetTypes/Microsoft-VirtualMachine/capabilityTypes/Shutdown-1.0/parametersSchema.json
Publisher                    : Microsoft
ResourceGroupName            :
RuntimePropertyKind          : Continuous
SystemDataCreatedAt          : 2024-03-08 06:57:59 PM
SystemDataCreatedBy          :
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 2024-03-08 06:57:59 PM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TargetType                   : VirtualMachine
Type                         : Microsoft.Chaos/locations/targetTypes/capabilityTypes
Urn                          : urn:csci:microsoft:virtualMachine:shutdown/1.0
```

Get a Capability Type resource for given Target Type and location.