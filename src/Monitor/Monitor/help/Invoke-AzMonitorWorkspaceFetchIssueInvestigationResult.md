---
external help file: Az.Monitor-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/invoke-azmonitorworkspacefetchissueinvestigationresult
schema: 2.0.0
---

# Invoke-AzMonitorWorkspaceFetchIssueInvestigationResult

## SYNOPSIS
Fetch investigation result

## SYNTAX

### FetchExpanded (Default)
```
Invoke-AzMonitorWorkspaceFetchIssueInvestigationResult -AzureMonitorWorkspaceName <String> -IssueName <String>
 -ResourceGroupName <String> -InvestigationId <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Fetch
```
Invoke-AzMonitorWorkspaceFetchIssueInvestigationResult -AzureMonitorWorkspaceName <String> -IssueName <String>
 -ResourceGroupName <String> -Body <IFetchInvestigationResultParameters> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FetchViaIdentity
```
Invoke-AzMonitorWorkspaceFetchIssueInvestigationResult -InputObject <IMonitorWorkspaceIdentity>
 -Body <IFetchInvestigationResultParameters> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### FetchViaIdentityAccount
```
Invoke-AzMonitorWorkspaceFetchIssueInvestigationResult -AccountInputObject <IMonitorWorkspaceIdentity>
 -IssueName <String> -Body <IFetchInvestigationResultParameters> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### FetchViaIdentityAccountExpanded
```
Invoke-AzMonitorWorkspaceFetchIssueInvestigationResult -AccountInputObject <IMonitorWorkspaceIdentity>
 -IssueName <String> -InvestigationId <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### FetchViaIdentityExpanded
```
Invoke-AzMonitorWorkspaceFetchIssueInvestigationResult -InputObject <IMonitorWorkspaceIdentity>
 -InvestigationId <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FetchViaJsonFilePath
```
Invoke-AzMonitorWorkspaceFetchIssueInvestigationResult -AzureMonitorWorkspaceName <String> -IssueName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FetchViaJsonString
```
Invoke-AzMonitorWorkspaceFetchIssueInvestigationResult -AzureMonitorWorkspaceName <String> -IssueName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Fetch investigation result

## EXAMPLES

### Example 1: Fetch an investigation result for an issue
```powershell
Invoke-AzMonitorWorkspaceFetchIssueInvestigationResult -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001 -InvestigationId inv-001
```

```output
Id      CreatedAt             LastModifiedAt        Result
--      ---------             --------------        ------
inv-001 5/7/2026 6:05:00 PM   5/7/2026 6:10:00 PM   CPU saturation correlated with deployment ring 2.
```

Fetches investigation result inv-001 for issue-001.

## PARAMETERS

### -AccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity
Parameter Sets: FetchViaIdentityAccount, FetchViaIdentityAccountExpanded
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
Parameter Sets: Fetch, FetchExpanded, FetchViaJsonFilePath, FetchViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Parameters provided to get the investigation result

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IFetchInvestigationResultParameters
Parameter Sets: Fetch, FetchViaIdentity, FetchViaIdentityAccount
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
Parameter Sets: FetchViaIdentity, FetchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InvestigationId
The unique identifier of the investigation

```yaml
Type: System.String
Parameter Sets: FetchExpanded, FetchViaIdentityAccountExpanded, FetchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IssueName
The name of the IssueResource

```yaml
Type: System.String
Parameter Sets: Fetch, FetchExpanded, FetchViaIdentityAccount, FetchViaIdentityAccountExpanded, FetchViaJsonFilePath, FetchViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Fetch operation

```yaml
Type: System.String
Parameter Sets: FetchViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Fetch operation

```yaml
Type: System.String
Parameter Sets: FetchViaJsonString
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
Parameter Sets: Fetch, FetchExpanded, FetchViaJsonFilePath, FetchViaJsonString
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
Parameter Sets: Fetch, FetchExpanded, FetchViaJsonFilePath, FetchViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IFetchInvestigationResultParameters

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IInvestigationResult

## NOTES

## RELATED LINKS

