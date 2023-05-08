
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
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20230201.IWorkspace])]
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

        [Parameter(HelpMessage = "Prepare the workspace for encryption. Enables the Managed Identity for managed storage account.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Prepare the workspace for encryption. Enables the Managed Identity for managed storage account.
        ${PrepareEncryption},

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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.String]
        # The name of KeyVault key.
        ${KeyVaultKeyName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.String]
        # The version of KeyVault key.
        ${KeyVaultKeyVersion},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.String]
        # The Uri of KeyVault.
        ${KeyVaultUri},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.String]
        # The value which should be used for this field.
        ${AmlWorkspaceId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.String]
        # The SKU tier.
        ${SkuTier},

        [Parameter(HelpMessage = "Resource tags.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20230201.IWorkspaceUpdateTags]))]
        [System.Collections.Hashtable]
        # Resource tags.
        ${Tag},

        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.RequiredNsgRules])]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.RequiredNsgRules]
        # Gets or sets a value indicating whether data plane (clusters) to control plane communication happen over private endpoint.
        # Supported values are 'AllRules' and 'NoAzureDatabricksRules'.
        # 'NoAzureServiceRules' value is for internal use only.
        ${RequiredNsgRule},

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
            # 1. GET
            $hasPrepareEncryption = $PSBoundParameters.Remove('PrepareEncryption')
            $hasEncryptionKeySource = $PSBoundParameters.Remove('EncryptionKeySource')
            $hasEncryptionKeyVaultUri = $PSBoundParameters.Remove('EncryptionKeyVaultUri')
            $hasEncryptionKeyName = $PSBoundParameters.Remove('EncryptionKeyName')
            $hasEncryptionKeyVersion = $PSBoundParameters.Remove('EncryptionKeyVersion')
            $hasKeyVaultKeyName = $PSBoundParameters.Remove('KeyVaultKeyName')
            $hasKeyVaultKeyVersion = $PSBoundParameters.Remove('KeyVaultKeyVersion')
            $hasKeyVaultUri = $PSBoundParameters.Remove('KeyVaultUri')
            $hasAmlWorkspaceId = $PSBoundParameters.Remove('AmlWorkspaceId')
            $hasSkuTier = $PSBoundParameters.Remove('SkuTier')
            $hasTag = $PSBoundParameters.Remove('Tag')
            $hasRequiredNsgRule = $PSBoundParameters.Remove('RequiredNsgRule')
            $hasAsJob = $PSBoundParameters.Remove('AsJob')
            $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')

            $workspace = Get-AzDatabricksWorkspace @PSBoundParameters

            # 2. PUT
            $null = $PSBoundParameters.Remove('InputObject')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('Name')
            $null = $PSBoundParameters.Remove('SubscriptionId')
            if ($hasPrepareEncryption) {
                $workspace.PrepareEncryption = $PrepareEncryption
            }
            if ($hasEncryptionKeySource) {
                $workspace.EncryptionKeySource = $EncryptionKeySource
            }
            if ($hasEncryptionKeyVaultUri) {
                $workspace.EncryptionKeyVaultUri = $EncryptionKeyVaultUri
            }
            if ($hasEncryptionKeyName) {
                $workspace.EncryptionKeyName = $EncryptionKeyName
            }
            if ($hasEncryptionKeyVersion) {
                $workspace.EncryptionKeyVersion = $EncryptionKeyVersion
            }
            if ($hasKeyVaultKeyName) {
                $workspace.KeyVaultKeyName = $KeyVaultKeyName
            }

            if ($hasKeyVaultKeyVersion) {
                $workspace.KeyVaultKeyVersion = $KeyVaultKeyVersion
            }

            if ($hasKeyVaultUri) {
                $workspace.KeyVaultUri = $KeyVaultUri
            }

            if ($hasAmlWorkspaceId) {
                $workspace.AmlWorkspaceId = $AmlWorkspaceId
            }

            if ($hasSkuTier) {
                $workspace.SkuTier = $SkuTier
            }

            if ($hasTag) {
                $workspace.Tag = $Tag
            }

            if ($hasRequiredNsgRule) {
                $workspace.RequiredNsgRule = $RequiredNsgRule
            }
            if ($hasAsJob) {
                $PSBoundParameters.Add('AsJob', $true)
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
