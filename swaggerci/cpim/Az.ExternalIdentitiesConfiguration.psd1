@{
  GUID = '3a378baa-f048-4542-a5db-5a9631ffb528'
  RootModule = './Az.ExternalIdentitiesConfiguration.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ExternalIdentitiesConfiguration cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ExternalIdentitiesConfiguration.private.dll'
  FormatsToProcess = './Az.ExternalIdentitiesConfiguration.format.ps1xml'
  FunctionsToExport = 'Get-AzExternalIdentitiesConfigurationB2CTenant', 'Get-AzExternalIdentitiesConfigurationGuestUsage', 'New-AzExternalIdentitiesConfigurationB2CTenant', 'New-AzExternalIdentitiesConfigurationGuestUsage', 'Remove-AzExternalIdentitiesConfigurationB2CTenant', 'Remove-AzExternalIdentitiesConfigurationGuestUsage', 'Test-AzExternalIdentitiesConfigurationB2CTenantNameAvailability', 'Update-AzExternalIdentitiesConfigurationB2CTenant', 'Update-AzExternalIdentitiesConfigurationGuestUsage', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ExternalIdentitiesConfiguration'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
