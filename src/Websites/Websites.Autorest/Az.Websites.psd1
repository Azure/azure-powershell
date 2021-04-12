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
  FunctionsToExport = 'Get-AzStaticWebApp', 'Get-AzStaticWebAppAppSetting', 'Get-AzStaticWebAppBuild', 'Get-AzStaticWebAppBuildAppSetting', 'Get-AzStaticWebAppBuildFunction', 'Get-AzStaticWebAppBuildFunctionAppSetting', 'Get-AzStaticWebAppConfiguredRole', 'Get-AzStaticWebAppCustomDomain', 'Get-AzStaticWebAppFunction', 'Get-AzStaticWebAppFunctionAppSetting', 'Get-AzStaticWebAppSecret', 'Get-AzStaticWebAppUser', 'Get-AzStaticWebAppUserProvidedFunctionApp', 'Invoke-AzStaticWebAppDetachUserProvidedFunctionAppFromStaticSite', 'Invoke-AzStaticWebAppDetachUserProvidedFunctionAppFromStaticSiteBuild', 'New-AzStaticWebApp', 'New-AzStaticWebAppAppSetting', 'New-AzStaticWebAppBuildAppSetting', 'New-AzStaticWebAppBuildFunctionAppSetting', 'New-AzStaticWebAppCustomDomain', 'New-AzStaticWebAppFunctionAppSetting', 'New-AzStaticWebAppPreviewWorkflow', 'New-AzStaticWebAppUserRoleInvitationLink', 'New-AzStaticWebAppZipDeployment', 'Register-AzStaticWebAppUserProvidedFunctionApp', 'Remove-AzStaticWebApp', 'Remove-AzStaticWebAppAttachedRepository', 'Remove-AzStaticWebAppBuild', 'Remove-AzStaticWebAppCustomDomain', 'Remove-AzStaticWebAppUser', 'Reset-AzStaticWebAppApiKey', 'Test-AzStaticWebAppCustomDomain', 'Update-AzStaticWebApp', 'Update-AzStaticWebAppUser', '*'
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
