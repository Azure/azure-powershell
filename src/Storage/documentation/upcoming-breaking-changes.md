<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Upcoming Breaking Changes", and should adhere to the following format:

    # Upcoming Breaking Changes

    ## Release X.0.0 - January 2017

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above section follows the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

# Upcoming Breaking Changes

## Current Release

	The following cmdlets were affected this release:

	**Get-AzureStorageBlob**
	**Get-AzureStorageBlobContent**
	**Get-AzureStorageBlobCopyState**
	**Set-AzureStorageBlobContent**
	**Start-AzureStorageBlobCopy**
	**Stop-AzureStorageBlobCopy**
	- Following properties are removed from the output AzureStorageBlob.ICloudBlob.ServiceClient: LocationMode, MaximumExecutionTime, ServerTimeout, ParallelOperationThreadCount, SingleBlobUploadThresholdInBytes; they still can be found in AzureStorageBlob.ICloudBlob.ServiceClient.DefaultRequestOptions
		
	**Get-AzureStorageContainer**
	**New-AzureStorageContainer**
	**Set-AzureStorageContainerAcl**
	- Following properties are removed from the output AzureStorageContainer.CloudBlobContainer.ServiceClient: LocationMode, MaximumExecutionTime, ServerTimeout, ParallelOperationThreadCount, SingleBlobUploadThresholdInByte; they still can be found in AzureStorageContainer.CloudBlobContainer.ServiceClient.DefaultRequestOptions
	
	
	**Get-AzureStorageQueue**
	**New-AzureStorageQueue**
	- Following properties are removed from the output AzureStorageQueue.CloudQueue.ServiceClient: LocationMode, MaximumExecutionTime, RetryPolicy, ServerTimeout; they still can be found in AzureStorageQueue.CloudQueue.ServiceClient.DefaultRequestOptions
	
	**Get-AzureStorageTable**
	**New-AzureStorageTable**
	- Following properties are removed from the output AzureStorageTable.CloudTable.ServiceClient: LocationMode, MaximumExecutionTime, PayloadFormat, RetryPolicy ServerTimeout; they still can be found in AzureStorageTable.CloudTable.ServiceClient.DefaultRequestOptions

	```powershell
	# Old
		$LocationMode = (Get-AzureStorageBlob -Container $containername)[0].ICloudBlob.ServiceClient.LocationMode		
		$ParallelOperationThreadCount = (Get-AzureStorageContainer -Container $containername).CloudBlobContainer.ServiceClient.ParallelOperationThreadCount
		$PayloadFormat = (Get-AzureStorageTable -Name $tablename).CloudTable.ServiceClient.PayloadFormat
		$RetryPolicy = (Get-AzureStorageQueue -Name $queuename).CloudQueue.ServiceClient.RetryPolicy

	# New
	
		$LocationMode = (Get-AzureStorageBlob -Container $containername)[0].ICloudBlob.ServiceClient.DefaultRequestOptions.LocationMode		
		ParallelOperationThreadCount = (Get-AzureStorageContainer -Container $containername).CloudBlobContainer.ServiceClient.DefaultRequestOptions.ParallelOperationThreadCount
		$PayloadFormat = (Get-AzureStorageTable -Name $tablename).CloudTable.ServiceClient.DefaultRequestOptions.PayloadFormat
		$RetryPolicy = (Get-AzureStorageQueue -Name $queuename).CloudQueue.ServiceClient.DefaultRequestOptions.RetryPolicy