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

########################################################################### General Websites Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests any cloud based cmdlet with invalid credentials and expect it'll throw an exception.
#>
function Test-WithInvalidCredentials
{
    param([ScriptBlock] $cloudCmdlet)
    
    # Setup
    Remove-AllSubscriptions

    # Test
    Assert-Throws $cloudCmdlet "No current subscription has been designated. Use Select-AzureSubscription -Current <subscriptionName> to set the current subscription."
}

########################################################################### Remove-AzureWebsite Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Remove-AzureWebsite with existing name
#>
function Test-RemoveAzureServiceWithValidName
{
    # Setup
    $name = Get-WebsiteName
    New-AzureWebsite $name

    # Test
    Remove-AzureWebsite $name -Slot Production -Force

    # Assert
    Assert-True { (Get-AzureWebsite -Name $name ) -eq $null}
    $global:createdWebsites.Clear()
}

<#
.SYNOPSIS
Tests Remove-AzureWebsite with non existing name
#>
function Test-RemoveAzureServiceWithNonExistingName
{
    Assert-True { (Remove-AzureWebsite "OneSDKNotExisting" -Force) -eq $null }
}

<#
.SYNOPSIS
Tests Remove-AzureWebsite with WhatIf
#>
function Test-RemoveAzureServiceWithWhatIf
{
    # Setup
    $name = Get-WebsiteName
    New-AzureWebsite -Name $name

    # Test
    Remove-AzureWebsite -Name $name -Slot Production -Force -WhatIf
    Remove-AzureWebsite -Name $name -Slot Production -Force
    $global:createdWebsites.Clear()
    # Assert
    Assert-True { (Get-AzureWebsite -Name $name ) -eq $null }
}

########################################################################### Get-AzureWebsiteLog Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Get-AzureWebsiteLog with -Tail
#>
function Test-GetAzureWebsiteLogTail
{
    # Setup
    New-BasicLogWebsite
    $website = $global:currentWebsite
    $client = New-Object System.Net.WebClient
    $uri = "http://" + $website.HostNames[0]
    $client.BaseAddress = $uri
    $count = 0

    #Test
    Get-AzureWebsiteLog -Name $website.Name -Tail -Message "㯑䲘䄂㮉" | % {
        if ($_ -like "*㯑䲘䄂㮉*") { exit; }
        Retry-DownloadString $client $uri
        $count++
        if ($count -gt 50) { throw "Logs were not found"; }
    }
}

<#
.SYNOPSIS
Tests Get-AzureWebsiteLog with -Tail with special characters in uri.
#>
function Test-GetAzureWebsiteLogTailUriEncoding
{
    # Setup
    New-BasicLogWebsite
    $website = $global:currentWebsite
    $client = New-Object System.Net.WebClient
    $uri = "http://" + $website.HostNames[0]
    $client.BaseAddress = $uri
    $count = 0

    #Test
    Get-AzureWebsiteLog -Name $website.Name -Tail -Message "mes/a:q;" | % {
        if ($_ -like "*mes/a:q;*") { exit; }
        Retry-DownloadString $client $uri
        $count++
        if ($count -gt 50) { throw "Logs were not found"; }
    }
}

<#
.SYNOPSIS
Tests Get-AzureWebsiteLog with -Tail
#>
function Test-GetAzureWebsiteLogTailPath
{
    # Setup
    New-BasicLogWebsite
    $website = $global:currentWebsite
    $client = New-Object System.Net.WebClient
    $uri = "http://" + $website.HostNames[0]
    $client.BaseAddress = $uri
    Set-AzureWebsite -RequestTracingEnabled $true -HttpLoggingEnabled $true -DetailedErrorLoggingEnabled $true
    1..10 | % { Retry-DownloadString $client $uri }
    Wait-Seconds 30

    #Test
    $retry = $false
    do
    {
        try
        {
            Get-AzureWebsiteLog -Name $website.Name -Tail -Path http | % {
                if ($_ -like "*")
                {
                    exit
                }
                throw "HTTP path is not reached"
            }
        }
        catch
        {
            if ($_.Exception.Message -eq "One or more errors occurred.")
            {
                $retry = $true;
                Write-Warning "Retry Test-GetAzureWebsiteLogTailPath"
                continue;
            }

            throw $_.Exception
        }
    } while ($retry)
}

