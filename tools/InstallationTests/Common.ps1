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
###################################
#
# Retrievce the contents of a powershrell transcript, stripping headers and footers
#
#    param [string] $path: The path to the transript file to read
###################################
function Get-Transcript 
{
   param([string] $path)
   return Get-Content $path |
   Select-String -InputObject {$_} -Pattern "^Start Time\s*:.*" -NotMatch |
   Select-String -InputObject {$_} -Pattern "^End Time\s*:.*" -NotMatch |
   Select-String -InputObject {$_} -Pattern "^Machine\s*:.*" -NotMatch |
   Select-String -InputObject {$_} -Pattern "^Username\s*:.*" -NotMatch |
   Select-String -InputObject {$_} -Pattern "^Transcript started, output file is.*" -NotMatch
}

########################
#
# Get a random file name in the current directory
#
#    param [string] $rootPath: The path of the directory to contain the random file (optional)
########################
function Get-LogFile
{
    param([string] $rootPath = ".")
    return [System.IO.Path]::Combine($rootPath, ([System.IO.Path]::GetRandomFileName()))
}

#################
#
# Execute a test, no exception thrown means the test passes.  Can also be used to compare test 
#  output to a baseline file, or to generate a baseline file
#
#    param [scriptblock] $test: The test code to run
#    param [string] $testScript: The path to the baseline file (optional)
#    param [switch] $generate: Set if the baseline file should be generated, otherwise
#     the baseline file would be used for comparison with test output
##################
function Run-Test 
{
    param([scriptblock]$test, [string] $testName = $null, [string] $testScript = $null, [switch] $generate = $false)
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
    #Start-Transcript -Path $transFile	
    $success = $false;
    $ErrorActionPreference = $oldPref
    try 
    {
      &$test
      $success = $true;
    }
    finally 
    {
        Test-Cleanup
        $oldPref = $ErrorActionPreference	 
        $ErrorActionPreference = "SilentlyContinue"
        #Stop-Transcript
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

##################
#
# Format a string for proper output to host and transcript
#
#    param [string] $message: The text to write
##################
function Write-Log
{
    [CmdletBinding()]
    param( [Object] [Parameter(Position=0, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$false)] $obj = "")
    PROCESS
    {
        $obj | Out-String | Write-Verbose
    }
}

function Check-SubscriptionMatch
{
    param([string] $baseSubscriptionName, [Microsoft.WindowsAzure.Commands.Utilities.Common.SubscriptionData] $checkedSubscription)
    Write-Log ("[CheckSubscriptionMatch]: base subscription: '$baseSubscriptionName', validating '" + ($checkedSubscription.SubscriptionName)+ "'")
    Format-Subscription $checkedSubscription | Write-Log
    if ($baseSubscriptionName -ne $checkedSubscription.SubscriptionName) 
    {
        throw ("[Check-SubscriptionMatch]: Subscription Match Failed '" + ($baseSubscriptionName) + "' != '" + ($checkedSubscription.SubscriptionName) + "'")
    }
    
    Write-Log ("CheckSubscriptionMatch]: subscription check succeeded.")
}


##########################
#
# Return the fully qualified filename of a given file
#
#    param [string] $path: The relative path to the file
#
##########################
function Get-FullName
{
    param([string] $path)
    $pathObj = Get-Item $path
    return ($pathObj.FullName)
}

#############################
#
# PowerShell environment setup for running a test, save previous snvironment settings and 
# enable verbose, debug, and warning streams
#
#############################
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

#############################
#
# PowerShell environment cleanup for running a test, restore previous snvironment settings
#
#############################
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

#######################
#
# Dump the contents of a directory to the output stream
#
#    param [string] $rootPath: The path to the directory
#    param [switch] $resurse : True if we should recurse directories
######################
function Dump-Contents
{
    param([string] $rootPath = ".", [switch] $recurse = $false)
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

function Test-BinaryFile
{
    param ([System.IO.FileInfo] $file)
    ($excludedExtensions | Where-Object -FilterScript {$_ -eq $file.Extension}) -ne $null
}


<#
.SYNOPSIS
Removes all current subscriptions.
#>
function Remove-AllSubscriptions
{
    Get-AzureSubscription | Remove-AzureSubscription -Force
}

<#
.SYNOPSIS
Waits on the specified job with the given timeout.

.PARAMETER scriptBlock
The script block to execute.

.PARAMETER timeout
The maximum timeout for the script.
#>
function Wait-Function
{
    param([ScriptBlock] $scriptBlock, [object] $breakCondition, [int] $timeout)

    if ($timeout -eq 0) { $timeout = 60 * 5 }
    $start = [DateTime]::Now
    $current = [DateTime]::Now
    $diff = $current - $start

    do
    {
        Start-Sleep -s 5
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
Waits for specified duration if not-mocked, otherwise skips wait.

.PARAMETER timeout
Timeout in seconds
#>
function Wait-Seconds
{
    param([int] $timeout)
    
    [Microsoft.WindowsAzure.Testing.TestUtilities]::Wait($timeout * 1000)
}


<#
.SYNOPSIS
Retires the specified job the given numer of times, waiting the given interval between tries

.PARAMETER scriptBlock
The script block to execute. Must be a predicate (return true or false)

.PARAMETER argument
Argument to pass to the script block

.PARAMETER maxTries
The maximum number of times to retry

.PARAMETER interval
The number of seconds to wait before retrying
#>
function Retry-Function
{
    param([ScriptBlock] $scriptBlock, [Object] $argument, [int] $maxTries, [int] $interval)

    if ($interval -eq 0) { $interval = 60  }
    
    $result = Invoke-Command -ScriptBlock $scriptBlock -ArgumentList $argument;
    $tries = 1;
    while(( $result -ne $true) -and ($tries -le $maxTries))
    {
        Start-Sleep -s $interval
        $result = Invoke-Command -ScriptBlock $scriptBlock -ArgumentList $argument;
        $tries++;
    }
    
    return $result;
}

function getAssetName
{
    $stack = Get-PSCallStack
    $testName = $null;
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