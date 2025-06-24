@{
  GUID = '5f968fee-d653-4e64-ba98-f9ac4a1a4b9e'
  RootModule = './Az.LambdaTest.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: LambdaTest cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.LambdaTest.private.dll'
  FormatsToProcess = './Az.LambdaTest.format.ps1xml'
  FunctionsToExport = 'Get-AzLambdaTestOrganization', 'New-AzLambdaTestOrganization', 'Remove-AzLambdaTestOrganization', 'Update-AzLambdaTestOrganization'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'LambdaTest'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
