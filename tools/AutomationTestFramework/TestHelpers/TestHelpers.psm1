
function LoginWithConnection([string]$connectionName) {
	if (!$connectionName) {
		$connectionName = "AzureRunAsConnection";
		Write-Output "Parameter 'connectionName' is not set - will use the default connection name $connectionName"
	}
	
	try {
		$servicePrincipalConnection=Get-AutomationConnection -Name $connectionName         

		"==> Logging in to Azure..."
		Add-AzureRmAccount `
			-ServicePrincipal `
			-TenantId $servicePrincipalConnection.TenantId `
			-ApplicationId $servicePrincipalConnection.ApplicationId `
			-CertificateThumbprint $servicePrincipalConnection.CertificateThumbprint 
	} catch {
		if (!$servicePrincipalConnection) {
			$ErrorMessage = "Connection $connectionName not found."
			throw $ErrorMessage
		} else {
			Write-Error -Message $_.Exception
			throw $_.Exception
		}
	}

	Get-AzureRmSubscription | Format-Table -Property Name, Id
}

function TestRunner( [string[]]$tests ) {
    if (!$tests -or $tests.Count -eq 0) {
		$msg = "No tests found to execute"
		Write-Error $msg
		throw $msg
	}
	$pass = 0;
    $fail = 0;
    $run = 0;
    $total = $tests.Count;
    "==> Staring test cases..."
    foreach ($test in $tests) {
        try {
            $run++;
            Write-Output "--> Running $test..."
            #& $tast | Out-Null
            $null = & $test
            Write-Output "+++ Test PASSED"
            $pass++;
        
        }  catch {
            $fail++;
            #$PSItem.InvocationInfo | Format-List *
            Write-Output "!!! Test FAILED: $PSItem"
            $scriptStackTrace = $PSItem.ScriptStackTrace
			$newLine = [Environment]::NewLine
			$scriptStackTrace.Split($newLine) | Where-Object {$_.Length -gt 0} | ForEach-Object { Write-Output "`t$_" }
			Write-Error "!!! Test FAILED: $PSItem$newLine$scriptStackTrace"
		}
	}
	
	"==> Done: PASSED $pass  FAILED $fail  EXECUTED $run($total)";
	
	if ($fail -gt 0) {
		$msg = "$fail test(s) failed. Please see log for details"
		Write-Error $msg
		throw $msg
	}
	
}