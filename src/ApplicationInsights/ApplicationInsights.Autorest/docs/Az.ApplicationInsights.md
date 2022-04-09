---
Module Name: Az.ApplicationInsights
Module Guid: 031a685e-5904-433f-b2f8-4fcef3cd15d8
Download Help Link: https://docs.microsoft.com/powershell/module/az.applicationinsights
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ApplicationInsights Module
## Description
Microsoft Azure PowerShell: ApplicationInsights cmdlets

## Az.ApplicationInsights Cmdlets
### [Clear-AzApplicationInsights](Clear-AzApplicationInsights.md)
Purges data in an Application Insights component by a set of user-defined filters.\n\nIn order to manage system resources, purge requests are throttled at 50 requests per hour.
You should batch the execution of purge requests by sending a single command whose predicate includes all user identities that require purging.
Use the in operator to specify multiple identities.
You should run the query prior to using for a purge request to verify that the results are expected.

### [Get-AzApplicationInsights](Get-AzApplicationInsights.md)
Returns an Application Insights component.

### [Get-AzApplicationInsightsAnnotation](Get-AzApplicationInsightsAnnotation.md)
Get the annotation for given id.

### [Get-AzApplicationInsightsApiKey](Get-AzApplicationInsightsApiKey.md)
Get the API Key for this key id.

### [Get-AzApplicationInsightsComponentAvailableFeature](Get-AzApplicationInsightsComponentAvailableFeature.md)
Returns all available features of the application insights component.

### [Get-AzApplicationInsightsComponentFeatureCapability](Get-AzApplicationInsightsComponentFeatureCapability.md)
Returns feature capabilities of the application insights component.

### [Get-AzApplicationInsightsComponentPurgeStatus](Get-AzApplicationInsightsComponentPurgeStatus.md)
Get status for an ongoing purge operation.

### [Get-AzApplicationInsightsContinuousExport](Get-AzApplicationInsightsContinuousExport.md)
Get the Continuous Export configuration for this export id.

### [Get-AzApplicationInsightsLinkedStorageAccount](Get-AzApplicationInsightsLinkedStorageAccount.md)
Returns the current linked storage settings for an Application Insights component.

### [Get-AzApplicationInsightsWebTest](Get-AzApplicationInsightsWebTest.md)
Get a specific Application Insights web test definition.

### [New-AzApplicationInsights](New-AzApplicationInsights.md)
Creates (or updates) an Application Insights component.
Note: You cannot specify a different value for InstrumentationKey nor AppId in the Put operation.

### [New-AzApplicationInsightsAnnotation](New-AzApplicationInsightsAnnotation.md)
Create an Annotation of an Application Insights component.

### [New-AzApplicationInsightsApiKey](New-AzApplicationInsightsApiKey.md)
Create an API Key of an Application Insights component.

### [New-AzApplicationInsightsContinuousExport](New-AzApplicationInsightsContinuousExport.md)
Create a Continuous Export configuration of an Application Insights component.

### [New-AzApplicationInsightsLinkedStorageAccount](New-AzApplicationInsightsLinkedStorageAccount.md)
Replace current linked storage account for an Application Insights component.

### [New-AzApplicationInsightsWebTest](New-AzApplicationInsightsWebTest.md)
Creates or updates an Application Insights web test definition.

### [New-AzApplicationInsightsWebTestGeolocationObject](New-AzApplicationInsightsWebTestGeolocationObject.md)
Create an in-memory object for WebTestGeolocation.

### [New-AzApplicationInsightsWebTestHeaderFieldObject](New-AzApplicationInsightsWebTestHeaderFieldObject.md)
Create a in-memory object for HeaderField

### [Remove-AzApplicationInsights](Remove-AzApplicationInsights.md)
Deletes an Application Insights component.

### [Remove-AzApplicationInsightsAnnotation](Remove-AzApplicationInsightsAnnotation.md)
Delete an Annotation of an Application Insights component.

### [Remove-AzApplicationInsightsApiKey](Remove-AzApplicationInsightsApiKey.md)
Delete an API Key of an Application Insights component.

### [Remove-AzApplicationInsightsContinuousExport](Remove-AzApplicationInsightsContinuousExport.md)
Delete a Continuous Export configuration of an Application Insights component.

### [Remove-AzApplicationInsightsLinkedStorageAccount](Remove-AzApplicationInsightsLinkedStorageAccount.md)
Delete linked storage accounts for an Application Insights component.

### [Remove-AzApplicationInsightsWebTest](Remove-AzApplicationInsightsWebTest.md)
Deletes an Application Insights web test.

### [Set-AzApplicationInsights](Set-AzApplicationInsights.md)
Creates (or updates) an Application Insights component.
Note: You cannot specify a different value for InstrumentationKey nor AppId in the Put operation.

### [Set-AzApplicationInsightsContinuousExport](Set-AzApplicationInsightsContinuousExport.md)
Create a Continuous Export configuration of an Application Insights component.

### [Set-AzApplicationInsightsDailyCap](Set-AzApplicationInsightsDailyCap.md)
Update current billing features for an Application Insights component.

### [Set-AzApplicationInsightsPricingPlan](Set-AzApplicationInsightsPricingPlan.md)
Update current billing features for an Application Insights component.

### [Set-AzApplicationInsightsWebTest](Set-AzApplicationInsightsWebTest.md)
Creates or updates an Application Insights web test definition.

### [Update-AzApplicationInsights](Update-AzApplicationInsights.md)
Creates (or updates) an Application Insights component.
Note: You cannot specify a different value for InstrumentationKey nor AppId in the Put operation.

### [Update-AzApplicationInsightsComponentTag](Update-AzApplicationInsightsComponentTag.md)
Updates an existing component's tags.
To update other fields use the CreateOrUpdate method.

### [Update-AzApplicationInsightsLinkedStorageAccount](Update-AzApplicationInsightsLinkedStorageAccount.md)
Update linked storage accounts for an Application Insights component.

### [Update-AzApplicationInsightsWebTestTag](Update-AzApplicationInsightsWebTestTag.md)
Creates or updates an Application Insights web test definition.

