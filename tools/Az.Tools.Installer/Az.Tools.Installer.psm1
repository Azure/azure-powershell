# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.internal
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------
using namespace System
using namespace System.Collections.Generic
using namespace System.IO
using namespace System.IO.Compression
using namespace System.Management.Automation
using namespace System.Net
using namespace System.Net.Http
using namespace System.Threading.Tasks

Microsoft.PowerShell.Core\Set-StrictMode -Version 3

$script:AzTempRepoName = 'AzTempRepo'
$script:CurrentMinAzToolsInstallerVersion = '0.0.0.0'
$script:ExpectedModuleCompanyName = 'azure-sdk'
$script:MaxModulesToFindIndividually = 3
$script:ParallelDownloaderClassCode = @"
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class ParallelDownloader
{
    private readonly HttpClient Client;
    private readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

    public ParallelDownloader(HttpClient client)
    {
        Client = client;
    }

    public async Task DownloadToFile(string uri, string filePath)
    {
        using (var httpResponseMessage = await Client.GetAsync(uri, CancellationTokenSource.Token))
        using (var stream = await httpResponseMessage.EnsureSuccessStatusCode().Content.ReadAsStreamAsync())
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await stream.CopyToAsync(fileStream, 81920, CancellationTokenSource.Token);
        }
    }

    public void Cancel()
    {
        CancellationTokenSource.Cancel();
    }
}
"@

Add-Type $script:ParallelDownloaderClassCode -ReferencedAssemblies System.Net.Http,System.Threading.Tasks

function Test-Class {
    param ()

    process {
        [ParallelDownloaderClassCode] | Get-Member
    }
}

[ParallelDownloader] | Get-Member

$getModule = Get-Module -Name "PowerShellGet"
if ($null -ne $getModule -and $getModule.Version -lt [System.Version]"2.1.3") { 
    Write-Error "This module requires PowerShellGet version 2.1.3. An earlier version of PowerShellGet is imported in the current PowerShell session. Please open a new session before importing this module." -ErrorAction Stop 
} 
elseif ($null -eq $getModule) { 
    Import-Module PowerShellGet -MinimumVersion 2.1.3 -Scope Global 
}

