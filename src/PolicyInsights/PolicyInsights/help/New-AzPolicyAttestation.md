---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.dll-Help.xml
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/new-azpolicyattestation
schema: 2.0.0
---

# New-AzPolicyAttestation

## SYNOPSIS
Creates a new policy attestation for a policy assignment.

## SYNTAX

### ByName (Default)
```
New-AzPolicyAttestation -Name <String> [-Scope <String>] [-ResourceGroupName <String>]
 -PolicyAssignmentId <String> [-ComplianceState <String>] [-PolicyDefinitionReferenceId <String>]
 [-ExpiresOn <DateTime>] [-Owner <String>] [-Comment <String>] [-Evidence <PSAttestationEvidence[]>]
 [-AssessmentDate <DateTime>] [-Metadata <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByResourceId
```
New-AzPolicyAttestation -ResourceId <String> -PolicyAssignmentId <String> [-ComplianceState <String>]
 [-PolicyDefinitionReferenceId <String>] [-ExpiresOn <DateTime>] [-Owner <String>] [-Comment <String>]
 [-Evidence <PSAttestationEvidence[]>] [-AssessmentDate <DateTime>] [-Metadata <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzPolicyAttestation** cmdlet creates a policy attestation for a particular policy assignment. Attestations are used by Azure Policy to set compliance states of resources or scopes targeted by manual policies. They also allow users to provide additional metadata or link to evidence which accompanies the attested compliance state.

## EXAMPLES

### Example 1: Create an attestation at subscription scope
```powershell
Set-AzContext -Subscription "d1acb22b-c876-44f7-b08e-3fcf9f6767f4"
$policyAssignmentId = "/subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/policyassignments/psattestationsubassignment"
$attestationName = "attestation-subscription"
New-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
```

```output
Id                          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.policyinsights
                              /attestations/attestation-subscription
Name                        : attestation-subscription
Type                        : Microsoft.PolicyInsights/attestations
PolicyAssignmentId          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/
                              policyassignments/psattestationsubassignment
PolicyDefinitionReferenceId :
ComplianceState             : Compliant
ExpiresOn                   :
Owner                       :
Comment                     :
Evidence                    :
ProvisioningState           : Succeeded
LastComplianceStateChangeAt : 1/27/2023 2:26:24 AM
AssessmentDate              :
Metadata                    :
SystemData                  :
```

This command creates a new policy attestation at subscription 'd1acb22b-c876-44f7-b08e-3fcf9f6767f4' for the given policy assignment.

>**Note:**
>This command creates an attestation for the subscription and not the resources underneath it. For ease of management, manual policies should be designed to target the scope which defines the boundary of resources whose compliance state needs to be attested. In this case, the manual policy should be targeting `Microsoft.Resources/subscriptions`. For more information, go to https://learn.microsoft.com/en-us/azure/governance/policy/concepts/attestation-structure to understand the best practices for creating attestations.

### Example 2: Create an attestation at resource group
```powershell
$policyAssignmentId = "/subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/policyassignments/psattestationrgassignment"
$attestationName = "attestation-RG"
$rgName = "ps-attestation-test-rg"
New-AzPolicyAttestation -ResourceGroupName $RGName -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
```

```output
Id                          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/resourcegroups/ps-attestation-test
                              -rg/providers/microsoft.policyinsights/attestations/attestation-rg
Name                        : attestation-RG
Type                        : Microsoft.PolicyInsights/attestations
PolicyAssignmentId          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/
                              policyassignments/psattestationrgassignment
PolicyDefinitionReferenceId :
ComplianceState             : Compliant
ExpiresOn                   :
Owner                       :
Comment                     :
Evidence                    :
ProvisioningState           : Succeeded
LastComplianceStateChangeAt : 1/27/2023 2:35:28 AM
AssessmentDate              :
Metadata                    :
SystemData                  :
```

This command creates a new policy attestation at the resource group 'ps-attestation-test-rg' for the given policy assignment.

>**Note:**
>This command creates an attestation for the resource group and not the resources underneath it. For ease of management, manual policies should be designed to target the scope which defines the boundary of resources whose compliance state needs to be attested. In this case, the manual policy should be targeting `Microsoft.Resources/subscriptions/resourceGroups`. For more information, go to https://learn.microsoft.com/en-us/azure/governance/policy/concepts/attestation-structure to understand the best practices for creating attestations.

### Example 3: Create an attestation at resource
```powershell
$policyAssignmentId = "/subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/policyassignments/psattestationresourceassignment"
$attestationName = "attestation-resource"
$scope = "/subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/resourceGroups/ps-attestation-test-rg/providers/Microsoft.Network/networkSecurityGroups/pstests0"
New-AzPolicyAttestation `
    -PolicyAssignmentId $policyAssignmentId `
    -Name $attestationName `
    -Scope $scope `
    -ComplianceState "NonCompliant"
```

```output
Id                          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/resourcegroups/ps-attestation-test
                              -rg/providers/microsoft.network/networksecuritygroups/pstests0/providers/microsoft.pol
                              icyinsights/attestations/attestation-resource
Name                        : attestation-resource
Type                        : Microsoft.PolicyInsights/attestations
PolicyAssignmentId          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/
                              policyassignments/psattestationresourceassignment
PolicyDefinitionReferenceId :
ComplianceState             : NonCompliant
ExpiresOn                   :
Owner                       :
Comment                     :
Evidence                    :
ProvisioningState           : Succeeded
LastComplianceStateChangeAt : 1/27/2023 2:38:17 AM
AssessmentDate              :
Metadata                    :
SystemData                  :
```

This command creates an attestation for the resource 'pstests0' for the given policy assignment.

### Example 4: Create an attestation with all properties at resource group
```powershell
$attestationName = "attestationRGAllProps"
$policyInitiativeAssignmentId = "/subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/policyassignments/psattestationinitiativergassignment"

$policyDefinitionReferenceId = "PSTestAttestationRG_1"
$RGName = "ps-attestation-test-rg"
$description = "This is a test description"
$sourceURI = "https://contoso.org/test.pdf"
$evidence = @{
    "Description"=$description
    "SourceUri"=$sourceURI
}
$policyEvidence = @($evidence)
$owner = "Test Owner"
$expiresOn = [datetime]::UtcNow.AddYears(1)
$metadata = '{"TestKey":"TestValue"}'

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
Id                          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/resourcegroups/ps-attestation-test
                              -rg/providers/microsoft.policyinsights/attestations/attestationrgallprops
Name                        : attestationRGAllProps
Type                        : Microsoft.PolicyInsights/attestations
PolicyAssignmentId          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/
                              policyassignments/psattestationinitiativergassignment
PolicyDefinitionReferenceId : pstestattestationrg_1
ComplianceState             :
ExpiresOn                   : 1/27/2024 2:51:54 AM
Owner                       : Test Owner
Comment                     :
Evidence                    : {Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestationEvidence}
ProvisioningState           : Succeeded
LastComplianceStateChangeAt : 1/27/2023 2:51:57 AM
AssessmentDate              : 1/25/2024 2:51:54 AM
Metadata                    : {
                                "TestKey": "TestValue"
                              }
SystemData                  :
```

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

Required: True
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
Accept pipeline input: True (ByPropertyName)
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

### System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestationEvidence[]

### System.Object

## OUTPUTS

### Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation

## NOTES

## RELATED LINKS
[Get-AzPolicyAttestation](./Get-AzPolicyAttestation.md)

[Set-AzPolicyAttestation](./Set-AzPolicyAttestation.md)

[Remove-AzPolicyAttestation](./Remove-AzPolicyAttestation.md)