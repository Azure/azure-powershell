# Migration Guide for Az 16.0.0

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
$policyDefinitionId = $policyExemption.Properties.PolicyAssignmentId
```

#### After
```powershell
$policyExemption = Get-AzPolicyAssignment -Name MyAssignment | New-AzPolicyExemption -Name MyExemption -ExemptionCategory Mitigated
$policyDefinitionId = $policyExemption.PolicyAssignmentId
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
