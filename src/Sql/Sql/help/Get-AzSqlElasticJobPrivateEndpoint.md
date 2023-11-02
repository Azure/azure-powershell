---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/get-azsqlelasticjobprivateendpoint
schema: 2.0.0
---

# Get-AzSqlElasticJobPrivateEndpoint

## SYNOPSIS
Gets one or more job private endpoints

## SYNTAX

### DefaultSet (Default)
```
Get-AzSqlElasticJobPrivateEndpoint [-ResourceGroupName] <String> [-ServerName] <String> [-AgentName] <String>
 [-Name <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ObjectSet
```
Get-AzSqlElasticJobPrivateEndpoint [-ElasticJobAgentObject] <AzureSqlElasticJobAgentModel> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdSet
```
Get-AzSqlElasticJobPrivateEndpoint [-ElasticJobAgentResourceId] <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzSqlElasticJobPrivateEndpoint cmdlet gets one or more job private endpoints

## EXAMPLES

### Example 1
```powershell
$agent = Get-AzSqlElasticJobAgent -ResourceGroupName rg -ServerName elasticjobserver -Name agent
$agent | Get-AzSqlElasticJobPrivateEndpoint
```

```output
PrivateEndpointName         : endpoint1
TargetServerAzureResourceId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rg1/providers/Microsoft.Sql/servers/server1
PrivateEndpointId           : EJ_xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_endpoint1
ResourceGroupName           : rg
ServerName                  : elasticjobserver
AgentName                   : agent
ResourceId                  : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rg/providers/Microsoft.Sql/servers/elasticjobserver/jobAgents/agent/privateEndpoints/endpoint1
Type                        : Microsoft.Sql/servers/jobAgents/privateEndpoints
```

Gets one or more job private endpoints by job agent

### Example 2
```powershell
$agent = Get-AzSqlElasticJobAgent -ResourceGroupName rg -ServerName elasticjobserver -Name agent
$agent | Get-AzSqlElasticJobPrivateEndpoint -Name endpoint1
```

```output
PrivateEndpointName         : endpoint1
TargetServerAzureResourceId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rg1/providers/Microsoft.Sql/servers/server1
PrivateEndpointId           : EJ_xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_endpoint1
ResourceGroupName           : rg
ServerName                  : elasticjobserver
AgentName                   : agent
ResourceId                  : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rg/providers/Microsoft.Sql/servers/elasticjobserver/jobAgents/agent/privateEndpoints/endpoint1
Type                        : Microsoft.Sql/servers/jobAgents/privateEndpoints
```

Gets one or more job private endpoints by name

## PARAMETERS

### -AgentName
The agent name

```yaml
Type: System.String
Parameter Sets: DefaultSet
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ElasticJobAgentObject
The agent object

```yaml
Type: Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobAgentModel
Parameter Sets: ObjectSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ElasticJobAgentResourceId
The agent resource id

```yaml
Type: System.String
Parameter Sets: ResourceIdSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The private endpoint name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PrivateEndpointName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name

```yaml
Type: System.String
Parameter Sets: DefaultSet
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
Type: System.String
Parameter Sets: DefaultSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobAgentModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobPrivateEndpointModel

## NOTES

## RELATED LINKS
