---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorbackendpoolobject
schema: 2.0.0
---

# New-AzFrontDoorBackendPoolObject

## SYNOPSIS
Create an in-memory object for BackendPool.

## SYNTAX

```
New-AzFrontDoorBackendPoolObject [-Backend <IBackend[]>] [-FrontDoorName <String>]
 [-HealthProbeSettingsName <String>] [-Id <String>] [-LoadBalancingSettingsName <String>] [-Name <String>]
 [-ResourceGroupName <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BackendPool.

## EXAMPLES

### Example 1
```powershell
New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
```

```output
Backend                :
HealthProbeSettingId   : /subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups//providers/Microsoft.Network/frontDoors//HealthProbeSettings/healthProbeSetting1
Id                     :
LoadBalancingSettingId : /subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups//providers/Microsoft.Network/frontDoors//LoadBalancingSettings/loadBalancingSetting1
Name                   : backendpool1
ResourceState          :
Type                   :
```

Create a PSBackendPool object for Front Door creation

## PARAMETERS

### -Backend
The set of backends for this pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackend[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontDoorName
Resource ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthProbeSettingsName
Resource ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancingSettingsName
Resource ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.BackendPool

## NOTES

## RELATED LINKS

