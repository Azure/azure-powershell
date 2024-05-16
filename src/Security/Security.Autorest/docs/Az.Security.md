---
Module Name: Az.Security
Module Guid: 6f1c0dfd-dfcd-4e5b-b77c-a64a9d355ebf
Download Help Link: https://learn.microsoft.com/powershell/module/az.security
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Security Module
## Description
Microsoft Azure PowerShell: Security cmdlets

## Az.Security Cmdlets
### [Get-AzSecurityApiCollection](Get-AzSecurityApiCollection.md)
Gets an Azure API Management API if it has been onboarded to Microsoft Defender for APIs.
If an Azure API Management API is onboarded to Microsoft Defender for APIs, the system will monitor the operations within the Azure API Management API for intrusive behaviors and provide alerts for attacks that have been detected.

### [Get-AzSecurityConnector](Get-AzSecurityConnector.md)
Retrieves details of a specific security connector

### [Get-AzSecurityConnectorAzureDevOpsOrg](Get-AzSecurityConnectorAzureDevOpsOrg.md)
Returns a monitored Azure DevOps organization resource.

### [Get-AzSecurityConnectorAzureDevOpsOrgAvailable](Get-AzSecurityConnectorAzureDevOpsOrgAvailable.md)
Returns a list of all Azure DevOps organizations accessible by the user token consumed by the connector.

### [Get-AzSecurityConnectorAzureDevOpsProject](Get-AzSecurityConnectorAzureDevOpsProject.md)
Returns a monitored Azure DevOps project resource.

### [Get-AzSecurityConnectorAzureDevOpsRepo](Get-AzSecurityConnectorAzureDevOpsRepo.md)
Returns a monitored Azure DevOps repository resource.

### [Get-AzSecurityConnectorDevOpsConfiguration](Get-AzSecurityConnectorDevOpsConfiguration.md)
Gets a DevOps Configuration.

### [Get-AzSecurityConnectorGitHubOwner](Get-AzSecurityConnectorGitHubOwner.md)
Returns a monitored GitHub owner.

### [Get-AzSecurityConnectorGitHubOwnerAvailable](Get-AzSecurityConnectorGitHubOwnerAvailable.md)
Returns a list of all GitHub owners accessible by the user token consumed by the connector.

### [Get-AzSecurityConnectorGitHubRepo](Get-AzSecurityConnectorGitHubRepo.md)
Returns a monitored GitHub repository.

### [Get-AzSecurityConnectorGitLabGroup](Get-AzSecurityConnectorGitLabGroup.md)
Returns a monitored GitLab Group resource for a given fully-qualified name.

### [Get-AzSecurityConnectorGitLabGroupAvailable](Get-AzSecurityConnectorGitLabGroupAvailable.md)
Returns a list of all GitLab groups accessible by the user token consumed by the connector.

### [Get-AzSecurityConnectorGitLabProject](Get-AzSecurityConnectorGitLabProject.md)
Returns a monitored GitLab Project resource for a given fully-qualified group name and project name.

### [Get-AzSecurityConnectorGitLabSubgroup](Get-AzSecurityConnectorGitLabSubgroup.md)
Gets nested subgroups of given GitLab Group which are onboarded to the connector.

### [Invoke-AzSecurityApiCollectionApimOffboard](Invoke-AzSecurityApiCollectionApimOffboard.md)
Offboard an Azure API Management API from Microsoft Defender for APIs.
The system will stop monitoring the operations within the Azure API Management API for intrusive behaviors.

### [Invoke-AzSecurityApiCollectionApimOnboard](Invoke-AzSecurityApiCollectionApimOnboard.md)
Onboard an Azure API Management API to Microsoft Defender for APIs.
The system will start monitoring the operations within the Azure Management API for intrusive behaviors and provide alerts for attacks that have been detected.

### [New-AzSecurityAwsEnvironmentObject](New-AzSecurityAwsEnvironmentObject.md)
Create an in-memory object for AwsEnvironment.

### [New-AzSecurityAwsOrganizationalDataMasterObject](New-AzSecurityAwsOrganizationalDataMasterObject.md)
Create an in-memory object for AwsOrganizationalDataMaster.

### [New-AzSecurityAwsOrganizationalDataMemberObject](New-AzSecurityAwsOrganizationalDataMemberObject.md)
Create an in-memory object for AwsOrganizationalDataMember.

### [New-AzSecurityAzureDevOpsScopeEnvironmentObject](New-AzSecurityAzureDevOpsScopeEnvironmentObject.md)
Create an in-memory object for AzureDevOpsScopeEnvironment.

### [New-AzSecurityConnector](New-AzSecurityConnector.md)
Create a security connector.
If a security connector is already created and a subsequent request is issued for the same security connector id, then it will be updated.

### [New-AzSecurityConnectorActionableRemediationObject](New-AzSecurityConnectorActionableRemediationObject.md)
Create an in-memory object for ActionableRemediation.

### [New-AzSecurityConnectorDevOpsConfiguration](New-AzSecurityConnectorDevOpsConfiguration.md)
Create a DevOps Configuration.

