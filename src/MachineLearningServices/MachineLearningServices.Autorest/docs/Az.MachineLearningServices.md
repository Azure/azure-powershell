---
Module Name: Az.MachineLearningServices
Module Guid: 56293047-9014-4c88-96b7-98b69c3b687d
Download Help Link: https://learn.microsoft.com/powershell/module/az.machinelearningservices
Help Version: 1.0.0.0
Locale: en-US
---

# Az.MachineLearningServices Module
## Description
Microsoft Azure PowerShell: MachineLearningServices cmdlets

## Az.MachineLearningServices Cmdlets
### [Get-AzMLServiceQuota](Get-AzMLServiceQuota.md)
Gets the currently assigned Workspace Quotas based on VMFamily.

### [Get-AzMLServiceUsage](Get-AzMLServiceUsage.md)
Gets the current usage information as well as limits for AML resources for given subscription and location.

### [Get-AzMLServiceVMSize](Get-AzMLServiceVMSize.md)
Returns supported VM Sizes in a location

### [Get-AzMLWorkspace](Get-AzMLWorkspace.md)
Gets the properties of the specified machine learning workspace.

### [Get-AzMLWorkspaceBatchDeployment](Get-AzMLWorkspaceBatchDeployment.md)
Gets a batch inference deployment by id.

### [Get-AzMLWorkspaceBatchEndpoint](Get-AzMLWorkspaceBatchEndpoint.md)
Gets a batch inference endpoint by name.

### [Get-AzMLWorkspaceCodeVersion](Get-AzMLWorkspaceCodeVersion.md)
Get version.

### [Get-AzMLWorkspaceComponentContainer](Get-AzMLWorkspaceComponentContainer.md)
Get container.

### [Get-AzMLWorkspaceComponentVersion](Get-AzMLWorkspaceComponentVersion.md)
Get version.

### [Get-AzMLWorkspaceCompute](Get-AzMLWorkspaceCompute.md)
Gets compute definition by its name.
Any secrets (storage keys, service credentials, etc) are not returned - use 'keys' nested resource to get them.

### [Get-AzMLWorkspaceComputeKey](Get-AzMLWorkspaceComputeKey.md)
Gets secrets related to Machine Learning compute (storage keys, service credentials, etc).

### [Get-AzMLWorkspaceComputeNode](Get-AzMLWorkspaceComputeNode.md)
Get the details (e.g IP address, port etc) of all the compute nodes in the compute.

### [Get-AzMLWorkspaceConnection](Get-AzMLWorkspaceConnection.md)
Get a new workspace connection

### [Get-AzMLWorkspaceDataContainer](Get-AzMLWorkspaceDataContainer.md)
Get container.

### [Get-AzMLWorkspaceDatastore](Get-AzMLWorkspaceDatastore.md)
Get datastore.

### [Get-AzMLWorkspaceDatastoreSecret](Get-AzMLWorkspaceDatastoreSecret.md)
Get datastore secrets.

### [Get-AzMLWorkspaceDataVersion](Get-AzMLWorkspaceDataVersion.md)
Get version.

### [Get-AzMLWorkspaceEnvironmentContainer](Get-AzMLWorkspaceEnvironmentContainer.md)
Get container.

### [Get-AzMLWorkspaceEnvironmentVersion](Get-AzMLWorkspaceEnvironmentVersion.md)
Get version.

### [Get-AzMLWorkspaceFeature](Get-AzMLWorkspaceFeature.md)
Lists all enabled features for a workspace

### [Get-AzMLWorkspaceJob](Get-AzMLWorkspaceJob.md)
Gets a Job by name/id.

### [Get-AzMLWorkspaceKey](Get-AzMLWorkspaceKey.md)
Lists all the keys associated with this workspace.
This includes keys for the storage account, app insights and password for container registry

### [Get-AzMLWorkspaceModelContainer](Get-AzMLWorkspaceModelContainer.md)
Get container.

### [Get-AzMLWorkspaceModelVersion](Get-AzMLWorkspaceModelVersion.md)
Get version.

