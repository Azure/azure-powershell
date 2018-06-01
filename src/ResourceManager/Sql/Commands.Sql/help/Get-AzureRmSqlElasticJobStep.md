---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version:
schema: 2.0.0
---

# Get-AzureRmSqlElasticJobStep

## SYNOPSIS
Gets one or more job steps

## SYNTAX

### Default Parameter Set (Default)
```
Get-AzureRmSqlElasticJobStep [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-JobName] <String> [-Name <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Get Job Step Version Parameter Set
```
Get-AzureRmSqlElasticJobStep [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-JobName] <String> -Name <String> [-Version] <Int32> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Input Object Parameter Set
```
Get-AzureRmSqlElasticJobStep [-Name <String>] [-JobObject] <AzureSqlElasticJobModel>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Get Job Step Version Parameter Set Using Job Object
```
Get-AzureRmSqlElasticJobStep -Name <String> [-Version] <Int32> [-JobObject] <AzureSqlElasticJobModel>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Resource Id Parameter Set
```
Get-AzureRmSqlElasticJobStep [-Name <String>] [-JobResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Get Job Step Version Parameter Set Using Job Resource Id
```
Get-AzureRmSqlElasticJobStep -Name <String> [-Version] <Int32> [-JobResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmSqlElasticJobStep** cmdlet gets one or more job steps from a job

## EXAMPLES

### Example 1 - Gets a job step from a job
```powershell
PS C:\> $job | Get-AzureRmSqlElasticJobStep -Name step1

JobName StepName StepId TargetGroupName CredentialName Output ExecutionOptions   CommandText
------- -------- ------ --------------- -------------- ------ ----------------   -----------
job1    step1    1      tg1             cred1                 (43200,10,1,120,2) SELECT 1
```

Gets a job step from a job

## PARAMETERS

### -AgentName
The agent name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Get Job Step Version Parameter Set
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

### -JobName
The job name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Get Job Step Version Parameter Set
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobObject
The job input object

```yaml
Type: AzureSqlElasticJobModel
Parameter Sets: Input Object Parameter Set, Get Job Step Version Parameter Set Using Job Object
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
Parameter Sets: Resource Id Parameter Set, Get Job Step Version Parameter Set Using Job Resource Id
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The job step name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Input Object Parameter Set, Resource Id Parameter Set
Aliases: StepName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Get Job Step Version Parameter Set, Get Job Step Version Parameter Set Using Job Object, Get Job Step Version Parameter Set Using Job Resource Id
Aliases: StepName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Get Job Step Version Parameter Set
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
The server name

```yaml
Type: String
Parameter Sets: Default Parameter Set, Get Job Step Version Parameter Set
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The job step name

```yaml
Type: Int32
Parameter Sets: Get Job Step Version Parameter Set
Aliases:

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: Int32
Parameter Sets: Get Job Step Version Parameter Set Using Job Object
Aliases:

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: Int32
Parameter Sets: Get Job Step Version Parameter Set Using Job Resource Id
Aliases:

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobModel
System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobStepModel
Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobStepVersionModel
System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobStepModel, Microsoft.Azure.Commands.Sql, Version=4.4.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
