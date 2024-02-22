---
external help file: Az.DesktopVirtualization-help.xml
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/invoke-azwvdinitiatesessionhostupdate
schema: 2.0.0
---

# Invoke-AzWvdInitiateSessionHostUpdate

## SYNOPSIS
Initiates a hostpool update or schedule an update for the future.

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzWvdInitiateSessionHostUpdate -HostPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ScheduledDateTime <DateTime>] [-ScheduledDateTimeZone <String>]
 [-UpdateDeleteOriginalVM] [-UpdateLogOffDelayMinute <Int32>] [-UpdateLogOffMessage <String>]
 [-UpdateMaxVmsRemoved <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Post
```
Invoke-AzWvdInitiateSessionHostUpdate -HostPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -UpdateSessionHostsRequestBody <IUpdateSessionHostsRequestBody>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PostViaIdentityExpanded
```
Invoke-AzWvdInitiateSessionHostUpdate -InputObject <IDesktopVirtualizationIdentity>
 [-ScheduledDateTime <DateTime>] [-ScheduledDateTimeZone <String>] [-UpdateDeleteOriginalVM]
 [-UpdateLogOffDelayMinute <Int32>] [-UpdateLogOffMessage <String>] [-UpdateMaxVmsRemoved <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PostViaIdentity
```
Invoke-AzWvdInitiateSessionHostUpdate -InputObject <IDesktopVirtualizationIdentity>
 -UpdateSessionHostsRequestBody <IUpdateSessionHostsRequestBody> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Initiates a hostpool update or schedule an update for the future.

## EXAMPLES

### EXAMPLE 1
```
Invoke-AzWvdInitiateSessionHostUpdate -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -UpdateDeleteOriginalVm `
          -UpdateMaxVmsRemoved 4 `
          -UpdateLogOffDelayMinute 5 `
          -UpdateLogOffMessage "logging off for hostpool update."
```

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostPoolName
The name of the host pool within the specified resource group

```yaml
Type: String
Parameter Sets: PostExpanded, Post
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
Type: IDesktopVirtualizationIdentity
Parameter Sets: PostViaIdentityExpanded, PostViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: PostExpanded, Post
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduledDateTime
The timestamp that the update validation is scheduled for.
If none is provided, the update will be executed immediately

```yaml
Type: DateTime
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduledDateTimeZone
The timeZone as defined in https://docs.microsoft.com/dotnet/api/system.timezoneinfo.findsystemtimezonebyid.

```yaml
Type: String
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: String
Parameter Sets: PostExpanded, Post
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateDeleteOriginalVM
Whether not to save original disk.
False by default.

```yaml
Type: SwitchParameter
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateLogOffDelayMinute
Grace period before logging off users in minutes.

```yaml
Type: Int32
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateLogOffMessage
Log off message sent to user for logoff.

```yaml
Type: String
Parameter Sets: PostExpanded, PostViaIdentityExpanded
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
Type: Int32
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateSessionHostsRequestBody
Object containing the definition for properties to be used for a sessionHostUpdate operation.
To construct, see NOTES section for UPDATESESSIONHOSTSREQUESTBODY properties and create a hash table.

```yaml
Type: IUpdateSessionHostsRequestBody
Parameter Sets: Post, PostViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231101Preview.IUpdateSessionHostsRequestBody
### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
## OUTPUTS

### System.Boolean
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IDesktopVirtualizationIdentity\>: Identity Parameter
  \[AppAttachPackageName \<String\>\]: The name of the App Attach package arm object
  \[ApplicationGroupName \<String\>\]: The name of the application group
  \[ApplicationName \<String\>\]: The name of the application within the specified application group
  \[DesktopName \<String\>\]: The name of the desktop within the specified desktop group
  \[HostPoolName \<String\>\]: The name of the host pool within the specified resource group
  \[Id \<String\>\]: Resource identity path
  \[MsixPackageFullName \<String\>\]: The version specific package full name of the MSIX package within specified hostpool
  \[OperationId \<String\>\]: The Guid of the operation.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection associated with the Azure resource
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ScalingPlanName \<String\>\]: The name of the scaling plan.
  \[ScalingPlanScheduleName \<String\>\]: The name of the ScalingPlanSchedule
  \[SessionHostName \<String\>\]: The name of the session host within the specified host pool
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[UserSessionId \<String\>\]: The name of the user session within the specified session host
  \[WorkspaceName \<String\>\]: The name of the workspace

UPDATESESSIONHOSTSREQUESTBODY \<IUpdateSessionHostsRequestBody\>: Object containing the definition for properties to be used for a sessionHostUpdate operation.
  \[ScheduledDateTime \<DateTime?\>\]: The timestamp that the update validation is scheduled for.
If none is provided, the update will be executed immediately
  \[ScheduledDateTimeZone \<String\>\]: The timeZone as defined in https://docs.microsoft.com/dotnet/api/system.timezoneinfo.findsystemtimezonebyid.
  \[UpdateDeleteOriginalVM \<Boolean?\>\]: Whether not to save original disk.
False by default.
  \[UpdateLogOffDelayMinute \<Int32?\>\]: Grace period before logging off users in minutes.
  \[UpdateLogOffMessage \<String\>\]: Log off message sent to user for logoff.
  \[UpdateMaxVmsRemoved \<Int32?\>\]: The maximum number of virtual machines to be removed during hostpool update.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.desktopvirtualization/invoke-azwvdinitiatesessionhostupdate](https://learn.microsoft.com/powershell/module/az.desktopvirtualization/invoke-azwvdinitiatesessionhostupdate)

