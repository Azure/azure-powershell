
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
PS C:\> Get-AzStreamAnalyticsDefaultFunctionDefinition -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name mlsfunction-01 -BindingType Microsoft.MachineLearningServices -Endpoint "http://875da830-4d5f-44f1-b221-718a5f26a21d.eastus.azurecontainer.io/score"-UdfType Scalar

Name           Type ETag
----           ---- ----
mlsfunction-01

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
    [Parameter(ParameterSetName='Retrieve', Mandatory)]
    [Parameter(ParameterSetName='RetrieveExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${JobName},

    [Parameter(ParameterSetName='Retrieve', Mandatory)]
    [Parameter(ParameterSetName='RetrieveExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the function.
    ${Name},

    [Parameter(ParameterSetName='Retrieve', Mandatory)]
    [Parameter(ParameterSetName='RetrieveExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Retrieve')]
    [Parameter(ParameterSetName='RetrieveExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='RetrieveViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='RetrieveViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Retrieve', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='RetrieveViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters]
    # Parameters used to specify the type of function to retrieve the default definition for.
    # To construct, see NOTES section for FUNCTIONRETRIEVEDEFAULTDEFINITIONPARAMETER properties and create a hash table.
    ${FunctionRetrieveDefaultDefinitionParameter},

    [Parameter(ParameterSetName='RetrieveExpanded', Mandatory)]
    [Parameter(ParameterSetName='RetrieveViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # Indicates the function binding type.
    ${BindingType},

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
            Retrieve = 'Az.StreamAnalytics.private\Get-AzStreamAnalyticsDefaultFunctionDefinition_Retrieve';
            RetrieveExpanded = 'Az.StreamAnalytics.private\Get-AzStreamAnalyticsDefaultFunctionDefinition_RetrieveExpanded';
            RetrieveViaIdentity = 'Az.StreamAnalytics.private\Get-AzStreamAnalyticsDefaultFunctionDefinition_RetrieveViaIdentity';
            RetrieveViaIdentityExpanded = 'Az.StreamAnalytics.private\Get-AzStreamAnalyticsDefaultFunctionDefinition_RetrieveViaIdentityExpanded';
        }
        if (('Retrieve', 'RetrieveExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Lists all of the available Stream Analytics related operations.
.Description
Lists all of the available Stream Analytics related operations.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOperation
.Link
https://docs.microsoft.com/powershell/module/az.streamanalytics/get-azstreamanalyticsoperation
#>
function Get-AzStreamAnalyticsOperation {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOperation])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
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
            List = 'Az.StreamAnalytics.private\Get-AzStreamAnalyticsOperation_List';
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
Creates an input or replaces an already existing input under an existing streaming job.
.Description
Creates an input or replaces an already existing input under an existing streaming job.
.Example
PS C:\> New-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name input-01 -File .\test\template-json\EventHub.json

Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 6c9f5122-44b9-45bf-81c9-5349a9dd8851
.Example
PS C:\> New-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name input-01 -File .\test\template-json\IotHub.json

Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 6c9f5122-44b9-45bf-81c9-5349a9dd8851

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUT <IInput>: An input object, containing all information associated with the named input. All inputs are contained under a streaming job.
  [ETag <String>]: 
  [Property <IInputProperties>]: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
    Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
    [Compression <ICompression>]: Describes how input data is compressed
      Type <String>: 
    [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
    [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
      Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.

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

PROPERTY <IInputProperties>: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
  Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
  [Compression <ICompression>]: Describes how input data is compressed
    Type <String>: 
  [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
  [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
    Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
.Link
https://docs.microsoft.com/powershell/module/az.streamanalytics/new-azstreamanalyticsinput
#>
function New-AzStreamAnalyticsInput {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput])]
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
    [Alias('InputName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the input.
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
    # The ETag of the input.
    # Omit this value to always overwrite the current input.
    # Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.
    ${IfMatch},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Header')]
    [System.String]
    # Set to '*' to allow a new input to be created, but to prevent updating an existing input.
    # Other values will result in a 412 Pre-condition Failed response.
    ${IfNoneMatch},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput]
    # An input object, containing all information associated with the named input.
    # All inputs are contained under a streaming job.
    # To construct, see NOTES section for INPUT properties and create a hash table.
    ${Input},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInputProperties]
    # The properties that are associated with an input.
    # Required on PUT (CreateOrReplace) requests.
    # To construct, see NOTES section for PROPERTY properties and create a hash table.
    ${Property},

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
            Create = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsInput_Create';
            CreateExpanded = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsInput_CreateExpanded';
            CreateViaIdentity = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsInput_CreateViaIdentity';
            CreateViaIdentityExpanded = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsInput_CreateViaIdentityExpanded';
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
Creates a streaming job or replaces an already existing streaming job.
.Description
Creates a streaming job or replaces an already existing streaming job.
.Example
PS C:\> New-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-02-pwsh -Location westcentralus -SkuName Standard

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs a687c464-82ce-45cc-b88a-1f72ba2b1dc2

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

FUNCTION <IFunction[]>: A list of one or more functions for the streaming job. The name property for each function is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual transformation.
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

INPUT <IInput[]>: A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual input.
  [ETag <String>]: 
  [Property <IInputProperties>]: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
    Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
    [Compression <ICompression>]: Describes how input data is compressed
      Type <String>: 
    [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
    [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
      Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.

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

OUTPUT <IOutput[]>: A list of one or more outputs for the streaming job. The name property for each output is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual output.
  [Datasource <IOutputDataSource>]: Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
    Type <String>: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
  [ETag <String>]: 
  [SerializationType <EventSerializationType?>]: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
  [SizeWindow <Single?>]: 
  [TimeWindow <String>]: 

STREAMINGJOB <IStreamingJob>: A streaming job object, containing all information associated with the named streaming job.
  [Location <String>]: The geo-location where the resource lives
  [Tag <ITrackedResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [ClusterId <String>]: The resource id of cluster.
  [CompatibilityLevel <CompatibilityLevel?>]: Controls certain runtime behaviors of the streaming job.
  [ContentStoragePolicy <ContentStoragePolicy?>]: Valid values are JobStorageAccount and SystemAccount. If set to JobStorageAccount, this requires the user to also specify jobStorageAccount property. .
  [DataLocale <String>]: The data locale of the stream analytics job. Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx. Defaults to 'en-US' if none specified.
  [ETag <String>]: 
  [EventsLateArrivalMaxDelayInSecond <Int32?>]: The maximum tolerable delay in seconds where events arriving late could be included.  Supported range is -1 to 1814399 (20.23:59:59 days) and -1 is used to specify wait indefinitely. If the property is absent, it is interpreted to have a value of -1.
  [EventsOutOfOrderMaxDelayInSecond <Int32?>]: The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.
  [EventsOutOfOrderPolicy <EventsOutOfOrderPolicy?>]: Indicates the policy to apply to events that arrive out of order in the input event stream.
  [ExternalContainer <String>]: 
  [ExternalPath <String>]: 
  [Function <IFunction[]>]: A list of one or more functions for the streaming job. The name property for each function is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual transformation.
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
  [IdentityPrincipalId <String>]: 
  [IdentityTenantId <String>]: 
  [IdentityType <String>]: 
  [Input <IInput[]>]: A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual input.
    [ETag <String>]: 
    [Property <IInputProperties>]: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
      Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
      [Compression <ICompression>]: Describes how input data is compressed
        Type <String>: 
      [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
      [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
        Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
  [JobStorageAccountAuthenticationMode <AuthenticationMode?>]: Authentication Mode.
  [JobStorageAccountKey <String>]: The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  [JobStorageAccountName <String>]: The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  [JobType <JobType?>]: Describes the type of the job. Valid modes are `Cloud` and 'Edge'.
  [Output <IOutput[]>]: A list of one or more outputs for the streaming job. The name property for each output is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual output.
    [Datasource <IOutputDataSource>]: Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
      Type <String>: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
    [ETag <String>]: 
    [SerializationType <EventSerializationType?>]: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
    [SizeWindow <Single?>]: 
    [TimeWindow <String>]: 
  [OutputErrorPolicy <OutputErrorPolicy?>]: Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to being malformed (missing column values, column values of wrong type or size).
  [OutputStartMode <OutputStartMode?>]: This property should only be utilized when it is desired that the job be started immediately upon creation. Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property, or start from the last event output time.
  [OutputStartTime <DateTime?>]: Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null to indicate that the output event stream will start whenever the streaming job is started. This property must have a value if outputStartMode is set to CustomTime.
  [Query <String>]: Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
  [SkuName <StreamingJobSkuName?>]: The name of the SKU. Required on PUT (CreateOrReplace) requests.
  [StorageAccountKey <String>]: The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  [StorageAccountName <String>]: The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  [StreamingUnit <Int32?>]: Specifies the number of streaming units that the streaming job uses.
  [TransformationETag <String>]: 
.Link
https://docs.microsoft.com/powershell/module/az.streamanalytics/new-azstreamanalyticsjob
#>
function New-AzStreamAnalyticsJob {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
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
    # The ETag of the streaming job.
    # Omit this value to always overwrite the current record set.
    # Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.
    ${IfMatch},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Header')]
    [System.String]
    # Set to '*' to allow a new streaming job to be created, but to prevent updating an existing record set.
    # Other values will result in a 412 Pre-condition Failed response.
    ${IfNoneMatch},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob]
    # A streaming job object, containing all information associated with the named streaming job.
    # To construct, see NOTES section for STREAMINGJOB properties and create a hash table.
    ${StreamingJob},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The resource id of cluster.
    ${ClusterId},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel]
    # Controls certain runtime behaviors of the streaming job.
    ${CompatibilityLevel},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy]
    # Valid values are JobStorageAccount and SystemAccount.
    # If set to JobStorageAccount, this requires the user to also specify jobStorageAccount property.
    # .
    ${ContentStoragePolicy},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The data locale of the stream analytics job.
    # Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx.
    # Defaults to 'en-US' if none specified.
    ${DataLocale},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.Int32]
    # The maximum tolerable delay in seconds where events arriving late could be included.
    # Supported range is -1 to 1814399 (20.23:59:59 days) and -1 is used to specify wait indefinitely.
    # If the property is absent, it is interpreted to have a value of -1.
    ${EventsLateArrivalMaxDelayInSecond},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.Int32]
    # The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.
    ${EventsOutOfOrderMaxDelayInSecond},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy]
    # Indicates the policy to apply to events that arrive out of order in the input event stream.
    ${EventsOutOfOrderPolicy},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${ExternalContainer},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${ExternalPath},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction[]]
    # A list of one or more functions for the streaming job.
    # The name property for each function is required when specifying this property in a PUT request.
    # This property cannot be modify via a PATCH operation.
    # You must use the PATCH API available for the individual transformation.
    # To construct, see NOTES section for FUNCTION properties and create a hash table.
    ${Function},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${IdentityPrincipalId},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${IdentityTenantId},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${IdentityType},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput[]]
    # A list of one or more inputs to the streaming job.
    # The name property for each input is required when specifying this property in a PUT request.
    # This property cannot be modify via a PATCH operation.
    # You must use the PATCH API available for the individual input.
    # To construct, see NOTES section for INPUT properties and create a hash table.
    ${Input},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode]
    # Authentication Mode.
    ${JobStorageAccountAuthenticationMode},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The account key for the Azure Storage account.
    # Required on PUT (CreateOrReplace) requests.
    ${JobStorageAccountKey},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The name of the Azure Storage account.
    # Required on PUT (CreateOrReplace) requests.
    ${JobStorageAccountName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType]
    # Describes the type of the job.
    # Valid modes are `Cloud` and 'Edge'.
    ${JobType},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput[]]
    # A list of one or more outputs for the streaming job.
    # The name property for each output is required when specifying this property in a PUT request.
    # This property cannot be modify via a PATCH operation.
    # You must use the PATCH API available for the individual output.
    # To construct, see NOTES section for OUTPUT properties and create a hash table.
    ${Output},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy]
    # Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to being malformed (missing column values, column values of wrong type or size).
    ${OutputErrorPolicy},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode]
    # This property should only be utilized when it is desired that the job be started immediately upon creation.
    # Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property, or start from the last event output time.
    ${OutputStartMode},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.DateTime]
    # Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null to indicate that the output event stream will start whenever the streaming job is started.
    # This property must have a value if outputStartMode is set to CustomTime.
    ${OutputStartTime},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # Specifies the query that will be run in the streaming job.
    # You can learn more about the Stream Analytics Query Language (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 .
    # Required on PUT (CreateOrReplace) requests.
    ${Query},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName]
    # The name of the SKU.
    # Required on PUT (CreateOrReplace) requests.
    ${SkuName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The account key for the Azure Storage account.
    # Required on PUT (CreateOrReplace) requests.
    ${StorageAccountKey},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The name of the Azure Storage account.
    # Required on PUT (CreateOrReplace) requests.
    ${StorageAccountName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.Int32]
    # Specifies the number of streaming units that the streaming job uses.
    ${StreamingUnit},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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
            Create = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsJob_Create';
            CreateExpanded = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsJob_CreateExpanded';
            CreateViaIdentity = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsJob_CreateViaIdentity';
            CreateViaIdentityExpanded = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsJob_CreateViaIdentityExpanded';
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
Creates an output or replaces an already existing output under an existing streaming job.
.Description
Creates an output or replaces an already existing output under an existing streaming job.
.Example
PS C:\> New-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name output-01 -File .\test\template-json\StroageAccount.json

Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs 3819fb65-07f5-4dc3-83e1-d3149596f8d0

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DATASOURCE <IOutputDataSource>: Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
  Type <String>: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.

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

OUTPUT <IOutput>: An output object, containing all information associated with the named output. All outputs are contained under a streaming job.
  [Datasource <IOutputDataSource>]: Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
    Type <String>: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
  [ETag <String>]: 
  [SerializationType <EventSerializationType?>]: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
  [SizeWindow <Single?>]: 
  [TimeWindow <String>]: 
.Link
https://docs.microsoft.com/powershell/module/az.streamanalytics/new-azstreamanalyticsoutput
#>
function New-AzStreamAnalyticsOutput {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput])]
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
    [Alias('OutputName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the output.
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
    # The ETag of the output.
    # Omit this value to always overwrite the current output.
    # Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.
    ${IfMatch},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Header')]
    [System.String]
    # Set to '*' to allow a new output to be created, but to prevent updating an existing output.
    # Other values will result in a 412 Pre-condition Failed response.
    ${IfNoneMatch},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput]
    # An output object, containing all information associated with the named output.
    # All outputs are contained under a streaming job.
    # To construct, see NOTES section for OUTPUT properties and create a hash table.
    ${Output},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource]
    # Describes the data source that output will be written to.
    # Required on PUT (CreateOrReplace) requests.
    # To construct, see NOTES section for DATASOURCE properties and create a hash table.
    ${Datasource},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType]
    # Indicates the type of serialization that the input or output uses.
    # Required on PUT (CreateOrReplace) requests.
    ${SerializationType},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.Single]
    # .
    ${SizeWindow},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${TimeWindow},

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
            Create = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsOutput_Create';
            CreateExpanded = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsOutput_CreateExpanded';
            CreateViaIdentity = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsOutput_CreateViaIdentity';
            CreateViaIdentityExpanded = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsOutput_CreateViaIdentityExpanded';
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
Tests if the information provided for a function is valid.
This can range from testing the connection to the underlying web service behind the function or making sure the function code provided is syntactically correct.
.Description
Tests if the information provided for a function is valid.
This can range from testing the connection to the underlying web service behind the function or making sure the function code provided is syntactically correct.
.Example
PS C:\> Test-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name mlsfunction-01

