---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# New-AzEventGridPartnerNamespaceKey

## SYNOPSIS
Regenerates the shared access key for an Azure Event Grid partner namespace.

## SYNTAX

### PartnerNamespaceNameParameterSet (Default)
```
New-AzEventGridPartnerNamespaceKey [-ResourceGroupName] <String> [-PartnerNamespaceName] <String>
 [-Name] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PartnerNamespaceInputObjectParameterSet
```
New-AzEventGridPartnerNamespaceKey [-Name] <String> -InputObject <PSPartnerNamespace>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Regenerates the shared access key for an Azure Event Grid partner namespace.

## EXAMPLES

### Example 1
```powershell
New-AzEventGridPartnerNamespaceKey -ResourceGroupName MyResourceGroupName -PartnerNamespaceName PartnerNamespace1 -Name key1
```

Regenerate the key corresponding to key \`key1\` of Event Grid partner namespace \`PartnerNamespace1\` in resource group \`MyResourceGroupName\`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
PartnerNamespace object

```yaml
Type: PSPartnerNamespace
Parameter Sets: PartnerNamespaceInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the shared access key for the partner namespace.
Either key1 or key2.

```yaml
Type: String
Parameter Sets: (All)
Aliases: KeyName
Accepted values: key1, key2

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerNamespaceName
Event Grid partner namespace name.

```yaml
Type: String
Parameter Sets: PartnerNamespaceNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: PartnerNamespaceNameParameterSet
Aliases: ResourceGroup

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
Default value: None
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerNamespace

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerNamespace

## NOTES

## RELATED LINKS
