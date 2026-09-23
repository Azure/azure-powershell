---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azmonitorworkspaceissue
schema: 2.0.0
---

# Get-AzMonitorWorkspaceIssue

## SYNOPSIS
Get issue properties

## SYNTAX

### List (Default)
```
Get-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMonitorWorkspaceIssue -InputObject <IMonitorWorkspaceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityAccount
```
Get-AzMonitorWorkspaceIssue -AccountInputObject <IMonitorWorkspaceIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get issue properties

## EXAMPLES

### Example 1: List issues in a workspace
```powershell
Get-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group
```

```output
Name      Severity Status ProvisioningState Title
----      -------- ------ ----------------- -----
issue-001 High     Active Succeeded         CPU spike on frontend cluster
```

Lists issues in the workspace.

### Example 2: Get a specific issue from a workspace
```powershell
Get-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -Name issue-001
```

```output
Name      Severity Status ProvisioningState Title
----      -------- ------ ----------------- -----
issue-001 High     Active Succeeded         CPU spike on frontend cluster
```

Gets issue-001 from the workspace.

## PARAMETERS

### -AccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity
Parameter Sets: GetViaIdentityAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AzureMonitorWorkspaceName
The name of the Azure Monitor Workspace.
The name is case insensitive

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
The name of the IssueResource

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityAccount
Aliases: IssueName

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IIssueResource

## NOTES

## RELATED LINKS

