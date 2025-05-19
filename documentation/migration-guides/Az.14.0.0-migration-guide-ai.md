# Migration Guide for Az 14.0.0

## Az.Accounts

### `Get-AzAccessToken`

- The default output type is changing from `PSAccessToken` to `PSSecureAccessToken`, which means the token value will now be a `SecureString` instead of plaintext.
- Effective in Az.Accounts version 5.0.0 and Az version 14.0.0

#### Before
```powershell
$authHeader = @{
    'Content-Type'  = 'application/json'
    'Authorization' = 'Bearer ' + (Get-AccessToken)
}
$respone = Invoke-RestMethod -Method Get -Headers $authHeader -Uri $uri"	"$secureToken = (Get-AzAccessToken).Token
```

#### After
```powershell
$ssPtr = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($Securetoken)
try {
     $plaintextToken = [System.Runtime.InteropServices.Marshal]::PtrToStringBSTR($ssPtr)
} 
finally {
     [System.Runtime.InteropServices.Marshal]::ZeroFreeBSTR($ssPtr) 
}
$authHeader = @{
    'Content-Type'  = 'application/json'
    'Authorization' = 'Bearer ' + $plaintextToken
}
$respone = Invoke-RestMethod -Method Get -Headers $authHeader -Uri $uri
```


## Az.Aks

### `Get-AzAksMaintenanceConfiguration`
- Output type is changing from API-specific model to a more generic model
- Collection-type properties (`TimeInWeek` and `NotAllowedTime`) will now return generic List collections instead of arrays
- This change will take effect on May 19, 2025 in Az version 14.0.0 (Az.Aks version 2.0.0)

#### Before
```powershell
Get-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster
```

#### After
```powershell
Get-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster
```


### `Get-AzAksManagedClusterOSOption`
- Output type is changing to return properties as generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Aks version 2.0.0)

#### Before
```powershell
Get-AzAksManagedClusterOSOption -Location eastus
```

#### After
```powershell
Get-AzAksManagedClusterOSOption -Location eastus
```


### `Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint`
- Output property `Endpoint` is changing from a single object to a generic List collection
- Effective May 19, 2025 in Az version 14.0.0 (Az.Aks version 2.0.0)

#### Before
```powershell
$result = Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint -ResourceGroupName mygroup -ResourceName mycluster
$result | select Category,Endpoint
```

#### After
```powershell
$result = Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint -ResourceGroupName mygroup -ResourceName mycluster
$result | select Category,Endpoint
```


### `Get-AzAksNodePoolUpgradeProfile`
- Output property `Upgrade` is changing from a single object to a generic List collection
- Effective May 19, 2025 in Az version 14.0.0 (Az.Aks version 2.0.0)

#### Before
```powershell
Get-AzAksNodePoolUpgradeProfile -ResourceGroupName group -ClusterName myCluster -AgentPoolName default
```

#### After
```powershell
Get-AzAksNodePoolUpgradeProfile -ResourceGroupName group -ClusterName myCluster -AgentPoolName default
```


### `Get-AzAksUpgradeProfile`
- Output properties will now return generic List collections instead of single objects
- Effective May 19, 2025 in Az version 14.0.0 (Az.Aks version 2.0.0)

#### Before
```powershell
Get-AzAksUpgradeProfile -ResourceGroupName group -Name myCluster
```

#### After
```powershell
Get-AzAksUpgradeProfile -ResourceGroupName group -Name myCluster
```


### `Get-AzAksVersion`
- Output property `Orchestrator` is changing from a single object to a generic List collection
- Effective May 19, 2025 in Az version 14.0.0 (Az.Aks version 2.0.0)

#### Before
```powershell
Get-AzAksVersion -location eastus
```

#### After
```powershell
Get-AzAksVersion -location eastus
```


### `New-AzAksCluster`
- The default value of `-NodeVmSize` parameter is changing from 'Standard_D2_V2' to being dynamically selected by the AKS resource provider based on quota and capacity
- Effective in Az.Aks version 7.0.0 and Az version 14.0.0

#### Before
```powershell
If '-NodeVmSize' is not provided, the default NodeVmSize is 'Standard_D2_V2'。 
```

