<!-- region Generated -->
# Az.Security
This directory contains the PowerShell module for the Security service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Security`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

###
``` yaml
commit: a427dd4d108b1fb93340dfeca3994de1c695b53b
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/security/resource-manager/Microsoft.Security/Security/preview/2023-10-01-preview/securityConnectors.json
  - $(repo)/specification/security/resource-manager/Microsoft.Security/Security/preview/2023-09-01-preview/securityConnectorsDevOps.json
  - $(repo)/specification/security/resource-manager/Microsoft.Security/Security/stable/2023-11-15/apiCollections.json
  - $(repo)/specification/security/resource-manager/Microsoft.Security/Security/preview/2026-04-01-preview/security-SqlVulnerabilityAssessments.json

title: Security
module-version: 1.5.1
subject-prefix: $(service-name)
enable-parent-pipeline-input: false

directive:
  - rename-model:
      from: EnvironmentData
      to: SecurityConnectorEnvironment
  - rename-model:
      from: AwsEnvironmentData
      to: AwsEnvironment
  - rename-model:
      from: GcpProjectEnvironmentData
      to: GcpProjectEnvironment
  - rename-model:
      from: AzureDevOpsScopeEnvironmentData
      to: AzureDevOpsScopeEnvironment
  - rename-model:
      from: GitlabScopeEnvironmentData
      to: GitLabScopeEnvironment
  - rename-model:
      from: GithubScopeEnvironmentData
      to: GitHubScopeEnvironment

  - from: securityConnectors.json
    where: $.definitions
    debug: true
    transform: >
      $.defenderFoDatabasesAwsOffering['x-ms-client-name'] = 'DefenderForDatabasesAwsOffering'

  - from: types.json
    where: $.definitions.Kind
    transform: >
      $['x-ms-client-name'] = 'ResourceKind';
  
  - from: apiCollections.json
    where: $.paths..operationId
    transform: >
      return $.replace(/OffboardAzureApiManagementApi$/g, "ApiCollectionAPIM_Delete")
  
  - where:
      verb: Invoke
      subject: ^AzureApiCollection$
    set:
      subject: ApiCollectionApimOnboard

  - where:
      verb: Remove
      subject: ^ApiCollectionApim$
    set:
      verb: Invoke
      subject: ApiCollectionApimOffboard
  
  # New-* cmdlets, ViaIdentity is not required
  - where:
      variant: ^(Create|Update)(?!.*?Expanded|JsonFilePath|JsonString)
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  - where:
      subject: ^(DevOpsConfiguration|AzureDevOps|GitHub|GitLab)(.*)
    set:
      subject-prefix: SecurityConnector

  - where:
      subject: (.*)(AzureDevOpsRepos)$
    set:
      subject: $1AzureDevOpsRepo
  
  - where:
      subject: (.*)(GitHubRepos)$
    set:
      subject: $1GitHubRepo

  - where:
      verb: New
      subject: ^(AzureDevOpsOrg|AzureDevOpsProject|AzureDevOpsRepo)(.*)
    remove: true
  
  - where:
      subject: ^(DevOpsOperationResult)(.*)
    remove: true

  # ScanOperationResult is only used internally to poll the InitiateScan long-running-operation; not meant to be called directly
  - where:
      subject: ^(SqlVulnerabilityAssessmentScanOperationResult)(.*)
    remove: true

  # Avoid a cmdlet name collision with the legacy (2020-07-01-preview) hand-written
  # Get-AzSecuritySqlVulnerabilityAssessmentScanResult cmdlet in src/Security/Security/Cmdlets/SqlVulnerabilityAssessment
  - where:
      subject: ^(SqlVulnerabilityAssessmentScanResult)(.*)
    set:
      subject: SqlVulnerabilityAssessmentScanResultV2

  # SQL Vulnerability Assessment (2026-04-01-preview) cmdlets are preview
  - where:
      subject: (.*)SqlVulnerabilityAssessment(.*)
    set:
      preview-announcement:
        preview-message: Cmdlets for Sql Vulnerability Assessment are in preview.
        estimated-ga-date: 2027-04-01

  - where:
      subject: ^(DevOpsConfiguration|AzureDevOps|GitHub|GitLab)(.*)
      parameter-name: ProvisioningState
    hide: true

  - where:
      verb: Update
      subject: ^(AzureDevOps)(.*)
      parameter-name: OnboardingState
    hide: true

  - where:
      model-name: SecurityConnector
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - EnvironmentName
          - Location
          - HierarchyIdentifier

  - no-inline:
    - SecurityConnectorEnvironment
    - AwsOrganizationalData
    - GcpOrganizationalData
    - ActionableRemediation
  
  - model-cmdlet:
    - model-name: AwsEnvironment
    - model-name: AwsOrganizationalDataMaster
    - model-name: AwsOrganizationalDataMember
    - model-name: GcpProjectEnvironment
    - model-name: GcpOrganizationalDataOrganization
    - model-name: GcpOrganizationalDataMember
    - model-name: AzureDevOpsScopeEnvironment
    - model-name: GitLabScopeEnvironment
    - model-name: GitHubScopeEnvironment
    - model-name: CspmMonitorAwsOffering
    - model-name: CspmMonitorGcpOffering
    - model-name: CspmMonitorGithubOffering
    - model-name: CspmMonitorAzureDevOpsOffering
    - model-name: CspmMonitorGitLabOffering
    - model-name: DefenderCspmAwsOffering
    - model-name: DefenderCspmGcpOffering
    - model-name: DefenderForContainersAwsOffering
    - model-name: DefenderForContainersGcpOffering
    - model-name: DefenderForDatabasesAwsOffering
    - model-name: DefenderForDatabasesGcpOffering
    - model-name: DefenderForServersAwsOffering
    - model-name: DefenderForServersGcpOffering
    - model-name: InformationProtectionAwsOffering
    - model-name: ActionableRemediation
      cmdlet-name: New-AzSecurityConnectorActionableRemediationObject
```
