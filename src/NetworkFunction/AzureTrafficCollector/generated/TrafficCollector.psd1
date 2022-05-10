@{
  GUID = '1d339b1c-5a86-4fbd-9a2e-d0497c39b397'
  RootModule = './TrafficCollector.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = ''
  CompanyName = ''
  Copyright = ''
  Description = ''
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/TrafficCollector.private.dll'
  FormatsToProcess = './TrafficCollector.format.ps1xml'
  FunctionsToExport = 'Get-AzureTrafficCollector', 'Get-CollectorPolicy', 'Get-NetworkFunctionOperation', 'New-AzureTrafficCollector', 'New-CollectorPolicy', 'Remove-AzureTrafficCollector', 'Remove-CollectorPolicy', 'Set-AzureTrafficCollector', 'Set-CollectorPolicy', 'Update-AzureTrafficCollectorTag', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = ''
      LicenseUri = ''
      ProjectUri = ''
      ReleaseNotes = ''
    }
  }
}
