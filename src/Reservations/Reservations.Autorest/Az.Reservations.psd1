@{
  GUID = '59d3f19f-af05-4d96-a9a8-ff647983b57f'
  RootModule = './Az.Reservations.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Reservations cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Reservations.private.dll'
  FormatsToProcess = './Az.Reservations.format.ps1xml'
  FunctionsToExport = 'Get-AzReservation', 'Get-AzReservationAvailableScope', 'Get-AzReservationCatalog', 'Get-AzReservationHistory', 'Get-AzReservationOrder', 'Get-AzReservationOrderId', 'Get-AzReservationQuote', 'Invoke-AzReservationArchiveReservation', 'Invoke-AzReservationCalculateExchange', 'Invoke-AzReservationCalculateRefund', 'Invoke-AzReservationExchange', 'Invoke-AzReservationReturn', 'Invoke-AzReservationUnarchiveReservation', 'Merge-AzReservation', 'Move-AzReservationDirectory', 'New-AzReservation', 'Split-AzReservation', 'Update-AzReservation', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Reservations'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
