---
Module Name: Az.Batch
Module Guid: f05875ea-2664-4699-89f7-c02394189dbc
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.batch
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Batch Module
## Description
Microsoft Azure PowerShell: Batch cmdlets

## Az.Batch Cmdlets
### [Disable-AzBatchPoolAutoScale](Disable-AzBatchPoolAutoScale.md)
Disables automatic scaling for a pool.

### [Get-AzBatchAccount](Get-AzBatchAccount.md)
Gets information about the specified Batch account.

### [Get-AzBatchAccountDetector](Get-AzBatchAccountDetector.md)
Gets information about the given detector for a given Batch account.

### [Get-AzBatchAccountKey](Get-AzBatchAccountKey.md)
This operation applies only to Batch accounts with allowedAuthenticationModes containing 'SharedKey'.
If the Batch account doesn't contain 'SharedKey' in its allowedAuthenticationMode, clients cannot use shared keys to authenticate, and must use another allowedAuthenticationModes instead.
In this case, getting the keys will fail.

### [Get-AzBatchAccountOutboundNetworkDependencyEndpoint](Get-AzBatchAccountOutboundNetworkDependencyEndpoint.md)
Lists the endpoints that a Batch Compute Node under this Batch Account may call as part of Batch service administration.
If you are deploying a Pool inside of a virtual network that you specify, you must make sure your network allows outbound access to these endpoints.
Failure to allow access to these endpoints may cause Batch to mark the affected nodes as unusable.
For more information about creating a pool inside of a virtual network, see https://docs.microsoft.com/en-us/azure/batch/batch-virtual-network.

### [Get-AzBatchApplication](Get-AzBatchApplication.md)
Gets information about the specified application.

### [Get-AzBatchApplicationPackage](Get-AzBatchApplicationPackage.md)
Gets information about the specified application package.

### [Get-AzBatchCertificate](Get-AzBatchCertificate.md)
Gets information about the specified certificate.

### [Get-AzBatchLocationQuota](Get-AzBatchLocationQuota.md)
Gets the Batch service quotas for the specified subscription at the given location.

### [Get-AzBatchLocationSupportedCloudServiceSku](Get-AzBatchLocationSupportedCloudServiceSku.md)
Gets the list of Batch supported Cloud Service VM sizes available at the given location.

### [Get-AzBatchLocationSupportedVirtualMachineSku](Get-AzBatchLocationSupportedVirtualMachineSku.md)
Gets the list of Batch supported Virtual Machine VM sizes available at the given location.

### [Get-AzBatchPool](Get-AzBatchPool.md)
Gets information about the specified pool.

### [Get-AzBatchPrivateEndpointConnection](Get-AzBatchPrivateEndpointConnection.md)
Gets information about the specified private endpoint connection.

### [Get-AzBatchPrivateLinkResource](Get-AzBatchPrivateLinkResource.md)
Gets information about the specified private link resource.

### [Initialize-AzBatchApplicationPackage](Initialize-AzBatchApplicationPackage.md)
Activates the specified application package.
This should be done after the `ApplicationPackage` was created and uploaded.
This needs to be done before an `ApplicationPackage` can be used on Pools or Tasks.

### [New-AzBatchAccount](New-AzBatchAccount.md)
Creates a new Batch account with the specified parameters.
Existing accounts cannot be updated with this API and should instead be updated with the Update Batch Account API.

### [New-AzBatchAccountKey](New-AzBatchAccountKey.md)
This operation applies only to Batch accounts with allowedAuthenticationModes containing 'SharedKey'.
If the Batch account doesn't contain 'SharedKey' in its allowedAuthenticationMode, clients cannot use shared keys to authenticate, and must use another allowedAuthenticationModes instead.
In this case, regenerating the keys will fail.

### [New-AzBatchApplication](New-AzBatchApplication.md)
Adds an application to the specified Batch account.

### [New-AzBatchApplicationPackage](New-AzBatchApplicationPackage.md)
Creates an application package record.
The record contains a storageUrl where the package should be uploaded to.
Once it is uploaded the `ApplicationPackage` needs to be activated using `ApplicationPackageActive` before it can be used.
If the auto storage account was configured to use storage keys, the URL returned will contain a SAS.

### [New-AzBatchCertificate](New-AzBatchCertificate.md)
Creates a new certificate inside the specified account.

### [New-AzBatchPool](New-AzBatchPool.md)
Creates a new pool inside the specified account.

### [Remove-AzBatchAccount](Remove-AzBatchAccount.md)
Deletes the specified Batch account.

### [Remove-AzBatchApplication](Remove-AzBatchApplication.md)
Deletes an application.

### [Remove-AzBatchApplicationPackage](Remove-AzBatchApplicationPackage.md)
Deletes an application package record and its associated binary file.

### [Remove-AzBatchCertificate](Remove-AzBatchCertificate.md)
Deletes the specified certificate.

### [Remove-AzBatchPool](Remove-AzBatchPool.md)
Deletes the specified pool.

### [Stop-AzBatchCertificateDeletion](Stop-AzBatchCertificateDeletion.md)
If you try to delete a certificate that is being used by a pool or compute node, the status of the certificate changes to deleteFailed.
If you decide that you want to continue using the certificate, you can use this operation to set the status of the certificate back to active.
If you intend to delete the certificate, you do not need to run this operation after the deletion failed.
You must make sure that the certificate is not being used by any resources, and then you can try again to delete the certificate.

### [Stop-AzBatchPoolResize](Stop-AzBatchPoolResize.md)
This does not restore the pool to its previous state before the resize operation: it only stops any further changes being made, and the pool maintains its current state.
After stopping, the pool stabilizes at the number of nodes it was at when the stop operation was done.
During the stop operation, the pool allocation state changes first to stopping and then to steady.
A resize operation need not be an explicit resize pool request; this API can also be used to halt the initial sizing of the pool when it is created.

### [Sync-AzBatchAccountAutoStorageKey](Sync-AzBatchAccountAutoStorageKey.md)
Synchronizes access keys for the auto-storage account configured for the specified Batch account, only if storage key authentication is being used.

### [Test-AzBatchLocationNameAvailability](Test-AzBatchLocationNameAvailability.md)
Checks whether the Batch account name is available in the specified region.

### [Update-AzBatchAccount](Update-AzBatchAccount.md)
Updates the properties of an existing Batch account.

### [Update-AzBatchApplication](Update-AzBatchApplication.md)
Updates settings for the specified application.

### [Update-AzBatchCertificate](Update-AzBatchCertificate.md)
Updates the properties of an existing certificate.

### [Update-AzBatchPool](Update-AzBatchPool.md)
Updates the properties of an existing pool.

### [Update-AzBatchPrivateEndpointConnection](Update-AzBatchPrivateEndpointConnection.md)
Updates the properties of an existing private endpoint connection.

