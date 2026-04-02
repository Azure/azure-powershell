---
external help file: Az.PolicyInsights-help.xml
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/update-azpolicyattestation
schema: 2.0.0
---

# Update-AzPolicyAttestation

## SYNOPSIS
Modifies a policy attestation.

## SYNTAX

### UpdateBySubscriptionId (Default)
```
Update-AzPolicyAttestation -Name <String> [-SubscriptionId <String>] [-AssessmentDate <DateTime>]
 [-Comment <String>] [-ComplianceState <String>] [-Evidence <IAttestationEvidence[]>] [-ExpiresOn <DateTime>]
 [-Metadata <String>] [-Owner <String>] [-PolicyAssignmentId <String>] [-PolicyDefinitionReferenceId <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByResourceGroup
```
Update-AzPolicyAttestation -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 [-AssessmentDate <DateTime>] [-Comment <String>] [-ComplianceState <String>]
 [-Evidence <IAttestationEvidence[]>] [-ExpiresOn <DateTime>] [-Metadata <String>] [-Owner <String>]
 [-PolicyAssignmentId <String>] [-PolicyDefinitionReferenceId <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByResourceId
```
Update-AzPolicyAttestation [-Name <String>] -ResourceId <String> [-AssessmentDate <DateTime>]
 [-Comment <String>] [-ComplianceState <String>] [-Evidence <IAttestationEvidence[]>] [-ExpiresOn <DateTime>]
 [-Metadata <String>] [-Owner <String>] [-PolicyAssignmentId <String>] [-PolicyDefinitionReferenceId <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByScope
```
Update-AzPolicyAttestation -Name <String> -Scope <String> [-AssessmentDate <DateTime>] [-Comment <String>]
 [-ComplianceState <String>] [-Evidence <IAttestationEvidence[]>] [-ExpiresOn <DateTime>] [-Metadata <String>]
 [-Owner <String>] [-PolicyAssignmentId <String>] [-PolicyDefinitionReferenceId <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzPolicyAttestation -InputObject <IPolicyInsightsIdentity> [-AssessmentDate <DateTime>]
 [-Comment <String>] [-ComplianceState <String>] [-Evidence <IAttestationEvidence[]>] [-ExpiresOn <DateTime>]
 [-Metadata <String>] [-Owner <String>] [-PolicyAssignmentId <String>] [-PolicyDefinitionReferenceId <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzPolicyAttestation** cmdlet modifies a policy attestation.

\>**Note:**
\>An existing policy attestation's `policyAssignmentId` or `policyDefinitionReferenceId` cannot be modified.

## EXAMPLES

### Example 1: Update an attestation by name
```powershell
# Update the existing attestation by resource name at subscription scope (default)
$comment = "Setting the state to non compliant"
$attestationName = "Attestation-SubscriptionScope-Crud"
$policyAssignmentId = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/Microsoft.Authorization/policyAssignments/PSAttestationSubAssignment"
Update-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "NonCompliant" -Comment $comment
```

```output
AssessmentDate               :
Comment                      : Setting the state to non compliant
ComplianceState              : NonCompliant
Evidence                     :
ExpiresOn                    :
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.policyinsights/attestations/attestation-subscriptionscope-crud
LastComplianceStateChangeAt  : 3/27/2026 6:50:22 PM
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
SystemDataLastModifiedAt     : 3/27/2026 6:50:22 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

The command here sets the compliance state and adds a comment to an existing attestation with name 'Attestation-SubscriptionScope-Crud'.

### Example 2: Update an attestation by ResourceId
```powershell
# Get an attestation
$rgName = "ps-attestation-test-rg"
$attestationName = "Attestation-RGScope-Crud"
$attestation = Get-AzPolicyAttestation -ResourceGroupName $rgName -Name $attestationName

# Update the existing attestation by resource ID at RG scope
$expiresOn = [System.DateTime]::UtcNow.AddYears(1)
Update-AzPolicyAttestation -Id $attestation.Id -ExpiresOn $expiresOn
```

```output
AssessmentDate               :
Comment                      :
ComplianceState              : Compliant
Evidence                     :
ExpiresOn                    : 3/27/2027 6:54:11 PM
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourcegroups/ps-attestation-test-rg/providers/microsoft.policyinsights/attestations/attestation-rgscope-crud
LastComplianceStateChangeAt  : 3/26/2026 9:28:05 PM
Metadata                     : {
                               }
Name                         : attestation-rgscope-crud
Owner                        :
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationrgassignment
PolicyDefinitionReferenceId  :
ProvisioningState            : Succeeded
ResourceGroupName            : ps-attestation-test-rg
SystemDataCreatedAt          : 3/26/2026 9:28:05 PM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/27/2026 6:54:39 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

The first command gets an existing attestation at the resource group 'ps-attestation-test-rg' with the name 'attestation-rgscope-crud'.

The final command updates the expiry time of the policy attestation by the **ResourceId** property of the existing attestation.

### Example 3: Update an attestation by input object
```powershell
# Get an attestation
$attestationName = "Attestation-ResourceScope-Crud"
$scope = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourceGroups/ps-attestation-test-rg/providers/Microsoft.Network/networkSecurityGroups/pstests0"
$attestation = Get-AzPolicyAttestation -Name $attestationName -Scope $scope

# Update attestation by input object
$newOwner = "Test Owner 2"
$attestation | Update-AzPolicyAttestation -Owner $newOwner
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
Name                         : attestation-resourcescope-crud
Owner                        : Test Owner 2
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationresourceassignment
PolicyDefinitionReferenceId  :
ProvisioningState            : Succeeded
ResourceGroupName            : ps-attestation-test-rg
SystemDataCreatedAt          : 3/26/2026 9:28:50 PM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/27/2026 6:59:14 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

The first command gets an existing attestation with name 'attestation-resourcescope-crud' for the given resource using its resource id as the scope.

The final command updates the owner of the policy attestation by using piping.

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
The time the compliance state should expire.

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
Parameter Sets: UpdateViaIdentity
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
Parameter Sets: UpdateBySubscriptionId, UpdateByResourceGroup, UpdateByScope
Aliases: AttestationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: UpdateByResourceId
Aliases: AttestationName

Required: False
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

Required: False
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: UpdateByResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ID of the resource that the attestation was made against or the full Resource ID of the attestation.

```yaml
Type: System.String
Parameter Sets: UpdateByResourceId
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
Parameter Sets: UpdateByScope
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
Parameter Sets: UpdateBySubscriptionId, UpdateByResourceGroup
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

ALIASES

Set-AzPolicyAttestation

## RELATED LINKS
