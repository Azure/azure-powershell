---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version:
schema: 2.0.0
---

# Set-AzureRmRelayNamespace

## SYNOPSIS
Updates the description of an existing Relay namespace.

## SYNTAX

```
Set-AzureRmRelayNamespace [-ResourceGroupName] <String> [-NamespaceName] <String> [-Tag <Hashtable>]
 [-RelayNamespaceObj <RelayNamespaceAttirbutesUpdateParameter>] [-WhatIf] [-Confirm]
```

## DESCRIPTION
The **Set-AzureRmRelayNamespace** cmdlet updates the description of the specified Relay namespace within the resource group.

## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmRelayNamespace -ResourceGroupName Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -Tag @{Tag2="Tag2Value"}

ProvisioningState  :
CreatedAt          : 4/12/2017 12:38:47 AM
UpdatedAt          : 4/12/2017 12:39:10 AM
ServiceBusEndpoint : https://TestNameSpace-Relay1.servicebus.windows.net:443/
MetricId           :
Location           :
Tags               : {[tag2, Tag2Value]}
Id                 :
Name               :
Type               :
```

Updates the Relay namespace with a new description.

## PARAMETERS

### -NamespaceName
Relay Namespace Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RelayNamespaceObj
Relay Namespace object.

```yaml
Type: RelayNamespaceAttirbutesUpdateParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

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

### -Tag
Key-value pairs in the form of a hash table. For example:

@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### -ResourceGroupName
 System.String

### -NamespaceName
 System.String

### -Location
 System.String

### -Tag
 System.Collections.Hashtable

## OUTPUTS

Microsoft.Azure.Commands.Relay.Models.RelayNamespaceAttributes

## NOTES

## RELATED LINKS
