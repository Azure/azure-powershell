
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
Run assessment on given Sql Servers.
.Description
Run assessment on given Sql Servers.
#>


function Get-AzDataMigrationAssessment 
{
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Description('Runs assessment on given Sql Servers')]

    param(
        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Sql Server Connection Strings')]
        [System.String[]]
        ${ConnectionString},


        [Parameter(ParameterSetName='CommandLine', HelpMessage='Output folder to store assessment report')]
        [System.String]
        ${OutputFolder},


        [Parameter(ParameterSetName='CommandLine', HelpMessage='Enable this parameter to overwrite the existing assessment report')]
        [System.Management.Automation.SwitchParameter]
        ${Overwrite},

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
            #Defining Base and Exe paths
            $BaseFolder = $PSScriptRoot;
            $ExePath = Join-Path -Path $BaseFolder -ChildPath SqlAssessment.Console.csproj\SqlAssessment.exe;

            #Defining Default Output Path
            $DefaultOutputFolder = Get-DefaultOutputFolder

            #Testing Whether Console App is downloaded or not
            $TestExePath =  Test-Path -Path $ExePath;

            #Downloading and extracting SqlAssessment Zip file
            if(-Not $TestExePath)
            {
                $ZipSource = "https://sqlassess.blob.core.windows.net/app/SqlAssessment.zip";
                $ZipDestination = Join-Path -Path $BaseFolder -ChildPath "SqlAssessment.zip";
                Invoke-RestMethod -Uri $ZipSource -OutFile $ZipDestination;

                Expand-Archive -Path $ZipDestination -DestinationPath $BaseFolder -Force;
            }

            #Running Assessment
            if(('CommandLine') -contains $PSCmdlet.ParameterSetName)
            {
                if(($PSBoundParameters.ContainsKey("OutputFolder")))
                {
                    if($PSBoundParameters.ContainsKey("Overwrite"))
                    {
                        & $ExePath Assess --sqlConnectionStrings $PSBoundParameters.ConnectionString --outputFolder $PSBoundParameters.OutputFolder; 
                    }
                    else
                    {
                        & $ExePath Assess --sqlConnectionStrings $PSBoundParameters.ConnectionString --outputFolder $PSBoundParameters.OutputFolder --overwrite False;
                        
                    }
                }
                else
                {
                    if(($PSBoundParameters.ContainsKey("Overwrite")))
                    {
                        & $ExePath Assess --sqlConnectionStrings $PSBoundParameters.ConnectionString;
                    }
                    else 
                    {
                        & $ExePath Assess --sqlConnectionStrings $PSBoundParameters.ConnectionString --overwrite False;
                    }
                } 
            }
            else
            {   
                Test-ConfigFile $PSBoundParameters.ConfigFilePath
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
