---
Module Name: Az.ApplicationInsights
Module Guid: 18307057-db6b-461e-924f-334f311ef139
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.applicationinsights
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ApplicationInsights Module
## Description
Microsoft Azure PowerShell: ApplicationInsights cmdlets

## Az.ApplicationInsights Cmdlets
### [Add-AzApplicationInsightsFavorite](Add-AzApplicationInsightsFavorite.md)
Adds a new favorites to an Application Insights component.

### [Clear-AzApplicationInsightsComponent](Clear-AzApplicationInsightsComponent.md)
Purges data in an Application Insights component by a set of user-defined filters.\n\nIn order to manage system resources, purge requests are throttled at 50 requests per hour.
You should batch the execution of purge requests by sending a single command whose predicate includes all user identities that require purging.
Use the in operator to specify multiple identities.
You should run the query prior to using for a purge request to verify that the results are expected.

### [Get-AzApplicationInsightsAnalyticsItem](Get-AzApplicationInsightsAnalyticsItem.md)
Gets a specific Analytics Items defined within an Application Insights component.

### [Get-AzApplicationInsightsAnnotation](Get-AzApplicationInsightsAnnotation.md)
Get the annotation for given id.

### [Get-AzApplicationInsightsApiKey](Get-AzApplicationInsightsApiKey.md)
Get the API Key for this key id.

### [Get-AzApplicationInsightsComponent](Get-AzApplicationInsightsComponent.md)
Returns an Application Insights component.

### [Get-AzApplicationInsightsComponentAvailableFeature](Get-AzApplicationInsightsComponentAvailableFeature.md)
Returns all available features of the application insights component.

### [Get-AzApplicationInsightsComponentCurrentBillingFeature](Get-AzApplicationInsightsComponentCurrentBillingFeature.md)
Returns current billing features for an Application Insights component.

### [Get-AzApplicationInsightsComponentFeatureCapability](Get-AzApplicationInsightsComponentFeatureCapability.md)
Returns feature capabilities of the application insights component.

### [Get-AzApplicationInsightsComponentLinkedStorageAccount](Get-AzApplicationInsightsComponentLinkedStorageAccount.md)
Returns the current linked storage settings for an Application Insights component.

### [Get-AzApplicationInsightsComponentPurgeStatus](Get-AzApplicationInsightsComponentPurgeStatus.md)
Get status for an ongoing purge operation.

### [Get-AzApplicationInsightsComponentQuotaStatus](Get-AzApplicationInsightsComponentQuotaStatus.md)
Returns daily data volume cap (quota) status for an Application Insights component.

### [Get-AzApplicationInsightsExportConfiguration](Get-AzApplicationInsightsExportConfiguration.md)
Get the Continuous Export configuration for this export id.

### [Get-AzApplicationInsightsFavorite](Get-AzApplicationInsightsFavorite.md)
Get a single favorite by its FavoriteId, defined within an Application Insights component.

### [Get-AzApplicationInsightsLiveToken](Get-AzApplicationInsightsLiveToken.md)
**Gets an access token for live metrics stream data.**

### [Get-AzApplicationInsightsMyWorkbook](Get-AzApplicationInsightsMyWorkbook.md)
Get a single private workbook by its resourceName.

### [Get-AzApplicationInsightsProactiveDetectionConfiguration](Get-AzApplicationInsightsProactiveDetectionConfiguration.md)
Get the ProactiveDetection configuration for this configuration id.

### [Get-AzApplicationInsightsWebTest](Get-AzApplicationInsightsWebTest.md)
Get a specific Application Insights web test definition.

### [Get-AzApplicationInsightsWebTestLocation](Get-AzApplicationInsightsWebTestLocation.md)
Gets a list of web test locations available to this Application Insights component.

### [Get-AzApplicationInsightsWorkbook](Get-AzApplicationInsightsWorkbook.md)
Get a single workbook by its resourceName.

### [Get-AzApplicationInsightsWorkbookRevision](Get-AzApplicationInsightsWorkbookRevision.md)
Get a single workbook revision defined by its revisionId.

### [Get-AzApplicationInsightsWorkbookTemplate](Get-AzApplicationInsightsWorkbookTemplate.md)
Get a single workbook template by its resourceName.

### [Get-AzApplicationInsightsWorkItemConfiguration](Get-AzApplicationInsightsWorkItemConfiguration.md)
Gets the list work item configurations that exist for the application

### [Get-AzApplicationInsightsWorkItemConfigurationDefault](Get-AzApplicationInsightsWorkItemConfigurationDefault.md)
Gets default work item configurations that exist for the application

### [Get-AzApplicationInsightsWorkItemConfigurationItem](Get-AzApplicationInsightsWorkItemConfigurationItem.md)
Gets specified work item configuration for an Application Insights component.

### [New-AzApplicationInsightsAnnotation](New-AzApplicationInsightsAnnotation.md)
Create an Annotation of an Application Insights component.

