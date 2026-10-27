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
  FunctionsToExport = 'Get-AzChaosDiscoveredResource', 'Get-AzChaosScenario', 'Get-AzChaosScenarioConfiguration', 'Get-AzChaosScenarioConfigurationResourcePermission', 'Get-AzChaosScenarioConfigurationValidation', 'Get-AzChaosScenarioRun', 'Get-AzChaosWorkspace', 'Get-AzChaosWorkspaceEvaluation', 'Initialize-AzChaosWorkspace', 'Invoke-AzChaosScenarioConfigurationExecution', 'Invoke-AzChaosWorkspaceScenarioEvaluation', 'New-AzChaosActionDependencyObject', 'New-AzChaosKeyValuePairObject', 'New-AzChaosScenario', 'New-AzChaosScenarioActionObject', 'New-AzChaosScenarioConfiguration', 'New-AzChaosScenarioParameterObject', 'New-AzChaosWorkspace', 'Remove-AzChaosScenario', 'Remove-AzChaosScenarioConfiguration', 'Remove-AzChaosWorkspace', 'Repair-AzChaosScenarioConfigurationResourcePermission', 'Start-AzChaosScenarioRun', 'Stop-AzChaosScenarioRun', 'Test-AzChaosScenarioConfiguration', 'Update-AzChaosWorkspace', 'Update-AzChaosWorkspaceRecommendation'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Chaos'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
