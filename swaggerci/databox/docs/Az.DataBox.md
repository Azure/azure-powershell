---
Module Name: Az.DataBox
Module Guid: 3ac8cee6-4037-42b3-bc48-383456741975
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.databox
Help Version: 1.0.0.0
Locale: en-US
---

# Az.DataBox Module
## Description
Microsoft Azure PowerShell: DataBox cmdlets

## Az.DataBox Cmdlets
### [Get-AzDataBoxJob](Get-AzDataBoxJob.md)
Gets information about the specified job.

### [Get-AzDataBoxJobCredentials](Get-AzDataBoxJobCredentials.md)
This method gets the unencrypted secrets related to the job.

### [Get-AzDataBoxServiceAvailableSku](Get-AzDataBoxServiceAvailableSku.md)
This method provides the list of available skus for the given subscription, resource group and location.

### [Invoke-AzDataBoxBookJobShipmentPickUp](Invoke-AzDataBoxBookJobShipmentPickUp.md)
Book shipment pick up.

### [Invoke-AzDataBoxMarkJobDeviceShipped](Invoke-AzDataBoxMarkJobDeviceShipped.md)
Request to mark devices for a given job as shipped

### [Invoke-AzDataBoxMitigate](Invoke-AzDataBoxMitigate.md)
Request to mitigate for a given job

### [Invoke-AzDataBoxRegionServiceConfiguration](Invoke-AzDataBoxRegionServiceConfiguration.md)
This API provides configuration details specific to given region/location at Subscription level.

### [New-AzDataBoxJob](New-AzDataBoxJob.md)
Creates a new job with the specified parameters.
Existing job cannot be updated with this API and should instead be updated with the Update job API.

### [Remove-AzDataBoxJob](Remove-AzDataBoxJob.md)
Deletes a job.

### [Stop-AzDataBoxJob](Stop-AzDataBoxJob.md)
CancelJob.

### [Test-AzDataBoxServiceAddress](Test-AzDataBoxServiceAddress.md)
[DEPRECATED NOTICE: This operation will soon be removed].
This method validates the customer shipping address and provide alternate addresses if any.

### [Test-AzDataBoxServiceInput](Test-AzDataBoxServiceInput.md)
This method does all necessary pre-job creation validation under resource group.

### [Update-AzDataBoxJob](Update-AzDataBoxJob.md)
Updates the properties of an existing job.

