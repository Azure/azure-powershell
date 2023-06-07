
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
Migrate Sql Server Schema from the source Sql Servers to the target Azure Sql Servers.
.Description
Migrate Sql Server Schema from the source Sql Servers to the target Azure Sql Servers.
#>


function New-AzDataMigrationSqlServerSchema
{
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Description('Migrate Sql Server Schema from the source Sql Servers to the target Azure Sql Servers.')]

    param(
        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Required. Select one schema migration action. The valid values are: MigrateSchema, GenerateScript, DeploySchema. MigrateSchema is to migrate the database objects to Azure SQL Database target. GenerateScript is to generate an editable TSQL schema script that can be used to run on the target to deploy the objects. DeploySchema is to run the TSQL script generated from -GenerateScript action on the target to deploy the objects.')]
        [Validateset('MigrateSchema', 'GenerateScript', 'DeploySchema', IgnoreCase = $true)]
        [System.String]
        ${Action},

        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Required. Connection string for the source SQL instance, using the formal connection string format.')]
        [System.String]
        ${SourceConnectionString},

        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Required. Connection string for the target SQL instance, using the formal connection string format.')]
        [System.String]
        ${TargetConnectionString},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Location of an editable TSQL schema script. Use this parameter only with DeploySchema Action.')]
        [System.String]
        ${InputScriptFilePath},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Default: %LocalAppData%/Microsoft/SqlSchemaMigrations) Folder where logs will be written and the generated TSQL schema script by GenerateScript Action.')]
        [System.String]
        ${OutputFolder},

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
            $DefaultOutputFolder = Get-DefaultSqlServerSchemaOutputFolder

            #Defining Base and Exe paths
            $BaseFolder = Join-Path -Path $DefaultOutputFolder -ChildPath Downloads;
            $ExePath = Join-Path -Path $BaseFolder -ChildPath SchemaMigration.Console.csproj\SqlSchemaMigration.exe;

            #Checking if BaseFolder Path is valid or not
            if(-Not (Test-Path $BaseFolder))
            {
                $null = New-Item -Path $BaseFolder -ItemType "directory"
            }

            #Testing Whether Console App is downloaded or not
            $TestExePath =  Test-Path -Path $ExePath;

            #Downloading and extracting SchemaMigration Zip file
            if(-Not $TestExePath)
            {
                $ZipSource = "https://migrationapps.blob.core.windows.net/schemamigration/SqlSchemaMigration.zip";
                $ZipDestination = Join-Path -Path $BaseFolder -ChildPath "SqlSchemaMigration.zip";
                Invoke-RestMethod -Uri $ZipSource -OutFile $ZipDestination;

                Expand-Archive -Path $ZipDestination -DestinationPath $BaseFolder -Force;
            }
            # To do:
            # else
            # {
                # check local exe version; 
                # call storage account API to get latest version
                # if version does not match, pop up to choose download Yes/No
            # }

            #Collecting data
            if($PSCmdlet.ParameterSetName -eq 'CommandLine')
            {   
                # The array list $splat contains all the parameters that will be passed to '.\SqlSchemaMigration.exe'
                [System.Collections.ArrayList] $splat = @(
                    '--sourceConnectionString', $SourceConnectionString
                    '--targetConnectionString', $TargetConnectionString
                    '--inputScriptFilePath', $InputScriptFilePath
                    '--outputFolder', $OutputFolder
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
                # Running Action                
                & $ExePath $Action @splat
            }
            else
            {   
                Write-Host "Run through the provided config file:"
                Test-SqlServerSchemaConfigFile $PSBoundParameters.ConfigFilePath
                & $ExePath --configFile $PSBoundParameters.ConfigFilePath
            }

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
