@{
  GUID = '0fbff4fb-215b-4aca-b867-d1acfecab531'
  RootModule = './Az.BotService.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: BotService cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.BotService.private.dll'
  FormatsToProcess = './Az.BotService.format.ps1xml'
  FunctionsToExport = 'Export-AzBotServiceApp', 'Get-AzBotService', 'Get-AzBotServiceHostSetting', 'Initialize-AzBotServicePrepareDeploy', 'New-AzBotService', 'New-AzBotServiceDirectLineKey', 'Publish-AzBotServiceApp', 'Remove-AzBotService', 'Update-AzBotService', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'BotService'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
