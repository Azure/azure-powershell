
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
Creates a function or replaces an already existing function under an existing streaming job.
.Description
Creates a function or replaces an already existing function under an existing streaming job.
.Example
PS C:\> New-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name function-01 -File .\test\template-json\Function_JavascriptUdf.json

Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions 7bbd6ccd-c7a4-4910-b2ae-a3eae19d9b18

.Example
PS C:\> New-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name function-01 -File .\test\template-json\MachineLearningServices.json

Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions 7bbd6ccd-c7a4-4910-b2ae-a3eae19d9b18

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

FUNCTION <IFunction>: A function object, containing all information associated with the named function. All functions are contained under a streaming job.
  [ConfigurationProperty <IFunctionConfiguration>]: 
    [Binding <IFunctionBinding>]: The physical binding of the function. For example, in the Azure Machine Learning web service’s case, this describes the endpoint.
      Type <String>: Indicates the function binding type.
    [Input <IFunctionInput[]>]: 
      [DataType <String>]: The (Azure Stream Analytics supported) data type of the function input parameter. A list of valid Azure Stream Analytics data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
      [IsConfigurationParameter <Boolean?>]: A flag indicating if the parameter is a configuration parameter. True if this input parameter is expected to be a constant. Default is false.
    [Output <IFunctionOutput>]: Describes the output of a function.
      [DataType <String>]: The (Azure Stream Analytics supported) data type of the function output. A list of valid Azure Stream Analytics data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
  [ETag <String>]: 
  [PropertiesType <String>]: Indicates the type of function.

FUNCTIONCONFIGURATIONPROPERTY <IFunctionConfiguration>: .
  [Binding <IFunctionBinding>]: The physical binding of the function. For example, in the Azure Machine Learning web service’s case, this describes the endpoint.
    Type <String>: Indicates the function binding type.
  [Input <IFunctionInput[]>]: 
    [DataType <String>]: The (Azure Stream Analytics supported) data type of the function input parameter. A list of valid Azure Stream Analytics data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
    [IsConfigurationParameter <Boolean?>]: A flag indicating if the parameter is a configuration parameter. True if this input parameter is expected to be a constant. Default is false.
  [Output <IFunctionOutput>]: Describes the output of a function.
    [DataType <String>]: The (Azure Stream Analytics supported) data type of the function output. A list of valid Azure Stream Analytics data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx

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
https://docs.microsoft.com/powershell/module/az.streamanalytics/new-azstreamanalyticsfunction
#>
function New-AzStreamAnalyticsFunction {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${JobName},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Alias('FunctionName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the function.
    ${Name},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Create')]
    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Header')]
    [System.String]
    # The ETag of the function.
    # Omit this value to always overwrite the current function.
    # Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.
    ${IfMatch},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Header')]
    [System.String]
    # Set to '*' to allow a new function to be created, but to prevent updating an existing function.
    # Other values will result in a 412 Pre-condition Failed response.
    ${IfNoneMatch},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction]
    # A function object, containing all information associated with the named function.
    # All functions are contained under a streaming job.
    # To construct, see NOTES section for FUNCTION properties and create a hash table.
    ${Function},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionConfiguration]
    # .
    # To construct, see NOTES section for FUNCTIONCONFIGURATIONPROPERTY properties and create a hash table.
    ${FunctionConfigurationProperty},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # Indicates the type of function.
    ${PropertiesType},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Create = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsFunction_Create';
            CreateExpanded = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsFunction_CreateExpanded';
            CreateViaIdentity = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsFunction_CreateViaIdentity';
            CreateViaIdentityExpanded = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsFunction_CreateViaIdentityExpanded';
        }
        if (('Create', 'CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
