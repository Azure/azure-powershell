---
external help file:
Module Name: Az.EdgeZones
online version: https://learn.microsoft.com/powershell/module/az.edgezones/register-azedgezonesextendedzone
schema: 2.0.0
---

# Register-AzEdgeZonesExtendedZone

## SYNOPSIS
Registers a subscription for an Extended Zone

## SYNTAX

### Register (Default)
```
Register-AzEdgeZonesExtendedZone -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegisterViaIdentity
```
Register-AzEdgeZonesExtendedZone -InputObject <IEdgeZonesIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Registers a subscription for an Extended Zone

## EXAMPLES

### Example 1: Register subscription for an Azure Extended Zone
```powershell
Register-AzEdgeZonesExtendedZone -Name losangeles
```

```output
DisplayName                  : Los Angeles
Geography                    : usa
GeographyGroup               : US
HomeLocation                 : westus
Id                           : /subscriptions/2027ff61-4414-4aa3-bd20-170c46f69b19/providers/Microsoft.EdgeZones/extendedZones/losangeles
Latitude                     : 34.058414
Longitude                    : -118.23537
Name                         : losangeles
ProvisioningState            : Succeeded
RegionCategory               : Other
RegionType                   : Physical
RegionalDisplayName          : (US) Los Angeles
RegistrationState            : PendingRegister
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.EdgeZones/extendedZones
```

This command register subscription for an Azure Extended Zone

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeZones.Models.IEdgeZonesIdentity
Parameter Sets: RegisterViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ExtendedZone

```yaml
Type: System.String
Parameter Sets: Register
Aliases: ExtendedZoneName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Register
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeZones.Models.IEdgeZonesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeZones.Models.IExtendedZone

## NOTES

## RELATED LINKS