#### After
```powershell
If '-NodeVmSize' is not provided, the default NodeVmSize is dynamically selected by the AKS resource provider based on quota and capacity.
```


### `New-AzAksNodePool`
- The default value of `-VmSize` parameter is changing from 'Standard_D2_V2' to being dynamically selected by the AKS resource provider based on quota and capacity
- Effective in Az.Aks version 7.0.0 and Az version 14.0.0

#### Before
```powershell
If '-VmSize' is not provided, the default VmSize is 'Standard_D2_V2'。 
```

#### After
```powershell
If '-VmSize' is not provided, the default VmSize is dynamically selected by the AKS resource provider based on quota and capacity.
```


### `New-AzAksMaintenanceConfiguration`
- Output properties will now return generic List collections instead of arrays
- Effective May 19, 2025 in Az version 14.0.0 (Az.Aks version 2.0.0)

#### Before
```powershell
$TimeSpan = New-AzAksTimeSpanObject -Start (Get-Date -Year 2023 -Month 3 -Day 1) -End (Get-Date -Year 2023 -Month 3 -Day 2)
$TimeInWeek = New-AzAksTimeInWeekObject -Day 'Sunday' -HourSlot 1,2
$MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config' -TimeInWeek $TimeInWeek -NotAllowedTime $TimeSpan
```

#### After
```powershell
$TimeSpan = New-AzAksTimeSpanObject -Start (Get-Date -Year 2023 -Month 3 -Day 1) -End (Get-Date -Year 2023 -Month 3 -Day 2)
$TimeInWeek = New-AzAksTimeInWeekObject -Day Sunday -HourSlot 1,2
$MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config' -TimeInWeek $TimeInWeek -NotAllowedTime $TimeSpan
```


## Az.AppConfiguration

### `Get-AzAppConfigurationStore`
- Output property `PrivateEndpointConnection` is changing from a single object to a generic List collection
- Effective May 19, 2025 in Az version 14.0.0 (Az.AppConfiguration version 2.0.0)

#### Before
```powershell
Get-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp
```

#### After
```powershell
Get-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp
```


### `New-AzAppConfigurationStore`
- Parameter `-IdentityType` will be removed. Use `-EnableSystemAssignedIdentity` to enable/disable system assigned identity and `-UserAssignedIdentity` to specify user assigned identities
- Output property `PrivateEndpointConnection` will change from a single object to a generic List collection
- Effective May 19, 2025 in Az version 14.0.0 (Az.AppConfiguration version 2.0.0)

#### Before
```powershell
New-AzAppConfigurationStore -Name $storeName -ResourceGroupName $resourceGroupName -Location $location -Sku Standard -CreateMode 'Recover' -IdentityType SystemAssigned -UserAssignedIdentity "/subscriptions/xxxx/resourceGroups/azpstest_gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uai"
```

#### After
```powershell
New-AzAppConfigurationStore -Name $storeName -ResourceGroupName $resourceGroupName -Location $location -Sku Standard -CreateMode 'Recover' -EnableSystemAssignedIdentity:$true -UserAssignedIdentity "/subscriptions/xxxx/resourceGroups/azpstest_gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uai"
```


### `Update-AzAppConfigurationStore`
- Parameter `-IdentityType` will be removed. Use `-EnableSystemAssignedIdentity` to enable/disable system assigned identity and `-UserAssignedIdentity` to specify user assigned identities
- Output property `PrivateEndpointConnection` will change from a single object to a generic List collection
- Effective May 19, 2025 in Az version 14.0.0 (Az.AppConfiguration version 2.0.0)

#### Before
```powershell
Update-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp -DisableLocalAuth -EnablePurgeProtection -PublicNetworkAccess 'Enabled' -IdentityType SystemAssigned -UserAssignedIdentity "/subscriptions/xxxx/resourceGroups/azpstest_gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uai"
```

#### After
```powershell
Update-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp -DisableLocalAuth -EnablePurgeProtection -PublicNetworkAccess 'Enabled' -EnableSystemAssignedIdentity:$true -UserAssignedIdentity "/subscriptions/xxxx/resourceGroups/azpstest_gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uai"
```


## Az.Cdn

