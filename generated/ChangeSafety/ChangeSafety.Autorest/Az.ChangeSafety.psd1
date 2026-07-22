@{
  GUID = '0f6af2a4-6965-4a36-9bcc-e7c490a17dc3'
  RootModule = './Az.ChangeSafety.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ChangeSafety cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ChangeSafety.private.dll'
  FormatsToProcess = './Az.ChangeSafety.format.ps1xml'
  FunctionsToExport = 'Assert-AzChangeSafetyChangeRecordEnumValue', 'Assert-AzChangeSafetyChangeRecordName', 'Assert-AzChangeSafetyChangeRecordWindow', 'ConvertTo-AzChangeSafetyTargetList', 'Get-AzChangeSafetyChangeRecord', 'Get-AzChangeSafetyStageMap', 'Get-AzChangeSafetyStageProgression', 'New-AzChangeSafetyChangeRecord', 'New-AzChangeSafetyStageMap', 'New-AzChangeSafetyStageProgression', 'Remove-AzChangeSafetyChangeRecord', 'Remove-AzChangeSafetyStageMap', 'Remove-AzChangeSafetyStageProgression', 'Update-AzChangeSafetyChangeRecord', 'Update-AzChangeSafetyStageMap', 'Update-AzChangeSafetyStageProgression'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ChangeSafety'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
