---
external help file:
Module Name: Az.ApplicationInsights
online version: https://docs.microsoft.com/powershell/module/az.applicationinsights/get-azapplicationinsightsapikey
schema: 2.0.0
---

# Get-AzApplicationInsightsApiKey

## SYNOPSIS
Get the API Key for this key id.

## SYNTAX

### List (Default)
```
Get-AzApplicationInsightsApiKey -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzApplicationInsightsApiKey -ApiKeyId <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzApplicationInsightsApiKey -InputObject <IApplicationInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the API Key for this key id.

## EXAMPLES

### Example 1: Get Api Keys for an application insights resource
```powershell
Get-AzApplicationInsightsApiKey -ResourceGroupName "testGroup" -Name "test"
```

Get Api Keys for an application insights resource

### Example 2: Get specific API key for an application insights resource
```powershell
Get-AzApplicationInsightsApiKey -ResourceGroupName "testGroup" -Name "test" -ApiKeyId 7c4c61dc-b392-4aa4-992f-ee92b84e5dee
```

Get specific API key for an application insights resource

## PARAMETERS

### -ApiKeyId
The API Key ID.
This is unique within a Application Insights component.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
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
The name of the Application Insights component resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases: ApplicationInsightsComponentName, ComponentName

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentApiKey

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IApplicationInsightsIdentity>`: Identity Parameter
  - `[AnnotationId <String>]`: The unique annotation ID. This is unique within a Application Insights component.
  - `[ComponentName <String>]`: The name of the Application Insights component resource.
  - `[ExportId <String>]`: The Continuous Export configuration ID. This is unique within a Application Insights component.
  - `[Id <String>]`: Resource identity path
  - `[KeyId <String>]`: The API Key ID. This is unique within a Application Insights component.
  - `[PurgeId <String>]`: In a purge status request, this is the Id of the operation the status of which is returned.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: The name of the Application Insights component resource.
  - `[StorageType <StorageType?>]`: The type of the Application Insights component data source for the linked storage account.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[WebTestName <String>]`: The name of the Application Insights WebTest resource.

## RELATED LINKS