### [Get-AzMLWorkspaceNotebookAccessToken](Get-AzMLWorkspaceNotebookAccessToken.md)
return notebook access token and refresh token

### [Get-AzMLWorkspaceNotebookKey](Get-AzMLWorkspaceNotebookKey.md)
List keys of a notebook.

### [Get-AzMLWorkspaceOnlineDeployment](Get-AzMLWorkspaceOnlineDeployment.md)
Get Inference Deployment Deployment.

### [Get-AzMLWorkspaceOnlineDeploymentLog](Get-AzMLWorkspaceOnlineDeploymentLog.md)
Polls an Endpoint operation.

### [Get-AzMLWorkspaceOnlineDeploymentSku](Get-AzMLWorkspaceOnlineDeploymentSku.md)
List Inference Endpoint Deployment Skus.

### [Get-AzMLWorkspaceOnlineEndpoint](Get-AzMLWorkspaceOnlineEndpoint.md)
Get Online Endpoint.

### [Get-AzMLWorkspaceOnlineEndpointKey](Get-AzMLWorkspaceOnlineEndpointKey.md)
List EndpointAuthKeys for an Endpoint using Key-based authentication.

### [Get-AzMLWorkspaceOnlineEndpointToken](Get-AzMLWorkspaceOnlineEndpointToken.md)
Retrieve a valid AAD token for an Endpoint using AMLToken-based authentication.

### [Get-AzMLWorkspaceOutboundNetworkDependencyEndpoint](Get-AzMLWorkspaceOutboundNetworkDependencyEndpoint.md)
Called by Client (Portal, CLI, etc) to get a list of all external outbound dependencies (FQDNs) programmatically.

### [Get-AzMLWorkspaceStorageAccountKey](Get-AzMLWorkspaceStorageAccountKey.md)
List storage account keys of a workspace.

### [Invoke-AzMLWorkspaceDiagnose](Invoke-AzMLWorkspaceDiagnose.md)
Diagnose workspace setup issue.

### [Invoke-AzMLWorkspaceNotebook](Invoke-AzMLWorkspaceNotebook.md)
Prepare a notebook.

### [New-AzMLWorkspace](New-AzMLWorkspace.md)
Creates or updates a workspace with the specified parameters.

### [New-AzMLWorkspaceAksObject](New-AzMLWorkspaceAksObject.md)
Create an in-memory object for Aks.

### [New-AzMLWorkspaceAmlComputeObject](New-AzMLWorkspaceAmlComputeObject.md)
Create an in-memory object for AmlCompute.

### [New-AzMLWorkspaceBatchDeployment](New-AzMLWorkspaceBatchDeployment.md)
Creates/updates a batch inference deployment (asynchronous).

### [New-AzMLWorkspaceBatchEndpoint](New-AzMLWorkspaceBatchEndpoint.md)
Creates a batch inference endpoint (asynchronous).

### [New-AzMLWorkspaceCodeVersion](New-AzMLWorkspaceCodeVersion.md)
Create or update version.

### [New-AzMLWorkspaceCommandJobObject](New-AzMLWorkspaceCommandJobObject.md)
Create an in-memory object for CommandJob.

### [New-AzMLWorkspaceComponentContainer](New-AzMLWorkspaceComponentContainer.md)
Create or update container.

### [New-AzMLWorkspaceComponentVersion](New-AzMLWorkspaceComponentVersion.md)
Create or update version.

### [New-AzMLWorkspaceCompute](New-AzMLWorkspaceCompute.md)
Creates or updates compute.
This call will overwrite a compute if it exists.
This is a nonrecoverable operation.
If your intent is to create a new compute, do a GET first to verify that it does not exist yet.

### [New-AzMLWorkspaceComputeInstanceObject](New-AzMLWorkspaceComputeInstanceObject.md)
Create an in-memory object for ComputeInstance.

### [New-AzMLWorkspaceComputeStartStopScheduleObject](New-AzMLWorkspaceComputeStartStopScheduleObject.md)
Create an in-memory object for ComputeStartStopSchedule.

### [New-AzMLWorkspaceConnection](New-AzMLWorkspaceConnection.md)
Creating or updating a new workspace connection

