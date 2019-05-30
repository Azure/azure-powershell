---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azdenyassignment
schema: 2.0.0
---

# Get-AzDenyAssignment

## SYNOPSIS
Get the specified deny assignment.

## SYNTAX

### Get1 (Default)
```
Get-AzDenyAssignment -Id <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDenyAssignment -Id <String> -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List3
```
Get-AzDenyAssignment -Scope <String> [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzDenyAssignment -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDenyAssignment -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDenyAssignment -ParentResourcePath <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String[]> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzDenyAssignment -ResourceGroupName <String> -SubscriptionId <String[]> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzDenyAssignment -SubscriptionId <String[]> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the specified deny assignment.

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
Use $filter=atScope() to return all deny assignments at or above the scope.
Use $filter=denyAssignmentName eq '{name}' to search deny assignments by name at specified scope.
Use $filter=principalId eq '{id}' to return all deny assignments at, above and below the scope for the specified principal.
Use $filter=gdprExportPrincipalId eq '{id}' to return all deny assignments at, above and below the scope for the specified principal.
This filter is different from the principalId filter as it returns not only those deny assignments that contain the specified principal is the Principals list but also those deny assignments that contain the specified principal is the ExcludePrincipals list.
Additionally, when gdprExportPrincipalId filter is used, only the deny assignment name and description properties are returned.

```yaml
Type: System.String
Parameter Sets: List3, List, List1, List2
Aliases: ODataQuery

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
The fully qualified deny assignment ID.
For example, use the format, /subscriptions/{guid}/providers/Microsoft.Authorization/denyAssignments/{denyAssignmentId} for subscription level deny assignments, or /providers/Microsoft.Authorization/denyAssignments/{denyAssignmentId} for tenant level deny assignments.

```yaml
Type: System.String
Parameter Sets: Get1, Get
Aliases: DenyAssignmentId

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
Parameter Sets: GetViaIdentity1, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ParentResourcePath
The parent resource identity.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

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
Parameter Sets: List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceName
The name of the resource to get deny assignments for.

```yaml
Type: System.String
Parameter Sets: List
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
Parameter Sets: List
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
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Scope
The scope of the deny assignments.

```yaml
Type: System.String
Parameter Sets: Get, List3
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
Parameter Sets: List, List1, List2
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180701Preview.IDenyAssignment

## ALIASES

## RELATED LINKS

