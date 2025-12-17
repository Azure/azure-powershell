---
external help file:
Module Name: Az.DurableTask
online version: https://learn.microsoft.com/powershell/module/az.durabletask/new-azdurabletaskhub
schema: 2.0.0
---

# New-AzDurableTaskHub

## SYNOPSIS
Create a Task Hub

## SYNTAX

### CreateExpanded (Default)
```
New-AzDurableTaskHub -Name <String> -ResourceGroupName <String> -SchedulerName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentitySchedulerExpanded
```
New-AzDurableTaskHub -Name <String> -SchedulerInputObject <IDurableTaskIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDurableTaskHub -Name <String> -ResourceGroupName <String> -SchedulerName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDurableTaskHub -Name <String> -ResourceGroupName <String> -SchedulerName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Task Hub

## EXAMPLES

### Example 1: Create a new task hub
```powershell
New-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Creates a new task hub in a Durable Task scheduler.

### Example 2: Create a task hub with scheduler input object
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
New-AzDurableTaskHub -Name "testtaskhub" -SchedulerInputObject $scheduler
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Creates a new task hub using a scheduler input object (CreateViaIdentitySchedulerExpanded parameter set).

### Example 3: Create a task hub from JSON file
```powershell
New-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler" -JsonFilePath "./taskhub.json"
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Creates a new task hub using a JSON configuration file.

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

### -Name
The name of the TaskHub

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: TaskHubName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchedulerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DurableTask.Models.IDurableTaskIdentity
Parameter Sets: CreateViaIdentitySchedulerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SchedulerName
The name of the Scheduler

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.DurableTask.Models.IDurableTaskIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DurableTask.Models.ITaskHub

## NOTES

## RELATED LINKS

