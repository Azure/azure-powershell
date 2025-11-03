---
external help file:
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/update-azelasticmonitor
schema: 2.0.0
---

# Update-AzElasticMonitor

## SYNOPSIS
Update an existing Elastic monitor resource in your Azure subscription, ensuring optimal observability and performance.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzElasticMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzElasticMonitor -InputObject <IElasticIdentity> [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzElasticMonitor -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzElasticMonitor -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Upgrade
```
Update-AzElasticMonitor -Name <String> -ResourceGroupName <String> -Body <IElasticMonitorUpgrade>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpgradeExpanded
```
Update-AzElasticMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Version <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpgradeViaIdentity
```
Update-AzElasticMonitor -InputObject <IElasticIdentity> -Body <IElasticMonitorUpgrade>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an existing Elastic monitor resource in your Azure subscription, ensuring optimal observability and performance.

## EXAMPLES

### Example 1: Update a monitor resource
```powershell
Update-AzElasticMonitor -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02 -Tag @{'key01' = '1'; 'key2' = '2'; 'key3' = '3'}
```

```output
Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-consumption-2024_Monthly Enabled          westus2  azure-elastic-test
```

This command updates a monitor resource.

### Example 2: Update a monitor resource by pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02 | Update-AzElasticMonitor -Tag @{'key01' = '1'; 'key2' = '2'; 'key3' = '3'}
```

```output
Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-consumption-2024_Monthly Enabled          westus2  azure-elastic-test
```

This command updates a monitor resource by pipeline.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Body
Upgrade elastic monitor version

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticMonitorUpgrade
Parameter Sets: Upgrade, UpgradeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpgradeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Monitor resource name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString, Upgrade, UpgradeExpanded
Aliases: MonitorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Upgrade, UpgradeExpanded, UpgradeViaIdentity
Aliases:

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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString, Upgrade, UpgradeExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString, Upgrade, UpgradeExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
elastic monitor resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Version to which the elastic monitor should be upgraded to

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticMonitorUpgrade

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticMonitorResource

### System.Boolean

## NOTES

## RELATED LINKS