### [New-AzMLWorkspaceCustomModelJobInputObject](New-AzMLWorkspaceCustomModelJobInputObject.md)
Create an in-memory object for CustomModelJobInput.

### [New-AzMLWorkspaceCustomModelJobOutputObject](New-AzMLWorkspaceCustomModelJobOutputObject.md)
Create an in-memory object for CustomModelJobOutput.

### [New-AzMLWorkspaceDatabricksObject](New-AzMLWorkspaceDatabricksObject.md)
Create an in-memory object for Databricks.

### [New-AzMLWorkspaceDataContainer](New-AzMLWorkspaceDataContainer.md)
Create or update container.

### [New-AzMLWorkspaceDataFactoryObject](New-AzMLWorkspaceDataFactoryObject.md)
Create an in-memory object for DataFactory.

### [New-AzMLWorkspaceDataLakeAnalyticsObject](New-AzMLWorkspaceDataLakeAnalyticsObject.md)
Create an in-memory object for DataLakeAnalytics.

### [New-AzMLWorkspaceDatastore](New-AzMLWorkspaceDatastore.md)
Create or update datastore.

### [New-AzMLWorkspaceDatastoreBlobObject](New-AzMLWorkspaceDatastoreBlobObject.md)
Create an in-memory object for AzureBlobDatastore.

### [New-AzMLWorkspaceDatastoreCredentialObject](New-AzMLWorkspaceDatastoreCredentialObject.md)
Create an in-memory object for CertificateDatastoreCredentials.

### [New-AzMLWorkspaceDatastoreDataLakeGen1Object](New-AzMLWorkspaceDatastoreDataLakeGen1Object.md)
Create an in-memory object for AzureDataLakeGen1Datastore.

### [New-AzMLWorkspaceDatastoreDataLakeGen2Object](New-AzMLWorkspaceDatastoreDataLakeGen2Object.md)
Create an in-memory object for AzureDataLakeGen2Datastore.

### [New-AzMLWorkspaceDatastoreFileObject](New-AzMLWorkspaceDatastoreFileObject.md)
Create an in-memory object for AzureFileDatastore.

### [New-AzMLWorkspaceDatastoreKeyCredentialObject](New-AzMLWorkspaceDatastoreKeyCredentialObject.md)
Create an in-memory object for AccountKeyDatastoreCredentials.

### [New-AzMLWorkspaceDatastoreNoneCredentialObject](New-AzMLWorkspaceDatastoreNoneCredentialObject.md)
Create an in-memory object for NoneDatastoreCredentials.

### [New-AzMLWorkspaceDatastoreSasCredentialObject](New-AzMLWorkspaceDatastoreSasCredentialObject.md)
Create an in-memory object for SasDatastoreCredentials.

### [New-AzMLWorkspaceDatastoreServicePrincipalCredentialObject](New-AzMLWorkspaceDatastoreServicePrincipalCredentialObject.md)
Create an in-memory object for ServicePrincipalDatastoreCredentials.

### [New-AzMLWorkspaceDataVersion](New-AzMLWorkspaceDataVersion.md)
Create or update version.

### [New-AzMLWorkspaceEnvironmentVersion](New-AzMLWorkspaceEnvironmentVersion.md)
Creates or updates an EnvironmentVersion.

### [New-AzMLWorkspaceHDInsightObject](New-AzMLWorkspaceHDInsightObject.md)
Create an in-memory object for HDInsight.

### [New-AzMLWorkspaceJob](New-AzMLWorkspaceJob.md)
Creates and executes a Job.

### [New-AzMLWorkspaceJobServiceObject](New-AzMLWorkspaceJobServiceObject.md)
Create an in-memory object for JobService.

### [New-AzMLWorkspaceKubernetesObject](New-AzMLWorkspaceKubernetesObject.md)
Create an in-memory object for Kubernetes.

### [New-AzMLWorkspaceLiteralJobInputObject](New-AzMLWorkspaceLiteralJobInputObject.md)
Create an in-memory object for LiteralJobInput.

