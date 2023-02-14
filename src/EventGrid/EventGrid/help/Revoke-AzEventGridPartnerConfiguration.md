---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Revoke-AzEventGridPartnerConfiguration

## SYNOPSIS
Revokes access to a partner in a partner configuration.

## SYNTAX

### ResourceGroupNameParameterSet (Default)
```
Revoke-AzEventGridPartnerConfiguration [-ResourceGroupName] <String> [-PartnerRegistrationImmutableId <Guid>]
 [-PartnerName <String>] [-AuthorizationExpirationTime <DateTime>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PartnerConfigurationInputObjectParameterSet
```
Revoke-AzEventGridPartnerConfiguration [-InputObject] <PSPartnerConfiguration>
 [-PartnerRegistrationImmutableId <Guid>] [-PartnerName <String>] [-AuthorizationExpirationTime <DateTime>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Revoke-AzEventGridPartnerConfiguration revokes access to a partner in a partner configuration using either the partner registration immutable ID or the partner name. At least one of these two parameters is required.

## EXAMPLES

### Example 1
```powershell
Revoke-AzEventGridPartnerConfiguration -ResourceGroupName MyResourceGroupName -PartnerName Contoso.Finance
```

Revokes access for partner name \`Contoso.Finance\` for the partner configuration in resource group \`MyResourceGroupName\`.

## PARAMETERS

### -AuthorizationExpirationTime
Expiration time of the partner authorization.
If this timer expires, any request from this partner to create, update or delete resources in subscriber's context will fail.
If specified, the allowed values are between 1 to the value of defaultMaximumExpirationTimeInDays specified in PartnerConfiguration.
If not specified, the default value will be the value of defaultMaximumExpirationTimeInDays specified in PartnerConfiguration or 7 if this value is not specified.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -PartnerName
Parter name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerRegistrationImmutableId
Immutable id of the corresponding partner registration

```yaml
Type: Guid
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

### System.Nullable`1[[System.Guid, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerConfiguration

## NOTES

## RELATED LINKS
