---
external help file: Az.Monitor-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/update-azmonitorworkspaceissue
schema: 2.0.0
---

# Update-AzMonitorWorkspaceIssue

## SYNOPSIS
Update an issue

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-BackgroundDetail <IBackgroundDetails[]>] [-BackgroundText <String>]
 [-BackgroundType <String>] [-ImpactTime <DateTime>] [-NotificationActionGroupId <String[]>]
 [-NotificationExcludeDefaultActionGroup] [-NotificationUpdateType <IIssueNotificationType[]>]
 [-Severity <String>] [-Status <String>] [-Title <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityAccountExpanded
```
Update-AzMonitorWorkspaceIssue -AccountInputObject <IMonitorWorkspaceIdentity> -Name <String>
 [-BackgroundDetail <IBackgroundDetails[]>] [-BackgroundText <String>] [-BackgroundType <String>]
 [-ImpactTime <DateTime>] [-NotificationActionGroupId <String[]>] [-NotificationExcludeDefaultActionGroup]
 [-NotificationUpdateType <IIssueNotificationType[]>] [-Severity <String>] [-Status <String>]
 [-Title <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMonitorWorkspaceIssue -InputObject <IMonitorWorkspaceIdentity>
 [-BackgroundDetail <IBackgroundDetails[]>] [-BackgroundText <String>] [-BackgroundType <String>]
 [-ImpactTime <DateTime>] [-NotificationActionGroupId <String[]>] [-NotificationExcludeDefaultActionGroup]
 [-NotificationUpdateType <IIssueNotificationType[]>] [-Severity <String>] [-Status <String>]
 [-Title <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update an issue

## EXAMPLES

### Example 1: Update an issue in a workspace
```powershell
Update-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -Name issue-001 -Severity "Critical" -Status "Mitigated" -Title "CPU spike on frontend cluster mitigated"
```

```output
Name      Severity Status    ProvisioningState Title
----      -------- ------    ----------------- -----
issue-001 Critical Mitigated Succeeded         CPU spike on frontend cluster mitigated
```

Updates the severity and status of issue-001.

## PARAMETERS

### -AccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity
Parameter Sets: UpdateViaIdentityAccountExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
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
The name of the IssueResource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaIdentityExpanded
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

