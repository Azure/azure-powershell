---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Update-AzEventGridPartnerConfiguration

## SYNOPSIS
Updates the details of an Event Grid partner configuration.

## SYNTAX

### ResourceGroupNameParameterSet (Default)
```
Update-AzEventGridPartnerConfiguration [-ResourceGroupName] <String> [-Tag <Hashtable>]
 [-MaxExpirationTimeInDays <Int32>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PartnerConfigurationInputObjectParameterSet
```
Update-AzEventGridPartnerConfiguration [-InputObject] <PSPartnerConfiguration> [-Tag <Hashtable>]
 [-MaxExpirationTimeInDays <Int32>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates the details of an Event Grid partner configuration.

## EXAMPLES

### Example 1
```powershell
Update-AzEventGridPartnerConfiguration -ResourceGroupName MyResourceGroupName -MaxExpirationTimeInDays 8
```

Updates the maximum expiration time in days property of the partner configuration in the resource group \`MyResourceGroupName\`.

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
PartnerConfiguration object.

```yaml
Type: PSPartnerConfiguration
Parameter Sets: PartnerConfigurationInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaxExpirationTimeInDays
Expiration time in days used to validate the authorization expiration time for each authorized partner.
If this parameter is not specified, the default is 7 days.
Otherwise, allowed values are between 1 and 365 days.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: ResourceGroupNameParameterSet
Aliases: ResourceGroup

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Hashtable which represents resource Tags.

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

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerConfiguration

### System.Collections.Hashtable

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerConfiguration

## NOTES

## RELATED LINKS
