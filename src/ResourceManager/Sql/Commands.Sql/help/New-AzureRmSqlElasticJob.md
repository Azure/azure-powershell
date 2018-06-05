---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.sql/get-azurermsqlelasticjob
schema: 2.0.0
---

# New-AzureRmSqlElasticJob

## SYNOPSIS
Creates a new job

## SYNTAX

### DefaultSet (Default)
```
New-AzureRmSqlElasticJob [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-Name] <String> [-Description <String>] [-Enable] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RunOnce
```
New-AzureRmSqlElasticJob [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-Name] <String> [-RunOnce] [-StartTime <DateTime>] [-Description <String>] [-Enable]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Recurring
```
New-AzureRmSqlElasticJob [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-Name] <String> [-IntervalType] <IntervalTypes> [-IntervalCount] <UInt32> [-StartTime <DateTime>]
 [-EndTime <DateTime>] [-Description <String>] [-Enable] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ObjectSet
```
New-AzureRmSqlElasticJob [-Name] <String> [-Description <String>] [-AgentObject] <AzureSqlElasticJobAgentModel>
 [-Enable] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RunOnce using AgentObject
```
New-AzureRmSqlElasticJob [-Name] <String> [-RunOnce] [-StartTime <DateTime>] [-Description <String>]
 [-AgentObject] <AzureSqlElasticJobAgentModel> [-Enable] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Recurring using AgentObject
```
New-AzureRmSqlElasticJob [-Name] <String> [-IntervalType] <IntervalTypes> [-IntervalCount] <UInt32>
 [-StartTime <DateTime>] [-EndTime <DateTime>] [-Description <String>]
 [-AgentObject] <AzureSqlElasticJobAgentModel> [-Enable] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ResourceIdSet
```
New-AzureRmSqlElasticJob [-Name] <String> [-Description <String>] [-AgentResourceId] <String> [-Enable]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RunOnce using AgentResourceId
```
New-AzureRmSqlElasticJob [-Name] <String> [-RunOnce] [-StartTime <DateTime>] [-Description <String>]
 [-AgentResourceId] <String> [-Enable] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Recurring using AgentResourceId
```
New-AzureRmSqlElasticJob [-Name] <String> [-IntervalType] <IntervalTypes> [-IntervalCount] <UInt32>
 [-StartTime <DateTime>] [-EndTime <DateTime>] [-Description <String>] [-AgentResourceId] <String> [-Enable]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmSqlElasticJob** cmdlet creates a new job

## EXAMPLES

### Example 1 - Creates a new job
```powershell
PS C:\> $agent = Get-AzureRmSqlElasticJobAgent -ResourceGroupName rg -ServerName elasticjobserver -Name agent
$agent | New-AzureRmSqlElasticJob -Name job1

JobName Version Description StartTime           EndTime                ScheduleType Interval Enabled
------- ------- ----------- ---------           -------                ------------ -------- -------
job1    0                   6/1/2018 9:46:29 PM 12/31/9999 11:59:59 AM Once                  False
```

Creates a new job

## PARAMETERS

### -AgentName
The agent name

```yaml
Type: String
Parameter Sets: DefaultSet, RunOnce, Recurring
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgentObject
The agent input object

```yaml
Type: AzureSqlElasticJobAgentModel
Parameter Sets: ObjectSet, RunOnce using AgentObject, Recurring using AgentObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AgentResourceId
The agent resource id

```yaml
Type: String
Parameter Sets: ResourceIdSet, RunOnce using AgentResourceId, Recurring using AgentResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Parameter Sets: Recurring, Recurring using AgentObject, Recurring using AgentResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IntervalCount
The recurring schedule interval count

```yaml
Type: UInt32
Parameter Sets: Recurring, Recurring using AgentObject, Recurring using AgentResourceId
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
Type: IntervalTypes
Parameter Sets: Recurring, Recurring using AgentObject, Recurring using AgentResourceId
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
Parameter Sets: (All)
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
Parameter Sets: DefaultSet, RunOnce, Recurring
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunOnce
The flag to indicate job will be run once

```yaml
Type: SwitchParameter
Parameter Sets: RunOnce, RunOnce using AgentObject, RunOnce using AgentResourceId
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
Parameter Sets: DefaultSet, RunOnce, Recurring
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
Parameter Sets: RunOnce, Recurring, RunOnce using AgentObject, Recurring using AgentObject, RunOnce using AgentResourceId, Recurring using AgentResourceId
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

### Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobAgentModel
System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
