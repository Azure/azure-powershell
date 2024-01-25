---
external help file:
<<<<<<<< HEAD:src/DesktopVirtualization/DesktopVirtualization.Autorest/docs/Update-AzWvdSessionHostManagement.md
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/update-azwvdsessionhostmanagement
schema: 2.0.0
---

# Update-AzWvdSessionHostManagement

## SYNOPSIS
Update a SessionHostManagement.
========
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/update-azdevcenteradminproject
schema: 2.0.0
---

# Update-AzDevCenterAdminProject

## SYNOPSIS
Partially updates a project.
>>>>>>>> generation:src/DevCenter/DevCenter.AutoRest/docs/Update-AzDevCenterAdminProject.md

## SYNTAX

### UpdateExpanded (Default)
```
<<<<<<<< HEAD:src/DesktopVirtualization/DesktopVirtualization.Autorest/docs/Update-AzWvdSessionHostManagement.md
Update-AzWvdSessionHostManagement -HostPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ScheduledDateTimeZone <String>] [-UpdateDeleteOriginalVM]
 [-UpdateLogOffDelayMinute <Int32>] [-UpdateLogOffMessage <String>] [-UpdateMaxVmsRemoved <Int32>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
========
Update-AzDevCenterAdminProject -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Description <String>] [-DisplayName <String>] [-MaxDevBoxesPerUser <Int32>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
>>>>>>>> generation:src/DevCenter/DevCenter.AutoRest/docs/Update-AzDevCenterAdminProject.md
```

### UpdateViaIdentityExpanded
```
<<<<<<<< HEAD:src/DesktopVirtualization/DesktopVirtualization.Autorest/docs/Update-AzWvdSessionHostManagement.md
Update-AzWvdSessionHostManagement -InputObject <IDesktopVirtualizationIdentity>
 [-ScheduledDateTimeZone <String>] [-UpdateDeleteOriginalVM] [-UpdateLogOffDelayMinute <Int32>]
 [-UpdateLogOffMessage <String>] [-UpdateMaxVmsRemoved <Int32>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a SessionHostManagement.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

========
Update-AzDevCenterAdminProject -InputObject <IDevCenterIdentity> [-Description <String>]
 [-DisplayName <String>] [-MaxDevBoxesPerUser <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Partially updates a project.

## EXAMPLES

### Example 1: Update a project
```powershell
Update-AzDevCenterAdminProject -Name DevProject -ResourceGroupName testRg -MaxDevBoxesPerUser 5
```

This command updates a project name "DevProject" in the resource group "testRg".

### Example 2: Update a project using InputObject
```powershell
$projectInput = Get-AzDevCenterAdminProject -ResourceGroupName testRg -Name DevProject

Update-AzDevCenterAdminProject -InputObject $projectInput -MaxDevBoxesPerUser 5
```

This command updates a project name "DevProject" in the resource group "testRg".

## PARAMETERS

### -AsJob
Run the command as a job

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

>>>>>>>> generation:src/DevCenter/DevCenter.AutoRest/docs/Update-AzDevCenterAdminProject.md
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

<<<<<<<< HEAD:src/DesktopVirtualization/DesktopVirtualization.Autorest/docs/Update-AzWvdSessionHostManagement.md
### -HostPoolName
The name of the host pool within the specified resource group
========
### -Description
Description of the project.

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

### -DisplayName
The display name of the project.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MaxDevBoxesPerUser
When specified, limits the maximum number of Dev Boxes a single user can create across all pools in the project.
This will have no effect on existing Dev Boxes when reduced.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the project.
>>>>>>>> generation:src/DevCenter/DevCenter.AutoRest/docs/Update-AzDevCenterAdminProject.md

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ProjectName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<<< HEAD:src/DesktopVirtualization/DesktopVirtualization.Autorest/docs/Update-AzWvdSessionHostManagement.md
### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
========
### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
>>>>>>>> generation:src/DevCenter/DevCenter.AutoRest/docs/Update-AzDevCenterAdminProject.md
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<<< HEAD:src/DesktopVirtualization/DesktopVirtualization.Autorest/docs/Update-AzWvdSessionHostManagement.md
### -ScheduledDateTimeZone
Time zone for sessionHostManagement operations as defined in https://docs.microsoft.com/dotnet/api/system.timezoneinfo.findsystemtimezonebyid.
Must be set if useLocalTime is true.

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

========
>>>>>>>> generation:src/DevCenter/DevCenter.AutoRest/docs/Update-AzDevCenterAdminProject.md
### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateDeleteOriginalVM
Whether not to save original disk.
False by default.

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

### -UpdateLogOffDelayMinute
Grace period before logging off users in minutes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateLogOffMessage
Log off message sent to user for logoff.

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

### -UpdateMaxVmsRemoved
The maximum number of virtual machines to be removed during hostpool update.

```yaml
Type: System.Int32
Parameter Sets: (All)
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

<<<<<<<< HEAD:src/DesktopVirtualization/DesktopVirtualization.Autorest/docs/Update-AzWvdSessionHostManagement.md
### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231101Preview.ISessionHostManagement
========
### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20231001Preview.IProject
>>>>>>>> generation:src/DevCenter/DevCenter.AutoRest/docs/Update-AzDevCenterAdminProject.md

## NOTES

## RELATED LINKS

