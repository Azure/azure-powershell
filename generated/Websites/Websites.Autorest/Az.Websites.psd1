@{
  GUID = 'e2ccd5b0-af3a-415f-82ed-b9a388aeed61'
  RootModule = './Az.Websites.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Websites cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Websites.private.dll'
  FormatsToProcess = './Az.Websites.format.ps1xml'
  FunctionsToExport = 'Get-AzStaticWebApp', 'Get-AzStaticWebAppBuild', 'Get-AzStaticWebAppBuildAppSetting', 'Get-AzStaticWebAppBuildFunction', 'Get-AzStaticWebAppBuildFunctionAppSetting', 'Get-AzStaticWebAppConfiguredRole', 'Get-AzStaticWebAppCustomDomain', 'Get-AzStaticWebAppFunction', 'Get-AzStaticWebAppFunctionAppSetting', 'Get-AzStaticWebAppSecret', 'Get-AzStaticWebAppSetting', 'Get-AzStaticWebAppUser', 'Get-AzStaticWebAppUserProvidedFunctionApp', 'Get-AzWebAppContinuousWebJob', 'Get-AzWebAppSlotContinuousWebJob', 'Get-AzWebAppSlotTriggeredWebJob', 'Get-AzWebAppSlotTriggeredWebJobHistory', 'Get-AzWebAppSlotWebJob', 'Get-AzWebAppTriggeredWebJob', 'Get-AzWebAppTriggeredWebJobHistory', 'Get-AzWebAppWebJob', 'New-AzStaticWebApp', 'New-AzStaticWebAppBuildAppSetting', 'New-AzStaticWebAppBuildFunctionAppSetting', 'New-AzStaticWebAppCustomDomain', 'New-AzStaticWebAppFunctionAppSetting', 'New-AzStaticWebAppSetting', 'New-AzStaticWebAppUserRoleInvitationLink', 'Register-AzStaticWebAppUserProvidedFunctionApp', 'Remove-AzStaticWebApp', 'Remove-AzStaticWebAppAttachedRepository', 'Remove-AzStaticWebAppBuild', 'Remove-AzStaticWebAppCustomDomain', 'Remove-AzStaticWebAppUser', 'Remove-AzWebAppContinuousWebJob', 'Remove-AzWebAppSlotContinuousWebJob', 'Remove-AzWebAppSlotTriggeredWebJob', 'Remove-AzWebAppTriggeredWebJob', 'Reset-AzStaticWebAppApiKey', 'Start-AzWebAppContinuousWebJob', 'Start-AzWebAppSlotContinuousWebJob', 'Start-AzWebAppSlotTriggeredWebJob', 'Start-AzWebAppTriggeredWebJob', 'Stop-AzWebAppContinuousWebJob', 'Stop-AzWebAppSlotContinuousWebJob', 'Test-AzStaticWebAppCustomDomain', 'Unregister-AzStaticWebAppBuildUserProvidedFunctionApp', 'Unregister-AzStaticWebAppUserProvidedFunctionApp', 'Update-AzStaticWebApp', 'Update-AzStaticWebAppUser', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Websites'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
