
$global:Location = "local"
$global:TenantVMName = "502828aa-de3a-4ba9-a66c-5ae6d49589d7"
$global:Provider = "Microsoft.Fabric.Admin"

if(-not $RunRaw) {
	$scriptBlock = {
		Get-MockClient -ClassName 'FabricAdminClient' -TestName $global:TestName -Verbose
	}
	Mock Get-ServiceClient $scriptBlock -ModuleName "Azs.Fabric.Admin"
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

function ExtractOperationId{
	param(
		[string]$Uri
	)
	[int]$start = $Uri.LastIndexOf('/') + 1
	[int]$end = $Uri.LastIndexOf('?')
	[int]$length = $end - $start
	return $Uri.Substring($start, $length)
}

function PollComputeOperationId{
	param(
		[string]$ComputeOperationUri
	)

	$ComputeOperationId = ExtractOperationId $ComputeOperationUri

	Repeat 10 {Get-ComputeFabricOperation -Location $Location -Provider $Provider -ComputeOperationResult $ComputeOperationId}
}
