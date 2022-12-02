---
Module Name: Az.MobileNetwork
Module Guid: 5ecd135a-5394-4d9a-a328-321233b8f904
Download Help Link: https://learn.microsoft.com/powershell/module/az.mobilenetwork
Help Version: 1.0.0.0
Locale: en-US
---

# Az.MobileNetwork Module
## Description
Microsoft Azure PowerShell: MobileNetwork cmdlets

## Az.MobileNetwork Cmdlets
### [Get-AzMobileNetwork](Get-AzMobileNetwork.md)
Gets information about the specified mobile network.

### [Get-AzMobileNetworkAttachedDataNetwork](Get-AzMobileNetworkAttachedDataNetwork.md)
Gets information about the specified attached data network.

### [Get-AzMobileNetworkDataNetwork](Get-AzMobileNetworkDataNetwork.md)
Gets information about the specified data network.

### [Get-AzMobileNetworkPacketCoreControlPlane](Get-AzMobileNetworkPacketCoreControlPlane.md)
Gets information about the specified packet core control plane.

### [Get-AzMobileNetworkPacketCoreControlPlaneVersion](Get-AzMobileNetworkPacketCoreControlPlaneVersion.md)
Gets information about the specified packet core control plane version.

### [Get-AzMobileNetworkPacketCoreDataPlane](Get-AzMobileNetworkPacketCoreDataPlane.md)
Gets information about the specified packet core data plane.

### [Get-AzMobileNetworkService](Get-AzMobileNetworkService.md)
Gets information about the specified service.

### [Get-AzMobileNetworkSim](Get-AzMobileNetworkSim.md)
Gets information about the specified SIM.

### [Get-AzMobileNetworkSimGroup](Get-AzMobileNetworkSimGroup.md)
Gets information about the specified SIM group.

### [Get-AzMobileNetworkSimPolicy](Get-AzMobileNetworkSimPolicy.md)
Gets information about the specified SIM policy.

### [Get-AzMobileNetworkSite](Get-AzMobileNetworkSite.md)
Gets information about the specified mobile network site.

### [Get-AzMobileNetworkSlouse](Get-AzMobileNetworkSlouse.md)
Gets information about the specified network slice.

### [Invoke-AzMobileNetworkBulkSimDelete](Invoke-AzMobileNetworkBulkSimDelete.md)
Bulk delete SIMs from a SIM group.

### [Invoke-AzMobileNetworkBulkSimUpload](Invoke-AzMobileNetworkBulkSimUpload.md)
Bulk upload SIMs to a SIM group.

### [Invoke-AzMobileNetworkBulkSimUploadEncrypted](Invoke-AzMobileNetworkBulkSimUploadEncrypted.md)
Bulk upload SIMs in encrypted form to a SIM group.
The SIM credentials must be encrypted.

### [Invoke-AzMobileNetworkCollectPacketCoreControlPlaneDiagnosticPackage](Invoke-AzMobileNetworkCollectPacketCoreControlPlaneDiagnosticPackage.md)
Collect a diagnostics package for the specified packet core control plane.
This action will upload the diagnostics to a storage account.

### [Invoke-AzMobileNetworkReinstallPacketCoreControlPlane](Invoke-AzMobileNetworkReinstallPacketCoreControlPlane.md)
Reinstall the specified packet core control plane.
This action will remove any transaction state from the packet core to return it to a known state.
This action will cause a service outage.

### [Invoke-AzMobileNetworkRollbackPacketCoreControlPlane](Invoke-AzMobileNetworkRollbackPacketCoreControlPlane.md)
Roll back the specified packet core control plane to the previous version, \"rollbackVersion\".
Multiple consecutive rollbacks are not possible.
This action may cause a service outage.

### [New-AzMobileNetwork](New-AzMobileNetwork.md)
Creates or updates a mobile network.

### [New-AzMobileNetworkAttachedDataNetwork](New-AzMobileNetworkAttachedDataNetwork.md)
Creates or updates an attached data network.
Must be created in the same location as its parent packet core data plane.

### [New-AzMobileNetworkDataNetwork](New-AzMobileNetworkDataNetwork.md)
Creates or updates a data network.
Must be created in the same location as its parent mobile network.