$exportedFunctions = @( Get-ChildItem -Path $PSScriptRoot/exports/*.ps1 -Recurse -ErrorAction SilentlyContinue )
$internalFunctions = @( Get-ChildItem -Path $PSScriptRoot/internal/*.ps1 -ErrorAction SilentlyContinue )

$allFunctions = $exportedFunctions + $internalFunctions
foreach($function in $allFunctions) {
    try {
        . $function.Fullname
    }
    catch {
        Write-Error -Message "Failed to import function $($function.fullname): $_"
    }
}
Export-ModuleMember -Function $exportedFunctions.Basename

$commandsWithRepositoryParameter = @(
    "Install-AzModule",
    "Uninstall-AzModule"
)

Add-RepositoryArgumentCompleter -Cmdlets $commandsWithRepositoryParameter -ParameterName "Repository"

function Get-AllAzModule {
    param (
        [Parameter()]
        [Switch]
        ${PrereleaseOnly}
    )

    process {
        $allmodules = Microsoft.PowerShell.Core\Get-Module -ListAvailable -Name Az*,Az | Where-Object {
            !$PrereleaseOnly -or ($_.PrivateData -and $_.PrivateData.ContainsKey('PSData') -and $_.PrivateData.PSData.ContainsKey('PreRelease') -and $_.PrivateData.PSData.Prerelease -eq 'preview')
        }
        $allmodules
    }
}

function Normalize-ModuleName {
    param (
        [Parameter()]
        [string[]]
        ${Name}      
    )

    process {
        $normalName = $Name | ForEach-Object {
            if ($_) {
                if ($_ -notlike "Az.*") {
                    "Az.$_"
                }
                else {
                    $_
                }
            }
        } | Sort-Object -Unique

        if ($normalName -and $normalName -notmatch "Az(\.[a-zA-Z0-9]+)?$") {
            $normalName = $null
            throw "The Name parameter must only contain Az modules."
        }

        if ($normalName -eq 'Az.Az') {
            $normalName = $normalName | Where-Object { $_ -ne 'Az.Az'}
            Write-Warning "Az.Tools.Installer cannot be used to install Az. Will discard Az in the Name parameter."
        } 
        
        $normalName
    }
}

function Get-AzModuleFromRemote {
    param (
        [Parameter()]
        [string[]]
        ${Name},

        [Parameter()]
        [string]
        ${Repository},

        [Parameter()]
        [Switch]
        ${AllowPrerelease},

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [Version]
        ${RequiredVersion},

        [Parameter()]
        [Switch]
        ${UseExactAccountVersion}
    )

    process {
        $findModuleParams = @{
            Name = if ($AllowPrerelease) {'AzPreview'} else {'Az'} 
            Repository = $Repository
            RequiredVersion = $RequiredVersion
        }

        $modules = PowerShellGet\Find-Module @findModuleParams

        Write-Debug 'Get-AzModuleFromRemote'

        $accountVersion = 0
        if (!$UseExactAccountVersion) {
            $findModuleParams = @{
                Name = 'Az.Accounts'
                Repository = $Repository
            }
            $module = PowerShellGet\Find-Module @findModuleParams
            $accountVersion = [Version] $module.Version
        }

        $modulesWithVersion = @()
        $containValidModule = if ($Name) {$Name.Contains('Az.Accounts')} else {$false}
        foreach($module in $modules.Dependencies) {
            if ($module.Name -eq 'Az.Accounts') {
                if ($UseExactAccountVersion) {
                    $modulesWithVersion += [PSCustomObject]@{Name = $module.Name; Version = $module.MinimumVersion}
                }
                else {
                    $modulesWithVersion += [PSCustomObject]@{Name = $module.Name; Version = $accountVersion}
                }
            }
            elseif (!$Name -or $Name.Contains($module.Name))
            {
                if ($module.RequiredVersion) {
                    $modulesWithVersion += [PSCustomObject]@{Name = $module.Name; Version = $module.RequiredVersion}
                    $containValidModule = $true
                }
            }
        }

        Write-Debug "Get-AzModuleFromRemote: find$($modulesWithVersion.Length)"

        if (!$containValidModule -and !$Name) {
            @()
        }
        else {
            $modulesWithVersion
        }
    }
}

function Uninstall-AzureRM {
    process {
        try {
            $azureModuleNames = (Get-InstalledModule -Name Azure* -ErrorAction Stop).Name | Where-Object {$_ -match "Azure(\.[a-zA-Z0-9]+)?$" -or $_ -match "AzureRM(\.[a-zA-Z0-9]+)?$"}
            foreach($module in $azureModuleNames) {
                Uninstall-Module -Name $azureModuleName -AllVersion -ErrorAction SilentlyContinue
            }
        }
        catch {
            Write-Warning $_
        }   
    }
}

function Uninstall-Az {
    param (
        [Parameter()]
        [Switch]
        ${AzOnly}
    )
    
    process {
        try {
            if (!$AzOnly) {
                $azModuleNames = (Get-InstalledModule -Name Az.* -ErrorAction Stop).Name | Where-Object {$_ -match "Az(\.[a-zA-Z0-9]+)?$"}
                foreach($module in $azModuleNames) {
                    Uninstall-Module -Name $module -AllVersion -ErrorAction SilentlyContinue
                }
            }
            Uninstall-Module -Name 'Az' -AllVersion -ErrorAction SilentlyContinue
        }
        catch {
            Write-Warning $_
        }   
    }
}

class PSParallelDownloader
{
    [ParallelDownloader] hidden $ppDownloader = $null
    [HttpClient] hidden $psHttpClient = $null
    [HttpClientHandler] hidden $psHttpClientHandler = $null
    [List[PSCustomObject]] hidden $tasks = @()
    [string] $url = ""

    PSParallelDownloader([string]$repository) {
        #Add-Type $script:ParallelDownloaderClassCode -ReferencedAssemblies System.Net.Http,System.Threading.Tasks

        $this.psHttpClientHandler = [HttpClientHandler]::new()
        $this.psHttpClient = [HttpClient]::new($this.psHttpClientHandler)
        this.$ppDownloader = [ParallelDownloader]::new($this.psHttpClient)
        $this.url = (Get-PSRepository -Name $repository).SourceLocation

        #Test-Class
    }

    [PSCustomObject] Download([string]$module, [version]$version, [string]$path) {
        Write-Host "[$($MyInvocation.MyCommand)] Downloading module $module version $version to $path"
        $this.url
        [string]$nupkgFilePath = Join-Path $path "$module.$($version).nupkg"
        $task = [PSCustomObject]@{
            Task       = $this.ppDownloader.DownloadToFile("$($this.url)/package/$module/$version", $nupkgFilePath)
            ModuleName = $module
            Path       = $nupkgFilePath
        }
        $this.tasks += $task
        return $task
    }
    
    [void] WaitForAllTasks() {
        while ($this.tasks) {
            [int]$taskIndex = [Task]::WaitAny($this.tasks.Task)
            Write-Host "[$($MyInvocation.MyCommand)] wait for task $taskIndex."
            [PSObject]$task = $this.tasks[$taskIndex]
            $this.tasks.RemoveAt($taskIndex)
            if (!$task.Task.IsCompleted) {
                throw "Error downloading $($task.ModuleName): $($task.Task.Exception)"
            }
        }
    }
    
    [void] Dispose() {
        if ($this.tasks) {
            Write-Host "[$($MyInvocation.MyCommand)] Cancelling $($this.tasks.Count) tasks"
            $this.ppDownloader.Cancel()
            try {
                [Task]::WaitAll($this.tasks.Task)
            } catch {

            }
        }

        if ($this.psHttpClient) {
            $this.psHttpClient.Dispose()
        }
        if ($this.psHttpClientHandler) {
            $this.psHttpClientHandler.Dispose()
        }
    }
}


<#--------------------------------------------------------------#>

function Test-Downloader {
    param (
    )
    
    process {
        $tempRepo = Join-Path 'D:/PSLocalRepo/' (Get-Date -Format "yyyyddMM-HHmm")
        $null = Microsoft.PowerShell.Management\New-Item -ItemType Directory -Path $tempRepo -WhatIf:$false

        $downloader = [PSParallelDownloader]::new("PSGallery")
        $downloader
        try
        {
            $null = $downloader.Download('Az.Storage', '3.11.0', $tempRepo)
            $downloader.WaitForAllTasks()
            $downloader
        }
        finally
        {
            $downloader.Dispose()
        }
        $downloader
    }
}
