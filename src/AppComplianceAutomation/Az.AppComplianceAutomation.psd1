@{
  GUID = '372733fc-fa2d-4a44-98fb-644186237429'
  RootModule = './Az.AppComplianceAutomation.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: AppComplianceAutomation cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.AppComplianceAutomation.private.dll'
  FormatsToProcess = './Az.AppComplianceAutomation.format.ps1xml'
  FunctionsToExport = 'Get-AzAcatControlAssessments', 'Get-AzAcatReport', 'Get-AzAcatWebhook', 'Invoke-AzAcatDownloadReport', 'New-AzAcatReport', 'New-AzAcatReportResourceObject', 'New-AzAcatWebhook', 'New-AzAcatWebhookResourceObject', 'Remove-AzAcatReport', 'Remove-AzAcatWebhook', 'Start-AzAcatQuickEvaluation', 'Update-AzAcatReport', 'Update-AzAcatWebhook', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'AppComplianceAutomation'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
