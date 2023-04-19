@{
  GUID = '20a4a5d9-068c-43d8-b45a-7130dd33afe4'
  RootModule = './Az.ServiceLinker.psm1'
  ModuleVersion = '0.1.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ServiceLinker cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ServiceLinker.private.dll'
  FormatsToProcess = './Az.ServiceLinker.format.ps1xml'
  FunctionsToExport = 'Get-AzServiceLinkerConfigurationForContainerApp', 'Get-AzServiceLinkerConfigurationForSpringCloud', 'Get-AzServiceLinkerConfigurationForWebApp', 'Get-AzServiceLinkerConfigurationName', 'Get-AzServiceLinkerForContainerApp', 'Get-AzServiceLinkerForSpringCloud', 'Get-AzServiceLinkerForWebApp', 'New-AzServiceLinkerAzureResourceObject', 'New-AzServiceLinkerConfluentBootstrapServerObject', 'New-AzServiceLinkerConfluentSchemaRegistryObject', 'New-AzServiceLinkerForContainerApp', 'New-AzServiceLinkerForSpringCloud', 'New-AzServiceLinkerForWebApp', 'New-AzServiceLinkerSecretAuthInfoObject', 'New-AzServiceLinkerServicePrincipalSecretAuthInfoObject', 'New-AzServiceLinkerSystemAssignedIdentityAuthInfoObject', 'New-AzServiceLinkerUserAssignedIdentityAuthInfoObject', 'Remove-AzServiceLinkerForContainerApp', 'Remove-AzServiceLinkerForSpringCloud', 'Remove-AzServiceLinkerForWebApp', 'Test-AzServiceLinkerForContainerApp', 'Test-AzServiceLinkerForSpringCloud', 'Test-AzServiceLinkerForWebApp', 'Update-AzServiceLinkerForContainerApp', 'Update-AzServiceLinkerForSpringCloud', 'Update-AzServiceLinkerForWebApp', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ServiceLinker'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
