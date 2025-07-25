---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/get-azeventgridpermissionbinding
schema: 2.0.0
---

# Get-AzEventGridPermissionBinding

## SYNOPSIS
Get properties of a permission binding.

## SYNTAX

### List (Default)
```
Get-AzEventGridPermissionBinding -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzEventGridPermissionBinding -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEventGridPermissionBinding -InputObject <IEventGridIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityNamespace
```
Get-AzEventGridPermissionBinding -Name <String> -NamespaceInputObject <IEventGridIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get properties of a permission binding.

## EXAMPLES

### Example 1: List properties of permission binding.
```powershell
Get-AzEventGridPermissionBinding -ResourceGroupName azps_test_group_eventgrid -NamespaceName azps-eventgridnamespace
```

```output
Name    ResourceGroupName
----    -----------------
azps-pb azps_test_group_eventgrid
```

List properties of permission binding.

### Example 2: Get properties of a permission binding.
```powershell
Get-AzEventGridPermissionBinding -ResourceGroupName azps_test_group_eventgrid -NamespaceName azps-eventgridnamespace -Name azps-pb
```

```output
Name    ResourceGroupName
----    -----------------
azps-pb azps_test_group_eventgrid
```

Get properties of a permission binding.

### Example 3: Get properties of a permission binding.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Get-AzEventGridPermissionBinding -NamespaceInputObject $namespace -Name azps-pb
```

```output
Name    ResourceGroupName
----    -----------------
azps-pb azps_test_group_eventgrid
```

Get properties of a permission binding.

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
The query used to filter the search results using OData syntax.
Filtering is permitted on the 'name' property only and with limited number of OData operations.
These operations are: the 'contains' function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal).
No arithmetic operations are supported.
The following is a valid filter example: $filter=contains(namE, 'PATTERN') and name ne 'PATTERN-1'.
The following is not a valid filter example: $filter=location eq 'westus'.

```yaml
Type: System.String
Parameter Sets: List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the permission binding.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityNamespace
Aliases: PermissionBindingName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: GetViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
Name of the namespace.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases: ResourceGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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
The number of results to return per page for the list operation.
Valid range for top parameter is 1 to 100.
If not specified, the default number of results to be returned is 20 items per page.

```yaml
Type: System.Int32
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IPermissionBinding

## NOTES

## RELATED LINKS