### [New-AzMLWorkspaceMLFlowModelJobInputObject](New-AzMLWorkspaceMLFlowModelJobInputObject.md)
Create an in-memory object for MLFlowModelJobInput.

### [New-AzMLWorkspaceMLFlowModelJobOutputObject](New-AzMLWorkspaceMLFlowModelJobOutputObject.md)
Create an in-memory object for MLFlowModelJobOutput.

### [New-AzMLWorkspaceMLTableJobInputObject](New-AzMLWorkspaceMLTableJobInputObject.md)
Create an in-memory object for MLTableJobInput.

### [New-AzMLWorkspaceMLTableJobOutputObject](New-AzMLWorkspaceMLTableJobOutputObject.md)
Create an in-memory object for MLTableJobOutput.

### [New-AzMLWorkspaceModelContainer](New-AzMLWorkspaceModelContainer.md)
Create or update container.

### [New-AzMLWorkspaceModelVersion](New-AzMLWorkspaceModelVersion.md)
Create or update version.

### [New-AzMLWorkspaceOnlineDeployment](New-AzMLWorkspaceOnlineDeployment.md)
Create or update Inference Endpoint Deployment (asynchronous).

### [New-AzMLWorkspaceOnlineEndpoint](New-AzMLWorkspaceOnlineEndpoint.md)
Create or update Online Endpoint (asynchronous).

### [New-AzMLWorkspaceOnlineEndpointKey](New-AzMLWorkspaceOnlineEndpointKey.md)
Regenerate EndpointAuthKeys for an Endpoint using Key-based authentication (asynchronous).

### [New-AzMLWorkspacePipelineJobObject](New-AzMLWorkspacePipelineJobObject.md)
Create an in-memory object for PipelineJob.

### [New-AzMLWorkspaceQuotaPropertiesObject](New-AzMLWorkspaceQuotaPropertiesObject.md)
Create an in-memory object for QuotaBaseProperties.

### [New-AzMLWorkspaceSharedPrivateLinkResourceObject](New-AzMLWorkspaceSharedPrivateLinkResourceObject.md)
Create an in-memory object for SharedPrivateLinkResource.

### [New-AzMLWorkspaceSweepJobObject](New-AzMLWorkspaceSweepJobObject.md)
Create an in-memory object for SweepJob.

### [New-AzMLWorkspaceSynapseSparkObject](New-AzMLWorkspaceSynapseSparkObject.md)
Create an in-memory object for SynapseSpark.

### [New-AzMLWorkspaceTritonModelJobInputObject](New-AzMLWorkspaceTritonModelJobInputObject.md)
Create an in-memory object for TritonModelJobInput.

### [New-AzMLWorkspaceTritonModelJobOutputObject](New-AzMLWorkspaceTritonModelJobOutputObject.md)
Create an in-memory object for TritonModelJobOutput.

### [New-AzMLWorkspaceUriFileJobInputObject](New-AzMLWorkspaceUriFileJobInputObject.md)
Create an in-memory object for UriFileJobInput.

### [New-AzMLWorkspaceUriFileJobOutputObject](New-AzMLWorkspaceUriFileJobOutputObject.md)
Create an in-memory object for UriFileJobOutput.

### [New-AzMLWorkspaceUriFolderJobInputObject](New-AzMLWorkspaceUriFolderJobInputObject.md)
Create an in-memory object for UriFolderJobInput.

### [New-AzMLWorkspaceUriFolderJobOutputObject](New-AzMLWorkspaceUriFolderJobOutputObject.md)
Create an in-memory object for UriFolderJobOutput.

### [New-AzMLWorkspaceVirtualMachineObject](New-AzMLWorkspaceVirtualMachineObject.md)
Create an in-memory object for VirtualMachine.

### [Remove-AzMLWorkspace](Remove-AzMLWorkspace.md)
Deletes a machine learning workspace.

### [Remove-AzMLWorkspaceBatchDeployment](Remove-AzMLWorkspaceBatchDeployment.md)
Delete Batch Inference deployment (asynchronous).

