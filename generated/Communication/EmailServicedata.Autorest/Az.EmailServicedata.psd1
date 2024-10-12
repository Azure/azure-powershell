@{
  GUID = 'f8860724-7666-4e38-bc35-59133fd6def2'
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
