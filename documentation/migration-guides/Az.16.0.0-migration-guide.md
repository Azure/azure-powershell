# Migration Guide for Az 16.0.0

## Az.DesktopVirtualization

### `Update-AzWvdApplication`

- Parameter breaking-change will happen to all parameter sets
  - `-Tag`
    - The parameter : 'Tag' is changing.
    - Change description : The parameter 'Tag' will be removed from the Update cmdlet of Application. 
    - This change will take effect on '6/2/2026'- The change is expected to take effect from Az version : '16.0.0'
    - The change is expected to take effect in 'Az.DesktopVirtualization' from version : '6.0.0'


#### Before
```powershell
Update-AzWvdApplication -ResourceGroupName 'RGName' -GroupName 'AppGroupName' -Name 'AppName' -Tag @{ Env = "Prod" } -FriendlyName 'AppFriendlyName' 
```
#### After
```powershell
Update-AzWvdApplication -ResourceGroupName 'RGName' -GroupName 'AppGroupName' -Name 'AppName' -FriendlyName 'AppFriendlyName' 
```


### `Update-AzWvdDesktop`

- Parameter breaking-change will happen to all parameter sets
  - `-Tag`
    - The parameter : 'Tag' is changing.
    - Change description : The parameter 'Tag' will be removed from the Update cmdlet of Desktop. 
    - This change will take effect on '6/2/2026'- The change is expected to take effect from Az version : '16.0.0'
    - The change is expected to take effect in 'Az.DesktopVirtualization' from version : '6.0.0'


#### Before
```powershell
Update-AzWvdDesktop -ResourceGroupName 'RGName' -ApplicationGroupName 'AppGroupName' -Name 'DesktopName' -FriendlyName 'DesktopFriendlyName' -Tag @{ Env = "Prod" }
```
#### After
```powershell
Update-AzWvdDesktop -ResourceGroupName 'RGName' -ApplicationGroupName 'AppGroupName' -Name 'DesktopName' -FriendlyName 'DesktopFriendlyName'
```


## Az.NetworkCloud

### `Update-AzNetworkCloudVirtualMachine`
- Cmdlet breaking-change will happen to all parameter sets - The cmdlet will no longer support the 'JsonString' and 'JsonFilePath' parameter sets. The 'UpdateViaJsonString' and 'UpdateViaJsonFilePath' sets have been removed. - Guidance: Update scripts to use the expanded parameter sets instead of passing JSON input. - This change is expected to take effect on 5/1/2026, from Az.NetworkCloud version: 3.0.0 and Az version: 16.0.0

#### Before
```powershell
$json = @"
{ "location": "eastus", "extendedLocation": { "name": "myCustomLocation", "type": "CustomLocation" }, "tags": { "env": "test" }
}
"@
Update-AzNetworkCloudVirtualMachine ` -ResourceGroupName MyRg ` -Name MyResource ` -JsonString $json
```
#### After
```powershell
Update-AzNetworkCloudVirtualMachine -ResourceGroupName MyRg -Name MyResource -Location "eastus" -ExtendedLocationName "myCustomLocation" -ExtendedLocationType "CustomLocation" -Tag @{ env = "test" }
```


## Az.PolicyInsights

### `Get-AzPolicyAttestation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation' to the new type :'Attestation'
  - The following properties in the output type are being deprecated : 'SystemData'
  - The following properties are being added to the output type : 'ResourceGroupName' 'SystemDataCreatedAt' 'SystemDataCreatedBy' 'SystemDataCreatedByType' 'SystemDataLastModifiedAt' 'SystemDataLastModifiedBy' 'SystemDataLastModifiedByType'
  - This change is expected to take effect from Az.PolicyInsights version: 2.0.0 and Az version: 16.0.0


#### Before
```powershell
$attestation = Get-AzPolicyAttestation -ResourceGroupName "ps-attestation-test-rg" -Name "Attestation-RGScope-Crud"
[Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation]$attestation = $attestation
$creationTime = $attestation.SystemData.CreatedAt
```
#### After
```powershell
$attestation = Get-AzPolicyAttestation -ResourceGroupName "ps-attestation-test-rg" -Name "Attestation-RGScope-Crud"
[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IAttestation]$attestation = $attestation
$creationTime = $attestation.SystemDataCreatedAt
```


