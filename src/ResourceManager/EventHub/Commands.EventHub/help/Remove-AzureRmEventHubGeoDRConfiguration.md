---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
Module Name: AzureRM.EventHub
online version: 
schema: 2.0.0
---

# Remove-AzureRmEventHubDRConfiguration

## SYNOPSIS
Deletes an Alias(Disaster Recovery configuration)

## SYNTAX

### AliasPropertiesSet (Default)
```
Remove-AzureRmEventHubDRConfiguration [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
 [[-InputObject] <EventHubDRConfigurationAttributes>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm]
```

### AliasInputObjectSet
```
Remove-AzureRmEventHubDRConfiguration [-ResourceGroupName] <String> [-Namespace] <String> [[-Name] <String>]
 [-InputObject] <EventHubDRConfigurationAttributes> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm]
```

## DESCRIPTION
The **Remove-AzureRmEventHubDRConfiguration** cmdlet deletes an Alias(Disaster Recovery configuration)

## EXAMPLES

### Example 1
```
PS C:\>Remove-AzureRmEventHubDRConfiguration -ResourceGroupName "SampleResourceGroup" -Namespace "SampleNamespace_Secondary" -Name "SampleDRCongifName"
```

Deletes an Alias(Disaster Recovery configuration)

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Alias Configuration object.

```yaml
Type: EventHubDRConfigurationAttributes
Parameter Sets: AliasPropertiesSet
Aliases: AliasObj

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: EventHubDRConfigurationAttributes
Parameter Sets: AliasInputObjectSet
Aliases: AliasObj

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Alias (GeoDR)

```yaml
Type: String
Parameter Sets: AliasPropertiesSet
Aliases: Alias

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: AliasInputObjectSet
Aliases: Alias

Required: False
Position: 2
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
Position: 1
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
Microsoft.Azure.Commands.EventHub.Models.EventHubDRConfigurationAttributes


## OUTPUTS

### System.Boolean


## NOTES

## RELATED LINKS

