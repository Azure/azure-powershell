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
Create an object as a parameter for submitting cluster work
.Description
Create an object as a parameter for submitting cluster work
.Example
 $flinkJobProperties = New-AzHdInsightOnAksFlinkJobObject -Action "NEW" -JobName "job1" `
        -JarName "JarName" -EntryClass "com.microsoft.hilo.flink.job.streaming.SleepJob" `
        -JobJarDirectory "abfs://flinkjob@hilosa.dfs.core.windows.net/jars" `
        -FlinkConfiguration @{parallelism=1}
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterJob
.Link
https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksFlinkJobObject
#>
function New-AzHdInsightOnAksFlinkJobObject{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterJob])]
    [CmdletBinding(DefaultParameterSetName='Create', PositionalBinding=$false)]
    param(
        [Parameter(ParameterSetName='Create', Mandatory)]
        [System.String]
        # The reference name of the secret to be used in service configs.
        ${Action},
        
        [Parameter(ParameterSetName='Create', Mandatory)]
        [System.String]
        # Name of job.
        ${JobName},

        [System.String]
        # A string property that specifies the directory where the job JAR is located.
        ${JobJarDirectory},

        [System.String]
        # A string property that represents the name of the job JAR
        ${JarName},

        [System.String]
        # A string property that specifies the entry class for the Flink job.
        ${EntryClass},

        [System.String]
        # A string property representing additional JVM arguments for the Flink job. It should be space separated value.
        ${Arg},

        [System.String]
        # A string property that represents the name of the savepoint for the Flink job
        ${SavePointName},

        [Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IFlinkJobPropertiesFlinkConfiguration]
        # Additional properties used to configure Flink jobs. It allows users to set properties such as parallelism and jobSavePointDirectory. It accepts additional key-value pairs as properties, where the keys are strings and the values are strings as well.
        ${FlinkConfiguration}
    )
    process{

        try {
            $flinkJobProperties = New-Object Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.FlinkJobProperties -Property @{
                Action = $Action
                JobName = $JobName
                JobJarDirectory = $JobJarDirectory
                JarName = $JarName
                EntryClass = $EntryClass
                Arg = $Arg
                FlinkConfiguration = $FlinkConfiguration
            }

            $clusterJob = New-Object Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ClusterJob -Property @{
                property = $flinkJobProperties
            }

            return $clusterJob
        }
        catch {
            throw
        }
}
}