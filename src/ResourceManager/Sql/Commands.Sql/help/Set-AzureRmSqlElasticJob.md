---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version:
schema: 2.0.0
---

# Set-AzureRmSqlElasticJob

## SYNOPSIS
Updates a job

## SYNTAX

### Default Parameter Set (Default)
```
Set-AzureRmSqlElasticJob [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-Name] <String> [-StartTime <DateTime>] [-EndTime <DateTime>] [-Enable] [-Description <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Set Job Run Once Parameter Set
```
Set-AzureRmSqlElasticJob [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-Name] <String> [-RunOnce] [-StartTime <DateTime>] [-EndTime <DateTime>] [-Enable] [-Description <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Set Job Recurring Parameter Set
```
Set-AzureRmSqlElasticJob [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-Name] <String> [-IntervalType] <JobScheduleReccuringScheduleTypes> [-IntervalCount] <UInt32>
 [-StartTime <DateTime>] [-EndTime <DateTime>] [-Enable] [-Description <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Set Job Run Once Parameter Set Using Job Object
```
Set-AzureRmSqlElasticJob [-RunOnce] [-StartTime <DateTime>] [-EndTime <DateTime>]
 [-InputObject] <AzureSqlElasticJobModel> [-Enable] [-Description <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Set Job Run Once Parameter Set Using Job Resource Id
```
Set-AzureRmSqlElasticJob [-RunOnce] [-StartTime <DateTime>] [-EndTime <DateTime>] [-ResourceId] <String>
 [-Enable] [-Description <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Set Job Recurring Parameter Set Using Job Object
```
Set-AzureRmSqlElasticJob [-IntervalType] <JobScheduleReccuringScheduleTypes> [-IntervalCount] <UInt32>
 [-StartTime <DateTime>] [-EndTime <DateTime>] [-InputObject] <AzureSqlElasticJobModel> [-Enable]
 [-Description <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Set Job Recurring Parameter Set Using Job Resource Id
```
Set-AzureRmSqlElasticJob [-IntervalType] <JobScheduleReccuringScheduleTypes> [-IntervalCount] <UInt32>
 [-StartTime <DateTime>] [-EndTime <DateTime>] [-ResourceId] <String> [-Enable] [-Description <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Input Object Parameter Set
```
Set-AzureRmSqlElasticJob [-StartTime <DateTime>] [-EndTime <DateTime>] [-InputObject] <AzureSqlElasticJobModel>
 [-Enable] [-Description <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Resource Id Parameter Set
```
Set-AzureRmSqlElasticJob [-StartTime <DateTime>] [-EndTime <DateTime>] [-ResourceId] <String> [-Enable]
 [-Description <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmSqlElasticJob** cmdlet updates a job

## EXAMPLES

### Example 1 - Updates a job to start an hour from now and repeat every 1 hour
```powershell
PS C:\> $job | Set-AzureRmSqlElasticJob -IntervalType Hour -IntervalCount 1 -StartTime (Get-Date).AddHours(1) -Enable

JobName Version Description StartTime            EndTime                ScheduleType Interval Enabled
------- ------- ----------- ---------            -------                ------------ -------- -------
job1    0                   6/1/2018 10:50:15 PM 12/31/9999 11:59:59 AM Recurring    PT1H     True
```

Updates a job

## PARAMETERS

### -AgentName
The agent name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Set Job Run Once Parameter Set, Set Job Recurring Parameter Set
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The job description

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enable
The flag to indicate customer wants this job to be enabled.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTime
The job schedule end time

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The job input object

```yaml
Type: AzureSqlElasticJobModel
Parameter Sets: Set Job Run Once Parameter Set Using Job Object, Set Job Recurring Parameter Set Using Job Object, Input Object Parameter Set
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IntervalCount
The recurring schedule interval count

```yaml
Type: UInt32
Parameter Sets: Set Job Recurring Parameter Set, Set Job Recurring Parameter Set Using Job Object, Set Job Recurring Parameter Set Using Job Resource Id
Aliases:

Required: True
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IntervalType
The recurring schedule interval type - Can be Minute, Hour, Day, Week, Month

```yaml
Type: JobScheduleReccuringScheduleTypes
Parameter Sets: Set Job Recurring Parameter Set, Set Job Recurring Parameter Set Using Job Object, Set Job Recurring Parameter Set Using Job Resource Id
Aliases:
Accepted values: Minute, Hour, Day, Week, Month

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The job name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Set Job Run Once Parameter Set, Set Job Recurring Parameter Set
Aliases: JobName

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Set Job Run Once Parameter Set, Set Job Recurring Parameter Set
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The job resource id

```yaml
Type: String
Parameter Sets: Set Job Run Once Parameter Set Using Job Resource Id, Set Job Recurring Parameter Set Using Job Resource Id, Resource Id Parameter Set
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RunOnce
The flag to indicate job will be run once

```yaml
Type: SwitchParameter
Parameter Sets: Set Job Run Once Parameter Set, Set Job Run Once Parameter Set Using Job Object, Set Job Run Once Parameter Set Using Job Resource Id
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
The server name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Set Job Run Once Parameter Set, Set Job Recurring Parameter Set
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
The job schedule start time

```yaml
Type: DateTime
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobModel
System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
