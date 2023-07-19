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
  - https://github.com/Azure/azure-rest-api-specs/blob/0981d741705c4dcc72efb1e3a39dbe9124c84d83/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-08-01/virtualMachine.json

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
  - https://github.com/Azure/azure-rest-api-specs/blob/084da0d41924cd117db8fd0f999cf204ef1e78e8/specification/hybridconnectivity/resource-manager/Microsoft.HybridConnectivity/stable/2023-03-15/hybridconnectivity.json

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
    - ServiceConfigurations_ListByEndpointResource
#    - ServiceConfigurations_Get
#    - ServiceConfigurations_CreateOrupdate
    - ServiceConfigurations_Update
    - ServiceConfigurations_Delete
#    - Endpoints_ListCredentials
    - Endpoints_ListIngressGatewayCredentials
    - Endpoints_ListManagedProxyDetails
```


### Tag: HybridCompute
``` yaml $(tag) == 'HybridCompute'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/aef78a6d0f0bc49b42327621fc670200d7545816/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2022-11-10/HybridCompute.json

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
    - UpgradeExtensions
    - ExtensionMetadata_Get
    - ExtensionMetadata_List
```

### Tag: Network
``` yaml $(tag) == 'Network'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/0981d741705c4dcc72efb1e3a39dbe9124c84d83/specification/network/resource-manager/Microsoft.Network/stable/2022-09-01/networkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/0981d741705c4dcc72efb1e3a39dbe9124c84d83/specification/network/resource-manager/Microsoft.Network/stable/2022-09-01/publicIpAddress.json

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
    - PublicIPAddresses_DdosProtectionStatus
```