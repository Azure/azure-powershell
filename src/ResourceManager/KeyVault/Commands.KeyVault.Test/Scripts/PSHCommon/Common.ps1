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

$excludedExtensions = @(".dll", ".zip", ".msi", ".exe")

<#
.SYNOPSIS
Retrieve the contents of a PowerShell transcript, stripping headers and
footers.

.PARAMETER path
The path to the transcript file to read.
#>
function Get-Transcript
{
    param(
        [string] $path
    )

    return Get-Content $path |
    Select-String -InputObject {$_} -Pattern "^Start Time\s*:.*" -NotMatch |
    Select-String -InputObject {$_} -Pattern "^End Time\s*:.*" -NotMatch |
    Select-String -InputObject {$_} -Pattern "^Machine\s*:.*" -NotMatch |
    Select-String -InputObject {$_} -Pattern "^Username\s*:.*" -NotMatch |
    Select-String -InputObject {$_} -Pattern "^Transcript started, output file is.*" -NotMatch
}


<#
.SYNOPSIS
Get a random file name in the current directory.

.PARAMETER rootPath
The path of the directory to contain the random file (optional).
#>
function Get-LogFile
{
    param(
        [string] $rootPath = "."
    )
    return [System.IO.Path]::Combine($rootPath, ([System.IO.Path]::GetRandomFileName()))
}

<#
.SYNOPSIS
Execute the test. If no exception is thrown, then the test passes.

.PARAMETER test
The test code to run.

.PARAMETER testName
The name of the test (optional).

.PARAMETER testScript
The path to the baseline file (optional).

.PARAMETER generate
Set if the baseline file should be generated, otherwise the baseline
file would be used for comparison with test output.

.NOTES
This function can also be used to compare test output to a baseline
file, or to generate a baseline file.
#>
function Run-Test
{
    param(
        [scriptblock] $test,
        [string] $testName = $null,
        [string] $testScript = $null,
        [switch] $generate = $false
    )

    Test-Setup
    $transFile = $testName + ".log"
    if ($testName -eq $null)
    {
      $transFile = Get-LogFile "."
    }
    if($testScript)
    {
        if ($generate)
        {
            Write-Log "[run-test]: generating script file $testScript"
            $transFile = $testScript
        }
        else
        {
            Write-Log "[run-test]: writing output to $transFile, using validation script $testScript"
        }
    }
    else
    {
         Write-Log "[run-test]: Running test without file comparison"
    }

    $oldPref = $ErrorActionPreference
    $ErrorActionPreference = "SilentlyContinue"
    $success = $false
    $ErrorActionPreference = $oldPref
    try
    {
        &$test
        $success = $true
    }
    finally
    {
        Test-Cleanup
        $oldPref = $ErrorActionPreference
        $ErrorActionPreference = "SilentlyContinue"
        $ErrorActionPreference = $oldPref
        if ($testScript)
        {
            if ($success -and -not $generate)
            {
                $result = Compare-Object (Get-Transcript $testScript) (Get-Transcript $transFile)
                if ($result -ne $null)
                {
                    throw "[run-test]: Test Failed " + (Out-String -InputObject $result) + ", Transcript at $transFile"
                }
            }
        }

        if ($success)
        {
            Write-Log "[run-test]: Test Passed"
        }
    }
}

<#
.SYNOPSIS
Format the string for proper output to host and transcript.

.PARAMETER message
The text to write (optional).
#>
function Write-Log
{
    [CmdletBinding()]
    param(
        [Parameter(Position=0, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$false)]
        [Object] $message = ""
    )

    PROCESS
    {
        $message | Out-String | Write-Verbose
    }
}

<#
.SYNOPSIS
Check for a subscription match.

.PARAMETER baseSubscriptionName
The name of the base subscription.

.PARAMETER checkedSubscription
The subscription to be validated.
#>
function Check-SubscriptionMatch
{
    param(
        [string] $baseSubscriptionName,
        [Microsoft.WindowsAzure.Commands.Utilities.Common.SubscriptionData] $checkedSubscription
    )

    Write-Log ("[CheckSubscriptionMatch]: base subscription: '$baseSubscriptionName', validating '" + ($checkedSubscription.SubscriptionName)+ "'")
    Format-Subscription $checkedSubscription | Write-Log
    if ($baseSubscriptionName -ne $checkedSubscription.SubscriptionName)
    {
        throw ("[Check-SubscriptionMatch]: Subscription Match Failed '" + ($baseSubscriptionName) + "' != '" + ($checkedSubscription.SubscriptionName) + "'")
    }

    Write-Log ("CheckSubscriptionMatch]: subscription check succeeded.")
}

<#
.SYNOPSIS
Retrieve the fully qualified filename of a given file.

.PARAMETER path
The relative path to the file.
#>
function Get-FullName
{
    param(
        [string] $path
    )

    $pathObj = Get-Item $path
    return ($pathObj.FullName)
}

<#
.SYNOPSIS
Set up the PowerShell environment.

.DESCRIPTION
This function sets up the PowerShell environment for running a test,
saving previous environment settings and enabling verbose, debug, and
warning streams.
#>
function Test-Setup
{
    $global:oldConfirmPreference = $global:ConfirmPreference
    $global:oldDebugPreference = $global:DebugPreference
    $global:oldErrorActionPreference = $global:ErrorActionPreference
    $global:oldFormatEnumerationLimit = $global:FormatEnumerationLimit
    $global:oldProgressPreference = $global:ProgressPreference
    $global:oldVerbosePreference = $global:VerbosePreference
    $global:oldWarningPreference = $global:WarningPreference
    $global:oldWhatIfPreference = $global:WhatIfPreference
    $global:ConfirmPreference = "None"
    $global:DebugPreference = "Continue"
    $global:ErrorActionPreference = "Stop"
    $global:FormatEnumerationLimit = 10000
    $global:ProgressPreference = "SilentlyContinue"
    $global:VerbosePreference = "Continue"
    $global:WarningPreference = "Continue"
    $global:WhatIfPreference = 0
}