<#
.SYNOPSIS
Tests Get-AzureWebsiteLog with -ListPath
#>
function Test-GetAzureWebsiteLogListPath
{
    # Setup
    New-BasicLogWebsite

    #Test
    $retry = $false
    do
    {
        try
        {
            $actual = Get-AzureWebsiteLog -ListPath;
            $retry = $false
        }
        catch
        {
            if ($_.Exception.Message -like "For security reasons DTD is prohibited in this XML document.*")
            {
                $retry = $true;
                Write-Warning "Retry Test-GetAzureWebsiteLogListPath"
                continue;
            }
            throw $_.Exception
        }
    } while ($retry)

    # Assert
    Assert-AreEqual 1 $actual.Count
    Assert-AreEqual "Git" $actual
}

########################################################################### Get-AzureWebsite Scenario Tests ###########################################################################
<#
.SYNOPSIS
Test Kudu apps
#>
function Test-KuduAppsExpressApp
{
    Write-Debug "Starting Test Test-KuduappsExpressApp"
    $ok = Assert-Env @("GIT_USERNAME")
    $GIT_USERNAME = $env:GIT_USERNAME
    # Setup
    $siteName = Get-WebsiteName
    Mkdir $siteName
    cd $siteName
    
    # Test
    $command = "install -g express@3.4.8";
    Write-Debug "Running Start-Process npm $command -WAIT"
    Start-Process npm $command -WAIT

    express
    Write-Debug "Creating website $siteName"
    $webSite = New-AzureWebSite $siteName -Git –PublishingUsername $GIT_USERNAME
    Write-Debug "Created website"
    Write-Debug $webSite
    
    # Assert
    Assert-NotNull { $webSite } "Site $siteName created failed"
    Assert-Exists "..\$siteName\iisnode.yml"
}

<#
.SYNOPSIS
Tests Get-AzureWebsite
#>
function Test-GetAzureWebsite
{
    # Setup
    $name = Get-WebsiteName
    New-AzureWebsite $name

    #Test
    $config = Get-AzureWebsite -Name $name -Slot Production

    # Assert
    Assert-AreEqual $name $config.Name
}

<#
.SYNOPSIS
Tests GetAzureWebsite with a stopped site and expects to proceed.
#>
function Test-GetAzureWebsiteWithStoppedSite
{
    # Setup
    $name = Get-WebsiteName
    New-AzureWebsite $name
    Stop-AzureWebsite $name

    #Test
    $website = Get-AzureWebsite $name -Slot Production

    # Assert
    Assert-NotNull { $website }
}

########################################################################### Start-AzureWebsite Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Start-AzureWebsite happy path.
#>
function Test-StartAzureWebsite
{
    # Setup
    $name = Get-WebsiteName
    New-AzureWebsite $name
    Stop-AzureWebsite $name

    # Test
    Start-AzureWebsite $name

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-AreEqual "Running" $website.State
}

########################################################################### Stop-AzureWebsite Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Stop-AzureWebsite happy path.
#>
function Test-StopAzureWebsite
{
    # Setup
    $name = Get-WebsiteName
    New-AzureWebsite $name

    # Test
    Stop-AzureWebsite $name

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-AreEqual $name $website.Name
}

########################################################################### Restart-AzureWebsite Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Restart-AzureWebsite happy path.
#>
function Test-RestartAzureWebsite
{
    # Setup
    $name = Get-WebsiteName
    New-AzureWebsite $name

    # Test
    Restart-AzureWebsite $name

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-AreEqual "Running" $website.State
}

########################################################################### Enable-AzureWebsiteApplicationDiagnostic Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Enable-AzureWebsiteApplicationDiagnostic with storage table
#>
function Test-EnableApplicationDiagnosticOnTableStorage
{
    # Setup
    $name = Get-WebsiteName
    $storageName = $(Get-WebsiteName).ToLower()
    $defaultLocation = Get-StorageDefaultLocation
    New-AzureWebsite $name
    New-AzureStorageAccount -ServiceName $storageName -Location $defaultLocation
    
    # Test

    Enable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage -LogLevel Warning -StorageAccountName $storageName
    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-True { $website.AzureTableTraceEnabled }
    Assert-AreEqual Warning $website.AzureTableTraceLevel
    Assert-True { $website.AppSettings.ContainsKey("DIAGNOSTICS_AZURETABLESASURL") }

    # Cleanup
    Remove-AzureStorageAccount $storageName
}

