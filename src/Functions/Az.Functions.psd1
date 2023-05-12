@{
  GUID = 'eafced71-8742-4a2c-5afd-13117428dd90'
  RootModule = './Az.Functions.psm1'
  ModuleVersion = '1.0.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell - Azure Functions service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.

For information on Azure Functions, please visit the following: https://learn.microsoft.com/azure/azure-functions/'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Functions.private.dll'
  FormatsToProcess = './Az.Functions.format.ps1xml', './custom/Functions.format.ps1xml'
  TypesToProcess = @('./custom/Functions.types.ps1xml')
  ScriptsToProcess = @('./custom/HelperFunctions.ps1')
  FunctionsToExport = @('Get-AzFunctionApp', 'Get-AzFunctionAppAvailableLocation', 'Get-AzFunctionAppPlan', 'Get-AzFunctionAppSetting', 'New-AzFunctionApp', 'New-AzFunctionAppPlan', 'Remove-AzFunctionApp', 'Remove-AzFunctionAppPlan', 'Remove-AzFunctionAppSetting', 'Restart-AzFunctionApp', 'Start-AzFunctionApp', 'Stop-AzFunctionApp', 'Update-AzFunctionApp', 'Update-AzFunctionAppPlan', 'Update-AzFunctionAppSetting')
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Functions'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
