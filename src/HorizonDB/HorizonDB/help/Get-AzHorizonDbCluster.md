---
external help file: Az.HorizonDB-help.xml
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/get-azhorizondbcluster
schema: 2.0.0
---

# Get-AzHorizonDbCluster

## SYNOPSIS
Gets information about a HorizonDB cluster.

## SYNTAX

### List (Default)
```
Get-AzHorizonDbCluster [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzHorizonDbCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzHorizonDbCluster -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHorizonDbCluster -InputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about a HorizonDB cluster.

## EXAMPLES

### Example 1: List clusters in the current subscription
```powershell
Get-AzHorizonDbCluster | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : example-cluster
Location            : eastus2
PostgreSqlVersion   : 17
CreationMode        : Create
State               : Ready
ProvisioningState   : Succeeded
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: List clusters in a resource group
```powershell
Get-AzHorizonDbCluster -ResourceGroupName 'example-resource-group' | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : example-cluster
Location            : westcentralus
PostgreSqlVersion   : 17
CreationMode        : Create
State               : Ready
ProvisioningState   : Succeeded
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 3: Get a cluster
```powershell
Get-AzHorizonDbCluster -ResourceGroupName 'example-resource-group' -Name 'example-cluster' | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : example-cluster
Location            : eastus2
PostgreSqlVersion   : 17
CreationMode        : Create
State               : Ready
ProvisioningState   : Succeeded
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

## PARAMETERS

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
The name of the HorizonDB cluster.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ClusterName

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
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.ICluster

## NOTES

## RELATED LINKS
