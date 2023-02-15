---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/grant-azeventgridpartnerconfiguration
schema: 2.0.0
---

# Grant-AzEventGridPartnerConfiguration

## SYNOPSIS
Grants access to a partner for the specified partner configuration.

## SYNTAX

### ResourceGroupNameParameterSet (Default)
```
Grant-AzEventGridPartnerConfiguration [-ResourceGroupName] <String> [[-PartnerRegistrationImmutableId] <Guid>]
 [[-PartnerName] <String>] [[-AuthorizationExpirationTime] <DateTime>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PartnerConfigurationInputObjectParameterSet
```
Grant-AzEventGridPartnerConfiguration [-InputObject] <PSPartnerConfiguration>
 [[-PartnerRegistrationImmutableId] <Guid>] [[-PartnerName] <String>]
 [[-AuthorizationExpirationTime] <DateTime>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Grant-AzEventGridPartnerConfiguration cmdlet grants access to a partner for the specific partner configuration based on either the partner registration immutable ID or the partner name.
At least one of the partner registration immutable ID and the partner name is required.

## EXAMPLES

### Example 1
```powershell
Grant-AzEventGridPartnerConfiguration -ResourceGroup MyResourceGroupName -PartnerRegistrationImmutableId 23e0092b-f336-4833-9ab3-9353a15650fc
```

Grants access to a partner based on the partner ID for the partner configuration in resource group \`MyResourceGroupName\`.

## PARAMETERS

### -AuthorizationExpirationTime
Expiration time of the partner authorization.
If this timer expires, any request from this partner to create, update or delete resources in subscriber's context will fail.
If specified, the allowed values are between 1 to the value of defaultMaximumExpirationTimeInDays specified in PartnerConfiguration.
If not specified, the default value will be the value of defaultMaximumExpirationTimeInDays specified in PartnerConfiguration or 7 if this value is not specified.

```yaml
Type: System.Nullable`1[System.DateTime]
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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
PartnerConfiguration object.

```yaml
Type: Microsoft.Azure.Commands.EventGrid.Models.PSPartnerConfiguration
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerRegistrationImmutableId
Immutable id of the corresponding partner registration

```yaml
Type: System.Nullable`1[System.Guid]
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
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

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerConfiguration

### System.Nullable`1[[System.Guid, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerConfiguration

## NOTES

## RELATED LINKS
