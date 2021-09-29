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
using namespace System.Linq
using namespace System.Management.Automation
using namespace System.Net

using namespace System.Net.Http
using namespace System.Threading
using namespace System.Threading.Tasks

Microsoft.PowerShell.Core\Set-StrictMode -Version 3

$script:AzTempRepoName = 'AzTempRepo'
$script:CurrentMinAzToolsInstallerVersion = '0.0.0.0'
$script:ParallelDownloaderClassCode = @"
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class ParallelDownloader
{
    private HttpClientHandler httpClientHandler = new HttpClientHandler();
    private HttpClient client = null;
    private string urlRepository = null;
    private readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

    IList<Task> tasks;
    IList<string> modules;

    public ParallelDownloader(string url)
    {
        client = new HttpClient(httpClientHandler);
        this.urlRepository = url;
        tasks = new List<Task>();
        modules = new List<string>();
    }

    private async Task DownloadToFile(string uri, string filePath)
    {
        using (var httpResponseMessage = await client.GetAsync(uri, CancellationTokenSource.Token))
        using (var stream = await httpResponseMessage.EnsureSuccessStatusCode().Content.ReadAsStreamAsync())
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await stream.CopyToAsync(fileStream, 81920, CancellationTokenSource.Token);
        }
    }

    public void Download(string module, Version version, string path)
    {
        var nupkgFile = Path.Combine(path, String.Format("{0}.{1}.nupkg", module, version));
        Task task = DownloadToFile(String.Format("{0}/package/{1}/{2}", urlRepository, module, version), nupkgFile.ToString());
        tasks.Add(task);
        modules.Add(module);
    }

    public void WaitForAllTasks()
    {
        while (tasks.Count() > 0)
        {
            int taskIndex = Task.WaitAny(tasks.ToArray());
            var task = tasks[taskIndex];
            tasks.Remove(task);
            modules.Remove(modules[taskIndex]);
            if (!task.IsCompleted)
            {
                throw new Exception(String.Format("Error downloading {0} {1}", modules[taskIndex], task.Exception));
            }
        }
    }

    public void Dispose()
    {
        if (tasks.Count() > 0)
        {
            CancellationTokenSource.Cancel();
            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch
            {

            }
        }

        if (client != null)
        {
            client.Dispose();
        }

        if (httpClientHandler != null)
        {
            httpClientHandler.Dispose();
        }
    }
}
"@

Write-Warning "Start to add type of ParallelDownloaderClassCode"
Add-Type -AssemblyName System.Net.Http -ErrorAction Stop
Add-Type $script:ParallelDownloaderClassCode -ReferencedAssemblies System.Net.Http,System.Threading.Tasks,System.Linq,System.Collections,System.Runtime.Extensions
Write-Warning "Add-Type finished."

$getModule = Get-Module -Name "PowerShellGet"
if ($null -ne $getModule -and $getModule.Version -lt [System.Version]"2.1.3") { 
    Write-Error "This module requires PowerShellGet version 2.1.3. An earlier version of PowerShellGet is imported in the current PowerShell session. Please open a new session before importing this module." -ErrorAction Stop 
} 
elseif ($null -eq $getModule) { 
    Import-Module PowerShellGet -MinimumVersion 2.1.3 -Scope Global 
}

