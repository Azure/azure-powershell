
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
Description for Creates a new static site in an existing resource group, or updates an existing static site.
.Description
Description for Creates a new static site in an existing resource group, or updates an existing static site.
.Example
PS C:\> New-AzStaticWebApp -ResourceGroupName 'azure-rg-test' -Name 'staticweb-45asde' -Location 'Central US' -RepositoryUrl 'https://github.com/LucasYao93/blazor-starter' -RepositoryToken 'githubAccessToken' -Branch 'branch02' -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'Standard'

Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb-45asde Microsoft.Web/staticSites
.Example
PS C:\> New-AzStaticWebApp -ResourceGroupName 'azure-rg-test' -Name staticweb-pwsh01 -Location "Central US" -RepositoryToken  'xxxxxxxxxxxxxxxxx' -TemplateRepositoryUrl 'https://github.com/staticwebdev/blazor-starter' -ForkRepositoryDescription "Test template repository function of the azure static web." -ForkRepositoryName "test-blazor-starter" -ForkRepositoryOwner 'LucasYao93' -Branch 'main' -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'Standard'

Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb-pwsh01 Microsoft.Web/staticSites

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteArmResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

SKUCAPABILITY <ICapability[]>: Capabilities of the SKU, e.g., is traffic manager enabled
  [Name <String>]: Name of the SKU capability.
  [Reason <String>]: Reason of the SKU capability.
  [Value <String>]: Value of the SKU capability.
.Link
https://docs.microsoft.com/powershell/module/az.websites/new-azstaticwebapp
#>
function New-AzStaticWebApp {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteArmResource])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Path')]
    [System.String]
    # Name of the static site to create or update.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Resource Location.
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>false</code> if config file is locked for this static web app; otherwise, <code>true</code>.
    ${AllowConfigFileUpdate},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # A custom command to run during deployment of the Azure Functions API application.
    ${ApiBuildCommand},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # The path to the api code within the repository.
    ${ApiLocation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)
    ${AppArtifactLocation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # A custom command to run during deployment of the static content application.
    ${AppBuildCommand},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # The path to the app code within the repository.
    ${AppLocation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # The target branch in the repository.
    ${Branch},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.Int32]
    # Current number of instances assigned to the resource.
    ${Capacity},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Description of the newly generated repository.
    ${ForkRepositoryDescription},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Whether or not the newly generated repository is a private repository.
    # Defaults to false (i.e.
    # public).
    ${ForkRepositoryIsPrivate},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Name of the newly generated repository.
    ${ForkRepositoryName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Owner of the newly generated repository.
    ${ForkRepositoryOwner},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Github Action secret name override.
    ${GithubActionSecretNameOverride},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.ManagedServiceIdentityType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.ManagedServiceIdentityType]
    # Type of managed service identity.
    ${IdentityType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityUserAssignedIdentities]))]
    [System.Collections.Hashtable]
    # The list of user assigned identities associated with the resource.
    # The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    ${IdentityUserAssignedIdentity},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Kind of resource.
    ${Kind},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # The output path of the app after building.
    ${OutputLocation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # A user's github repository token.
    # This is used to setup the Github Actions workflow file and API secrets.
    ${RepositoryToken},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # URL for the repository of the static site.
    ${RepositoryUrl},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Skip Github Action workflow generation.
    ${SkipGithubActionWorkflowGeneration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ICapability[]]
    # Capabilities of the SKU, e.g., is traffic manager enabled
    # To construct, see NOTES section for SKUCAPABILITY properties and create a hash table.
    ${SkuCapability},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.Int32]
    # Default number of workers for this App Service plan SKU.
    ${SkuCapacityDefault},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.Int32]
    # Maximum number of Elastic workers for this App Service plan SKU.
    ${SkuCapacityElasticMaximum},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.Int32]
    # Maximum number of workers for this App Service plan SKU.
    ${SkuCapacityMaximum},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.Int32]
    # Minimum number of workers for this App Service plan SKU.
    ${SkuCapacityMinimum},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Available scale configurations for an App Service plan.
    ${SkuCapacityScaleType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Family code of the resource SKU.
    ${SkuFamily},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String[]]
    # Locations of the SKU.
    ${SkuLocation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Name of the resource SKU.
    ${SkuName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Size specifier of the resource SKU.
    ${SkuSize},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # Service tier of the resource SKU.
    ${SkuTier},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy]
    # State indicating whether staging environments are allowed or not allowed for a static web app.
    ${StagingEnvironmentPolicy},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [System.String]
    # URL of the template repository.
    # The newly generated repository will be based on this one.
    ${TemplateRepositoryUrl},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Runtime')]
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
            CreateExpanded = 'Az.Websites.private\New-AzStaticWebApp_CreateExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
