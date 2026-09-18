@{
  GUID = '7b962bb2-6f08-40e6-95b3-ddf0ba701aef'
  RootModule = './Az.Astro.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Astro cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Astro.private.dll'
  FormatsToProcess = './Az.Astro.format.ps1xml'
  FunctionsToExport = 'Get-AzAstroOrganization', 'New-AzAstroOrganization', 'Remove-AzAstroOrganization', 'Update-AzAstroOrganization'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Astro'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
