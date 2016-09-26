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

$global:createdKeys = @()
$global:createdSecrets = @()
$global:createdCertificates = @()

$invocationPath = Split-Path $MyInvocation.MyCommand.Definition;

<#
.SYNOPSIS
Get test key name
#>
function Get-KeyVault([bool] $haspermission=$true)
{
    if ($global:testVault -ne "" -and $haspermission)
    {
        return $global:testVault
    }   
    elseif ($haspermission)
    {
        return 'azkmspsprodeus'    
    }
    else
    {
        return 'azkmspsnopermprodeus'
    }
}

<#
.SYNOPSIS
Get test key name
#>
function Get-KeyName([string]$suffix)
{
    return 'pshtk-' + $global:testns+ '-' + $suffix
}

<#
.SYNOPSIS
Get test secret name
#>
function Get-SecretName([string]$suffix)
{
    return 'pshts-' + $global:testns + '-' + $suffix
}

<#
.SYNOPSIS
Get test certificate name
#>
function Get-CertificateName([string]$suffix)
{
    return 'pshtc-' + $global:testns + '-' + $suffix
}

<#
.SYNOPSIS
Get key file path to be imported
The name convention of a key file is $filesuffixtest.$filesuffix 
#>
function Get-ImportKeyFile([string]$filesuffix, [bool] $exists=$true)
{
    if ($exists)
    {
        $file = "$filesuffix"+"test.$filesuffix"
    }
    else
    {
        $file = "notexist" + ".$filesuffix"
    }

    if ($global:testEnv -eq 'BVT')
    {       
        return Join-Path $invocationPath "bvtdata\$file"        
    }
    else
    {
        return Join-Path $invocationPath "proddata\$file"
    }
}

<#
.SYNOPSIS
Get 1024 bit key file path to be imported
#>
function Get-ImportKeyFile1024([string]$filesuffix, [bool] $exists=$true)
{
    if ($exists)
    {
        $file = "$filesuffix"+"test1024.$filesuffix"
    }
    else
    {
        $file = "notexist" + ".$filesuffix"
    }

    if ($global:testEnv -eq 'BVT')
    {       
        return Join-Path $invocationPath "bvtdata\$file"        
    }
    else
    {
        return Join-Path $invocationPath "proddata\$file"
    }
}


<#
.SYNOPSIS
Get file path from common data directory
#>
function Get-FilePathFromCommonData([string]$fileName)
{
    return Join-Path $invocationPath "commondata\$fileName"
}

<#
.SYNOPSIS
Remove log files under the given folder.
#>
function Cleanup-LogFiles([string]$rootfolder)
{
    Write-Host "Cleaning up log files from $rootfolder..."
    
    Get-ChildItem –Path $rootfolder -Include *.debug_log -Recurse |
        where {$_.mode -match "a"} |
        Remove-Item -Force     
}

<#
.SYNOPSIS
Remove log file under a folder
#>
function Move-Log([string]$rootfolder)
{    
    $logfolder = Join-Path $rootfolder ("$global:testEnv"+"$global:testns"+"log")
    if (Test-Path $logfolder)
    {
        Cleanup-LogFiles $logfolder
    }
    else
    {
        New-Item $logfolder -type directory -force
    }

    Get-ChildItem –Path $rootfolder -Include *.debug_log -Recurse | Move-Item -Destination $logfolder
}


<#
.SYNOPSIS
Remove all old certificates starting with the given prefix.
#>
function Cleanup-OldCertificates
{
    Write-Host "Cleaning up old certificates..."

    $keyVault = Get-KeyVault
    $certificatePattern = Get-CertificateName '*'
    Get-AzureKeyVaultCertificate $keyVault |
        Where-Object {$_.Name -like $certificatePattern} |
        Remove-AzureKeyVaultCertificate -Force -Confirm:$false
}

<#
.SYNOPSIS
Remove all old keys starting with the given prefix.
#>
function Cleanup-OldKeys
{
    Write-Host "Cleaning up old keys..."

    $keyVault = Get-KeyVault
    $keyPattern = Get-KeyName '*'
    Get-AzureKeyVaultKey $keyVault |
        Where-Object {$_.KeyName -like $keyPattern} |
        Remove-AzureKeyVaultKey -Force -Confirm:$false
}

<#
.SYNOPSIS
Remove all old secrets starting with the given prefix.
#>
function Cleanup-OldSecrets
{
    Write-Host "Cleaning up old secrets..."

    $keyVault = Get-KeyVault
    $secretPattern = Get-SecretName '*'
    Get-AzureKeyVaultSecret $keyVault |
        Where-Object {$_.SecretName -like $secretPattern} |
        Remove-AzureKeyVaultSecret -Force -Confirm:$false
}


<#
.SYNOPSIS
Removes all certificates starting with the prefix
#>
function Initialize-CertificateTest
{
    $keyVault = Get-KeyVault
    $certificatePattern = Get-CertificateName '*'
    Get-AzureKeyVaultCertificate $keyVault  | Where-Object {$_.Name -like $certificatePattern}  | Remove-AzureKeyVaultCertificate -Force
}

<#
.SYNOPSIS
Removes all created keys.
#>
function Cleanup-SingleKeyTest
{
    $global:createdKeys | % {
       if ($_ -ne $null)
       {
         try
         {
            $keyVault = Get-KeyVault
            Write-Debug "Removing key with name $_ in vault $keyVault"
            $catch = Remove-AzureKeyVaultKey $keyVault $_ -Force -Confirm:$false
         }
         catch 
         {
         }
      }
    }

    $global:createdKeys.Clear()    
}

