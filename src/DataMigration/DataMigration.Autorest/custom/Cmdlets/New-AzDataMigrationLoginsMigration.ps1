
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
                #Delete old Login console app files
                Delete-OldLoginConsoleApp $DownloadsFolder;
            }

            #Determine latest version of Login console app
            $PackageId = "Microsoft.SqlServer.Migration.LoginsConsoleApp"
            $LatestNugetOrgDetails = Get-LatestConsoleAppVersionFromNugetOrg $PackageId

            #Determine local version of Login console app
            $ConsoleAppFolders = Get-ChildItem -Path $DownloadsFolder -Filter "$PackageId.*"
            $LatestLocalNameAndVersion = ""
            if ($ConsoleAppFolders.Length -gt 0)
            {
                $ConsoleAppFolders = $ConsoleAppFolders | Sort-Object -Property Name -Descending
                $LatestLocalNameAndVersion = $ConsoleAppFolders[0].Name
                Write-Host "Installed Login migration console app nupkg version: $LatestLocalNameAndVersion"

                if ($AvailablePackagesOnNugetOrg -eq "")
                {
                    $LatestNugetOrgDetails.NameAndVersion = $LatestLocalNameAndVersion
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

            Write-Host "Latest Login migration console app nupkg version on Nuget.org: $($LatestNugetOrgDetails.NameAndVersion)";
            $LatestNugetFolder = Join-Path -Path $DownloadsFolder -ChildPath $LatestNugetOrgDetails.NameAndVersion;
            $ExePath = "tools\Microsoft.SqlServer.Migration.Logins.ConsoleApp.exe";

            # Check for the latest console app version and download it if needed.
            CheckAndDownloadConsoleAppFromNugetOrg $LatestLocalNameAndVersion $LatestNugetOrgDetails $ExePath ([ref]$LatestNugetFolder)

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
