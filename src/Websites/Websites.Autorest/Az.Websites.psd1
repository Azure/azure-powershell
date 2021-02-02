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
  FunctionsToExport = 'Get-AzWebsitesStaticSite', 'Get-AzWebsitesStaticSiteBuild', 'Get-AzWebsitesStaticSiteBuildFunction', 'Get-AzWebsitesStaticSiteBuildFunctionAppSetting', 'Get-AzWebsitesStaticSiteCustomDomain', 'Get-AzWebsitesStaticSiteFunction', 'Get-AzWebsitesStaticSiteFunctionAppSetting', 'Get-AzWebsitesStaticSiteSecret', 'Get-AzWebsitesStaticSiteUser', 'Invoke-AzWebsitesDetachStaticSite', 'Invoke-AzWebsitesPreviewStaticSiteWorkflow', 'New-AzWebsitesStaticSite', 'New-AzWebsitesStaticSiteBuildFunctionAppSetting', 'New-AzWebsitesStaticSiteCustomDomain', 'New-AzWebsitesStaticSiteFunctionAppSetting', 'New-AzWebsitesStaticSiteUserRoleInvitationLink', 'Remove-AzWebsitesStaticSite', 'Remove-AzWebsitesStaticSiteBuild', 'Remove-AzWebsitesStaticSiteCustomDomain', 'Remove-AzWebsitesStaticSiteUser', 'Reset-AzWebsitesStaticSiteApiKey', 'Set-AzWebsitesStaticSite', 'Set-AzWebsitesStaticSiteBuildFunctionAppSetting', 'Set-AzWebsitesStaticSiteCustomDomain', 'Set-AzWebsitesStaticSiteFunctionAppSetting', 'Test-AzWebsitesStaticSiteCustomDomainCanBeAddedToStaticSite', 'Update-AzWebsitesStaticSite', 'Update-AzWebsitesStaticSiteUser', '*'
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
