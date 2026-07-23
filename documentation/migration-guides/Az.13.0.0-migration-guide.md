# Migration Guide for Az 13.0.0

## Az.Accounts

### `Resolve-AzError`

- Cmdlet breaking-change will happen to all parameter sets
  - The alias 'Resolve-Error' will be removed. Please use 'Resolve-AzError' instead.
  - This change is expected to take effect from Az.Accounts version: 4.0.0 and Az version: 13.0.0


#### Before
```powershell
Resolve-Error
```
#### After
```powershell
Resolve-AzError
```


## Az.App

### `New-AzContainerApp`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
New-AzContainerApp -Name "azps-containerapp" -ResourceGroupName "azps_test_group_app" -Location "eastus" -Configuration $configuration -TemplateContainer $temp -TemplateInitContainer $temp2 -TemplateServiceBind $serviceBind -EnvironmentId $EnvId -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity @{"/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai"=@{};}
```
#### After
```powershell
New-AzContainerApp -Name "azps-containerapp" -ResourceGroupName "azps_test_group_app" -Location "eastus" -Configuration $configuration -TemplateContainer $temp -TemplateInitContainer $temp2 -TemplateServiceBind $serviceBind -EnvironmentId $EnvId -EnableSystemAssignedIdentity $true -UserAssignedIdentity @("/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai")
```


### `New-AzContainerAppJob`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
New-AzContainerAppJob -Name azps-app-job -ResourceGroupName azps_test_group_app -Location eastus -ConfigurationReplicaRetryLimit 10 -ConfigurationReplicaTimeout 10 -ConfigurationTriggerType Manual -EnvironmentId $EnvId -ManualTriggerConfigParallelism 4 -ManualTriggerConfigReplicaCompletionCount 1 -TemplateContainer $temp -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity @{"/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai"=@{};}
```
#### After
```powershell
New-AzContainerAppJob -Name azps-app-job -ResourceGroupName azps_test_group_app -Location eastus -ConfigurationReplicaRetryLimit 10 -ConfigurationReplicaTimeout 10 -ConfigurationTriggerType Manual -EnvironmentId $EnvId -ManualTriggerConfigParallelism 4 -ManualTriggerConfigReplicaCompletionCount 1 -TemplateContainer $temp -EnableSystemAssignedIdentity $true -UserAssignedIdentity @("/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai")
```


### `Update-AzContainerApp`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
Update-AzContainerApp -ContainerAppName azps-containerapp -ResourceGroupName azps_test_group_app -Configuration $configuration -Tag @{"123"="abc"} -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity @{"/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai"=@{};}
```
#### After
```powershell
Update-AzContainerApp -ContainerAppName azps-containerapp -ResourceGroupName azps_test_group_app -Configuration $configuration -Tag @{"123"="abc"} -EnableSystemAssignedIdentity $true -UserAssignedIdentity @("/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai")
```


### `Update-AzContainerAppJob`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
Update-AzContainerAppJob -Name azps-app-job -ResourceGroupName azps_test_group_app -ConfigurationReplicaRetryLimit 10 -ConfigurationReplicaTimeout 10 -ConfigurationTriggerType Manual -EnvironmentId $EnvId -ManualTriggerConfigParallelism 4 -ManualTriggerConfigReplicaCompletionCount 1 -TemplateContainer $temp -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity @{"/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai"=@{};}
```
#### After
```powershell
Update-AzContainerAppJob -Name azps-app-job -ResourceGroupName azps_test_group_app -ConfigurationReplicaRetryLimit 10 -ConfigurationReplicaTimeout 10 -ConfigurationTriggerType Manual -EnvironmentId $EnvId -ManualTriggerConfigParallelism 4 -ManualTriggerConfigReplicaCompletionCount 1 -TemplateContainer $temp -EnableSystemAssignedIdentity $true -UserAssignedIdentity @("/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai")
```


## Az.Compute

### `New-AzVM`
- Parameter breaking-change will happen to parameter set SimpleParameterSet and DiskFileParameterSet
  - Default value of `-PublicIpSku` will be Standard if customer doesn't specify this parameter.

#### Before
```powershell
Default value of `-PublicIpSku` was Basic if it is not specified
```
#### After
```powershell
Default value of `-PublicIpSku` will be Standard if it is not specified
```


## Az.DevCenter

### `Get-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'DevBox' to the new type :'DevBox'
  - The following properties in the output type are being deprecated : 'Detail' 'ProvisioningState' 'HardwareProfileSkuName'
  - The following properties are being added to the output type : 'Detail' 'ProvisioningState' 'HardwareProfileSkuName'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'


#### Before

- Detail is type CloudErrorBody. CloudErrorBody uses a `List<ICloudErrorBody>` for the Detail property.

- Example output for Details:
```powershell
Code       : ResourceNotFound
Message    : The specified resource does not exist.
Target     : resourceName
Detail     : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}, @{Code=ResourceGroupNotFound; Message=The specified resource group does not exist.; Target=resourceGroupName}}
```
- ProvisioningState is type System.String
- HardwareProfileSKuName is type System.String
#### After
- Detail is type AzureCoreFoundationsError. Innererror property is added for additional error information. AzureCoreFoundationsError uses an array of IAzureCoreFoundationsError for the Detail property.

- Example output for Detail: 
```powershell
Code       : InvalidRequest
Message    : The request is invalid.
Target     : request
Detail     : {@{Code=MissingParameter; Message=A required parameter is missing.; Target=parameterName}, @{Code=InvalidParameter; Message=The parameter value is invalid.; Target=parameterValue}}
Innererror : @{Code=InnerErrorCode; Message=More specific information about the error.}
```

- ProvisioningState is type DevBoxProvisioningState. Possible values will be Creating, Deleting, Failed, InGracePeriod, NotProvisioned, ProvisionedWithWarning, Provisioning, Starting, Stopping, Succeeded, Updating.
- HardwareProfileSKuName is type SkuName. Possible values will be general_a_16c64gb1024ssd_v2, general_a_16c64gb2048ssd_v2, general_a_16c64gb256ssd_v2, general_a_16c64gb512ssd_v2, general_a_32c128gb1024ssd_v2, general_a_32c128gb2048ssd_v2, general_a_32c128gb512ssd_v2, general_a_8c32gb1024ssd_v2, general_a_8c32gb2048ssd_v2, general_a_8c32gb256ssd_v2, general_a_8c32gb512ssd_v2, general_i_16c64gb1024ssd_v2, general_i_16c64gb2048ssd_v2, general_i_16c64gb256ssd_v2, general_i_16c64gb512ssd_v2, general_i_32c128gb1024ssd_v2, general_i_32c128gb2048ssd_v2, general_i_32c128gb512ssd_v2, general_i_8c32gb1024ssd_v2, general_i_8c32gb2048ssd_v2, general_i_8c32gb256ssd_v2, general_i_8c32gb512ssd_v2