### [Remove-AzMLWorkspaceBatchEndpoint](Remove-AzMLWorkspaceBatchEndpoint.md)
Delete Batch Inference Endpoint (asynchronous).

### [Remove-AzMLWorkspaceCodeVersion](Remove-AzMLWorkspaceCodeVersion.md)
Delete version.

### [Remove-AzMLWorkspaceComponentContainer](Remove-AzMLWorkspaceComponentContainer.md)
Delete container.

### [Remove-AzMLWorkspaceComponentVersion](Remove-AzMLWorkspaceComponentVersion.md)
Delete version.

### [Remove-AzMLWorkspaceCompute](Remove-AzMLWorkspaceCompute.md)
Deletes specified Machine Learning compute.

### [Remove-AzMLWorkspaceConnection](Remove-AzMLWorkspaceConnection.md)
Remove a new workspace connection

### [Remove-AzMLWorkspaceDataContainer](Remove-AzMLWorkspaceDataContainer.md)
Delete container.

### [Remove-AzMLWorkspaceDatastore](Remove-AzMLWorkspaceDatastore.md)
Delete datastore.

### [Remove-AzMLWorkspaceDataVersion](Remove-AzMLWorkspaceDataVersion.md)
Delete version.

### [Remove-AzMLWorkspaceEnvironmentContainer](Remove-AzMLWorkspaceEnvironmentContainer.md)
Delete container.

### [Remove-AzMLWorkspaceEnvironmentVersion](Remove-AzMLWorkspaceEnvironmentVersion.md)
Delete version.

### [Remove-AzMLWorkspaceJob](Remove-AzMLWorkspaceJob.md)
Deletes a Job (asynchronous).

### [Remove-AzMLWorkspaceModelContainer](Remove-AzMLWorkspaceModelContainer.md)
Delete container.

### [Remove-AzMLWorkspaceModelVersion](Remove-AzMLWorkspaceModelVersion.md)
Delete version.

### [Remove-AzMLWorkspaceOnlineDeployment](Remove-AzMLWorkspaceOnlineDeployment.md)
Delete Inference Endpoint Deployment (asynchronous).

### [Remove-AzMLWorkspaceOnlineEndpoint](Remove-AzMLWorkspaceOnlineEndpoint.md)
Delete Online Endpoint (asynchronous).

### [Restart-AzMLWorkspaceCompute](Restart-AzMLWorkspaceCompute.md)
Posts a restart action to a compute instance

### [Start-AzMLWorkspaceCompute](Start-AzMLWorkspaceCompute.md)
Posts a start action to a compute instance

### [Stop-AzMLWorkspaceCompute](Stop-AzMLWorkspaceCompute.md)
Posts a stop action to a compute instance

### [Stop-AzMLWorkspaceJob](Stop-AzMLWorkspaceJob.md)
Cancels a Job (asynchronous).

### [Sync-AzMLWorkspaceKey](Sync-AzMLWorkspaceKey.md)
Resync all the keys associated with this workspace.
This includes keys for the storage account, app insights and password for container registry

### [Update-AzMLServiceQuota](Update-AzMLServiceQuota.md)
Update quota for each VM family in workspace.

### [Update-AzMLWorkspace](Update-AzMLWorkspace.md)
Updates a machine learning workspace with the specified parameters.

### [Update-AzMLWorkspaceBatchDeployment](Update-AzMLWorkspaceBatchDeployment.md)
Update a batch inference deployment (asynchronous).

### [Update-AzMLWorkspaceBatchEndpoint](Update-AzMLWorkspaceBatchEndpoint.md)
Update a batch inference endpoint (asynchronous).

### [Update-AzMLWorkspaceCompute](Update-AzMLWorkspaceCompute.md)
Updates properties of a compute.
This call will overwrite a compute if it exists.
This is a nonrecoverable operation.

### [Update-AzMLWorkspaceOnlineDeployment](Update-AzMLWorkspaceOnlineDeployment.md)
Update Online Deployment (asynchronous).

### [Update-AzMLWorkspaceOnlineEndpoint](Update-AzMLWorkspaceOnlineEndpoint.md)
Update Online Endpoint (asynchronous).

