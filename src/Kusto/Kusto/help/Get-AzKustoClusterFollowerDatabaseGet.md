---
external help file: Az.Kusto-help.xml
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/get-azkustoclusterfollowerdatabaseget
schema: 2.0.0
---

# Get-AzKustoClusterFollowerDatabaseGet

## SYNOPSIS
Returns a list of databases that are owned by this cluster and were followed by another cluster.

## SYNTAX

```
Get-AzKustoClusterFollowerDatabaseGet -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns a list of databases that are owned by this cluster and were followed by another cluster.

## EXAMPLES

### Example 1: Getting a list of
```powershell
Get-AzKustoClusterFollowerDatabaseGet -ResourceGroupName rg1 -ClusterName cluster1 -SubscriptionId subid
```

```output
AttachedDatabaseConfigurationName                   : 77789349-86f5-437e-a965-cf02fed0fa9e
ClusterResourceId                                   : /capacity/12c6162d-0e45-4315-890d-3b4e8cfab277
                                                      /workspace/339aaf03-e7f1-4028-982c-79e05f84499
                                                      5/artifact/77789349-86f5-437e-a965-cf02fed0fa9
                                                      e
DatabaseName                                        : db1
DatabaseShareOrigin                                 : Direct
TableLevelSharingPropertyExternalTablesToExclude    :
TableLevelSharingPropertyExternalTablesToInclude    :
TableLevelSharingPropertyFunctionsToExclude         :
TableLevelSharingPropertyFunctionsToInclude         :
TableLevelSharingPropertyMaterializedViewsToExclude :
TableLevelSharingPropertyMaterializedViewsToInclude :
TableLevelSharingPropertyTablesToExclude            :
TableLevelSharingPropertyTablesToInclude            :

AttachedDatabaseConfigurationName                   : 6370858a-ae02-4e97-9c87-0163226bdef7
ClusterResourceId                                   : /capacity/12c6162d-0e45-4315-890d-3b4e8cfab277
                                                      /workspace/339aaf03-e7f1-4028-982c-79e05f84499
                                                      5/artifact/6370858a-ae02-4e97-9c87-0163226bdef
                                                      7
DatabaseName                                        : db1
DatabaseShareOrigin                                 : Direct
TableLevelSharingPropertyExternalTablesToExclude    :
TableLevelSharingPropertyExternalTablesToInclude    :
TableLevelSharingPropertyFunctionsToExclude         :
TableLevelSharingPropertyFunctionsToInclude         :
TableLevelSharingPropertyMaterializedViewsToExclude :
TableLevelSharingPropertyMaterializedViewsToInclude :
TableLevelSharingPropertyTablesToExclude            :
TableLevelSharingPropertyTablesToInclude            :
```

The above command lists all the databases that are owned by this cluster and are followed by another cluster.

## PARAMETERS

### -ClusterName
The name of the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IFollowerDatabaseDefinitionGet

## NOTES

## RELATED LINKS
