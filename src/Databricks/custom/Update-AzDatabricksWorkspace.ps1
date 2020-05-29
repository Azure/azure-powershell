
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
Updates a workspace.
.Description
Updates a workspace.
#>
function Update-AzDatabricksWorkspace {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspace])]
    [CmdletBinding(DefaultParameterSetName = 'UpdateExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory, HelpMessage = "The name of the workspace.")]
        [Alias('WorkspaceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
        [System.String]
        # The name of the workspace.
        ${Name},

        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'UpdateExpanded', HelpMessage = "The ID of the target subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline, HelpMessage = "Identity parameter. To construct, see NOTES section for INPUTOBJECT properties and create a hash table.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IDatabricksIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter(HelpMessage = "The encryption keySource (provider). Possible values (case-insensitive): Default, Microsoft.Keyvault")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource])]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource]
        # The encryption keySource (provider).
        # Possible values (case-insensitive): Default, Microsoft.Keyvault
        ${EncryptionKeySource},

        [Parameter(HelpMessage = "The URI (DNS name) of the Key Vault.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.String]
        # The Uri of KeyVault.
        ${EncryptionKeyVaultUri},

        [Parameter(HelpMessage = "The name of Key Vault key.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.String]
        # The name of KeyVault key.
        ${EncryptionKeyName},

        [Parameter(HelpMessage = "The version of KeyVault key.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.String]
        # The version of KeyVault key.
        ${EncryptionKeyVersion},

        [Parameter(HelpMessage = "Resource tags.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceUpdateTags]))]
        [System.Collections.Hashtable]
        # Resource tags.
        ${Tag},

        [Parameter(HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(HelpMessage = "Run the command as a job")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(HelpMessage = "Run the command asynchronously")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        try {
            $outBuffer = $null
            if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
                $PSBoundParameters['OutBuffer'] = 1
            }

            # 1. GET
            $PSBoundParameters.Remove('EncryptionKeySource') | Out-Null
            $PSBoundParameters.Remove('EncryptionKeyVaultUri') | Out-Null
            $PSBoundParameters.Remove('EncryptionKeyName') | Out-Null
            $PSBoundParameters.Remove('EncryptionKeyVersion') | Out-Null
            $PSBoundParameters.Remove('Tag') | Out-Null
            $PSBoundParameters.Remove('WhatIf') | Out-Null
            $PSBoundParameters.Remove('Confirm') | Out-Null

            $workspace = Get-AzDatabricksWorkspace @PSBoundParameters

            # 2. PUT
            $PSBoundParameters.Remove('InputObject') | Out-Null
            $PSBoundParameters.Remove('ResourceGroupName') | Out-Null
            $PSBoundParameters.Remove('Name') | Out-Null
            $PSBoundParameters.Remove('SubscriptionId') | Out-Null
            if ($true -eq $AsJob) {
                $PSBoundParameters.Add('AsJob', $true)
            }
            if ($null -ne $EncryptionKeySource) {
                $workspace.EncryptionKeySource = $EncryptionKeySource
            }
            if ($null -ne $EncryptionKeyVaultUri) {
                $workspace.EncryptionKeyVaultUri = $EncryptionKeyVaultUri
            }
            if ($null -ne $EncryptionKeyName) {
                $workspace.EncryptionKeyName = $EncryptionKeyName
            }
            if ($null -ne $EncryptionKeyVersion) {
                $workspace.EncryptionKeyVersion = $EncryptionKeyVersion
            }
            if ($null -ne $Tag) {
                $workspace.Tag = $Tag
            }

            if ($PSCmdlet.ShouldProcess("Databricks workspace $($workspace.Name)", "Create or update")) {
                Az.Databricks.private\New-AzDatabricksWorkspace_CreateViaIdentity -InputObject $workspace -Parameter $workspace @PSBoundParameters
            }
        }
        catch {
            throw
        }
    }
}
