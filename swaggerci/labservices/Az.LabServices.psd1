@{
  GUID = '0d0952f2-9bc4-46b9-bc17-ab665c85916f'
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
  FunctionsToExport = 'Get-AzLabServicesImage', 'Get-AzLabServicesLab', 'Get-AzLabServicesLabPlan', 'Get-AzLabServicesOperationResult', 'Get-AzLabServicesSchedule', 'Get-AzLabServicesSku', 'Get-AzLabServicesUsage', 'Get-AzLabServicesUser', 'Get-AzLabServicesVirtualMachine', 'Invoke-AzLabServicesInviteUser', 'Invoke-AzLabServicesRedeployVirtualMachine', 'New-AzLabServicesImage', 'New-AzLabServicesLab', 'New-AzLabServicesLabPlan', 'New-AzLabServicesSchedule', 'New-AzLabServicesUser', 'Publish-AzLabServicesLab', 'Remove-AzLabServicesLab', 'Remove-AzLabServicesLabPlan', 'Remove-AzLabServicesSchedule', 'Remove-AzLabServicesUser', 'Reset-AzLabServicesVirtualMachinePassword', 'Save-AzLabServicesLabPlanImage', 'Start-AzLabServicesVirtualMachine', 'Stop-AzLabServicesVirtualMachine', 'Sync-AzLabServicesLabGroup', 'Update-AzLabServicesImage', 'Update-AzLabServicesLab', 'Update-AzLabServicesLabPlan', 'Update-AzLabServicesSchedule', 'Update-AzLabServicesUser', 'Update-AzLabServicesVirtualMachine', '*'
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
