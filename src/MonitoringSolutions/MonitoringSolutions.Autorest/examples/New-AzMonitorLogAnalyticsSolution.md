### Example 1: Create a monitor log analytics solution for the log analytics workspace
```powershell
$workspace = Get-AzOperationalInsightsWorkspace -ResourceGroupName azureps-manual-test -Name monitoringworkspace-2vob7n
New-AzMonitorLogAnalyticsSolution -Type Containers -ResourceGroupName azureps-manual-test -Location $workspace.Location -WorkspaceResourceId $workspace.ResourceId
```

```output
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

