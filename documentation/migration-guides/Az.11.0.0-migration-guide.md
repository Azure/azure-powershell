# Migration Guide for Az 11.0.0

## Az.Aks

### `New-AzAksCluster`
The parameter  'DockerBridgeCidr' is removed from the cmdlet 'New-AzAksCluster', and there is no replacement for it.

## Az.CloudService

### `Get-AzCloudServiceNetworkInterface`
- 'ProtectionMode' and 'DdosProtectionPlanId' of type 'IDdosSettings' have been removed.
- 'InboundNatRulesPortMapping' and 'AdminState' of type 'ILoadBalancerBackendAddress' have been removed.
- 'InboundNatRule' and 'DrainPeriodInSecond' of type 'IBackendAddressPool' have been removed.
- 'FlushConnection' of type 'ISubnet' has been removed.
- 'AuxiliaryMode', 'VnetEncryptionSupported', and 'DisableTcpStateTracking' of type 'INetworkInterface' have been removed.


## Az.Compute

### `New-AzDisk`
Creation of Disk without any Image or SecurityType values provided will default to turn Trusted Launch on. 

#### Before
```powershell
$diskconfig = New-AzDiskConfig -DiskSizeGB 127 -AccountType Premium_LRS -OsType Windows -CreateOption FromImage -Location $loc;
```
#### After
```powershell
$diskconfig = New-AzDiskConfig -DiskSizeGB 127 -AccountType Premium_LRS -OsType Windows -CreateOption FromImage -Location $loc -SecurityType "Standard";
```


### `New-AzVM`
Linux image aliases CentOS, Debian, RHEL, and UbuntuLTS are removed. Instead use the aliases CentOS85Gen2, Debian11, RHELRaw8LVMGen2, Ubuntu2204.

#### Before
```powershell
New-AzVM -ResourceGroupName MyResourceGroup -Name mytestvm -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image UbuntuLTS;
```
#### After
```powershell
New-AzVM -ResourceGroupName MyResourceGroup -Name mytestvm -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Ubuntu2204;
```


### `New-AzVM`
Creation of VM without any Image or SecurityType values provided will default to turn Trusted Launch on. 

#### Before
```powershell
$result = New-AzVM -ResourceGroupName $rgname -Credential $vmCred -Name $vmName -DomainNameLabel $domainNameLabel ;
```
#### After
```powershell
$result = New-AzVM-ResourceGroupName $rgname -Credential $vmCred -Name $vmName -ImageName $imageName -DomainNameLabel $domainNameLabel -SecurityType "Standard";
```


### `New-AzVmss`
Linux image aliases CentOS, Debian, RHEL, and UbuntuLTS are removed. Instead use the aliases CentOS85Gen2, Debian11, RHELRaw8LVMGen2, Ubuntu2204.

### `New-AzVmss`
Creation of Vmss using this cmdlet will now default to OrchestrationMode: Flexible. Only when explicitly stated "-OrchestrationMode Uniform", it will create a VMSS in Uniform orchestration mode.  UgradePolicy  and SinglePlacementGroup can also be set now when OrchestrationMode is Flexible. 

#### Before
```powershell
New-AzVmss
```
#### After
```powershell
New-AzVmss
```


### `New-AzVmss`
Creation of Vmss without any Image or SecurityType values provided will default to turn Trusted Launch on. 

#### Before
```powershell
$result = New-AzVmss -ResourceGroupName $rgname -Credential $vmCred -VMScaleSetName $vmssName1 -DomainNameLabel $domainNameLabel ;
```
#### After
```powershell
$result = New-AzVmss -ResourceGroupName $rgname -Credential $vmCred -VMScaleSetName $vmssName1 -ImageName $imageName -DomainNameLabel $domainNameLabel -SecurityType "Standard";
```


## Az.ContainerInstance

### `Get-AzContainerGroup`
Fixed typos in these output properties: 'PreviouState' 'PreviouStateDetailStatus' 'PreviouStateExitCode' 'PreviouStateFinishTime' 'PreviouStateStartTime'. 
The impacted cmdlets are: 'Get-AzContainerGroup', 'Remove-AzContainerGroup', 'Restart-AzContainerGroup', 'Start-AzContainerGroup', 'Stop-AzContainerGroup', 'Update-AzContainerGroup', 'New-AzContainerInstanceObject', 'New-AzContainerInstanceInitDefinitionObject'

