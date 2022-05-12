@{
  GUID = 'fa832cf2-b4ef-456e-8a1d-b9cd577f03c3'
  RootModule = './Az.SourceControlConfiguration.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: SourceControlConfiguration cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.SourceControlConfiguration.private.dll'
  FormatsToProcess = './Az.SourceControlConfiguration.format.ps1xml'
  FunctionsToExport = 'Get-AzSourceControlConfigurationExtension', 'Get-AzSourceControlConfigurationFluxConfigOperationStatus', 'Get-AzSourceControlConfigurationFluxConfiguration', 'Get-AzSourceControlConfigurationOperationStatus', 'Get-AzSourceControlConfigurationSourceControlConfiguration', 'New-AzSourceControlConfigurationExtension', 'New-AzSourceControlConfigurationFluxConfiguration', 'New-AzSourceControlConfigurationSourceControlConfiguration', 'Remove-AzSourceControlConfigurationExtension', 'Remove-AzSourceControlConfigurationFluxConfiguration', 'Remove-AzSourceControlConfigurationSourceControlConfiguration', 'Update-AzSourceControlConfigurationExtension', 'Update-AzSourceControlConfigurationFluxConfiguration', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'SourceControlConfiguration'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
