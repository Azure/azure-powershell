---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/test-aztrafficmanagerprofiletrafficmanagernameavailabilityv2
schema: 2.0.0
---

# Test-AzTrafficManagerProfileTrafficManagerNameAvailabilityV2

## SYNOPSIS
Checks the availability of a Traffic Manager Relative DNS name.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzTrafficManagerProfileTrafficManagerNameAvailabilityV2 -SubscriptionId <String> [-Name <String>]
 [-Type <String>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzTrafficManagerProfileTrafficManagerNameAvailabilityV2 -SubscriptionId <String>
 -Parameters <ICheckTrafficManagerRelativeDnsNameAvailabilityParameters> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Checks the availability of a Traffic Manager Relative DNS name.

## EXAMPLES

### Example 1: Check if a DNS name is available
```powershell
Test-AzTrafficManagerProfileTrafficManagerNameAvailabilityV2 -Name "myprofile" -Type "Microsoft.Network/trafficManagerProfiles"
```

```output
NameAvailable : True
Name          : myprofile
Type          : Microsoft.Network/trafficManagerProfiles
Message       :
```

Checks whether the relative DNS name "myprofile" is available for creating a new Traffic Manager profile.

### Example 2: Check an unavailable name
```powershell
Test-AzTrafficManagerProfileTrafficManagerNameAvailabilityV2 -Name "existingprofile" -Type "Microsoft.Network/trafficManagerProfiles"
```

```output
NameAvailable : False
Name          : existingprofile
Type          : Microsoft.Network/trafficManagerProfiles
Message       : The DNS name is already in use.
```

Checks a name that is already taken and returns False.

## PARAMETERS

### -Name
The name of the resource.

```yaml
Type: System.String
Parameter Sets: CheckExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
Parameters supplied to check Traffic Manager name operation.

```yaml
Type: Az.TrafficManager.Models.ICheckTrafficManagerRelativeDnsNameAvailabilityParameters
Parameter Sets: Check
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of the resource.

```yaml
Type: System.String
Parameter Sets: CheckExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Az.TrafficManager.Models.ICheckTrafficManagerRelativeDnsNameAvailabilityParameters

## OUTPUTS

### Az.TrafficManager.Models.ITrafficManagerNameAvailability

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PARAMETERS <ICheckTrafficManagerRelativeDnsNameAvailabilityParameters>`: Parameters supplied to check Traffic Manager name operation.
  - `[Name <String>]`: The name of the resource.
  - `[Type <String>]`: The type of the resource.

## RELATED LINKS

