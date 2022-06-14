---
Module Name: Az.ServiceFabricMesh
Module Guid: eb2b1078-bf0a-448a-8314-def7d506b75b
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.servicefabricmesh
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ServiceFabricMesh Module
## Description
Microsoft Azure PowerShell: ServiceFabricMesh cmdlets

## Az.ServiceFabricMesh Cmdlets
### [Get-AzServiceFabricMeshApplication](Get-AzServiceFabricMeshApplication.md)
Gets the information about the application resource with the given name.
The information include the description and other properties of the application.

### [Get-AzServiceFabricMeshCodePackageContainerLog](Get-AzServiceFabricMeshCodePackageContainerLog.md)
Gets the logs for the container of the specified code package of the service replica.

### [Get-AzServiceFabricMeshGateway](Get-AzServiceFabricMeshGateway.md)
Gets the information about the gateway resource with the given name.
The information include the description and other properties of the gateway.

### [Get-AzServiceFabricMeshNetwork](Get-AzServiceFabricMeshNetwork.md)
Gets the information about the network resource with the given name.
The information include the description and other properties of the network.

### [Get-AzServiceFabricMeshSecret](Get-AzServiceFabricMeshSecret.md)
Gets the information about the secret resource with the given name.
The information include the description and other properties of the secret.

### [Get-AzServiceFabricMeshSecretValue](Get-AzServiceFabricMeshSecretValue.md)
Get the information about the specified named secret value resources.
The information does not include the actual value of the secret.

### [Get-AzServiceFabricMeshService](Get-AzServiceFabricMeshService.md)
Gets the information about the service resource with the given name.
The information include the description and other properties of the service.

### [Get-AzServiceFabricMeshServiceReplica](Get-AzServiceFabricMeshServiceReplica.md)
Gets the information about the service replica with the given name.
The information include the description and other properties of the service replica.

### [Get-AzServiceFabricMeshVolume](Get-AzServiceFabricMeshVolume.md)
Gets the information about the volume resource with the given name.
The information include the description and other properties of the volume.

### [New-AzServiceFabricMeshApplication](New-AzServiceFabricMeshApplication.md)
Creates an application resource with the specified name, description and properties.
If an application resource with the same name exists, then it is updated with the specified description and properties.

### [New-AzServiceFabricMeshGateway](New-AzServiceFabricMeshGateway.md)
Creates a gateway resource with the specified name, description and properties.
If a gateway resource with the same name exists, then it is updated with the specified description and properties.
Use gateway resources to create a gateway for public connectivity for services within your application.

### [New-AzServiceFabricMeshNetwork](New-AzServiceFabricMeshNetwork.md)
Creates a network resource with the specified name, description and properties.
If a network resource with the same name exists, then it is updated with the specified description and properties.

### [New-AzServiceFabricMeshSecret](New-AzServiceFabricMeshSecret.md)
Creates a secret resource with the specified name, description and properties.
If a secret resource with the same name exists, then it is updated with the specified description and properties.

### [New-AzServiceFabricMeshSecretValue](New-AzServiceFabricMeshSecretValue.md)
Creates a new value of the specified secret resource.
The name of the value is typically the version identifier.
Once created the value cannot be changed.

### [New-AzServiceFabricMeshVolume](New-AzServiceFabricMeshVolume.md)
Creates a volume resource with the specified name, description and properties.
If a volume resource with the same name exists, then it is updated with the specified description and properties.

### [Remove-AzServiceFabricMeshApplication](Remove-AzServiceFabricMeshApplication.md)
Deletes the application resource identified by the name.

### [Remove-AzServiceFabricMeshGateway](Remove-AzServiceFabricMeshGateway.md)
Deletes the gateway resource identified by the name.

### [Remove-AzServiceFabricMeshNetwork](Remove-AzServiceFabricMeshNetwork.md)
Deletes the network resource identified by the name.

### [Remove-AzServiceFabricMeshSecret](Remove-AzServiceFabricMeshSecret.md)
Deletes the secret resource identified by the name.

### [Remove-AzServiceFabricMeshSecretValue](Remove-AzServiceFabricMeshSecretValue.md)
Deletes the secret value resource identified by the name.
The name of the resource is typically the version associated with that value.
Deletion will fail if the specified value is in use.

### [Remove-AzServiceFabricMeshVolume](Remove-AzServiceFabricMeshVolume.md)
Deletes the volume resource identified by the name.

