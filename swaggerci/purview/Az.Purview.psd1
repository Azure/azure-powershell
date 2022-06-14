@{
  GUID = 'c117921c-bd0d-43ed-9432-0f5105080f95'
  RootModule = './Az.Purview.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Purview cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Purview.private.dll'
  FormatsToProcess = './Az.Purview.format.ps1xml'
  FunctionsToExport = 'Add-AzPurviewAccountRootCollectionAdmin', 'Get-AzPurviewAccount', 'Get-AzPurviewAccountKey', 'Get-AzPurviewDefaultAccount', 'Get-AzPurviewPrivateEndpointConnection', 'Get-AzPurviewPrivateLinkResource', 'New-AzPurviewAccount', 'New-AzPurviewPrivateEndpointConnection', 'Remove-AzPurviewAccount', 'Remove-AzPurviewDefaultAccount', 'Remove-AzPurviewPrivateEndpointConnection', 'Test-AzPurviewAccountNameAvailability', 'Update-AzPurviewAccount', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Purview'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