function Get-AllAzModule {
    param (
        [Parameter()]
        [Switch]
        ${PrereleaseOnly}
    )

    process {
        $allmodules = Microsoft.PowerShell.Core\Get-Module -ListAvailable -Name Az*, Az `
         | Where-Object {$_.Name -match "Az(\.[a-zA-Z0-9]+)?$"} `
         | Where-Object {
            !$PrereleaseOnly -or ($_.PrivateData -and $_.PrivateData.ContainsKey('PSData') -and $_.PrivateData.PSData.ContainsKey('PreRelease') -and $_.PrivateData.PSData.Prerelease -eq 'preview') -or ($_.Version -lt [Version] "1.0")
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

function Get-ReferencePath {
    [OutputType([string[]])]
    param()
    process {
        $allAzModules = @()
        $allAzModules += Get-Module -ListAvailable | Where-Object {$_ -match "Az(\.[a-zA-Z0-9]+)?$"}
        $pathList = $null
        if ($allAzModules) {
            $pathList = $allAzModules.Path -split 'Az.' | Sort-Object -Property Length -Descending | Select-Object -First $allAzModules.Count | Select-Object -Unique
            $isAdmin = [Security.Principal.WindowsIdentity]::GetCurrent().Groups -Contains 'S-1-5-32-544'
            if (!$isAdmin) {
                $pathList = $pathList | Where-Object {$_.Contains($env:UserName)}
            }
        }
        Write-Output $pathList
    }
}

function Get-AzModuleFromRemote {
    [OutputType([PSCustomObject[]])]
    param (
        [Parameter()]
        [string[]]
        ${Name},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository},

        [Parameter()]
        [Switch]
        ${AllowPrerelease},

        [Parameter()]
        [Version]
        ${RequiredVersion},

        [Parameter()]
        [Switch]
        ${UseExactAccountVersion},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Invoker}
    )

    process {
        $azModule = "Az"
        if ($AllowPrerelease) {
            if ($RequiredVersion -and $RequiredVersion -lt [Version] "6.0") {
                write-warning "[$Invoker] Prerelease version cannot be lower than 6.0. Will only install GA modules."
            }
            else {
                $azModule = "AzPreview"
            }
        }
        $findModuleParams = @{
            Name =  $azModule
            Repository = $Repository
            RequiredVersion = $RequiredVersion
            ErrorAction = 'Stop'
        }

        $modules = PowerShellGet\Find-Module @findModuleParams

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
        $containValidModule = if ($Name) {$Name -Contains 'Az.Accounts'} else {$false}
        foreach($module in $modules.Dependencies) {
            if ($module.Name -eq 'Az.Accounts') {
                if ($UseExactAccountVersion) {
                    $version = $accountVersion
                    if ($module.Keys -Contains 'MinimumVersion') {
                        $version = $module.MinimumVersion
                    }
                    elseif ($module.Keys -Contains 'RequiredVersion') {
                        $version = $module.RequiredVersion
                    }
                    $modulesWithVersion += [PSCustomObject]@{Name = $module.Name; Version = $version}
                }
                else {
                    $modulesWithVersion += [PSCustomObject]@{Name = $module.Name; Version = $accountVersion}
                }
            }
            elseif (!$Name -or $Name -Contains $module.Name)
            {
                if ($module.RequiredVersion) {
                    $modulesWithVersion += [PSCustomObject]@{Name = $module.Name; Version = $module.RequiredVersion}
                    $containValidModule = $true
                }
            }
        }

        if (!$containValidModule) {
            $modulesWithVersion = $modulesWithVersion | Where-Object {$_.Name -ne "Az.Accounts"}
        }
        $count = if ($modulesWithVersion) {$modulesWithVersion.Count} else {0}
        Write-Debug "[$Invoker] $count module(s) are found."
        $modulesWithVersion
    }
}

Write-Warning "Start to add type of ModuleInfo"
class ModuleInfo
{
    [string] $Name = $null
    [Version[]] $Version = @()
}

<#
function Invoke-ThreadJob {
    [CmdletBinding(SupportsShouldProcess)]
    param (
        [Parameter(Mandatory)]
        [ModuleInfo[]]
        ${ModuleList},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [ScriptBlock]
        ${Snippet},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Operation},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${JobName},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Invoker}
    )

    process {
        #Write-Debug ($PSBoundParameters | Out-String)
        try
        {
            $jobs = @()
            $module = $null
            foreach ($module in $ModuleList) {
                if ($PSCmdlet.ShouldProcess("$Operation module $($module.Name) version $($module.Version)", "$($module.Name) version $($module.Version)", $Operation)) {
                    $jobs  += Start-ThreadJob -Name $JobName -ScriptBlock $Snippet -ArgumentList $module -ThrottleLimit 5
                    #-StreamingHost $Host
                }
            }
    
            if (!$WhatIfPreference) {
                $result = $null
                $job = $null
                foreach ($job in $jobs) {
                    $job = Wait-Job $job
                    $result = Receive-Job $job
                    if ($job.State -eq 'Completed') {
                        Write-Debug  "[$Invoker] $Operation $result is completed"
                    }
                    else {
                        Write-Warning  "[$Invoker] $Operation $result is failed"
                    }
                    Remove-Job $job -Confirm:$false
                }
            }
        }
        finally
        {
            $jobs = Get-Job -Name $JobName -ErrorAction 'SilentlyContinue'
            if ($jobs) {
                Stop-Job $jobs
                Remove-Job $jobs -Confirm:$false
            }
        }
    }
}
#>
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

