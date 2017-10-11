---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmEventHub

## SYNOPSIS
Gets the details of a single Event Hub, or gets a list of Event Hubs.

## SYNTAX

```
Get-AzureRmEventHub [-ResourceGroupName] <String> -Namespace <String> [-Name <String>]
```

## DESCRIPTION
The Get-AzureRmEventHub cmdlet returns either the details of an Event Hub, or a list of all Event Hubs in the current namespace.
If the Event Hub name is provided, the details of a single Event Hub are returned.
If an Event Hub name is not provided, a list of all Event Hubs in the specified namespace is returned.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmEventHub -ResourceGroupName MyResourceGroupName -NamespaceName MyNamespaceName -EventHubName MyEventHubName
```

Returns the details of the Event Hub \`MyEventHubName\`.

### Example 2
```
PS C:\> Get-AzureRmEventHub -ResourceGroup MyResourceGroupName -NamespaceName MyNamespaceName
```

Returns a list of Event Hubs in the namespace \`MyNamespaceName\`.

## PARAMETERS

### -ResourceGroupName
Resource group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
EventHub Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: EventHubName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Namespace
Namespace Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: NamespaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.EventHub.Models.EventHubAttributes, Microsoft.Azure.Commands.EventHub, Version=0.0.1.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

