---
external help file:
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.applicationinsights/update-azapplicationinsights
schema: 2.0.0
---

# Update-AzApplicationInsights

## SYNOPSIS
Creates (or updates) an Application Insights component.
Note: You cannot specify a different value for InstrumentationKey nor AppId in the Put operation.

## SYNTAX

```
Update-AzApplicationInsights -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ApplicationType <ApplicationType>] [-DisableIPMasking] [-DisableLocalAuth] [-Etag <String>]
 [-FlowType <FlowType>] [-ForceCustomerStorageForProfiler] [-HockeyAppId <String>]
 [-ImmediatePurgeDataOn30Day] [-IngestionMode <IngestionMode>]
 [-PublicNetworkAccessForIngestion <PublicNetworkAccessType>]
 [-PublicNetworkAccessForQuery <PublicNetworkAccessType>] [-RequestSource <RequestSource>]
 [-RetentionInDays <Int32>] [-SamplingPercentage <Double>] [-Tag <Hashtable>] [-WorkspaceResourceId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates (or updates) an Application Insights component.
Note: You cannot specify a different value for InstrumentationKey nor AppId in the Put operation.

## EXAMPLES

### Example 1: Update application insights component
```powershell
Update-AzApplicationInsights -ResourceGroupName "rgName" -Name "aiName" -PublicNetworkAccessForIngestion "Disabled" -PublicNetworkAccessForQuery "Disabled"
```

update application insights component "aiName" PublicNetworkAccessForIngestion/PublicNetworkAccessForQuery both to "Disabled"

## PARAMETERS

### -ApplicationType
Type of application being monitored.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.ApplicationType
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

### -DisableIPMasking
Disable IP masking.

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

### -DisableLocalAuth
Disable Non-AAD based Auth.

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

### -Etag
Resource etag

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

### -FlowType
Used by the Application Insights system to determine what kind of flow this component was created by.
This is to be set to 'Bluefield' when creating/updating a component via the REST API.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.FlowType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForceCustomerStorageForProfiler
Force users to create their own storage account for profiler and debugger.

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

### -HockeyAppId
The unique application ID created when a new application is added to HockeyApp, used for communications with HockeyApp.

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

### -ImmediatePurgeDataOn30Day
Purge data immediately after 30 days.

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

### -IngestionMode
Indicates the flow of the ingestion.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.IngestionMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Application Insights component resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ApplicationInsightsComponentName, ComponentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccessForIngestion
The network access type for accessing Application Insights ingestion.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.PublicNetworkAccessType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccessForQuery
The network access type for accessing Application Insights query.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.PublicNetworkAccessType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestSource
Describes what tool created this Application Insights component.
Customers using this API should set this to the default 'rest'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.RequestSource
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionInDays
Retention period in days.

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

### -SamplingPercentage
Percentage of the data produced by the application being monitored that is being sampled for Application Insights telemetry.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases: Tags

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceResourceId
Resource Id of the log analytics workspace which the data will be ingested to.
This property is required to create an application with this API version.
Applications from older versions will not have this property.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api202002.IApplicationInsightsComponent

## NOTES

ALIASES

## RELATED LINKS

