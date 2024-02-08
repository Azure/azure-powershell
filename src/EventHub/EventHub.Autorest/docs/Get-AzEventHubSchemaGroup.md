---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/get-azeventhubschemagroup
schema: 2.0.0
---

# Get-AzEventHubSchemaGroup

## SYNOPSIS
Gets all the Schema Groups in a Namespace.

## SYNTAX

```
Get-AzEventHubSchemaGroup -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Skip <Int32>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets all the Schema Groups in a Namespace.

## EXAMPLES

### Example 1: Get details of a schema group from an EventHub namespace
```powershell
Get-AzEventHubSchemaGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name mySchemaGroup
```

```output
CreatedAtUtc                 : 9/14/2022 6:05:47 AM
ETag                         : {etag}
GroupProperty                : {
                               }
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/schemagroups/mySchemaGroup
Location                     : Central US
Name                         : mySchemaGroup
ResourceGroupName            : myResourceGroup
SchemaCompatibility          : None
SchemaType                   : Avro
```

Gets details of schema group `mySchemaGroup` from EventHub namespace `myNamespace`.

### Example 2: List all schema groups in an EventHub namespace
```powershell
Get-AzEventHubSchemaGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Lists all schema groups created within EventHub namespace `myNamespace`.

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

### -NamespaceName
The Namespace name

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

### -ResourceGroupName
Name of the resource group within the azure subscription.

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

### -Skip
Skip is only used if a previous operation returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skip parameter that specifies a starting point to use for subsequent calls.

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
May be used to limit the number of results to the most recent N usageDetails.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.ISchemaGroup

## NOTES

## RELATED LINKS

