---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/get-azresiliencedrillrun
schema: 2.0.0
---

# Get-AzResilienceDrillRun

## SYNOPSIS
Get a DrillRun

## SYNTAX

### List (Default)
```
Get-AzResilienceDrillRun -DrillName <String> -ServiceGroupName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzResilienceDrillRun -DrillName <String> -Name <String> -ServiceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzResilienceDrillRun -InputObject <IResilienceIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityDrill
```
Get-AzResilienceDrillRun -DrillInputObject <IResilienceIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityServiceGroup
```
Get-AzResilienceDrillRun -DrillName <String> -Name <String> -ServiceGroupInputObject <IResilienceIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a DrillRun

## EXAMPLES

### Example 1: List all drill runs in a service group
```powershell
Get-AzResilienceDrillRun -DrillName 'drill-zonal-payments' -ServiceGroupName 'azcmdlet-testing'
```

Lists every drill run in the specified service group.

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

### -DrillInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: GetViaIdentityDrill
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DrillName
The name of the Drill

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityServiceGroup, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the DrillRun (GUID).

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityDrill, GetViaIdentityServiceGroup
Aliases: DrillRunName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: GetViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrillRun

## NOTES

## RELATED LINKS

