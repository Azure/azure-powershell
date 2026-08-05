---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/new-azmonitorworkspaceissue
schema: 2.0.0
---

# New-AzMonitorWorkspaceIssue

## SYNOPSIS
Create a new issue or create an existing one

## SYNTAX

### CreateExpanded (Default)
```
New-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Related <String>] [-BackgroundDetail <IBackgroundDetails[]>]
 [-BackgroundText <String>] [-BackgroundType <String>] [-ImpactTime <DateTime>]
 [-NotificationActionGroupId <String[]>] [-NotificationExcludeDefaultActionGroup]
 [-NotificationUpdateType <IIssueNotificationType[]>] [-Severity <String>] [-Status <String>]
 [-Title <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityAccountExpanded
```
New-AzMonitorWorkspaceIssue -AccountInputObject <IMonitorWorkspaceIdentity> -Name <String> [-Related <String>]
 [-BackgroundDetail <IBackgroundDetails[]>] [-BackgroundText <String>] [-BackgroundType <String>]
 [-ImpactTime <DateTime>] [-NotificationActionGroupId <String[]>] [-NotificationExcludeDefaultActionGroup]
 [-NotificationUpdateType <IIssueNotificationType[]>] [-Severity <String>] [-Status <String>]
 [-Title <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzMonitorWorkspaceIssue -InputObject <IMonitorWorkspaceIdentity> [-Related <String>]
 [-BackgroundDetail <IBackgroundDetails[]>] [-BackgroundText <String>] [-BackgroundType <String>]
 [-ImpactTime <DateTime>] [-NotificationActionGroupId <String[]>] [-NotificationExcludeDefaultActionGroup]
 [-NotificationUpdateType <IIssueNotificationType[]>] [-Severity <String>] [-Status <String>]
 [-Title <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-Related <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-Related <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new issue or create an existing one

## EXAMPLES

### Example 1: Create an issue in a workspace
```powershell
New-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -Name issue-001 -Title "CPU spike on frontend cluster" -Severity "High" -Status "Active" -ImpactTime (Get-Date "2026-05-07T18:00:00Z") -BackgroundType "markdown" -BackgroundText "CPU usage exceeded 95% on the frontend cluster."
```

```output
Name      Severity Status ProvisioningState Title
----      -------- ------ ----------------- -----
issue-001 High     Active Succeeded         CPU spike on frontend cluster
```

Creates issue-001 in the workspace.

## PARAMETERS

### -AccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity
Parameter Sets: CreateViaIdentityAccountExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackgroundDetail
The background details

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IBackgroundDetails[]
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackgroundText
The background text

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackgroundType
The background type

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded, CreateViaIdentityExpanded
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

### -ImpactTime
The issue impact time (in UTC)

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded, CreateViaIdentityExpanded
Aliases:

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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Name
The name of the IssueResource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: IssueName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationActionGroupId
The action group IDs to notify

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationExcludeDefaultActionGroup
Whether to exclude default action groups from notifications

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationUpdateType
The types of updates that trigger notifications

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IIssueNotificationType[]
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Related
Related resource or alert that is to be added to the issue (default: empty - the issue will be created without any related resources or alerts)

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Severity
The issue severity

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
The issue status

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Title
The issue title

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IIssueResource

## NOTES

## RELATED LINKS