### `Get-AzDevCenterUserDevBoxOperation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'DevBoxOperation' to the new type :'DevBoxOperation'
  - The following properties in the output type are being deprecated : 'Detail' 'Status'
  - The following properties are being added to the output type : 'Detail' 'Status'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'


#### Before
- Detail is type CloudErrorBody. CloudErrorBody uses a `List<ICloudErrorBody>` for the Detail property.

- Example output for Details:
```powershell
Code       : ResourceNotFound
Message    : The specified resource does not exist.
Target     : resourceName
Detail     : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}, @{Code=ResourceGroupNotFound; Message=The specified resource group does not exist.; Target=resourceGroupName}}
```

- Status is type DevBoxOperationStatus
#### After
- Detail is type AzureCoreFoundationsError. Innererror property is added for additional error information. AzureCoreFoundationsError uses an array of IAzureCoreFoundationsError for the Detail property.

- Example output for Detail: 
```powershell
Code       : InvalidRequest
Message    : The request is invalid.
Target     : request
Detail     : {@{Code=MissingParameter; Message=A required parameter is missing.; Target=parameterName}, @{Code=InvalidParameter; Message=The parameter value is invalid.; Target=parameterValue}}
Innererror : @{Code=InnerErrorCode; Message=More specific information about the error.}
```

- Status is type OperationState. The possible values are the same (Canceled, Failed, NotStarted, Running, Succeeded). The change is a rename from DevBoxOperationStatus to OperationState.


### `Get-AzDevCenterUserEnvironment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Environment' to the new type :'Environment'
  - The following properties in the output type are being deprecated : 'Detail' 'ProvisioningState'
  - The following properties are being added to the output type : 'Detail' 'ProvisioningState'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'


#### Before
- Detail is type CloudErrorBody. CloudErrorBody uses a `List<ICloudErrorBody>` for the Detail property.

- Example output for Details:
```powershell
Code       : ResourceNotFound
Message    : The specified resource does not exist.
Target     : resourceName
Detail     : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}, @{Code=ResourceGroupNotFound; Message=The specified resource group does not exist.; Target=resourceGroupName}}
```

- ProvisioningState is type System.String
#### After
- Detail is type AzureCoreFoundationsError. Innererror property is added for additional error information. AzureCoreFoundationsError uses an array of IAzureCoreFoundationsError for the Detail property.

- Example output for Detail: 
```powershell
Code       : InvalidRequest
Message    : The request is invalid.
Target     : request
Detail     : {@{Code=MissingParameter; Message=A required parameter is missing.; Target=parameterName}, @{Code=InvalidParameter; Message=The parameter value is invalid.; Target=parameterValue}}
Innererror : @{Code=InnerErrorCode; Message=More specific information about the error.}
```

- ProvisioningState is type EnvironmentProvisioningState. Possible values will be Accepted, Canceled, Creating, Deleting, Failed, MovingResources, Preparing, Running, StorageProvisioningFailed, Succeeded, Syncing, TransientFailure, Updating.


### `Get-AzDevCenterUserEnvironmentAction`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'EnvironmentAction' to the new type :'EnvironmentAction'
  - The following properties in the output type are being deprecated : 'NextScheduledTime'
  - The following properties are being added to the output type : 'NextScheduledTime'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
NextScheduledTime is type System.DateTime
```
#### After
```powershell
NextScheduledTime is type nullable System.DateTime
```


### `Get-AzDevCenterUserEnvironmentLog`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'boolean' to the new type :'string'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-OutFile`
    - The parameter : 'OutFile' is changing.
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-PassThru`
    - The parameter : 'PassThru' is changing.
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
Output type is Boolean
```
#### After
```powershell
Output type is string representation of logs
Outfile parameter is removed
Passthru parameter is removed
```


### `Get-AzDevCenterUserEnvironmentOperation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'EnvironmentOperation' to the new type :'EnvironmentOperation'
  - The following properties in the output type are being deprecated : 'Detail' 'EnvironmentParameter' 'Status'
  - The following properties are being added to the output type : 'Detail' 'EnvironmentParameter' 'Status'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'


#### Before
- Detail is type CloudErrorBody. CloudErrorBody uses a `List<ICloudErrorBody>` for the Detail property.

- Example output for Details:
```powershell
Code       : ResourceNotFound
Message    : The specified resource does not exist.
Target     : resourceName
Detail     : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}, @{Code=ResourceGroupNotFound; Message=The specified resource group does not exist.; Target=resourceGroupName}}
```

-Status is type EnvironmentOperationStatus
-EnvironmentParameter is type IAny
#### After
- Detail is type AzureCoreFoundationsError. Innererror property is added for additional error information. AzureCoreFoundationsError uses an array of IAzureCoreFoundationsError for the Detail property.

- Example output for Detail: 
```powershell
Code       : InvalidRequest
Message    : The request is invalid.
Target     : request
Detail     : {@{Code=MissingParameter; Message=A required parameter is missing.; Target=parameterName}, @{Code=InvalidParameter; Message=The parameter value is invalid.; Target=parameterValue}}
Innererror : @{Code=InnerErrorCode; Message=More specific information about the error.}
```

- Status is type OperationState. The possible values are the same (Canceled, Failed, NotStarted, Running, Succeeded). The change is a rename from EnvironmentOperationStatus to OperationState.
-EnvironmentParameter is type EnvironmentOperationEnvironmentParameters. This is serializable to JSON and to function as an associative array (dictionary) of objects




### `Get-AzDevCenterUserPool`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Pool' to the new type :'Pool'
  - The following properties in the output type are being deprecated : 'HardwareProfileSkuName'
  - The following properties are being added to the output type : 'HardwareProfileSkuName'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
