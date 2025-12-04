---
external help file:
Module Name: Az.DurableTask
online version: https://learn.microsoft.com/powershell/module/az.durabletask/get-azdurabletaskhub
schema: 2.0.0
---

# Get-AzDurableTaskHub

## SYNOPSIS
Get a Task Hub

## SYNTAX

### List (Default)
```
Get-AzDurableTaskHub -ResourceGroupName <String> -SchedulerName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDurableTaskHub -Name <String> -ResourceGroupName <String> -SchedulerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDurableTaskHub -InputObject <IDurableTaskIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityScheduler
```
Get-AzDurableTaskHub -Name <String> -SchedulerInputObject <IDurableTaskIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Task Hub

## EXAMPLES

### Example 1: List all task hubs for a scheduler
```powershell
Get-AzDurableTaskHub -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
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

Lists all task hubs for a specific Durable Task scheduler.

### Example 2: Get a specific task hub by name
```powershell
Get-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
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

Gets the details of a specific task hub by name.

### Example 3: Get a task hub using pipeline input
```powershell
$taskHub = Get-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
$taskHub | Get-AzDurableTaskHub
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

Gets a task hub using pipeline input (GetViaIdentity parameter set).

### Example 4: Get a task hub with scheduler input object
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
Get-AzDurableTaskHub -Name "testtaskhub" -SchedulerInputObject $scheduler
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

Gets a task hub using a scheduler input object (GetViaIdentityScheduler parameter set).

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DurableTask.Models.IDurableTaskIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the TaskHub

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityScheduler
Aliases: TaskHubName

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
Parameter Sets: Get, List
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
Parameter Sets: GetViaIdentityScheduler
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

