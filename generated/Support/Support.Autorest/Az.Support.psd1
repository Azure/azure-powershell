@{
  GUID = 'ca38d4b0-fe38-4f55-b9e1-66df3d985f20'
  RootModule = './Az.Support.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Support cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Support.private.dll'
  FormatsToProcess = './Az.Support.format.ps1xml'
  FunctionsToExport = 'Get-AzSupportChatTranscript', 'Get-AzSupportChatTranscriptsNoSubscription', 'Get-AzSupportCommunication', 'Get-AzSupportCommunicationsNoSubscription', 'Get-AzSupportFile', 'Get-AzSupportFilesNoSubscription', 'Get-AzSupportFileWorkspace', 'Get-AzSupportFileWorkspacesNoSubscription', 'Get-AzSupportOperation', 'Get-AzSupportProblemClassification', 'Get-AzSupportService', 'Get-AzSupportTicket', 'Get-AzSupportTicketsNoSubscription', 'New-AzSupportCommunication', 'New-AzSupportCommunicationsNoSubscription', 'New-AzSupportFileAndUpload', 'New-AzSupportFileAndUploadNoSubscription', 'New-AzSupportFileWorkspace', 'New-AzSupportFileWorkspacesNoSubscription', 'New-AzSupportTicket', 'New-AzSupportTicketsNoSubscription', 'Test-AzSupportCommunicationNameAvailability', 'Test-AzSupportCommunicationsNoSubscriptionNameAvailability', 'Test-AzSupportTicketNameAvailability', 'Test-AzSupportTicketsNoSubscriptionNameAvailability', 'Update-AzSupportTicket', 'Update-AzSupportTicketsNoSubscription'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Support'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
