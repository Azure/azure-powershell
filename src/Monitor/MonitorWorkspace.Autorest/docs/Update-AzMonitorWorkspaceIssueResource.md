---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/update-azmonitorworkspaceissueresource
schema: 2.0.0
---

# Update-AzMonitorWorkspaceIssueResource

## SYNOPSIS
Add or add resources in the issue

## SYNTAX

### UpdateViaIdentityExpanded (Default)
```
Update-AzMonitorWorkspaceIssueResource -InputObject <IMonitorWorkspaceIdentity> -Value <IRelatedResource[]>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName <String> -IssueName <String>
 -ResourceGroupName <String> -Value <IRelatedResource[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityAccountExpanded
```
Update-AzMonitorWorkspaceIssueResource -AccountInputObject <IMonitorWorkspaceIdentity> -IssueName <String>
 -Value <IRelatedResource[]> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName <String> -IssueName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName <String> -IssueName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Add or add resources in the issue

## EXAMPLES

### Example 1: Update the resources for an issue
```powershell
$resources = @(
    @{
        Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Compute/virtualMachines/vm-app-01"
        Relevance = "Relevant"
    },
    @{
        Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Network/loadBalancers/lb-app-01"
        Relevance = "Relevant"
    }
)
Update-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001 -Value $resources
```

```output
Id                                                                                                                                     Relevance
--                                                                                                                                     ---------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Compute/virtualMachines/vm-app-01   Relevant
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Network/loadBalancers/lb-app-01     Relevant
```

Replaces the related resources for issue-001.

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IssueName
The name of the IssueResource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -Value
A list of related resources

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IRelatedResource[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IRelatedResources

## NOTES

## RELATED LINKS

