if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataBoxCustomerDiskJobDetailsObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataBoxCustomerDiskJobDetailsObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDataBoxCustomerDiskJobDetailsObject' {
    It '__AllParameterSets' -skip {
        {
            $dataAccount = New-AzDataBoxStorageAccountDetailsObject -StorageAccountId "/subscriptions/YourSubscriptionId/resourceGroups/YourResourceGroup/providers/Microsoft.Storage/storageAccounts/YourStorageAccount"
            $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "XXXX XXXX" -EmailList @("emailId") -Phone "0000000000"
            $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "XXXX XXXX" -StateOrProvince "XX" -Country "XX" -City "XXXX XXXX" -PostalCode "00000" -AddressType "Commercial"
            $importDiskDetailsCollection = @{"XXXXXX"= @{ManifestFile = "xyz.txt"; ManifestHash = "xxxx"; BitLockerKey = "xxx"}}  

            $config = New-AzDataBoxCustomerDiskJobDetailsObject -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -ImportDiskDetailsCollection $importDiskDetailsCollection -ReturnToCustomerPackageDetailCarrierAccountNumber "00000"
            $config.Type | Should -Be "DataBoxCustomerDisk"
        } | Should -Not -Throw
    }
}
