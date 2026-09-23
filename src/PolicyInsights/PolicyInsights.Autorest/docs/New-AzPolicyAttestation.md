---
external help file:
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/new-azpolicyattestation
schema: 2.0.0
---

# New-AzPolicyAttestation

## SYNOPSIS
Creates a new policy attestation for a policy assignment.

## SYNTAX

### CreateBySubscriptionId (Default)
```
New-AzPolicyAttestation -Name <String> -PolicyAssignmentId <String> [-SubscriptionId <String>]
 [-AssessmentDate <DateTime>] [-Comment <String>] [-ComplianceState <String>]
 [-Evidence <IAttestationEvidence[]>] [-ExpiresOn <DateTime>] [-Metadata <String>] [-Owner <String>]
 [-PolicyDefinitionReferenceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateByResourceGroup
```
New-AzPolicyAttestation -Name <String> -ResourceGroupName <String> -PolicyAssignmentId <String>
 [-SubscriptionId <String>] [-AssessmentDate <DateTime>] [-Comment <String>] [-ComplianceState <String>]
 [-Evidence <IAttestationEvidence[]>] [-ExpiresOn <DateTime>] [-Metadata <String>] [-Owner <String>]
 [-PolicyDefinitionReferenceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateByResourceId
```
New-AzPolicyAttestation -Name <String> -ResourceId <String> -PolicyAssignmentId <String>
 [-AssessmentDate <DateTime>] [-Comment <String>] [-ComplianceState <String>]
 [-Evidence <IAttestationEvidence[]>] [-ExpiresOn <DateTime>] [-Metadata <String>] [-Owner <String>]
 [-PolicyDefinitionReferenceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateByScope
```
New-AzPolicyAttestation -Name <String> -Scope <String> -PolicyAssignmentId <String>
 [-AssessmentDate <DateTime>] [-Comment <String>] [-ComplianceState <String>]
 [-Evidence <IAttestationEvidence[]>] [-ExpiresOn <DateTime>] [-Metadata <String>] [-Owner <String>]
 [-PolicyDefinitionReferenceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzPolicyAttestation -InputObject <IPolicyInsightsIdentity> -PolicyAssignmentId <String>
 [-AssessmentDate <DateTime>] [-Comment <String>] [-ComplianceState <String>]
 [-Evidence <IAttestationEvidence[]>] [-ExpiresOn <DateTime>] [-Metadata <String>] [-Owner <String>]
 [-PolicyDefinitionReferenceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzPolicyAttestation** cmdlet creates a policy attestation for a particular policy assignment.

Attestations are used by Azure Policy to set compliance states of resources or scopes targeted by manual policies.

They also allow users to provide additional metadata or link to evidence which accompanies the attested compliance state.

## EXAMPLES

### Example 1: Create an attestation at subscription scope
```powershell
$policyAssignmentId = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/Microsoft.Authorization/policyAssignments/PSAttestationSubAssignment"
$attestationName = "Attestation-SubscriptionScope-Crud"
New-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
```

```output
AssessmentDate               :
Comment                      :
ComplianceState              : Compliant
Evidence                     :
ExpiresOn                    :
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.policyinsights/attestations/attestation-subscriptionscope-crud
LastComplianceStateChangeAt  : 3/26/2026 9:01:05 PM
Metadata                     : {
                               }
Name                         : Attestation-SubscriptionScope-Crud
Owner                        :
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationsubassignment
PolicyDefinitionReferenceId  :
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 3/26/2026 9:01:05 PM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/26/2026 9:01:05 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

This command creates a new policy attestation at subscription 'e5a130f3-57fd-46b6-9c55-03d21a853935' for the given policy assignment.

\>**Note:**
\>This command creates an attestation for the subscription and not the resources underneath it.
For ease of management, manual policies should be designed to target the scope which defines the boundary of resources whose compliance state needs to be attested.
In this case, the manual policy should be targeting `Microsoft.Resources/subscriptions`.
For more information, go to https://learn.microsoft.com/en-us/azure/governance/policy/concepts/attestation-structure to understand the best practices for creating attestations.

### Example 2: Create an attestation at resource group
```powershell
$policyAssignmentId = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/Microsoft.Authorization/policyAssignments/PSAttestationRGAssignment"
$attestationName = "Attestation-RGScope-Crud"
$rgName = "ps-attestation-test-rg"
New-AzPolicyAttestation -ResourceGroupName $RGName -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
```

```output
AssessmentDate               :
Comment                      :
ComplianceState              : Compliant
Evidence                     :
ExpiresOn                    :
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourcegroups/ps-attestation-test-rg/providers/microsoft.policyinsights/attestations/attestation-rgscope-crud
LastComplianceStateChangeAt  : 3/26/2026 9:28:05 PM
Metadata                     : {
                               }
Name                         : Attestation-RGScope-Crud
Owner                        :
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationrgassignment
PolicyDefinitionReferenceId  :
ProvisioningState            : Succeeded
ResourceGroupName            : ps-attestation-test-rg
SystemDataCreatedAt          : 3/26/2026 9:28:05 PM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/26/2026 9:28:05 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

This command creates a new policy attestation at the resource group 'ps-attestation-test-rg' for the given policy assignment.

\>**Note:**
\>This command creates an attestation for the resource group and not the resources underneath it.
For ease of management, manual policies should be designed to target the scope which defines the boundary of resources whose compliance state needs to be attested.
In this case, the manual policy should be targeting `Microsoft.Resources/subscriptions/resourceGroups`.
For more information, go to https://learn.microsoft.com/en-us/azure/governance/policy/concepts/attestation-structure to understand the best practices for creating attestations.

### Example 3: Create an attestation at resource
```powershell
$policyAssignmentId = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/Microsoft.Authorization/policyAssignments/PSAttestationResourceAssignment"
$attestationName = "Attestation-ResourceScope-Crud"
$scope = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourceGroups/ps-attestation-test-rg/providers/Microsoft.Network/networkSecurityGroups/pstests0"
New-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -Scope $scope -ComplianceState "Compliant"
```

```output
AssessmentDate               :
Comment                      :
ComplianceState              : Compliant
Evidence                     :
ExpiresOn                    :
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourcegroups/ps-attestation-test-rg/providers/microsoft.network/networksecuritygroups/pstests0/providers/microsoft.policyins
                               ights/attestations/attestation-resourcescope-crud
LastComplianceStateChangeAt  : 3/26/2026 9:28:50 PM
Metadata                     : {
                               }
Name                         : Attestation-ResourceScope-Crud
Owner                        :
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationresourceassignment
PolicyDefinitionReferenceId  :
ProvisioningState            : Succeeded
ResourceGroupName            : ps-attestation-test-rg
SystemDataCreatedAt          : 3/26/2026 9:28:50 PM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/26/2026 9:28:50 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

This command creates an attestation for the resource 'pstests0' for the given policy assignment.

### Example 4: Create an attestation with all properties at resource group
```powershell
$attestationName = "Attestation-RG-Full"
$policyInitiativeAssignmentId = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/PSAttestationInitiativeRGAssignment"

$policyDefinitionReferenceId = "PSTestAttestationRG_1"
$RGName = "ps-attestation-test-rg"
$description = "This is a test description"
$sourceURI = "https://contoso.org/test.pdf"
$evidence = @{ "Description"=$description; "SourceUri"=$sourceURI }
$comment = "This is a test comment"
$policyEvidence = @($evidence)
$owner = "Test Owner"
$expiresOn = [datetime]::UtcNow.AddYears(1)
$metadata = '{"TestKey":"TestValue"}'
$compliant = "Compliant"

New-AzPolicyAttestation `
    -Name $attestationName `
    -ResourceGroupName $RGName `
    -PolicyAssignmentId $policyInitiativeAssignmentId `
    -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
    -ComplianceState $Compliant `
    -Comment $comment `
    -Evidence $policyEvidence `
    -ExpiresOn $expiresOn `
    -AssessmentDate $expiresOn.AddDays(-2) `
    -Owner $owner `
    -Metadata $metadata
```

```output
AssessmentDate               : 3/25/2027 12:00:19 AM
Comment                      : This is a test comment
ComplianceState              : Compliant
Evidence                     : {{
                                 "description": "This is a test description",
                                 "sourceUri": "https://contoso.org/test.pdf"
                               }}
ExpiresOn                    : 3/27/2027 12:00:19 AM
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourcegroups/ps-attestation-test-rg/providers/microsoft.policyinsights/attestations/attestation-rg-full
LastComplianceStateChangeAt  : 3/27/2026 12:01:31 AM
Metadata                     : {
                                 "TestKey": "TestValue"
                               }
Name                         : Attestation-RG-Full
Owner                        : Test Owner
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationinitiativergassignment
PolicyDefinitionReferenceId  : pstestattestationrg_1
ProvisioningState            : Succeeded
ResourceGroupName            : ps-attestation-test-rg
SystemDataCreatedAt          : 3/27/2026 12:01:31 AM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/27/2026 12:01:31 AM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

This command creates an attestation at resource group scope with all of the fields populated.

## PARAMETERS

### -AssessmentDate
The time the evidence was assessed

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Comment
Comments describing why this attestation was created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComplianceState
The Compliance State of the resource.
E.g.
'Compliant', 'NonCompliant', 'Unknown'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Evidence
The evidence supporting the compliance state set in this attestation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IAttestationEvidence[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpiresOn
The time the compliance state set in the attestation should expire.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyInsightsIdentity
Parameter Sets: CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Metadata
Additional metadata for this attestation

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the attestation.

```yaml
Type: System.String
Parameter Sets: CreateByResourceGroup, CreateByResourceId, CreateByScope, CreateBySubscriptionId
Aliases: AttestationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Owner
The person responsible for setting the state of the resource.
This value is typically a Microsoft Entra object ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyAssignmentId
The resource ID of the policy assignment that the attestation is setting the state for.
E.g.
'/subscriptions/\{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/\{assignmentName}'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyDefinitionReferenceId
The policy definition reference ID from a policy set definition that the attestation is setting the state for.
If the policy assignment assigns a policy set definition the attestation can choose a definition within the set definition with this property or omit this and set the state for the entire set definition.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateByResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ID of the resource to make the attestation on.

```yaml
Type: System.String
Parameter Sets: CreateByResourceId
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Scope of the resource.
E.g.
'/subscriptions/\{subscriptionId}/resourceGroups/\{rgName}'.

```yaml
Type: System.String
Parameter Sets: CreateByScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
Uses current subscription if one isn't provided.

```yaml
Type: System.String
Parameter Sets: CreateByResourceGroup, CreateBySubscriptionId
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IAttestation

## NOTES

## RELATED LINKS