### [New-AzApplicationInsightsApiKey](New-AzApplicationInsightsApiKey.md)
Create an API Key of an Application Insights component.

### [New-AzApplicationInsightsComponent](New-AzApplicationInsightsComponent.md)
Creates (or updates) an Application Insights component.
Note: You cannot specify a different value for InstrumentationKey nor AppId in the Put operation.

### [New-AzApplicationInsightsComponentLinkedStorageAccountAndUpdate](New-AzApplicationInsightsComponentLinkedStorageAccountAndUpdate.md)
Replace current linked storage account for an Application Insights component.

### [New-AzApplicationInsightsExportConfiguration](New-AzApplicationInsightsExportConfiguration.md)
Create a Continuous Export configuration of an Application Insights component.

### [New-AzApplicationInsightsMyWorkbook](New-AzApplicationInsightsMyWorkbook.md)
Create a new private workbook.

### [New-AzApplicationInsightsWebTest](New-AzApplicationInsightsWebTest.md)
Creates or updates an Application Insights web test definition.

### [New-AzApplicationInsightsWorkbook](New-AzApplicationInsightsWorkbook.md)
Create a new workbook.

### [New-AzApplicationInsightsWorkbookTemplate](New-AzApplicationInsightsWorkbookTemplate.md)
Create a new workbook template.

### [New-AzApplicationInsightsWorkItemConfiguration](New-AzApplicationInsightsWorkItemConfiguration.md)
Create a work item configuration for an Application Insights component.

### [Remove-AzApplicationInsightsAnalyticsItem](Remove-AzApplicationInsightsAnalyticsItem.md)
Deletes a specific Analytics Items defined within an Application Insights component.

### [Remove-AzApplicationInsightsAnnotation](Remove-AzApplicationInsightsAnnotation.md)
Delete an Annotation of an Application Insights component.

### [Remove-AzApplicationInsightsApiKey](Remove-AzApplicationInsightsApiKey.md)
Delete an API Key of an Application Insights component.

### [Remove-AzApplicationInsightsComponent](Remove-AzApplicationInsightsComponent.md)
Deletes an Application Insights component.

### [Remove-AzApplicationInsightsComponentLinkedStorageAccount](Remove-AzApplicationInsightsComponentLinkedStorageAccount.md)
Delete linked storage accounts for an Application Insights component.

### [Remove-AzApplicationInsightsExportConfiguration](Remove-AzApplicationInsightsExportConfiguration.md)
Delete a Continuous Export configuration of an Application Insights component.

### [Remove-AzApplicationInsightsFavorite](Remove-AzApplicationInsightsFavorite.md)
Remove a favorite that is associated to an Application Insights component.

### [Remove-AzApplicationInsightsMyWorkbook](Remove-AzApplicationInsightsMyWorkbook.md)
Delete a private workbook.

### [Remove-AzApplicationInsightsWebTest](Remove-AzApplicationInsightsWebTest.md)
Deletes an Application Insights web test.

### [Remove-AzApplicationInsightsWorkbook](Remove-AzApplicationInsightsWorkbook.md)
Delete a workbook.

### [Remove-AzApplicationInsightsWorkbookTemplate](Remove-AzApplicationInsightsWorkbookTemplate.md)
Delete a workbook template.

### [Remove-AzApplicationInsightsWorkItemConfiguration](Remove-AzApplicationInsightsWorkItemConfiguration.md)
Delete a work item configuration of an Application Insights component.

### [Update-AzApplicationInsightsComponentLinkedStorageAccount](Update-AzApplicationInsightsComponentLinkedStorageAccount.md)
Update linked storage accounts for an Application Insights component.

### [Update-AzApplicationInsightsComponentTag](Update-AzApplicationInsightsComponentTag.md)
Updates an existing component's tags.
To update other fields use the CreateOrUpdate method.

### [Update-AzApplicationInsightsFavorite](Update-AzApplicationInsightsFavorite.md)
Updates a favorite that has already been added to an Application Insights component.

### [Update-AzApplicationInsightsMyWorkbook](Update-AzApplicationInsightsMyWorkbook.md)
Updates a private workbook that has already been added.

### [Update-AzApplicationInsightsWebTestTag](Update-AzApplicationInsightsWebTestTag.md)
Creates or updates an Application Insights web test definition.

### [Update-AzApplicationInsightsWorkbook](Update-AzApplicationInsightsWorkbook.md)
Updates a workbook that has already been added.

### [Update-AzApplicationInsightsWorkbookTemplate](Update-AzApplicationInsightsWorkbookTemplate.md)
Updates a workbook template that has already been added.

### [Update-AzApplicationInsightsWorkItemConfigurationItem](Update-AzApplicationInsightsWorkItemConfigurationItem.md)
Update a work item configuration for an Application Insights component.