<#
.SYNOPSIS
Tests Enable-AzureWebsiteApplicationDiagnostic with blob storage
#>
function Test-EnableApplicationDiagnosticOnBlobStorage
{
    # Setup
    $name = Get-WebsiteName
    $storageName = $(Get-WebsiteName).ToLower()
    $defaultLocation = Get-StorageDefaultLocation
    New-AzureWebsite $name
    New-AzureStorageAccount -ServiceName $storageName -Location $defaultLocation
    
    # Test

    Enable-AzureWebsiteApplicationDiagnostic -Name $name -BlobStorage -LogLevel Warning -StorageAccountName $storageName
    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-True { $website.AzureBlobTraceEnabled }
    Assert-AreEqual Warning $website.AzureBlobTraceLevel
    Assert-True { $website.AppSettings.ContainsKey("DIAGNOSTICS_AZUREBLOBCONTAINERSASURL") }

    # Cleanup
    Remove-AzureStorageAccount $storageName
}

<#
.SYNOPSIS
Tests Enable-AzureWebsiteApplicationDiagnostic with file system
#>
function Test-EnableApplicationDiagnosticOnFileSystem
{
    # Setup
    $name = Get-WebsiteName
    New-AzureWebsite $name

    # Test
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -File -LogLevel Warning

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-True { $website.AzureDriveTraceEnabled }
    Assert-AreEqual Warning $website.AzureDriveTraceLevel
}

<#
.SYNOPSIS
Tests Enable-AzureWebsiteApplicationDiagnostic when updating a log level and expects to pass.
#>
function Test-UpdateTheDiagnositicLogLevel
{
    # Setup
    $name = Get-WebsiteName
    New-AzureWebsite $name
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -File -LogLevel Verbose

    # Test
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -File -LogLevel Warning

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-True { $website.AzureDriveTraceEnabled }
    Assert-AreEqual Warning $website.AzureDriveTraceLevel
}

<#
.SYNOPSIS
Tests reconfiguring the table storage diagnostic settings information.
#>
function Test-ReconfigureStorageAppDiagnostics
{
    # Setup
    $name = Get-WebsiteName
    $storageName = $(Get-WebsiteName).ToLower()
    $newStorageName = $(Get-WebsiteName).ToLower()
    $defaultLocation = Get-StorageDefaultLocation
    New-AzureWebsite $name
    New-AzureStorageAccount -ServiceName $storageName -Location $defaultLocation
    New-AzureStorageAccount -ServiceName $newStorageName -Location $defaultLocation
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage -LogLevel Warning -StorageAccountName $storageName

    # Test
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage -LogLevel Verbose -StorageAccountName $newStorageName

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-True { $website.AzureTableTraceEnabled }
    Assert-AreEqual Verbose $website.AzureTableTraceLevel
    Assert-True { $website.AppSettings.ContainsKey("DIAGNOSTICS_AZURETABLESASURL") }

    # Cleanup
    Remove-AzureStorageAccount $storageName
}

<#
.SYNOPSIS
Tests Enable-AzureWebsiteApplicationDiagnostic with not existing storage service.
#>
function Test-ThrowsForInvalidStorageAccountName
{
    # Setup
    $name = Get-WebsiteName
    New-AzureWebsite $name
    
    # Test
    Assert-Throws { Enable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage -LogLevel Warning -StorageAccountName "notexsiting" }
}

########################################################################### Disable-AzureWebsiteApplicationDiagnostic Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Disable-AzureWebsiteApplicationDiagnostic with storage table
#>
function Test-DisableApplicationDiagnosticOnTableStorage
{
    # Setup
    $name = Get-WebsiteName
    $storageName = $(Get-WebsiteName).ToLower()
    $defaultLocation = Get-StorageDefaultLocation
    New-AzureWebsite $name
    New-AzureStorageAccount -ServiceName $storageName -Location $defaultLocation
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage -LogLevel Warning -StorageAccountName $storageName
    
    # Test
    Disable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-False { $website.AzureTableTraceEnabled }
    Assert-AreEqual Warning $website.AzureTableTraceLevel
    Assert-True { $website.AppSettings.ContainsKey("DIAGNOSTICS_AZURETABLESASURL") }

    # Cleanup
    Remove-AzureStorageAccount $storageName
}

