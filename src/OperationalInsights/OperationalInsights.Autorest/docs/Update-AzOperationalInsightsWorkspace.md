---
external help file:
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/update-azoperationalinsightsworkspace
schema: 2.0.0
---

# Update-AzOperationalInsightsWorkspace

## SYNOPSIS
Updates a workspace.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzOperationalInsightsWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DailyQuotaGb <Double>] [-DefaultDataCollectionRuleResourceId <String>] [-Feature <IWorkspaceFeatures>]
 [-ForceCmkForQuery] [-PublicNetworkAccessForIngestion <PublicNetworkAccessType>]
 [-PublicNetworkAccessForQuery <PublicNetworkAccessType>] [-RetentionInDay <Int32>]
 [-Sku <WorkspaceSkuNameEnum>] [-SkuCapacity <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzOperationalInsightsWorkspace -InputObject <IOperationalInsightsIdentity> [-DailyQuotaGb <Double>]
 [-DefaultDataCollectionRuleResourceId <String>] [-Feature <IWorkspaceFeatures>] [-ForceCmkForQuery]
 [-PublicNetworkAccessForIngestion <PublicNetworkAccessType>]
 [-PublicNetworkAccessForQuery <PublicNetworkAccessType>] [-RetentionInDay <Int32>]
 [-Sku <WorkspaceSkuNameEnum>] [-SkuCapacity <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a workspace.

## EXAMPLES

### Example 1: Update an existing Worksapce retrntion
```powershell
PS C:\>$workspace =  Update-AzOperationalInsightsWorkspace -ResourceGroupName {RG-name} -Name {WS-name} -RetentionInDay 42
PS C:\>$workspace
Location Name                   ETag ResourceGroupName
-------- ----                   ---- -----------------
eastus   {WS-name}t

PS C:\> $workspace.RetentionInDay
42
```

Update a custom property - retention for a workspace

### Example 2: Update a workspace that does not exist
```powershell
PS C:\> Update-AzOperationalInsightsWorkspace -ResourceGroupName {RG-name} -Name {WS-name} -RetentionInDay 42

Update-AzOperationalInsightsWorkspace_UpdateExpanded: The Resource 'Microsoft.OperationalInsights/workspaces/{WS-name}' under resource group '{RG-name}' was not found. For more details please go to https://aka.ms/ARMResourceNotFoundFix
```

Please create a workspace using 'New-AzOperationalInsightsWorkspace' cmdlet before updating it

## PARAMETERS

### -DailyQuotaGb
The workspace daily quota for ingestion.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultDataCollectionRuleResourceId
The resource ID of the default Data Collection Rule to use for this workspace.
Expected format is - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionRules/{dcrName}.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Feature
Workspace features.
To construct, see NOTES section for FEATURE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.Api20211201Preview.IWorkspaceFeatures
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForceCmkForQuery
Indicates whether customer managed storage is mandatory for query management.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.IOperationalInsightsIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: WorkspaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccessForIngestion
The network access type for accessing Log Analytics ingestion.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Support.PublicNetworkAccessType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccessForQuery
The network access type for accessing Log Analytics query.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Support.PublicNetworkAccessType
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionInDay
The workspace data retention in days.
Allowed values are per pricing plan.
See pricing tiers documentation for details.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The name of the SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Support.WorkspaceSkuNameEnum
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
The capacity reservation level in GB for this workspace, when CapacityReservation sku is selected.

```yaml
Type: System.Int32
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.
Optional.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.IOperationalInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.Api20211201Preview.IWorkspace

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FEATURE <IWorkspaceFeatures>: Workspace features.
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ClusterResourceId <String>]`: Dedicated LA cluster resourceId that is linked to the workspaces.
  - `[DisableLocalAuth <Boolean?>]`: Disable Non-AAD based Auth.
  - `[EnableDataExport <Boolean?>]`: Flag that indicate if data should be exported.
  - `[EnableLogAccessUsingOnlyResourcePermission <Boolean?>]`: Flag that indicate which permission to use - resource or workspace or both.
  - `[ImmediatePurgeDataOn30Day <Boolean?>]`: Flag that describes if we want to remove the data after 30 days.

INPUTOBJECT <IOperationalInsightsIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[TableName <String>]`: The name of the table.
  - `[WorkspaceName <String>]`: The name of the workspace.

## RELATED LINKS

