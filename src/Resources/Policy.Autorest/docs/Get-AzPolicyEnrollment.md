---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azpolicyenrollment
schema: 2.0.0
---

# Get-AzPolicyEnrollment

## SYNOPSIS
Gets policy enrollments.

## SYNTAX

### ListBySubscriptionId (Default)
```
Get-AzPolicyEnrollment [-IncludeDescendent] [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetById
```
Get-AzPolicyEnrollment -Id <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByName
```
Get-AzPolicyEnrollment -Name <String> -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByManagementGroupId
```
Get-AzPolicyEnrollment -ManagementGroupId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByResourceGroupName
```
Get-AzPolicyEnrollment -ResourceGroupName <String> [-IncludeDescendent] [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByScope
```
Get-AzPolicyEnrollment -Scope <String> [-IncludeDescendent] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyEnrollment** cmdlet gets a collection of policy enrollments or a specific policy enrollment identified by name or ID.

## EXAMPLES

### Example 1: Get all policy enrollments
```powershell
Get-AzPolicyEnrollment
```

This command gets all the policy enrollments in the current subscription.
If you need to list all enrollments related to the given scope, including those from ancestor scopes and those from descendant scopes, pass the `-IncludeDescendent` parameter.

### Example 2: Get a specific policy enrollment by name and scope
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
Get-AzPolicyEnrollment -Name 'PolicyEnrollment07' -Scope $ResourceGroup.ResourceId
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy enrollment named PolicyEnrollment07 for the scope that the **ResourceId** property of $ResourceGroup identifies.

### Example 3: Get all policy enrollments at management group scope
```powershell
$ManagementGroup = Get-AzManagementGroup -GroupName 'AManagementGroup'
Get-AzPolicyEnrollment -ManagementGroupId $ManagementGroup.Name
```

The first command gets a management group named AManagementGroup by using the Get-AzManagementGroup cmdlet and stores it in the $ManagementGroup variable.
The second command gets all policy enrollments at the management group scope identified by the **Name** property of $ManagementGroup.

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

### -Id
The fully qualified resource Id of the policy enrollment.

```yaml
Type: System.String
Parameter Sets: GetById
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IncludeDescendent
Causes the list of returned policy enrollments to include all policy enrollments related to the given scope, including those from ancestor scopes and those from descendent scopes.
If not provided, only policy enrollments at and above the given scope are included.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListByResourceGroupName, ListByScope, ListBySubscriptionId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ManagementGroupId
The management group ID.

```yaml
Type: System.String
Parameter Sets: ListByManagementGroupId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the policy enrollment.

```yaml
Type: System.String
Parameter Sets: GetByName
Aliases: PolicyEnrollmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: ListByResourceGroupName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
The scope of the policy enrollment.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}'), or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}')

```yaml
Type: System.String
Parameter Sets: GetByName, ListByScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: ListByResourceGroupName, ListBySubscriptionId
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Management.Automation.SwitchParameter

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollment

## NOTES

## RELATED LINKS

