
$global:Location = "local"
$global:TenantVMName = "502828aa-de3a-4ba9-a66c-5ae6d49589d7"
$global:Provider = "Microsoft.Compute.Admin"

if(-not $RunRaw) {
	$scriptBlock = {
		Get-MockClient -ClassName 'ComputeAdminClient' -TestName $global:TestName -Verbose
	}
	Mock New-ServiceClient $scriptBlock -ModuleName "Azs.Compute.Admin"
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
