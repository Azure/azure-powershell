@{
  GUID = 'b548be86-943f-4051-88b3-f736d290abae'
  RootModule = './Az.Confluent.psm1'
  ModuleVersion = '0.3.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Confluent cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Confluent.private.dll'
  FormatsToProcess = './Az.Confluent.format.ps1xml'
  FunctionsToExport = 'Get-AzConfluentAccessCluster', 'Get-AzConfluentAccessEnvironment', 'Get-AzConfluentAccessInvitation', 'Get-AzConfluentAccessRoleBinding', 'Get-AzConfluentAccessRoleBindingNameList', 'Get-AzConfluentAccessServiceAccount', 'Get-AzConfluentAccessUser', 'Get-AzConfluentConnector', 'Get-AzConfluentMarketplaceAgreement', 'Get-AzConfluentOrganization', 'Get-AzConfluentOrganizationCluster', 'Get-AzConfluentOrganizationClusterApiKey', 'Get-AzConfluentOrganizationEnvironment', 'Get-AzConfluentOrganizationRegion', 'Get-AzConfluentOrganizationSchemaRegistryCluster', 'Get-AzConfluentTopic', 'Invoke-AzConfluentInviteAccessUser', 'New-AzConfluentAccessRoleBinding', 'New-AzConfluentCluster', 'New-AzConfluentConnector', 'New-AzConfluentEnvironment', 'New-AzConfluentOrganization', 'New-AzConfluentOrganizationApiKey', 'New-AzConfluentTopic', 'Remove-AzConfluentAccessRoleBinding', 'Remove-AzConfluentCluster', 'Remove-AzConfluentConnector', 'Remove-AzConfluentEnvironment', 'Remove-AzConfluentOrganization', 'Remove-AzConfluentOrganizationClusterApiKey', 'Remove-AzConfluentTopic', 'Set-AzConfluentCluster', 'Set-AzConfluentConnector', 'Set-AzConfluentEnvironment', 'Test-AzConfluentValidationOrganization', 'Test-AzConfluentValidationOrganizationV2', 'Update-AzConfluentOrganization', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Confluent'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
