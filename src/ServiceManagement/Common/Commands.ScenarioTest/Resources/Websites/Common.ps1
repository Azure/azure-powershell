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

$global:createdWebsites = @()
$currentWebsite = $null

<#
.SYNOPSIS
Gets valid website name.
#>
function Get-WebsiteName
{
    $name = getAssetName
    Write-Debug "Creating website with name $name"
    Store-Website $name
    return $name
}

<#
.SYNOPSIS
Gets a valid website location, given a preferred location
#>
function Get-WebsiteDefaultLocation
{
    param([string] $defaultLoc = $null)
    $location = $null
    if ($global:DefaultLocation -ne $null)
    {
       $location = $global:DefaultLocation
    }
    else 
    {
       $locations = @(Get-AzureWebsiteLocation)
       $locations | % {
         if ($_.ToLower() -eq $defaultLoc)
         {
            $location = $defaultLoc
         }
      }
      if ($location -eq $null)
      {
          $location = $locations[0]
      }
    }

    return $location;
}

<#
.SYNOPSIS
Gets a valid storage location
#>
function Get-StorageDefaultLocation
{
	$location = $null
	$locations = @(Get-AzureLocation)
       $locations | % {
	     if ($_.AvailableServices.Contains("Storage"))
		 {
		    $location = $_.Name
		 }
	  }

	return $location;
}

<#
.SYNOPSIS
Gets valid website job name.
#>
function Get-WebsiteJobName
{
    return "OneSDKWebsiteJob" + (Get-Random).ToString()
}

<#
.SYNOPSIS
Creates websites with the count specified

.PARAMETER count
The number of websites to create.
#>
function New-Website
{
    param([int] $count)
    
    1..$count | % {
        $name = Get-WebsiteName
        New-AzureWebsite $name
        $global:createdWebsites += $name
    }
}

<#
.SYNOPSIS
Removes all websites
#>
function Initialize-WebsiteTest
{
  Get-AzureWebsite | Remove-AzureWebsite -Force
}


<#
.SYNOPSIS
Sets up environment for running a website test
#>
function Initialize-SingleWebsiteTest
{
  Write-Debug "Saving Global Location"
  $global:testLocation = Get-Location
}

<#
.SYNOPSIS
Removes all created websites.
#>
function Cleanup-SingleWebsiteTest
{
    $global:createdWebsites | % {
       if ($_ -ne $null)
       {
         try
         {
            Write-Debug "Removing website with name $_"
            $catch = Remove-AzureWebsite -Name $_ -Slot Production -Force
         }
         catch 
         {
         }
      }
    }

    $global:createdWebsites.Clear()
    Set-Location $global:testLocation
}

<#
.SYNOPSIS
Run a website test, with cleanup.
#>
function Run-WebsiteTest
{
   param([ScriptBlock] $test, [string] $testName)
   
   Initialize-SingleWebsiteTest *> "$testName.debug_log"
   try 
   {
     Run-Test $test $testName *>> "$testName.debug_log"
   }
   finally 
   {
     Cleanup-SingleWebsiteTest *>> "$testName.debug_log"
   }
}

<#
.SYNOPSIS
Record the creation of a website
#>
function Store-Website
{
   param([string]$name)
   $global:createdWebsites += $name
}

<#
.SYNOPSIS
Clones git repo
#>
function Clone-GitRepo
{
    param([string] $repo, [string] $dir)

    $cloned = $false
    do
    {
        try
        {
            git clone $repo $dir
            $cloned = $true
        }
        catch
        {
            # Do nothing
        }
    }
    while (!$cloned)
}

<#
.SYNOPSIS
Creates new website using the sample log app template.
#>
function New-BasicLogWebsite
{
    $name = Get-WebsiteName
    Clone-GitRepo https://github.com/wapTestApps/basic-log-app.git $name
    $password = ConvertTo-SecureString $githubPassword -AsPlainText -Force
    $credentials = New-Object System.Management.Automation.PSCredential $githubUsername,$password 
    cd $name
    $global:currentWebsite = New-AzureWebsite -Name $name -Github -GithubCredentials $credentials -GithubRepository wapTestApps/basic-log-app
}

