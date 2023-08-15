---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.dll-Help.xml
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/get-azpolicyattestation
schema: 2.0.0
---

# Get-AzPolicyAttestation

## SYNOPSIS
Gets policy attestations.

## SYNTAX

### SubscriptionScope (Default)
```
Get-AzPolicyAttestation [-Top <Int32>] [-Filter <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByName
```
Get-AzPolicyAttestation -Name <String> [-Scope <String>] [-ResourceGroupName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GenericScope
```
Get-AzPolicyAttestation -Scope <String> [-Top <Int32>] [-Filter <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceGroupScope
```
Get-AzPolicyAttestation -ResourceGroupName <String> [-Top <Int32>] [-Filter <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzPolicyAttestation -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyAttestation** cmdlet gets all policy attestations in a scope or a particular attestation.

## EXAMPLES

### Example 1: Get all policy attestations in the current subscription
```powershell
Set-AzContext -Subscription "d1acb22b-c876-44f7-b08e-3fcf9f6767f4"
Get-AzPolicyAttestation
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

Id                          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/resourcegroups/ps-attestation-test-rg/providers/
                              microsoft.policyinsights/attestations/attestationrgallprops
Name                        : attestationRGAllProps
Type                        : Microsoft.PolicyInsights/attestations
PolicyAssignmentId          : /subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/policyassignme
                              nts/psattestationinitiativergassignment
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

This command gets all the attestations created at or underneath a subscription with id d1acb22b-c876-44f7-b08e-3fcf9f6767f4.

### Example 2: Get a specific policy attestation
```powershell
Get-AzPolicyAttestation -ResourceGroupName "ps-attestation-test-rg" -Name "attestation-RG"
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

This command gets the attestation named 'attestation-RG' at the resource group 'ps-attestation-test-rg'.

### Example 3: Get 5 policy attestations in a subscription with optional filters
```powershell
Set-AzContext -Subscription "d1acb22b-c876-44f7-b08e-3fcf9f6767f4"
Get-AzPolicyAttestation -Top 5 -Filter "PolicyAssignmentId eq '/subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/providers/microsoft.authorization/policyassignments/psattestationresourceassignment'"
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

This command gets a max of 5 policy attestations underneath the subscription with id d1acb22b-c876-44f7-b08e-3fcf9f6767f4. Only policy attestations for the given policy assignment will be retrieved.

## PARAMETERS

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

### -Filter
Filter expression using OData notation.

```yaml
Type: System.String
Parameter Sets: SubscriptionScope, GenericScope, ResourceGroupScope
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

```yaml
Type: System.String
Parameter Sets: ResourceGroupScope
Aliases:

Required: True
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

```yaml
Type: System.String
Parameter Sets: GenericScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Top
Maximum number of records to return.
If not provided, the maximum number of records returned is determined by the Azure Policy service (currently 1000).

```yaml
Type: System.Int32
Parameter Sets: SubscriptionScope, GenericScope, ResourceGroupScope
Aliases:

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

## OUTPUTS

### Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation

## NOTES

## RELATED LINKS
[New-AzPolicyAttestation](./New-AzPolicyAttestation.md)

[Remove-AzPolicyAttestation](./Remove-AzPolicyAttestation.md)