function Uninstall-SingleModule {
    param (
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${ModuleName},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string[]]
        ${ReferencePath},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Invoker}
    )

    process {
        try {
            foreach ($path in $ReferencePath){
                $path = Join-Path $path $moduleName
                if (Test-Path -Path $path) {
                    $subFolder = Get-ChildItem $path
                    $version = $null
                    if ($subFolder) {
                        $version = $subFolder.Name
                    }
                    Microsoft.PowerShell.Management\Remove-Item -Path $path -Recurse -Force -WhatIf:$false
                    Write-Debug "[$Invoker] Uninstalling $ModuleName version $version is completed."
                }
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
        ${AzOnly},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Invoker}
    )
    
    process {
        try {
            if (!$AzOnly) {
                $azModuleNames = Get-Module -ListAvailable -Name Az.* | Where-Object {$_.Name -match "Az(\.[a-zA-Z0-9]+)?$"}
                $module = $null
                foreach ($module in $azModuleNames) {
                    $referencePath = $module.Path -Split $module.Name | Sort-Object -Property Length -Descending | Select-Object -First 1
                    Uninstall-SingleModule -ModuleName $module.Name -ReferencePath $referencePath -Invoker $Invoker
                }
            }
            Uninstall-Module -Name 'Az' -AllVersion -ErrorAction SilentlyContinue
        }
        catch {
            Write-Warning $_
        }   
    }
}

function Get-RepositoryUrl {
    param (
        [Parameter()]
        [string]
        ${Repository}
    )

    process {
        $url = (Get-PSRepository -Name $repository).SourceLocation
        $url
    }
}

$exportedFunctions = @( Get-ChildItem -Path $PSScriptRoot/exports/*.ps1 -Recurse -ErrorAction SilentlyContinue )
$internalFunctions = @( Get-ChildItem -Path $PSScriptRoot/internal/*.ps1 -ErrorAction SilentlyContinue )

$allFunctions = $internalFunctions + $exportedFunctions
foreach($function in $allFunctions) {
    try {
        . $function.Fullname
        Write-Warning "$($function.Fullname)"
    }
    catch {
        Write-Error -Message "Failed to import function $($function.fullname): $_"
    }
}

Export-ModuleMember -Function $exportedFunctions.Basename

$commandsWithRepositoryParameter = @(
    "Install-AzModule",
    "Update-AzModule"
)

Add-RepositoryArgumentCompleter -Cmdlets $commandsWithRepositoryParameter -ParameterName "Repository"
Add-RepositoryDefaultValue -Cmdlets $commandsWithRepositoryParameter -ParameterName "Repository"
<#--------------------------------------------------------------#>

function Test-Downloader {
    param (
    )
    
    process {
        $tempRepo = Join-Path 'D:/PSLocalRepo/' (Get-Date -Format "yyyyddMM-HHmm")
        $null = Microsoft.PowerShell.Management\New-Item -ItemType Directory -Path $tempRepo -WhatIf:$false

        $url = Get-RepositoryUrl 'PSGallery'
        $downloader = [ParallelDownloader]::new($url)
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