HardwareProfileSKuName is type System.String
```
#### After
```powershell
HardwareProfileSKuName is type SkuName. Possible values will be general_a_16c64gb1024ssd_v2, general_a_16c64gb2048ssd_v2, general_a_16c64gb256ssd_v2, general_a_16c64gb512ssd_v2, general_a_32c128gb1024ssd_v2, general_a_32c128gb2048ssd_v2, general_a_32c128gb512ssd_v2, general_a_8c32gb1024ssd_v2, general_a_8c32gb2048ssd_v2, general_a_8c32gb256ssd_v2, general_a_8c32gb512ssd_v2, general_i_16c64gb1024ssd_v2, general_i_16c64gb2048ssd_v2, general_i_16c64gb256ssd_v2, general_i_16c64gb512ssd_v2, general_i_32c128gb1024ssd_v2, general_i_32c128gb2048ssd_v2, general_i_32c128gb512ssd_v2, general_i_8c32gb1024ssd_v2, general_i_8c32gb2048ssd_v2, general_i_8c32gb256ssd_v2, general_i_8c32gb512ssd_v2
```


### `Invoke-AzDevCenterUserDelayDevBoxAction`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'DevBoxActionDelayResult' to the new type :'DevBoxActionDelayResult'
  - The following properties in the output type are being deprecated : 'Detail'
  - The following properties are being added to the output type : 'Detail'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'


#### Before
- Detail is type CloudErrorBody. CloudErrorBody uses a `List<ICloudErrorBody>` for the Detail property.

- Example output for Details:
```powershell
Code       : ResourceNotFound
Message    : The specified resource does not exist.
Target     : resourceName
Detail     : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}, @{Code=ResourceGroupNotFound; Message=The specified resource group does not exist.; Target=resourceGroupName}}
```
#### After
- Detail is type AzureCoreFoundationsError. Innererror property is added for additional error information. AzureCoreFoundationsError uses an array of IAzureCoreFoundationsError for the Detail property.

- Example output for Detail: 
```powershell
Code       : InvalidRequest
Message    : The request is invalid.
Target     : request
Detail     : {@{Code=MissingParameter; Message=A required parameter is missing.; Target=parameterName}, @{Code=InvalidParameter; Message=The parameter value is invalid.; Target=parameterValue}}
Innererror : @{Code=InnerErrorCode; Message=More specific information about the error.}
```



### `Invoke-AzDevCenterUserDelayEnvironmentAction`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'EnvironmentAction' to the new type :'EnvironmentAction'
  - The following properties in the output type are being deprecated : 'NextScheduledTime'
  - The following properties are being added to the output type : 'NextScheduledTime'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
NextScheduledTime is type System.DateTime
```
#### After
```powershell
NextScheduledTime is type nullable System.DateTime
```


### `New-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'DevBox' to the new type :'DevBox'
  - The following properties in the output type are being deprecated : 'Detail' 'ProvisioningState' 'HardwareProfileSkuName'
  - The following properties are being added to the output type : 'Detail' 'ProvisioningState' 'HardwareProfileSkuName'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'


#### Before

- Detail is type CloudErrorBody. CloudErrorBody uses a `List<ICloudErrorBody>` for the Detail property.

- Example output for Details:
```powershell
Code       : ResourceNotFound
Message    : The specified resource does not exist.
Target     : resourceName
Detail     : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}, @{Code=ResourceGroupNotFound; Message=The specified resource group does not exist.; Target=resourceGroupName}}
```

- ProvisioningState is type System.String
- HardwareProfileSKuName is type System.String
#### After
- Detail is type AzureCoreFoundationsError. Innererror property is added for additional error information. AzureCoreFoundationsError uses an array of IAzureCoreFoundationsError for the Detail property.

- Example output for Detail: 
```powershell
Code       : InvalidRequest
Message    : The request is invalid.
Target     : request
Detail     : {@{Code=MissingParameter; Message=A required parameter is missing.; Target=parameterName}, @{Code=InvalidParameter; Message=The parameter value is invalid.; Target=parameterValue}}
Innererror : @{Code=InnerErrorCode; Message=More specific information about the error.}
```

- ProvisioningState is type DevBoxProvisioningState. Possible values will be Creating, Deleting, Failed, InGracePeriod, NotProvisioned, ProvisionedWithWarning, Provisioning, Starting, Stopping, Succeeded, Updating.
- HardwareProfileSKuName is type SkuName. Possible values will be general_a_16c64gb1024ssd_v2, general_a_16c64gb2048ssd_v2, general_a_16c64gb256ssd_v2, general_a_16c64gb512ssd_v2, general_a_32c128gb1024ssd_v2, general_a_32c128gb2048ssd_v2, general_a_32c128gb512ssd_v2, general_a_8c32gb1024ssd_v2, general_a_8c32gb2048ssd_v2, general_a_8c32gb256ssd_v2, general_a_8c32gb512ssd_v2, general_i_16c64gb1024ssd_v2, general_i_16c64gb2048ssd_v2, general_i_16c64gb256ssd_v2, general_i_16c64gb512ssd_v2, general_i_32c128gb1024ssd_v2, general_i_32c128gb2048ssd_v2, general_i_32c128gb512ssd_v2, general_i_8c32gb1024ssd_v2, general_i_8c32gb2048ssd_v2, general_i_8c32gb256ssd_v2, general_i_8c32gb512ssd_v2


### `Update-AzDevCenterUserEnvironment`
- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Environment' to the new type :'Environment'
  - The following properties in the output type are being deprecated : 'Detail' 'ProvisioningState'
  - The following properties are being added to the output type : 'Detail' 'ProvisioningState'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

#### Before
- Detail is type CloudErrorBody. CloudErrorBody uses a `List<ICloudErrorBody>` for the Detail property.

- Example output for Details:
```powershell
Code       : ResourceNotFound
Message    : The specified resource does not exist.
Target     : resourceName
Detail     : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}, @{Code=ResourceGroupNotFound; Message=The specified resource group does not exist.; Target=resourceGroupName}}
```

- ProvisioningState is type System.String
#### After
- Detail is type AzureCoreFoundationsError. Innererror property is added for additional error information. AzureCoreFoundationsError uses an array of IAzureCoreFoundationsError for the Detail property.

- Example output for Detail: 
```powershell
Code       : InvalidRequest
Message    : The request is invalid.
Target     : request
Detail     : {@{Code=MissingParameter; Message=A required parameter is missing.; Target=parameterName}, @{Code=InvalidParameter; Message=The parameter value is invalid.; Target=parameterValue}}
Innererror : @{Code=InnerErrorCode; Message=More specific information about the error.}
```

- ProvisioningState is type EnvironmentProvisioningState. Possible values will be Accepted, Canceled, Creating, Deleting, Failed, MovingResources, Preparing, Running, StorageProvisioningFailed, Succeeded, Syncing, TransientFailure, Updating.


### `Deploy-AzDevCenterUserEnvironment`
- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'System.Boolean' to the new type :'Environment'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Output type is Boolean
```
#### After
- Output type is Environment

- Example output:
```powershell
Name                     : myEnvironment
EnvironmentType          : dev
User                     : 00000000-0000-0000-0000-000000000000
ProvisioningState        : Succeeded
CatalogName              : devCatalog
EnvironmentDefinitionName: FunctionApp
```


### `Get-AzDevCenterUserCatalog`
- Cmdlet breaking-change will happen to all parameter sets
  - The output type is  'System.String' is removed. The only output type will be Catalog. 
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Output type is Boolean
```
#### After
- Output type is Catalog

- Example output:
```powershell
Name: myCatalogName
```


