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
$script:FixProgressBarId = 1
$script:ParallelDownloaderClassCode = @"
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

public class ParallelDownloader
{
    private readonly HttpClientHandler httpClientHandler = new HttpClientHandler();
    private readonly HttpClient client = null;
    private readonly string urlRepository = null;
    private readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

    private readonly IList<Task> tasks;
    private readonly IList<string> modules;

    private string lastModuleName = null;
    private string lastModuleVersion = null;

    public string LastModuleName
    {
        get
        {
            return lastModuleName;
        }
    }

    public string LastModuleVersion
    {
        get
        {
            return lastModuleVersion;
        }
    }

    public ParallelDownloader(string url)
    {
        client = new HttpClient(httpClientHandler);
        this.urlRepository = url;
        tasks = new List<Task>();
        modules = new List<string>();
    }

    public ParallelDownloader()
    {
        client = new HttpClient(httpClientHandler);
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

    private void Copy(string src, string dest)
    {
        File.Copy(src, dest);
    }

    bool ParseFile(string fileName, out string moduleName, out Version moduleVersion, out Boolean preview)
    {
        try
        {
            Regex pattern = new Regex(@"(?<moduleName>[a-zA-Z.]+)\.(?<moduleVersion>[0-9.]+(\-preview)?)\.nupkg");
            Match matches = pattern.Match(fileName);
            if (matches.Groups["moduleName"].Success && matches.Groups["moduleVersion"].Success)
            {
                moduleName = matches.Groups["moduleName"].Value;
                var versionString = matches.Groups["moduleVersion"].Value;
                if (versionString.Contains('-'))
                {
                    var parts = versionString.Split('-');
                    moduleVersion = Version.Parse(parts[0]);
                    preview = string.Compare(parts[1], "preview", true) == 0;
                }
                else
                {
                    moduleVersion = Version.Parse(versionString);
                    preview = false;
                }
                return true;
            }
        }
        catch
        {
        }
        moduleName = null;
        moduleVersion = null;
        preview = false;
        return false;
    }

    public string Download(string sourceUri, string targetPath)
    {
        try
        {
            Uri uri = new Uri(sourceUri);
            var fileName = Path.GetFileName(uri.AbsoluteUri);
            string module = null;
            Version version = null;
            Boolean preview = false;
            if (!ParseFile(fileName, out module, out version, out preview))
            {
                throw new ArgumentException(string.Format("{0} is not a valid Az module nuget package name for installation.", fileName));
            }
            var nupkgFile = preview ? "{0}.{1}-preview.nupkg": "{0}.{1}.nupkg";
            nupkgFile = Path.Combine(targetPath, String.Format(nupkgFile, module, version));
            if (uri.IsFile)
            {
                Copy(uri.AbsolutePath, nupkgFile);
            }
            else if(String.Compare(uri.Scheme, "http", true) == 0 || String.Compare(uri.Scheme, "https", true) == 0)
            {
                Task task = DownloadToFile(uri.AbsoluteUri, nupkgFile);
                tasks.Add(task);
                modules.Add(module);
            }
            else
            {
                throw new ArgumentException(string.Format("{0} scheme is not supported.", sourceUri));
            }
            lastModuleName = module;
            lastModuleVersion = string.Format(preview ? "{0}-preview" : "{0}", version);
            return nupkgFile;
        }
        catch (UriFormatException)
        {
            throw new ArgumentException(string.Format("{0} is not a valid uri.", sourceUri));
        }
    }

    public string Download(string module, Version version, string path, Boolean preview = false)
    {
        var nupkgFile = preview ? "{0}.{1}-preview.nupkg" : "{0}.{1}.nupkg";
        nupkgFile = Path.Combine(path, String.Format(nupkgFile, module, version));
        Task task = DownloadToFile(String.Format("{0}/package/{1}/{2}", urlRepository, module, version), nupkgFile);
        tasks.Add(task);
        modules.Add(module);
        lastModuleName = module;
        lastModuleVersion = string.Format(preview ? "{0}-preview" : "{0}", version);
        return nupkgFile;
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

Add-Type -AssemblyName System.Net.Http -ErrorAction Stop
Add-Type $script:ParallelDownloaderClassCode -ReferencedAssemblies System.Net.Http,System.Threading.Tasks,System.Linq,System.Collections,System.Runtime.Extensions,System.Text.RegularExpressions,System.IO.FileSystem

$getModule = Get-Module -Name "PowerShellGet"
if ($null -ne $getModule -and $getModule.Version -lt [System.Version]"2.1.3") {
    Write-Error "This module requires PowerShellGet version 2.1.3. An earlier version of PowerShellGet is imported in the current PowerShell session. Please open a new session before importing this module." -ErrorAction Stop
}
elseif ($null -eq $getModule -or $getModule.Version -ge [System.Version]"3.0") {
    try {
        Import-Module PowerShellGet -MinimumVersion 2.1.3 -MaximumVersion 3.0 -Scope Global -Force -ErrorAction Stop
    }
    catch {
        Write-Error "This module requires PowerShellGet version no earlier than 2.1.3 and no later than 3.0. Please install the required PowerShellGet firstly."
    }
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

        if ($normalName -and $normalName -notmatch "Az(\.[a-zA-Z0-9.]+)?$") {
            $normalName = $null
            Throw "The Name parameter must only contain Az modules."
        }

        if ($normalName -eq 'Az.Az') {
            $normalName = $normalName | Where-Object { $_ -ne 'Az.Az'}
            Write-Warning "Az.Tools.Installer cannot be used to install Az. Will discard Az in the Name parameter."
        }

        $normalName
    }
}

function Get-AzModuleFromRemote {
    [OutputType([PSCustomObject[]])]
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
                Throw "[$Invoker] Prerelease version cannot be lower than 6.0. Please install GA modules only or specify Az version above 6.0."
            }
            else {
                $azModule = "AzPreview"
            }
        }
        $findModuleParams = @{
            Name =  $azModule
            RequiredVersion = $RequiredVersion
            ErrorAction = 'Stop'
        }
        if ($Repository) {
            $findModuleParams.Add('Repository', $Repository);
        }

        $modules = [Array] (PowerShellGet\Find-Module @findModuleParams)
        if ($modules.Count -gt 1) {
            Throw "[$Invoker] You have multiple modules matched 'Az' in the registered reposistory $($modules.Repository). Please specify a single -Repository."
        }

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
        $module = $null
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

class ModuleInfo
{
    [string] $Name = $null
    [Version[]] $Version = @()
}

function Remove-AzureRM {
    process {
        try {
            $azureModuleNames = (Get-InstalledModule -Name Azure* -ErrorAction Stop).Name | Where-Object {$_ -match "Azure(\.[a-zA-Z0-9]+)?" -or $_ -match "AzureRM(\.[a-zA-Z0-9]+)?"}
            foreach($moduleName in $azureModuleNames) {
                PowerShellGet\Uninstall-Module -Name $moduleName -AllVersion -AllowPrerelease -ErrorAction Continue
            }
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
    }
    catch {
        Write-Error "Failed to import function $($function.fullname): $_"
    }
}

Export-ModuleMember -Function $exportedFunctions.Basename

$commandsWithRepositoryParameter = @(
    "Install-AzModule",
    "Update-AzModule"
)

Add-RepositoryArgumentCompleter -Cmdlets $commandsWithRepositoryParameter -ParameterName "Repository"