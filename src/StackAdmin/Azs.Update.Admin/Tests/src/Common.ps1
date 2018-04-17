
$global:Location = "local"
$global:TenantVMName = "502828aa-de3a-4ba9-a66c-5ae6d49589d7"
$global:Provider = "Microsoft.Update.Admin"

if(-not $RunRaw) {
	$scriptBlock = {
		Get-MockClient -ClassName 'UpdateAdminClient' -TestName $global:TestName -Verbose
	}
	Mock New-ServiceClient $scriptBlock -ModuleName "Azs.Update.Admin"
}

function Repeat{
	param(
		[int]$Times,
		[ScriptBLock]$Script
	)

	while($Times -gt 0) {
		Invoke-Command -ScriptBlock $Script
		$Times = $Times - 1
	}
}
