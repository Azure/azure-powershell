
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
PS C:\> Update-AzStaticWebApp -ResourceGroupName 'resourceGroup' -Name 'staticweb00'

Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb00 Microsoft.Web/staticSites
.Example
PS C:\> Get-AzStaticWebApp -ResourceGroupName 'resourceGroup' -Name 'staticweb00' | Update-AzStaticWebApp

Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb00 Microsoft.Web/staticSites

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteArmResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IWebsitesIdentity>: Identity Parameter
  [Authprovider <String>]: The auth provider for the users.
  [DomainName <String>]: The custom domain name.
  [EnvironmentName <String>]: The stage site identifier.
  [FunctionAppName <String>]: Name of the function app registered with the static site build.
  [Id <String>]: Resource identity path
  [Location <String>]: Location where you plan to create the static site.
  [Name <String>]: Name of the static site.
  [PrivateEndpointConnectionName <String>]: Name of the private endpoint connection.
  [ResourceGroupName <String>]: Name of the resource group to which the resource belongs.
  [SubscriptionId <String>]: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  [Userid <String>]: The user id of the user.
.Link
https://docs.microsoft.com/powershell/module/az.websites/update-azstaticwebapp
#>
function Update-AzStaticWebApp {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteArmResource])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Path')]
    [System.String]
    # Name of the static site to create or update.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

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
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy]
    # State indicating whether staging environments are allowed or not allowed for a static web app.
    ${StagingEnvironmentPolicy},

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
            UpdateExpanded = 'Az.Websites.private\Update-AzStaticWebApp_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.Websites.private\Update-AzStaticWebApp_UpdateViaIdentityExpanded';
        }
        if (('UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
