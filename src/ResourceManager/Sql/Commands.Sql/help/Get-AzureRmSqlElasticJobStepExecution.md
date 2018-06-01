---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version:
schema: 2.0.0
---

# Get-AzureRmSqlElasticJobStepExecution

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### Default Parameter Set (Default)
```
Get-AzureRmSqlElasticJobStepExecution [-ResourceGroupName] <String> [-ServerName] <String>
 [-AgentName] <String> [-JobName] <String> [-JobExecutionId] <String> [-CreateTimeMin <DateTime>]
 [-CreateTimeMax <DateTime>] [-EndTimeMin <DateTime>] [-EndTimeMax <DateTime>] [-Active]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Get Job Step Execution Parameter Set
```
Get-AzureRmSqlElasticJobStepExecution [-ResourceGroupName] <String> [-ServerName] <String>
 [-AgentName] <String> [-JobName] <String> [-JobExecutionId] <String> [-StepName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Get Job Step Execution Parameter Set Using Job Execution Object
```
Get-AzureRmSqlElasticJobStepExecution [-StepName] <String>
 [-JobExecutionObject] <AzureSqlElasticJobExecutionModel> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Get Job Step Execution Parameter Set Using Job Execution Resource Id
```
Get-AzureRmSqlElasticJobStepExecution [-StepName] <String> [-JobExecutionResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Input Object Parameter Set
```
Get-AzureRmSqlElasticJobStepExecution [-CreateTimeMin <DateTime>] [-CreateTimeMax <DateTime>]
 [-EndTimeMin <DateTime>] [-EndTimeMax <DateTime>] [-Active]
 [-JobExecutionObject] <AzureSqlElasticJobExecutionModel> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Resource Id Parameter Set
```
Get-AzureRmSqlElasticJobStepExecution [-CreateTimeMin <DateTime>] [-CreateTimeMax <DateTime>]
 [-EndTimeMin <DateTime>] [-EndTimeMax <DateTime>] [-Active] [-JobExecutionResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmSqlElasticJobStepExecution** cmdlet gets one or more job step executions from a job execution

## EXAMPLES

### Example 1 - Gets one or more job step executions from a job executions
```powershell
PS C:\> $je | Get-AzureRmSqlElasticJobStepExecution

JobName JobVersion StepName StepId JobExecutionId                       Lifecycle StartTime            EndTime
------- ---------- -------- ------ --------------                       --------- ---------            -------
job1    1          step1    1      3bcfc912-20b2-411d-a2b7-6265d13fe272 Succeeded 6/1/2018 10:11:44 PM 6/1/2018 10:11:47 PM
```

### Example 2 - Gets one or more job step executions from a job execution, filtering by step name
```powershell
PS C:\> $je | Get-AzureRmSqlElasticJobStepExecution -StepName step1

JobName JobVersion StepName StepId JobExecutionId                       Lifecycle StartTime            EndTime
------- ---------- -------- ------ --------------                       --------- ---------            -------
job1    1          step1    1      3bcfc912-20b2-411d-a2b7-6265d13fe272 Succeeded 6/1/2018 10:11:44 PM 6/1/2018 10:11:47 PM
```

Gets one or more job step executions

## PARAMETERS

### -Active
Flag to filter by active executions.

```yaml
Type: SwitchParameter
Parameter Sets: Default Parameter Set, Input Object Parameter Set, Resource Id Parameter Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgentName
The agent name.

```yaml
Type: String
Parameter Sets: Default Parameter Set, Get Job Step Execution Parameter Set
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreateTimeMax
Filter by create time max

```yaml
Type: DateTime
Parameter Sets: Default Parameter Set, Input Object Parameter Set, Resource Id Parameter Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreateTimeMin
Filter by create time min

```yaml
Type: DateTime
Parameter Sets: Default Parameter Set, Input Object Parameter Set, Resource Id Parameter Set
Aliases:

Required: False
Position: Named
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

### -EndTimeMax
Filter by end time max.

```yaml
Type: DateTime
Parameter Sets: Default Parameter Set, Input Object Parameter Set, Resource Id Parameter Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTimeMin
Filter by end time min.

```yaml
Type: DateTime
Parameter Sets: Default Parameter Set, Input Object Parameter Set, Resource Id Parameter Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobExecutionId
The job execution id.

```yaml
Type: String
Parameter Sets: Default Parameter Set, Get Job Step Execution Parameter Set
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobExecutionObject
The agent object.

```yaml
Type: AzureSqlElasticJobExecutionModel
Parameter Sets: Get Job Step Execution Parameter Set Using Job Execution Object, Input Object Parameter Set
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobExecutionResourceId
The job execution resource id.

```yaml
Type: String
Parameter Sets: Get Job Step Execution Parameter Set Using Job Execution Resource Id, Resource Id Parameter Set
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -JobName
The job name.

```yaml
Type: String
Parameter Sets: Default Parameter Set, Get Job Step Execution Parameter Set
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: Default Parameter Set, Get Job Step Execution Parameter Set
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
The server name.

```yaml
Type: String
Parameter Sets: Default Parameter Set, Get Job Step Execution Parameter Set
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StepName
The job step name.

```yaml
Type: String
Parameter Sets: Get Job Step Execution Parameter Set, Get Job Step Execution Parameter Set Using Job Execution Object, Get Job Step Execution Parameter Set Using Job Execution Resource Id
Aliases:

Required: True
Position: 5
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

### Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobExecutionModel
System.String

## OUTPUTS

### System.Collections.Generic.IEnumerable`1[[Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobExecutionModel, Microsoft.Azure.Commands.Sql, Version=4.5.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
