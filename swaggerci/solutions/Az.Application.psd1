@{
  GUID = '4a4521ac-d377-4c14-8a18-fccaf70362c7'
  RootModule = './Az.Application.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Application cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Application.private.dll'
  FormatsToProcess = './Az.Application.format.ps1xml'
  FunctionsToExport = 'Get-AzApplication', 'Get-AzApplicationAllowedUpgradePlan', 'Get-AzApplicationDefinition', 'Get-AzApplicationJitRequest', 'New-AzApplication', 'New-AzApplicationDefinition', 'New-AzApplicationJitRequest', 'Remove-AzApplication', 'Remove-AzApplicationDefinition', 'Remove-AzApplicationJitRequest', 'Update-AzApplication', 'Update-AzApplicationDefinition', 'Update-AzApplicationJitRequest', 'Update-AzApplicationPermission', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Application'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
