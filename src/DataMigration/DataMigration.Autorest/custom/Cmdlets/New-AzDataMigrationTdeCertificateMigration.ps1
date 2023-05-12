
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
<#
.Synopsis
Migrate TDE certificate(s) from source SQL Server to the target Azure SQL Server.
.Description
Migrate TDE certificate(s) from source SQL Server to the target Azure SQL Server.
#>


function New-AzDataMigrationTdeCertificateMigration
{
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Description('Migrate TDE certificate(s) from source SQL Server to the target Azure SQL Server.')]

    param(
        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Required. Connection string for the source SQL instance, using the formal connection string format.')]
        [SecureString]
        ${SourceSqlConnectionString},

        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Subscription Id of the target Azure SQL server.')]
        [System.String]
        ${TargetSubscriptionId},

        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Resource group name of the target Azure SQL server.')]
        [System.String]
        ${TargetResourceGroupName},

        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Name of the Azure SQL Server.')]
        [System.String]
        ${TargetManagedInstanceName},

        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Network share path.')]
        [System.String]
        ${NetworkSharePath},

        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Network share domain.')]
        [System.String]
        ${NetworkShareDomain},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Network share user name.')]
        [System.String]
        ${NetworkShareUserName},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Network share password.')]
        [SecureString]
        ${NetworkSharePassword},

        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Source database name.')]
        [System.String[]]
        ${DatabaseName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru}
    )

    process
    {
        try {
            if($PSCmdlet.ShouldProcess("Migrate TDE certificate(s) from source SQL Server.") -eq $false)
            {
                return;
            }

            $OSPlatform = Get-OSName

            if(-Not $OSPlatform.Contains("Windows"))
            {
                throw "This command cannot be run in non-windows environment"
                Break;
            }

            #Defining Default Output Path
            $DefaultOutputFolder = Get-DefaultTdeMigrationsOutputFolder

            #Determine latest version of TDE console app
            $PackageId = "Microsoft.SqlServer.Migration.TdeConsoleApp"

            $AvailablePackagesOnNugetOrg = ""

            try {
                $AvailablePackagesOnNugetOrg = Find-Package -Source "https://api.nuget.org/v3/index.json" -Name $PackageId -AllowPrereleaseVersions -AllVersions
                $AvailablePackagesOnNugetOrg = $AvailablePackagesOnNugetOrg | Sort-Object -Property Version -Descending
            } catch {
                Write-Host "Unable to connect to NuGet.org to check for updates."
            }

            $LatestNugetOrgName  = $AvailablePackagesOnNugetOrg[0].Name
            $LatestNugetOrgVersion = $AvailablePackagesOnNugetOrg[0].Version
            $LatestNugetOrgNameAndVersion = "$LatestNugetOrgName.$LatestNugetOrgVersion";

            $DownloadsFolder = Join-Path -Path $DefaultOutputFolder -ChildPath "Downloads"
            if(-Not (Test-Path $DownloadsFolder))
            {
                $null = New-Item -Path $DownloadsFolder -ItemType "directory";
            }

            $ConsoleAppFolders = Get-ChildItem -Path $DownloadsFolder -Filter "$PackageId.*"
            $LatestLocalNameAndVersion = ""
            if ($ConsoleAppFolders.Length -gt 0)
            {
                $ConsoleAppFolders = $ConsoleAppFolders | Sort-Object -Property Name -Descending
                $LatestLocalNameAndVersion = $ConsoleAppFolders[0].Name

                if ($AvailablePackagesOnNugetOrg -eq "")
                {
                    $LatestNugetOrgNameAndVersion = $LatestLocalNameAndVersion
                }
            }
            else
            {
                #No local console app
                if ($AvailablePackagesOnNugetOrg -eq "")
                {
                    #No version available to download
                    Write-Host "Connection to NuGet.org required. Please check connection and try again."
                    return;
                }
            }

            $LatestNugetFolder = Join-Path -Path $DownloadsFolder -ChildPath $LatestNugetOrgNameAndVersion;
            $ExePath = "tools\Microsoft.SqlServer.Migration.Tde.ConsoleApp.exe";

            if ($LatestNugetOrgNameAndVersion -gt $LatestLocalNameAndVersion)
            {
                #Update is available
                $DownloadUrl = "https://www.nuget.org/api/v2/package/$PackageId/$LatestNugetOrgVersion"

                #Checking if LatestNugetFolder Path is valid or not
                if(-Not (Test-Path $LatestNugetFolder))
                {
                    $null = New-Item -Path $LatestNugetFolder -ItemType "directory";
                }

                Invoke-WebRequest $DownloadUrl -OutFile "$LatestNugetFolder\\$LatestNugetOrgName.$LatestNugetOrgVersion.nupkg"

                $ToolsPathExists = Test-Path -Path (Join-Path -Path $LatestNugetFolder -ChildPath "tools");

                if ($ToolsPathExists -eq $False)
                {
                    $Nugets = Get-ChildItem -Path $LatestNugetFolder -Filter "$PackageId.*.nupkg";

                    if ($Nugets.Length -gt 0)
                    {
                        $Nugets = $Nugets | Sort-Object -Property Name -Descending;
                        $LatestNugetPath = $Nugets[0].FullName;
                        Expand-Archive -Path $LatestNugetPath -DestinationPath $LatestNugetFolder;
                    }
                }

                #Check if update was successful
                $TestPathResult = Test-Path -Path "$LatestNugetFolder\$ExePath"

                $NugetVersions = Get-ChildItem -Path $DownloadsFolder -Filter "$PackageId.*";
                $NugetVersions = $NugetVersions | Sort-Object -Property Name -Descending

                if($TestPathResult)
                {
                    #Remove all other NuGet versions except for the version just downloaded
                    for ($NugetIndex = 0; $NugetIndex -lt $NugetVersions.Length; $NugetIndex = $NugetIndex + 1)
                    {
                        if($NugetVersions[$NugetIndex].Name -ne $LatestNugetOrgNameAndVersion)
                        {
                            Remove-Item -Path $NugetVersions[$NugetIndex].FullName -Recurse -Force
                        }
                    }
                }
                else
                {
                    if($NugetVersions.Length -gt 0)
                    {
                        $LatestNugetFolder = $NugetVersions[0].Name;
                    }
                }
            }

            if(-Not (Test-Path -Path "$LatestNugetFolder\$ExePath"))
            {
                Write-Host "Failed to locate executable."
                return
            }

            $SourceSqlConnectionStringParam = . "$PSScriptRoot/../../utils/Unprotect-SecureString.ps1" $SourceSqlConnectionString
            $NetworkSharePasswordParam = . "$PSScriptRoot/../../utils/Unprotect-SecureString.ps1" $NetworkSharePassword

            [System.Collections.ArrayList] $parameterArray = @(
                "--sourceSqlConnectionString", $SourceSqlConnectionStringParam,
                "--targetSubscriptionId", $TargetSubscriptionId,
                "--targetResourceGroupName", $TargetResourceGroupName,
                "--targetManagedInstanceName", $TargetManagedInstanceName
                "--networkSharePath", $NetworkSharePath
                "--networkShareDomain", $NetworkShareDomain
                "--networkShareUserName", $NetworkShareUserName
                "--networkSharePassword", $NetworkSharePasswordParam
                "--databaseName"
            )

            $ExePath = Join-Path -Path $LatestNugetFolder -ChildPath $ExePath;
            foreach($Name in $DatabaseName) {
                $parameterArray.Add($Name) | Out-Null;
            }

            & $ExePath $parameterArray

            if($PSBoundParameters.ContainsKey("PassThru"))
            {
                return $true;
            }
        }
        catch
        {
            throw $_
        }
    }
}

function  Get-DefaultTdeMigrationsOutputFolder {
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
    )

    process {
        $OSPlatform = Get-OSName

        if($OSPlatform.Contains("Linux"))
        {
            $DefualtPath = Join-Path -Path $env:USERPROFILE -ChildPath ".config\Microsoft\SqlTdeMigrations";

        }
        elseif ($OSPlatform.Contains("Darwin"))
        {
            $DefualtPath = Join-Path -Path $env:USERPROFILE -ChildPath "Library\Application Support\Microsoft\SqlTdeMigrations";
        }
        else
        {
            $DefualtPath = Join-Path -Path $env:LOCALAPPDATA -ChildPath "Microsoft\SqlTdeMigrations";
        }

        return $DefualtPath
    }
}