### `Get-AzPolicyEvent`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.PolicyInsights.Models.PolicyEvent' is changing
  - The following properties in the output type are being deprecated : 'ResourceTags' 'ManagementGroupIds'
  - The following properties are being added to the output type : 'ResourceTag' 'ManagementGroupId' 'ComplianceState' 'Component' 'EffectiveParameter' 'OdataContext' 'OdataId' 'Keys' 'Values' 'Count' 'AdditionalProperties'
  - This change is expected to take effect from Az.PolicyInsights version: 2.0.0 and Az version: 16.0.0


#### Before
```powershell
$event = Get-AzPolicyEvent -ResourceGroupName "myResourceGroup" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
[Microsoft.Azure.Commands.PolicyInsights.Models.PolicyEvent]$event = $event 
$managementGroup = $event[0].ManagementGroupIds
```
#### After
```powershell
$event = Get-AzPolicyEvent -ResourceGroupName "myResourceGroup" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyEvent]$event = $event
$managementGroup = $event[0].ManagementGroupId
```


### `Get-AzPolicyMetadata`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.Commands.PolicyInsights.Models.PSPolicyMetadata' to the new type :'PolicyMetadata'
  - The following properties are being added to the output type : 'ResourceGroupName'
  - This change is expected to take effect from Az.PolicyInsights version: 2.0.0 and Az version: 16.0.0


#### Before
```powershell
$metadata = Get-AzPolicyMetadata -Name ACF1348
[Microsoft.Azure.Commands.PolicyInsights.Models.PSPolicyMetadata]$metadata = $metadata
```
#### After
```powershell
$metadata = Get-AzPolicyMetadata -Name ACF1348
[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.PolicyMetadata]$metadata = $metadata
```


### `Get-AzPolicyRemediation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.Commands.PolicyInsights.Models.Remediation.PSRemediation' to the new type :'Remediation'
  - The following properties in the output type are being deprecated : 'Filters' 'DeploymentSummary' 'FailureThreshold' 'ParallelDeployments'
  - The following properties are being added to the output type : 'FilterLocation' 'FilterResourceId' 'DeploymentStatusFailedDeployment' 'DeploymentStatusSuccessfulDeployment' 'DeploymentStatusTotalDeployment' 'FailureThresholdPercentage' 'ParallelDeployment' 'ResourceGroupName' 'SystemDataCreatedAt' 'SystemDataCreatedBy' 'SystemDataCreatedByType' 'SystemDataLastModifiedAt' 'SystemDataLastModifiedBy' 'SystemDataLastModifiedByType'
  - This change is expected to take effect from Az.PolicyInsights version: 2.0.0 and Az version: 16.0.0


#### Before
```powershell
$remediation = Get-AzPolicyRemediation -ResourceGroupName "myResourceGroup" -Name "remediation1" -IncludeDetail
[Microsoft.Azure.Commands.PolicyInsights.Models.Remediation.PSRemediation]$remediation = $remediation
$locationFilter = $remediation.Filters.Locations
```
#### After
```powershell
$remediation = Get-AzPolicyRemediation -ResourceGroupName "myResourceGroup" -Name "remediation1" -IncludeDetail
[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IRemediation]$remediation = $remediation
$locationFilter = $remediation.FilterLocation
```


### `Get-AzPolicyState`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.PolicyInsights.Models.PolicyState' is changing
  - The following properties in the output type are being deprecated : 'ResourceTags' 'ManagementGroupIds'
  - The following properties are being added to the output type : 'ResourceGroupName' 'ResourceTag' 'ManagementGroupId'
  - This change is expected to take effect from Az.PolicyInsights version: 2.0.0 and Az version: 16.0.0


#### Before
```powershell
$state = Get-AzPolicyState -ResourceGroupName "myResourceGroup" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
[Microsoft.Azure.Commands.PolicyInsights.Models.PolicyState]$state = $state
$managementGroup = $state[0].ManagementGroupIds
```
#### After
```powershell
$state = Get-AzPolicyState -ResourceGroupName "myResourceGroup" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyState]$state = $state
$managementGroup = $state[0].ManagementGroupId
```


### `Get-AzPolicyStateSummary`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.PolicyInsights.Models.PolicyStateSummary' is changing
  - The following properties in the output type are being deprecated : 'PolicyAssignments' 'Results'
  - The following properties are being added to the output type : 'PolicyAssignment' 'ResultCompliantResource' 'ResultNonCompliantPolicy' 'ResultNonCompliantResource' 'ResultPolicyDetail' 'ResultPolicyGroupDetail' 'ResultQueryResultsUri' 'ResultResourceDetail' 'OdataId' 'OdataContext'
  - This change is expected to take effect from Az.PolicyInsights version: 2.0.0 and Az version: 16.0.0


