@{
  GUID = 'bdedc683-d9b6-41ea-b310-d068b8c72305'
  RootModule = './Az.ImageBuilder.psm1'
  ModuleVersion = '0.1.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ImageBuilder cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ImageBuilder.private.dll'
  RequiredModules = @(@{ModuleName = 'Az.Accounts'; ModuleVersion = '1.9.0'; })
  FormatsToProcess = './Az.ImageBuilder.format.ps1xml'
  FunctionsToExport = 'Get-AzImageBuilderRunOutput', 'Get-AzImageBuilderTemplate', 'New-AzImageBuilderCustomizerObject', 'New-AzImageBuilderDistributorObject', 'New-AzImageBuilderSourceObject', 'New-AzImageBuilderTemplate', 'Remove-AzImageBuilderTemplate', 'Start-AzImageBuilderTemplate', 'Stop-AzImageBuilderTemplate'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ImageBuilder'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
