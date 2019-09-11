---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azroleassignment
schema: 2.0.0
---

# Get-AzRoleAssignment

## SYNOPSIS
Gets a role assignment by ID.

## SYNTAX

### GetRoleAssignment1 (Default)
```
Get-AzRoleAssignment [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetRoleAssignment2
```
Get-AzRoleAssignment -Name <String> -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetRoleAssignment3
```
Get-AzRoleAssignment -RoleId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListRoleAssignment4
```
Get-AzRoleAssignment -ParentResourceId <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> [-SubscriptionId <String[]>] [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListRoleAssignment5
```
Get-AzRoleAssignment -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListRoleAssignment6
```
Get-AzRoleAssignment [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListRoleAssignment7
```
Get-AzRoleAssignment -Scope <String> [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a role assignment by ID.

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
Use $filter=atScope() to return all role assignments at or above the scope.
Use $filter=principalId eq {id} to return all role assignments at, above or below the scope for the specified principal.

```yaml
Type: System.String
Parameter Sets: ListRoleAssignment4, ListRoleAssignment5, ListRoleAssignment6, ListRoleAssignment7
Aliases: ODataQuery

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the role assignment to get.

```yaml
Type: System.String
Parameter Sets: GetRoleAssignment2
Aliases: RoleAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ParentResourceId
The parent resource identity.

```yaml
Type: System.String
Parameter Sets: ListRoleAssignment4
Aliases: ParentResourcePath

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: ListRoleAssignment4, ListRoleAssignment5
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceName
The name of the resource to get role assignments for.

```yaml
Type: System.String
Parameter Sets: ListRoleAssignment4
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

```yaml
Type: System.String
Parameter Sets: ListRoleAssignment4
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceType
The resource type of the resource.

```yaml
Type: System.String
Parameter Sets: ListRoleAssignment4
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RoleId
The ID of the role assignment to get.

```yaml
Type: System.String
Parameter Sets: GetRoleAssignment3
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Scope
The scope of the role assignment.

```yaml
Type: System.String
Parameter Sets: GetRoleAssignment2, ListRoleAssignment7
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
Parameter Sets: ListRoleAssignment4, ListRoleAssignment5, ListRoleAssignment6
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180901Preview.IRoleAssignment

## ALIASES

## NOTES

## RELATED LINKS