<#
.SYNOPSIS
Tests Disable-AzureWebsiteApplicationDiagnostic with file system
#>
function Test-DisableApplicationDiagnosticOnFileSystem
{
    # Setup
    $name = Get-WebsiteName
    New-AzureWebsite $name
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -File -LogLevel Warning

    # Test
    Disable-AzureWebsiteApplicationDiagnostic -Name $name -File

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-False { $website.AzureDriveTraceEnabled }
    Assert-AreEqual Warning $website.AzureDriveTraceLevel
}

<#
.SYNOPSIS
Tests Disable-AzureWebsiteApplicationDiagnostic with storage and file
#>
function Test-DisableApplicationDiagnosticOnTableStorageAndFile
{
    # Setup
    $name = Get-WebsiteName
    $storageName = $(Get-WebsiteName).ToLower()
    $defaultLocation = Get-StorageDefaultLocation
    New-AzureWebsite $name
    New-AzureStorageAccount -ServiceName $storageName -Location $defaultLocation
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage -LogLevel Warning -StorageAccountName $storageName
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -File -LogLevel Warning
    
    # Test
    Disable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage -File

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-False { $website.AzureTableTraceEnabled }
    Assert-False { $website.AzureDriveTraceEnabled }
    Assert-True { $website.AppSettings.ContainsKey("DIAGNOSTICS_AZURETABLESASURL") }

    # Cleanup
    Remove-AzureStorageAccount $storageName
}

<#
.SYNOPSIS
Tests Disable-AzureWebsiteApplicationDiagnostic with file. Makes sure it disables file only.
#>
function Test-DisablesFileOnly
{
    # Setup
    $name = Get-WebsiteName
    $storageName = $(Get-WebsiteName).ToLower()
    $defaultLocation = Get-StorageDefaultLocation
    New-AzureWebsite $name
    New-AzureStorageAccount -ServiceName $storageName -Location $defaultLocation
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage -LogLevel Warning -StorageAccountName $storageName
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -File -LogLevel Verbose
    
    # Test
    Disable-AzureWebsiteApplicationDiagnostic -Name $name -File

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-True { $website.AzureTableTraceEnabled }
    Assert-False { $website.AzureDriveTraceEnabled }
    Assert-True { $website.AppSettings.ContainsKey("DIAGNOSTICS_AZURETABLESASURL") }

    # Cleanup
    Remove-AzureStorageAccount $storageName
}

<#
.SYNOPSIS
Tests Disable-AzureWebsiteApplicationDiagnostic with file. Makes sure it disables storage only.
#>
function Test-DisablesStorageOnly
{
    # Setup
    $name = Get-WebsiteName
    $storageName = $(Get-WebsiteName).ToLower()
    $defaultLocation = Get-StorageDefaultLocation
    New-AzureWebsite $name
    New-AzureStorageAccount -ServiceName $storageName -Location $defaultLocation
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -File -LogLevel Verbose
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage -LogLevel Warning -StorageAccountName $storageName
    
    # Test
    Disable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-True { $website.AzureDriveTraceEnabled }
    Assert-False { $website.AzureTableTraceEnabled }
    Assert-True { $website.AppSettings.ContainsKey("DIAGNOSTICS_AZURETABLESASURL") }

    # Cleanup
    Remove-AzureStorageAccount $storageName
}

<#
.SYNOPSIS
Tests Disable-AzureWebsiteApplicationDiagnostic with file. Makes sure it disables storage and table.
#>
function Test-DisablesBothByDefault
{
    # Setup
    $name = Get-WebsiteName
    $storageName = $(Get-WebsiteName).ToLower()
    $defaultLocation = Get-StorageDefaultLocation
    New-AzureWebsite $name
    New-AzureStorageAccount -ServiceName $storageName -Location $defaultLocation
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -TableStorage -LogLevel Warning -StorageAccountName $storageName
    Enable-AzureWebsiteApplicationDiagnostic -Name $name -File -LogLevel Verbose
    
    # Test
    Disable-AzureWebsiteApplicationDiagnostic -Name $name

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-False { $website.AzureTableTraceEnabled }
    Assert-False { $website.AzureDriveTraceEnabled }
    Assert-True { $website.AppSettings.ContainsKey("DIAGNOSTICS_AZURETABLESASURL") }

    # Cleanup
    Remove-AzureStorageAccount $storageName
}