### `New-AzDevCenterUserEnvironment`
- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'System.Boolean' to the new type :'Environment'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Output type is Boolean
```
#### After
- Output type is Environment

- Example output:
```powershell
Name                     : myEnvironment
EnvironmentType          : dev
User                     : 00000000-0000-0000-0000-000000000000
ProvisioningState        : Succeeded
CatalogName              : devCatalog
EnvironmentDefinitionName: FunctionApp
```


### `Remove-AzDevCenterUserDevBox`
- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'System.Boolean' to the new type :'OperationStatus'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Output type is Boolean
```
#### After
- Output type is OperationStatus
- Example output: 
```powershell
Code             : ResourceNotFound
Detail           : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}}
EndTime          : 10/1/2023 12:34:56 PM
Error            : @{Code=ResourceNotFound; Message=The specified resource does not exist.; Target=resourceName; Detail=System.Object[]; Innererror=}
Id               : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
Innererror       : @{Code=InnerErrorCode; Message=More specific information about the error.}
Message          : The specified resource does not exist.
Name             : operationId
OperationLocation: /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
PercentComplete  : 100
Property         : @{CustomProperty=CustomValue}
ResourceId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/resources/resourceId
StartTime        : 10/1/2023 12:00:00 PM
Status           : Succeeded
Target           : resourceName
```


### `Remove-AzDevCenterUserEnvironment`
- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'System.Boolean' to the new type :'OperationStatus'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Output type is Boolean
```
#### After
- Output type is OperationStatus
- Example output: 
```powershell
Code             : ResourceNotFound
Detail           : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}}
EndTime          : 10/1/2023 12:34:56 PM
Error            : @{Code=ResourceNotFound; Message=The specified resource does not exist.; Target=resourceName; Detail=System.Object[]; Innererror=}
Id               : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
Innererror       : @{Code=InnerErrorCode; Message=More specific information about the error.}
Message          : The specified resource does not exist.
Name             : operationId
OperationLocation: /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
PercentComplete  : 100
Property         : @{CustomProperty=CustomValue}
ResourceId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/resources/resourceId
StartTime        : 10/1/2023 12:00:00 PM
Status           : Succeeded
Target           : resourceName
```


### `Repair-AzDevCenterUserDevBox`
- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'System.Boolean' to the new type :'OperationStatus'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Output type is Boolean
```
#### After
- Output type is OperationStatus
- Example output: 
```powershell
Code             : ResourceNotFound
Detail           : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}}
EndTime          : 10/1/2023 12:34:56 PM
Error            : @{Code=ResourceNotFound; Message=The specified resource does not exist.; Target=resourceName; Detail=System.Object[]; Innererror=}
Id               : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
Innererror       : @{Code=InnerErrorCode; Message=More specific information about the error.}
Message          : The specified resource does not exist.
Name             : operationId
OperationLocation: /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
PercentComplete  : 100
Property         : @{CustomProperty=CustomValue}
ResourceId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/resources/resourceId
StartTime        : 10/1/2023 12:00:00 PM
Status           : Succeeded
Target           : resourceName
```


### `Restart-AzDevCenterUserDevBox`
- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'System.Boolean' to the new type :'OperationStatus'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Output type is Boolean
```
#### After
- Output type is OperationStatus
- Example output: 
```powershell
Code             : ResourceNotFound
Detail           : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}}
EndTime          : 10/1/2023 12:34:56 PM
Error            : @{Code=ResourceNotFound; Message=The specified resource does not exist.; Target=resourceName; Detail=System.Object[]; Innererror=}
Id               : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
Innererror       : @{Code=InnerErrorCode; Message=More specific information about the error.}
Message          : The specified resource does not exist.
Name             : operationId
OperationLocation: /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
PercentComplete  : 100
Property         : @{CustomProperty=CustomValue}
ResourceId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/resources/resourceId
StartTime        : 10/1/2023 12:00:00 PM
Status           : Succeeded
Target           : resourceName
```


### `Start-AzDevCenterUserDevBox`
- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'System.Boolean' to the new type :'OperationStatus'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Output type is Boolean
```
#### After
- Output type is OperationStatus
- Example output: 
```powershell
Code             : ResourceNotFound
Detail           : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}}
EndTime          : 10/1/2023 12:34:56 PM
Error            : @{Code=ResourceNotFound; Message=The specified resource does not exist.; Target=resourceName; Detail=System.Object[]; Innererror=}
Id               : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
Innererror       : @{Code=InnerErrorCode; Message=More specific information about the error.}
Message          : The specified resource does not exist.
Name             : operationId
OperationLocation: /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
PercentComplete  : 100
Property         : @{CustomProperty=CustomValue}
ResourceId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/resources/resourceId
StartTime        : 10/1/2023 12:00:00 PM
Status           : Succeeded
Target           : resourceName
```


### `Stop-AzDevCenterUserDevBox`
- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'System.Boolean' to the new type :'OperationStatus'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Output type is Boolean
```
#### After
- Output type is OperationStatus
- Example output: 
```powershell
Code             : ResourceNotFound
Detail           : {@{Code=InvalidResourceName; Message=The resource name is invalid.; Target=resourceName}}
EndTime          : 10/1/2023 12:34:56 PM
Error            : @{Code=ResourceNotFound; Message=The specified resource does not exist.; Target=resourceName; Detail=System.Object[]; Innererror=}
Id               : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
Innererror       : @{Code=InnerErrorCode; Message=More specific information about the error.}
Message          : The specified resource does not exist.
Name             : operationId
OperationLocation: /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/operationStatuses/operationId
PercentComplete  : 100
Property         : @{CustomProperty=CustomValue}
ResourceId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/exampleGroup/providers/Microsoft.DevCenter/resources/resourceId
StartTime        : 10/1/2023 12:00:00 PM
Status           : Succeeded
Target           : resourceName
```


## Az.ElasticSan

### `New-AzElasticSanVolumeGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'


### `Update-AzElasticSanVolumeGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'


## Az.Monitor

### `New-AzDataCollectionEndpoint`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
New-AzDataCollectionEndpoint -Name myCollectionEndpoint -ResourceGroupName AMCS-TEST -Location eastus -NetworkAclsPublicNetworkAccess Enabled -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity @{"/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai"=@{};}
```
#### After
```powershell
New-AzDataCollectionEndpoint -Name myCollectionEndpoint -ResourceGroupName AMCS-TEST -Location eastus -NetworkAclsPublicNetworkAccess Enabled -EnableSystemAssignedIdentity $true -UserAssignedIdentity @("/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai")
```


### `New-AzDataCollectionRule`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
New-AzDataCollectionRule -Name myCollectionRule1 -ResourceGroupName AMCS-TEST -Location eastus -DataFlow $dataflow -DataSourcePerformanceCounter $performanceCounter1,$performanceCounter2 -DataSourceWindowsEventLog $windowsEvent -DestinationAzureMonitorMetricName "azureMonitorMetrics-default" -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity @{"/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai"=@{};}
```
#### After
```powershell
New-AzDataCollectionRule -Name myCollectionRule1 -ResourceGroupName AMCS-TEST -Location eastus -DataFlow $dataflow -DataSourcePerformanceCounter $performanceCounter1,$performanceCounter2 -DataSourceWindowsEventLog $windowsEvent -DestinationAzureMonitorMetricName "azureMonitorMetrics-default" -EnableSystemAssignedIdentity $true -UserAssignedIdentity @("/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai")
```


