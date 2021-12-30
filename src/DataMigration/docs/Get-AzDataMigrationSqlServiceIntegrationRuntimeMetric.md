---
external help file:
Module Name: Az.DataMigration
online version: https://docs.microsoft.com/powershell/module/az.datamigration/get-azdatamigrationsqlserviceintegrationruntimemetric
schema: 2.0.0
---

# Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric

## SYNOPSIS
Retrieve the registered Integration Runtime nodes and their monitoring data for a given Database Migration Service

## SYNTAX

```
Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric -ResourceGroupName <String>
 -SqlMigrationServiceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Retrieve the registered Integration Runtime nodes and their monitoring data for a given Database Migration Service

## EXAMPLES

### Example 1: Get the registered Integration Runtime nodes and their monitoring data for a given Sql Migration Service
```powershell
PS C:\> Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService" | Select *

Name       Node
----       ----
default-ir {WIN-AKLAB}
```

This command gets the registered Integration Runtime nodes and their monitoring data for a given Sql Migration Service.

### Example 2: Print the monitoring data for each Integration Runtime node
```powershell
PS C:\> $item = Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric -ResourceGroupName "MyResourceGroup" -SqlMigrationService "MySqlMigrationService"
PS C:\> $item.Node[0] 

AvailableMemoryInMb ConcurrentJobsLimit ConcurrentJobsRunning CpuUtilization MaxConcurrentJob NodeName     ReceivedByte     SentByte
------------------- ------------------- --------------------- -------------- ---------------- --------     ------------     --------
200138              20                  0                     8                               WIN-AKLAB    9.33309006690979 5.433871746063232
```

First command gets the node monitoring data of a Sql Migration Service.
Second command is then used to print the monitoring data for each node.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

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

### -SqlMigrationServiceName
Name of the SQL Migration Service.

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
Subscription ID that identifies an Azure subscription.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20211030Preview.IIntegrationRuntimeMonitoringData

## NOTES

ALIASES

## RELATED LINKS

