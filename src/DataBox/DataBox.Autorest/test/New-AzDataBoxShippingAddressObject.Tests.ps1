$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataBoxShippingAddressObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataBoxShippingAddressObject' {
    It '__AllParameterSets' {
        $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 $env.StreetAddress1 -StateOrProvince $env.StateOrProvince -Country $env.Country -City $env.City -PostalCode $env.PostalCode -AddressType $env.AddressType
        $ShippingDetails.StreetAddress1 | Should -Be $env.StreetAddress1
    }
}
