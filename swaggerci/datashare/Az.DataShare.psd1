@{
  GUID = '48458c50-ba3a-447d-afeb-c71b34b3b7e2'
  RootModule = './Az.DataShare.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataShare cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataShare.private.dll'
  FormatsToProcess = './Az.DataShare.format.ps1xml'
  FunctionsToExport = 'Get-AzDataShare', 'Get-AzDataShareAccount', 'Get-AzDataShareConsumerInvitation', 'Get-AzDataShareConsumerSourceDataSet', 'Get-AzDataShareDataSet', 'Get-AzDataShareDataSetMapping', 'Get-AzDataShareInvitation', 'Get-AzDataShareProviderShareSubscription', 'Get-AzDataShareSubscription', 'Get-AzDataShareSubscriptionSourceShareSynchronizationSetting', 'Get-AzDataShareSubscriptionSynchronization', 'Get-AzDataShareSubscriptionSynchronizationDetail', 'Get-AzDataShareSynchronization', 'Get-AzDataShareSynchronizationDetail', 'Get-AzDataShareSynchronizationSetting', 'Get-AzDataShareTrigger', 'Initialize-AzDataShareEmailRegistrationEmail', 'Invoke-AzDataShareAdjustProviderShareSubscription', 'Invoke-AzDataShareReinstateProviderShareSubscription', 'Invoke-AzDataShareRejectConsumerInvitation', 'New-AzDataShare', 'New-AzDataShareAccount', 'New-AzDataShareDataSet', 'New-AzDataShareDataSetMapping', 'New-AzDataShareInvitation', 'New-AzDataShareSubscription', 'New-AzDataShareSynchronizationSetting', 'New-AzDataShareTrigger', 'Register-AzDataShareEmailRegistrationEmail', 'Remove-AzDataShare', 'Remove-AzDataShareAccount', 'Remove-AzDataShareDataSet', 'Remove-AzDataShareDataSetMapping', 'Remove-AzDataShareInvitation', 'Remove-AzDataShareSubscription', 'Remove-AzDataShareSynchronizationSetting', 'Remove-AzDataShareTrigger', 'Revoke-AzDataShareProviderShareSubscription', 'Stop-AzDataShareSubscriptionSynchronization', 'Sync-AzDataShareSubscription', 'Update-AzDataShareAccount', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataShare'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