<#
.SYNOPSIS
Removes all created secrets.
#>
function Cleanup-SingleSecretTest
{
    $global:createdSecrets | % {
       if ($_ -ne $null)
       {
         try
         {
            $keyVault = Get-KeyVault
            Write-Debug "Removing secret with name $_ in vault $keyVault"
            $catch = Remove-AzureKeyVaultSecret $keyVault $_ -Force -Confirm:$false
         }
         catch 
         {
         }
      }
    }

    $global:createdSecrets.Clear()    
}

<#
.SYNOPSIS
Removes all created certificates.
#>
function Cleanup-SingleCertificateTest
{
    $global:createdCertificates | % {
       if ($_ -ne $null)
       {
         try
         {
            $keyVault = Get-KeyVault
            Write-Debug "Removing certificate with name $_ in vault $keyVault"
            $catch = Remove-AzureKeyVaultCertificate $keyVault $_ -Force -Confirm:$false
         }
         catch 
         {
         }
      }
    }

    $global:createdCertificates.Clear()    
}

<#
.SYNOPSIS
Run a key test, with cleanup.
#>
function Run-KeyTest ([ScriptBlock] $test, [string] $testName)
{   
   try 
   {
     Run-Test $test $testName *>> "$testName.debug_log"
   }
   finally 
   {
     Cleanup-SingleKeyTest *>> "$testName.debug_log"
   }
}

function Run-SecretTest ([ScriptBlock] $test, [string] $testName)
{   
   try 
   {
     Run-Test $test $testName *>> "$testName.debug_log"
   }
   finally 
   {
     Cleanup-SingleSecretTest *>> "$testName.debug_log"
   }
}

function Run-CertificateTest ([ScriptBlock] $test, [string] $testName)
{   
   try 
   {
     Run-Test $test $testName *>> "$testName.debug_log"
   }
   finally 
   {
     Cleanup-SingleCertificateTest *>> "$testName.debug_log"
   }
}

function Run-VaultTest ([ScriptBlock] $test, [string] $testName)
{   
   try 
   {
     Run-Test $test $testName *>> "$testName.debug_log"
   }
   finally 
   {
     
   }
}

function Write-FileReport
{
    $fileName = "$global:testEnv"+"$global:testns"+"Summary.debug_log"	
    Get-TestRunReport *>> $fileName
}


function Get-TestRunReport
{

    Write-Output "PASSED TEST Count=$global:passedCount"
    Write-Output "Total TEST Count=$global:totalCount"
    Write-Output "Start Time=$global:startTime"
    Write-Output "End Time=$global:endTime"
    $elapsed=$global:endTime - $global:startTime
    Write-Output "Elapsed=$elapsed"
   
    Write-Output "Passed TEST`tExecutionTime"
    $global:passedTests | % { $extime=$global:times[$_]; Write-Output $_`t$extime }
    Write-Output "Failed TEST lists"
    $global:failedTests | % { $extime=$global:times[$_]; Write-Output $_`t$extime }	
}

function Write-ConsoleReport
{
    Write-Host
    Write-Host -ForegroundColor Green "$global:passedCount / $global:totalCount Key Vault Tests Pass"
    Write-Host -ForegroundColor Green "============"
    Write-Host -ForegroundColor Green "PASSED TESTS"
    Write-Host -ForegroundColor Green "============"
    $global:passedTests | % { Write-Host -ForegroundColor Green "PASSED "$_": "($global:times[$_]).ToString()}
    Write-Host -ForegroundColor Green "============"
    Write-Host
    Write-Host -ForegroundColor Red "============"
    Write-Host -ForegroundColor Red "FAILED TESTS"
    Write-Host -ForegroundColor Red "============"
    $global:failedTests | % { Write-Host -ForegroundColor Red "FAILED "$_": "($global:times[$_]).ToString()}
    Write-Host -ForegroundColor Red "============"
    Write-Host
    Write-Host -ForegroundColor Green "======="
    Write-Host -ForegroundColor Green "TIMES"
    Write-Host -ForegroundColor Green "======="
    Write-Host
    Write-Host -ForegroundColor Green "Start Time: $global:startTime"
    Write-Host -ForegroundColor Green "End Time: $global:endTime"
    Write-Host -ForegroundColor Green "Elapsed: "($global:endTime - $global:startTime).ToString()	
}

function Equal-DateTime($left, $right)
{   
    if ($left -eq $null -and $right -eq $null)
    {        
        return $true
    }
    if ($left -eq $null -or $right -eq $null)
    {
        return $false
    }
    
    return (($left - $right).Duration() -le $delta)
}

function Equal-Hashtable($left, $right)
{
    if ((EmptyOrNullHashtable $left) -and (-Not (EmptyOrNullHashtable $right)))
    {
        return $false
    }  
    if ((EmptyOrNullHashtable $right) -and (-Not (EmptyOrNullHashtable $left)))
    {
        return $false
    } 
    if ($right.Count -ne $left.Count)
    {
        return $false
    }
    
    return $true
}

function EmptyOrNullHashtable($hashtable)
{
    return ($hashtable -eq $null -or $hashtable.Count -eq 0)
}

function Equal-OperationList($left, $right)
{   
    if ($left -eq $null -and $right -eq $null)
    {        
        return $true
    }
    if ($left -eq $null -or $right -eq $null)
    {
        return $false
    }

    $diff = Compare-Object -ReferenceObject $left -DifferenceObject $right -PassThru
    
    return (-not $diff)
}

function Equal-String($left, $right)
{
    if (([string]::IsNullOrEmpty($left)) -and ([string]::IsNullOrEmpty($right)))
    {
        return $true
    }
    if (([string]::IsNullOrEmpty($left)) -or ([string]::IsNullOrEmpty($right)))
    {
        return $false
    }    
    
    return $left.Equals($right)
}