#### Before
```powershell
$aci = Get-AzContainerGroup -ResourceGroupName 'rg name' -Name 'aci name'
$previousState = $aci.Property.Container.PreviouState

```
#### After
```powershell
$aci = Get-AzContainerGroup -ResourceGroupName 'rg name' -Name 'aci name'
$previousState = $aci.Property.Container.PreviousState

```


## Az.DesktopVirtualization

### `New-AzWvdScalingPlan`
The allowed value of this parameter changed from 'BYODesktop, Personal, Pooled' to 'Pooled'

## Az.Functions

### `Get-AzFunctionApp`
This cmdlet will redact the application settings of the returned function apps and only the keys will be shown while previously it returned both keys and values.

#### Before
```powershell
Get-AzFunctionApp  -Name <AppName> -ResourceGroupName <ResourceGroupName>
```output
Name                                                                        Value
----                                                                             -----
FUNCTIONS_EXTENSION_VERSION            ~4
WEBSITE_CONTENTAZUREFILECONNE… <connection string>
AzureWebJobsStorage                                       <connection string>
APPLICATIONINSIGHTS_CONNECTIO…   <connection string>
APPINSIGHTS_INSTRUMENTATIONKEY     <guid>
FUNCTIONS_WORKER_RUNTIME                 powershell
WEBSITE_CONTENTSHARE                            <share name>
```
```
#### After
```powershell
Get-AzFunctionApp  -Name <AppName> -ResourceGroupName <ResourceGroupName>
```output
WARNING: App settings have been redacted. Use the Get-AzFunctionAppSetting cmdlet to view them.
Name                                                                        Value
----                                                                             -----
FUNCTIONS_EXTENSION_VERSION            
WEBSITE_CONTENTAZUREFILECONNE… 
AzureWebJobsStorage                                       
APPLICATIONINSIGHTS_CONNECTIO…   
APPINSIGHTS_INSTRUMENTATIONKEY     
FUNCTIONS_WORKER_RUNTIME                 
WEBSITE_CONTENTSHARE                             
```
```


### `Update-AzFunctionAppSetting`
This cmdlet will only return the updated application settings while previously all of them returned.

#### Before
```powershell
Update-AzFunctionAppSetting  -Name <AppName> -ResourceGroupName <ResourceGroupName>  -AppSetting @{"foo3"="bar3"}
```output
Name                                                                        Value
----                                                                             -----
FUNCTIONS_EXTENSION_VERSION            ~4
WEBSITE_CONTENTAZUREFILECONNE… <connection string>
foo3                                                                           bar3
AzureWebJobsStorage                                       <connection string>
APPLICATIONINSIGHTS_CONNECTIO…   <connection string>
APPINSIGHTS_INSTRUMENTATIONKEY     <guid>
FUNCTIONS_WORKER_RUNTIME                 powershell
WEBSITE_CONTENTSHARE                            <share name>
```
```
#### After
```powershell
Update-AzFunctionAppSetting  -Name <AppName> -ResourceGroupName <ResourceGroupName>  -AppSetting @{"foo3"="bar3"}
```output
Name                      Value
----                           -----
foo3                         bar3
```
```


## Az.Network

### `New-AzApplicationGatewayFirewallCustomRuleGroupByVariable`
Geo is no longwe a valid input for parameter `VariableName` in `NewAzureApplicationGatewayFirewallCustomRuleGroupByVariable`

## Az.Resources

### `Get-AzPolicyAssignment`
Output type no longer contains a property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
Get-AzPolicyAssignment
```
#### After
```powershell
Get-AzPolicyAssignment -BackwardCompatible
```


### `Get-AzPolicyDefinition`
Output type no longer contains a property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
Get-AzPolicyDefinition
```
#### After
```powershell
Get-AzPolicyDefinition -BackwardCompatible
```


### `Get-AzPolicyExemption`
Output type no longer contains a property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
Get-AzPolicyExemption
```
#### After
```powershell
Get-AzPolicyExemption -BackwardCompatible
```


### `Get-AzPolicySetDefinition`
Output type no longer contains a property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
Get-AzPolicySetDefinition
```
#### After
```powershell
Get-AzPolicySetDefinition -BackwardCompatible
```


