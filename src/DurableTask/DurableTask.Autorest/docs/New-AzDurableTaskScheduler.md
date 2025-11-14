---
external help file:
Module Name: Az.DurableTask
online version: https://learn.microsoft.com/powershell/module/az.durabletask/new-azdurabletaskscheduler
schema: 2.0.0
---

# New-AzDurableTaskScheduler

## SYNOPSIS
Create a Scheduler

## SYNTAX

### CreateExpanded (Default)
```
New-AzDurableTaskScheduler -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-IPAllowlist <String[]>] [-SkuCapacity <Int32>] [-SkuName <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDurableTaskScheduler -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDurableTaskScheduler -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Scheduler

## EXAMPLES

### Example 1: Create a new Durable Task scheduler with basic settings
```powershell
New-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -Location "northcentralus" -SkuCapacity 3 -SkuName "Dedicated" -IPAllowlist @("10.0.0.0/8") -Tag @{department="research"; development="true"}
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Creates a new Durable Task scheduler with Dedicated SKU, IP allowlist, and tags.
Output shows all returned properties.

### Example 2: Create a scheduler with JSON file
```powershell
New-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -JsonFilePath "./scheduler.json"
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Creates a Durable Task scheduler using a JSON configuration file.
Output shows full resource details.

### Example 3: Create a scheduler with capacity configuration
```powershell
New-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -Location "northcentralus" -SkuName "Dedicated" -SkuCapacity 1
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {0.0.0.0/0}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 1
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Creates a Durable Task scheduler with a specific SKU capacity and shows the full returned object.

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

### -IPAllowlist
IP allow list for durable task scheduler.
Values can be IPv4, IPv6 or CIDR

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

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

### -Location
The geo-location where the resource lives

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

### -Name
The name of the Scheduler

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SchedulerName

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
The SKU capacity.
This allows scale out/in for the resource and impacts zone redundancy

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

### -SkuName
The name of the SKU

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

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DurableTask.Models.IScheduler

## NOTES

## RELATED LINKS