### `Clear-AzCdnEndpointContent`
- Property types are changing from arrays to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Clear-AzFrontDoorCdnEndpointContent`
- Property types are changing from arrays to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Get-AzCdnEdgeNode`
- Property types are changing from single objects to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Get-AzCdnEndpoint`
- Property types are changing from single objects to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Get-AzCdnOriginGroup`
- Property types are changing from single objects to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Get-AzFrontDoorCdnEndpoint`
- Property types are changing from single objects to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Get-AzFrontDoorCdnOriginGroup`
- Property types are changing from single objects to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Get-AzFrontDoorCdnRoute`
- Property types are changing from arrays to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Get-AzFrontDoorCdnRule`
- Property types are changing from single objects to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Import-AzCdnEndpointContent`
- Property types are changing from arrays to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `New-AzCdnEndpoint`
- Property types are changing from single objects to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `New-AzCdnManagedHttpsParametersObject`
- Adding new mandatory parameter `-CertificateSourceParameterTypeName`
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

#### Before
```powershell
New-AzCdnManagedHttpsParametersObject -CertificateSourceParameterCertificateType <CertificateType>
 -CertificateSource <CertificateSource> -ProtocolType <ProtocolType> [-MinimumTlsVersion <MinimumTlsVersion>]
```

#### After
```powershell
New-AzCdnManagedHttpsParametersObject -CertificateSourceParameterCertificateType <String>
 -CertificateSourceParameterTypeName <String> -ProtocolType <String> -CertificateSource <String>
 [-MinimumTlsVersion <String>]
```

### `New-AzCdnOriginGroup`
- Property types are changing from single objects to generic List collections
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `New-AzCdnUserManagedHttpsParametersObject`
- Adding new mandatory parameter `-CertificateSourceParameterTypeName`
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

#### Before
```powershell
New-AzCdnUserManagedHttpsParametersObject -CertificateSourceParameterResourceGroupName <String>
 -CertificateSourceParameterSecretName <String> -CertificateSourceParameterSubscriptionId <String>
 -CertificateSourceParameterVaultName <String> -CertificateSource <CertificateSource>
 -ProtocolType <ProtocolType> [-CertificateSourceParameterSecretVersion <String>]
 [-MinimumTlsVersion <MinimumTlsVersion>]
```

#### After
```powershell
New-AzCdnUserManagedHttpsParametersObject -CertificateSourceParameterResourceGroupName <String>
 -CertificateSourceParameterSecretName <String> -CertificateSourceParameterSubscriptionId <String>
 -CertificateSourceParameterTypeName <String> -CertificateSourceParameterVaultName <String>
 -CertificateSource <String> -ProtocolType <String> [-CertificateSourceParameterSecretVersion <String>]
 [-MinimumTlsVersion <String>]
