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
Gives SKU recommendations for Azure SQL offerings.
.Description
Gives SKU recommendations for Azure SQL offerings (including SQL Database, SQL Managed Instance, and SQL on Azure VM) that best suit your workload while also being cost-effective.
#>

function Get-AzDataMigrationSkuRecommendation
{
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Description('Gives SKU recommendations for Azure SQL offerings')]

    param(
                  
        [Parameter(ParameterSetName='CommandLine', HelpMessage='Folder which data and result reports will be written to/read from. The value here must be the same as the one used in PerfDataCollection')]
        [System.String]
        ${OutputFolder},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Target platform for SKU recommendation: either AzureSqlDatabase, AzureSqlManagedInstance, AzureSqlVirtualMachine, or Any. If Any is selected, then SKU recommendations for all three target platforms will be evaluated, and the best fit will be returned. (Default: Any)')]
        [System.String]
        ${TargetPlatform},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Name of the SQL instance that SKU recommendation will be targeting. (Default: outputFolder will be scanned for files created by the PerfDataCollection action, and recommendations will be provided for every instance found)')]
        [System.String]
        ${TargetSqlInstance},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Percentile of data points to be used during aggregation of the performance data. Only used for baseline (non-elastic) strategy. (Default: 95)')]
        [System.String]
        ${TargetPercentile},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Scaling (comfort) factor used during SKU recommendation. For example, if it is determined that there is a 4 vCore CPU requirement with a scaling factor of 150%, then the true CPU requirement will be 6 vCores. (Default: 100)')]
        [System.String]
        ${ScalingFactor},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. UTC start time of performance data points to consider during aggregation, in YYYY-MM-DD HH:MM format. Only used for baseline (non-elastic) strategy. (Default: all data points collected will be considered)')]
        [System.String]
        ${StartTime},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. UTC end time of performance data points to consider during aggregation, in YYYY-MM-DD HH:MM format. Only used for baseline (non-elastic) strategy. (Default: all data points collected will be considered)')]
        [System.String]
        ${EndTime},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Whether or not to overwrite any existing SKU recommendation reports.')]
        [System.Management.Automation.SwitchParameter]
        ${Overwrite},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Whether or not to print the SKU recommendation results to the console.')]
        [System.Management.Automation.SwitchParameter]
        ${DisplayResult},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Whether or not to use the elastic strategy for SKU recommendations based on resource usage profiling.')]
        [System.Management.Automation.SwitchParameter]
        ${ElasticStrategy},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Space separated list of names of databases to be allowed for SKU recommendation consideration while excluding all others. Only set one of the following or neither: databaseAllowList, databaseDenyList. How to pass - "Database1 Database2" (Default: null)')]
        [System.String]
        ${DatabaseAllowList},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Optional. Space separated list of names of databases to not be considered for SKU recommendation. Only set one of the following or neither: databaseAllowList, databaseDenyList. How to pass - "Database1 Database2" (Default: null)
        ')]
        [System.String]
        ${DatabaseDenyList},

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
            $DefaultOutputFolder = Get-DefaultOutputFolder

            #Defining Base and Exe paths
            $BaseFolder = Join-Path -Path $DefaultOutputFolder -ChildPath Downloads;
            $ExePath = Join-Path -Path $BaseFolder -ChildPath SqlAssessment.Console.csproj\SqlAssessment.exe;

            #Checking if BaseFolder Path is valid or not
            if(-Not (Test-Path $BaseFolder))
            {
                $null = New-Item -Path $BaseFolder -ItemType "directory"
            }

            #Testing Whether Console App is downloaded or not
            $TestExePath =  Test-Path -Path $ExePath;

            #Downloading and extracting SqlAssessment Zip file
            if(-Not $TestExePath)
            {
                $ZipSource = "https://aka.ms/sqlassessmentpackage";
                $ZipDestination = Join-Path -Path $BaseFolder -ChildPath "SqlAssessment.zip";
                Invoke-RestMethod -Uri $ZipSource -OutFile $ZipDestination;

                Expand-Archive -Path $ZipDestination -DestinationPath $BaseFolder -Force;
            }

            #Collecting performance data
            if(('CommandLine') -contains $PSCmdlet.ParameterSetName)
            {
                # The array list $splat contains all the parameters that will be passed to '.\SqlAssessment.exe GetSkuRecommendation'

                $DatabaseAllowList2 = $($DatabaseAllowList -split " ")
                $DatabaseDenyList2 = $($DatabaseDenyList -split " ")
                [System.Collections.ArrayList] $splat = @(
                    '--outputFolder', $OutputFolder
                    '--targetPlatform', $TargetPlatform
                    '--targetSqlInstance', $TargetSqlInstance
                    '--scalingFactor', $ScalingFactor
                    '--targetPercentile', $TargetPercentile
                    '--startTime', $StartTime
                    '--endTime', $EndTime
                    '--overwrite', $Overwrite
                    '--displayResult', $DisplayResult
                    '--elasticStrategy', $ElasticStrategy
                    '--databaseAllowList', $DatabaseAllowList2
                    '--databaseDenyList', $DatabaseDenyList2
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
                # Running GetSkuRecommendation                
                & $ExePath GetSkuRecommendation @splat
            }
            else
            {   
                Test-ConfigFile $PSBoundParameters.ConfigFilePath "GetSkuRecommendation"
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


