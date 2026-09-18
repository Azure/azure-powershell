@{
  GUID = '5168d495-7a9d-45d6-ab8f-9127f05ee378'
  RootModule = './Az.EmailServicedata.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: EmailServicedata cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.EmailServicedata.private.dll'
  FormatsToProcess = './Az.EmailServicedata.format.ps1xml'
  FunctionsToExport = 'Get-AzEmailServicedataEmailSendResult', 'Send-AzEmailServicedataEmail'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'EmailServicedata'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