### [New-AzMobileNetworkPacketCoreControlPlane](New-AzMobileNetworkPacketCoreControlPlane.md)
Creates or updates a packet core control plane.

### [New-AzMobileNetworkPacketCoreDataPlane](New-AzMobileNetworkPacketCoreDataPlane.md)
Creates or updates a packet core data plane.
Must be created in the same location as its parent packet core control plane.

### [New-AzMobileNetworkService](New-AzMobileNetworkService.md)
Creates or updates a service.
Must be created in the same location as its parent mobile network.

### [New-AzMobileNetworkSim](New-AzMobileNetworkSim.md)
Creates or updates a SIM.

### [New-AzMobileNetworkSimGroup](New-AzMobileNetworkSimGroup.md)
Creates or updates a SIM group.

### [New-AzMobileNetworkSimPolicy](New-AzMobileNetworkSimPolicy.md)
Creates or updates a SIM policy.
Must be created in the same location as its parent mobile network.

### [New-AzMobileNetworkSite](New-AzMobileNetworkSite.md)
Creates or updates a mobile network site.
Must be created in the same location as its parent mobile network.

### [New-AzMobileNetworkSlouse](New-AzMobileNetworkSlouse.md)
Creates or updates a network slice.
Must be created in the same location as its parent mobile network.

### [Remove-AzMobileNetwork](Remove-AzMobileNetwork.md)
Deletes the specified mobile network.

### [Remove-AzMobileNetworkAttachedDataNetwork](Remove-AzMobileNetworkAttachedDataNetwork.md)
Deletes the specified attached data network.

### [Remove-AzMobileNetworkDataNetwork](Remove-AzMobileNetworkDataNetwork.md)
Deletes the specified data network.

### [Remove-AzMobileNetworkPacketCoreControlPlane](Remove-AzMobileNetworkPacketCoreControlPlane.md)
Deletes the specified packet core control plane.

### [Remove-AzMobileNetworkPacketCoreDataPlane](Remove-AzMobileNetworkPacketCoreDataPlane.md)
Deletes the specified packet core data plane.

### [Remove-AzMobileNetworkService](Remove-AzMobileNetworkService.md)
Deletes the specified service.

### [Remove-AzMobileNetworkSim](Remove-AzMobileNetworkSim.md)
Deletes the specified SIM.

### [Remove-AzMobileNetworkSimGroup](Remove-AzMobileNetworkSimGroup.md)
Deletes the specified SIM group.

### [Remove-AzMobileNetworkSimPolicy](Remove-AzMobileNetworkSimPolicy.md)
Deletes the specified SIM policy.

### [Remove-AzMobileNetworkSite](Remove-AzMobileNetworkSite.md)
Deletes the specified mobile network site.
This will also delete any network functions that are a part of this site.

### [Remove-AzMobileNetworkSlouse](Remove-AzMobileNetworkSlouse.md)
Deletes the specified network slice.

### [Update-AzMobileNetworkAttachedDataNetworkTag](Update-AzMobileNetworkAttachedDataNetworkTag.md)
Updates an attached data network tags.

### [Update-AzMobileNetworkDataNetworkTag](Update-AzMobileNetworkDataNetworkTag.md)
Updates data network tags.

### [Update-AzMobileNetworkPacketCoreControlPlaneTag](Update-AzMobileNetworkPacketCoreControlPlaneTag.md)
Updates packet core control planes tags.

### [Update-AzMobileNetworkPacketCoreDataPlaneTag](Update-AzMobileNetworkPacketCoreDataPlaneTag.md)
Updates packet core data planes tags.

### [Update-AzMobileNetworkServiceTag](Update-AzMobileNetworkServiceTag.md)
Updates service tags.

### [Update-AzMobileNetworkSimGroupTag](Update-AzMobileNetworkSimGroupTag.md)
Updates SIM group tags.

### [Update-AzMobileNetworkSimPolicyTag](Update-AzMobileNetworkSimPolicyTag.md)
Updates SIM policy tags.

### [Update-AzMobileNetworkSiteTag](Update-AzMobileNetworkSiteTag.md)
Updates site tags.

### [Update-AzMobileNetworkSlouseTag](Update-AzMobileNetworkSlouseTag.md)
Updates slice tags.

### [Update-AzMobileNetworkTag](Update-AzMobileNetworkTag.md)
Updates mobile network tags.

