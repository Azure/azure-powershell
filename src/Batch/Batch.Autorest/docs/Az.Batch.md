---
Module Name: Az.Batch
Module Guid: f9cf5142-cc00-446d-ab26-b1d7bf65a536
Download Help Link: https://learn.microsoft.com/powershell/module/az.batch
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Batch Module
## Description
Microsoft Azure PowerShell: Batch cmdlets

## Az.Batch Cmdlets
### [Disable-AzPoolAutoScale](Disable-AzPoolAutoScale.md)
Disables automatic scaling for a pool.

### [Get-AzApplication](Get-AzApplication.md)
Gets information about the specified application.

### [Get-AzApplicationPackage](Get-AzApplicationPackage.md)
Gets information about the specified application package.

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
For more information about creating a pool inside of a virtual network, see https://learn.microsoft.com/azure/batch/batch-virtual-network.

### [Get-AzCertificate](Get-AzCertificate.md)
Warning: This operation is deprecated and will be removed after February, 2024.
Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.

### [Get-AzLocationQuota](Get-AzLocationQuota.md)
Gets the Batch service quotas for the specified subscription at the given location.

### [Get-AzLocationSupportedVirtualMachineSku](Get-AzLocationSupportedVirtualMachineSku.md)
Gets the list of Batch supported Virtual Machine VM sizes available at the given location.

### [Get-AzNetworkSecurityPerimeterConfiguration](Get-AzNetworkSecurityPerimeterConfiguration.md)
Gets information about the specified NSP configuration.

### [Get-AzPool](Get-AzPool.md)
Gets information about the specified pool.

### [Initialize-AzApplicationPackage](Initialize-AzApplicationPackage.md)
Activates the specified application package.
This should be done after the `ApplicationPackage` was created and uploaded.
This needs to be done before an `ApplicationPackage` can be used on Pools or Tasks.

### [Invoke-AzReconcileNetworkSecurityPerimeterConfiguration](Invoke-AzReconcileNetworkSecurityPerimeterConfiguration.md)
Reconciles the specified NSP configuration.

### [New-AzApplication](New-AzApplication.md)
Adds an application to the specified Batch account.

### [New-AzApplicationPackage](New-AzApplicationPackage.md)
Create an application package record.
The record contains a storageUrl where the package should be uploaded to.
Once it is uploaded the `ApplicationPackage` needs to be activated using `ApplicationPackageActive` before it can be used.
If the auto storage account was configured to use storage keys, the URL returned will contain a SAS.

### [New-AzBatchAccount](New-AzBatchAccount.md)
Create a new Batch account with the specified parameters.
Existing accounts cannot be updated with this API and should instead be updated with the create Batch Account API.

### [New-AzBatchAccountKey](New-AzBatchAccountKey.md)
This operation applies only to Batch accounts with allowedAuthenticationModes containing 'SharedKey'.
If the Batch account doesn't contain 'SharedKey' in its allowedAuthenticationMode, clients cannot use shared keys to authenticate, and must use another allowedAuthenticationModes instead.
In this case, regenerating the keys will fail.

### [New-AzCertificate](New-AzCertificate.md)
Warning: This operation is deprecated and will be removed after February, 2024.
Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.

### [New-AzPool](New-AzPool.md)
Create a new pool inside the specified account.

### [Remove-AzApplication](Remove-AzApplication.md)
Deletes an application.

### [Remove-AzApplicationPackage](Remove-AzApplicationPackage.md)
Deletes an application package record and its associated binary file.

### [Remove-AzBatchAccount](Remove-AzBatchAccount.md)
Deletes the specified Batch account.

### [Remove-AzCertificate](Remove-AzCertificate.md)
Warning: This operation is deprecated and will be removed after February, 2024.
Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.

### [Remove-AzPool](Remove-AzPool.md)
Deletes the specified pool.

### [Stop-AzCertificateDeletion](Stop-AzCertificateDeletion.md)
If you try to delete a certificate that is being used by a pool or compute node, the status of the certificate changes to deleteFailed.
If you decide that you want to continue using the certificate, you can use this operation to set the status of the certificate back to active.
If you intend to delete the certificate, you do not need to run this operation after the deletion failed.
You must make sure that the certificate is not being used by any resources, and then you can try again to delete the certificate.\n\nWarning: This operation is deprecated and will be removed after February, 2024.
Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.

### [Stop-AzPoolResize](Stop-AzPoolResize.md)
This does not restore the pool to its previous state before the resize operation: it only stops any further changes being made, and the pool maintains its current state.
After stopping, the pool stabilizes at the number of nodes it was at when the stop operation was done.
During the stop operation, the pool allocation state changes first to stopping and then to steady.
A resize operation need not be an explicit resize pool request; this API can also be used to halt the initial sizing of the pool when it is created.

### [Sync-AzBatchAccountAutoStorageKey](Sync-AzBatchAccountAutoStorageKey.md)
Synchronizes access keys for the auto-storage account configured for the specified Batch account, only if storage key authentication is being used.

### [Test-AzLocationNameAvailability](Test-AzLocationNameAvailability.md)
Checks whether the Batch account name is available in the specified region.

### [Update-AzApplication](Update-AzApplication.md)
Update settings for the specified application.

### [Update-AzApplicationPackage](Update-AzApplicationPackage.md)
Update an application package record.
The record contains a storageUrl where the package should be uploaded to.
Once it is uploaded the `ApplicationPackage` needs to be activated using `ApplicationPackageActive` before it can be used.
If the auto storage account was configured to use storage keys, the URL returned will contain a SAS.

### [Update-AzBatchAccount](Update-AzBatchAccount.md)
Update the properties of an existing Batch account.

### [Update-AzCertificate](Update-AzCertificate.md)
Warning: This operation is deprecated and will be removed after February, 2024.
Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.

### [Update-AzPool](Update-AzPool.md)
Update a new pool inside the specified account.

