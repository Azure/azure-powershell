---
external help file:
Module Name: Az.ApplicationInsights
online version: https://docs.microsoft.com/en-us/powershell/module/az.applicationinsights/get-azapplicationinsightsanalyticsitem
schema: 2.0.0
---

# Get-AzApplicationInsightsAnalyticsItem

## SYNOPSIS
Gets a specific Analytics Items defined within an Application Insights component.

## SYNTAX

### Get (Default)
```
Get-AzApplicationInsightsAnalyticsItem -ResourceGroupName <String> -ResourceName <String>
 -ScopePath <ItemScopePath> [-SubscriptionId <String[]>] [-Id <String>] [-Name <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzApplicationInsightsAnalyticsItem -InputObject <IApplicationInsightsIdentity> [-Id <String>]
 [-Name <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzApplicationInsightsAnalyticsItem -ResourceGroupName <String> -ResourceName <String>
 -ScopePath <ItemScopePath> [-SubscriptionId <String[]>] [-IncludeContent] [-Scope <ItemScope>]
 [-Type <ItemTypeParameter>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a specific Analytics Items defined within an Application Insights component.

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

### -Id
The Id of a specific item defined in the Application Insights component

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeContent
Flag indicating whether or not to return the content of each applicable item.
If false, only return the item information.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of a specific item defined in the Application Insights component

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Enum indicating if this item definition is owned by a specific user or is shared between all users with access to the Application Insights component.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.ItemScope
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopePath
Enum indicating if this item definition is owned by a specific user or is shared between all users with access to the Application Insights component.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.ItemScopePath
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Enum indicating the type of the Analytics item.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.ItemTypeParameter
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentAnalyticsItem

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


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

