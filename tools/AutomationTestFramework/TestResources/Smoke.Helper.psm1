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

function LoginWithConnection([string] $connectionName, [string] $subscriptionName) {
	
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

# https://blogs.endjin.com/2014/07/how-to-retry-commands-in-powershell/
function Retry-Command
{
    param (
		[ScriptBlock] $script,
		[string] $connectionName, 
		[string] $subscriptionName,
        [int] $retyCount = 3,
        [int] $secondsDelay = 5
    )
    $currentRetryCount = 0
    $succeeded = $false
    while (-not $succeeded) {
        try {
            # Setting ErrorAction to Stop is important. This ensures any errors that occur in the command are 
            # treated as terminating errors, and will be caught by the catch block.
            & $script -ErrorAction Stop
            $succeeded = $true
        } catch {
            if ($currentRetryCount -ge $retyCount) {
                Write-Output "Maximum retry count ($currentRetryCount) exceeded!"
                throw $_
            } else {
                $currentRetryCount++
                Write-Output "Attempt #$currentRetryCount failed (Max $retyCount). Retrying after $secondsDelay seconds..."
				Start-Sleep $secondsDelay
				LoginWithConnection $connectionName $subscriptionName
            }
        }
    }
}

function TestRunner([string[]]$tests, [string] $connectionName, [string] $subscriptionName) {

    if (!$tests -or $tests.Count -eq 0) {
		$msg = "No tests found to execute"
		throw $msg
	}

	$pass = 0;
    $fail = 0;
    $run = 0;
	$total = $tests.Count;
	
	"==> Starting test execution..."
	$startTime = (Get-Date)
    foreach ($test in $tests) {
        try {
            $run++;
            "--> Running $test..."
			# Retry-Command -connectionName $connectionName -subscriptionName $subscriptionName { $null = & $test }
			$null = & $test
            "+++ Test PASSED"
            $pass++;
        }  catch {
            $fail++;
            "!!! Test FAILED: $PSItem"
            $scriptStackTrace = $PSItem.ScriptStackTrace
			$newLine = [Environment]::NewLine
			$scriptStackTrace.Split($newLine) | Where-Object {$_.Length -gt 0} | ForEach-Object { Write-Output "`t$_" }
		}
	}

	$endTime = (Get-Date)
	$elapsedTime = $endTime-$startTime
	$duration = '{0:hh} h {0:mm} min {0:ss} sec' -f $elapsedTime
	"==> Done: PASSED $pass  FAILED $fail  EXECUTED $run($total) DURATION $duration";
}