---
external help file: Az.EdgeZones-help.xml
Module Name: Az.EdgeZones
online version: https://learn.microsoft.com/powershell/module/az.edgezones/get-azedgezonesextendedzone
schema: 2.0.0
---

# Get-AzEdgeZonesExtendedZone

## SYNOPSIS
Gets an Azure Extended Zone for a subscription

## SYNTAX

### List (Default)
```
Get-AzEdgeZonesExtendedZone [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzEdgeZonesExtendedZone -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEdgeZonesExtendedZone -InputObject <IEdgeZonesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an Azure Extended Zone for a subscription

## EXAMPLES

### Example 1: List all Azure Extended Zones under a subscription
```powershell
Get-AzEdgeZonesExtendedZone
```

```output
Name                     SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                     ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
losangeles
```

This command list all Azure Extended Zones under a subscription

### Example 2: Get an Azure Extended Zone by name
```powershell
Get-AzEdgeZonesExtendedZone -Name losangeles
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
RegistrationState            : NotRegistered
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.EdgeZones/extendedZones
```

This command gets an Azure Extended Zones by name

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
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get
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
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
