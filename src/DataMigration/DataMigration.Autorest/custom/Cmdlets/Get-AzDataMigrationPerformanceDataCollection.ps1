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
Collect performance data for given SQL instance .
.Description
Collect performance data for given SQL instance over an extended period of time. The collected data can then be aggregated and analysed, and by examining the performance characteristics of your source instance, SKU recommendations can be determined for Azure SQL offerings.
#>

function Get-AzDataMigrationPerformanceDataCollection
{
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Description('Collect performance data for given SQL Server instance(s)')]

    param(
        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Sql Server Connection Strings')]
        [System.String[]]
        ${SqlConnectionStrings},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Folder which data and result reports will be written to/read from.')]
        [System.String]
        ${OutputFolder},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Interval at which to query performance data, in seconds. (Default: 30)')]
        [System.String]
        ${PerfQueryInterval},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Interval at which to query and persist static configuration data, in seconds. (Default: 3600)')]
        [System.String]
        ${StaticQueryInterval},

        [Parameter(ParameterSetName='CommandLine', HelpMessage='Number of iterations of performance data collection to perform before persisting to file. For example, with default values, performance data will be persisted every 30 seconds * 20 iterations = 10 minutes. (Default: 20, Minimum: 2)
        ')]
        [System.String]
        ${NumberOfIterations},

        [Parameter(ParameterSetName='ConfigFile', Mandatory, HelpMessage='Path of the ConfigFile')]
        [System.String]
        ${ConfigFilePath},

        [Parameter(HelpMessage = 'Duration of time in seconds for which you want to collect performance data')]
        [System.Int64]
        ${Time},

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
                # The array list $splat contains all the parameters that will be passed to '.\SqlAssessment.exe PerfDataCollection'
                [System.Collections.ArrayList] $splat = @(
                '--sqlConnectionStrings', $SqlConnectionStrings
                '--outputfolder', $OutputFolder
                '--perfQueryIntervalInSec', $PerfQueryInterval
                '--staticQueryIntervalInSec', $StaticQueryInterval
                '--numberOfIterations', $NumberOfIterations
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
                
                # Running PerfDataCollection
                If($PSBoundParameters.ContainsKey("Time"))
                {   
                    #this is used to create a json file in case the perf collection is to be time based
                    $jsonHash = [Ordered]@{
                    'action' = "PerfDataCollection"
                    'sqlConnectionStrings'= $SqlConnectionStrings
                    'outputfolder'= $OutputFolder
                    'perfQueryIntervalInSec'= $PerfQueryInterval
                    'staticQueryIntervalInSec'= $StaticQueryInterval
                    'numberOfIterations'= $NumberOfIterations
                    }
                    # removing empty key,vallue pairs from $jsonHash
                    if($OutputFolder -eq "")
                    {
                        $jsonHash.Remove('outputfolder')
                    }
                    if($PerfQueryInterval -eq "")
                    {
                        $jsonHash.Remove('perfQueryIntervalInSec')
                    }
                    if($StaticQueryInterval -eq "")
                    {
                        $jsonHash.Remove('staticQueryIntervalInSec')
                    }
                    if($NumberOfIterations -eq "")
                    {
                        $jsonHash.Remove('numberOfIterations')
                    } 
                    
                    $saveAt = Join-Path -Path $DefaultOutputFolder -ChildPath Downloads;
                    $saveas = Join-Path -Path $saveAt -ChildPath "tempConfigFileForPerf.json"
                    $jsonHash | ConvertTo-Json -depth 100 | Set-Content $saveas
                    $pro = Start-Process -FilePath $ExePath -ArgumentList "--configFile ""$saveas"""  -PassThru -NoNewWindow
                    Start-Sleep -Seconds $Time
                    $pro | stop-process  
                    Remove-Item -Path $saveas       
                }
                else
                {
                    & $ExePath PerfDataCollection @splat
                }                 
            }
            else
            {   
                if($PSBoundParameters.ContainsKey("Time"))
                {
                    $paramPath = $PSBoundParameters.ConfigFilePath
                    Test-ConfigFile $PSBoundParameters.ConfigFilePath "PerfDataCollection"
                    $pro = Start-Process -FilePath $ExePath -ArgumentList "--configFile ""$paramPath"""  -PassThru -NoNewWindow
                    Start-Sleep -Seconds $Time
                    $pro | stop-process
                    
                }
                else{
                    Test-ConfigFile $PSBoundParameters.ConfigFilePath "PerfDataCollection"
                    & $ExePath --configFile $PSBoundParameters.ConfigFilePath
                }
                
                
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

