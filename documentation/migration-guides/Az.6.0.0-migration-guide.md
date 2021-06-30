# Migration Guide for Az 6.0.0
- [Migration Guide for Az 6.0.0](#migration-guide-for-az-600)
	- [Supported versions of PowerShell](#supported-versions-of-powershell)
	- [Az.Accounts](#azaccounts)
		- [`Connect-AzAccount`](#connect-azaccount)
	- [Az.ContainerInstance](#azcontainerinstance)
		- [`New-AzContainerGroup`](#new-azcontainergroup)
		- [`Remove-AzContainerGroup`](#remove-azcontainergroup)
		- [`Get-AzContainerGroup`](#get-azcontainergroup)
		- [`Get-AzContainerInstanceLog`](#get-azcontainerinstancelog)
	- [Az.DesktopVirtualization](#azdesktopvirtualization)
		- [`New-AzWvdHostPool`](#new-azwvdhostpool)
		- [`Expand-AzWvdMsixImage`](#expand-azwvdmsiximage)
		- [`New-AzWvdMsixPackage`](#new-azwvdmsixpackage)
		- [`Update-AzWvdHostPool`](#update-azwvdhostpool)
	- [Az.StreamAnalytics](#azstreamanalytics)
		- [`Get-AzStreamAnalyticsDefaultFunctionDefinition`](#get-azstreamanalyticsdefaultfunctiondefinition)
		- [`New-AzStreamAnalyticsJob`](#new-azstreamanalyticsjob)
		- [`New-AzStreamAnalyticsTransformation`](#new-azstreamanalyticstransformation)
	- [Az.RecoveryServices](#azrecoveryservices)
		- [`Set-AzRecoveryServicesBackupProperty`](#set-azrecoveryservicesbackupproperty)
		- [`Get-AzRecoveryServicesBackupJobDetail`](#get-azrecoveryservicesbackupjobdetail)
	- [Az.Storage](#azstorage)
		- [`Remove-AzRmStorageShare`](#remove-azrmstorageshare)
	- [Az.ServiceFabric](#azservicefabric)
		- [`Add-AzServiceFabricClusterCertificate`](#add-azservicefabricclustercertificate)
		- [`Get-AzServiceFabricManagedClusterService`](#get-azservicefabricmanagedclusterservice)
		- [`New-AzServiceFabricManagedCluster`](#new-azservicefabricmanagedcluster)
		- [`New-AzServiceFabricManagedClusterService`](#new-azservicefabricmanagedclusterservice)
		- [`Remove-AzServiceFabricClusterCertificate`](#remove-azservicefabricclustercertificate)
		- [`Remove-AzServiceFabricManagedClusterService`](#remove-azservicefabricmanagedclusterservice)
		- [`Set-AzServiceFabricManagedCluster`](#set-azservicefabricmanagedcluster)
		- [`Set-AzServiceFabricManagedClusterService`](#set-azservicefabricmanagedclusterservice)

## Supported versions of PowerShell

Due to [CVE-2021-26701](https://msrc.microsoft.com/update-guide/en-us/vulnerability/CVE-2021-26701) Az 6 is only supported on the following platforms:
- PowerShell 7.1: version 7.1.3 or above
- PowerShell 7.0: version 7.0.6 or above
- Windows PowerShell 5.1 

For further details, refer to the [Azure PowerShell support lifecycle](https://aka.ms/lifecycle)

## Az.Accounts

### `Connect-AzAccount`
Removed obsolete parameters ManagedServiceHostName, ManagedServicePort and ManagedServiceSecret.

#### Before
```powershell
Connect-AzAccount -Identity -ManagedServiceSecret $secret
```
#### After
```powershell
#To use customized MSI endpoint, please set environment variable MSI_ENDPOINT, e.g. "http://localhost:50342/oauth2/token"; to use customized MSI secret, please set environment variable MSI_SECRET.
Connect-AzAccount -Identity
```


## Az.ContainerInstance

### `New-AzContainerGroup`
No longer supports the parameter `Image`, `RegistryCredential`, `AzureFileVolumeShareName`, `AzureFileVolumeAccountCredential`, `AzureFileVolumeMountPath`, `IdentityId`, `AssignIdentity`, `OsType`, `Cpu`, `MemoryInGB`, `IpAddressType`, `DnsNameLabel`, `Port`, `Command`, `EnvironmentVariable`, `RegistryServerDomain` and no alias was found for the original parameter name.

#### Before
```powershell
PS C:\> New-AzContainerGroup -ResourceGroupName demo -Name mycontainer -Image nginx -OsType Linux -IpAddressType Public -Port @(8000)

ResourceGroupName        : demo
Id                       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/demo/providers/Microsoft.ContainerInstance/containerGroups/mycontainer
Name                     : mycontainer
Type                     : Microsoft.ContainerInstance/containerGroups
Location                 : westus
Tags                     :
ProvisioningState        : Creating
Containers               : {mycontainer}
ImageRegistryCredentials :
RestartPolicy            :
IpAddress                : 13.88.10.240
Ports                    : {8000}
OsType                   : Linux
Volumes                  :
State                    : Running
Events                   : {}
```
#### After
```powershell
PS C:\> $port1 = New-AzContainerInstancePortObject -Port 8000 -Protocol TCP
PS C:\> $port2 = New-AzContainerInstancePortObject -Port 8001 -Protocol TCP
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image nginx -RequestCpu 1 -RequestMemoryInGb 1.5 -Port @($port1, $port2)
PS C:\> $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType Public

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```


### `Remove-AzContainerGroup`
The cmdlet 'Remove-AzContainerGroup' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.

#### Before
```powershell
PS C:\> Find-AzResource -ResourceGroupEquals MyResourceGroup -ResourceNameEquals MyContainer | Remove-AzContainerGroup
```
#### After
```powershell
PS C:\> Remove-AzContainerGroup -Name test-cg -ResourceGroupName test-rg

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```


### `Get-AzContainerGroup`
The cmdlet 'Get-AzContainerGroup' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.

#### Before
```powershell
PS C:\> Find-AzResource -ResourceGroupEquals demo -ResourceNameEquals mycontainer | Get-AzContainerGroup

ResourceGroupName        : demo
Id                       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/demo/providers/Microsoft.ContainerInstance/containerGroups/mycontainer
Name                     : mycontainer
Type                     : Microsoft.ContainerInstance/containerGroups
Location                 : westus
Tags                     :
ProvisioningState        : Succeeded
Containers               : {mycontainer}
ImageRegistryCredentials :
RestartPolicy            :
IpAddress                : 13.88.10.240
Ports                    : {8000}
OsType                   : Linux
Volumes                  :
State                    : Running
Events                   : {}
```
#### After
```powershell
PS C:\> Get-AzContainerGroup

Location Name           Type
-------- ----           ----
eastus   bez-cg1         Microsoft.ContainerInstance/containerGroups
eastus   bez-cg2        Microsoft.ContainerInstance/containerGroups
```


### `Get-AzContainerInstanceLog`
The cmdlet 'Get-AzContainerInstanceLog' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
The cmdlet 'Get-AzContainerInstanceLog' no longer supports the parameter 'Name' and no alias was found for the original parameter name.

#### Before
```powershell
PS C:\> Get-AzContainerGroup -ResourceGroupName demo -Name mycontainer | Get-AzContainerInstanceLog

Log line 1.
Log line 2.
Log line 3.
Log line 4.
```
#### After
```powershell
PS C:\> Get-AzContainerInstanceLog -ContainerGroupName test-cg -ContainerName test-container -ResourceGroupName test-rg
```
## Az.DesktopVirtualization

### `New-AzWvdHostPool`
The cmdlet 'New-AzWvdHostPool' no longer supports the parameter 'SsoContext' and no alias was found for the original parameter name.

### `Expand-AzWvdMsixImage`
The cmdlet 'Expand-AzWvdMsixImage' no longer supports the type 'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixImageUri' for parameter 'MsixImageUri'.

#### Before
```powershell
$MsixImageUri = [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixImageUri]::New()
Get-AzWvdDesktop -ResourceGroupName ResourceGroupName -ApplicationGroupName ApplicationGroupName -Name DesktopName | Expand-AzWvdMsixImage -MsixImageUri $MsixImageUri
```
#### After
```powershell
$MsixImageUri = [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IMsixImageUri]::New()
Get-AzWvdDesktop -ResourceGroupName ResourceGroupName -ApplicationGroupName ApplicationGroupName -Name DesktopName | Expand-AzWvdMsixImage -MsixImageUri $MsixImageUri
```


### `New-AzWvdMsixPackage`
The element type for parameter 'PackageApplication' has been changed from 'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplications' to 'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IMsixPackageApplications'.
The element type for parameter 'PackageDependency' has been changed from 'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageDependencies' to 'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IMsixPackageDependencies'.

#### Before
```powershell
PS C:\> $apps = @([Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplications]::New())
PS C:\> $deps = @([Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageDependencies]::New())
PS C:\> New-AzWvdMsixPackage -FullName PackageFullName `
							-HostPoolName HostPoolName `
							-ResourceGroupName ResourceGroupName ` 
							-SubscriptionId SubscriptionId ` 
							-DisplayName displayname `
							-ImagePath imageURI ` 
							-IsActive:$false `
							-IsRegularRegistration:$false `
							-LastUpdated datelastupdated `
							-PackageApplication $apps `
							-PackageDependency $deps `
							-PackageFamilyName packagefamilyname `
							-PackageName packagename `
							-PackageRelativePath packagerelativepath `
							-Version packageversion `
```
#### After
```powershell
PS C:\> $apps = @([Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IMsixPackageApplications]::New())
PS C:\> $deps = @([Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IMsixPackageDependencies]::New())
PS C:\> New-AzWvdMsixPackage -FullName PackageFullName `
							-HostPoolName HostPoolName `
							-ResourceGroupName ResourceGroupName ` 
							-SubscriptionId SubscriptionId ` 
							-DisplayName displayname `
							-ImagePath imageURI ` 
							-IsActive:$false `
							-IsRegularRegistration:$false `
							-LastUpdated datelastupdated `
							-PackageApplication $apps `
							-PackageDependency $deps `
							-PackageFamilyName packagefamilyname `
							-PackageName packagename `
							-PackageRelativePath packagerelativepath `
							-Version packageversion `
```


### `Update-AzWvdHostPool`
The cmdlet 'Update-AzWvdHostPool' no longer supports the parameter 'SsoContext' and no alias was found for the original parameter name.



## Az.StreamAnalytics

### `Get-AzStreamAnalyticsDefaultFunctionDefinition`

The cmdlet 'Get-AzStreamAnalyticsDefaultFunctionDefinition' no longer supports the parameter 'File' and no alias was found for the original parameter name.

#### Before
```powershell
Get-AzStreamAnalyticsDefaultFunctionDefinition -ResourceGroupName "StreamAnalytics-Default-West-US" -JobName "StreamJob22" -File "C:\RetrieveDefaultDefinitionRequest.json" -Name "ScoreTweet"
```
#### After
```powershell
Get-AzStreamAnalyticsDefaultFunctionDefinition -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name mlsfunction-01 -BindingType Microsoft.MachineLearningServices -Endpoint "http://875da830-4d5f-44f1-b221-718a5f26a21d.eastus.azurecontainer.io/score"-UdfType Scalar
Input is specified in flattened parameters instead from the input file.
```


### `New-AzStreamAnalyticsJob`
The cmdlet 'New-AzStreamAnalyticsJob' no longer supports the parameter 'File' and no alias was found for the original parameter name.

#### Before
```powershell
New-AzStreamAnalyticsJob -ResourceGroupName "StreamAnalytics-Default-West-US" -File "C:\JobDefinition.json"
```
#### After
```powershell
New-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-02-pwsh -Location westcentralus -SkuName Standard
Input is specified in flattened parameters instead from the input file.
```


### `New-AzStreamAnalyticsTransformation`
The cmdlet 'New-AzStreamAnalyticsTransformation' no longer supports the parameter 'File' and no alias was found for the original parameter name.

#### Before
```powershell
New-AzStreamAnalyticsTransformation -ResourceGroupName "StreamAnalytics-Default-West-US" -File "C:\Transformation.json" -JobName "StreamingJob" -Name "StreamingJobTransform"
```
#### After
```powershell
New-AzStreamAnalyticsTransformation -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name tranf-01 -StreamingUnit 6 -Query "Select Id, Name from input-01"
Input is specified in flattened parameters instead from the input file.
```


## Az.RecoveryServices

### `Set-AzRecoveryServicesBackupProperty`
Removed Set-AzRecoveryServicesBackupProperties plural alias, use Set-AzRecoveryServicesBackupProperty cmdlet name going forward

### `Get-AzRecoveryServicesBackupJobDetail`
Removed Get-AzRecoveryServicesBackupJobDetails plural alias, use Get-AzRecoveryServicesBackupJobDetail cmdlet name going forward

#### Before
```powershell
$jobDetails = Get-AzRecoveryServicesBackupJobDetails -VaultId $vault.ID -Job $job   
$jobDetails2 = Get-AzRecoveryServicesBackupJobDetails -VaultId $vault.ID -JobId $job.JobId
```
#### After
```powershell
$jobDetails = Get-AzRecoveryServicesBackupJobDetail -VaultId $vault.ID -Job $job   
$jobDetails2 = Get-AzRecoveryServicesBackupJobDetail -VaultId $vault.ID -JobId $job.JobId
```


## Az.Storage

### `Remove-AzRmStorageShare`
The cmdlet 'Remove-AzRmStorageShare' can remove share with snapshots by default before; but after the change remove share with snapshots will fail by default, need add parameter "-Include Snapshots" to make remove success.

#### Before
```powershell
Remove-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName
```
#### After
```powershell
Remove-AzRmStorageShare -ResourceGroupName $resourceGroupName -StorageAccountName $accountName -Name $shareName -Force -Include Snapshots
```


## Az.ServiceFabric

### `Add-AzServiceFabricClusterCertificate`
this cmdlet has been removed completly. please follow instructions here to add cluster certificates: https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-cluster-security-update-certs-azure#add-a-secondary-certificate-using-azure-resource-manager

### `Get-AzServiceFabricManagedClusterService`
Change PSManagedService model to avoid using the properties parameter directly from sdk. Now all the properties are in the first level of the object.
And remove deprecated parameters InstanceCloseDelayDuration, DropSourceReplicaOnMove and ServiceDnsName 

#### Before
```powershell
$service = Get-AzServiceFabricManagedClusterService -ResourceId $resourceId
$statelessService.Properties.ProvisioningState
```
#### After
```powershell
$service = Get-AzServiceFabricManagedClusterService -ResourceId $resourceId
$statelessService.ProvisioningState
```


### `New-AzServiceFabricManagedCluster`
Remove deprecated parameter ReverseProxyEndpointPort.

### `New-AzServiceFabricManagedClusterService`
Change PSManagedService model to avoid using the properties parameter directly from sdk. Now all the properties are in the first level of the object.
And remove deprecated parameters InstanceCloseDelayDuration, DropSourceReplicaOnMove and ServiceDnsName 

#### Before
```powershell
$service = New-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $serviceName -Type $serviceTypeName -Stateless -InstanceCount -1 -PartitionSchemaSingleton
$statelessService.Properties.ProvisioningState
```
#### After
```powershell
$service = New-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $serviceName -Type $serviceTypeName -Stateless -InstanceCount -1 -PartitionSchemaSingleton
$statelessService.ProvisioningState
```


### `Remove-AzServiceFabricClusterCertificate`
this cmdlet has been removed completly. please follow instructions here to add cluster certificates: https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-cluster-security-update-certs-azure#remove-a-cluster-certificate-using-the-portal

### `Remove-AzServiceFabricManagedClusterService`
Change PSManagedService model to avoid using the properties parameter directly from sdk. Now all the properties are in the first level of the object.

### `Set-AzServiceFabricManagedCluster`
Remove deprecated parameter ReverseProxyEndpointPort.

### `Set-AzServiceFabricManagedClusterService`
Change PSManagedService model to avoid using the properties parameter directly from sdk. Now all the properties are in the first level of the object.
And remove deprecated parameters InstanceCloseDelayDuration, DropSourceReplicaOnMove and ServiceDnsName 

#### Before
```powershell
$service = Get-AzServiceFabricManagedClusterService -ResourceId $resourceId
$statelessService.Properties.MinInstanceCount = 3
service | Set-AzServiceFabricManagedClusterService
```
#### After
```powershell
$service = Get-AzServiceFabricManagedClusterService -ResourceId $resourceId
$statelessService.MinInstanceCount = 3
service | Set-AzServiceFabricManagedClusterService
```



