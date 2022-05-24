---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventHub.dll-Help.xml
Module Name: Az.EventHub
online version:
schema: 2.0.0
---

# New-AzEventHubSchemaGroup

## SYNOPSIS
Creates schema group in a namespace.

## SYNTAX

```
New-AzEventHubSchemaGroup [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
 -SchemaCompatibility <String> -SchemaType <String> [-GroupProperty <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzEventHubSchemaGroup cmdlet creates schema group in a namespace.

## EXAMPLES

### Example 1
```powershell
New-AzEventHubSchemaGroup -ResourceGroupName myresourcegroup -Namespace mynamespace -Name myschemagroup -SchemaCompatibility Forward -SchemaType Avro -GroupProperty @{'key1'='value1';'key2'='value2'}
```

```output
Id                  : /subscriptions/{subscriptionid}/resourceGroups/myresourcegroup/providers/Microsoft.EventHub/namespaces/mynamespace/schemagroups/myschemagroup
Name                : myschemagroup
Location            : East US
Type                : Microsoft.EventHub/Namespaces/SchemaGroups
SchemaCompatibility : Forward
SchemaType          : Avro
GroupProperties     : {key1:value1, key2:value2}
```

Create schema group \`myschemagroup\` in the namespace \`mynamespace\` in resource group \`myresourcegroup\`

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

### -GroupProperty
Group property of eventhub

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Name of Schema Group

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases: NamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SchemaCompatibility
Compatibility of Schema.
Forward, Backward

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: None, Forward, Backward

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SchemaType
Type of Schema

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Avro

Required: True
Position: Named
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

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.EventHub.Models.PSEventHubsSchemaRegistryAttributes

## NOTES

## RELATED LINKS
