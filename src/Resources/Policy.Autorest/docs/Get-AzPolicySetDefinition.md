---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azpolicysetdefinition
schema: 2.0.0
---

# Get-AzPolicySetDefinition

## SYNOPSIS
This operation retrieves the policy set definition in the given subscription with the given name.

## SYNTAX

### List (Default)
```
Get-AzPolicySetDefinition [-SubscriptionId <String[]>] [-Filter <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPolicySetDefinition -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get1
```
Get-AzPolicySetDefinition -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPolicySetDefinition -InputObject <IPolicyIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzPolicySetDefinition -InputObject <IPolicyIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzPolicySetDefinition [-Filter <String>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
This operation retrieves the policy set definition in the given subscription with the given name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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
The filter to apply on the operation.
Valid values for $filter are: 'atExactScope()', 'policyType -eq {value}' or 'category eq '{value}''.
If $filter is not provided, no filtering is performed.
If $filter=atExactScope() is provided, the returned list only includes all policy set definitions that at the given scope.
If $filter='policyType -eq {value}' is provided, the returned list only includes all policy set definitions whose type match the {value}.
Possible policyType values are NotSpecified, BuiltIn, Custom, and Static.
If $filter='category -eq {value}' is provided, the returned list only includes all policy set definitions whose category match the {value}.

```yaml
Type: System.String
Parameter Sets: List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyIdentity
Parameter Sets: GetViaIdentity, GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the policy set definition to get.

```yaml
Type: System.String
Parameter Sets: Get, Get1
Aliases: PolicySetDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Maximum number of records to return.
When the $top filter is not provided, it will return 500 records.

```yaml
Type: System.Int32
Parameter Sets: List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Api20210601.IPolicySetDefinition

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IPolicyIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ManagementGroupId <String>]`: The ID of the management group.
  - `[ParentResourcePath <String>]`: The parent resource path. Use empty string if there is none.
  - `[PolicyAssignmentId <String>]`: The ID of the policy assignment to delete. Use the format '{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.
  - `[PolicyAssignmentName <String>]`: The name of the policy assignment to delete.
  - `[PolicyDefinitionName <String>]`: The name of the policy definition to create.
  - `[PolicyExemptionName <String>]`: The name of the policy exemption to delete.
  - `[PolicySetDefinitionName <String>]`: The name of the policy set definition to create.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains policy assignments.
  - `[ResourceName <String>]`: The name of the resource.
  - `[ResourceProviderNamespace <String>]`: The namespace of the resource provider. For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines)
  - `[ResourceType <String>]`: The resource type name. For example the type name of a web app is 'sites' (from Microsoft.Web/sites).
  - `[Scope <String>]`: The scope of the policy assignment. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

