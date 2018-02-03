# ----------------------------------------------------------------------------------
	#
	# Copyright Microsoft Corporation
	# Licensed under the Apache License, Version 2.0 (the "License");
	# you may not use this file except in compliance with the License.
	# You may obtain a copy of the License at
	# http://www.apache.org/licenses/LICENSE-2.0
	# Unless required by applicable law or agreed to in writing, software
	# distributed under the License is distributed on an "AS IS" BASIS,
	# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	# See the License for the specific language governing permissions and
	# limitations under the License.
# ----------------------------------------------------------------------------------

function Login-AutomationConnection([string] $connectionName, [string] $subscriptionName) {
	
	if ([string]::IsNullOrEmpty($connectionName)) {
		$connectionName = 'AzureRunAsConnection';
		Write-Output "Parameter 'connectionName' is not set - will use the default connection name $connectionName"
	}
	
	try {
		$servicePrincipalConnection = Get-AutomationConnection -Name $connectionName

		"==> Logging in to Azure using connection $connectionName with subscription $subscriptionName..."
		$null = Add-AzureRmAccount `
			-ServicePrincipal `
			-TenantId $servicePrincipalConnection.TenantId `
			-ApplicationId $servicePrincipalConnection.ApplicationId `
			-CertificateThumbprint $servicePrincipalConnection.CertificateThumbprint `
			-Subscription $subscriptionName
	} catch {
		if (!$servicePrincipalConnection) {
			$ErrorMessage = "Connection $connectionName not found."
			throw $ErrorMessage
		} else {
			Write-Error -Message $_.Exception
			throw $_.Exception
		}
	}
}

function Run-Test([string[]] $tests, [string] $connectionName, [string] $subscriptionName) {

    if (-not $tests -or $tests.Count -eq 0) {
		throw "No tests found to execute"
	}
	
	"==> Starting test execution..."
	$pass = 0
	$fail = 0
	$run = 0
	$startTime = (Get-Date)
    foreach ($test in $tests) {
        try {
            $run++
            "--> Running $test..."
			$null = & $test
            "+++ Test PASSED"
            $pass++
        }  catch {
            $fail++
            "!!! Test FAILED: $_"
			$_.ScriptStackTrace.Split([Environment]::NewLine) | Where-Object {$_.Length -gt 0} | ForEach-Object { Write-Output "`t$_" }
		}
	}
	$endTime = (Get-Date)

	$duration = '{0:hh} h {0:mm} min {0:ss} sec' -f ($endTime - $startTime)
	"==> Done: PASSED $pass | FAILED $fail | EXECUTED $run($($tests.Count)) | DURATION $duration"
}