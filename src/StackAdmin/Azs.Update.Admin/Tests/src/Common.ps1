
$global:Provider = "Microsoft.Update.Admin"

if (-not $global:RunRaw) {
    $scriptBlock = {
        Get-MockClient -ClassName 'UpdateAdminClient' -TestName $global:TestName -Verbose
    }
    Mock New-ServiceClient $scriptBlock -ModuleName $global:ModuleName
}

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}
