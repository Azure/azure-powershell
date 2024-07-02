@{
  GUID = '593f5094-e96e-4646-9c96-5342db09e51a'
  RootModule = './Az.Alb.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Alb cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Alb.private.dll'
  FormatsToProcess = './Az.Alb.format.ps1xml'
  FunctionsToExport = 'Get-AzAlb', 'Get-AzAlbAssociation', 'Get-AzAlbFrontend', 'New-AzAlb', 'New-AzAlbAssociation', 'New-AzAlbFrontend', 'Remove-AzAlb', 'Remove-AzAlbAssociation', 'Remove-AzAlbFrontend', 'Update-AzAlb', 'Update-AzAlbAssociation', 'Update-AzAlbFrontend'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Alb'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
