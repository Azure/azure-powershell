@{
  GUID = '2dfa9435-78be-44de-bc7e-8e8c7cf9da29'
  RootModule = 'Azs.Subscriptions.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = ''
  CompanyName = ''
  Copyright = ''
  Description = ''
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Azs.Subscriptions.private.dll'
  FormatsToProcess = './Azs.Subscriptions.format.ps1xml'
  CmdletsToExport = 'Get-AzsDelegatedProviderOffer', 'Get-AzsOffer', 'Get-AzsSubscription', 'New-AzsSubscription', 'Remove-AzsSubscription', 'Set-AzsSubscription', '*'
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
