# Overall
This directory contains management plane service clients of Az.Security module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
autorest.cmd README.md --version=v2
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
```



###
``` yaml
commit: 312544c27464f61bf9639924099d4238bdfa1d71
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2021-10-01-preview/mdeOnboardings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2021-07-01-preview/customAssessmentAutomation.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2021-07-01-preview/customEntityStoreAssignment.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2017-08-01/complianceResults.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2022-03-01/pricings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2019-01-01/advancedThreatProtectionSettings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2019-08-01/deviceSecurityGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2019-08-01/iotSecuritySolutions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2019-08-01/iotSecuritySolutionAnalytics.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2015-06-01-preview/locations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2015-06-01-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2015-06-01-preview/tasks.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2017-08-01-preview/autoProvisioningSettings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2017-08-01-preview/compliances.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2017-08-01-preview/informationProtectionPolicies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2020-01-01-preview/securityContacts.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2017-08-01-preview/workspaceSettings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2019-01-01-preview/regulatoryCompliance.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2019-01-01-preview/subAssessments.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2019-01-01-preview/automations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2019-01-01-preview/alertsSuppressionRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/serverVulnerabilityAssessments.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2021-06-01/assessmentMetadata.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2021-06-01/assessments.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/applicationWhitelistings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/adaptiveNetworkHardenings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/allowedConnections.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/topologies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/jitNetworkAccessPolicies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/discoveredSecuritySolutions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/securitySolutionsReferenceData.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/externalSecuritySolutions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/secureScore.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/SecuritySolutions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2020-01-01-preview/connectors.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2020-07-01-preview/sqlVulnerabilityAssessmentsScanOperations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2020-07-01-preview/sqlVulnerabilityAssessmentsScanResultsOperations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2020-07-01-preview/sqlVulnerabilityAssessmentsBaselineRuleOperations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2022-01-01/alerts.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/stable/2022-05-01/settings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2021-01-15-preview/ingestionSettings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2021-05-01-preview/softwareInventories.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2022-08-01-preview/securityConnectors.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2022-01-01-preview/governanceRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2022-01-01-preview/governanceAssignments.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/security/resource-manager/Microsoft.Security/preview/2022-07-01-preview/applications.json

override-info:
  title: SecurityCenter

directive:
  - from: securityContacts.json
    where: $.definitions.SecurityContactProperties.properties.alertNotifications.properties.state
    transform: >
        $['x-ms-enum']['name'] = 'SecurityAlertNotificationState';
  - from: securityContacts.json
    where: $.definitions.SecurityContactProperties.properties.notificationsByRole.properties.state
    transform: >
        $['x-ms-enum']['name'] = 'SecurityAlertNotificationByRoleState';
  - from: swagger-document
    where: $.parameters.AscLocation
    transform: >
        $['x-ms-parameter-location'] = 'client';

output-folder: Generated
namespace: Microsoft.Azure.Management.Security
```