#### Before
```powershell
$stateSummary = Get-AzPolicyStateSummary -ManagementGroupName "myManagementGroup"
[Microsoft.Azure.Commands.PolicyInsights.Models.PolicyStateSummary]$stateSummary = $stateSummary
$nonCompliantResourceCount = $stateSummary.Results.NonCompliantResources
```
#### After
```powershell
$stateSummary = Get-AzPolicyStateSummary -ManagementGroupName "myManagementGroup"
[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.ISummary]$stateSummary = $stateSummary
$nonCompliantResourceCount = $stateSummary.ResultNonCompliantResource
```


### `New-AzPolicyAttestation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation' to the new type :'Attestation'
  - The following properties in the output type are being deprecated : 'SystemData'
  - The following properties are being added to the output type : 'ResourceGroupName' 'SystemDataCreatedAt' 'SystemDataCreatedBy' 'SystemDataCreatedByType' 'SystemDataLastModifiedAt' 'SystemDataLastModifiedBy' 'SystemDataLastModifiedByType'
  - This change is expected to take effect from Az.PolicyInsights version: 2.0.0 and Az version: 16.0.0


#### Before
```powershell
$attestation = New-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
[Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation]$attestation = $attestation
$creationTime = $attestation.SystemData.CreatedAt
```
#### After
```powershell
$attestation = New-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IAttestation]$attestation = $attestation
$creationTime = $attestation.SystemDataCreatedAt
```


### `Set-AzPolicyAttestation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation' to the new type :'Attestation'
  - The following properties in the output type are being deprecated : 'SystemData'
  - The following properties are being added to the output type : 'ResourceGroupName' 'SystemDataCreatedAt' 'SystemDataCreatedBy' 'SystemDataCreatedByType' 'SystemDataLastModifiedAt' 'SystemDataLastModifiedBy' 'SystemDataLastModifiedByType'
  - This change is expected to take effect from Az.PolicyInsights version: 2.0.0 and Az version: 16.0.0


#### Before
```powershell
$attestation = Set-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "NonCompliant" -Comment $comment
[Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation]$attestation = $attestation
$creationTime = $attestation.SystemData.CreatedAt
```
#### After
```powershell
$attestation = Update-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "NonCompliant" -Comment $comment
[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IAttestation]$attestation = $attestation
$creationTime = $attestation.SystemDataCreatedAt
```


### `Start-AzPolicyRemediation`

- Cmdlet breaking-change will happen to all parameter sets
  - Start-AzPolicyRemediation will now return when the Remediation reaches a terminal state unless you use the new NoWait parameter.
  - This change is expected to take effect from Az.PolicyInsights version: 2.0.0 and Az version: 16.0.0


#### Before
```powershell
$remediation = Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1"
[Microsoft.Azure.Commands.PolicyInsights.Models.Remediation.PSRemediation]$remediation = $remediation
$locationFilter = $remediation.Filters.Locations
```
#### After
```powershell
$remediation = Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -NoWait
[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IRemediation]$remediation = $remediation
$locationFilter = $remediation.FilterLocation
```


### `Stop-AzPolicyRemediation`

- Cmdlet breaking-change will happen to all parameter sets
  - Stop-AzPolicyRemediation will now have a NoWait switch parameter as well as returning the Remediation object instead of just a boolean.
  - This change is expected to take effect from Az.PolicyInsights version: 2.0.0 and Az version: 16.0.0


#### Before
```powershell
$successfulBoolean = Stop-AzPolicyRemediation -ResourceGroupName "myRG" -Name "remediation1"
```
#### After
```powershell
$remediation = Stop-AzPolicyRemediation -ResourceGroupName "myRG" -Name "remediation1"
[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IRemediation]$remediation = $remediation
```


## Az.Resources

### `Get-AzPolicyAssignment`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policyAssignment = Get-AzPolicyAssignment -Name MyAssignment -BackwardCompatible
$description = $policyAssignment.Properties.Description
```
#### After
```powershell
$policyAssignment = Get-AzPolicyAssignment -Name MyAssignment
$description = $policyAssignment.Description
```


### `Get-AzPolicyDefinition`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policyDefinition = Get-AzPolicyDefinition -Builtin -BackwardCompatible | select -First 1
$policyRule = $policyDefinition.Properties.PolicyRule
```
#### After
```powershell
$policyDefinition = Get-AzPolicyDefinition -Builtin | select -First 1
$policyRule = $policyDefinition.PolicyRule
```


