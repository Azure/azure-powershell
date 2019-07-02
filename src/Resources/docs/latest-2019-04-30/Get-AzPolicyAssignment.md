---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azpolicyassignment
schema: 2.0.0
---

# Get-AzPolicyAssignment

## SYNOPSIS
This operation retrieves a single policy assignment, given its name and the scope it was created at.

## SYNTAX

### Get1 (Default)
```
Get-AzPolicyAssignment -Id <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPolicyAssignment -Name <String> -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzPolicyAssignment -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPolicyAssignment -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByPolicyDefinition
```
Get-AzPolicyAssignment -ParentResourcePath <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String[]>
 -PolicyDefinitionId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByPolicyDefinition2
```
Get-AzPolicyAssignment -ParentResourcePath <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String[]>
 -PolicyDefinitionId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListWithDescendents
```
Get-AzPolicyAssignment -ParentResourcePath <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String[]> -IncludeDescendent
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListWithDescendents2
```
Get-AzPolicyAssignment -ParentResourcePath <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String[]> -IncludeDescendent
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzPolicyAssignment -ParentResourcePath <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String[]> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzPolicyAssignment -ParentResourcePath <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String[]> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByPolicyDefinition1
```
Get-AzPolicyAssignment -ResourceGroupName <String> -SubscriptionId <String[]> -PolicyDefinitionId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListWithDescendents1
```
Get-AzPolicyAssignment -ResourceGroupName <String> -SubscriptionId <String[]> -IncludeDescendent
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzPolicyAssignment -ResourceGroupName <String> -SubscriptionId <String[]> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByPolicyDefinition3
```
Get-AzPolicyAssignment -SubscriptionId <String[]> -PolicyDefinitionId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListWithDescendents3
```
Get-AzPolicyAssignment -SubscriptionId <String[]> -IncludeDescendent [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List3
```
Get-AzPolicyAssignment -SubscriptionId <String[]> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
This operation retrieves a single policy assignment, given its name and the scope it was created at.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Filter
The filter to apply on the operation.
Valid values for $filter are: 'atScope()' or 'policyDefinitionId eq '{value}''.
If $filter is not provided, no filtering is performed.

```yaml
Type: System.String
Parameter Sets: List2, List, List1, List3
Aliases: ODataQuery

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
The ID of the policy assignment to get.
Use the format '{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.

```yaml
Type: System.String
Parameter Sets: Get1
Aliases: PolicyAssignmentId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IncludeDescendent
Indicates that the list of returned policy assignments should include all assignments related to the given scope, including those from ancestor scopes and those from descendent scopes.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListWithDescendents, ListWithDescendents2, ListWithDescendents1, ListWithDescendents3
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: GetViaIdentity1, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the policy assignment to get.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PolicyAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ParentResourcePath
The parent resource path.
Use empty string if there is none.

```yaml
Type: System.String
Parameter Sets: ListByPolicyDefinition, ListByPolicyDefinition2, ListWithDescendents, ListWithDescendents2, List2, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PolicyDefinitionId
Limits the list of returned policy assignments to those assigning the policy definition identified by this fully qualified ID.

```yaml
Type: System.String
Parameter Sets: ListByPolicyDefinition, ListByPolicyDefinition2, ListByPolicyDefinition1, ListByPolicyDefinition3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group containing the resource.

```yaml
Type: System.String
Parameter Sets: ListByPolicyDefinition, ListByPolicyDefinition2, ListWithDescendents, ListWithDescendents2, List2, List, ListByPolicyDefinition1, ListWithDescendents1, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceName
The name of the resource.

```yaml
Type: System.String
Parameter Sets: ListByPolicyDefinition, ListByPolicyDefinition2, ListWithDescendents, ListWithDescendents2, List2, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceProviderNamespace
The namespace of the resource provider.
For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines)

```yaml
Type: System.String
Parameter Sets: ListByPolicyDefinition, ListByPolicyDefinition2, ListWithDescendents, ListWithDescendents2, List2, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceType
The resource type name.
For example the type name of a web app is 'sites' (from Microsoft.Web/sites).

```yaml
Type: System.String
Parameter Sets: ListByPolicyDefinition, ListByPolicyDefinition2, ListWithDescendents, ListWithDescendents2, List2, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Scope
The scope of the policy assignment.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: ListByPolicyDefinition, ListByPolicyDefinition2, ListWithDescendents, ListWithDescendents2, List2, List, ListByPolicyDefinition1, ListWithDescendents1, List1, ListByPolicyDefinition3, ListWithDescendents3, List3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyAssignment

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20151101.IPolicyAssignment

## ALIASES

## RELATED LINKS