```

### `New-AzFrontDoorCdnEndpoint`
- Enum parameters are changing to String type
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `New-AzFrontDoorCdnOriginGroup`
- Enum parameters are changing to String type
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `New-AzFrontDoorCdnRoute`
- Enum parameters are changing to String type
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `New-AzFrontDoorCdnRule`
- Parameter `-Action` is changing type
- Enum parameters are changing to String type
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Remove-AzCdnEndpoint`, `Remove-AzCdnOriginGroup`, `Remove-AzFrontDoorCdnEndpoint`, `Remove-AzFrontDoorCdnOriginGroup`, `Remove-AzFrontDoorCdnRoute`, `Remove-AzFrontDoorCdnRule`
- These cmdlets are being deprecated with no replacement
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Start-AzCdnEndpoint`, `Stop-AzCdnEndpoint`
- These cmdlets are being deprecated with no replacement
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)

### `Update-AzCdnEndpoint`, `Update-AzCdnOriginGroup`, `Update-AzFrontDoorCdnEndpoint`, `Update-AzFrontDoorCdnOriginGroup`, `Update-AzFrontDoorCdnRoute`, `Update-AzFrontDoorCdnRule`
- These cmdlets are being deprecated with no replacement
- Enum parameters are changing to String type
- Effective May 19, 2025 in Az version 14.0.0 (Az.Cdn version 5.0.0)


## Az.Compute

### `Get-AzVMSize`
- The "ListVirtualMachineSize" parameter set is being deprecated as its API is deprecated
- For listing available VM sizes by subscription or location, use `Get-AzComputeResourceSku` instead
- Parameter sets for "List Available Sizes for Availability Set" and "List Available Sizes for Virtual Machine" will continue to be supported
- Effective in Az.Compute version 10.0.0 and Az version 14.0.0

#### Before
```powershell
Get-AzVMSize -Location <string>
```

#### After
```powershell
Get-AzComputeResourceSku -Location <string>
```


## Az.Resources

### `Get-AzResource`
- The API version for the resource type will now use the default version instead of the latest version
- Effective in Az.Resources version 8.0.0 and Az version 14.0.0

### `Invoke-AzResourceAction`
- The API version for the resource type will now use the default version instead of the latest version
- In most situations, this change won't cause issues. If you see unexpected behavior, manually specify the API version
- Effective in Az.Resources version 8.0.0 and Az version 14.0.0

#### Before
```powershell
Invoke-AzResourceAction -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -Action <action>
```

#### After
```powershell
Invoke-AzResourceAction -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -Action <action> -ApiVersion <api version>
```

### `New-AzResource`
- The API version for the resource type will now use the default version instead of the latest version
- In most situations, this change won't cause issues. If you see unexpected behavior, manually specify the API version
- Effective in Az.Resources version 8.0.0 and Az version 14.0.0

#### Before
```powershell
New-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type>
```

#### After
```powershell
New-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -ApiVersion <api version>
```

### `Move-AzResource`
- The API version for the resource type will now use the default version instead of the latest version
- In most situations, this change won't cause issues. If you see unexpected behavior, manually specify the API version
- Effective in Az.Resources version 8.0.0 and Az version 14.0.0

#### Before
```powershell
Move-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type>
```

#### After
```powershell
Move-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -ApiVersion <api version>
```

### `Remove-AzResource`
- The API version for the resource type will now use the default version instead of the latest version
- Effective in Az.Resources version 8.0.0 and Az version 14.0.0

#### Before
```powershell
Remove-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type>
```

#### After
```powershell
Remove-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -ApiVersion <api version>
```

### `Set-AzResource`
- The API version for the resource type will now use the default version instead of the latest version
- In most situations, this change won't cause issues. If you see unexpected behavior, manually specify the API version
- Effective in Az.Resources version 8.0.0 and Az version 14.0.0

#### Before
```powershell
Set-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type>
```

#### After
```powershell
Set-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -ApiVersion <api version>
```


## Az.Storage

### `Set-AzStorageFileContent`
- The ContentHash properties will be removed from uploaded Azure files when:
  - File size > 1TB
  - Upload with OAuth credential
  - Upload with `-DisAllowTrailingDot` parameter
- Effective in Az.Storage version 9.0.0 and Az version 14.0.0

#### Before
```powershell
Set-AzStorageFileContent -ShareName $shareName -Path $filename -Source $localSrcFile -Context $ctxoauth
```

#### After
```powershell
# If need contenthash in MD5, need set it after upload file
$file = Set-AzStorageFileContent -ShareName $shareName -Path $filename -Source $localSrcFile -Context $ctxoauth -PassThru
$md5 = New-Object -TypeName System.Security.Cryptography.MD5CryptoServiceProvider
$filems5 = $md5.ComputeHash([System.IO.File]::ReadAllBytes($localSrcFile))
$file.ShareFileClient.SetHttpHeaders(@{"HttpHeaders" = @{"ContentHash" = $filems5}})
```

### `Start-AzStorageAccountMigration`
- A confirmation prompt will be added when converting account redundancy configuration
- Use `-Force` parameter to suppress the prompt
- Effective May 19, 2025 in Az version 14.0.0 (Az.Storage version 9.0.0)

#### Before
```powershell
Start-AzStorageAccountMigration -AccountName myaccount -ResourceGroupName myresourcegroup -TargetSku Standard_LRS -Name migration1 -AsJob
```

#### After
```powershell
Start-AzStorageAccountMigration -AccountName myaccount -ResourceGroupName myresourcegroup -TargetSku Standard_LRS -Name migration1 -Force -AsJob
```


