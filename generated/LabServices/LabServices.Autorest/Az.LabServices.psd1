@{
  GUID = 'f4604f08-6749-40ce-bd25-81074c1119e7'
  RootModule = './Az.LabServices.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: LabServices cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.LabServices.private.dll'
  FormatsToProcess = './Az.LabServices.format.ps1xml'
  FunctionsToExport = 'Add-AzLabServicesUserQuota', 'Get-AzLabServicesLab', 'Get-AzLabServicesLabForVM', 'Get-AzLabServicesLabPlan', 'Get-AzLabServicesPlanImage', 'Get-AzLabServicesSchedule', 'Get-AzLabServicesTemplateVM', 'Get-AzLabServicesUser', 'Get-AzLabServicesUserVM', 'Get-AzLabServicesVM', 'New-AzLabServicesLab', 'New-AzLabServicesLabPlan', 'New-AzLabServicesSchedule', 'New-AzLabServicesUser', 'Publish-AzLabServicesLab', 'Remove-AzLabServicesLab', 'Remove-AzLabServicesLabPlan', 'Remove-AzLabServicesSchedule', 'Remove-AzLabServicesUser', 'Reset-AzLabServicesVMPassword', 'Save-AzLabServicesLabPlanImage', 'Send-AzLabServicesUserInvite', 'Start-AzLabServicesUserVM', 'Start-AzLabServicesVM', 'Start-AzLabServicesVMRedeployment', 'Stop-AzLabServicesUserVM', 'Stop-AzLabServicesVM', 'Sync-AzLabServicesLabUser', 'Update-AzLabServicesLab', 'Update-AzLabServicesLabPlan', 'Update-AzLabServicesPlanImage', 'Update-AzLabServicesQuota', 'Update-AzLabServicesSchedule', 'Update-AzLabServicesUser', 'Update-AzLabServicesVMReimage', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'LabServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
