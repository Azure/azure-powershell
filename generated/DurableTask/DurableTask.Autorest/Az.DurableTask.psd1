@{
  GUID = '4aa9eb6c-909b-48a2-8277-df481c4e8f05'
  RootModule = './Az.DurableTask.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DurableTask cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DurableTask.private.dll'
  FormatsToProcess = './Az.DurableTask.format.ps1xml'
  FunctionsToExport = 'Get-AzDurableTaskHub', 'Get-AzDurableTaskScheduler', 'New-AzDurableTaskHub', 'New-AzDurableTaskScheduler', 'Remove-AzDurableTaskHub', 'Remove-AzDurableTaskScheduler', 'Update-AzDurableTaskScheduler'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DurableTask'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
