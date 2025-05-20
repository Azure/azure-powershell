@{
  GUID = '8866a9da-eb79-4abc-bf61-57477029244e'
  RootModule = './Az.ArizeAI.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ArizeAi cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ArizeAI.private.dll'
  FormatsToProcess = './Az.ArizeAI.format.ps1xml'
  FunctionsToExport = 'Get-AzArizeAIOrganization', 'New-AzArizeAIOrganization', 'Remove-AzArizeAIOrganization', 'Update-AzArizeAIOrganization'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ArizeAi'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
