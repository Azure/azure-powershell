@{
  GUID = '36cc732b-665f-4db7-bdfa-70d09e08f7b1'
  RootModule = './Az.HealthcareApis.psm1'
  ModuleVersion = '0.3.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: HealthcareApis cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.HealthcareApis.private.dll'
  FormatsToProcess = './Az.HealthcareApis.format.ps1xml'
  FunctionsToExport = 'Get-AzHealthcareAPIsService', 'Get-AzHealthcareAPIsWorkspace', 'Get-AzHealthcareDicomService', 'Get-AzHealthcareFhirDestination', 'Get-AzHealthcareFhirService', 'Get-AzHealthcareIotConnector', 'New-AzHealthcareAPIsService', 'New-AzHealthcareAPIsWorkspace', 'New-AzHealthcareDicomService', 'New-AzHealthcareFhirService', 'New-AzHealthcareIotConnector', 'Remove-AzHealthcareAPIsService', 'Remove-AzHealthcareAPIsWorkspace', 'Remove-AzHealthcareDicomService', 'Remove-AzHealthcareFhirService', 'Remove-AzHealthcareIotConnector', 'Test-AzHealthcareServiceNameAvailability', 'Update-AzHealthcareAPIsService', 'Update-AzHealthcareAPIsWorkspace', 'Update-AzHealthcareDicomService', 'Update-AzHealthcareFhirService', 'Update-AzHealthcareIotConnector', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HealthcareApis'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
