---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserschedule
schema: 2.0.0
---

# Get-AzDevCenterUserSchedule

## SYNOPSIS
Gets a schedule.

## SYNTAX

### List1 (Default)
```
Get-AzDevCenterUserSchedule -Endpoint <String> -ProjectName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserSchedule -Endpoint <String> -PoolName <String> -ProjectName <String> -ScheduleName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserSchedule -DevCenterName <String> -PoolName <String> -ProjectName <String>
 -ScheduleName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserSchedule -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserSchedule -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDevCenterUserSchedule -Endpoint <String> -PoolName <String> -ProjectName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1ByDevCenter
```
Get-AzDevCenterUserSchedule -DevCenterName <String> -ProjectName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserSchedule -DevCenterName <String> -PoolName <String> -ProjectName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a schedule.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
Get-AzDevCenterUserSchedule -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -PoolName DevPool -ScheduleName default
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
Get-AzDevCenterUserSchedule -DevCenterName Contoso -ProjectName DevProject -PoolName DevPool -ScheduleName default
```



### -------------------------- EXAMPLE 3 --------------------------
```powershell
$devBoxInput = @{"ProjectName" = "DevProject"; "PoolName" = "DevPool"; "ScheduleName" = "default" }
Get-AzDevCenterUserSchedule -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput
```



### -------------------------- EXAMPLE 4 --------------------------
```powershell
$devBoxInput = @{"ProjectName" = "DevProject"; "PoolName" = "DevPool"; "ScheduleName" = "default" }
Get-AzDevCenterUserSchedule -DevCenterName Contoso -InputObject $devBoxInput
```



### -------------------------- EXAMPLE 5 --------------------------
```powershell
Get-AzDevCenterUserSchedule -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
```



### -------------------------- EXAMPLE 6 --------------------------
```powershell
Get-AzDevCenterUserSchedule -DevCenterName Contoso -ProjectName DevProject
```



### -------------------------- EXAMPLE 7 --------------------------
```powershell
Get-AzDevCenterUserSchedule -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -PoolName DevPool
```



### -------------------------- EXAMPLE 8 --------------------------
```powershell
Get-AzDevCenterUserSchedule -DevCenterName Contoso -ProjectName DevProject -PoolName DevPool
```



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

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: GetByDevCenter, GetViaIdentityByDevCenter, List1ByDevCenter, ListByDevCenter
Aliases: DevCenter

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The DevCenter-specific URI to operate on.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
Parameter Sets: GetViaIdentity, GetViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PoolName
Pool name.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter, List, ListByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
Name of the project.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter, List, List1, List1ByDevCenter, ListByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleName
Display name for the Schedule.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20240501Preview.ISchedule

## NOTES

## RELATED LINKS

