---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/get-azeventgridsubscriptionglobal
schema: 2.0.0
---

# Get-AzEventGridSubscriptionGlobal

## SYNOPSIS
List all aggregated global event subscriptions under a specific Azure subscription.

## SYNTAX

### List (Default)
```
Get-AzEventGridSubscriptionGlobal [-SubscriptionId <String[]>] [-Filter <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### List1
```
Get-AzEventGridSubscriptionGlobal -TopicTypeName <String> [-SubscriptionId <String[]>] [-Filter <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### List2
```
Get-AzEventGridSubscriptionGlobal -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Filter <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### List3
```
Get-AzEventGridSubscriptionGlobal -ResourceGroupName <String> -TopicTypeName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-Top <Int32>] [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
List all aggregated global event subscriptions under a specific Azure subscription.

## EXAMPLES

### Example 1: List all aggregated global event subscriptions under a specific Azure subscription.
```powershell
Get-AzEventGridSubscriptionGlobal -ResourceGroupName azps_test_group_eventgrid
```

```output
Value
-----
......
```

List all aggregated global event subscriptions under a specific Azure subscription.

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: List2, List3
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicTypeName
Name of the topic type.

```yaml
Type: System.String
Parameter Sets: List1, List3
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscription

## NOTES

## RELATED LINKS

