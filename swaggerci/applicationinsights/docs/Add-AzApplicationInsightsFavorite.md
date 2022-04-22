---
external help file:
Module Name: Az.ApplicationInsights
online version: https://docs.microsoft.com/en-us/powershell/module/az.applicationinsights/add-azapplicationinsightsfavorite
schema: 2.0.0
---

# Add-AzApplicationInsightsFavorite

## SYNOPSIS
Adds a new favorites to an Application Insights component.

## SYNTAX

### AddExpanded (Default)
```
Add-AzApplicationInsightsFavorite -Id <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-Category <String>] [-Config <String>] [-FavoriteType <FavoriteType>]
 [-IsGeneratedFromTemplate] [-Name <String>] [-SourceType <String>] [-Tag <String[]>] [-Version <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Add
```
Add-AzApplicationInsightsFavorite -Id <String> -ResourceGroupName <String> -ResourceName <String>
 -FavoriteProperty <IApplicationInsightsComponentFavorite> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddViaIdentity
```
Add-AzApplicationInsightsFavorite -InputObject <IApplicationInsightsIdentity>
 -FavoriteProperty <IApplicationInsightsComponentFavorite> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### AddViaIdentityExpanded
```
Add-AzApplicationInsightsFavorite -InputObject <IApplicationInsightsIdentity> [-Category <String>]
 [-Config <String>] [-FavoriteType <FavoriteType>] [-IsGeneratedFromTemplate] [-Name <String>]
 [-SourceType <String>] [-Tag <String[]>] [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Adds a new favorites to an Application Insights component.

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

### -Category
Favorite category, as defined by the user at creation time.

```yaml
Type: System.String
Parameter Sets: AddExpanded, AddViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Config
Configuration of this particular favorite, which are driven by the Azure portal UX.
Configuration data is a string containing valid JSON

```yaml
Type: System.String
Parameter Sets: AddExpanded, AddViaIdentityExpanded
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

### -FavoriteProperty
Properties that define a favorite that is associated to an Application Insights component.
To construct, see NOTES section for FAVORITEPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentFavorite
Parameter Sets: Add, AddViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FavoriteType
Enum indicating if this favorite definition is owned by a specific user or is shared between all users with access to the Application Insights component.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.FavoriteType
Parameter Sets: AddExpanded, AddViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The Id of a specific favorite defined in the Application Insights component

```yaml
Type: System.String
Parameter Sets: Add, AddExpanded
Aliases: FavoriteId

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
Parameter Sets: AddViaIdentity, AddViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsGeneratedFromTemplate
Flag denoting wether or not this favorite was generated from a template.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AddExpanded, AddViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The user-defined name of the favorite.

```yaml
Type: System.String
Parameter Sets: AddExpanded, AddViaIdentityExpanded
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
Parameter Sets: Add, AddExpanded
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
Parameter Sets: Add, AddExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceType
The source of the favorite definition.

```yaml
Type: System.String
Parameter Sets: AddExpanded, AddViaIdentityExpanded
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
Parameter Sets: Add, AddExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
A list of 0 or more tags that are associated with this favorite definition

```yaml
Type: System.String[]
Parameter Sets: AddExpanded, AddViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
This instance's version of the data model.
This can change as new features are added that can be marked favorite.
Current examples include MetricsExplorer (ME) and Search.

```yaml
Type: System.String
Parameter Sets: AddExpanded, AddViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentFavorite

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentFavorite

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FAVORITEPROPERTY <IApplicationInsightsComponentFavorite>: Properties that define a favorite that is associated to an Application Insights component.
  - `[Category <String>]`: Favorite category, as defined by the user at creation time.
  - `[Config <String>]`: Configuration of this particular favorite, which are driven by the Azure portal UX. Configuration data is a string containing valid JSON
  - `[FavoriteType <FavoriteType?>]`: Enum indicating if this favorite definition is owned by a specific user or is shared between all users with access to the Application Insights component.
  - `[IsGeneratedFromTemplate <Boolean?>]`: Flag denoting wether or not this favorite was generated from a template.
  - `[Name <String>]`: The user-defined name of the favorite.
  - `[SourceType <String>]`: The source of the favorite definition.
  - `[Tag <String[]>]`: A list of 0 or more tags that are associated with this favorite definition
  - `[Version <String>]`: This instance's version of the data model. This can change as new features are added that can be marked favorite. Current examples include MetricsExplorer (ME) and Search.

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

