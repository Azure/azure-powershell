# Overall
This directory contains the service clients of Az.Sql module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
title: SqlManagementClient
use-extension:
  "@autorest/powershell": "4.x"
```

###
``` yaml
commit: b7b77b11ba1f6defc86d309d4ca0d51b2a2646a7
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01/metrics.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01-legacy/sql.core_legacy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-05-01-preview/ServerDevOpsAudit.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-11-01-preview/BlobAuditing.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/SyncGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseSecurityAlertPolicies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseVulnerabilityAssesmentRuleBaselines.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseVulnerabilityAssessments.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseVulnerabilityAssessmentScans.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ElasticPoolOperations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/EncryptionProtectors.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/InstancePools.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/JobAgents.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/JobCredentials.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/JobExecutions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/Jobs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/JobStepExecutions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/JobSteps.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/JobTargetExecutions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/JobTargetGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/JobVersions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/JobPrivateEndpoints.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-05-01-preview/LocationCapabilities.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/LongTermRetentionPolicies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedBackupShortTermRetentionPolicies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseVulnerabilityAssessmentRuleBaselines.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseVulnerabilityAssessments.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseVulnerabilityAssessmentScans.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceAdministrators.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceAzureADOnlyAuthentications.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceEncryptionProtectors.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceKeys.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceLongTermRetentionPolicies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceOperations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceTdeCertificates.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceVulnerabilityAssessments.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedServerSecurityAlertPolicies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/RecoverableManagedDatabases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/RestorePoints.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerAzureADAdministrators.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerAzureADOnlyAuthentications.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerDnsAliases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerKeys.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerSecurityAlertPolicies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerTrustGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerVulnerabilityAssessments.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/SyncMembers.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/TdeCertificates.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/VirtualNetworkRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/TransparentDataEncryptions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/BackupShortTermRetentionPolicies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/DatabaseOperations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/LedgerDigestUploads.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/OutboundFirewallRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/Usages.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-05-01-preview/LongTermRetentionBackups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-05-01-preview/LongTermRetentionManagedInstanceBackups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-05-01-preview/RestorableDroppedManagedDatabases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-11-01-preview/DistributedAvailabilityGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-11-01-preview/ServerTrustCertificates.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-11-01-preview/EndpointCertificates.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseSensitivityLabels.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/SensitivityLabels.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-11-01-preview/IPv6FirewallRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-02-01-preview/Databases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-02-01-preview/ReplicationLinks.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/VirtualClusters.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-02-01-preview/ManagedDatabaseAdvancedThreatProtectionSettings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-02-01-preview/ManagedInstanceAdvancedThreatProtectionSettings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-02-01-preview/DatabaseAdvancedThreatProtectionSettings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-02-01-preview/ServerAdvancedThreatProtectionSettings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2021-11-01-preview/ManagedServerDnsAliases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-05-01-preview/ManagedInstanceDtcs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-05-01-preview/ManagedDatabaseRestoreDetails.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/DatabaseEncryptionProtectorRevalidate.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/DatabaseEncryptionProtectorRevert.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/RecoverableDatabases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/RestorableDroppedDatabases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-05-01-preview/InstanceFailoverGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-02-01-preview/Servers.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/ServerConfigurationOptions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/ManagedLedgerDigestUploads.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/ManagedDatabases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/ElasticPools.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2023-02-01-preview/FailoverGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/ManagedDatabaseMoveOperations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/ManagedInstances.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/preview/2022-08-01-preview/StartStopManagedInstanceSchedules.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Sql
```
