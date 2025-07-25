---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/get-azeventgridextensiontopic
schema: 2.0.0
---

# Get-AzEventGridExtensionTopic

## SYNOPSIS
Get the properties of an extension topic.

## SYNTAX

```
Get-AzEventGridExtensionTopic -Scope <String> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Get the properties of an extension topic.

## EXAMPLES

### Example 1: Get the properties of an extension topic.
```powershell
Get-AzEventGridExtensionTopic -Scope "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}"
```

```output
Value
-----
......
```

Get the properties of an extension topic.

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

### -Scope
The identifier of the resource to which extension topic is queried.
The scope can be a subscription, or a resource group, or a top level resource belonging to a resource provider namespace.
For example, use '/subscriptions/{subscriptionId}/' for a subscription, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for a resource group, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}' for Azure resource.

```yaml
Type: System.String
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IExtensionTopic

## NOTES

## RELATED LINKS