<#
.SYNOPSIS
Clean up the PowerShell environment.

.DESCRIPTION
This function cleans up the PowerShell environment for running a test by
restoring previous environment settings.
#>
function Test-Cleanup
{
    $global:ConfirmPreference = $global:oldConfirmPreference
    $global:DebugPreference = $global:oldDebugPreference
    $global:ErrorActionPreference = $global:oldErrorActionPreference
    $global:FormatEnumerationLimit = $global:oldFormatEnumerationLimit
    $global:ProgressPreference = $global:oldProgressPreference
    $global:VerbosePreference = $global:oldVerbosePreference
    $global:WarningPreference = $global:oldWarningPreference
    $global:WhatIfPreference = $global:oldWhatIfPreference
}

<#
.SYNOPSIS
Dump the contents of the directory to the output stream.

.PARAMETER rootPath
The path to the directory.

.PARAMETER recurse
True if we should recurse directories.
#>
function Dump-Contents
{
    param(
        [string] $rootPath = ".",
        [switch] $recurse = $false
    )

    if (-not ((Test-Path $rootPath) -eq $true))
    {
        throw "[dump-contents]: $rootPath does not exist"
    }

    foreach ($item in Get-ChildItem $rootPath)
    {
        Write-Log
        Write-Log "---------------------------"
        Write-Log $item.Name
        Write-Log "---------------------------"
        Write-Log
        if (!$item.PSIsContainer)
        {
           if (Test-BinaryFile $item)
           {
               Write-Log "---- binary data excluded ----"
           }
           else
           {
               Get-Content ($item.PSPath)
           }
        }
        elseif ($recurse)
        {
            Dump-Contents ($item.PSPath) -recurse
        }
    }
}

<#
.SYNOPSIS
Test the binary file.

.PARAMETER file
The binary file to be tested.
#>
function Test-BinaryFile
{
    param(
        [System.IO.FileInfo] $file
    )

    ($excludedExtensions | Where-Object -FilterScript {$_ -eq $file.Extension}) -ne $null
}


<#
.SYNOPSIS
Wait on the specified job with the given timeout.

.PARAMETER scriptBlock
The script block to execute.

.PARAMETER timeout
The maximum timeout for the script.
#>
function Wait-Function
{
    param(
        [ScriptBlock] $scriptBlock,
        [object] $breakCondition,
        [int] $timeout
    )

    if ($timeout -eq 0) { $timeout = 60 * 5 }
    $start = [DateTime]::Now
    $current = [DateTime]::Now
    $diff = $current - $start

    do
    {
        Wait-Seconds 5
        $current = [DateTime]::Now
        $diff = $current - $start
        $result = &$scriptBlock
    }
    while(($result -ne $breakCondition) -and ($diff.TotalSeconds -lt $timeout))

    if ($diff.TotalSeconds -ge $timeout)
    {
        Write-Warning "The script block '$scriptBlock' exceeded the timeout."
        # End the processing so the test does not blow up
        exit
    }
}

<#
.SYNOPSIS
Wait for specified duration if not-mocked, otherwise skips wait.

.PARAMETER timeout
Timeout in seconds
#>
function Wait-Seconds
{
    param(
        [int] $timeout
    )

    try
    {
        if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
        {
            Write-Host "Skipping Start-Sleep since we're in playback mode..."
            return
        }

        Write-Host "Calling Start-Sleep since we're not in playback mode..."
    }
    catch [System.Management.Automation.RuntimeException]
    {
        if (-not $_.Exception.Message.Contains("Unable to find type [Microsoft.Azure.Test.HttpRecorder."))
        {
            throw
        }

        Write-Host "Calling Start-Sleep since we're unable to find the HttpRecorder library..."
    }

    Start-Sleep -Seconds $timeout
}

<#
.SYNOPSIS
Retry the specified job the given numer of times, waiting the given
interval between tries.

.PARAMETER scriptBlock
The script block to execute. Must be a predicate (return true or false).

.PARAMETER argument
The argument to pass to the script block.

.PARAMETER maxTries
The maximum number of times to retry.

.PARAMETER interval
The number of seconds to wait before retrying.
#>
function Retry-Function
{
    param(
        [ScriptBlock] $scriptBlock,
        [Object] $argument,
        [int] $maxTries,
        [int] $interval
    )

    if ($interval -eq 0) { $interval = 60 }

    $result = Invoke-Command -ScriptBlock $scriptBlock -ArgumentList $argument
    $tries = 1
    while(( $result -ne $true) -and ($tries -le $maxTries))
    {
        Wait-Seconds $interval
        $result = Invoke-Command -ScriptBlock $scriptBlock -ArgumentList $argument
        $tries++
    }

    return $result
}

<#
.SYNOPSIS
Retrieve the name of the asset.
#>
function GetAssetName
{
    $stack = Get-PSCallStack
    $testName = $null
    foreach ($frame in $stack)
    {
        if ($frame.Command.StartsWith("Test-", "CurrentCultureIgnoreCase"))
        {
            $testName = $frame.Command
        }
    }

    $assetName = [Microsoft.Azure.Utilities.HttpRecorder.HttpMockServer]::GetAssetName($testName, "onesdk")

    return $assetName
}