---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.dll-Help.xml
Module Name: Az.PolicyInsights
online version:
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
Set-AzContext -Subscription "MySubscription"
Get-AzPolicyAttestation
```

This command gets all the attestations created at or underneath a subscription named "My Subscription".

### Example 2: Get a specific policy attestation
```powershell
Get-AzPolicyAttestation -ResourceGroupName "myResourceGroup" -Name "attestation1"
```

This command gets the attestation named 'attestation1' at the resource group 'myResourceGroup'.

### Example 3: Get 5 policy attestations in a subscription with optional filters
```powershell
Set-AzContext -Subscription "MySubscription"
Get-PolicyAttestation -Top 5 -Filter "PolicyAssignmentId eq '/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/providers/Microsoft.Authorization/policyAssignments/0774f87b3af94c1399d3ee52"
```

This command gets a max of 5 policy attestations underneath the subscription named 'My Subscription'. Only policy attestations for the given policy assignment will be retrieved.

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
