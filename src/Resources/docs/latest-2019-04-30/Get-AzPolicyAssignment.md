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

### GetViaIdentity
```
Get-AzPolicyAssignment -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzPolicyAssignment -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzPolicyAssignment -ParentResourcePath <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String[]> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzPolicyAssignment -ResourceGroupName <String> -SubscriptionId <String[]> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzPolicyAssignment -ParentResourcePath <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String[]> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List3
```
Get-AzPolicyAssignment -SubscriptionId <String[]> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListByPolicyDefinition
```
Get-AzPolicyAssignment -SubscriptionId <String[]> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String>
 -PolicyDefinitionId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByPolicyDefinition1
```
Get-AzPolicyAssignment -SubscriptionId <String[]> -ResourceGroupName <String> -PolicyDefinitionId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByPolicyDefinition2
```
Get-AzPolicyAssignment -SubscriptionId <String[]> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String>
 -PolicyDefinitionId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByPolicyDefinition3
```
Get-AzPolicyAssignment -SubscriptionId <String[]> -PolicyDefinitionId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListWithDescendents
```
Get-AzPolicyAssignment -SubscriptionId <String[]> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String> -IncludeDescendent
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListWithDescendents1
```
Get-AzPolicyAssignment -SubscriptionId <String[]> -ResourceGroupName <String> -IncludeDescendent
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListWithDescendents2
```
Get-AzPolicyAssignment -SubscriptionId <String[]> -ParentResourcePath <String> -ResourceGroupName <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String> -IncludeDescendent
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListWithDescendents3
```
Get-AzPolicyAssignment -SubscriptionId <String[]> -IncludeDescendent [-DefaultProfile <PSObject>]
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

```yaml
Type: System.String
Parameter Sets: List, List1, List2, List3
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
Parameter Sets: ListWithDescendents, ListWithDescendents1, ListWithDescendents2, ListWithDescendents3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: GetViaIdentity, GetViaIdentity1
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

```yaml
Type: System.String
Parameter Sets: List, List2, ListByPolicyDefinition, ListByPolicyDefinition2, ListWithDescendents, ListWithDescendents2
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
Parameter Sets: ListByPolicyDefinition, ListByPolicyDefinition1, ListByPolicyDefinition2, ListByPolicyDefinition3
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
Parameter Sets: List, List1, List2, ListByPolicyDefinition, ListByPolicyDefinition1, ListByPolicyDefinition2, ListWithDescendents, ListWithDescendents1, ListWithDescendents2
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
Parameter Sets: List, List2, ListByPolicyDefinition, ListByPolicyDefinition2, ListWithDescendents, ListWithDescendents2
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
Parameter Sets: List, List2, ListByPolicyDefinition, ListByPolicyDefinition2, ListWithDescendents, ListWithDescendents2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceType
The resource type.

```yaml
Type: System.String
Parameter Sets: List, List2, ListByPolicyDefinition, ListByPolicyDefinition2, ListWithDescendents, ListWithDescendents2
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
Parameter Sets: List, List1, List2, List3, ListByPolicyDefinition, ListByPolicyDefinition1, ListByPolicyDefinition2, ListByPolicyDefinition3, ListWithDescendents, ListWithDescendents1, ListWithDescendents2, ListWithDescendents3
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20151101.IPolicyAssignment

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyAssignment

## ALIASES

## NOTES

## RELATED LINKS