########################################################################### Get-AzureWebsiteLocation Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Get-AzureWebsiteLocation and expects to return valid websites.
#>
function Test-GetAzureWebsiteLocation
{
    # Test
    $locations = Get-AzureWebsiteLocation;

    # Assert
    Assert-NotNull { $locations }
    Assert-True { $locations.Count -gt 0 }
}

<#
.SYNOPSIS
Test Get-AzureWebsite list none
#>
function Test-GetAzureWebSiteListNone
{
     Get-AzureWebsite | Remove-AzureWebsite –Force
     Assert-True { (Get-AzureWebsite) -eq $null}
}

<#
.SYNOPSIS
Tests Get-AzureWebsite list all
#>
function Test-AzureWebSiteListAll
{
    #Setup
    $name1 = Get-WebsiteName
    $name2 = Get-WebsiteName
    $name3 = Get-WebsiteName

    #Test
    New-AzureWebsite $name1
    New-AzureWebsite $name2
    New-AzureWebsite $name3

    $name = (Get-AzureWebsite).Name
    Assert-True {$name.Contains($name1)}
    Assert-True {$name.Contains($name2)}
    Assert-True {$name.Contains($name3)}
}

<#
.SYNOPSIS
Test Get-AzureWebsite show single site
#>
function Test-AzureWebSiteShowSingleSite
{
    # Setup
    $name1 = Get-WebsiteName
    $name2 = Get-WebsiteName
    $name3 = Get-WebsiteName

    #Test
    New-AzureWebsite $name1
    New-AzureWebsite $name2
    New-AzureWebsite $name3
    Assert-True { (Get-AzureWebsite $name1 -Slot Production).Name -eq  $name1 }	
    Assert-True { (Get-AzureWebsite $name2 -Slot Production).Name -eq  $name2 }	
    Assert-True { (Get-AzureWebsite $name3 -Slot Production).Name -eq  $name3 }	
    
    # Cleanup
    Remove-AzureWebsite $name1 -Slot Production -Force
    Remove-AzureWebsite $name2 -Slot Production -Force
    Remove-AzureWebsite $name3 -Slot Production -Force
} 

########################################################################### Azurewebsite Git Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests New azure web site with git hub.
#>
function Test-NewAzureWebSiteMultipleCreds
{
    $ok = Assert-Env @("GIT_USERNAME", "GIT_PASSWORD")

    $GIT_USERNAME = $env:GIT_USERNAME
    $GIT_PASSWORD = $env:GIT_PASSWORD

    # Setup
    $siteName = Get-WebsiteName
    Set-Location "\"
    mkdir $siteName
    Set-Location $siteName
    
    # Test
    New-AzureWebsite $siteName -Git -PublishingUsername $GIT_USERNAME
    $webSite = Get-AzureWebsite -Name $siteName -Slot Production
    
    # Verify publishingusername & publishingpassword in git remote
    $webSite = Get-AzureWebsite -Name $siteName -Slot Production
    $gitRemoteList = git remote -v
    $expectedRemoteUri = "https://" + $GIT_USERNAME + "@" + $webSite.EnabledHostNames[1] + "/" + $webSite.Name + ".git"
    Assert-True { $gitRemoteList[0].Contains($expectedRemoteUri)}

    # Install express
    Npm-InstallExpress

    # Push local git to website
    Git-PushLocalGitToWebSite $siteName
    
    # Verify browse website
    $siteStatusRunning = Retry-Function { return (Get-AzureWebsite -Name $siteName -Slot Production).State -eq "Running" } $null 4 1
    $deploymentStatusSuccess = Retry-Function { return (Get-AzureWebSiteDeployment $siteName).Status.ToString() -eq "Success" } $null 8 2
    if (($siteStatusRunning -eq $true) -and ($deploymentStatusSuccess -eq $true))
    {
        $url = "http://" + $webSite.EnabledHostNames[0]
        $expectedString = "Welcome to Express"
        Assert-True { Test-ValidateResultInBrowser ($url) $expectedString }
    }
    else
    {
        throw "Web site or git repository is not ready for browse"
    }
}