<#
.SYNOPSIS
Waits on the specified task until it does not return not found.

.PARAMETER scriptBlock
The script block to execute.

.PARAMETER timeout
The maximum timeout for the script.
#>
function Wait-WebsiteFunction
{
    param([ScriptBlock] $scriptBlock, [object] $breakCondition, [int] $timeout)

    if ($timeout -eq 0) { $timeout = 60 * 5 }
    $start = [DateTime]::Now
    $current = [DateTime]::Now
    $diff = $current - $start

    do
    {
        Wait-Seconds 5
        $current = [DateTime]::Now
        $diff = $current - $start
        $result = $null
        try
        {
           $result = &$scriptBlock
        }
        catch {}
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
Retries DownloadString
#>
function Retry-DownloadString
{
    param([object] $client, [string] $uri)

    $retry = $false

    do
    {
        try
        {
            $client.DownloadString($uri)
            $retry = $false
        }
        catch
        {
            $retry = $true
            Write-Warning "Retry calling $client.DownloadString"
        }
    }
    while ($retry)
}

<#
.SYNOPSIS
Get downloadString and verify expected string
#>
function Test-ValidateResultInBrowser
{
       param([string] $uri, [string] $expectedString)
       $client = New-Object System.Net.WebClient
       $resultString = $client.DownloadString($uri)
       return $resultString.ToUpper().Contains($expectedString.ToUpper())
}

<#
.SYNOPSIS
Runs npm and verifies the results.

.PARAMETER command
The npm command to run
#>

function Npm-InstallExpress
{
    try
    {
        $command = "install -g express@3.4.8";
        Start-Process npm $command -WAIT
        "Y" | express
        if([system.IO.File]::Exists("server.js"))
        {
            del server.js
        }
        mv app.js server.js
        npm install 
    }
    catch
    {
        Write-Warning "Expected warning exist when npm install, ignore it"
    }
}

<#
.SYNOPSIS
Push local git repo to website.

.PARAMETER command
Target site name to push
#>

function Git-PushLocalGitToWebSite
{
    param([string] $siteName)
    $webSite = Get-AzureWebsite -Name $siteName -Slot Production

    # Expected warning: LF will be replaced by CRLF in node_modules/.bin/express." when run git command
    Assert-Throws { git add -A } 
    $commitString = "Update azurewebsite with local git"
    Assert-Throws { git commit -m $commitString }

    $remoteAlias = "azureins"
    $remoteUri = "https://" + $env:GIT_USERNAME + ":" + $env:GIT_PASSWORD + "@" + $webSite.EnabledHostNames[1] + "/" + $webSite.Name + ".git"
    git remote add $remoteAlias $remoteUri

    # Disable Git SSL verification for Windows Azure Pack
    git config --local http.sslVerify false
    
    # Expected message "remote: Updating branch 'master'"
    Assert-Throws { git push $remoteAlias master }
}

<#
.SYNOPSIS
A convinience function for you to pass in existing web site name and preferred web job configuration 
#>
function Test-CreateAndRemoveAJob
{
    param([string] $webSiteName, [string] $webSiteJobName, [string] $webSiteJobType, [string] $testCommandFile)
    
    # Setup
    New-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -JobType $webSiteJobType -JobFile $testCommandFile
    Get-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -JobType $webSiteJobType

    # Test
    If ($webSiteJobType -eq "Continuous")
    {
        Write-Host "Wait and retry to work around a known limitation, that a newly created job might not be immediately available."
        $waitScriptBlock = { Stop-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -PassThru }
        Wait-WebsiteFunction $waitScriptBlock $TRUE
    }
    
    $removed = Remove-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -JobType $webSiteJobType –Force

    # Assert
    Assert-True { $removed }
}
