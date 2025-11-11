
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the \"License\");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an \"AS IS\" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for Container with no default values
.Description
Create a in-memory object for Container with no default values
.Link
https://learn.microsoft.com/powershell/module/az.ContainerInstance/New-AzContainerInstanceNoDefaultObject
#>
function New-AzContainerInstanceNoDefaultObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.Container')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.OutputBreakingChangeAttribute("Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.Container", "15.0.0", "9.0.0", "2025/11/03", ReplacementCmdletOutputType = "Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Container", DeprecatedOutputProperties = ("Port, EnvironmentVariable, InstanceViewEvent, LivenessProbeHttpGetHttpHeader, ReadinessProbeHttpGetHttpHeader, VolumeMount, LimitsGpuSku, RequestsGpuSku, ReadinessProbeHttpGetScheme, LivenessProbeHttpGetScheme, ReadinessProbeExecCommand, Command, CapabilityDrop, LivenessProbeExecCommand, CapabilityAdd, Protocol"), NewOutputProperties = ("Port, EnvironmentVariable, InstanceViewEvent, LivenessProbeHttpGetHttpHeader, ReadinessProbeHttpGetHttpHeader, VolumeMount, LimitsGpuSku, RequestsGpuSku, ReadinessProbeHttpGetScheme, LivenessProbeHttpGetScheme, ReadinessProbeExecCommand, Command, CapabilityDrop, LivenessProbeExecCommand, CapabilityAdd, Protocol. This parameter will be changed from single object to 'List'."))]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="The commands to execute within the container instance in exec form.")]
        [string[]]
        $Command,
        [Parameter(HelpMessage="The key value pairs dictionary in the config map to set in the container instance.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IConfigMapKeyValuePairs]
        $ConfigMapKeyValuePair,
        [Parameter(HelpMessage="The environment variables to set in the container instance.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IEnvironmentVariable[]]
        $EnvironmentVariable,
        [Parameter(HelpMessage="The name of the image used to create the container instance.")]
        [string]
        $Image,
        [Parameter(HelpMessage="The CPU limit of this container instance.")]
        [double]
        $LimitCpu,
        [Parameter(HelpMessage="The memory limit in GB of this container instance.")]
        [double]
        $LimitMemoryInGb,
        [Parameter(HelpMessage="The count of the GPU resource.")]
        [int]
        $LimitsGpuCount,
        [Parameter(HelpMessage="The SKU of the GPU resource.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku])]
        [string]
        $LimitsGpuSku,
        [Parameter(HelpMessage="The commands to execute within the container.")]
        [string[]]
        $LivenessProbeExecCommand,
        [Parameter(HelpMessage="The failure threshold.")]
        [int]
        $LivenessProbeFailureThreshold,
        [Parameter(HelpMessage="The HTTP headers for liveness probe.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IHttpHeader[]]
        $LivenessProbeHttpGetHttpHeader,
        [Parameter(HelpMessage="The path to probe.")]
        [string]
        $LivenessProbeHttpGetPath,
        [Parameter(HelpMessage="The port number to probe.")]
        [int]
        $LivenessProbeHttpGetPort,
        [Parameter(HelpMessage="The scheme.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme])]
        [string]
        $LivenessProbeHttpGetScheme,
        [Parameter(HelpMessage="The initial delay seconds.")]
        [int]
        $LivenessProbeInitialDelaySecond,
        [Parameter(HelpMessage="The period seconds.")]
        [int]
        $LivenessProbePeriodSecond,
        [Parameter(HelpMessage="The success threshold.")]
        [int]
        $LivenessProbeSuccessThreshold,
        [Parameter(HelpMessage="The timeout seconds.")]
        [int]
        $LivenessProbeTimeoutSecond,
        [Parameter(Mandatory, HelpMessage="The user-provided name of the container instance.")]
        [string]
        $Name,
        [Parameter(HelpMessage="The exposed ports on the container instance.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IContainerPort[]]
        $Port,
        [Parameter(HelpMessage="The commands to execute within the container.")]
        [string[]]
        $ReadinessProbeExecCommand,
        [Parameter(HelpMessage="The failure threshold.")]
        [int]
        $ReadinessProbeFailureThreshold,
        [Parameter(HelpMessage="The HTTP headers for readiness probe.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IHttpHeader[]]
        $ReadinessProbeHttpGetHttpHeader,
        [Parameter(HelpMessage="The path to probe.")]
        [string]
        $ReadinessProbeHttpGetPath,
        [Parameter(HelpMessage="The port number to probe.")]
        [int]
        $ReadinessProbeHttpGetPort,
        [Parameter(HelpMessage="The scheme.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme])]
        [string]
        $ReadinessProbeHttpGetScheme,
        [Parameter(HelpMessage="The initial delay seconds.")]
        [int]
        $ReadinessProbeInitialDelaySecond,
        [Parameter(HelpMessage="The period seconds.")]
        [int]
        $ReadinessProbePeriodSecond,
        [Parameter(HelpMessage="The success threshold.")]
        [int]
        $ReadinessProbeSuccessThreshold,
        [Parameter(HelpMessage="The timeout seconds.")]
        [int]
        $ReadinessProbeTimeoutSecond,
        [Parameter(HelpMessage="The CPU request of this container instance.")]
        [double]
        $RequestCpu,
        [Parameter(HelpMessage="The memory request in GB of this container instance.")]
        [double]
        $RequestMemoryInGb,
        [Parameter(HelpMessage="The count of the GPU resource.")]
        [int]
        $RequestsGpuCount,
        [Parameter(HelpMessage="The SKU of the GPU resource.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku])]
        [string]
        $RequestsGpuSku,
        [Parameter(HelpMessage="The volume mounts available to the container instance.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IVolumeMount[]]
        $VolumeMount
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.Container]::New()

        $Object.Command = $Command
        $Object.ConfigMapKeyValuePair = $ConfigMapKeyValuePair
        $Object.EnvironmentVariable = $EnvironmentVariable
        if($PSBoundParameters.ContainsKey("Image")) {
 
            $Object.Image = $Image
        }
        $Object.LimitCpu = $LimitCpu
        $Object.LimitMemoryInGb = $LimitMemoryInGb
        $Object.LimitsGpuCount = $LimitsGpuCount
        $Object.LimitsGpuSku = $LimitsGpuSku
        $Object.LivenessProbeExecCommand = $LivenessProbeExecCommand
        $Object.LivenessProbeFailureThreshold = $LivenessProbeFailureThreshold
        $Object.LivenessProbeHttpGetHttpHeader = $LivenessProbeHttpGetHttpHeader
        $Object.LivenessProbeHttpGetPath = $LivenessProbeHttpGetPath
        $Object.LivenessProbeHttpGetPort = $LivenessProbeHttpGetPort
        $Object.LivenessProbeHttpGetScheme = $LivenessProbeHttpGetScheme
        $Object.LivenessProbeInitialDelaySecond = $LivenessProbeInitialDelaySecond
        $Object.LivenessProbePeriodSecond = $LivenessProbePeriodSecond
        $Object.LivenessProbeSuccessThreshold = $LivenessProbeSuccessThreshold
        $Object.LivenessProbeTimeoutSecond = $LivenessProbeTimeoutSecond
        $Object.Name = $Name
        $Object.Port = $Port
        $Object.ReadinessProbeExecCommand = $ReadinessProbeExecCommand
        $Object.ReadinessProbeFailureThreshold = $ReadinessProbeFailureThreshold
        $Object.ReadinessProbeHttpGetHttpHeader = $ReadinessProbeHttpGetHttpHeader
        $Object.ReadinessProbeHttpGetPath = $ReadinessProbeHttpGetPath
        $Object.ReadinessProbeHttpGetPort = $ReadinessProbeHttpGetPort
        $Object.ReadinessProbeHttpGetScheme = $ReadinessProbeHttpGetScheme
        $Object.ReadinessProbeInitialDelaySecond = $ReadinessProbeInitialDelaySecond
        $Object.ReadinessProbePeriodSecond = $ReadinessProbePeriodSecond
        $Object.ReadinessProbeSuccessThreshold = $ReadinessProbeSuccessThreshold
        $Object.ReadinessProbeTimeoutSecond = $ReadinessProbeTimeoutSecond
        if($PSBoundParameters.ContainsKey("RequestCpu")) {
 
            $Object.RequestCpu = $RequestCpu
        }
        if($PSBoundParameters.ContainsKey("RequestMemoryInGb")) {
 
            $Object.RequestMemoryInGb = $RequestMemoryInGb
        }
        if($PSBoundParameters.ContainsKey("RequestsGpuCount")) {
 
            $Object.RequestsGpuCount = $RequestsGpuCount
        }
        if($PSBoundParameters.ContainsKey("RequestsGpuSku")) {
 
            $Object.RequestsGpuSku = $RequestsGpuSku
        }
        $Object.VolumeMount = $VolumeMount
        return $Object
    }
}

