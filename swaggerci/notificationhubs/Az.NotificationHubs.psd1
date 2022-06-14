@{
  GUID = '02284831-82b0-4953-b8e7-f117581e9ceb'
  RootModule = './Az.NotificationHubs.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: NotificationHubs cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.NotificationHubs.private.dll'
  FormatsToProcess = './Az.NotificationHubs.format.ps1xml'
  FunctionsToExport = 'Debug-AzNotificationHubsNotificationHubSend', 'Get-AzNotificationHubsNamespace', 'Get-AzNotificationHubsNamespaceAuthorizationRule', 'Get-AzNotificationHubsNamespaceKey', 'Get-AzNotificationHubsNotificationHub', 'Get-AzNotificationHubsNotificationHubAuthorizationRule', 'Get-AzNotificationHubsNotificationHubKey', 'Get-AzNotificationHubsNotificationHubPnCredentials', 'New-AzNotificationHubsNamespace', 'New-AzNotificationHubsNamespaceAuthorizationRule', 'New-AzNotificationHubsNamespaceKey', 'New-AzNotificationHubsNotificationHub', 'New-AzNotificationHubsNotificationHubAuthorizationRule', 'New-AzNotificationHubsNotificationHubKey', 'Remove-AzNotificationHubsNamespace', 'Remove-AzNotificationHubsNamespaceAuthorizationRule', 'Remove-AzNotificationHubsNotificationHub', 'Remove-AzNotificationHubsNotificationHubAuthorizationRule', 'Test-AzNotificationHubsNamespaceAvailability', 'Test-AzNotificationHubsNotificationHubAvailability', 'Update-AzNotificationHubsNamespace', 'Update-AzNotificationHubsNotificationHub', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'NotificationHubs'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
