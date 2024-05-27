---
external help file:
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/get-azelasticmonitor
schema: 2.0.0
---

# Get-AzElasticMonitor

## SYNOPSIS
Get the properties of a specific monitor resource.

## SYNTAX

### List (Default)
```
Get-AzElasticMonitor [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzElasticMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzElasticMonitor -InputObject <IElasticIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzElasticMonitor -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the properties of a specific monitor resource.

## EXAMPLES

### Example 1: List all elastic monitors under a subscription
```powershell
Get-AzElasticMonitor
```

```output
Name                           SkuName                         MonitoringStatus Location      ResourceGroupName
----                           -------                         ---------------- --------      -----------------
kk-elastictest02               ess-consumption-2024_Monthly Enabled          westus2       kk-rg
kk-elastictest03               ess-consumption-2024_Monthly Enabled          westus2       kk-rg
wusDeployValidate              ess-consumption-2024_Monthly Enabled          westus2       poshett-rg
poshett-WestUS2-01             staging_Monthly                 Enabled          westus2       poshett-rg
hashahdemo01                   staging_Monthly                 Enabled          westus2       test-sub
```

This command lists all elastic monitors under a subscription.

### Example 2: List all elastic monitors under a resource group
```powershell
Get-AzElasticMonitor -ResourceGroupName azure-elastic-test
```

```output
Name             SkuName                         MonitoringStatus Location ResourceGroupName
----             -------                         ---------------- -------- -----------------
elastic-portal01 ess-consumption-2024_Monthly Enabled          westus2  azure-elastic-test
elastic-portal02 ess-consumption-2024_Monthly Enabled          westus2  azure-elastic-test
elastic-pwsh01   ess-consumption-2024_Monthly Enabled          westus2  azure-elastic-test
elastic-pwsh02   ess-consumption-2024_Monthly Enabled          westus2  azure-elastic-test
```

This command lists all elastic monitors under a resource group.

### Example 3: Get the properties of a specific monitor resource
```powershell
Get-AzElasticMonitor -ResourceGroupName azure-elastic-test -Name elastic-pwsh02
```

```output
Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-consumption-2024_Monthly Enabled          westus2  azure-elastic-test
```

This command gets the properties of a specific monitor resource.

### Example 4: Get the properties of a specific monitor resource by pipeline
```powershell
New-AzElasticMonitor -ResourceGroupName azps-elastic-test -Name elastic-pwsh02 -Location "westus2" -Sku "ess-consumption-2024_Monthly" -UserInfoEmailAddress 'xxx@microsoft.com' | Get-AzElasticMonitor
```

```output
Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-consumption-2024_Monthly Enabled          westus2  azure-elastic-test
```

This command gets the properties of a specific monitor resource by pipeline.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: MonitorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to which the Elastic resource belongs.

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
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IElasticMonitorResource

## NOTES

## RELATED LINKS

