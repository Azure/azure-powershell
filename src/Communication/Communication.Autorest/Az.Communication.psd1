@{
  GUID = '32c4dede-9b85-43d4-83ab-447e2938c400'
  RootModule = './Az.Communication.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Communication cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Communication.private.dll'
  FormatsToProcess = './Az.Communication.format.ps1xml'
  FunctionsToExport = 'Get-AzCommunicationService', 'Get-AzCommunicationServiceKey', 'New-AzCommunicationService', 'New-AzCommunicationServiceKey', 'Remove-AzCommunicationService', 'Set-AzCommunicationServiceNotificationHub', 'Test-AzCommunicationServiceNameAvailability', 'Update-AzCommunicationService', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Communication'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
