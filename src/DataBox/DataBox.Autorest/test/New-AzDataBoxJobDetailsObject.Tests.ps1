$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataBoxJobDetailsObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataBoxJobDetailsObject' {
    It '__AllParameterSets' {
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -StorageAccountId $env.StorageAccountId

        $details = New-AzDataBoxJobDetailsObject -DataImportDetail @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"}) `
            -ContactDetailsContactName $env.ContactName `
            -ContactDetailEmailList $env.EmailList `
            -ContactDetailsPhone $env.Phone `
            -StreetAddress1 $env.StreetAddress1 `
            -StateOrProvince $env.StateOrProvince `
            -Country $env.Country `
            -City $env.City `
            -PostalCode $env.PostalCode `
            -ShippingAddressType $env.AddressType

        $details | Should -Not -BeNullOrEmpty
    }
}