### `Update-AzDataCollectionEndpoint`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
Update-AzDataCollectionEndpoint -Name myCollectionEndpoint -ResourceGroupName AMCS-TEST -Tag @{"123"="abc"} -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity @{"/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai"=@{};}
```
#### After
```powershell
Update-AzDataCollectionEndpoint -Name myCollectionEndpoint -ResourceGroupName AMCS-TEST -Tag @{"123"="abc"} -EnableSystemAssignedIdentity $true -UserAssignedIdentity @("/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai")
```


### `Update-AzDataCollectionRule`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'


#### Before
```powershell
Update-AzDataCollectionRule -Name myCollectionRule1 -ResourceGroupName Monitor-ActionGroup -DataSourceSyslog $syslog -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity @{"/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai"=@{};}
```
#### After
```powershell
Update-AzDataCollectionRule -Name myCollectionRule1 -ResourceGroupName Monitor-ActionGroup -DataSourceSyslog $syslog -EnableSystemAssignedIdentity $true -UserAssignedIdentity @("/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/myGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai")
```


## Az.NetAppFiles

### `Get-AzNetAppFilesBackup`

- Parameter breaking-change will happen to all parameter sets
  - `-AccountBackupName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-PoolName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeObject`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12


#### Before
```powershell
Get-AzNetAppFilesBackup -ResourceGroupName "MyRG" -AccountName "MyAccount" -PoolName "MyPool" -VolumeName "MyVolume" -Name "MyBackup"
```
#### After
```powershell
Get-AzNetAppFilesBackup -ResourceGroupName "MyRG" -AccountName "MyAccount" -BackupVaultName "MyVault"  -Filter $volumeResourceId
```


### `New-AzNetAppFilesBackup`

- Parameter breaking-change will happen to all parameter sets
  - `-Location`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-PoolName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeObject`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12


#### Before
```powershell
New-AzNetAppFilesBackup -ResourceGroupName "MyRG" -Location "westus2" -AccountName "MyAccount" -PoolName "MyPool" -VolumeName "MyVolume" -Name "MyVolumeBackup" -Label "ALabel"
```
#### After
```powershell
New-AzNetAppFilesBackup -ResourceGroupName "MyRG" -AccountName "MyAccount" -BackupVaultName "MyVault" -Name "MyVolumeBackup" -Label "ALabel" -VolumeResourceId $volumeResourceId 
```


### `Remove-AzNetAppFilesBackup`

- Parameter breaking-change will happen to all parameter sets
  - `-AccountBackupName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-PoolName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeObject`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12


#### Before
```powershell
Remove-AzNetAppFilesBackup -ResourceGroupName "MyRG" -AccountName "MyAccount" -PoolName "MyPool" -VolumeName "MyVolume" -Name "MyBackup"
```
#### After
```powershell
Remove-AzNetAppFilesBackup -ResourceGroupName "MyRG" -AccountName "MyAccount" -BackupVaultName "MyVault" -Name "MyVolumeBackup"
```


### `Restore-AzNetAppFilesBackupFile`

- Parameter breaking-change will happen to all parameter sets
  - `-PoolName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeObject`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12


#### Before
```powershell
Restore-AzNetAppFilesBackupFile -ResourceGroupName "MyRG" -AccountName "MyAccount" -BackupVaultName "MyVault" -BackupName "MyBackup" -FileList $fileList -DestinationVolumeId "destinationVolumeResourceId"
```
#### After
```powershell
Restore-AzNetAppFilesBackupFile -ResourceGroupName "MyRG" -AccountName "MyAccount" -BackupVaultName "MyVault" -BackupName "MyBackup" -FileList $fileList -DestinationVolumeId "destinationVolumeResourceId"
```


### `Update-AzNetAppFilesBackup`

- Parameter breaking-change will happen to all parameter sets
  - `-PoolName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeObject`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12


#### Before
```powershell
Update-AzNetAppFilesBackup -ResourceGroupName "MyRG" -AccountName "MyAccount" -Name "BackupName" -Label "updatedLabel"
```
#### After
```powershell
Update-AzNetAppFilesBackup -ResourceGroupName "MyRG" -AccountName "MyAccount" -BackupVaultName "MyVault" -Name "BackupName" -Label "updatedLabel"
```


## Az.Sql

### `Get-AzSqlInstanceLink`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel' is changing
  - The following properties in the output type are being deprecated : 'TargetDatabase' 'PrimaryAvailabilityGroupName' 'SecondaryAvailabilityGroupName' 'SourceEndpoint' 'SourceReplicaId' 'TargetReplicaId' 'LinkState' 'LastHardenedLsn'
  - The following properties are being added to the output type : 'Database' 'DistributedAvailabilityGroupName ' 'InstanceAvailabilityGroupName' 'PartnerAvailabilityGroupName' 'InstanceLinkRole' 'PartnerLinkRole' 'FailoverMode' 'SeedingMode' 'PartnerEndpoint'
  - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0


#### Before
```powershell
Get-AzSqlInstanceLink -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "Link01"
```
#### After
```powershell
Get-AzSqlInstanceLink -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "Link01"
```


### `New-AzSqlInstanceLink`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel' is changing
  - The following properties in the output type are being deprecated : 'TargetDatabase' 'PrimaryAvailabilityGroupName' 'SecondaryAvailabilityGroupName' 'SourceEndpoint' 'SourceReplicaId' 'TargetReplicaId' 'LinkState' 'LastHardenedLsn'
  - The following properties are being added to the output type : 'Database' 'DistributedAvailabilityGroupName ' 'InstanceAvailabilityGroupName' 'PartnerAvailabilityGroupName' 'InstanceLinkRole' 'PartnerLinkRole' 'FailoverMode' 'SeedingMode' 'PartnerEndpoint'
  - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-PrimaryAvailabilityGroupName`
    - The parameter : 'PrimaryAvailabilityGroupName' is being replaced by parameter : 'PartnerAvailabilityGroupName'.
    - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0
  - `-SecondaryAvailabilityGroupName`
    - The parameter : 'SecondaryAvailabilityGroupName' is being replaced by parameter : 'InstanceAvailabilityGroupName'.
    - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0
  - `-SourceEndpoint`
    - The parameter : 'SourceEndpoint' is being replaced by parameter : 'PartnerEndpoint'.
    - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0
  - `-TargetDatabase`
    - The parameter 'TargetDatabase' is being replaced by parameter 'Database'. The type of new parameter is changing from 'string' to 'string[]'
    - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0


#### Before
```powershell
New-AzSqlInstanceLink -InstanceObject $instance -Name "Link01" -PrimaryAvailabilityGroupName "Link01PrimaryAG" -SecondaryAvailabilityGroupName "Link01SecondaryAG" -TargetDatabase "Database01" -SourceEndpoint "TCP://SERVER01:5022"
```
#### After
```powershell
New-AzSqlInstanceLink -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "Link01" -Database "Database01" -InstanceAvailabilityGroupName "AG_Database01_MI" -PartnerAvailabilityGroupName "AG_Database01" -InstanceLinkRole "Secondary" -PartnerEndpoint "TCP://SERVER01:5022" -FailoverMode "Manual" -SeedingMode "Automatic"

