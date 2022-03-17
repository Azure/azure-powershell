---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventHub.dll-Help.xml
Module Name: Az.EventHub
online version:
schema: 2.0.0
---

# Remove-AzEventHubSchemaGroup

## SYNOPSIS
Removes a schema group from a namespace.

## SYNTAX

### NamespaceSchemaGroupParameterSet
```
Remove-AzEventHubSchemaGroup [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SchemaGroupInputObjectParameterSet
```
Remove-AzEventHubSchemaGroup [-InputObject] <PSEventHubsSchemaRegistryAttributes> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SchemaGroupResourceIdParameterSet
```
Remove-AzEventHubSchemaGroup [-ResourceId] <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Removes-AzEventHubSchemaGroup cmdlet removes a schema group from a namespace.

## EXAMPLES

### Example 1
```powershell
Remove-AzEventHubSchemaGroup -ResourceGroupName myresourcegroup -Namespace mynamespace -Name myschemagroup
```
Remove a schema group \`myschemagroup\` in the namespace \`mynamespace\` in resource group \`myresourcegroup\`


## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Namespace Object

```yaml
Type: Microsoft.Azure.Commands.EventHub.Models.PSEventHubsSchemaRegistryAttributes
Parameter Sets: SchemaGroupInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of Schema Group

```yaml
Type: System.String
Parameter Sets: NamespaceSchemaGroupParameterSet
Aliases: SchemaGroupName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Namespace
Namespace Name

```yaml
Type: System.String
Parameter Sets: NamespaceSchemaGroupParameterSet
Aliases: NamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
{{ Fill PassThru Description }}

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
Resource Group Name

```yaml
Type: System.String
Parameter Sets: NamespaceSchemaGroupParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Namespace Resource Id

```yaml
Type: System.String
Parameter Sets: SchemaGroupResourceIdParameterSet
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
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
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

### Microsoft.Azure.Commands.EventHub.Models.PSEventHubsSchemaRegistryAttributes

## OUTPUTS

### Microsoft.Azure.Commands.EventHub.Models.PSEventHubsSchemaRegistryAttributes

## NOTES

## RELATED LINKS
