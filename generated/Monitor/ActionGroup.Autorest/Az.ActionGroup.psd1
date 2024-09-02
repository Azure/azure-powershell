@{
  GUID = 'c9f47937-c60a-4575-b669-442455ef6728'
  RootModule = './Az.ActionGroup.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ActionGroup cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ActionGroup.private.dll'
  FormatsToProcess = './Az.ActionGroup.format.ps1xml'
  FunctionsToExport = 'Enable-AzActionGroupReceiver', 'Get-AzActionGroup', 'New-AzActionGroup', 'New-AzActionGroupArmRoleReceiverObject', 'New-AzActionGroupAutomationRunbookReceiverObject', 'New-AzActionGroupAzureAppPushReceiverObject', 'New-AzActionGroupAzureFunctionReceiverObject', 'New-AzActionGroupEmailReceiverObject', 'New-AzActionGroupEventHubReceiverObject', 'New-AzActionGroupItsmReceiverObject', 'New-AzActionGroupLogicAppReceiverObject', 'New-AzActionGroupSmsReceiverObject', 'New-AzActionGroupVoiceReceiverObject', 'New-AzActionGroupWebhookReceiverObject', 'Remove-AzActionGroup', 'Test-AzActionGroup', 'Update-AzActionGroup'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ActionGroup'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
