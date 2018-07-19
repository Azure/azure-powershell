
$global:SkippedTests = @(
    'TestListInvalidLocation',
    'TestCreateQuotaOnInvalidLocation'
)

$global:Location = "local"
$global:Provider = "Microsoft.Compute.Admin"
$global:VHDUri = "https://test.blob.local.azurestack.external/test/xenial-server-cloudimg-amd64-disk1.vhd"


if (-not $global:RunRaw) {
    $scriptBlock = {
        Get-MockClient -ClassName 'ComputeAdminClient' -TestName $global:TestName -Verbose
    }
    Mock New-ServiceClient $scriptBlock -ModuleName $global:ModuleName
}

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}
