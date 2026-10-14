---
external help file:
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/get-azpolicyremediation
schema: 2.0.0
---

# Get-AzPolicyRemediation

## SYNOPSIS
Gets policy remediations.

## SYNTAX

### ListBySubscriptionId (Default)
```
Get-AzPolicyRemediation [-SubscriptionId <String[]>] [-Filter <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByManagementGroup
```
Get-AzPolicyRemediation -ManagementGroupId <String> -Name <String> [-Top <Int32>] [-IncludeDetail]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByResourceGroup
```
Get-AzPolicyRemediation -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Top <Int32>]
 [-IncludeDetail] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByResourceId
```
Get-AzPolicyRemediation -Name <String> -ResourceId <String> [-Top <Int32>] [-IncludeDetail]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByScope
```
Get-AzPolicyRemediation -Name <String> -Scope <String> [-Top <Int32>] [-IncludeDetail]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetBySubscriptionId
```
Get-AzPolicyRemediation -Name <String> [-SubscriptionId <String[]>] [-Top <Int32>] [-IncludeDetail]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPolicyRemediation -InputObject <IPolicyInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListByManagementGroup
```
Get-AzPolicyRemediation -ManagementGroupId <String> [-Filter <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByResourceGroup
```
Get-AzPolicyRemediation -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Filter <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByResourceId
```
Get-AzPolicyRemediation -ResourceId <String> [-Filter <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListByScope
```
Get-AzPolicyRemediation -Scope <String> [-Filter <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyRemediation** cmdlet gets all policy remediations in a scope or a particular remediation.

## EXAMPLES

### Example 1: Get all policy remediations in the current subscription
```powershell
Get-AzPolicyRemediation
```

This command gets all the remediations created at or underneath the subscription in the current context.

### Example 2: Get a specific policy remediation and the deployment details
```powershell
Get-AzPolicyRemediation -ResourceGroupName "myResourceGroup" -Name "remediation1" -IncludeDetail
```

This command gets the remediation named 'remediation1' from resource group 'myResourceGroup'.
The details of the deployments created by the remediation will be included.

### Example 3: Get 10 policy remediations in a management group with optional filters
```powershell
Get-AzPolicyRemediation -ManagementGroupId "mg1" -Top 10 -Filter "PolicyAssignmentId eq '/providers/Microsoft.Management/managementGroups/mg1/providers/Microsoft.Authorization/policyAssignments/pa1'"
```

This command gets a max of 10 policy remediations from a management group named 'mg1'.
Only policy remediations for the given policy assignment will be retrieved.

## PARAMETERS

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

### -Filter
Filter expression using OData notation.

```yaml
Type: System.String
Parameter Sets: ListByManagementGroup, ListByResourceGroup, ListByResourceId, ListByScope, ListBySubscriptionId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeDetail
Include details of the deployments created by the remediation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetByManagementGroup, GetByResourceGroup, GetByResourceId, GetByScope, GetBySubscriptionId
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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementGroupId
Management group ID.

```yaml
Type: System.String
Parameter Sets: GetByManagementGroup, ListByManagementGroup
Aliases: ManagementGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the remediation.

```yaml
Type: System.String
Parameter Sets: GetByManagementGroup, GetByResourceGroup, GetByResourceId, GetByScope, GetBySubscriptionId
Aliases: RemediationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: GetByResourceGroup, ListByResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ID of the resource that the remediation or remediations were made against.

```yaml
Type: System.String
Parameter Sets: GetByResourceId, ListByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Scope of the remediations.
E.g.
'/subscriptions/\{subscriptionId}/resourceGroups/\{rgName}'.

```yaml
Type: System.String
Parameter Sets: GetByScope, ListByScope
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
Type: System.String[]
Parameter Sets: GetByResourceGroup, GetBySubscriptionId, ListByResourceGroup, ListBySubscriptionId
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Maximum number of records to return.
When IncludeDetail is specified, this parameter applies to the amount of deployments returned.

```yaml
Type: System.Int32
Parameter Sets: GetByManagementGroup, GetByResourceGroup, GetByResourceId, GetByScope, GetBySubscriptionId, ListByManagementGroup, ListByResourceGroup, ListByResourceId, ListByScope, ListBySubscriptionId
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

### Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IRemediation

## NOTES

## RELATED LINKS

