@{
  GUID = 'eafced71-8742-4a2c-5afd-13117428dd90'
  RootModule = './Az.Functions.psm1'
  ModuleVersion = '0.0.2'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Functions cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Functions.private.dll'
  FormatsToProcess = './Az.Functions.format.ps1xml', './custom/Functions.format.ps1xml'
  TypesToProcess = './custom/Functions.types.ps1xml' 
  ScriptsToProcess = './custom/HelperFunctions.ps1'
  CmdletsToExport = 'Get-AzFunctionApp', 'Get-AzFunctionAppAvailableLocation', 'Get-AzFunctionAppPlan', 'New-AzFunctionApp', 'New-AzFunctionAppPlan', 'Remove-AzFunctionApp', 'Remove-AzFunctionAppPlan', 'Restart-AzFunctionApp', 'Start-AzFunctionApp', 'Stop-AzFunctionApp'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Functions'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30', 'hybrid-2019-03-01'
    }
  }
}
