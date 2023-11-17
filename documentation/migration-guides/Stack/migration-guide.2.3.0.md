
This document serves as both a breaking change notification and migration guide for consumers of the azure powershell version 2.3.0. This release is specific to 2018-03-01-hybrid profile. The list of api versions supported by this profile can be found at https://aka.ms/2018profile. 

## Table of Contents

- [Common Changes](#common-changes)
- [Breaking changes to Storage cmdlets](#breaking-changes-to-storage-cmdlets)
- [Breaking changes to Compute cmdlets](#breaking-changes-to-compute-cmdlets)
- [Breaking changes to Resources cmdlets](#breaking-changes-to-resources-cmdlets)
- [Breaking changes to Network cmdlets](#breaking-changes-to-network-cmdlets)

## Common Changes

### Context autosave enabled by default
Context autosave is the storage of Azure login information that can be used between new and different PowerShell sessions. For more information on context autosave, please see (https://learn.microsoft.com/en-us/powershell/azure/context-persistence).
Previously by default, context autosave was disabled, which meant the user's Azure login information was not stored between sessions until they ran the `Enable-AzureRmContextAutosave` cmdlet to turn on context persistence. Moving forward, context autosave will be enabled by default, which means that users _with no saved context autosave settings_ will have their context stored the next time they login. Users can opt out of this functionality by using the `Disable-AzureRmContextAutosave` cmdlet.

### AzureRm.Profile dependency
All the modules in the AzureRm 2.3.0 are taking ModuleVersion dependency on the AzureRm.Profile module. This means that any future versions of AzureRm.Profile modules will also be compatible with all other modules getting shipped part of AzureRm 2.3.0 version

## Breaking changes to Storage cmdlets

### **Get-AzureRmStorageAccountKey**
- The cmdlet now returns a list of keys, rather than an object with properties for each key

```powershell
# Old
$key = (Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $accountName).Key1
	# New
$key = (Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $accountName)[0].Value
```

**New-AzureRmStorageAccountKey**
- `StorageAccountRegenerateKeyResponse` field in output of this cmdlet is renamed to `StorageAccountListKeysResults`, which is now a list of keys rather than an object with properties for each key

```powershell
# Old
$key = (New-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $accountName).StorageAccountKeys.Key1
	# New
$key = (New-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $accountName).Keys[0].Value
```

### **New/Get/Set-AzureRmStorageAccount**
- `AccountType` field in output of this cmdlet is renamed to `Sku.Name`
- Output type for PrimaryEndpoints/Secondary endpoints blob/table/queue/file changed from `Uri` to `String`

```powershell
# Old
$accountType = (Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName).AccountType
	# New
$accountType = (Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName).Sku.Name
```
	
```powershell
# Old 
$blobEndpoint = (Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName).PrimaryEndpoints.Blob.ToString()
$blobEndpoint = (Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName).PrimaryEndpoints.Blob.AbsolutePath
	# New
$blobEndpoint = (Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName).PrimaryEndpoints.Blob.ToString()
$blobEndpoint = (Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $accountName).PrimaryEndpoints.Blob
```


## Breaking changes to Compute cmdlets

### Add-AzureRmVmssExtension
	The parameter name VirtualMachineScaleSetExtensionType got changed to Type
	
### Remove-AzureRmVmss
	Needs -Force parameter to suppress confirmation

### Stop-AzureRmVmss
	Needs -Force parameter to suppress confirmation


### PSVirtualMachine
- Top level properties `DataDiskNames` and `NetworkInterfaceIDs` of nthe `PSVirtualMachine` object have been removed from the output type. These properties have always been available in the `StorageProfile` and `NetworkProfile` properties of the `PSVirtualMachine` object and will be the way they will need to be accessed going forward.
- This change affects the following cmdlets:
    - `Add-AzureRmVMDataDisk`
    - `Add-AzureRmVMNetworkInterface`
    - `Get-AzureRmVM`
    - `Remove-AzureRmVMDataDisk`
    - `Remove-AzureRmVMNetworkInterface`
    - `Set-AzureRmVMDataDisk`

```powershell
# Old
$vm.DataDiskNames
$vm.NetworkInterfaceIDs
	# New
$vm.StorageProfile.DataDisks | Select -Property Name
$vm.NetworkProfile.NetworkInterfaces | Select -Property Id
```

### **Set-AzureRmVMAccessExtension**
- Parameters "UserName" and "Password" are being replaced in favor of a PSCredential

```powershell
# Old
Set-AzureRmVMAccessExtension [other required parameters] -UserName "plain-text string" -Password "plain-text string"
	# New
Set-AzureRmVMAccessExtension [other required parameters] -Credential $PSCredential
```

## Breaking changes to Resources cmdlets

### **Find-AzureRmResource**
- This cmdlet was removed and the functionality was moved into `Get-AzureRmResource`

```powershell
# Old
Find-AzureRmResource -ResourceType "Microsoft.Web/sites" -ResourceGroupNameContains "ResourceGroup"
Find-AzureRmResource -ResourceType "Microsoft.Web/sites" -ResourceNameContains "test"
	# New
Get-AzureRmResource -ResourceType "Microsoft.Web/sites" -ResourceGroupName "*ResourceGroup*"
Get-AzureRmResource -ResourceType "Microsoft.Web/sites" -Name "*test*"
```
	
### **Find-AzureRmResourceGroup**
- This cmdlet was removed and the functionality was moved into `Get-AzureRmResourceGroup`

```powershell
# Old
Find-AzureRmResourceGroup
Find-AzureRmResourceGroup -Tag @{ "testtag" = $null }
Find-AzureRmResourceGroup -Tag @{ "testtag" = "testval" }
	# New
Get-AzureRmResourceGroup
Get-AzureRmResourceGroup -Tag @{ "testtag" = $null }
Get-AzureRmResourceGroup -Tag @{ "testtag" = "testval" }
```

### **Get-AzureRmResource**
The cmdlet output model was changed. The property name `ResourceName` was renamed to `Name`
```powershell
# Old
(Get-AzureRmResource).ResourceName
# New
(Get-AzureRmResource).Name
```

### **New-AzureRmADAppCredential**
- Parameter "Password" being replaced in favor of a SecureString
```powershell
# Old
New-AzureRmADAppCredential [other required parameters] -Password "plain-text string"
	# New
New-AzureRmADAppCredential [other required parameters] -Password $SecureStringVariable
```

### **New-AzureRmADApplication**
- Parameter "Password" being replaced in favor of a SecureString
```powershell
# Old
New-AzureRmADApplication [other required parameters] -Password "plain-text string"
	# New
New-AzureRmADApplication [other required parameters] -Password $SecureStringVariable
```
### **New-AzureRmADServicePrincipal**
- Parameter "Password" being replaced in favor of a SecureString
```powershell
# Old
New-AzureRmADServicePrincipal [other required parameters] -Password "plain-text string"
	# New
New-AzureRmADServicePrincipal [other required parameters] -Password $SecureStringVariable
```

### **New-AzureRmADSpCredential**
- Parameter "Password" being replaced in favor of a SecureString
```powershell
# Old
New-AzureRmADSpCredential [other required parameters] -Password "plain-text string"
	# New
New-AzureRmADSpCredential [other required parameters] -Password $SecureStringVariable
```
### **New-AzureRmADUser**
- Parameter "Password" being replaced in favor of a SecureString
```powershell
# Old
New-AzureRmADUser [other required parameters] -Password "plain-text string"
	# New
New-AzureRmADUser [other required parameters] -Password $SecureStringVariable
```
### **Set-AzureRmADUser**
- Parameter "Password" being replaced in favor of a SecureString
```powershell
# Old
Set-AzureRmADUser [other required parameters] -Password "plain-text string"
	# New
Set-AzureRmADUser [other required parameters] -Password $SecureStringVariable
```

## Breaking changes to Network cmdlets

###**New-AzureRmVirtualNetworkGateway**
- Description of what has changed ``:- Bool parameter:-ActiveActive`` is removed and ``SwitchParameter:-EnableActiveActiveFeature`` is added for enabling Active-Active feature on newly creating virtual network gateway.
```powershell
# Old 
# Sample of how the cmdlet was previously called
New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -Location $location -IpConfigurations $vnetIpConfig1,$vnetIpConfig2 -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku HighPerformance -ActiveActive $true
	# New
# Sample of how the cmdlet should now be called
New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -Location $location -IpConfigurations $vnetIpConfig1,$vnetIpConfig2 -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku HighPerformance -EnableActiveActiveFeature
```
	
### **Set-AzureRmVirtualNetworkGateway**
- Description of what has changed ``:- Bool parameter:-ActiveActive`` is removed and 2 ``SwitchParameters:-EnableActiveActiveFeature`` / ``DisableActiveActiveFeature`` are added for enabling and disabling Active-Active feature on virtual network gateway.

```powershell
# Old
# Sample of how the cmdlet was previously called
Set-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $gw -ActiveActive $true
Set-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $gw -ActiveActive $false  
	# New
# Sample of how the cmdlet should now be called
Set-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $gw -EnableActiveActiveFeature
Set-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $gw -DisableActiveActiveFeature
```
	

### New-AzureRmVirtualNetworkGatewayConnection
- `EnableBgp` parameter has been changed to take a `boolean` instead of a `string`

```powershell
# Old
New-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName "RG" -name "conn1" -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -SharedKey "key" -EnableBgp "true"
# New
New-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName "RG" -name "conn1" -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -SharedKey "key" -EnableBgp $true
