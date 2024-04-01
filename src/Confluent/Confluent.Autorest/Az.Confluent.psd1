@{
  GUID = '957f617c-6cbe-4ea3-b46c-ab3ae8eddb3c'
  RootModule = './Az.Confluent.psm1'
  ModuleVersion = '0.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Confluent cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Confluent.private.dll'
  FormatsToProcess = './Az.Confluent.format.ps1xml'
  FunctionsToExport = 'Get-AzConfluentAccessCluster', 'Get-AzConfluentAccessEnvironment', 'Get-AzConfluentAccessInvitation', 'Get-AzConfluentAccessRoleBinding', 'Get-AzConfluentAccessRoleBindingNameList', 'Get-AzConfluentAccessServiceAccount', 'Get-AzConfluentAccessUser', 'Get-AzConfluentMarketplaceAgreement', 'Get-AzConfluentOrganization', 'Get-AzConfluentOrganizationCluster', 'Get-AzConfluentOrganizationClusterApiKey', 'Get-AzConfluentOrganizationEnvironment', 'Get-AzConfluentOrganizationRegion', 'Get-AzConfluentOrganizationSchemaRegistryCluster', 'Invoke-AzConfluentInviteAccessUser', 'New-AzConfluentAccessRoleBinding', 'New-AzConfluentOrganization', 'New-AzConfluentOrganizationApiKey', 'Remove-AzConfluentAccessRoleBinding', 'Remove-AzConfluentOrganization', 'Remove-AzConfluentOrganizationClusterApiKey', 'Test-AzConfluentValidationOrganization', 'Test-AzConfluentValidationOrganizationV2', 'Update-AzConfluentOrganization', '*'
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
