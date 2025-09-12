---
external help file:
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/update-azstoragemoveragent
schema: 2.0.0
---

# Update-AzStorageMoverAgent

## SYNOPSIS
Update an Agent resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageMoverAgent -Name <String> -ResourceGroupName <String> -StorageMoverName <String>
 [-SubscriptionId <String>] [-Description <String>]
 [-UploadLimitScheduleWeeklyRecurrence <IUploadLimitWeeklyRecurrence[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageMoverAgent -InputObject <IStorageMoverIdentity> [-Description <String>]
 [-UploadLimitScheduleWeeklyRecurrence <IUploadLimitWeeklyRecurrence[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityStorageMoverExpanded
```
Update-AzStorageMoverAgent -Name <String> -StorageMoverInputObject <IStorageMoverIdentity>
 [-Description <String>] [-UploadLimitScheduleWeeklyRecurrence <IUploadLimitWeeklyRecurrence[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzStorageMoverAgent -Name <String> -ResourceGroupName <String> -StorageMoverName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzStorageMoverAgent -Name <String> -ResourceGroupName <String> -StorageMoverName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update an Agent resource.

## EXAMPLES

### Example 1: Update an agent 
```powershell
$recurrence = New-AzStorageMoverUploadLimitWeeklyRecurrenceObject -Day 'Monday','Tuesday','Friday' -LimitInMbps 100 -EndTimeHour 5 -StartTimeHour 1 -StartTimeMinute 30 -EndTimeMinute 0
Update-AzStorageMoverAgent -ResourceGroupName myresourcegroup -StorageMoverName mystoragemover -Name myagent -Description "Update description" -UploadLimitScheduleWeeklyRecurrence $recurrence
```

```output
AgentStatus                         : Online
ArcResourceId                       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.HybridCompute/machines/myagent
ArcVMUuid                           : 00000000-0000-0000-0000-000000000000
Description                         : Update description
ErrorDetailCode                     :
ErrorDetailMessage                  :
Id                                  : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/agents/myagent
LastStatusUpdate                    : 6/12/2024 5:57:45 AM
LocalIPAddress                      : 000.000.000.00
MemoryInMb                          : 1470
Name                                : myagent
NumberOfCores                       : 8
ProvisioningState                   : Succeeded
SystemDataCreatedAt                 : 6/12/2024 5:47:26 AM
SystemDataCreatedBy                 : example@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 6/12/2024 5:57:54 AM
SystemDataLastModifiedBy            : example@microsoft.com
SystemDataLastModifiedByType        : User
TimeZone                            : UTC
Type                                : microsoft.storagemover/storagemovers/agents
UploadLimitScheduleWeeklyRecurrence : {{
                                        "startTime": {
                                          "hour": 1,
                                          "minute": 30
                                        },
                                        "endTime": {
                                          "hour": 5,
                                          "minute": 0
                                        },
                                        "days": [ "Monday", "Tuesday", "Friday" ],
                                        "limitInMbps": 100
                                      }}
UptimeInSeconds                     : 3417
Version                             : 
```

This command updates the description and the upload limit weekly recurrence of an agent.

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

### -Description
A description for the Agent.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Agent resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityStorageMoverExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: AgentName

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageMoverInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
Parameter Sets: UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageMoverName
The name of the Storage Mover resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UploadLimitScheduleWeeklyRecurrence
The set of weekly repeating recurrences of the WAN-link upload limit schedule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IUploadLimitWeeklyRecurrence[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityStorageMoverExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IAgent

## NOTES

## RELATED LINKS

