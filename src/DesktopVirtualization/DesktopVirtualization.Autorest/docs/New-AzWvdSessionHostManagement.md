---
external help file:
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/new-azwvdsessionhostmanagement
schema: 2.0.0
---

# New-AzWvdSessionHostManagement

## SYNOPSIS
Create a SessionHostManagement.

## SYNTAX

### CreateExpanded (Default)
```
New-AzWvdSessionHostManagement -HostPoolName <String> -ResourceGroupName <String>
 -ScheduledDateTimeZone <String> -UpdateLogOffDelayMinute <Int32> -UpdateMaxVmsRemoved <Int32>
 [-SubscriptionId <String>] [-FailedSessionHostCleanupPolicy <String>] [-ProvisioningCanaryPolicy <String>]
 [-ProvisioningInstanceCount <Int32>] [-ProvisioningSetDrainMode] [-UpdateDeleteOriginalVM]
 [-UpdateLogOffMessage <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzWvdSessionHostManagement -HostPoolName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzWvdSessionHostManagement -HostPoolName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a SessionHostManagement.

## EXAMPLES

### Example 1: Create a Azure Virtual Desktop SessionHostManagement by HostPool Name
```powershell
New-AzWvdSessionHostManagement -ResourceGroupName ResourceGroupName `
                            -HostPoolName HostPoolName `
                            -ScheduledDateTimeZone "Alaskan Standard Time" `
                            -UpdateDeleteOriginalVm `
                            -UpdateMaxVmsRemoved 4 `
                            -UpdateLogOffDelayMinute 5 `
                            -UpdateLogOffMessage "logging off for hostpool update."
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     default Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements
```

This command creates a Azure Virtual Desktop SessionHostManagement on a HostPool.

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

### -FailedSessionHostCleanupPolicy
The policy that should be applied when the Session Host provisioning operation fails.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostPoolName
The name of the host pool within the specified resource group

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningCanaryPolicy
Policy on whether a Canary VM should be provisioned during a session host provisioning operation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningInstanceCount
the number of session hosts to exist in the Host Pool.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningSetDrainMode
Whether the session host should be set in drain mode following provisioning.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduledDateTimeZone
Time zone for sessionHostManagement operations as defined in https://docs.microsoft.com/dotnet/api/system.timezoneinfo.findsystemtimezonebyid.
Must be set if useLocalTime is true.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateLogOffMessage
Log off message sent to user for logoff.
Default value is an empty string.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: True
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.ISessionHostManagement

## NOTES

## RELATED LINKS

