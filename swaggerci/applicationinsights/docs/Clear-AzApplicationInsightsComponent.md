---
external help file:
Module Name: Az.ApplicationInsights
online version: https://docs.microsoft.com/en-us/powershell/module/az.applicationinsights/clear-azapplicationinsightscomponent
schema: 2.0.0
---

# Clear-AzApplicationInsightsComponent

## SYNOPSIS
Purges data in an Application Insights component by a set of user-defined filters.\n\nIn order to manage system resources, purge requests are throttled at 50 requests per hour.
You should batch the execution of purge requests by sending a single command whose predicate includes all user identities that require purging.
Use the in operator to specify multiple identities.
You should run the query prior to using for a purge request to verify that the results are expected.

## SYNTAX

### PurgeViaIdentity (Default)
```
Clear-AzApplicationInsightsComponent -InputObject <IApplicationInsightsIdentity> -Body <IComponentPurgeBody>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Purge
```
Clear-AzApplicationInsightsComponent -ResourceGroupName <String> -ResourceName <String>
 -Body <IComponentPurgeBody> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### PurgeExpanded
```
Clear-AzApplicationInsightsComponent -ResourceGroupName <String> -ResourceName <String>
 -Filter <IComponentPurgeBodyFilters[]> -Table <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PurgeViaIdentityExpanded
```
Clear-AzApplicationInsightsComponent -InputObject <IApplicationInsightsIdentity>
 -Filter <IComponentPurgeBodyFilters[]> -Table <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Purges data in an Application Insights component by a set of user-defined filters.\n\nIn order to manage system resources, purge requests are throttled at 50 requests per hour.
You should batch the execution of purge requests by sending a single command whose predicate includes all user identities that require purging.
Use the in operator to specify multiple identities.
You should run the query prior to using for a purge request to verify that the results are expected.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Body
Describes the body of a purge request for an App Insights component
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api202002.IComponentPurgeBody
Parameter Sets: Purge, PurgeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Filter
The set of columns and filters (queries) to run over them to purge the resulting data.
To construct, see NOTES section for FILTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api202002.IComponentPurgeBodyFilters[]
Parameter Sets: PurgeExpanded, PurgeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity
Parameter Sets: PurgeViaIdentity, PurgeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Purge, PurgeExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the Application Insights component resource.

```yaml
Type: System.String
Parameter Sets: Purge, PurgeExpanded
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
Type: System.String
Parameter Sets: Purge, PurgeExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Table
Table from which to purge data.

```yaml
Type: System.String
Parameter Sets: PurgeExpanded, PurgeViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api202002.IComponentPurgeBody

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity

## OUTPUTS

### System.String

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IComponentPurgeBody>: Describes the body of a purge request for an App Insights component
  - `Filter <IComponentPurgeBodyFilters[]>`: The set of columns and filters (queries) to run over them to purge the resulting data.
    - `[Column <String>]`: The column of the table over which the given query should run
    - `[Key <String>]`: When filtering over custom dimensions, this key will be used as the name of the custom dimension.
    - `[Operator <String>]`: A query operator to evaluate over the provided column and value(s). Supported operators are ==, =~, in, in~, >, >=, <, <=, between, and have the same behavior as they would in a KQL query.
    - `[Value <IAny>]`: the value for the operator to function over. This can be a number (e.g., > 100), a string (timestamp >= '2017-09-01') or array of values.
  - `Table <String>`: Table from which to purge data.

FILTER <IComponentPurgeBodyFilters[]>: The set of columns and filters (queries) to run over them to purge the resulting data.
  - `[Column <String>]`: The column of the table over which the given query should run
  - `[Key <String>]`: When filtering over custom dimensions, this key will be used as the name of the custom dimension.
  - `[Operator <String>]`: A query operator to evaluate over the provided column and value(s). Supported operators are ==, =~, in, in~, >, >=, <, <=, between, and have the same behavior as they would in a KQL query.
  - `[Value <IAny>]`: the value for the operator to function over. This can be a number (e.g., > 100), a string (timestamp >= '2017-09-01') or array of values.

INPUTOBJECT <IApplicationInsightsIdentity>: Identity Parameter
  - `[AnnotationId <String>]`: The unique annotation ID. This is unique within a Application Insights component.
  - `[ComponentName <String>]`: The name of the Application Insights component resource.
  - `[ConfigurationId <String>]`: The ProactiveDetection configuration ID. This is unique within a Application Insights component.
  - `[ExportId <String>]`: The Continuous Export configuration ID. This is unique within a Application Insights component.
  - `[FavoriteId <String>]`: The Id of a specific favorite defined in the Application Insights component
  - `[Id <String>]`: Resource identity path
  - `[KeyId <String>]`: The API Key ID. This is unique within a Application Insights component.
  - `[PurgeId <String>]`: In a purge status request, this is the Id of the operation the status of which is returned.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: The name of the Application Insights component resource.
  - `[ResourceUri <String>]`: The identifier of the resource.
  - `[RevisionId <String>]`: The id of the workbook's revision.
  - `[ScopePath <ItemScopePath?>]`: Enum indicating if this item definition is owned by a specific user or is shared between all users with access to the Application Insights component.
  - `[StorageType <StorageType?>]`: The type of the Application Insights component data source for the linked storage account.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[WebTestName <String>]`: The name of the Application Insights webtest resource.
  - `[WorkItemConfigId <String>]`: The unique work item configuration Id. This can be either friendly name of connector as defined in connector configuration

## RELATED LINKS