```


### `Remove-AzSqlInstanceLink`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel' is changing
  - The following properties in the output type are being deprecated : 'TargetDatabase' 'PrimaryAvailabilityGroupName' 'SecondaryAvailabilityGroupName' 'SourceEndpoint' 'SourceReplicaId' 'TargetReplicaId' 'LinkState' 'LastHardenedLsn'
  - The following properties are being added to the output type : 'Database' 'DistributedAvailabilityGroupName ' 'InstanceAvailabilityGroupName' 'PartnerAvailabilityGroupName' 'InstanceLinkRole' 'PartnerLinkRole' 'FailoverMode' 'SeedingMode' 'PartnerEndpoint'
  - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0


#### Before
```powershell
Remove-AzSqlInstanceLink -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "Link01"
```
#### After
```powershell
Remove-AzSqlInstanceLink -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "Link01"
```


### `Update-AzSqlInstanceLink`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel' is changing
  - The following properties in the output type are being deprecated : 'TargetDatabase' 'PrimaryAvailabilityGroupName' 'SecondaryAvailabilityGroupName' 'SourceEndpoint' 'SourceReplicaId' 'TargetReplicaId' 'LinkState' 'LastHardenedLsn'
  - The following properties are being added to the output type : 'Database' 'DistributedAvailabilityGroupName ' 'InstanceAvailabilityGroupName' 'PartnerAvailabilityGroupName' 'InstanceLinkRole' 'PartnerLinkRole' 'FailoverMode' 'SeedingMode' 'PartnerEndpoint'
  - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0


#### Before
```powershell
Update-AzSqlInstanceLink -ResourceGroupName "ResourceGroup1" -InstanceName "ManagedInstance01" -Name "Link01" -ReplicationMode "Sync"
```
#### After
```powershell
Update-AzSqlInstanceLink -ResourceGroupName "ResourceGroup1" -InstanceName "ManagedInstance01" -Name "Link01" -ReplicationMode "Sync"
```


## Az.Storage

### `Close-AzStorageFileHandle`

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
# Pipe in CloudFileShare object to close file handles 
$share = Get-AzStorageShare -ShareName $sharename -Context $ctx
$share.CloudFileShare | Close-AzStorageFileHandle -CloseAll 

# Pipe in CloudFileDirectory to close file handles recursively
$dir = Get-AzStorageFile -ShareName $shareName -Path $dirpath -Context $ctx
$dir.CloudFileDirectory | Close-AzStorageFileHandle -Recursive -CloseAll 

# Pipe in CloudFile object to close file handles 
$file = Get-AzStorageFile -ShareName $shareName -Path $filepath -Context $ctx
$file.CloudFile | Close-AzStorageFileHandle -CloseAll
```
#### After
```powershell
# Pipe in ShareClient object to close file handles 
$share = Get-AzStorageShare -ShareName $sharename -Context $ctx
$share.ShareClient | Close-AzStorageFileHandle -CloseAll -PassThru

# Pipe in ShareDirectoryClient to close file handles recursively
$dir = Get-AzStorageFile -ShareName $shareName -Path $dirpath -Context $ctx
$dir.ShareDirectoryClient | Close-AzStorageFileHandle -Recursive -CloseAll

# Pipe in ShareFileClient to close file handles 
$file = Get-AzStorageFile -ShareName $shareName -Path $filepath -Context $ctx
$file.ShareFileClient | Close-AzStorageFileHandle -CloseAll
```


### `Get-AzStorageFile`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - The child property CloudFileDirectory from deprecated v11 SDK will be removed. Use child property ShareDirectoryClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$dir = Get-AzStorageFile -ShareName $sharename -Path $dirpath -Context $ctx
# Use CloudFileDirectory to access .NET SDK methods 
$dir.CloudFileDirectory.ListFilesAndDirectories()

$file = Get-AzStorageFile -ShareName $sharename -Path $filepath -Context $ctx 
# Use CloudFile to access .NET SDK methods 
$file.CloudFile

$share = Get-AzStorageShare -ShareName $sharename -Context $ctx
Get-AzStorageFile -Share $share.CloudFileShare -Path $filepath

Get-AzStorageFile -Directory $dir.CloudFileDirectory

```
#### After
```powershell
$dir = Get-AzStorageFile -ShareName $sharename -Path $dirpath -Context $ctx
# Use ShareDirectoryClient to access .NET SDK methods 
$dir.ShareDirectoryClient.GetFilesAndDirectories()

$file = Get-AzStorageFile -ShareName testshare1 -Path testfile2 -Context $ctx
# Use ShareFileClient to access .NET SDK methods 
$file.ShareFileClient 

$share = Get-AzStorageShare -ShareName $sharename -Context $ctx
Get-AzStorageFile -ShareClient $share.ShareClient -Path $filepath -Context $ctx

Get-AzStorageFile -ShareDirectoryClient $dir.ShareDirectoryClient -Context $ctx
```


### `Get-AzStorageFileContent`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed when -PassThru is specified. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$file = Get-AzStorageFileContent -ShareName $sharename -Path $filepath -Destination $destpath -Context $ctx -PassThru
# Use CloudFile property to access .NET SDK methods 
$file.CloudFile

# Input CloudFileShare object to download a file 
$share = Get-AzStorageShare -ShareName $sharename -Context $ctx
Get-AzStorageFileContent -Share $share.CloudFileShare -Path $filepath -Destination $destpath

# Input CloudFileDirectory object to download a file 
$dir = Get-AzStorageFile -ShareName $shareName -Path $dirpath -Context $ctx
Get-AzStorageFileContent -Directory $dir.CloudFileDirectory -Path $path

# Input CloudFile object to download a file 
$file = Get-AzStorageFile -ShareName $sharename -Path $filepath -Context $ctx 
Get-AzStorageFileContent -File $file.CloudFile 
```
#### After
```powershell
$file = Get-AzStorageFileContent -ShareName $sharename -Path $filepath -Destination $destpath -Context $ctx -PassThru
# Use ShareFileClient property to access .NET SDK methods 
$file.ShareFileClient

# Input ShareClient object to download a file 
$share = Get-AzStorageShare -ShareName $sharename -Context $ctx
Get-AzStorageFileContent -ShareClient $share.ShareClient -Path $filepath -Destination $destpath -Context $ctx

# Input ShareDirectoryClient to download a file  
$dir = Get-AzStorageFile -ShareName $shareName -Path $dirpath -Context $ctx
Get-AzStorageFileContent -ShareDirectoryClient $dir.ShareDirectoryClient -Path $path -Context $ctx

# Input ShareFileClient object to download a file 
$file = Get-AzStorageFile -ShareName $sharename -Path $filepath -Context $ctx 
Get-AzStorageFileContent -ShareFileClient $file.ShareFileClient  -Context $ctx 
```


