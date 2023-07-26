# Upcoming breaking changes in Azure PowerShell

## Az.Aks

### `New-AzAksCluster`

- Parameter breaking-change will happen to all parameter sets
  - `-DockerBridgeCidr`
    - DockerBridgeCidr parameter will be deprecated in Az 11.0.0 without being replaced.
    - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

## Az.Compute

### `New-AzDisk`

- Cmdlet breaking-change will happen to all parameter set
  - Starting in November 2023 the "New-AzDisk" cmdlet will deploy with the Trusted Launch configuration by default. This includes defaulting the "HyperVGeneration" parameter to "v2". To know more about Trusted Launch, please visit https://learn.microsoft.com/en-us/azure/virtual-machines/trusted-launch
  - This change is expected to take effect from version: 7.0.0 and Az version: 11.0.0

### `New-AzVM`

- Cmdlet breaking-change will happen to all parameter set
  - Consider using the image alias including the version of the distribution you want to use in the "-Image" parameter of the "New-AzVM" cmdlet. On April 30, 2023, the image deployed using `UbuntuLTS` will reach its end of life. In October 2023, the aliases `UbuntuLTS`, `CentOS`, `Debian`, and `RHEL` will be removed.
  - This change is expected to take effect from version: 7.0.0 and Az version: 11.0.0
  - Starting in November 2023 the "New-AzVM" cmdlet will deploy with the Trusted Launch configuration by default. To know more about Trusted Launch, please visit https://docs.microsoft.com/en-us/azure/virtual-machines/trusted-launch
  - This change is expected to take effect from version: 7.0.0 and Az version: 11.0.0

### `New-AzVmss`

- Cmdlet breaking-change will happen to all parameter set
  - Starting November 2023, the "New-AzVmss" cmdlet will default to Trusted Launch VMSS. For more info, visit https://aka.ms/trustedLaunchVMSS.
  - This change is expected to take effect from version: 7.0.0 and Az version: 11.0.0
  - Starting November 2023, the "New-AzVmss" cmdlet will use new defaults: Flexible orchestration mode and enable NATv2 configuration for Load Balancer. To learn more about Flexible Orchestration modes, visit https://aka.ms/orchestrationModeVMSS.
  - This change is expected to take effect from version: 7.0.0 and Az version: 11.0.0
  - Consider using the image alias including the version of the distribution you want to use in the "-ImageName" parameter of the "New-AzVmss" cmdlet. On April 30, 2023, the image deployed using `UbuntuLTS` will reach its end of life. In November 2023, the aliases `UbuntuLTS`, `CentOS`, `Debian`, and `RHEL` will be removed.
  - This change is expected to take effect from version: 7.0.0 and Az version: 11.0.0

## Az.DesktopVirtualization

### `New-AzWvdScalingPlan`

- Parameter breaking-change will happen to all parameter sets
  - `-HostPoolType`
    - The parameter : 'HostPoolType' is changing.
    - The change is expected to take effect from the version : '4.0.0'

## Az.Maintenance

### `New-AzMaintenanceConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-PostTask`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from version: 1.2.2 and Az version: 10.2.0
  - `-PreTask`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from version: 1.2.2 and Az version: 10.2.0

## Az.PowerBIEmbedded

### `Get-AzPowerBIWorkspace`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from version: 2.0.0 and Az version: 11.0.0

### `Get-AzPowerBIWorkspaceCollection`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from version: 2.0.0 and Az version: 11.0.0

### `Get-AzPowerBIWorkspaceCollectionAccessKey`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from version: 2.0.0 and Az version: 11.0.0

### `New-AzPowerBIWorkspaceCollection`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from version: 2.0.0 and Az version: 11.0.0

### `Remove-AzPowerBIWorkspaceCollection`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from version: 2.0.0 and Az version: 11.0.0

### `Reset-AzPowerBIWorkspaceCollectionAccessKey`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from version: 2.0.0 and Az version: 11.0.0

## Az.RecoveryServices

### `Get-AzRecoveryServicesVaultSettingsFile`

- Parameter breaking-change will happen to all parameter sets
  - `-Certificate`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from version: 7.0.0 and Az version: 11.0.0

## Az.Storage

### `New-AzDataLakeGen2SasToken`

- Cmdlet breaking-change will happen to all parameter set
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageAccount`

- Cmdlet breaking-change will happen to all parameter set
  - Default value of AllowBlobPublicAccess and AllowCrossTenantReplication will be changed from True to False in a future release. 
  When AllowBlobPublicAccess is False on a storage account, it is not permitted to configure container ACLs to allow anonymous access to blobs within the storage account. 
  When AllowCrossTenantReplication is False on a storage account, cross AAD tenant object replication is not allowed.
  - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageAccountSASToken`

- Cmdlet breaking-change will happen to all parameter set
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageBlobSASToken`

- Cmdlet breaking-change will happen to all parameter set
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageContainerSASToken`

- Cmdlet breaking-change will happen to all parameter set
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageContext`

- Parameter breaking-change will happen to all parameter sets
  - `-SasToken`
    - The SAS token in created Storage context properties 'ConnectionString' and 'StorageAccount.Credentials' won't have the leading question mark '?' in a future release.
    - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageFileSASToken`

- Cmdlet breaking-change will happen to all parameter set
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageQueueSASToken`

- Cmdlet breaking-change will happen to all parameter set
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageShareSASToken`

- Cmdlet breaking-change will happen to all parameter set
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageTableSASToken`

- Cmdlet breaking-change will happen to all parameter set
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

### `Set-AzStorageAccount`

- Parameter breaking-change will happen to all parameter sets
  - `-EnableLargeFileShare`
    - EnableLargeFileShare parameter will be deprecated in a future release.
    - This change is expected to take effect from version: 6.0.0 and Az version: 11.0.0

