---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version:
schema: 2.0.0
---

# Add-AzureRmSqlElasticJobStep

## SYNOPSIS
Adds a job step to a job

## SYNTAX

### Default Parameter Set (Default)
```
Add-AzureRmSqlElasticJobStep [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-JobName] <String> [-Name] <String> [-TargetGroupName] <String> [-CredentialName] <String>
 [-CommandText] <String> [-TimeoutSeconds <Int32>] [-RetryAttempts <Int32>]
 [-InitialRetryIntervalSeconds <Int32>] [-MaximumRetryIntervalSeconds <Int32>]
 [-RetryIntervalBackoffMultiplier <Double>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Add Job Step With Output Database Object Parameter Set
```
Add-AzureRmSqlElasticJobStep [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-JobName] <String> [-Name] <String> [-TargetGroupName] <String> [-CredentialName] <String>
 [-CommandText] <String> [-OutputDatabaseObject] <AzureSqlDatabaseModel> [-OutputCredentialName] <String>
 [-OutputTableName] <String> [[-OutputSchemaName] <String>] [-TimeoutSeconds <Int32>] [-RetryAttempts <Int32>]
 [-InitialRetryIntervalSeconds <Int32>] [-MaximumRetryIntervalSeconds <Int32>]
 [-RetryIntervalBackoffMultiplier <Double>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Add Job Step With Output Database Resource Id Parameter Set
```
Add-AzureRmSqlElasticJobStep [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-JobName] <String> [-Name] <String> [-TargetGroupName] <String> [-CredentialName] <String>
 [-CommandText] <String> [-OutputDatabaseResourceId] <String> [-OutputCredentialName] <String>
 [-OutputTableName] <String> [[-OutputSchemaName] <String>] [-TimeoutSeconds <Int32>] [-RetryAttempts <Int32>]
 [-InitialRetryIntervalSeconds <Int32>] [-MaximumRetryIntervalSeconds <Int32>]
 [-RetryIntervalBackoffMultiplier <Double>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Input Object Parameter Set
```
Add-AzureRmSqlElasticJobStep [-Name] <String> [-TargetGroupName] <String> [-CredentialName] <String>
 [-CommandText] <String> [-TimeoutSeconds <Int32>] [-RetryAttempts <Int32>]
 [-InitialRetryIntervalSeconds <Int32>] [-MaximumRetryIntervalSeconds <Int32>]
 [-RetryIntervalBackoffMultiplier <Double>] [-JobObject] <AzureSqlElasticJobModel>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Add Job Step With Output Database Object Parameter Set Using Job Object
```
Add-AzureRmSqlElasticJobStep [-Name] <String> [-TargetGroupName] <String> [-CredentialName] <String>
 [-CommandText] <String> [-OutputDatabaseObject] <AzureSqlDatabaseModel> [-OutputCredentialName] <String>
 [-OutputTableName] <String> [[-OutputSchemaName] <String>] [-TimeoutSeconds <Int32>] [-RetryAttempts <Int32>]
 [-InitialRetryIntervalSeconds <Int32>] [-MaximumRetryIntervalSeconds <Int32>]
 [-RetryIntervalBackoffMultiplier <Double>] [-JobObject] <AzureSqlElasticJobModel>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Add Job Step With Output Database Id Parameter Set Using Job Object
```
Add-AzureRmSqlElasticJobStep [-Name] <String> [-TargetGroupName] <String> [-CredentialName] <String>
 [-CommandText] <String> [-OutputDatabaseResourceId] <String> [-OutputCredentialName] <String>
 [-OutputTableName] <String> [[-OutputSchemaName] <String>] [-TimeoutSeconds <Int32>] [-RetryAttempts <Int32>]
 [-InitialRetryIntervalSeconds <Int32>] [-MaximumRetryIntervalSeconds <Int32>]
 [-RetryIntervalBackoffMultiplier <Double>] [-JobObject] <AzureSqlElasticJobModel>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Resource Id Parameter Set
```
Add-AzureRmSqlElasticJobStep [-Name] <String> [-TargetGroupName] <String> [-CredentialName] <String>
 [-CommandText] <String> [-TimeoutSeconds <Int32>] [-RetryAttempts <Int32>]
 [-InitialRetryIntervalSeconds <Int32>] [-MaximumRetryIntervalSeconds <Int32>]
 [-RetryIntervalBackoffMultiplier <Double>] [-JobResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Add Job Step With Output Database Object Parameter Set Using Job Resource Id
```
Add-AzureRmSqlElasticJobStep [-Name] <String> [-TargetGroupName] <String> [-CredentialName] <String>
 [-CommandText] <String> [-OutputDatabaseObject] <AzureSqlDatabaseModel> [-OutputCredentialName] <String>
 [-OutputTableName] <String> [[-OutputSchemaName] <String>] [-TimeoutSeconds <Int32>] [-RetryAttempts <Int32>]
 [-InitialRetryIntervalSeconds <Int32>] [-MaximumRetryIntervalSeconds <Int32>]
 [-RetryIntervalBackoffMultiplier <Double>] [-JobResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Add Job Step With Output Database Id Parameter Set Using Job Resource Id
```
Add-AzureRmSqlElasticJobStep [-Name] <String> [-TargetGroupName] <String> [-CredentialName] <String>
 [-CommandText] <String> [-OutputDatabaseResourceId] <String> [-OutputCredentialName] <String>
 [-OutputTableName] <String> [[-OutputSchemaName] <String>] [-TimeoutSeconds <Int32>] [-RetryAttempts <Int32>]
 [-InitialRetryIntervalSeconds <Int32>] [-MaximumRetryIntervalSeconds <Int32>]
 [-RetryIntervalBackoffMultiplier <Double>] [-JobResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmSqlElasticJobStep** cmdlet adds a job step to a job

## EXAMPLES

### Example 1 - Adds a step to a job
```powershell
PS C:\> > $job | Add-AzureRmSqlElasticJobStep -Name step1 -TargetGroupName tg1 -CredentialName cred1 -CommandText "SELECT 1"

JobName StepName StepId TargetGroupName CredentialName Output ExecutionOptions   CommandText
------- -------- ------ --------------- -------------- ------ ----------------   -----------
job1    step1    1      tg1             cred1                 (43200,10,1,120,2) SELECT 1
```

Adds a job step to a job

## PARAMETERS

### -AgentName
The agent name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Add Job Step With Output Database Object Parameter Set, Add Job Step With Output Database Resource Id Parameter Set
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommandText
The command text

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CredentialName
The credential name

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 6
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

### -InitialRetryIntervalSeconds
The initial retry interval seconds

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobName
The job name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Add Job Step With Output Database Object Parameter Set, Add Job Step With Output Database Resource Id Parameter Set
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobObject
The job object

```yaml
Type: AzureSqlElasticJobModel
Parameter Sets: Input Object Parameter Set, Add Job Step With Output Database Object Parameter Set Using Job Object, Add Job Step With Output Database Id Parameter Set Using Job Object
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobResourceId
The job resource id

```yaml
Type: String
Parameter Sets: Resource Id Parameter Set, Add Job Step With Output Database Object Parameter Set Using Job Resource Id, Add Job Step With Output Database Id Parameter Set Using Job Resource Id
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaximumRetryIntervalSeconds
The maximum retry interval seconds

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The job step name

```yaml
Type: String
Parameter Sets: (All)
Aliases: StepName

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputCredentialName
The output credential name

```yaml
Type: String
Parameter Sets: Add Job Step With Output Database Object Parameter Set, Add Job Step With Output Database Resource Id Parameter Set, Add Job Step With Output Database Object Parameter Set Using Job Object, Add Job Step With Output Database Id Parameter Set Using Job Object, Add Job Step With Output Database Object Parameter Set Using Job Resource Id, Add Job Step With Output Database Id Parameter Set Using Job Resource Id
Aliases:

Required: True
Position: 9
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputDatabaseObject
The output database object

```yaml
Type: AzureSqlDatabaseModel
Parameter Sets: Add Job Step With Output Database Object Parameter Set, Add Job Step With Output Database Object Parameter Set Using Job Object, Add Job Step With Output Database Object Parameter Set Using Job Resource Id
Aliases:

Required: True
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputDatabaseResourceId
The output database resource id

```yaml
Type: String
Parameter Sets: Add Job Step With Output Database Resource Id Parameter Set, Add Job Step With Output Database Id Parameter Set Using Job Object, Add Job Step With Output Database Id Parameter Set Using Job Resource Id
Aliases:

Required: True
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputSchemaName
The output schema name

```yaml
Type: String
Parameter Sets: Add Job Step With Output Database Object Parameter Set, Add Job Step With Output Database Resource Id Parameter Set, Add Job Step With Output Database Object Parameter Set Using Job Object, Add Job Step With Output Database Id Parameter Set Using Job Object, Add Job Step With Output Database Object Parameter Set Using Job Resource Id, Add Job Step With Output Database Id Parameter Set Using Job Resource Id
Aliases:

Required: False
Position: 11
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputTableName
The output table name

```yaml
Type: String
Parameter Sets: Add Job Step With Output Database Object Parameter Set, Add Job Step With Output Database Resource Id Parameter Set, Add Job Step With Output Database Object Parameter Set Using Job Object, Add Job Step With Output Database Id Parameter Set Using Job Object, Add Job Step With Output Database Object Parameter Set Using Job Resource Id, Add Job Step With Output Database Id Parameter Set Using Job Resource Id
Aliases:

Required: True
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Add Job Step With Output Database Object Parameter Set, Add Job Step With Output Database Resource Id Parameter Set
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryAttempts
The retry attempts

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryIntervalBackoffMultiplier
The retry interval back off multiplier

```yaml
Type: Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
The server name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Add Job Step With Output Database Object Parameter Set, Add Job Step With Output Database Resource Id Parameter Set
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetGroupName
The target group name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Add Job Step With Output Database Object Parameter Set, Add Job Step With Output Database Resource Id Parameter Set, Input Object Parameter Set, Add Job Step With Output Database Object Parameter Set Using Job Object, Add Job Step With Output Database Id Parameter Set Using Job Object, Resource Id Parameter Set, Add Job Step With Output Database Id Parameter Set Using Job Resource Id
Aliases:

Required: True
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Add Job Step With Output Database Object Parameter Set Using Job Resource Id
Aliases:

Required: True
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeoutSeconds
The time out seconds

```yaml
Type: Int32
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

### System.String
Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobModel

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobStepModel

## NOTES

## RELATED LINKS
