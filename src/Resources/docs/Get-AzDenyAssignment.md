---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azdenyassignment
schema: 2.0.0
---

# Get-AzDenyAssignment

## SYNOPSIS
Get the specified deny assignment.

## SYNTAX

### ListSubscriptionIdViaHost2 (Default)
```
Get-AzDenyAssignment [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
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

### ListSubscriptionIdViaHost
```
Get-AzDenyAssignment -ParentResourcePath <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzDenyAssignment -ParentResourcePath <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> -SubscriptionId <String> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListSubscriptionIdViaHost1
```
Get-AzDenyAssignment -ResourceGroupName <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzDenyAssignment -ResourceGroupName <String> -SubscriptionId <String> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzDenyAssignment -SubscriptionId <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the specified deny assignment.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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
Parameter Sets: ListSubscriptionIdViaHost2, List3, ListSubscriptionIdViaHost, List, ListSubscriptionIdViaHost1, List1, List2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The ID of the deny assignment to get.

```yaml
Type: System.String
Parameter Sets: Get1, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentResourcePath
The parent resource identity.

```yaml
Type: System.String
Parameter Sets: ListSubscriptionIdViaHost, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: ListSubscriptionIdViaHost, List, ListSubscriptionIdViaHost1, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the resource to get deny assignments for.

```yaml
Type: System.String
Parameter Sets: ListSubscriptionIdViaHost, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceProviderNamespace
The namespace of the resource provider.

```yaml
Type: System.String
Parameter Sets: ListSubscriptionIdViaHost, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The resource type of the resource.

```yaml
Type: System.String
Parameter Sets: ListSubscriptionIdViaHost, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the deny assignment.

```yaml
Type: System.String
Parameter Sets: Get, List3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: List, List1, List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180701Preview.IDenyAssignment
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azdenyassignment](https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azdenyassignment)

