---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmRelayNamespace

## SYNOPSIS
Removes the namespace from the specified resource group. 

## SYNTAX

```
Remove-AzureRmRelayNamespace [-ResourceGroup] <String> [-Name] <String> [-WhatIf] [-Confirm]
```

## DESCRIPTION
The **Remove-AzureRmRelayNamespace** cmdlet removes the namespace from the specified resource group.


## EXAMPLES

### Example 1
```
PS C:\> Remove-AzureRmRelayNamespace -ResourceGroup Default-ServiceBus-WestUS -Name TestNameSpace-Relay1
```

Removes the Relay namespace `TestNameSpace-Relay1` from the specified resource group `Default-ServiceBus-WestUS`.

## PARAMETERS

### -Name
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

### -ResourceGroup
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

### -ResourceGroup
 System.String

### -Name
 System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

