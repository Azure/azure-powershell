
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
Migrate TDE certificate from source SQL Server to the target Azure SQL Server.
.Description
Migrate TDE certificate from source SQL Server to the target Azure SQL Server.
#>


function New-AzDataMigrationTdeCertificateMigration
{
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Description('Migrate TDE certificate from source SQL Server to the target Azure SQL Server.')]

    param(
        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Required. Connection string for the source SQL instance, using the formal connection string format.')]
        [System.String]
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
        [securestring]
        ${NetworkSharePassword},

        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Source database name.')]
        [System.String]
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
            $OSPlatform = Get-OSName
            
            if(-Not $OSPlatform.Contains("Windows"))
            {
                throw "This command cannot be run in non-windows environment"
                Break;
            }

            #Defining Default Output Path
            $DefaultOutputFolder = Get-DefaultTdeMigrationsOutputFolder

            #Defining Base and Exe paths
            $BaseFolder = Join-Path -Path $DefaultOutputFolder -ChildPath Downloads;

            $ExePath = Join-Path -Path $BaseFolder -ChildPath "Microsoft.SqlServer.Migration.Tde.ConsoleApp.csproj\Microsoft.SqlServer.Migration.Tde.ConsoleApp.exe";

            #Checking if BaseFolder Path is valid or not
            if(-Not (Test-Path $BaseFolder))
            {
                $null = New-Item -Path $BaseFolder -ItemType "directory"
            }

            #Testing Whether Console App is downloaded or not
            $TestExePath = Test-Path -Path $ExePath;

            #Downloading and extracting TdeMigration Zip file
            if(-Not $TestExePath)
            {

            }

            [System.Collections.ArrayList] $parameterArray = @(
                "--sourceSqlConnectionString", $SourceSqlConnectionString,
                "--targetSubscriptionId", $TargetSubscriptionId,
                "--targetResourceGroupName", $TargetResourceGroupName,
                "--targetManagedInstanceName", $TargetManagedInstanceName
                "--networkSharePath", $NetworkSharePath
                "--networkShareDomain", $NetworkShareDomain
                "--networkShareUserName", $NetworkShareUserName
                "--networkSharePassword", $NetworkSharePassword
                "--databaseName", $DatabaseName
            )
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
