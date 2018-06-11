---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.sql/remove-azurermsqlelasticjobtarget
schema: 2.0.0
---

# Remove-AzureRmSqlElasticJobTarget

## SYNOPSIS
Removes the target from the target group

## SYNTAX

### Sql Database Target Type (Default)
```
Remove-AzureRmSqlElasticJobTarget [-ResourceGroupName] <String> [-AgentServerName] <String>
 [-AgentName] <String> [-TargetGroupName] <String> [-ServerName] <String> [-DatabaseName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Sql Database Input Object Parameter Set
```
Remove-AzureRmSqlElasticJobTarget -ParentObject <AzureSqlElasticJobTargetGroupModel> [-ServerName] <String>
 [-DatabaseName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Sql Server or Elastic Pool Input Object Parameter Set
```
Remove-AzureRmSqlElasticJobTarget -ParentObject <AzureSqlElasticJobTargetGroupModel> [-ServerName] <String>
 [-ElasticPoolName <String>] [-RefreshCredentialName] <String> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Sql Shard Map Input Object Parameter Set
```
Remove-AzureRmSqlElasticJobTarget -ParentObject <AzureSqlElasticJobTargetGroupModel> [-ServerName] <String>
 [-ShardMapName] <String> [-DatabaseName] <String> [-RefreshCredentialName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Sql Database ParentResourceId Parameter Set
```
Remove-AzureRmSqlElasticJobTarget -ParentResourceId <String> [-ServerName] <String> [-DatabaseName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Sql Server or Elastic Pool ParentResourceId Parameter Set
```
Remove-AzureRmSqlElasticJobTarget -ParentResourceId <String> [-ServerName] <String> [-ElasticPoolName <String>]
 [-RefreshCredentialName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Sql Shard Map ParentResourceId Parameter Set
```
Remove-AzureRmSqlElasticJobTarget -ParentResourceId <String> [-ServerName] <String> [-ShardMapName] <String>
 [-DatabaseName] <String> [-RefreshCredentialName] <String> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Sql Server or Elastic Pool Target Type
```
Remove-AzureRmSqlElasticJobTarget [-ResourceGroupName] <String> [-AgentServerName] <String>
 [-AgentName] <String> [-TargetGroupName] <String> [-ServerName] <String> [-ElasticPoolName <String>]
 [-RefreshCredentialName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Sql Shard Map Target Type
```
Remove-AzureRmSqlElasticJobTarget [-ResourceGroupName] <String> [-AgentServerName] <String>
 [-AgentName] <String> [-TargetGroupName] <String> [-ServerName] <String> [-ShardMapName] <String>
 [-DatabaseName] <String> [-RefreshCredentialName] <String> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmSqlElasticJobTarget** cmdlet removes a target resource to a target group

## EXAMPLES

### Example 1 - Remove a server target
```powershell
PS C:\> $tg = Get-AzureRmSqlElasticJobTargetGroup -ResourceGroupName rg -ServerName elasticjobserver -Name tg1
$tg | Remove-AzureRmSqlElasticJobTarget -ServerName s1 -RefreshCredentialName cred1

TargetGroupName TargetType TargetServerName TargetDatabaseName TargetElasticPoolName TargetShardMapName RefreshCredentialName MembershipType
--------------- ---------- ---------------- ------------------ --------------------- ------------------ --------------------- --------------
tg1             SqlServer  s1                                                                           cred1                 Include
```

### Example 2 - Remove a database target
```powershell
PS C:\> $tg = Get-AzureRmSqlElasticJobTargetGroup -ResourceGroupName rg -ServerName elasticjobserver -Name tg1
$tg | Remove-AzureRmSqlElasticJobTarget -ServerName s1 -DatabaseName db2

TargetGroupName TargetType  TargetServerName TargetDatabaseName TargetElasticPoolName TargetShardMapName RefreshCredentialName MembershipType
--------------- ----------  ---------------- ------------------ --------------------- ------------------ --------------------- --------------
tg1             SqlDatabase s1               db2                                                                               Include
```

### Example 3 - Remove an elastic pool target
```powershell
PS C:\> $tg = Get-AzureRmSqlElasticJobTargetGroup -ResourceGroupName rg -ServerName elasticjobserver -Name tg1
$tg | Remove-AzureRmSqlElasticJobTarget -ServerName s1 -ElasticPoolName ep1 -RefreshCredentialName cred1

TargetGroupName TargetType     TargetServerName TargetDatabaseName TargetElasticPoolName TargetShardMapName RefreshCredentialName MembershipType
--------------- ----------     ---------------- ------------------ --------------------- ------------------ --------------------- --------------
tg1             SqlElasticPool s1                                  ep1                                      cred1                 Include
```

### Example 4 - Remove a shard map target
```powershell
PS C:\> $tg = Get-AzureRmSqlElasticJobTargetGroup -ResourceGroupName rg -ServerName elasticjobserver -Name tg1
$tg | Remove-AzureRmSqlElasticJobTarget -ServerName s1 -ShardMapName sm1 -DatabaseName db1 -RefreshCredentialName cred1

TargetGroupName TargetType  TargetServerName TargetDatabaseName TargetElasticPoolName TargetShardMapName RefreshCredentialName MembershipType
--------------- ----------  ---------------- ------------------ --------------------- ------------------ --------------------- --------------
tg1             SqlShardMap s1               db1                                      sm1                cred1                 Include
```

Removes a target (server, elastic pool, database, and shard map) from a target group

## PARAMETERS

### -AgentName
The agent name.

```yaml
Type: String
Parameter Sets: Sql Database Target Type, Sql Server or Elastic Pool Target Type, Sql Shard Map Target Type
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgentServerName
The server name.

```yaml
Type: String
Parameter Sets: Sql Database Target Type, Sql Server or Elastic Pool Target Type, Sql Shard Map Target Type
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
The database target name.

```yaml
Type: String
Parameter Sets: Sql Database Target Type, Sql Database Input Object Parameter Set, Sql Shard Map Input Object Parameter Set, Sql Database ParentResourceId Parameter Set, Sql Shard Map ParentResourceId Parameter Set, Sql Shard Map Target Type
Aliases:

Required: True
Position: 5
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

### -ElasticPoolName
The target elastic pool name.

```yaml
Type: String
Parameter Sets: Sql Server or Elastic Pool Input Object Parameter Set, Sql Server or Elastic Pool ParentResourceId Parameter Set, Sql Server or Elastic Pool Target Type
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ParentObject
The target group object.

```yaml
Type: AzureSqlElasticJobTargetGroupModel
Parameter Sets: Sql Database Input Object Parameter Set, Sql Server or Elastic Pool Input Object Parameter Set, Sql Shard Map Input Object Parameter Set
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParentResourceId
The target group resource id.

```yaml
Type: String
Parameter Sets: Sql Database ParentResourceId Parameter Set, Sql Server or Elastic Pool ParentResourceId Parameter Set, Sql Shard Map ParentResourceId Parameter Set
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RefreshCredentialName
The refresh credential name.

```yaml
Type: String
Parameter Sets: Sql Server or Elastic Pool Input Object Parameter Set, Sql Shard Map Input Object Parameter Set, Sql Server or Elastic Pool ParentResourceId Parameter Set, Sql Shard Map ParentResourceId Parameter Set, Sql Server or Elastic Pool Target Type, Sql Shard Map Target Type
Aliases:

Required: True
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: Sql Database Target Type, Sql Server or Elastic Pool Target Type, Sql Shard Map Target Type
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
The target server name.

```yaml
Type: String
Parameter Sets: Sql Database Target Type, Sql Database Input Object Parameter Set, Sql Server or Elastic Pool Input Object Parameter Set, Sql Shard Map Input Object Parameter Set, Sql Database ParentResourceId Parameter Set, Sql Server or Elastic Pool ParentResourceId Parameter Set, Sql Shard Map ParentResourceId Parameter Set, Sql Shard Map Target Type
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Sql Server or Elastic Pool Target Type
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ShardMapName
The target shard map name.

```yaml
Type: String
Parameter Sets: Sql Shard Map Input Object Parameter Set, Sql Shard Map ParentResourceId Parameter Set, Sql Shard Map Target Type
Aliases:

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetGroupName
The target group name.

```yaml
Type: String
Parameter Sets: Sql Database Target Type, Sql Server or Elastic Pool Target Type, Sql Shard Map Target Type
Aliases:

Required: True
Position: 3
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

### Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobTargetGroupModel
System.String

## OUTPUTS

### Microsoft.Azure.Management.Sql.Models.JobTarget

## NOTES

## RELATED LINKS
