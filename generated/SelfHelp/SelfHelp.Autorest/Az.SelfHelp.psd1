@{
  GUID = '2705ffd2-39d8-491f-b0c6-14fca2dc3727'
  RootModule = './Az.SelfHelp.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: SelfHelp cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.SelfHelp.private.dll'
  FormatsToProcess = './Az.SelfHelp.format.ps1xml'
  FunctionsToExport = 'Get-AzSelfHelpDiagnostic', 'Get-AzSelfHelpDiscoverySolution', 'Get-AzSelfHelpSimplifiedSolution', 'Get-AzSelfHelpSolution', 'Get-AzSelfHelpSolutionSelfHelp', 'Get-AzSelfHelpTroubleshooter', 'Invoke-AzSelfHelpCheckNameAvailability', 'Invoke-AzSelfHelpContinueTroubleshooter', 'Invoke-AzSelfHelpDiscoverySolutionNlpSubscriptionScope', 'Invoke-AzSelfHelpDiscoverySolutionNlpTenantScope', 'Invoke-AzSelfHelpWarmSolutionUp', 'New-AzSelfHelpDiagnostic', 'New-AzSelfHelpSimplifiedSolution', 'New-AzSelfHelpSolution', 'New-AzSelfHelpTroubleshooter', 'Restart-AzSelfHelpTroubleshooter', 'Stop-AzSelfHelpTroubleshooter', 'Update-AzSelfHelpSolution', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'SelfHelp'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