### [New-AzSecurityCspmMonitorAwsOfferingObject](New-AzSecurityCspmMonitorAwsOfferingObject.md)
Create an in-memory object for CspmMonitorAwsOffering.

### [New-AzSecurityCspmMonitorAzureDevOpsOfferingObject](New-AzSecurityCspmMonitorAzureDevOpsOfferingObject.md)
Create an in-memory object for CspmMonitorAzureDevOpsOffering.

### [New-AzSecurityCspmMonitorGcpOfferingObject](New-AzSecurityCspmMonitorGcpOfferingObject.md)
Create an in-memory object for CspmMonitorGcpOffering.

### [New-AzSecurityCspmMonitorGithubOfferingObject](New-AzSecurityCspmMonitorGithubOfferingObject.md)
Create an in-memory object for CspmMonitorGithubOffering.

### [New-AzSecurityCspmMonitorGitLabOfferingObject](New-AzSecurityCspmMonitorGitLabOfferingObject.md)
Create an in-memory object for CspmMonitorGitLabOffering.

### [New-AzSecurityDefenderCspmAwsOfferingObject](New-AzSecurityDefenderCspmAwsOfferingObject.md)
Create an in-memory object for DefenderCspmAwsOffering.

### [New-AzSecurityDefenderCspmGcpOfferingObject](New-AzSecurityDefenderCspmGcpOfferingObject.md)
Create an in-memory object for DefenderCspmGcpOffering.

### [New-AzSecurityDefenderForContainersAwsOfferingObject](New-AzSecurityDefenderForContainersAwsOfferingObject.md)
Create an in-memory object for DefenderForContainersAwsOffering.

### [New-AzSecurityDefenderForContainersGcpOfferingObject](New-AzSecurityDefenderForContainersGcpOfferingObject.md)
Create an in-memory object for DefenderForContainersGcpOffering.

### [New-AzSecurityDefenderForDatabasesAwsOfferingObject](New-AzSecurityDefenderForDatabasesAwsOfferingObject.md)
Create an in-memory object for DefenderForDatabasesAwsOffering.

### [New-AzSecurityDefenderForDatabasesGcpOfferingObject](New-AzSecurityDefenderForDatabasesGcpOfferingObject.md)
Create an in-memory object for DefenderForDatabasesGcpOffering.

### [New-AzSecurityDefenderForServersAwsOfferingObject](New-AzSecurityDefenderForServersAwsOfferingObject.md)
Create an in-memory object for DefenderForServersAwsOffering.

### [New-AzSecurityDefenderForServersGcpOfferingObject](New-AzSecurityDefenderForServersGcpOfferingObject.md)
Create an in-memory object for DefenderForServersGcpOffering.

### [New-AzSecurityGcpOrganizationalDataMemberObject](New-AzSecurityGcpOrganizationalDataMemberObject.md)
Create an in-memory object for GcpOrganizationalDataMember.

### [New-AzSecurityGcpOrganizationalDataOrganizationObject](New-AzSecurityGcpOrganizationalDataOrganizationObject.md)
Create an in-memory object for GcpOrganizationalDataOrganization.

### [New-AzSecurityGcpProjectEnvironmentObject](New-AzSecurityGcpProjectEnvironmentObject.md)
Create an in-memory object for GcpProjectEnvironment.

### [New-AzSecurityGitHubScopeEnvironmentObject](New-AzSecurityGitHubScopeEnvironmentObject.md)
Create an in-memory object for GitHubScopeEnvironment.

### [New-AzSecurityGitLabScopeEnvironmentObject](New-AzSecurityGitLabScopeEnvironmentObject.md)
Create an in-memory object for GitLabScopeEnvironment.

### [New-AzSecurityInformationProtectionAwsOfferingObject](New-AzSecurityInformationProtectionAwsOfferingObject.md)
Create an in-memory object for InformationProtectionAwsOffering.

### [Remove-AzSecurityConnector](Remove-AzSecurityConnector.md)
Deletes a security connector.

### [Remove-AzSecurityConnectorDevOpsConfiguration](Remove-AzSecurityConnectorDevOpsConfiguration.md)
Deletes a DevOps Connector.

### [Update-AzSecurityConnector](Update-AzSecurityConnector.md)
Updates a security connector

### [Update-AzSecurityConnectorAzureDevOpsOrg](Update-AzSecurityConnectorAzureDevOpsOrg.md)
Updates monitored Azure DevOps organization details.

### [Update-AzSecurityConnectorAzureDevOpsProject](Update-AzSecurityConnectorAzureDevOpsProject.md)
Updates a monitored Azure DevOps project resource.

### [Update-AzSecurityConnectorAzureDevOpsRepo](Update-AzSecurityConnectorAzureDevOpsRepo.md)
Updates a monitored Azure DevOps repository resource.

### [Update-AzSecurityConnectorDevOpsConfiguration](Update-AzSecurityConnectorDevOpsConfiguration.md)
Updates a DevOps Configuration.

