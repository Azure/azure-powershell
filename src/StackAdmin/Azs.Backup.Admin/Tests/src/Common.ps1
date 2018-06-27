
$global:Location = "local"
$global:TenantVMName = "502828aa-de3a-4ba9-a66c-5ae6d49589d7"
$global:Provider = "Microsoft.Backup.Admin"
$global:ResourceGroup = "System.local"

if(-not $RunRaw) {
	$scriptBlock = {
		Get-MockClient -ClassName 'BackupAdminClient' -TestName $global:TestName -Verbose
	}
	Mock New-ServiceClient $scriptBlock -ModuleName "Azs.Backup.Admin"
}

# Extracts the name needed for parameters
function Select-Name {
	param($Name)
	if($name.contains("/")) {
		$Name = $Name.Substring($Name.LastIndexOf("/")+ 1)
	}
	$Name
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