<#
.SYNOPSIS
Tests New azure web site with github.
#>
function Test-NewAzureWebSiteGitHubAllParms
{
    $ok = Assert-Env @("GITHUB_USERNAME", "GITHUB_PASSWORD")

    $GitHub_USERNAME = $env:GITHUB_USERNAME
    $GitHub_PASSWORD = $env:GITHUB_PASSWORD
    $GitHub_REPO = $env:GITHUB_USERNAME + "/WebChatDefault-0802"
    
    # Setup
    $siteName = Get-WebsiteName
    Set-Location "\"
    mkdir $siteName
    Set-Location $siteName

    # Test
    $myCreds = New-Object "System.Management.Automation.PSCredential" ($GitHub_USERNAME, (ConvertTo-SecureString $GitHub_PASSWORD -AsPlainText -Force))
    $webSite = New-AzureWebsite $siteName -Location (Get-AzureWebsiteLocation)[0] -GitHub -GithubRepository $GitHub_REPO -GithubCredentials $myCreds

    $siteStatusRunning = Retry-Function { (Get-AzureWebsite -Name $siteName -Slot Production).State -eq "Running" } $null 4 2
    $deploymentStatusSuccess = Retry-Function { (Get-AzureWebSiteDeployment $siteName).Status.ToString() -eq "Success" } $null 8 3
    if (($siteStatusRunning -eq $true) -and ($deploymentStatusSuccess -eq $true))
    {
        Assert-True { Test-ValidateResultInBrowser ("http://" + $WebSite.HostNames[0]) "0.8.3" }
    }
    else
    {
        throw "Web site or git repository is not ready for browse"
    }
    
}

<#
.SYNOPSIS
Test New azure web site then update git deployment
#>
function Test-NewAzureWebSiteUpdateGit
{
    $ok = Assert-Env @("GIT_USERNAME", "GIT_PASSWORD")
    $GIT_USERNAME = $env:GIT_USERNAME
    $GIT_PASSWORD = $env:GIT_PASSWORD

    # Setup
    $siteName = Get-WebsiteName
    mkdir $siteName
    Set-Location $siteName

    # Test
    New-AzureWebSite $siteName
    # Set the ErrorActionPreference as "SilentlyContinue" to work around "The website already exist" exception
    $oldErrorActionPreferenceValue = $ErrorActionPreference
    $ErrorActionPreference = "SilentlyContinue"
    # Install express
    Npm-InstallExpress

    New-AzureWebSite $siteName -Git -Publishingusername:$GIT_USERNAME
    $ErrorActionPreference = $oldErrorActionPreferenceValue

    # Verify publishingusername & publishingpassword in git remote
    $webSite = Get-AzureWebsite -Name $siteName -Slot Production
    $gitRemoteList = git remote -v
    $expectedRemoteUri = "https://" + $GIT_USERNAME + "@" + $webSite.EnabledHostNames[1] + "/" + $webSite.Name + ".git"
    Assert-True { $gitRemoteList[0].Contains($expectedRemoteUri)} "failed to validate website app after deployment"


    # Push local git to website
    Git-PushLocalGitToWebSite $siteName

    # Verify browse website
    $siteStatusRunning = Retry-Function { return (Get-AzureWebsite -Name $siteName -Slot Production).State -eq "Running" } $null 4 1
    $deploymentStatusSuccess = Retry-Function { return (Get-AzureWebSiteDeployment $siteName).Status.ToString() -eq "Success" } $null 8 2
    if (($siteStatusRunning -eq $true) -and ($deploymentStatusSuccess -eq $true))
    {
        $url = "http://" + $webSite.EnabledHostNames[0]
        $expectedString = "Welcome to Express"
        Assert-True { Test-ValidateResultInBrowser ($url) $expectedString }
    }
    else
    {
        throw "Web site or git repository is not ready for browse"
    }
}

