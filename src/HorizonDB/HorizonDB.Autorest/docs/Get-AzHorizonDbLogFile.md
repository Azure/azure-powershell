---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/get-azhorizondblogfile
schema: 2.0.0
---

# Get-AzHorizonDbLogFile

## SYNOPSIS
Gets metadata for a captured HorizonDB log file.

## SYNTAX

### List (Default)
```
Get-AzHorizonDbLogFile -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzHorizonDbLogFile -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHorizonDbLogFile -InputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCluster
```
Get-AzHorizonDbLogFile -ClusterInputObject <IHorizonDbIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets metadata for a captured HorizonDB log file.

## EXAMPLES

### Example 1: List cluster log files
```powershell
Get-AzHorizonDbLogFile -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, LogType, Pool, Node, SizeInKilobyte, IsMutable
```

```output
Name           : 11111111-1111-1111-1111-111111111111
LogType        : PostgreSqlServer
Pool           : example-pool-01
Node           : node-01
SizeInKilobyte : 2048
IsMutable      : True

Name           : 22222222-2222-2222-2222-222222222222
LogType        : PostgreSqlServer
Pool           : example-pool-01
Node           : node-02
SizeInKilobyte : 1536
IsMutable      : False

Name           : 33333333-3333-3333-3333-333333333333
LogType        : PostgreSqlServer
Pool           : example-pool-01
Node           : node-03
SizeInKilobyte : 1280
IsMutable      : False
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a log file
```powershell
Get-AzHorizonDbLogFile -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name '11111111-1111-1111-1111-111111111111' | Format-List -Property Name, LogType, Pool, Node, SizeInKilobyte, IsMutable
```

```output
Name           : 11111111-1111-1111-1111-111111111111
LogType        : PostgreSqlServer
Pool           : example-pool-01
Node           : node-01
SizeInKilobyte : 2048
IsMutable      : True
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

## PARAMETERS

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the HorizonDB cluster.

```yaml
Type: System.String
Parameter Sets: Get, List
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the LogFile

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCluster
Aliases: LogFileName

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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.ILogFile

## NOTES

## RELATED LINKS

