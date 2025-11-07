---
external help file: Az.Dashboard-help.xml
Module Name: Az.Dashboard
online version: https://learn.microsoft.com/powershell/module/az.dashboard/new-azgrafanaintegrationfabric
schema: 2.0.0
---

# New-AzGrafanaIntegrationFabric

## SYNOPSIS
Create a IntegrationFabric

## SYNTAX

### CreateExpanded (Default)
```
New-AzGrafanaIntegrationFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WorkspaceName <String> -Location <String> [-DataSourceResourceId <String>] [-Scenario <String[]>]
 [-Tag <Hashtable>] [-TargetResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzGrafanaIntegrationFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WorkspaceName <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzGrafanaIntegrationFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WorkspaceName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityGrafanaExpanded
```
New-AzGrafanaIntegrationFabric -Name <String> -GrafanaInputObject <IDashboardIdentity> -Location <String>
 [-DataSourceResourceId <String>] [-Scenario <String[]>] [-Tag <Hashtable>] [-TargetResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a IntegrationFabric

## EXAMPLES

### Example 1: Create a new Grafana integration fabric
```powershell
New-AzGrafanaIntegrationFabric -Name fabric-integration1 -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana -Location eastus -Tag @{"Environment"="Production"}
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration1 eastus   azpstest-gp
```

Creates a new integration fabric for an Azure Managed Grafana workspace.

### Example 2: Create a Grafana integration fabric with scenarios
```powershell
New-AzGrafanaIntegrationFabric -Name fabric-integration2 -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana -Location eastus -Scenario @("DataExploration")
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration2 eastus   azpstest-gp
```

Creates a new integration fabric for the Grafana workspace with specified scenarios.

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

### -DataSourceResourceId
The resource Id of the Azure resource which is used to configure Grafana data source.
E.g., an Azure Monitor Workspace, an Azure Data Explorer cluster, etc.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityGrafanaExpanded
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
Parameter Sets: CreateViaIdentityGrafanaExpanded
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

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityGrafanaExpanded
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scenario
A list of integration scenarios covered by this integration fabric

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityGrafanaExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityGrafanaExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceId
The resource Id of the Azure resource being integrated with Azure Managed Grafana.
E.g., an Azure Kubernetes Service cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityGrafanaExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
