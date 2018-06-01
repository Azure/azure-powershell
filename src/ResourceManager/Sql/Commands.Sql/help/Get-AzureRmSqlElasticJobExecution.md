---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version:
schema: 2.0.0
---

# Get-AzureRmSqlElasticJobExecution

## SYNOPSIS
Gets one or more job executions

## SYNTAX

### Default Parameter Set (Default)
```
Get-AzureRmSqlElasticJobExecution [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-Count] <Int32> [-JobName <String>] [-CreateTimeMin <DateTime>] [-CreateTimeMax <DateTime>]
 [-EndTimeMin <DateTime>] [-EndTimeMax <DateTime>] [-Active] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Get Job Execution Parameter Set
```
Get-AzureRmSqlElasticJobExecution [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 -JobName <String> [-JobExecutionId] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Input Object Parameter Set
```
Get-AzureRmSqlElasticJobExecution [-Count] <Int32> [-JobName <String>] [-CreateTimeMin <DateTime>]
 [-CreateTimeMax <DateTime>] [-EndTimeMin <DateTime>] [-EndTimeMax <DateTime>] [-Active]
 [-AgentObject] <AzureSqlElasticJobAgentModel> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Resource Id Parameter Set
```
Get-AzureRmSqlElasticJobExecution [-Count] <Int32> [-JobName <String>] [-CreateTimeMin <DateTime>]
 [-CreateTimeMax <DateTime>] [-EndTimeMin <DateTime>] [-EndTimeMax <DateTime>] [-Active]
 [-AgentResourceId] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Get Job Execution Parameter Set Using Agent Object
```
Get-AzureRmSqlElasticJobExecution -JobName <String> [-JobExecutionId] <String>
 [-AgentObject] <AzureSqlElasticJobAgentModel> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Get Job Execution Parameter Set using Agent Resource Id
```
Get-AzureRmSqlElasticJobExecution -JobName <String> [-JobExecutionId] <String> [-AgentResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmSqlElasticJobExecution** cmdlet gets one or more job executions

## EXAMPLES

### Example 1 - Gets one or more job executions across all jobs
```powershell
PS C:\> $agent | Get-AzureRmSqlElasticJobExecution -Count 3

JobName JobExecutionId                       Lifecycle StartTime            EndTime
------- --------------                       --------- ---------            -------
job1    dab0ebe8-fd52-42e9-bacf-e5f27577039b Canceled  6/1/2018 10:13:56 PM 6/1/2018 10:13:59 PM
job1    3bcfc912-20b2-411d-a2b7-6265d13fe272 Succeeded 6/1/2018 10:11:43 PM 6/1/2018 10:11:47 PM
job2    433f798e-f35c-41de-a23c-f2b43801d7b4 Succeeded 6/1/2018 10:11:36 PM 6/1/2018 10:11:41 PM
```

### Example 2 - Gets one or more job executions for a job
```powershell
PS C:\> $agent | Get-AzureRmSqlElasticJobExecution -Count 3 -JobName job2

JobName JobExecutionId                       Lifecycle StartTime            EndTime
------- --------------                       --------- ---------            -------
job2    433f798e-f35c-41de-a23c-f2b43801d7b4 Succeeded 6/1/2018 10:11:36 PM 6/1/2018 10:11:41 PM
```

Gets one or more job executions

## PARAMETERS

### -Active
Filter by create time min

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
Parameter Sets: Default Parameter Set, Get Job Execution Parameter Set
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgentObject
The job execution id.

```yaml
Type: AzureSqlElasticJobAgentModel
Parameter Sets: Input Object Parameter Set, Get Job Execution Parameter Set Using Agent Object
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AgentResourceId
The agent resource id.

```yaml
Type: String
Parameter Sets: Resource Id Parameter Set, Get Job Execution Parameter Set using Agent Resource Id
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Count
Count returns the top number of executions.

```yaml
Type: Int32
Parameter Sets: Default Parameter Set, Input Object Parameter Set, Resource Id Parameter Set
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreateTimeMax
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

### -EndTimeMin
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

### -JobExecutionId
The job execution id.

```yaml
Type: String
Parameter Sets: Get Job Execution Parameter Set, Get Job Execution Parameter Set Using Agent Object, Get Job Execution Parameter Set using Agent Resource Id
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobName
The job name.

```yaml
Type: String
Parameter Sets: Default Parameter Set, Input Object Parameter Set, Resource Id Parameter Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Get Job Execution Parameter Set, Get Job Execution Parameter Set Using Agent Object, Get Job Execution Parameter Set using Agent Resource Id
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: Default Parameter Set, Get Job Execution Parameter Set
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
Parameter Sets: Default Parameter Set, Get Job Execution Parameter Set
Aliases:

Required: True
Position: 1
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

### System.Collections.Generic.IEnumerable`1[[Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobExecutionModel, Microsoft.Azure.Commands.Sql, Version=4.4.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
