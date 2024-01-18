
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

            #Defining Base and Exe paths
            $BaseFolder = Join-Path -Path $DefaultOutputFolder -ChildPath Downloads;
            $ExePath = Join-Path -Path $BaseFolder -ChildPath Logins.Console.csproj\Logins.Console.exe;

            #Checking if BaseFolder Path is valid or not
            if(-Not (Test-Path $BaseFolder))
            {
                $null = New-Item -Path $BaseFolder -ItemType "directory"
            }

            #Testing Whether Console App is downloaded or not
            $TestExePath =  Test-Path -Path $ExePath;

            #Console app download address
            $ZipSource = "https://sqlassess.blob.core.windows.net/app/LoginsMigration.zip";
            $ZipDestination = Join-Path -Path $BaseFolder -ChildPath "LoginsMigration.zip";

            #Downloading and extracting LoginsMigration Zip file
            if(-Not $TestExePath)
            {
                #Downloading and extracting LoginMigration Zip file
                Write-Host "Downloading and extracting latest LoginMigration Zip file..."
                Invoke-RestMethod -Uri $ZipSource -OutFile $ZipDestination;
                Expand-Archive -Path $ZipDestination -DestinationPath $BaseFolder -Force;
            }
            else
            {
                # Get local exe version
                Write-Host "Checking installed Login.Console.exe version...";
                $installedVersion = (Get-Item $ExePath).VersionInfo.FileVersion;
                Write-Host "Installed version: $installedVersion";

                # Get latest console app version
                Write-Host "Checking whether there is newer version...";
                $VersionFileSource = "https://sqlassess.blob.core.windows.net/app/loginconsoleappversion.json";
                $VersionFileDestination = Join-Path -Path $BaseFolder -ChildPath "loginconsoleappversion.json";
                Invoke-RestMethod -Uri $VersionFileSource -OutFile $VersionFileDestination;
                $jsonObj = Get-Content $VersionFileDestination | Out-String | ConvertFrom-Json;
                $latestVersion = $jsonObj.version;

                # Compare the latest exe version with the local exe version
                if([System.Version]$installedVersion -lt [System.Version]$latestVersion)
                {
                    Write-Host "Found newer version of Logins.Console.exe '$latestVersion'";

                    Write-Host "Removing old Logins.Console.exe..."
                    # Remove old zip file
                    Remove-Item -Path $ZipDestination;

                    # Remove existing folder and contents
                    $ConsoleAppDestination = Join-Path -Path $BaseFolder -ChildPath "Logins.Console.csproj";
                    Remove-Item -Path $ConsoleAppDestination -Recurse;

                    # Remove version file
                    Remove-Item -Path $VersionFileDestination;

                    #Downloading and extracting LoginMigration Zip file
                    Write-Host "Downloading and extracting latest LoginMigration Zip file..."
                    Invoke-RestMethod -Uri $ZipSource -OutFile $ZipDestination;
                    Expand-Archive -Path $ZipDestination -DestinationPath $BaseFolder -Force;
                }
                else
                {
                    Write-Host "Installed Logins.Console.exe is the latest one...";
                }
            }

            #Collecting data
            if(('CommandLine') -contains $PSCmdlet.ParameterSetName)
            {
                # The array list $splat contains all the parameters that will be passed to '.\Logins.Console.exe LoginsMigration'

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
                # Running LoginsMigration                
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
