---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.dll-Help.xml
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/set-azpolicyattestation
schema: 2.0.0
---

# Set-AzPolicyAttestation

## SYNOPSIS
Modifies a policy attestation.

## SYNTAX

### ByName (Default)
```
Set-AzPolicyAttestation -Name <String> [-Scope <String>] [-ResourceGroupName <String>]
 [-PolicyAssignmentId <String>] [-ComplianceState <String>] [-PolicyDefinitionReferenceId <String>]
 [-ExpiresOn <DateTime>] [-Owner <String>] [-Comment <String>] [-Evidence <PSAttestationEvidence[]>]
 [-AssessmentDate <DateTime>] [-Metadata <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByResourceId
```
Set-AzPolicyAttestation -ResourceId <String> [-PolicyAssignmentId <String>] [-ComplianceState <String>]
 [-PolicyDefinitionReferenceId <String>] [-ExpiresOn <DateTime>] [-Owner <String>] [-Comment <String>]
 [-Evidence <PSAttestationEvidence[]>] [-AssessmentDate <DateTime>] [-Metadata <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInputObject
```
Set-AzPolicyAttestation -InputObject <PSAttestation> [-PolicyAssignmentId <String>] [-ComplianceState <String>]
 [-PolicyDefinitionReferenceId <String>] [-ExpiresOn <DateTime>] [-Owner <String>] [-Comment <String>]
 [-Evidence <PSAttestationEvidence[]>] [-AssessmentDate <DateTime>] [-Metadata <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzPolicyAttestation** cmdlet modifies a policy attestation. Specify an attestation by Id or by Name and scope, or via piping.

>**Note:**
>An existing policy attestation's `policyAssignmentId` or `policyDefinitionReferenceId` cannot be modified.

## EXAMPLES

### Example 1: Update an attestation by name
```powershell
Set-AzContext -Subscription "d1acb22b-c876-44f7-b08e-3fcf9f6767f4"
# Update the existing attestation by resource name at subscription scope (default)
$comment = "Setting the state to non compliant"
$attestationName = "attestation-subscription"
$policyAssignmentId = "/subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/Microsoft.Authorization/policyAssignments/PSAttestationSubAssignment"
Set-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "NonCompliant" -Comment $comment
```

```output
Id                          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.policyinsights/attestations/
                              attestation-subscription
Name                        : attestation-subscription
Type                        : Microsoft.PolicyInsights/attestations
PolicyAssignmentId          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/policyassignme
                              nts/psattestationsubassignment
PolicyDefinitionReferenceId :
ComplianceState             : NonCompliant
ExpiresOn                   :
Owner                       :
Comment                     : Setting the state to non compliant
Evidence                    :
ProvisioningState           : Succeeded
LastComplianceStateChangeAt : 1/27/2023 4:00:04 PM
AssessmentDate              :
Metadata                    :
SystemData                  :
```

The command here sets the compliance state and adds a comment to an existing attestation with name 'attestation-subscription' in the subscription with id 'd1acb22b-c876-44f7-b08e-3fcf9f6767f4'

### Example 2: Update an attestation by ResourceId
```powershell
# Get an attestation
$rgName = "ps-attestation-test-rg"
$attestationName = "attestation-RG"
$attestation = Get-AzPolicyAttestation -ResourceGroupName $rgName -Name $attestationName

# Update the existing attestation by resource ID at RG
$expiresOn = [System.DateTime]::UtcNow.AddYears(1)
Set-AzPolicyAttestation -Id $attestation.Id -ExpiresOn $expiresOn
```

```output
Id                          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/resourcegroups/ps-attestation-test-rg/providers/
                              microsoft.policyinsights/attestations/attestation-rg
Name                        : attestation-rg
Type                        : Microsoft.PolicyInsights/attestations
PolicyAssignmentId          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/policyassignme
                              nts/psattestationrgassignment
PolicyDefinitionReferenceId :
ComplianceState             :
ExpiresOn                   : 1/27/2024 4:04:24 PM
Owner                       :
Comment                     :
Evidence                    :
ProvisioningState           : Succeeded
LastComplianceStateChangeAt : 1/27/2023 4:04:11 PM
AssessmentDate              :
Metadata                    :
SystemData                  :
```

The first command gets an existing attestation at the resource group 'ps-attestation-test-rg' with the name 'attestation-RG'.

The final command updates the expiry time of the policy attestation by the **ResourceId** property of the existing attestation.

### Example 3: Update an attestation by input object
```powershell
# Get an attestation
$attestationName = "attestation-resource"
$scope = "/subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/resourceGroups/ps-attestation-test-rg/providers/Microsoft.Network/networkSecurityGroups/pstests0"
$attestation = Get-AzPolicyAttestation -Name $attestationName -Scope $scope

# Update attestation by input object
$newOwner = "Test Owner 2"
$attestation | Set-AzPolicyAttestation -Owner $newOwner
```

```output
Id                          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/resourcegroups/ps-attestation-test-rg/providers/
                              microsoft.network/networksecuritygroups/pstests0/providers/microsoft.policyinsights/attestations/att
                              estation-resource
Name                        : attestation-resource
Type                        : Microsoft.PolicyInsights/attestations
PolicyAssignmentId          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/policyassignme
                              nts/psattestationresourceassignment
PolicyDefinitionReferenceId :
ComplianceState             : NonCompliant
ExpiresOn                   :
Owner                       : Test Owner 2
Comment                     :
Evidence                    :
ProvisioningState           : Succeeded
LastComplianceStateChangeAt : 1/27/2023 2:38:17 AM
AssessmentDate              :
Metadata                    :
SystemData                  :
```

The first command gets an existing attestation with name 'attestation-resource' for the given resource using its resource id as the scope

The final command updates the owner of the policy attestation by using piping.

## PARAMETERS

### -AssessmentDate
The time the evidence of an attestation was assessed.

```yaml
Type: System.Nullable`1[System.DateTime]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Evidence
The evidence supporting the compliance state set in this attestation.

```yaml
Type: Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestationEvidence[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExpiresOn
The time the compliance state set in the attestation should expire.

```yaml
Type: System.Nullable`1[System.DateTime]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
The Attestation object.

```yaml
Type: Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Metadata
Additional metadata for the attestation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Resource name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Owner
The person responsible for setting the state of the resource.
This value is typically an Azure Active Directory object ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PolicyAssignmentId
Policy assignment ID.
E.g.
'/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{assignmentName}'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PolicyDefinitionReferenceId
The policy definition reference ID of the individual definition.
Required when the policy assignment assigns a policy set definition.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Resource ID.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
Scope of the resource.
E.g.
'/subscriptions/{subscriptionId}/resourceGroups/{rgName}'.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: False
Position: Named
Default value: None
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

### System.String

### Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation

### System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestationEvidence[]

### System.Object

## OUTPUTS

### Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation

## NOTES

## RELATED LINKS
[New-AzPolicyAttestation](./New-AzPolicyAttestation.md)

[Remove-AzPolicyAttestation](./Remove-AzPolicyAttestation.md)

[Get-AzPolicyAttestation](./Get-AzPolicyAttestation.md)