### `Get-AzPolicyExemption`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policyExemption = Get-AzPolicyExemption -Scope /providers/Microsoft.Management/managementGroups/myManagementGroup -Name MyExemption -BackwardCompatible
$expiresOn = $policyExemption.Properties.ExpiresOn
```
#### After
```powershell
$policyExemption = Get-AzPolicyExemption -Scope /providers/Microsoft.Management/managementGroups/myManagementGroup -Name MyExemption
$expiresOn = $policyExemption.ExpiresOn
```


### `Get-AzPolicySetDefinition`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policySetDefinition = Get-AzPolicySetDefinition -Builtin -BackwardCompatible | select -First 1
$policySetParameters = $policySetDefinition.Properties.Parameters
```
#### After
```powershell
$policySetDefinition = Get-AzPolicySetDefinition -Builtin | select -First 1
$policySetParameters = $policySetDefinition.Parameter
```


### `New-AzPolicyAssignment`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policyAssignment = New-AzPolicyAssignment -Name MyAssignment -PolicyDefinition MyPolicyDefinition -BackwardCompatible
$enforcementMode = $policyAssignment.Properties.EnforcementMode
```
#### After
```powershell
$policyAssignment = New-AzPolicyAssignment -Name MyAssignment -PolicyDefinition MyPolicyDefinition
$enforcementMode = $policyAssignment.EnforcementMode
```


### `New-AzPolicyDefinition`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policyRule = '{ "if": { "field": "type", "like": "Microsoft.DesktopVirtualization/*" }, "then": { "effect": "deny" } }'
$policyDefinition = New-AzPolicyDefinition -Name MyDefinition -Policy $policyRule -BackwardCompatible
$policyType = $policyDefinition.Properties.PolicyType
```
#### After
```powershell
$policyRule = '{ "if": { "field": "type", "like": "Microsoft.DesktopVirtualization/*" }, "then": { "effect": "deny" } }'
$policyDefinition = New-AzPolicyDefinition -Name MyDefinition -Policy $policyRule
$policyType = $policyDefinition.PolicyType
```


### `New-AzPolicyExemption`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policyExemption = Get-AzPolicyAssignment -Name MyAssignment | New-AzPolicyExemption -Name MyExemption -ExemptionCategory Mitigated -BackwardCompatible
$policyAssignmentId = $policyExemption.Properties.PolicyAssignmentId
```
#### After
```powershell
$policyExemption = Get-AzPolicyAssignment -Name MyAssignment | New-AzPolicyExemption -Name MyExemption -ExemptionCategory Mitigated
$policyAssignmentId = $policyExemption.PolicyAssignmentId
```


### `New-AzPolicySetDefinition`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policyDefinitionReferences = ('[{ "policyDefinitionId": "' + (Get-AzPolicyDefinition -Name MyDefinition).ResourceId + '"}]')
$policySetDefinition = New-AzPolicySetDefinition -Name MySetDefinition -PolicyDefinition $policyDefinitionReferences -BackwardCompatible
$policyDefinitionReferenceId = $policySetDefinition.Properties.PolicyDefinitions[0].policyDefinitionReferenceId
```
#### After
```powershell
$policyDefinitionReferences = ('[{ "policyDefinitionId": "' + (Get-AzPolicyDefinition -Name MyDefinition).ResourceId + '"}]')
$policySetDefinition = New-AzPolicySetDefinition -Name MySetDefinition -PolicyDefinition $policyDefinitionReferences
$policyDefinitionReferenceId = $policySetDefinition.PolicyDefinition[0].policyDefinitionReferenceId
```


### `Remove-AzPolicyAssignment`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy behavior where `Remove-` cmdlets always returned a value. This parameter has now been removed. `Remove-` cmdlets will only return a value when `-PassThru` is specified.

#### Before
```powershell
$result = Remove-AzPolicyAssignment -Name MyAssignment -BackwardCompatible
```
#### After
```powershell
$result = Remove-AzPolicyAssignment -Name MyAssignment -PassThru
```


### `Remove-AzPolicyDefinition`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy behavior where `Remove-` cmdlets always returned a value. This parameter has now been removed. `Remove-` cmdlets will only return a value when `-PassThru` is specified.

