@{
  GUID = 'bdedc683-d9b6-41ea-b310-d068b8c72305'
  RootModule = './Az.ImageBuilder.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ImageBuilder cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ImageBuilder.private.dll'
  FormatsToProcess = './Az.ImageBuilder.format.ps1xml'
  FunctionsToExport = 'Get-AzImageBuilderTemplate', 'Get-AzImageBuilderTemplateRunOutput', 'Get-AzImageBuilderTrigger', 'New-AzImageBuilderTemplate', 'New-AzImageBuilderTemplateCustomizerObject', 'New-AzImageBuilderTemplateDistributeVersionerLatestObject', 'New-AzImageBuilderTemplateDistributeVersionerSourceObject', 'New-AzImageBuilderTemplateDistributorObject', 'New-AzImageBuilderTemplateSourceObject', 'New-AzImageBuilderTemplateValidatorObject', 'New-AzImageBuilderTrigger', 'Remove-AzImageBuilderTemplate', 'Remove-AzImageBuilderTrigger', 'Start-AzImageBuilderTemplate', 'Stop-AzImageBuilderTemplate', 'Update-AzImageBuilderTemplate', '*'
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
