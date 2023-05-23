---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azmonitorworkspace
schema: 2.0.0
---

# Get-AzMonitorWorkspace

## SYNOPSIS
Returns the specific Azure Monitor workspace

## SYNTAX

### List1 (Default)
```
Get-AzMonitorWorkspace [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMonitorWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMonitorWorkspace -InputObject <IMonitorWorkspaceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzMonitorWorkspace -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the specific Azure Monitor workspace

## EXAMPLES

### Example 1: List the specific Azure Monitor workspace.
```powershell
Get-AzMonitorWorkspace
```

```output
Name                   Location ProvisioningState PublicNetworkAccess ResourceGroupName
----                   -------- ----------------- ------------------- -----------------
azps-monitor-workspace eastus   Succeeded         Enabled             azps_test_group
```

List the specific Azure Monitor workspace.

### Example 2: List the specific Azure Monitor workspace by Resource Groupy.
```powershell
Get-AzMonitorWorkspace -ResourceGroupName azps_test_group
```

```output
Name                   Location ProvisioningState PublicNetworkAccess ResourceGroupName
----                   -------- ----------------- ------------------- -----------------
azps-monitor-workspace eastus   Succeeded         Enabled             azps_test_group
```

List the specific Azure Monitor workspace by Resource Groupy.

### Example 3: Get the specific Azure Monitor workspace by monitor workspace name.
```powershell
Get-AzMonitorWorkspace -ResourceGroupName azps_test_group -Name azps-monitor-workspace
```

```output
Name                   Location ProvisioningState PublicNetworkAccess ResourceGroupName
----                   -------- ----------------- ------------------- -----------------
azps-monitor-workspace eastus   Succeeded         Enabled             azps_test_group
```

Get the specific Azure Monitor workspace by monitor workspace name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Azure Monitor workspace.
The name is case insensitive

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AzureMonitorWorkspaceName

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.Api20230403.IAzureMonitorWorkspaceResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IMonitorWorkspaceIdentity>`: Identity Parameter
  - `[AzureMonitorWorkspaceName <String>]`: The name of the Azure Monitor workspace.  The name is case insensitive
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