########################################################################### Set-AzureWebsite Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Set-AzureWebsite cmdlet
#>
function Test-SetAzureWebsite
{
    # Setup
    $name = Get-WebsiteName
	$remotedebuggingversion = "VS2015"
    New-AzureWebsite $name

    # Test
    Set-AzureWebsite $name -Slot Production -ManagedPipelineMode Classic
    Set-AzureWebsite $name -Slot Production -WebSocketsEnabled $true

    # Assert
    $website = Get-AzureWebsite $name -Slot Production
    Assert-AreEqual Classic $website.ManagedPipelineMode
    Assert-AreEqual $true $website.WebSocketsEnabled

    $website.RemoteDebuggingEnabled = $true
    $website.RemoteDebuggingVersion = $remotedebuggingversion
    Set-AzureWebsite $name -Slot Production -SiteWithConfig $website

    Assert-AreEqual $true $website.RemoteDebuggingEnabled
    Assert-AreEqual $remotedebuggingversion $website.RemoteDebuggingVersion
}

########################################################################### Test-StartAzureWebsiteTriggeredJob Scenario Tests ###########################################################################
<#
.SYNOPSIS 
Tests Start AzureWebsiteJob cmdlet using "triggered" job type
#>
function Test-StartAzureWebsiteTriggeredJob
{
    $ok = Assert-Env @("WEBJOB_FILE")
    $webSiteName = Get-WebsiteName
    $webSiteJobName = Get-WebsiteJobName
    $jobType = "Triggered"

    # Setup
    New-AzureWebsite $webSiteName
    New-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -JobType $jobType -JobFile $env:WEBJOB_FILE

    # Test
    $started = Start-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -JobType $jobType -PassThru

    #Assert 
    Assert-True{ $started }    
}

########################################################################### Test-StartAndStopAzureWebsiteContinuousJob Scenario Tests ###########################################################################
<#
.SYNOPSIS 
Tests Start and stop AzureWebsiteJob cmdlet using "Continuous" job type
#>
function Test-StartAndStopAzureWebsiteContinuousJob
{
    $ok = Assert-Env @("WEBJOB_FILE")
    $webSiteName = Get-WebsiteName
    $webSiteJobName = Get-WebsiteJobName
    $jobType = "Continuous"
    # Setup
    New-AzureWebsite $webSiteName
    New-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -JobType $jobType -JobFile $env:WEBJOB_FILE

    # Make sure the job is initialized by polling the status 
    $waitScriptBlock = { (Get-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -JobType $jobType)[0].Status }
    Wait-Function $waitScriptBlock "PendingRestart"

    # Test

    # First, test 'Stop'
    $stopped = Stop-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -PassThru

    # Assert
    Assert-True{ $stopped }
    $jobStatus = Get-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -JobType $jobType
    Assert-True { $jobStatus[0].Status -eq "Stopped" }

    # Then, test 'Start'
    $started = Start-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -JobType $jobType -PassThru

    #Assert
    Assert-True{ $started }
    $jobStatus = Get-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName -JobType $jobType
    Assert-True { $jobStatus[0].Status -eq "PendingRestart" }

    # Clean up
    Stop-AzureWebsiteJob -Name $webSiteName -JobName $webSiteJobName 
}


########################################################################### Test-RemoveAzureWebsiteJob Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Remove-AzureWebsiteJob cmdlet using 'Triggered' job type 
#>
function Test-RemoveAzureWebsiteTriggeredJob
{
    $ok = Assert-Env @("WEBJOB_FILE")
    $webSiteName = Get-WebsiteName
    $webSiteJobName = Get-WebsiteJobName
        
    # Setup
    New-AzureWebsite $webSiteName
    
    # Test
    Test-CreateAndRemoveAJob $webSiteName $webSiteJobName Triggered $env:WEBJOB_FILE
    
}

<#
.SYNOPSIS
Tests Remove-AzureWebsiteJob cmdlet using 'Continuous' job type 
#>
function Test-RemoveAzureWebsiteContinuousJob
{
    $ok = Assert-Env @("WEBJOB_FILE")
    $webSiteName = Get-WebsiteName
    $webSiteJobName = Get-WebsiteJobName
    
    # Setup
    New-AzureWebsite $webSiteName
    
    # Test
    Test-CreateAndRemoveAJob $webSiteName $webSiteJobName Continuous $env:WEBJOB_FILE
    
}

