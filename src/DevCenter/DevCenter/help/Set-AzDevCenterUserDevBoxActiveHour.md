---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/set-azdevcenteruserdevboxactivehour
schema: 2.0.0
---

# Set-AzDevCenterUserDevBoxActiveHour

## SYNOPSIS
Lets a user set their own active hours for their Dev Box, overriding the defaults set at the pool level.

## SYNTAX

### SetExpanded (Default)
```
Set-AzDevCenterUserDevBoxActiveHour -Endpoint <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] -EndTimeHour <Int32> -StartTimeHour <Int32> -TimeZone <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Set
```
Set-AzDevCenterUserDevBoxActiveHour -Endpoint <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] -Body <IUserActiveHoursConfiguration> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByDevCenter
```
Set-AzDevCenterUserDevBoxActiveHour -DevCenterName <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] -Body <IUserActiveHoursConfiguration> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetExpandedByDevCenter
```
Set-AzDevCenterUserDevBoxActiveHour -DevCenterName <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] -EndTimeHour <Int32> -StartTimeHour <Int32> -TimeZone <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Lets a user set their own active hours for their Dev Box, overriding the defaults set at the pool level.

## EXAMPLES

### Example 1: Set active hours for a Dev Box by endpoint and user ID
```powershell
Set-AzDevCenterUserDevBoxActiveHour `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -StartTimeHour 9 `
  -EndTimeHour 17 `
  -TimeZone "America/Los_Angeles"
```

This command sets the active hours for the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" from 9 AM to 5 PM in the "America/Los_Angeles" time zone using the endpoint.

### Example 2: Set active hours for a Dev Box by dev center name and current user
```powershell
Set-AzDevCenterUserDevBoxActiveHour `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me" `
  -StartTimeHour 8 `
  -EndTimeHour 16 `
  -TimeZone "America/New_York"
```

This command sets the active hours for the dev box "myDevBox" assigned to the current signed-in user from 8 AM to 4 PM in the "America/New_York" time zone using the dev center name.

### Example 3: Set active hours for a Dev Box using Body parameter and endpoint
```powershell
$activeHours = @{
    StartTimeHour = 10
    EndTimeHour = 18
    TimeZone = "America/Chicago"
}
Set-AzDevCenterUserDevBoxActiveHour `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me" `
  -Body $activeHours
```

This command sets the active hours for the dev box "myDevBox" assigned to the current signed-in user from 10 AM to 6 PM in the "America/Chicago" time zone using the endpoint and a body object.

### Example 4: Set active hours for a Dev Box using Body parameter and dev center name
```powershell
$activeHours = @{
    StartTimeHour = 7
    EndTimeHour = 15
    TimeZone = "America/Los_Angeles"
}
Set-AzDevCenterUserDevBoxActiveHour `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -Body $activeHours
```

This command sets the active hours for the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" from 7 AM to 3 PM in the "UTC" time zone using the dev center name and a body object.

## PARAMETERS

### -Body
Manual user set active hours configuration.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IUserActiveHoursConfiguration
Parameter Sets: Set, SetByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -DevBoxName
Display name for the Dev Box.

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

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: SetByDevCenter, SetExpandedByDevCenter
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
Parameter Sets: SetExpanded, Set
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTimeHour
The end time of the active hours.

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetExpandedByDevCenter
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTimeHour
The start time of the active hours.

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZone
The timezone of the active hours.

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
The AAD object id of the user.
If value is 'me', the identity is taken from the authentication context.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: "me"
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IUserActiveHoursConfiguration

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IDevBox

## NOTES

## RELATED LINKS
