---
external help file: Az.Commvault-help.xml
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/new-azcommvaultplan
schema: 2.0.0
---

# New-AzCommvaultPlan

## SYNOPSIS
Create a CommvaultPlan

## SYNTAX

### CreateExpanded (Default)
```
New-AzCommvaultPlan -PlanName <String> -CloudAccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Location <String>] [-RetentionNumberOfSnapshot <Int32>] [-Schedule <ISchedule[]>]
 [-StoragePlan <IStoragePlan[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzCommvaultPlan -PlanName <String> -CloudAccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzCommvaultPlan -PlanName <String> -CloudAccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityCloudAccountExpanded
```
New-AzCommvaultPlan -PlanName <String> -CloudAccountInputObject <ICommvaultIdentity> [-Location <String>]
 [-RetentionNumberOfSnapshot <Int32>] [-Schedule <ISchedule[]>] [-StoragePlan <IStoragePlan[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a CommvaultPlan

## EXAMPLES

### Example 1: Create a backup plan
```powershell
$storagePlan = @{ Name = 'primary'; StoragePoolId = 'storage-hot'; CopyName = 'primary-copy'; CopyPrecedence = 1; RetentionPeriod = 30; RetentionTime = 'monthly'; BackupRuleType = 'ALL_JOBS' }
$schedule = @{ BackupType = 'INCREMENTAL'; Frequency = 'daily'; RunsEvery = 1; Time = '22:00'; TimeZone = 'UTC' }
New-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -PlanName plan-daily -Location eastus -StoragePlan $storagePlan -Schedule $schedule -RetentionNumberOfSnapshot 7
```

Creates a backup plan that runs an incremental backup every day and keeps seven snapshots.

### Example 2: Create a backup plan by using a JSON file
```powershell
New-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -PlanName plan-daily -JsonFilePath '.\plan.json'
```

Creates a backup plan from the request body in the JSON file.

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

### -CloudAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: CreateViaIdentityCloudAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CloudAccountName
Name of the Cloud Account resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
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

### -Location
Location of the Commvault Plan

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityCloudAccountExpanded
Aliases:

Required: False
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

### -PlanName
Name of the Plan resource

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionNumberOfSnapshot
Number of Snapshots

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityCloudAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Schedule
The Commvault Plan Schedule

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ISchedule[]
Parameter Sets: CreateExpanded, CreateViaIdentityCloudAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StoragePlan
The storage plans associated with the Commvault Plan

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IStoragePlan[]
Parameter Sets: CreateExpanded, CreateViaIdentityCloudAccountExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultPlan

## NOTES

## RELATED LINKS