Status
------
TestSucceeded

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IResourceTestStatus
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
https://docs.microsoft.com/powershell/module/az.streamanalytics/test-azstreamanalyticsfunction
#>
function Test-AzStreamAnalyticsFunction {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IResourceTestStatus])]
[CmdletBinding(DefaultParameterSetName='TestExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Test', Mandatory)]
    [Parameter(ParameterSetName='TestExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${JobName},

    [Parameter(ParameterSetName='Test', Mandatory)]
    [Parameter(ParameterSetName='TestExpanded', Mandatory)]
    [Alias('FunctionName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the function.
    ${Name},

    [Parameter(ParameterSetName='Test', Mandatory)]
    [Parameter(ParameterSetName='TestExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Test')]
    [Parameter(ParameterSetName='TestExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='TestViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='TestViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Test', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='TestViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction]
    # A function object, containing all information associated with the named function.
    # All functions are contained under a streaming job.
    # To construct, see NOTES section for FUNCTION properties and create a hash table.
    ${Function},

    [Parameter(ParameterSetName='TestExpanded')]
    [Parameter(ParameterSetName='TestViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionConfiguration]
    # .
    # To construct, see NOTES section for FUNCTIONCONFIGURATIONPROPERTY properties and create a hash table.
    ${FunctionConfigurationProperty},

    [Parameter(ParameterSetName='TestExpanded')]
    [Parameter(ParameterSetName='TestViaIdentityExpanded')]
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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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
            Test = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsFunction_Test';
            TestExpanded = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsFunction_TestExpanded';
            TestViaIdentity = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsFunction_TestViaIdentity';
            TestViaIdentityExpanded = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsFunction_TestViaIdentityExpanded';
        }
        if (('Test', 'TestExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Tests whether an input’s datasource is reachable and usable by the Azure Stream Analytics service.
.Description
Tests whether an input’s datasource is reachable and usable by the Azure Stream Analytics service.
.Example
PS C:\> Test-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name input-01

Status
------
TestSucceeded

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IResourceTestStatus
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUT <IInput>: An input object, containing all information associated with the named input. All inputs are contained under a streaming job.
  [ETag <String>]: 
  [Property <IInputProperties>]: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
    Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
    [Compression <ICompression>]: Describes how input data is compressed
      Type <String>: 
    [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
    [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
      Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.

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

PROPERTY <IInputProperties>: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
  Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
  [Compression <ICompression>]: Describes how input data is compressed
    Type <String>: 
  [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
  [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
    Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
.Link
https://docs.microsoft.com/powershell/module/az.streamanalytics/test-azstreamanalyticsinput
#>
function Test-AzStreamAnalyticsInput {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IResourceTestStatus])]
[CmdletBinding(DefaultParameterSetName='TestExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Test', Mandatory)]
    [Parameter(ParameterSetName='TestExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${JobName},

    [Parameter(ParameterSetName='Test', Mandatory)]
    [Parameter(ParameterSetName='TestExpanded', Mandatory)]
    [Alias('InputName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the input.
    ${Name},

    [Parameter(ParameterSetName='Test', Mandatory)]
    [Parameter(ParameterSetName='TestExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Test')]
    [Parameter(ParameterSetName='TestExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='TestViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='TestViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Test', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='TestViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput]
    # An input object, containing all information associated with the named input.
    # All inputs are contained under a streaming job.
    # To construct, see NOTES section for INPUT properties and create a hash table.
    ${Input},

    [Parameter(ParameterSetName='TestExpanded')]
    [Parameter(ParameterSetName='TestViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInputProperties]
    # The properties that are associated with an input.
    # Required on PUT (CreateOrReplace) requests.
    # To construct, see NOTES section for PROPERTY properties and create a hash table.
    ${Property},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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
            Test = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsInput_Test';
            TestExpanded = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsInput_TestExpanded';
            TestViaIdentity = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsInput_TestViaIdentity';
            TestViaIdentityExpanded = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsInput_TestViaIdentityExpanded';
        }
        if (('Test', 'TestExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Tests whether an output’s datasource is reachable and usable by the Azure Stream Analytics service.
.Description
Tests whether an output’s datasource is reachable and usable by the Azure Stream Analytics service.
.Example
PS C:\> Test-AzStreamAnalyticsOutput -ResourceGroupName lucas-rg-test -JobName sajob-01-pwsh -Name output-01

Status
------
TestSucceeded

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IResourceTestStatus
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DATASOURCE <IOutputDataSource>: Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
  Type <String>: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.

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

OUTPUT <IOutput>: An output object, containing all information associated with the named output. All outputs are contained under a streaming job.
  [Datasource <IOutputDataSource>]: Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
    Type <String>: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
  [ETag <String>]: 
  [SerializationType <EventSerializationType?>]: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
  [SizeWindow <Single?>]: 
  [TimeWindow <String>]: 
.Link
https://docs.microsoft.com/powershell/module/az.streamanalytics/test-azstreamanalyticsoutput
#>
function Test-AzStreamAnalyticsOutput {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IResourceTestStatus])]
[CmdletBinding(DefaultParameterSetName='TestExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Test', Mandatory)]
    [Parameter(ParameterSetName='TestExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${JobName},

    [Parameter(ParameterSetName='Test', Mandatory)]
    [Parameter(ParameterSetName='TestExpanded', Mandatory)]
    [Alias('OutputName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the output.
    ${Name},

    [Parameter(ParameterSetName='Test', Mandatory)]
    [Parameter(ParameterSetName='TestExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Test')]
    [Parameter(ParameterSetName='TestExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='TestViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='TestViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Test', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='TestViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput]
    # An output object, containing all information associated with the named output.
    # All outputs are contained under a streaming job.
    # To construct, see NOTES section for OUTPUT properties and create a hash table.
    ${Output},

    [Parameter(ParameterSetName='TestExpanded')]
    [Parameter(ParameterSetName='TestViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource]
    # Describes the data source that output will be written to.
    # Required on PUT (CreateOrReplace) requests.
    # To construct, see NOTES section for DATASOURCE properties and create a hash table.
    ${Datasource},

    [Parameter(ParameterSetName='TestExpanded')]
    [Parameter(ParameterSetName='TestViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType]
    # Indicates the type of serialization that the input or output uses.
    # Required on PUT (CreateOrReplace) requests.
    ${SerializationType},

    [Parameter(ParameterSetName='TestExpanded')]
    [Parameter(ParameterSetName='TestViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.Single]
    # .
    ${SizeWindow},

    [Parameter(ParameterSetName='TestExpanded')]
    [Parameter(ParameterSetName='TestViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${TimeWindow},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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
            Test = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsOutput_Test';
            TestExpanded = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsOutput_TestExpanded';
            TestViaIdentity = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsOutput_TestViaIdentity';
            TestViaIdentityExpanded = 'Az.StreamAnalytics.private\Test-AzStreamAnalyticsOutput_TestViaIdentityExpanded';
        }
        if (('Test', 'TestExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Updates an existing function under an existing streaming job.
This can be used to partially update (ie.
update one or two properties) a function without affecting the rest the job or function definition.
.Description
Updates an existing function under an existing streaming job.
This can be used to partially update (ie.
update one or two properties) a function without affecting the rest the job or function definition.
.Example
PS C:\> Update-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name function-01 -File .\test\template-json\Function_JavascriptUdf.json

Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions 3206c07f-ed77-4e24-b101-7aa2ac1f3cef
.Example
PS C:\> Get-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name function-01 | Update-AzStreamAnalyticsFunction -File .\test\template-json\MachineLearningServices.json

Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions 3206c07f-ed77-4e24-b101-7aa2ac1f3cef

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
https://docs.microsoft.com/powershell/module/az.streamanalytics/update-azstreamanalyticsfunction
#>
function Update-AzStreamAnalyticsFunction {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${JobName},

    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('FunctionName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the function.
    ${Name},

    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Update')]
    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
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

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction]
    # A function object, containing all information associated with the named function.
    # All functions are contained under a streaming job.
    # To construct, see NOTES section for FUNCTION properties and create a hash table.
    ${Function},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionConfiguration]
    # .
    # To construct, see NOTES section for FUNCTIONCONFIGURATIONPROPERTY properties and create a hash table.
    ${FunctionConfigurationProperty},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
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
            Update = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsFunction_Update';
            UpdateExpanded = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsFunction_UpdateExpanded';
            UpdateViaIdentity = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsFunction_UpdateViaIdentity';
            UpdateViaIdentityExpanded = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsFunction_UpdateViaIdentityExpanded';
        }
        if (('Update', 'UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Updates an existing input under an existing streaming job.
This can be used to partially update (ie.
update one or two properties) an input without affecting the rest the job or input definition.
.Description
Updates an existing input under an existing streaming job.
This can be used to partially update (ie.
update one or two properties) an input without affecting the rest the job or input definition.
.Example
PS C:\> Update-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name input-01 -File .\test\template-json\EventHub.json

Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 72d568f9-f4be-455b-bab8-c31e811a0469
.Example
PS C:\> Get-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name input-01 | Update-AzStreamAnalyticsInput -File .\test\template-json\IotHub.json

Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 29787d67-5274-4f31-a190-30182ebcecda

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUT <IInput>: An input object, containing all information associated with the named input. All inputs are contained under a streaming job.
  [ETag <String>]: 
  [Property <IInputProperties>]: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
    Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
    [Compression <ICompression>]: Describes how input data is compressed
      Type <String>: 
    [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
    [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
      Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.

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

PROPERTY <IInputProperties>: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
  Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
  [Compression <ICompression>]: Describes how input data is compressed
    Type <String>: 
  [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
  [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
    Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
.Link
https://docs.microsoft.com/powershell/module/az.streamanalytics/update-azstreamanalyticsinput
#>
function Update-AzStreamAnalyticsInput {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${JobName},

    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('InputName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the input.
    ${Name},

    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Update')]
    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Header')]
    [System.String]
    # The ETag of the input.
    # Omit this value to always overwrite the current input.
    # Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.
    ${IfMatch},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput]
    # An input object, containing all information associated with the named input.
    # All inputs are contained under a streaming job.
    # To construct, see NOTES section for INPUT properties and create a hash table.
    ${Input},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInputProperties]
    # The properties that are associated with an input.
    # Required on PUT (CreateOrReplace) requests.
    # To construct, see NOTES section for PROPERTY properties and create a hash table.
    ${Property},

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
            Update = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsInput_Update';
            UpdateExpanded = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsInput_UpdateExpanded';
            UpdateViaIdentity = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsInput_UpdateViaIdentity';
            UpdateViaIdentityExpanded = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsInput_UpdateViaIdentityExpanded';
        }
        if (('Update', 'UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Updates an existing streaming job.
This can be used to partially update (ie.
update one or two properties) a streaming job without affecting the rest the job definition.
.Description
Updates an existing streaming job.
This can be used to partially update (ie.
update one or two properties) a streaming job without affecting the rest the job definition.
.Example
PS C:\> Update-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-01-pwsh -EventsLateArrivalMaxDelayInSecond 13 -EventsOutOfOrderMaxDelayInSecond 21

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-01-pwsh Microsoft.StreamAnalytics/streamingjobs a5eb4626-ab6c-45bb-be0d-86593ad92021
.Example
PS C:\> Get-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-01-pwsh | Update-AzStreamAnalyticsJob -EventsLateArrivalMaxDelayInSecond 13 -EventsOutOfOrderMaxDelayInSecond 21

Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-01-pwsh Microsoft.StreamAnalytics/streamingjobs c1aa3d2a-1784-4586-926f-df5bfd084e31

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

FUNCTION <IFunction[]>: A list of one or more functions for the streaming job. The name property for each function is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual transformation.
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

INPUT <IInput[]>: A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual input.
  [ETag <String>]: 
  [Property <IInputProperties>]: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
    Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
    [Compression <ICompression>]: Describes how input data is compressed
      Type <String>: 
    [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
    [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
      Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.

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

OUTPUT <IOutput[]>: A list of one or more outputs for the streaming job. The name property for each output is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual output.
  [Datasource <IOutputDataSource>]: Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
    Type <String>: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
  [ETag <String>]: 
  [SerializationType <EventSerializationType?>]: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
  [SizeWindow <Single?>]: 
  [TimeWindow <String>]: 

STREAMINGJOB <IStreamingJob>: A streaming job object, containing all information associated with the named streaming job.
  [Location <String>]: The geo-location where the resource lives
  [Tag <ITrackedResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [ClusterId <String>]: The resource id of cluster.
  [CompatibilityLevel <CompatibilityLevel?>]: Controls certain runtime behaviors of the streaming job.
  [ContentStoragePolicy <ContentStoragePolicy?>]: Valid values are JobStorageAccount and SystemAccount. If set to JobStorageAccount, this requires the user to also specify jobStorageAccount property. .
  [DataLocale <String>]: The data locale of the stream analytics job. Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx. Defaults to 'en-US' if none specified.
  [ETag <String>]: 
  [EventsLateArrivalMaxDelayInSecond <Int32?>]: The maximum tolerable delay in seconds where events arriving late could be included.  Supported range is -1 to 1814399 (20.23:59:59 days) and -1 is used to specify wait indefinitely. If the property is absent, it is interpreted to have a value of -1.
  [EventsOutOfOrderMaxDelayInSecond <Int32?>]: The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.
  [EventsOutOfOrderPolicy <EventsOutOfOrderPolicy?>]: Indicates the policy to apply to events that arrive out of order in the input event stream.
  [ExternalContainer <String>]: 
  [ExternalPath <String>]: 
  [Function <IFunction[]>]: A list of one or more functions for the streaming job. The name property for each function is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual transformation.
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
  [IdentityPrincipalId <String>]: 
  [IdentityTenantId <String>]: 
  [IdentityType <String>]: 
  [Input <IInput[]>]: A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual input.
    [ETag <String>]: 
    [Property <IInputProperties>]: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
      Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
      [Compression <ICompression>]: Describes how input data is compressed
        Type <String>: 
      [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
      [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
        Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
  [JobStorageAccountAuthenticationMode <AuthenticationMode?>]: Authentication Mode.
  [JobStorageAccountKey <String>]: The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  [JobStorageAccountName <String>]: The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  [JobType <JobType?>]: Describes the type of the job. Valid modes are `Cloud` and 'Edge'.
  [Output <IOutput[]>]: A list of one or more outputs for the streaming job. The name property for each output is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual output.
    [Datasource <IOutputDataSource>]: Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
      Type <String>: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
    [ETag <String>]: 
    [SerializationType <EventSerializationType?>]: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
    [SizeWindow <Single?>]: 
    [TimeWindow <String>]: 
  [OutputErrorPolicy <OutputErrorPolicy?>]: Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to being malformed (missing column values, column values of wrong type or size).
  [OutputStartMode <OutputStartMode?>]: This property should only be utilized when it is desired that the job be started immediately upon creation. Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property, or start from the last event output time.
  [OutputStartTime <DateTime?>]: Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null to indicate that the output event stream will start whenever the streaming job is started. This property must have a value if outputStartMode is set to CustomTime.
  [Query <String>]: Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
  [SkuName <StreamingJobSkuName?>]: The name of the SKU. Required on PUT (CreateOrReplace) requests.
  [StorageAccountKey <String>]: The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  [StorageAccountName <String>]: The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  [StreamingUnit <Int32?>]: Specifies the number of streaming units that the streaming job uses.
  [TransformationETag <String>]: 
.Link
https://docs.microsoft.com/powershell/module/az.streamanalytics/update-azstreamanalyticsjob
#>
function Update-AzStreamAnalyticsJob {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${Name},

    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Update')]
    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Header')]
    [System.String]
    # The ETag of the streaming job.
    # Omit this value to always overwrite the current record set.
    # Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.
    ${IfMatch},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob]
    # A streaming job object, containing all information associated with the named streaming job.
    # To construct, see NOTES section for STREAMINGJOB properties and create a hash table.
    ${StreamingJob},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The resource id of cluster.
    ${ClusterId},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel]
    # Controls certain runtime behaviors of the streaming job.
    ${CompatibilityLevel},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy]
    # Valid values are JobStorageAccount and SystemAccount.
    # If set to JobStorageAccount, this requires the user to also specify jobStorageAccount property.
    # .
    ${ContentStoragePolicy},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The data locale of the stream analytics job.
    # Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx.
    # Defaults to 'en-US' if none specified.
    ${DataLocale},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.Int32]
    # The maximum tolerable delay in seconds where events arriving late could be included.
    # Supported range is -1 to 1814399 (20.23:59:59 days) and -1 is used to specify wait indefinitely.
    # If the property is absent, it is interpreted to have a value of -1.
    ${EventsLateArrivalMaxDelayInSecond},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.Int32]
    # The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.
    ${EventsOutOfOrderMaxDelayInSecond},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy]
    # Indicates the policy to apply to events that arrive out of order in the input event stream.
    ${EventsOutOfOrderPolicy},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${ExternalContainer},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${ExternalPath},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction[]]
    # A list of one or more functions for the streaming job.
    # The name property for each function is required when specifying this property in a PUT request.
    # This property cannot be modify via a PATCH operation.
    # You must use the PATCH API available for the individual transformation.
    # To construct, see NOTES section for FUNCTION properties and create a hash table.
    ${Function},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${IdentityPrincipalId},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${IdentityTenantId},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${IdentityType},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput[]]
    # A list of one or more inputs to the streaming job.
    # The name property for each input is required when specifying this property in a PUT request.
    # This property cannot be modify via a PATCH operation.
    # You must use the PATCH API available for the individual input.
    # To construct, see NOTES section for INPUT properties and create a hash table.
    ${Input},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode]
    # Authentication Mode.
    ${JobStorageAccountAuthenticationMode},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The account key for the Azure Storage account.
    # Required on PUT (CreateOrReplace) requests.
    ${JobStorageAccountKey},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The name of the Azure Storage account.
    # Required on PUT (CreateOrReplace) requests.
    ${JobStorageAccountName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType]
    # Describes the type of the job.
    # Valid modes are `Cloud` and 'Edge'.
    ${JobType},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput[]]
    # A list of one or more outputs for the streaming job.
    # The name property for each output is required when specifying this property in a PUT request.
    # This property cannot be modify via a PATCH operation.
    # You must use the PATCH API available for the individual output.
    # To construct, see NOTES section for OUTPUT properties and create a hash table.
    ${Output},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy]
    # Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to being malformed (missing column values, column values of wrong type or size).
    ${OutputErrorPolicy},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode]
    # This property should only be utilized when it is desired that the job be started immediately upon creation.
    # Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property, or start from the last event output time.
    ${OutputStartMode},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.DateTime]
    # Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null to indicate that the output event stream will start whenever the streaming job is started.
    # This property must have a value if outputStartMode is set to CustomTime.
    ${OutputStartTime},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # Specifies the query that will be run in the streaming job.
    # You can learn more about the Stream Analytics Query Language (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 .
    # Required on PUT (CreateOrReplace) requests.
    ${Query},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName]
    # The name of the SKU.
    # Required on PUT (CreateOrReplace) requests.
    ${SkuName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The account key for the Azure Storage account.
    # Required on PUT (CreateOrReplace) requests.
    ${StorageAccountKey},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # The name of the Azure Storage account.
    # Required on PUT (CreateOrReplace) requests.
    ${StorageAccountName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.Int32]
    # Specifies the number of streaming units that the streaming job uses.
    ${StreamingUnit},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

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
            Update = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsJob_Update';
            UpdateExpanded = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsJob_UpdateExpanded';
            UpdateViaIdentity = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsJob_UpdateViaIdentity';
            UpdateViaIdentityExpanded = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsJob_UpdateViaIdentityExpanded';
        }
        if (('Update', 'UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Updates an existing output under an existing streaming job.
This can be used to partially update (ie.
update one or two properties) an output without affecting the rest the job or output definition.
.Description
Updates an existing output under an existing streaming job.
This can be used to partially update (ie.
update one or two properties) an output without affecting the rest the job or output definition.
.Example
PS C:\> Update-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name output-01 -File .\test\template-json\StroageAccount.json

Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs d5a980c2-07cc-4dc7-8dd3-21d27ec1212d
.Example
PS C:\>  Get-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name output-01| Update-AzStreamAnalyticsOutput -File .\test\template-json\StroageAccount.json

Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs 6bbe2f2d-519a-4cd9-9fdb-5311ea2617bc

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DATASOURCE <IOutputDataSource>: Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
  Type <String>: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.

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

OUTPUT <IOutput>: An output object, containing all information associated with the named output. All outputs are contained under a streaming job.
  [Datasource <IOutputDataSource>]: Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
    Type <String>: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
  [ETag <String>]: 
  [SerializationType <EventSerializationType?>]: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
  [SizeWindow <Single?>]: 
  [TimeWindow <String>]: 
.Link
https://docs.microsoft.com/powershell/module/az.streamanalytics/update-azstreamanalyticsoutput
#>
function Update-AzStreamAnalyticsOutput {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${JobName},

    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('OutputName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the output.
    ${Name},

    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Update')]
    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Header')]
    [System.String]
    # The ETag of the output.
    # Omit this value to always overwrite the current output.
    # Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.
    ${IfMatch},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput]
    # An output object, containing all information associated with the named output.
    # All outputs are contained under a streaming job.
    # To construct, see NOTES section for OUTPUT properties and create a hash table.
    ${Output},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource]
    # Describes the data source that output will be written to.
    # Required on PUT (CreateOrReplace) requests.
    # To construct, see NOTES section for DATASOURCE properties and create a hash table.
    ${Datasource},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType])]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType]
    # Indicates the type of serialization that the input or output uses.
    # Required on PUT (CreateOrReplace) requests.
    ${SerializationType},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.Single]
    # .
    ${SizeWindow},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Body')]
    [System.String]
    # .
    ${TimeWindow},

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
            Update = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsOutput_Update';
            UpdateExpanded = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsOutput_UpdateExpanded';
            UpdateViaIdentity = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsOutput_UpdateViaIdentity';
            UpdateViaIdentityExpanded = 'Az.StreamAnalytics.private\Update-AzStreamAnalyticsOutput_UpdateViaIdentityExpanded';
        }
        if (('Update', 'UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