### `New-AzPolicyAssignment`
Output type no longer contains a property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
New-AzPolicyAssignment
```
#### After
```powershell
New-AzPolicyAssignment -BackwardCompatible
```


### `New-AzPolicyDefinition`
Output type no longer contains a property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
New-AzPolicyDefinition
```
#### After
```powershell
New-AzPolicyDefinition -BackwardCompatible
```


### `New-AzPolicyExemption`
Output type no longer contains a property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
New-AzPolicyExemption
```
#### After
```powershell
New-AzPolicyExemption -BackwardCompatible
```


### `New-AzPolicySetDefinition`
Output type no longer contains a property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
New-AzPolicySetDefinition
```
#### After
```powershell
New-AzPolicySetDefinition -BackwardCompatible
```


### `Remove-AzPolicyAssignment`
A boolean value is no longer returned. Previous behavior of returning True if the object is successfully deleted (or is nonexistent) can be restored by including the -PassThru or -BackwardCompatible switch.

#### Before
```powershell
Remove-AzPolicyAssignment
```
#### After
```powershell
Remove-AzPolicyAssignment -BackwardCompatible
```


### `Remove-AzPolicyDefinition`
A boolean value is no longer returned. Previous behavior of returning True if the object is successfully deleted (or is nonexistent) can be restored by including the -PassThru or -BackwardCompatible switch.

#### Before
```powershell
Remove-AzPolicyDefinition
```
#### After
```powershell
Remove-AzPolicyDefinition -BackwardCompatible
```


### `Remove-AzPolicyExemption`
A boolean value is no longer returned. Previous behavior of returning True if the object is successfully deleted (or is nonexistent) can be restored by including the -PassThru or -BackwardCompatible switch.

#### Before
```powershell
Remove-AzPolicyExemption
```
#### After
```powershell
Remove-AzPolicyExemption -BackwardCompatible
```


### `Remove-AzPolicySetDefinition`
A boolean value is no longer returned. Previous behavior of returning True if the object is successfully deleted (or is nonexistent) can be restored by including the -PassThru or -BackwardCompatible switch.

#### Before
```powershell
Remove-AzPolicySetDefinition
```
#### After
```powershell
Remove-AzPolicySetDefinition -BackwardCompatible
```


### `Set-AzPolicyAssignment`
Cmdlet is replaced by a similar Update-AzPolicyAssignment cmdlet aliased to Set-AzPolicyAssignment. Output type of Set-AzPolicyAssignment (Update-AzPolicyAssignment) no longer includes the property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
Set-AzPolicyAssignment
```
#### After
```powershell
Update-AzPolicyAssignment -BackwardCompatible
```


### `Set-AzPolicyDefinition`
Cmdlet is replaced by a similar Update-AzPolicyDefinition cmdlet aliased to Set-AzPolicyDefinition. Output type of Set-AzPolicyDefinition (Update-AzPolicyDefinition) no longer includes the property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
Set-AzPolicyDefinition
```
#### After
```powershell
Update-AzPolicyDefinition -BackwardCompatible
```


### `Set-AzPolicyExemption`
Cmdlet is replaced by a similar Update-AzPolicyExemption cmdlet aliased to Set-AzPolicyExemption. Output type of Set-AzPolicyExemption (Update-AzPolicyExemption) no longer includes the property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
Set-AzPolicyExemption
```
#### After
```powershell
Update-AzPolicyExemption -BackwardCompatible
```


### `Set-AzPolicySetDefinition`
Cmdlet is replaced by a similar Update-AzPolicySetDefinition cmdlet aliased to Set-AzPolicySetDefinition. Output type of Set-AzPolicySetDefinition (Update-AzPolicySetDefinition) no longer includes the property bag object (Properties property). New top-level properties are provided for all properties previously returned in the property bag object If the -BackwardCompatible switch is provided, the property bag object will be added back to the output.

#### Before
```powershell
Set-AzPolicySetDefinition
```
#### After
```powershell
Update-AzPolicySetDefinition -BackwardCompatible
```


## AZ.Storage

### `Get-AzStorageQueueStoredAcessPolicy`
Permissions in the ouput access policy is changed to a string like "raup"

### `New-AzStorageAccountSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageBlobSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageContainerSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageFileSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageQueueSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageShareSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageTableSasToken`
The leading question mark '?' of the created SAS token is removed

### `Set-AzStorageQueueStoredAccessPolicy`
Permissions in the ouput access policy is changed to a string like "raup"