#### Before
```powershell
$result = Remove-AzPolicyDefinition -Name MyDefinition -BackwardCompatible
```
#### After
```powershell
$result = Remove-AzPolicyDefinition -Name MyDefinition -PassThru
```


### `Remove-AzPolicyExemption`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy behavior where `Remove-` cmdlets always returned a value. This parameter has now been removed. `Remove-` cmdlets will only return a value when `-PassThru` is specified.

#### Before
```powershell
$result = Remove-AzPolicyExemption -Name MyExemption -BackwardCompatible
```
#### After
```powershell
$result = Remove-AzPolicyExemption -Name MyExemption -PassThru
```


### `Remove-AzPolicySetDefinition`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy behavior where `Remove-` cmdlets always returned a value. This parameter has now been removed. `Remove-` cmdlets will only return a value when `-PassThru` is specified.

#### Before
```powershell
$result = Remove-AzPolicySetDefinition -Name MySetDefinition -BackwardCompatible
```
#### After
```powershell
$result = Remove-AzPolicySetDefinition -Name MySetDefinition -PassThru
```


### `Update-AzPolicyAssignment`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policyAssignment = Update-AzPolicyAssignment -Name MyAssignment -DisplayName 'My cool assignment' -BackwardCompatible
$displayName = $policyAssignment.Properties.DisplayName
```
#### After
```powershell
$policyAssignment = Update-AzPolicyAssignment -Name MyAssignment -DisplayName 'My cool assignment'
$displayName = $policyAssignment.DisplayName
```


### `Update-AzPolicyDefinition`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policyDefinition = Update-AzPolicyDefinition -Name MyDefinition -Description 'A much better policy definition' -BackwardCompatible
$description = $policyDefinition.Properties.Description
```
#### After
```powershell
$policyDefinition = Update-AzPolicyDefinition -Name MyDefinition -Description 'A much better policy definition'
$description = $policyDefinition.Description
```


