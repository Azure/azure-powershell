---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/get-azhorizondbchangedatacaptureconfiguration
schema: 2.0.0
---

# Get-AzHorizonDbChangeDataCaptureConfiguration

## SYNOPSIS
Gets a change data capture configuration.

## SYNTAX

### List (Default)
```
Get-AzHorizonDbChangeDataCaptureConfiguration -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzHorizonDbChangeDataCaptureConfiguration -ClusterName <String> -ConfigurationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHorizonDbChangeDataCaptureConfiguration -InputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityCluster
```
Get-AzHorizonDbChangeDataCaptureConfiguration -ClusterInputObject <IHorizonDbIdentity>
 -ConfigurationName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a change data capture configuration.

## EXAMPLES

### Example 1: List change data capture configurations
```powershell
Get-AzHorizonDbChangeDataCaptureConfiguration -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, DatabaseName, UsageProfile, DesiredState, EffectiveState, ProvisioningState
```

```output
Name              : sales-database
DatabaseName      : sales
UsageProfile      : Mirroring
DesiredState      : Enabled
EffectiveState    : Enabled
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a change data capture configuration
```powershell
Get-AzHorizonDbChangeDataCaptureConfiguration -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -ConfigurationName 'sales-database' | Format-List -Property Name, DatabaseName, UsageProfile, DesiredState, EffectiveState, ProvisioningState
```

```output
Name              : sales-database
DatabaseName      : sales
UsageProfile      : Mirroring
DesiredState      : Enabled
EffectiveState    : Enabled
ProvisioningState : Succeeded
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

### -ConfigurationName
The caller-selected ARM-safe name of the change data capture configuration.
The exact PostgreSQL database name is stored in properties.databaseName.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCluster
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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IChangeDataCaptureConfiguration

## NOTES

## RELATED LINKS

