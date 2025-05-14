@{
  GUID = 'ca01a43f-b9c7-4e71-a41d-a185e2355c98'
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
  FunctionsToExport = 'Get-AzChaosCapability', 'Get-AzChaosCapabilityType', 'Get-AzChaosExecutionExperimentDetail', 'Get-AzChaosExperiment', 'Get-AzChaosExperimentExecution', 'Get-AzChaosTarget', 'Get-AzChaosTargetType', 'New-AzChaosActionObject', 'New-AzChaosBranchObject', 'New-AzChaosCapability', 'New-AzChaosExperiment', 'New-AzChaosSelectorObject', 'New-AzChaosStepObject', 'New-AzChaosTarget', 'Remove-AzChaosCapability', 'Remove-AzChaosExperiment', 'Remove-AzChaosTarget', 'Start-AzChaosExperiment', 'Stop-AzChaosExperiment', 'Update-AzChaosCapability', 'Update-AzChaosExperiment', 'Update-AzChaosTarget'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Chaos'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