### `Update-AzPolicyExemption`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policyExemption = Update-AzPolicyExemption -Name MyExemption -ExemptionCategory Waiver -BackwardCompatible
$exemptionCategory = $policyExemption.Properties.ExemptionCategory
```
#### After
```powershell
$policyExemption = Update-AzPolicyExemption -Name MyExemption -ExemptionCategory Waiver
$exemptionCategory = $policyExemption.ExemptionCategory
```


### `Update-AzPolicySetDefinition`
The `BackwardCompatible` parameter was previously introduced to preserve the legacy `.Properties`-based output shape. This parameter has now been removed. Cmdlets always return the modern flattened object shape, and legacy access via `.Properties.*` is no longer supported. Scripts must be updated to reference first‑class properties directly.

#### Before
```powershell
$policySetDefinition = Update-AzPolicySetDefinition -Name MySetDefinition -Metadata '{ "MyThing": "A really good thing" }' -BackwardCompatible
$myThing = $policySetDefinition.Properties.Metadata.MyThing
```
#### After
```powershell
$policySetDefinition = Update-AzPolicySetDefinition -Name MySetDefinition -Metadata '{ "MyThing": "A really good thing" }'
$myThing = $policySetDefinition.Metadata.MyThing
```


## Az.Sql

### `New-AzSqlServer`
- Parameter breaking-change will happen to all parameter sets - `-EnableSoftDelete` - The parameter : 'EnableSoftDelete' is changing. - Change description : The parameter 'EnableSoftDelete' will be removed from the New-AzSqlServer cmdlet of Application. - This change will take effect on '6/2/2026'- The change is expected to take effect from Az version : '16.0.0' - The change is expected to take effect in 'Az.Sql' from version : '7.0.0'

#### Before
```powershell
New-AzSqlServer -ResourceGroupName $rg -ServerName $server -SqlAdministratorCredentials $sqlCred -Location $location-EnableSoftDelete $true
```
#### After
```powershell
New-AzSqlServer -ResourceGroupName $rg -ServerName $server -SqlAdministratorCredentials $sqlCred -Location $location -SoftDeleteRetentionDays 7
```


### `Set-AzSqlServer`
- Parameter breaking-change will happen to all parameter sets - `-EnableSoftDelete` - The parameter : 'EnableSoftDelete' is changing. - Change description : The parameter 'EnableSoftDelete' will be removed from the Set-AzSqlServer cmdlet of Application. - This change will take effect on '6/2/2026'- The change is expected to take effect from Az version : '16.0.0' - The change is expected to take effect in 'Az.Sql' from version : '7.0.0'

#### Before
```powershell
Set-AzSqlServer -ResourceGroupName $rg -ServerName -EnableSoftDelete $true
```
#### After
```powershell
Set-AzSqlServer -ResourceGroupName $rg -ServerName -SoftDeleteRetentionDays 7
```


## Az.StackHCIVM

### `New-AzStackHCIVMImage`

- Parameter breaking-change will happen to all parameter sets
  - `-ImagePath`
    


#### Before
```powershell
ImagePath is of type 'string'
```
#### After
```powershell
ImagePath has been changed to SecureString
```


### `New-AzStackHCIVMVirtualMachine`

- Parameter breaking-change will happen to all parameter sets
  - `-AdminPassword`
    


#### Before
```powershell
AdminPassword is of type 'string'
```
#### After
```powershell
AdminPassword has been changed to SecureString
```


## Az.StorageAction

### `Get-AzStorageActionTask`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTask' is changing
  - The following properties in the output type are being deprecated : 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'IdentityUserAssignedIdentity'
  - Change description : The types of the property 'IdentityUserAssignedIdentity' will be changed from 'Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IUserAssignedIdentities' to 'Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IManagedServiceIdentityUserAssignedIdentities' 
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect in 'Az.StorageAction' from version : '2.0.0'


#### Before
```powershell
$task = Get-AzStorageActionTask -ResourceGroupName MyRg -Name MyTask
[Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IUserAssignedIdentities]$identity = $task.IdentityUserAssignedIdentity
```
#### After
```powershell
$task = Get-AzStorageActionTask -ResourceGroupName MyRg -Name MyTask
[Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IManagedServiceIdentityUserAssignedIdentities]$identity = $task.IdentityUserAssignedIdentity
```


### `New-AzStorageActionTask`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTask' is changing
  - The following properties in the output type are being deprecated : 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'IdentityUserAssignedIdentity'
  - Change description : The types of the property 'IdentityUserAssignedIdentity' will be changed from 'Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IUserAssignedIdentities' to 'Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IManagedServiceIdentityUserAssignedIdentities' 
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect in 'Az.StorageAction' from version : '2.0.0'


#### Before
```powershell
$task = New-AzStorageActionTask -ResourceGroupName MyRg -Name MyTask
[Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IUserAssignedIdentities]$identity = $task.IdentityUserAssignedIdentity
```
#### After
```powershell
$task = New-AzStorageActionTask -ResourceGroupName MyRg -Name MyTask
[Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IManagedServiceIdentityUserAssignedIdentities]$identity = $task.IdentityUserAssignedIdentity
```


### `Update-AzStorageActionTask`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTask' is changing
  - The following properties in the output type are being deprecated : 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'IdentityUserAssignedIdentity'
  - Change description : The types of the property 'IdentityUserAssignedIdentity' will be changed from 'Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IUserAssignedIdentities' to 'Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IManagedServiceIdentityUserAssignedIdentities' 
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect in 'Az.StorageAction' from version : '2.0.0'


#### Before
```powershell
$task = Update-AzStorageActionTask -ResourceGroupName MyRg -Name MyTask
[Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IUserAssignedIdentities]$identity = $task.IdentityUserAssignedIdentity
```
#### After
```powershell
$task = Update-AzStorageActionTask -ResourceGroupName MyRg -Name MyTask
[Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IManagedServiceIdentityUserAssignedIdentities]$identity = $task.IdentityUserAssignedIdentity
```

## Modules migrated from autorest v3 to autorest v4

To maintain behavioral consistency and introduce new features supported by AutoRest v4, we have upgraded many modules to use AutoRest v4.
This upgrade has introduced several breaking changes.
Details about potential breaking changes and their mitigation approaches can be found at the following [link](https://go.microsoft.com/fwlink/?linkid=2333486).

### Potentially affected modules

- Az.CloudService
- Az.ContainerInstance
- Az.Databricks
- Az.DataProtection
- Az.DnsResolver
- Az.Functions
- Az.Kusto
- Az.LoadTesting
- Az.MachineLearningServices
- Az.ManagedServices
- Az.Migrate
- Az.Monitor
- Az.MySql
- Az.RedisEnterpriseCache
- Az.ResourceMover
- Az.SecurityInsights
- Az.SignalR
- Az.SqlVirtualMachine
- Az.StackHCI
- Az.Websites