### `Get-AzStorageFileCopyState`

- Parameter breaking-change will happen to all parameter sets
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
# Input CloudFile object to get copy state 
Get-AzStorageFileCopyState -File $file.CloudFile
```
#### After
```powershell
# input ShareFileClient object to get copy state
Get-AzStorageFileCopyState -ShareFileClient $file.ShareFileClient
```


### `Get-AzStorageFileHandle`

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$share = Get-AzStorageShare -Name $shareName -Context $ctx
$share.CloudFileShare | Get-AzStorageFileHandle -Recursive

$dir = Get-AzStorageFile -ShareName $shareName -Path $path -Context $ctx
$dir.CloudFileDirectory | Get-AzStorageFileHandle -Recursive

$file = Get-AzStorageFile -ShareName $shareName -Path $filepath -Context $ctx
$file.CloudFile | Get-AzStorageFileHandle -Recursive
```
#### After
```powershell
$share = Get-AzStorageShare -Name $shareName -Context $ctx
$share.ShareClient | Get-AzStorageFileHandle -Recursive

$dir = Get-AzStorageFile -ShareName $shareName -Path $path -Context $ctx
$dir.ShareDirectoryClient | Get-AzStorageFileHandle -Recursive

$file = Get-AzStorageFile -ShareName $shareName -Path $filepath -Context $ctx
$file.ShareFileClient | Get-AzStorageFileHandle -Recursive
```


### `Get-AzStorageShare`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileShare from deprecated v11 SDK will be removed. Use child property ShareClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$share = Get-AzStorageShare -Name $sharename -Context $ctx
$share.CloudFileShare
```
#### After
```powershell
$share = Get-AzStorageShare -Name $sharename -Context $ctx
$share.ShareClient
```


### `New-AzStorageDirectory`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileDirectory from deprecated v11 SDK will be removed. Use child property ShareDirectoryClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$dir = New-AzStorageDirectory -ShareName testshare1 -Path $dirpath -Context $ctx 
$dir.CloudFileDirectory

$share = Get-AzStorageShare -Name $sharename -Context $ctx
New-AzStorageDirectory -Share $share.CloudFileShare -Path $dirpath

$dir = Get-AzStorageFile -ShareName $shareName -Path $path -Context $ctx
New-AzStorageDirectory -Directory $dir.CloudFileDirectory -Path $dirpath
```
#### After
```powershell
$dir = New-AzStorageDirectory -ShareName $sharename -Path $dirpath -Context $ctx 
$dir.ShareDirectoryClient

$share = Get-AzStorageShare -Name $sharename -Context $ctx
New-AzStorageDirectory -ShareClient $share.ShareClient -Path $dirpath -Context $ctx 
```


### `New-AzStorageFileSASToken`

- Parameter breaking-change will happen to all parameter sets
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and a new mandatory parameter ShareFileClient will be added.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Protocol`
    - The type of parameter Protocol will be changed from SharedAccessProtocol to string.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$file = Get-AzStorageFile -ShareName $shareName -Path $filepath -Context $ctx

New-AzStorageFileSASToken -File $file.CloudFile -Permission rdwl -Protocol HttpsOnly
```
#### After
```powershell
$file = Get-AzStorageFile -ShareName $shareName -Path $filepath -Context $ctx

New-AzStorageFileSASToken -ShareFileClient $file.ShareFileClient -Permission rdwl -Protocol HttpsOnly
```


### `New-AzStorageShare`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileShare from deprecated v11 SDK will be removed. Use child property ShareClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$s = New-AzStorageShare -Name $sharename -Context $ctx 

# Use CloudFileShare to access .NET SDK methods 
$s.CloudFileShare
```
#### After
```powershell
$s = New-AzStorageShare -Name $sharename -Context $ctx 

# Use ShareClient to access .NET SDK methods 
$s.ShareClient
```


### `New-AzStorageShareSASToken`

- Parameter breaking-change will happen to all parameter sets
  - `-Protocol`
    - The type of parameter Protocol will be changed from SharedAccessProtocol to string.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
New-AzStorageShareSASToken -ShareName $sharename -Permission rdwl -Protocol HttpsOnly -Context $ctx 
```
#### After
```powershell
New-AzStorageShareSASToken -ShareName $sharename -Permission rdwl -Protocol HttpsOnly -Context $ctx 
```


### `Remove-AzStorageDirectory`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileDirectory from deprecated v11 SDK will be removed when -PassThru is specified. Use child property ShareDirectoryClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$share = Get-AzStorageShare -Name $sharename -Context $ctx 
Remove-AzStorageDirectory -Share $share.CloudFileShare -Path $dirpath

$dir = Get-AzStorageFile -ShareName $sharename -Path $dirpath -Context $ctx 
Remove-AzStorageDirectory -Directory $dir.CloudFileDirectory 
```
#### After
```powershell
$share = Get-AzStorageShare -Name $sharename -Context $ctx 
Remove-AzStorageDirectory -ShareClient $share.ShareClient -Path $dirpath -Context $ctx

$dir = Get-AzStorageFile -ShareName $sharename -Path $dirpath -Context $ctx 
Remove-AzStorageDirectory -ShareDirectoryClient.ShareDirectoryClient -Context $ctx
```


### `Remove-AzStorageFile`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed when -PassThru is specified. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$f = Remove-AzStorageFile -ShareName $sharename -Path $filepath -Context $ctx -PassThru
$f.CloudFile

$share = Get-AzStorageShare -Name $sharename -Context $ctx 
Remove-AzStorageFile -Share $share.CloudFileShare -Path $filepath

$dir = Get-AzStorageFile -ShareName $sharename -Path $filepath -Context $ctx 
Remove-AzStorageFile -Directory $dir.CloudFileDirectory -Path $filepath

$f = Get-AzStorageFile -ShareName $sharename -Path $filepath -Context $ctx 
Remove-AzStorageFile -File $f.CloudFile
```
#### After
```powershell
$f = Remove-AzStorageFile -ShareName $sharename -Path $filepath -Context $ctx -PassThru
$f.ShareFileClient

$share = Get-AzStorageShare -Name $sharename -Context $ctx 
Remove-AzStorageFile -ShareClient $share.ShareClient -Path $filepath -Context $ctx 

$dir = Get-AzStorageFile -ShareName $sharename -Path $filepath -Context $ctx 
Remove-AzStorageFile -ShareDirectoryClient $dir.ShareDirectoryClient -Path $filepath -Context $ctx 

$f = Get-AzStorageFile -ShareName $sharename -Path $filepath -Context $ctx 
Remove-AzStorageFile -ShareFileClient $f.ShareFileClient -Context $ctx 
```


