@{
  GUID = '08db80a8-b1d6-49de-a18c-354d4e3a27f3'
  RootModule = './Az.Chaos.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Chaos cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Chaos.private.dll'
  FormatsToProcess = './Az.Chaos.format.ps1xml'
  FunctionsToExport = 'Get-AzChaosCapability', 'Get-AzChaosCapabilityType', 'Get-AzChaosExperiment', 'Get-AzChaosExperimentExecutionDetail', 'Get-AzChaosExperimentStatus', 'Get-AzChaosExperimentStatuses', 'Get-AzChaosTarget', 'Get-AzChaosTargetType', 'New-AzChaosCapability', 'New-AzChaosExperiment', 'New-AzChaosTarget', 'Remove-AzChaosCapability', 'Remove-AzChaosExperiment', 'Remove-AzChaosTarget', 'Start-AzChaosExperiment', 'Stop-AzChaosExperiment', 'Update-AzChaosExperiment', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Chaos'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
