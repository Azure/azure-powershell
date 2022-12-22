@{
  GUID = 'ae829cb8-2dab-4367-85e4-1d2d32194f5a'
  RootModule = './Az.VoiceServices.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: VoiceServices cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.VoiceServices.private.dll'
  FormatsToProcess = './Az.VoiceServices.format.ps1xml'
  FunctionsToExport = 'Get-AzVoiceServicesCommunicationGateway', 'Get-AzVoiceServicesCommunicationsGateway', 'Get-AzVoiceServicesContact', 'Get-AzVoiceServicesTestLine', 'New-AzVoiceServicesCommunicationGateway', 'New-AzVoiceServicesContact', 'New-AzVoiceServicesTestLine', 'Remove-AzVoiceServicesCommunicationsGateway', 'Remove-AzVoiceServicesContact', 'Remove-AzVoiceServicesTestLine', 'Update-AzVoiceServicesCommunicationsGateway', 'Update-AzVoiceServicesContact', 'Update-AzVoiceServicesTestLine', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'VoiceServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
