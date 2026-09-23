---
external help file: Az.PrometheusRuleGroups.psm1-help.xml
Module Name: Az.AlertsManagement
online version: https://learn.microsoft.com/powershell/module/az.alertsmanagement/new-azprometheusrulegroup
schema: 2.0.0
---

# New-AzPrometheusRuleGroup

## SYNOPSIS
create a Prometheus rule group definition.

## SYNTAX

### CreateExpanded (Default)
```
New-AzPrometheusRuleGroup -ResourceGroupName <String> -RuleGroupName <String> [-SubscriptionId <String>]
 -Location <String> -Rule <IPrometheusRule[]> -Scope <String[]> [-ClusterName <String>] [-Description <String>]
 [-Enabled] [-Interval <TimeSpan>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzPrometheusRuleGroup -ResourceGroupName <String> -RuleGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzPrometheusRuleGroup -ResourceGroupName <String> -RuleGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
create a Prometheus rule group definition.

## EXAMPLES

### Example 1: Create Prometheus rule group definition with one rule.
```powershell
$rule1 = New-AzPrometheusRuleObject -Record "job_type:billing_jobs_duration_seconds:99p5m"
$scope = "/subscriptions/fffffffff-ffff-ffff-ffff-ffffffffffff/resourcegroups/MyresourceGroup/providers/microsoft.monitor/accounts/MyAccounts"
New-AzPrometheusRuleGroup -ResourceGroupName MyresourceGroup -RuleGroupName MyRuleGroup -Location eastus -Rule $rule1 -Scope $scope -Enabled
```

```output
Name        Location ClusterName Enabled
----        -------- ----------- -------
MyRuleGroup eastus               True
```

Create Prometheus rule group definition with one rule.

### Example 2: Create Prometheus rule group definition with rules.
```powershell
$rule1 = New-AzPrometheusRuleObject -Record "job_type:billing_jobs_duration_seconds:99p5m"
$action =  New-AzPrometheusRuleGroupActionObject -ActionGroupId /subscriptions/fffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/MyresourceGroup/providers/microsoft.insights/actiongroups/MyActionGroup -ActionProperty @{"key1" = "value1"}
$Timespan = New-TimeSpan -Minutes 15
$rule2 = New-AzPrometheusRuleObject -Alert Billing_Processing_Very_Slow -Expression "job_type:billing_jobs_duration_seconds:99p5m > 30" -Enabled $false -Severity 3 -For $Timespan -Label @{"team"="prod"} -Annotation @{"annotation" = "value"} -ResolveConfigurationAutoResolved $true -ResolveConfigurationTimeToResolve $Timespan -Action $action
$rules = @($rule1, $rule2)
$scope = "/subscriptions/fffffffff-ffff-ffff-ffff-ffffffffffff/resourcegroups/MyresourceGroup/providers/microsoft.monitor/accounts/MyAccounts"
New-AzPrometheusRuleGroup -ResourceGroupName MyresourceGroup -RuleGroupName MyRuleGroup -Location eastus -Rule $rule1 -Scope $scope -Enabled
```

```output
Name        Location ClusterName Enabled
----        -------- ----------- -------
MyRuleGroup eastus               True
```

Create Prometheus rule group definition with rules.

## PARAMETERS

### -ClusterName
Apply rule to data from a specific cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
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

### -Description
Rule group description.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
Enable/disable rule group.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Interval
The interval in which to run the Prometheus rule group represented in ISO 8601 duration format.
Should be between 1 and 15 minutes

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
Defines the rules in the Prometheus rule group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRule[]
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleGroupName
The name of the rule group.

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

### -Scope
Target Azure Monitor workspaces resource ids.
This api-version is currently limited to creating with one scope.
This may change in future.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupResource

## NOTES

## RELATED LINKS
