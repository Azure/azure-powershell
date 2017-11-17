
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

function LoginWithConnection([string]$connectionName) {
	
	if ([string]::IsNullOrEmpty($connectionName)) {
		$connectionName = "AzureRunAsConnection";
		Write-Output "Parameter 'connectionName' is not set - will use the default connection name $connectionName"
	}
	
	try {
		$servicePrincipalConnection=Get-AutomationConnection -Name $connectionName         

		"==> Logging in to Azure using connection $connectionName..."
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
	"Available subscriptions:"
	Get-AzureRmSubscription | Format-Table -Property Name, Id | Write-Output
}

function TestRunner( [string[]]$tests ) {

    if (!$tests -or $tests.Count -eq 0) {
		$msg = "No tests found to execute"
		throw $msg
	}

	$pass = 0;
    $fail = 0;
    $run = 0;
	$total = $tests.Count;
	
	"==> Staring test execution..."
	$startTime = (Get-Date)
    foreach ($test in $tests) {
        try {
            $run++;
            "--> Running $test..."
            #& $tast | Out-Null
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

function SaveResultsInStorageAccount {

	Param(
		[parameter(Mandatory=$true)]
		[string] $jobId,
		[parameter(Mandatory=$true)]
		[string] $subscriptionName,
		[parameter(Mandatory=$true)]
		[string] $automationAccountName,
		[parameter(Mandatory=$true)]
		[string] $aaResourseGroupName,
		[parameter(Mandatory=$true)]
		[string] $storageAccountName,
		[parameter(Mandatory=$true)]
		[string] $saResourseGroupName,
		[parameter(Mandatory=$true)]
		[string] $containerName,
		[parameter(Mandatory=$true)]
		[string] $reportFolderPrefix
	)

	$cntx = Get-AzureRmContext
    if ($cntx.Subscription.Name -ne $subscriptionName) {
        $null = Get-AzureRmSubscription -SubscriptionName $subscriptionName | Select-AzureRmSubscription
    }  

	$outputPath = Join-Path $PSScriptRoot "Reports"
	if (-not (Test-Path $outputPath)) {
		$null = New-Item -ItemType Directory -Path $outputPath
	} else { 
		Remove-Item "$outputPath\*"
	}

	#get job streams
	$streams = Get-AzureRmAutomationJobOutput -id $jobId -ResourceGroupName $aaResourseGroupName -AutomationAccountName $automationAccountName -Stream Any | Where-Object { 
		($_.Summary).Length -gt 0 
	} | Get-AzureRmAutomationJobOutputRecord

	#generate reports localy

	$outputStr = 'Output'
	$errorStr = 'Error'
	$warningStr = 'Warning'

	$streamTypes = @($outputStr, $errorStr, $warningStr)

	$streamTypes | ForEach-Object {
		$streamType = $_
		$fileName = "$streamType.txt"
		$filePath = Join-Path $outputPath $fileName
		$null = New-Item -Path  $outputPath -Name $fileName -ItemType File

		$streams | Where-Object {
			$_.Type -eq $streamType
		} | ForEach-Object {
			$stream = $_
			switch ($streamType) {
				$outputStr {
					$stream.Value.value | Add-Content -Path $filePath
				} $errorStr {
					$stream.Value.Exception | Add-Content -Path $filePath
					$stream.Value.ScriptStackTrace | Add-Content -Path $filePath
				} $warningStr {
					$stream.Value.Message | Add-Content -Path $filePath
					$stream.Value.InvocationInfo | Add-Content -Path $filePath
				} default {
					Write-Output "Can't be here $streamType"
				} 
			}
		}
	}

	#upload reports to storage account
	$ctx = (Get-AzureRmStorageAccount -ResourceGroupName $saResourseGroupName -AccountName $storageAccountName).Context
	$now = Get-Date;
	$folderName = "{0}_{1}-{2}-{3}" -f $reportFolderPrefix, $now.Month, $now.Day, $now.Year, $_.Name
	
	Get-ChildItem $outputPath -Filter "*.txt" | Where-Object {
		$_.Length -gt 0
	} | ForEach-Object {
		$filePath =  Join-Path $outputPath $_.Name
		$blobName = "$folderName\$_" 
		$null = Set-AzureStorageBlobContent -Container $containerName  -File $filePath -Blob $blobName -Context $ctx -Force -ErrorAction Stop
	}
}