<#
.SYNOPSIS
Tests Remove-AzureWebsiteJob cmdlet using a job which doesn't exist
#>
function Test-RemoveNonExistingAzureWebsiteJob
{
    $webSiteName = Get-WebsiteName
    $nonExistingWebSiteJobName = Get-WebsiteJobName
    
    # Setup
    New-AzureWebsite $webSiteName
    
    # Test
    Remove-AzureWebsiteJob -Name $webSiteName -JobName $nonExistingWebSiteJobName -JobType Triggered –Force   

    Assert-True { $true }
}

########################################################################### Get-AzureWebsiteJob Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Get-AzureWebsiteJob cmdlet ability to get all webjob for a given website
#>
function Test-GettingWebsiteJobs
{
    $ok = Assert-Env @("WEBJOB_FILE")
    $webSiteName = Get-WebsiteName
    $location = Get-WebsiteDefaultLocation "North Central US"
    $job1 = Get-WebsiteJobName
    $job2 = Get-WebsiteJobName
    $job3 = Get-WebsiteJobName
    $job4 = Get-WebsiteJobName
        
    # Setup
    New-AzureWebsite $webSiteName -Location $location 
    New-AzureWebsiteJob -Name $webSiteName -JobName $job1 -JobType Triggered -JobFile $env:WEBJOB_FILE
    New-AzureWebsiteJob -Name $webSiteName -JobName $job2 -JobType Triggered -JobFile $env:WEBJOB_FILE
    New-AzureWebsiteJob -Name $webSiteName -JobName $job3 -JobType Continuous -JobFile $env:WEBJOB_FILE
    New-AzureWebsiteJob -Name $webSiteName -JobName $job4 -JobType Triggered -JobFile $env:WEBJOB_FILE

    # Test gets all web jobs
    $webjobs = Get-AzureWebsiteJob -Name $webSiteName
    
    Assert-AreEqual 4 $webjobs.Count

    # Test gets only triggered
    $webjobs = Get-AzureWebsiteJob -Name $webSiteName -JobType Triggered
    
    Assert-AreEqual 3 $webjobs.Count

    # Test gets specific job
    $webjob = Get-AzureWebsiteJob -Name $webSiteName -JobType Triggered -JobName $job1
    
    Assert-AreEqual $job1 $webjob.JobName

    # Test throws exception with non-existing job
    Assert-Throws { Get-AzureWebsiteJob -Name $webSiteName -JobType Triggered -JobName "foo" } "Not Found"

    Assert-True { $true }
}

########################################################################### Get-AzureWebsiteJobHistory Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Get-AzureWebsiteJobHistory functionality
#>
function Test-GettingJobHistory
{
    $ok = Assert-Env @("WEBJOB_FILE")
    $webSiteName = Get-WebsiteName
    $jobName = Get-WebsiteJobName
        
    # Setup
    New-AzureWebsite $webSiteName
    New-AzureWebsiteJob -Name $webSiteName -JobName $jobName -JobType Triggered -JobFile $env:WEBJOB_FILE

    # Test getting null run will work
    $run = Get-AzureWebsiteJobHistory -Name $webSiteName -JobName $jobName -Latest
    
    Assert-Null $run

    # Setup
    Start-AzureWebsiteJob -Name $webSiteName -JobName $jobName -JobType Triggered
    Start-AzureWebsiteJob -Name $webSiteName -JobName $jobName -JobType Triggered
    
    # Test getting latest run will work
    $run = Get-AzureWebsiteJobHistory -Name $webSiteName -JobName $jobName -Latest
    $webjob = Get-AzureWebsiteJob -Name $webSiteName -JobName $jobName -JobType Triggered
    
    Assert-AreEqual $webjob.LatestRun.Id $run.Id

    # Setup
    Start-AzureWebsiteJob -Name $webSiteName -JobName $jobName -JobType Triggered
    Start-AzureWebsiteJob -Name $webSiteName -JobName $jobName -JobType Triggered
    $runId = $webjob.LatestRun.Id

    # Test getting specific run will work
    $run = Get-AzureWebsiteJobHistory -Name $webSiteName -JobName $jobName -RunId $runId
    
    Assert-AreEqual $runId $run.Id

    # Test listing complete history works
    $runs = Get-AzureWebsiteJobHistory -Name $webSiteName -JobName $jobName
    
    Assert-AreEqual 4 $runs.Count
}
