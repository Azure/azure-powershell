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
  FunctionsToExport = 'Get-AzHealthcareApisService', 'Get-AzHealthcareApisWorkspace', 'Get-AzHealthcareDicomService', 'Get-AzHealthcareFhirDestination', 'Get-AzHealthcareFhirService', 'Get-AzHealthcareIotConnector', 'Get-AzHealthcareIotConnectorFhirDestination', 'New-AzHealthcareApisService', 'New-AzHealthcareApisWorkspace', 'New-AzHealthcareDicomService', 'New-AzHealthcareFhirService', 'New-AzHealthcareIotConnector', 'New-AzHealthcareIotConnectorFhirDestination', 'Remove-AzHealthcareApisService', 'Remove-AzHealthcareApisWorkspace', 'Remove-AzHealthcareDicomService', 'Remove-AzHealthcareFhirService', 'Remove-AzHealthcareIotConnector', 'Remove-AzHealthcareIotConnectorFhirDestination', 'Test-AzHealthcareServiceNameAvailability', 'Update-AzHealthcareApisService', 'Update-AzHealthcareApisWorkspace', 'Update-AzHealthcareDicomService', 'Update-AzHealthcareFhirService', 'Update-AzHealthcareIotConnector', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HealthcareApis', 'HealthCare', 'FhirService'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
