@{
  GUID = '6f1c0dfd-dfcd-4e5b-b77c-a64a9d355ebf'
  RootModule = './Az.Security.psm1'
  ModuleVersion = '1.5.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Security cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Security.private.dll'
  FormatsToProcess = './Az.Security.format.ps1xml'
  FunctionsToExport = 'Get-AzSecurityApiCollection', 'Get-AzSecurityConnector', 'Get-AzSecurityConnectorAzureDevOpsOrg', 'Get-AzSecurityConnectorAzureDevOpsOrgAvailable', 'Get-AzSecurityConnectorAzureDevOpsProject', 'Get-AzSecurityConnectorAzureDevOpsRepo', 'Get-AzSecurityConnectorDevOpsConfiguration', 'Get-AzSecurityConnectorGitHubOwner', 'Get-AzSecurityConnectorGitHubOwnerAvailable', 'Get-AzSecurityConnectorGitHubRepo', 'Get-AzSecurityConnectorGitLabGroup', 'Get-AzSecurityConnectorGitLabGroupAvailable', 'Get-AzSecurityConnectorGitLabProject', 'Get-AzSecurityConnectorGitLabSubgroup', 'Invoke-AzSecurityApiCollectionApimOffboard', 'Invoke-AzSecurityApiCollectionApimOnboard', 'New-AzSecurityAwsEnvironmentObject', 'New-AzSecurityAwsOrganizationalDataMasterObject', 'New-AzSecurityAwsOrganizationalDataMemberObject', 'New-AzSecurityAzureDevOpsScopeEnvironmentObject', 'New-AzSecurityConnector', 'New-AzSecurityConnectorActionableRemediationObject', 'New-AzSecurityConnectorDevOpsConfiguration', 'New-AzSecurityCspmMonitorAwsOfferingObject', 'New-AzSecurityCspmMonitorAzureDevOpsOfferingObject', 'New-AzSecurityCspmMonitorGcpOfferingObject', 'New-AzSecurityCspmMonitorGithubOfferingObject', 'New-AzSecurityCspmMonitorGitLabOfferingObject', 'New-AzSecurityDefenderCspmAwsOfferingObject', 'New-AzSecurityDefenderCspmGcpOfferingObject', 'New-AzSecurityDefenderForContainersAwsOfferingObject', 'New-AzSecurityDefenderForContainersGcpOfferingObject', 'New-AzSecurityDefenderForDatabasesAwsOfferingObject', 'New-AzSecurityDefenderForDatabasesGcpOfferingObject', 'New-AzSecurityDefenderForServersAwsOfferingObject', 'New-AzSecurityDefenderForServersGcpOfferingObject', 'New-AzSecurityGcpOrganizationalDataMemberObject', 'New-AzSecurityGcpOrganizationalDataOrganizationObject', 'New-AzSecurityGcpProjectEnvironmentObject', 'New-AzSecurityGitHubScopeEnvironmentObject', 'New-AzSecurityGitLabScopeEnvironmentObject', 'New-AzSecurityInformationProtectionAwsOfferingObject', 'Remove-AzSecurityConnector', 'Remove-AzSecurityConnectorDevOpsConfiguration', 'Update-AzSecurityConnector', 'Update-AzSecurityConnectorAzureDevOpsOrg', 'Update-AzSecurityConnectorAzureDevOpsProject', 'Update-AzSecurityConnectorAzureDevOpsRepo', 'Update-AzSecurityConnectorDevOpsConfiguration'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Security'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
