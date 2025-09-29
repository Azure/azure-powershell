@{
  GUID = '6a1fea15-f9cd-47f0-8752-4f911d32af81'
  RootModule = './Az.DataTransfer.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataTransfer cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataTransfer.private.dll'
  FormatsToProcess = './Az.DataTransfer.format.ps1xml'
  FunctionsToExport = 'Approve-AzDataTransferConnection', 'Deny-AzDataTransferConnection', 'Disable-AzDataTransferConnection', 'Disable-AzDataTransferFlow', 'Disable-AzDataTransferFlowType', 'Disable-AzDataTransferPipeline', 'Enable-AzDataTransferConnection', 'Enable-AzDataTransferFlow', 'Enable-AzDataTransferFlowType', 'Enable-AzDataTransferPipeline', 'Get-AzDataTransferConnection', 'Get-AzDataTransferFlow', 'Get-AzDataTransferFlowProfile', 'Get-AzDataTransferPendingConnection', 'Get-AzDataTransferPendingFlow', 'Get-AzDataTransferPipeline', 'Invoke-AzDataTransferLinkPendingConnection', 'Invoke-AzDataTransferLinkPendingFlow', 'New-AzDataTransferConnection', 'New-AzDataTransferFlow', 'New-AzDataTransferFlowProfile', 'Remove-AzDataTransferConnection', 'Remove-AzDataTransferFlow', 'Update-AzDataTransferConnection', 'Update-AzDataTransferFlow', 'Update-AzDataTransferFlowProfile'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataTransfer'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
