# Overall
This directory contains the service clients of other services for Azure PowerShell SSH module.

## Run Generation
In this directory, run AutoRest:
```
autorest.cmd README.md --version=v2 --tag=Compute
autorest.cmd README.md --version=v2 --tag=HybridConnectivity
autorest.cmd README.md --version=v2 --tag=HybridCompute
autorest.cmd README.md --version=v2 --tag=Network
```

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```

### Tag: Compute
``` yaml $(tag) == 'Compute'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/81cd88a080c4bf4bb251afbe62892a6e220cb2b4/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/virtualMachine.json

output-folder: Compute

namespace: Microsoft.Azure.PowerShell.Ssh.Helpers.Compute

directive:
  - remove-operation:
    - VirtualMachineExtensions_CreateOrUpdate
    - VirtualMachineExtensions_Update
    - VirtualMachineExtensions_Delete
    - VirtualMachineExtensions_Get
    - VirtualMachineExtensions_List
    - VirtualMachines_ListByLocation
    - VirtualMachines_Capture
    - VirtualMachines_CreateOrUpdate
    - VirtualMachines_Update
    - VirtualMachines_Delete
#    - VirtualMachines_Get
    - VirtualMachines_InstanceView
    - VirtualMachines_ConvertToManagedDisks
    - VirtualMachines_Deallocate
    - VirtualMachines_Generalize
    - VirtualMachines_List
    - VirtualMachines_ListAll
    - VirtualMachines_ListAvailableSizes
    - VirtualMachines_PowerOff
    - VirtualMachines_Reapply
    - VirtualMachines_Restart
    - VirtualMachines_Start
    - VirtualMachines_Redeploy
    - VirtualMachines_Reimage
    - VirtualMachines_RetrieveBootDiagnosticsData
    - VirtualMachines_PerformMaintenance
    - VirtualMachines_SimulateEviction
    - VirtualMachines_AssessPatches
    - VirtualMachines_InstallPatches
```


### Tag: HybridConnectivity
``` yaml $(tag) == 'HybridConnectivity'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/81cd88a080c4bf4bb251afbe62892a6e220cb2b4/specification/hybridconnectivity/resource-manager/Microsoft.HybridConnectivity/preview/2021-10-06-preview/hybridconnectivity.json

output-folder: HybridConnectivity

namespace: Microsoft.Azure.PowerShell.Ssh.Helpers.HybridConnectivity

directive:
  - remove-operation:
    - Operations_List
    - Endpoints_List
    - Endpoints_Get
#    - Endpoints_CreateOrUpdate
    - Endpoints_Update
    - Endpoints_Delete
#    - Endpoints_ListCredentials
```


### Tag: HybridCompute
``` yaml $(tag) == 'HybridCompute'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/81cd88a080c4bf4bb251afbe62892a6e220cb2b4/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2020-08-02/HybridCompute.json

output-folder: HybridCompute

namespace: Microsoft.Azure.PowerShell.Ssh.Helpers.HybridCompute

directive:
  - remove-operation:
    - Machines_CreateOrUpdate
    - Machines_Update
    - Machines_Delete
#    - Machines_Get
    - Machines_ListByResourceGroup
    - Machines_ListBySubscription
    - MachineExtensions_CreateOrUpdate
    - MachineExtensions_Update
    - MachineExtensions_Delete
    - MachineExtensions_Get
    - MachineExtensions_List
    - Operations_List
```

### Tag: Network
``` yaml $(tag) == 'Network'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/81cd88a080c4bf4bb251afbe62892a6e220cb2b4/specification/network/resource-manager/Microsoft.Network/stable/2021-08-01/networkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/81cd88a080c4bf4bb251afbe62892a6e220cb2b4/specification/network/resource-manager/Microsoft.Network/stable/2021-08-01/publicIpAddress.json

output-folder: Network

namespace: Microsoft.Azure.PowerShell.Ssh.Helpers.Network

directive:
  - remove-operation:
    - NetworkInterfaces_Delete
#    - NetworkInterfaces_Get
    - NetworkInterfaces_CreateOrUpdate
    - NetworkInterfaces_UpdateTags
    - NetworkInterfaces_ListAll
    - NetworkInterfaces_List
    - NetworkInterfaces_GetEffectiveRouteTable
    - NetworkInterfaces_ListEffectiveNetworkSecurityGroups
    - NetworkInterfaceIPConfigurations_List
    - NetworkInterfaceIPConfigurations_Get
    - NetworkInterfaceLoadBalancers_List
    - NetworkInterfaceTapConfigurations_Delete
    - NetworkInterfaceTapConfigurations_Get
    - NetworkInterfaceTapConfigurations_CreateOrUpdate
    - NetworkInterfaceTapConfigurations_List
    - PublicIPAddresses_Delete
#    - PublicIPAddresses_Get
    - PublicIPAddresses_CreateOrUpdate
    - PublicIPAddresses_UpdateTags
    - PublicIPAddresses_ListAll
    - PublicIPAddresses_List
```