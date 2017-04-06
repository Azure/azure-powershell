---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmRelayNamespace

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

```
Set-AzureRmRelayNamespace [-ResourceGroupName] <String> [-NamespaceName] <String> [-Tag <Hashtable>]
 [-RelayNamespaceObj <RelayNamespaceAttirbutesUpdateParameter>] [-WhatIf] [-Confirm]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Hashtables which represents resource Tag.

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

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.String
System.Collections.Hashtable
Microsoft.Azure.Commands.Relay.Models.RelayNamespaceAttirbutesUpdateParameter


## OUTPUTS

### Microsoft.Azure.Commands.Relay.Models.RelayNamespaceAttributes


## NOTES

## RELATED LINKS

