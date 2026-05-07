---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/add-azmonitorworkspaceissueresource
schema: 2.0.0
---

# Add-AzMonitorWorkspaceIssueResource

## SYNOPSIS
Add or add resources in the issue

## SYNTAX

### AddViaIdentity (Default)
```
Add-AzMonitorWorkspaceIssueResource -InputObject <IMonitorWorkspaceIdentity> -Body <IRelatedResources>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Add
```
Add-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName <String> -IssueName <String>
 -ResourceGroupName <String> -Body <IRelatedResources> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddExpanded
```
Add-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName <String> -IssueName <String>
 -ResourceGroupName <String> -Value <IRelatedResource[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddViaIdentityAccount
```
Add-AzMonitorWorkspaceIssueResource -AccountInputObject <IMonitorWorkspaceIdentity> -IssueName <String>
 -Body <IRelatedResources> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddViaIdentityAccountExpanded
```
Add-AzMonitorWorkspaceIssueResource -AccountInputObject <IMonitorWorkspaceIdentity> -IssueName <String>
 -Value <IRelatedResource[]> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddViaIdentityExpanded
```
Add-AzMonitorWorkspaceIssueResource -InputObject <IMonitorWorkspaceIdentity> -Value <IRelatedResource[]>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddViaJsonFilePath
```
Add-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName <String> -IssueName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddViaJsonString
```
Add-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName <String> -IssueName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Add or add resources in the issue

## EXAMPLES

### Example 1: Add a resource to an issue
```powershell
$resources = @(
    @{
        Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Compute/virtualMachines/vm-app-01"
        Relevance = "Relevant"
        AddedAt = (Get-Date "2026-05-07T18:02:00Z")
        OriginAddedBy = "ops@contoso.com"
        OriginAddedByType = "User"
    }
)
Add-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001 -Value $resources
```

```output
Id                                                                                                                                  Relevance
--                                                                                                                                  ---------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Compute/virtualMachines/vm-app-01 Relevant
```

Adds a related resource to issue-001.

## PARAMETERS

### -AccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity
Parameter Sets: AddViaIdentityAccount, AddViaIdentityAccountExpanded
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
Parameter Sets: Add, AddExpanded, AddViaJsonFilePath, AddViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
A list of related resources

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IRelatedResources
Parameter Sets: Add, AddViaIdentity, AddViaIdentityAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: AddViaIdentity, AddViaIdentityExpanded
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
Parameter Sets: Add, AddExpanded, AddViaIdentityAccount, AddViaIdentityAccountExpanded, AddViaJsonFilePath, AddViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Add operation

```yaml
Type: System.String
Parameter Sets: AddViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Add operation

```yaml
Type: System.String
Parameter Sets: AddViaJsonString
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
Parameter Sets: Add, AddExpanded, AddViaJsonFilePath, AddViaJsonString
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
Parameter Sets: Add, AddExpanded, AddViaJsonFilePath, AddViaJsonString
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
Parameter Sets: AddExpanded, AddViaIdentityAccountExpanded, AddViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IRelatedResources

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IRelatedResources

## NOTES

## RELATED LINKS

