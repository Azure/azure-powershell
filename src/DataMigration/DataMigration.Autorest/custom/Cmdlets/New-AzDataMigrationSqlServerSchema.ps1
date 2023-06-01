
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
            return $true;
        }
        catch 
        {
            throw $_
        }
    }
}
