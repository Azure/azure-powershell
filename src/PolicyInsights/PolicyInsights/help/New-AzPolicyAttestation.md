---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.dll-Help.xml
Module Name: Az.PolicyInsights
online version:
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
 [-AssessmentDate <DateTime>] [-Metadata <Object>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByResourceId
```
New-AzPolicyAttestation -ResourceId <String> -PolicyAssignmentId <String> [-ComplianceState <String>]
 [-PolicyDefinitionReferenceId <String>] [-ExpiresOn <DateTime>] [-Owner <String>] [-Comment <String>]
 [-Evidence <PSAttestationEvidence[]>] [-AssessmentDate <DateTime>] [-Metadata <Object>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzPolicyAttestation** cmdlet creates a policy attestation for a particular policy assignment. Attestations are used by Azure Policy to set compliance states of resources or scopes targeted by manual policies. They also allow users to provide additional metadata or link to evidence which accompanies the attested compliance state.

## EXAMPLES

### Example 1: Create an attestation at subscription scope
```powershell
Set-AzContext -Subscription "My Subscription"
$policyAssignmentId = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/providers/Microsoft.Authorization/policyAssignments/0774f87b3af94c1399d3ee52"
$attestationName = "attestation-subscription"
New-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
```

This command creates a new policy attestation at subscription 'My Subscription' for the given policy assignment.

>**Note:**
>This command creates an attestation for the subscription and not the resources underneath it. For ease of management, manual policies should be designed to target the scope which defines the boundary of resources whose compliance state needs to be attested. In this case, the manual policy should be targeting `Microsoft.Resources/subscriptions`. For more information, go to https://learn.microsoft.com/en-us/azure/governance/policy/concepts/attestation-structure to understand the best practices for creating attestations.

### Example 2: Create an attestation at resource group
```powershell
$policyAssignmentId = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/providers/Microsoft.Authorization/policyAssignments/0774f87b3af94c1399d3ee52"
$attestationName = "attestation-RG"
$rgName = "myRG"
New-AzPolicyAttestation -ResourceGroupName $RGName -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
```

This command creates a new policy attestation at the resource group 'myRG' for the given policy assignment.

>**Note:**
>This command creates an attestation for the resource group and not the resources underneath it. For ease of management, manual policies should be designed to target the scope which defines the boundary of resources whose compliance state needs to be attested. In this case, the manual policy should be targeting `Microsoft.Resources/subscriptions/resourceGroups`. For more information, go to https://learn.microsoft.com/en-us/azure/governance/policy/concepts/attestation-structure to understand the best practices for creating attestations.

### Example 3: Create an attestation at resource
```powershell
$policyAssignmentId = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/providers/Microsoft.Authorization/policyAssignments/0774f87b3af94c1399d3ee52"
$attestationName = "attestation-resource"
$scope = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/resourceGroups/myRG/providers/Microsoft.Network/virtualNetworks/Test-VN"
New-AzPolicyAttestation `
    -PolicyAssignmentId $policyAssignmentId `
    -Name $attestationName `
    -Scope $scope `
    -ComplianceState "NonCompliant"
```

This command creates an attestation for the resource 'Test-VN' for the given policy assignment.

### Example 4: Create an attestation with all properties at resource group
```
$attestationName = "attestationRG"
$policyInitiativeAssignmentId = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/resourceGroups/myRG/providers/Microsoft.Authorization/policyAssignments/74067f0991764e9882a046e0"
$policyDefinitionReferenceId = "PS: Manual Policy (RG)_1"

$description = "This is a test description"
$sourceURI = "https://contoso.org/test.pdf"
$owner = "Test Owner"
$evidence = @{
    "Description"=$description 
    "SourceUri"=$sourceURI
}
$policyEvidence = @($evidence)
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
Type: System.Object
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
