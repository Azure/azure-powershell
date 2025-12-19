---
external help file: Az.Dashboard-help.xml
Module Name: Az.Dashboard
online version: https://learn.microsoft.com/powershell/module/az.dashboard/update-azgrafanaintegrationfabric
schema: 2.0.0
---

# Update-AzGrafanaIntegrationFabric

## SYNOPSIS
Update a IntegrationFabric

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzGrafanaIntegrationFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WorkspaceName <String> [-Scenario <String[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzGrafanaIntegrationFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WorkspaceName <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzGrafanaIntegrationFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WorkspaceName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityGrafanaExpanded
```
Update-AzGrafanaIntegrationFabric -Name <String> -GrafanaInputObject <IDashboardIdentity>
 [-Scenario <String[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzGrafanaIntegrationFabric -InputObject <IDashboardIdentity> [-Scenario <String[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a IntegrationFabric

## EXAMPLES

### Example 1: Update tags for a Grafana integration fabric
```powershell
Update-AzGrafanaIntegrationFabric -Name fabric-integration1 -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana -Tag @{"Environment"="Production"; "Team"="DataEngineering"}
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration1 eastus   azpstest-gp
```

Updates the tags of an existing integration fabric in the Azure Managed Grafana workspace.

### Example 2: Update scenarios for a Grafana integration fabric
```powershell
Update-AzGrafanaIntegrationFabric -Name fabric-integration2 -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana -Scenario @("DataExploration", "Monitoring")
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration2 eastus   azpstest-gp
```

Updates the scenarios for an existing integration fabric to enable additional functionality.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
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

### -GrafanaInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity
Parameter Sets: UpdateViaIdentityGrafanaExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity
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
The integration fabric name of Azure Managed Grafana.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityGrafanaExpanded
Aliases: IntegrationFabricName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scenario
The new integration scenarios covered by this integration fabric.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityGrafanaExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The new tags of the Integration Fabric resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityGrafanaExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The workspace name of Azure Managed Grafana.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IIntegrationFabric

## NOTES

## RELATED LINKS
