---
external help file:
Module Name: Az.MonitoringSolutions
online version: https://docs.microsoft.com/powershell/module/az.monitoringsolutions/new-azmonitorloganalyticssolution
schema: 2.0.0
---

# New-AzMonitorLogAnalyticsSolution

## SYNOPSIS
Creates a log analytics solution.

## SYNTAX

```
New-AzMonitorLogAnalyticsSolution -ResourceGroupName <String> -Location <String> -Type <String>
 -WorkspaceResourceId <String> [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a log analytics solution.

## EXAMPLES

### Example 1: Create a monitor log analytics solution for the log analytics workspace
```powershell
PS C:\> $workspace = Get-AzOperationalInsightsWorkspace -ResourceGroupName azureps-manual-test -Name monitoringworkspace-2vob7n
PS C:\> New-AzMonitorLogAnalyticsSolution -Type Containers -ResourceGroupName azureps-manual-test -Location $workspace.Location -WorkspaceResourceId $workspace.ResourceId

Name                                   Type                                     Location
----                                   ----                                     --------
Containers(monitoringworkspace-2vob7n) Microsoft.OperationsManagement/solutions East US
```

This command creates a monitor log analytics solution for the log analytics workspace.

Commonly used types are:

| Type | Description |
| :-----| :----- |
| SecurityCenterFree |  Azure Security Center – Free Edition |
| Security | Azure Security Center |
| Updates | Update Management |
| ContainerInsights | Azure Monitor for Containers |
| ServiceMap | Service Map |
| AzureActivity | Activity log analytics |
| ChangeTracking | Change tracking and inventory |
| VMInsights | Azure Monitor for VMs |
| SecurityInsights | Azure Sentinel |
| NetworkMonitoring | Network Performance Monitor |
| SQLVulnerabilityAssessment | SQL Vulnerability Assessment |
| SQLAdvancedThreatProtection | SQL Advanced Threat Protection |
| AntiMalware | Antimalware Assessment |
| AzureAutomation |	Automation Hybrid Worker |
| LogicAppsManagement | Logic Apps Management |
| SQLDataClassification | SQL Data Discovery & Classification |

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

### -Location
Resource location.
Must be the same as the log analytic workspace.

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

### -ResourceGroupName
The name of the resource group to get.
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
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Type of the solution to be created.
For example "Container".

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SolutionType

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceResourceId
The Azure resource ID for the workspace where the solution will be deployed/enabled.

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

### Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolution

## NOTES

ALIASES

## RELATED LINKS



[Get-AzOperationalInsightsWorkspace](https://docs.microsoft.com/powershell/module/az.operationalinsights/get-azoperationalinsightsworkspace)

