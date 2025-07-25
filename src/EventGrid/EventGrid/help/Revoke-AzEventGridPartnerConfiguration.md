---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/revoke-azeventgridpartnerconfiguration
schema: 2.0.0
---

# Revoke-AzEventGridPartnerConfiguration

## SYNOPSIS
Unauthorize a single partner either by partner registration immutable Id or by partner name.

## SYNTAX

### PartnerExpanded (Default)
```
Revoke-AzEventGridPartnerConfiguration -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AuthorizationExpirationTimeInUtc <DateTime>] [-PartnerName <String>]
 [-PartnerRegistrationImmutableId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Partner
```
Revoke-AzEventGridPartnerConfiguration -ResourceGroupName <String> [-SubscriptionId <String>]
 -PartnerInfo <IPartner> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PartnerViaJsonFilePath
```
Revoke-AzEventGridPartnerConfiguration -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### PartnerViaJsonString
```
Revoke-AzEventGridPartnerConfiguration -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Unauthorize a single partner either by partner registration immutable Id or by partner name.

## EXAMPLES

### Example 1: Unauthorize a single partner either by partner registration immutable Id or by partner name.
```powershell
$partnerRegistration = Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid -Name azps-registration
Revoke-AzEventGridPartnerConfiguration -ResourceGroupName azps_test_group_eventgrid -AuthorizationExpirationTimeInUtc "2024-01-09T09:31:42.521Z" -PartnerName default -PartnerRegistrationImmutableId $partnerRegistration.ImmutableId
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default global   azps_test_group_eventgrid
```

Unauthorize a single partner either by partner registration immutable Id or by partner name.

## PARAMETERS

### -AuthorizationExpirationTimeInUtc
Expiration time of the partner authorization.
If this timer expires, any request from this partner to create, update or delete resources in subscriber'scontext will fail.
If specified, the allowed values are between 1 to the value of defaultMaximumExpirationTimeInDays specified in PartnerConfiguration.If not specified, the default value will be the value of defaultMaximumExpirationTimeInDays specified in PartnerConfiguration or 7 if this value is not specified.

```yaml
Type: System.DateTime
Parameter Sets: PartnerExpanded
Aliases: AuthorizationExpirationTime

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Partner operation

```yaml
Type: System.String
Parameter Sets: PartnerViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Partner operation

```yaml
Type: System.String
Parameter Sets: PartnerViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerInfo
Information about the partner.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IPartner
Parameter Sets: Partner
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PartnerName
The partner name.

```yaml
Type: System.String
Parameter Sets: PartnerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerRegistrationImmutableId
The immutableId of the corresponding partner registration.

```yaml
Type: System.String
Parameter Sets: PartnerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IPartner

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IPartnerConfiguration

## NOTES

## RELATED LINKS
