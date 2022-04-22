@{
  GUID = 'b15dbe86-023b-4d05-8282-44996cdd513f'
  RootModule = './Az.Addons.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Addons cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Addons.private.dll'
  FormatsToProcess = './Az.Addons.format.ps1xml'
  FunctionsToExport = 'Get-AzAddonsSupportPlanType', 'Get-AzAddonsSupportPlanTypeInfo', 'Remove-AzAddonsSupportPlanType', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Addons'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
