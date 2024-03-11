
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
Migrate logins from the source Sql Servers to the target Azure Sql Servers.
.Description
Migrate logins from the source Sql Servers to the target Azure Sql Servers.
#>


function New-AzDataMigrationLoginsMigration
{
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Description('Migrate logins from the source Sql Servers to the target Azure Sql Servers.')]

    param(
        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Required. Connection string(s) for the source SQL instance(s), using the formal connection string format.')]
        [System.String[]]
        ${SourceSqlConnectionString},


        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Required. Connection string(s) for the target SQL instance(s), using the formal connection string format.')]
        [System.String]
        ${TargetSqlConnectionString},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Location of CSV file of logins. Use only one parameter between this and listOfLogin.')]
        [System.String]
        ${CSVFilePath},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. List of logins in string format. If large number of logins need to be migrated, use CSV file option.')]
        [System.String[]]
        ${ListOfLogin},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Default: %LocalAppData%/Microsoft/SqlLoginMigrations) Folder where logs will be written.')]
        [System.String]
        ${OutputFolder},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Required if Windows logins are included in the list of logins to be migrated. (Default: empty string).')]
        [System.String]
        ${AADDomainName},

        [Parameter(ParameterSetName='ConfigFile', Mandatory, HelpMessage='Path of the ConfigFile')]
        [System.String]
        ${ConfigFilePath},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru}
    )

    process 
    {
        try 
        {
            $OSPlatform = Get-OSName

            if(-Not $OSPlatform.Contains("Windows"))
            {
                throw "This command cannot be run in non-windows environment"
                Break;
            }

            #Defining Default Output Path
            $DefaultOutputFolder = Get-DefaultLoginMigrationsOutputFolder

            #Defining Downloads folder
            $DownloadsFolder = Join-Path -Path $DefaultOutputFolder -ChildPath Downloads;

            #Checking if DownloadsFolder Path is valid or not
            if(-Not (Test-Path $DownloadsFolder))
            {
                $null = New-Item -Path $DownloadsFolder -ItemType "directory"
            }
            else
            {
                #Remove old Login console app files
                #Old console app download address
                $ZipDestination = Join-Path -Path $DownloadsFolder -ChildPath "LoginsMigration.zip";

                # Remove old zip file
                if(Test-Path $ZipDestination)
                {
                    Remove-Item -Path $ZipDestination;
                }

                # Remove existing folder and contents
                $ConsoleAppDestination = Join-Path -Path $DownloadsFolder -ChildPath "Logins.Console.csproj";
                if(Test-Path $ConsoleAppDestination)
                {
                    Remove-Item -Path $ConsoleAppDestination -Recurse;
                }

                # Remove version file
                $VersionFileDestination = Join-Path -Path $DownloadsFolder -ChildPath "loginconsoleappversion.json";
                if(Test-Path $VersionFileDestination)
                {
                    Remove-Item -Path $VersionFileDestination;
                }
            }

            #Determine latest version of Login console app
            $PackageId = "Microsoft.SqlServer.Migration.LoginsConsoleApp"

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

            $ConsoleAppFolders = Get-ChildItem -Path $DownloadsFolder -Filter "$PackageId.*"
            $LatestLocalNameAndVersion = ""
            if ($ConsoleAppFolders.Length -gt 0)
            {
                $ConsoleAppFolders = $ConsoleAppFolders | Sort-Object -Property Name -Descending
                $LatestLocalNameAndVersion = $ConsoleAppFolders[0].Name
                Write-Host "Installed Login migration console app nupkg version: $LatestLocalNameAndVersion"

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

            Write-Host "Latest Login migration console app nupkg version on Nuget.org: $LatestNugetOrgNameAndVersion";
            $LatestNugetFolder = Join-Path -Path $DownloadsFolder -ChildPath $LatestNugetOrgNameAndVersion;
            $ExePath = "tools\Microsoft.SqlServer.Migration.Logins.ConsoleApp.exe";

            #User consent for Login migration console app update. By default it is set to yes.
            $userUpdateConsent = "yes";

            # Prompt for user consent on Login migration console app update
            if($LatestLocalNameAndVersion -ne "" -and $LatestNugetOrgNameAndVersion -gt $LatestLocalNameAndVersion)
            {
                Write-Host "Newer Login migration console app nupkg version is available in Nuget.org...";
                while($true) {
                    $userUpdateConsent = Read-Host -Prompt "Do you want to upgrade to the latest version? (yes/no)"

                    if ($userUpdateConsent -eq "yes")
                    {
                        Write-Host "You chose to upgrade. Proceeding..."
                        break;
                    }
                    elseif ($userUpdateConsent -eq "no")
                    {
                        Write-Host "You chose not to upgrade."
                        $LatestNugetFolder = Join-Path -Path $DownloadsFolder -ChildPath $LatestLocalNameAndVersion;
                        break;
                    }
                    else
                    {
                        Write-Host "Invalid input. Please enter 'yes' or 'no'."
                    }
                }
            }

            if ($LatestNugetOrgNameAndVersion -gt $LatestLocalNameAndVersion -and $userUpdateConsent -eq "yes")
            {
                #Update is available
                $DownloadUrl = "https://www.nuget.org/api/v2/package/$PackageId/$LatestNugetOrgVersion"

                #Checking if LatestNugetFolder Path is valid or not
                if(-Not (Test-Path $LatestNugetFolder))
                {
                    $null = New-Item -Path $LatestNugetFolder -ItemType "directory";
                }

                Write-Host "Downloading the latest Login migration console app nupkg: $LatestNugetOrgNameAndVersion ..."
                Invoke-WebRequest $DownloadUrl -OutFile "$LatestNugetFolder\\$LatestNugetOrgName.$LatestNugetOrgVersion.nupkg"

                $ToolsPathExists = Test-Path -Path (Join-Path -Path $LatestNugetFolder -ChildPath "tools");

                if ($ToolsPathExists -eq $False)
                {
                    $Nugets = Get-ChildItem -Path $LatestNugetFolder -Filter "$PackageId.*.nupkg";

                    if ($Nugets.Length -gt 0)
                    {
                        Write-Host "Extracting the latest Login migration console app nupkg: $LatestNugetOrgNameAndVersion ..."
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
                    Write-Host "Removing all older Login migration console apps..."
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

            #Collecting data
            if(('CommandLine') -contains $PSCmdlet.ParameterSetName)
            {
                # The array list $splat contains all the parameters that will be passed to '.\Microsoft.SqlServer.Migration.Logins.ConsoleApp.exe LoginsMigration'

                $LoginsListArray = $($ListOfLogin -split " ")
                [System.Collections.ArrayList] $splat = @(
                    '--sourceSqlConnectionString', $SourceSqlConnectionString
                    '--targetSqlConnectionString', $TargetSqlConnectionString
                    '--csvFilePath', $CSVFilePath
                    '--listOfLogin', $LoginsListArray
                    '--outputFolder', $OutputFolder
                    '--aadDomainName', $AADDomainName
                )
                # Removing the parameters for which the user did not provide any values
                for($i = $splat.Count-1; $i -gt -1; $i = $i-2)
                {
                    $currVal = $splat[$i]
                    if($currVal -ne "")
                    {
                    }
                    else {
                        $splat.RemoveAt($i)
                        $i2 = $i -1
                        $splat.RemoveAt($i2)
    
                    }                       
                }

                $ExePath = Join-Path -Path $LatestNugetFolder -ChildPath $ExePath;
                # Running LoginsMigration
                Write-Host "Starting Execution..."
                & $ExePath LoginsMigration @splat
            }
            else
            {   
                Test-LoginMigrationsConfigFile $PSBoundParameters.ConfigFilePath
                & $ExePath --configFile $PSBoundParameters.ConfigFilePath
            }

            $LogFilePath = Join-Path -Path $DefaultOutputFolder -ChildPath Logs;
            Write-Host "Event and Error Logs Folder Path: $LogFilePath";

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