### `Remove-AzStorageShare`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileShare from deprecated v11 SDK will be removed when -PassThru is specified. Use child property ShareClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$share = Get-AzStorageShare -Name $sharename -Context $ctx
Remove-AzStorageShare -Share $share.CloudShare
```
#### After
```powershell
$share = Get-AzStorageShare -Name $sharename -Context $ctx
Remove-AzStorageShare -ShareClient $share.ShareClient
```


### `Rename-AzStorageDirectory`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileDirectory from deprecated v11 SDK will be removed. Use child property ShareDirectoryClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$dir = Rename-AzStorageDirectory -ShareName $sharename -SourcePath $dirpath -DestinationPath $destdir -Context $ctx

$dir.CloudFileDirectory 
```
#### After
```powershell
$dir = Rename-AzStorageDirectory -ShareName $sharename -SourcePath $dirpath -DestinationPath $destdir -Context $ctx

$dir.ShareDirectoryClient
```


### `Rename-AzStorageFile`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$file = Rename-AzStorageFile -ShareName $sharename -SourcePath $filename -DestinationPath $destfilename -Context $ctx 
$file.CloudFile
```
#### After
```powershell
$file = Rename-AzStorageFile -ShareName $sharename -SourcePath $filename -DestinationPath $destfilename -Context $ctx 
$file.ShareFileClient
```


### `Set-AzStorageFileContent`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$share = Get-AzStorageShare -Name $sharename -Context $ctx
Set-AzStorageFileContent -Share $share.CloudFileShare -Path $filepath -Source $sourcefile

$dir = Get-AzStorageFile -ShareName $sharename -Path $dirpath -Context $ctx 
Set-AzStorageFileContent -Directory $dir.CloudFileDirectory -Path $filepath -Source $sourcefile 

$f = Set-AzStorageFileContent -Directory $dir.CloudFileDirectory -Path $filepath -Source $sourcefile -PassThru
$f.CloudFile
```
#### After
```powershell
$share = Get-AzStorageShare -Name $sharename -Context $ctx
Set-AzStorageFileContent -ShareClient $share.ShareClient -Path $filepath -Source $sourcefile -Context $ctx

$dir = Get-AzStorageFile -ShareName $sharename -Path $dirpath -Context $ctx
Set-AzStorageFileContent -ShareDirectoryClient $dir.ShareDirectoryClient -Path $filepath -Source $sourcefile -Context $ctx

$f = Set-AzStorageFileContent -ShareDirectoryClient $dir.ShareDirectoryClient -Path $filepath -Source $sourcefile -Context $ctx -PassThru
$f.ShareFileClient
```


### `Set-AzStorageShareQuota`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileShare from deprecated v11 SDK will be removed. Use child property ShareClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and a new mandatory parameter ShareClient will be added.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$share = Set-AzStorageShareQuota -ShareName $sharename -Quota 200 -Context $ctx 
$share.CloudFileShare

$share = Get-AzStorageShare -Name $sharename -Context $ctx
Set-AzStorageShareQuota -Share $share.CloudFileShare -Quota 200
```
#### After
```powershell
$share = Set-AzStorageShareQuota -ShareName $sharename -Quota 200 -Context $ctx 
$share.ShareClient

$share = Get-AzStorageShare -Name $sharename -Context $ctx
Set-AzStorageShareQuota -ShareClient $share.ShareClient -Quota 200 -Context $ctx
```


### `Start-AzStorageFileCopy`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-DestFile`
    - The parameter DestFile will be deprecated. To input a dest file instance, use DestShareFileClient instead.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-SrcFile`
    - The type of parameter SrcFile will be changed from CloudFile to ShareFileClient. The alias CloudFile will be deprecated.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-SrcShare`
    - The type of parameter SrcShare will be changed from CloudFileShare to ShareClient. The alias CloudFileShare will be deprecated.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$f1 = Get-AzStorageFile -ShareName $sharename1 -Path $filepath -Context $ctx 
$f2 = Start-AzStorageFileCopy -SrcFile $f1.CloudFile -DestShareName $shareName -DestFilePath $destfilepath -DestContext $ctx

$f2.CloudFile

$fdest = Get-AzStorageFile -ShareName $sharename2 -Path $filepath2 -Context $ctx
Start-AzStorageFileCopy -SrcFile $f1.CloudFile -DestFile $fdest.CloudFile -Force 

$share = Get-AzStorageShare -Name $sharename -Context $ctx
Start-AzStorageFileCopy -SrcShare $s.CloudFileShare -SrcFilePath $srcfilepath -DestShareName $shareName -DestFilePath $destfilepath -DestContext $ctx
```
#### After
```powershell
$f1 = Get-AzStorageFile -ShareName $sharename1 -Path $filepath -Context $ctx 
$f2 = Start-AzStorageFileCopy -SrcFile $f1.ShareFileClient -DestShareName $shareName -DestFilePath $destfilepath -Force -DestContext $ctx

$f2.ShareFileClient

$fdest = Get-AzStorageFile -ShareName $sharename2 -Path $filepath2 -Context $ctx
Start-AzStorageFileCopy -SrcFile $f1.ShareFileClient -DestFile $fdest.ShareFileClient -Force -DestContext $ctx

$share = Get-AzStorageShare -Name $sharename -Context $ctx
Start-AzStorageFileCopy -SrcShare $s.ShareClient -SrcFilePath $srcfilepath -DestShareName $shareName -DestFilePath $destfilepath -Force -DestContext $ctx
```


### `Stop-AzStorageFileCopy`

- Parameter breaking-change will happen to all parameter sets
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0


#### Before
```powershell
$fd = Get-AzStorageFile -ShareName $shareName -Path $filepath -Context $ctx
Stop-AzStorageFileCopy -File $fd.CloudFile -Context $ctx -Force
```
#### After
```powershell
$fd = Get-AzStorageFile -ShareName $shareName -Path $filepath -Context $ctx
Stop-AzStorageFileCopy -ShareFileClient $fd.ShareFileClient -Context $ctx -Force
```


### `Get-AzStorageBlobContent`
- Parameter breaking-change will happen to parameter set UriPipeline
  - When download blob with parameter AbsoluteUri (alias Uri, BlobUri), parameter Context will not be allowed to input together.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

#### Before
```powershell
Allow input -Context and -AbsoluteUri together, but Context value actually is not used when execute the cmdlet:
```powershell
Get-AzStorageBlobContent -AbsoluteUri $sasuri -Destination c:\tempfile -Context $ctx
```
```
#### After
```powershell
Get-AzStorageBlobContent -AbsoluteUri $sasuri -Destination c:\tempfile
```


