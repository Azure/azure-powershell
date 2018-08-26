
$global:Location = 'local'

if(-not $global:RunRaw) {
	$scriptBlock = {
		Get-MockClient -ClassName 'KeyVaultAdminClient' -TestName $global:TestName -Verbose
	}
	Mock New-ServiceClient $scriptBlock -ModuleName $global:ModuleName
}

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}
