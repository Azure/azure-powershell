# 1. create a solution
# Notes:
# The name of the solution is not assigned by user, it is generated.
# `-Type <string>` is a code of the solution type. We are working with service team to provide a list of available types.
# Only first party (Microsoft) solutions are supported.

$workspace = Get-AzOperationalInsightsWorkspace -ResourceGroupName yemingmonitor -Name yemingmonitor

New-AzMonitorLogAnalyticsSolution -Type Containers -ResourceGroupName yemingmonitor -Location $workspace.location -WorkspaceResourceId $workspace.ResourceId

# Name                      Type                                     Location
# ----                      ----                                     --------
# Containers(yemingmonitor) Microsoft.OperationsManagement/solutions West US 2

# 2.