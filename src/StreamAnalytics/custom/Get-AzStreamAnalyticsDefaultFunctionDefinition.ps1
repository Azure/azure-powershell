
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
Retrieves the default definition of a function based on the parameters specified.
.Description
Retrieves the default definition of a function based on the parameters specified.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

FUNCTIONRETRIEVEDEFAULTDEFINITIONPARAMETER <IFunctionRetrieveDefaultDefinitionParameters>: Parameters used to specify the type of function to retrieve the default definition for.
  BindingType <String>: Indicates the function binding type.

INPUTOBJECT <IStreamAnalyticsIdentity>: Identity Parameter
  [ClusterName <String>]: The name of the cluster.
  [FunctionName <String>]: The name of the function.
  [Id <String>]: Resource identity path
  [InputName <String>]: The name of the input.
  [JobName <String>]: The name of the streaming job.
  [Location <String>]: The region in which to retrieve the subscription's quota information. You can find out which regions Azure Stream Analytics is supported in here: https://azure.microsoft.com/en-us/regions/
  [OutputName <String>]: The name of the output.
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [SubscriptionId <String>]: The ID of the target subscription.
  [TransformationName <String>]: The name of the transformation.
.Link
https://docs.microsoft.com/powershell/module/az.streamanalytics/get-azstreamanalyticsdefaultfunctiondefinition
#>
function Get-AzStreamAnalyticsDefaultFunctionDefinition {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction])]
[CmdletBinding(DefaultParameterSetName='RetrieveExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='RetrieveExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the function.
    ${Name},

    [Parameter(ParameterSetName='RetrieveExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${JobName},

    [Parameter(ParameterSetName='RetrieveExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='RetrieveExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='RetrieveExpanded', Mandatory)]
    [System.Management.Automation.ArgumentCompleter({"Microsoft.MachineLearning/WebService","Microsoft.MachineLearningServices"})]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${BindingType},

    [Parameter(ParameterSetName='RetrieveExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${Endpoint},

    [Parameter(ParameterSetName='RetrieveExpanded', Mandatory)]
    [System.Management.Automation.ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${UdfType},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)
  process {
      try {
        if ($BindingType -eq "Microsoft.MachineLearning/WebService")
        {
          $functionRetrieveDefaultDefinition = [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters]::New()
          $functionRetrieveDefaultDefinition.BindingType = $BindingType
          $functionRetrieveDefaultDefinition.BindingRetrievalPropertyEndpoint = $Endpoint
          $functionRetrieveDefaultDefinition.BindingRetrievalPropertyUdfType = $UdfType

        } elseif ($BindingType -eq "Microsoft.MachineLearningServices") {
          $functionRetrieveDefaultDefinition = [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningServiceFunctionRetrieveDefaultDefinitionParameters]::New()
          $functionRetrieveDefaultDefinition.BindingType = $BindingType
          $functionRetrieveDefaultDefinition.BindingRetrievalPropertyEndpoint = $Endpoint
          $functionRetrieveDefaultDefinition.BindingRetrievalPropertyUdfType = $UdfType
        } else {
          throw "The ($BindingType) binding type is not supported. Only supports Microsoft.MachineLearning/WebService or Microsoft.MachineLearningServices"
        }

        if ($PSBoundParameters.ContainsKey("BindingType")) {
          $PSBoundParameters.Remove("BindingType")
        } 
        if ($PSBoundParameters.ContainsKey("Endpoint")) {
          $PSBoundParameters.Remove("Endpoint")
        }  
        if ($PSBoundParameters.ContainsKey("UdfType")) {
          $PSBoundParameters.Remove("UdfType")
        }

        $PSBoundParameters.Add("FunctionRetrieveDefaultDefinitionParameter", $functionRetrieveDefaultDefinition);
        Az.StreamAnalytics.internal\Get-AzStreamAnalyticsDefaultFunctionDefinition @PSBoundParameters                         
      } catch {
          throw
      }
  }
}
