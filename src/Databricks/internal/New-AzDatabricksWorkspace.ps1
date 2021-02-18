
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
Creates a new workspace.
.Description
Creates a new workspace.
.Example
PS C:\> New-AzDatabricksWorkspace -Name databricks-test -ResourceGroupName testgroup -Location eastus -ManagedResourceGroupName databricks-group -Sku standard

Location Name            Type
-------- ----            ----
eastus   databricks-test Microsoft.Databricks/workspaces
.Example
PS C:\> $dlg = New-AzDelegation -Name dbrdl -ServiceName "Microsoft.Databricks/workspaces"
PS C:\> $rdpRule = New-AzNetworkSecurityRuleConfig -Name rdp-rule -Description "Allow RDP" -Access Allow -Protocol Tcp -Direction Inbound -Priority 100 -SourceAddressPrefix Internet -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389
PS C:\> $networkSecurityGroup = New-AzNetworkSecurityGroup -ResourceGroupName testgroup -Location eastus -Name nsg-test -SecurityRules $rdpRule
PS C:\> $privSubnet = New-AzVirtualNetworkSubnetConfig -Name priv-sub -AddressPrefix "10.0.1.0/24" -NetworkSecurityGroup $networkSecurityGroup -Delegation $dlg
PS C:\> $pubSubnet = New-AzVirtualNetworkSubnetConfig -Name pub-sub  -AddressPrefix "10.0.2.0/24" -NetworkSecurityGroup $networkSecurityGroup -Delegation $dlg
PS C:\> $testVN = New-AzVirtualNetwork -Name testvn -ResourceGroupName testgroup -Location eastus -AddressPrefix "10.0.0.0/16" -Subnet $privSubnet,$pubSubnet
PS C:\> New-AzDatabricksWorkspace -Name databricks-test-with-custom-vn -ResourceGroupName testgroup -Location eastus -VirtualNetworkId $testVN.Id -PrivateSubnetName $privSubnet.Name -PublicSubnetName $privSubnet.Name -Sku standard

Location Name                           Type
-------- ----                           ----
eastus   databricks-test-with-custom-vn Microsoft.Databricks/workspaces
.Example
PS C:\> New-AzDatabricksWorkspace -Name databricks-test02 -ResourceGroupName testgroup -PrepareEncryption -Location "East US 2 EUAP" -Sku premium

Location Name            Type
-------- ----            ----
eastus   databricks-test02 Microsoft.Databricks/workspaces

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspace
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IDatabricksIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspace
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

AUTHORIZATION <IWorkspaceProviderAuthorization[]>: The workspace provider authorizations.
  PrincipalId <String>: The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the workspace resources.
  RoleDefinitionId <String>: The provider's role definition identifier. This role will define all the permissions that the provider must have on the workspace's container resource group. This role definition cannot have permission to delete the resource group.

INPUTOBJECT <IDatabricksIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [PeeringName <String>]: The name of the workspace vNet peering.
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [SubscriptionId <String>]: The ID of the target subscription.
  [WorkspaceName <String>]: The name of the workspace.

PARAMETER <IWorkspace>: Information about workspace.
  Location <String>: The geo-location where the resource lives
  ManagedResourceGroupId <String>: The managed resource group Id.
  [Tag <ITrackedResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [AmlWorkspaceIdValue <String>]: The value which should be used for this field.
  [Authorization <IWorkspaceProviderAuthorization[]>]: The workspace provider authorizations.
    PrincipalId <String>: The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the workspace resources.
    RoleDefinitionId <String>: The provider's role definition identifier. This role will define all the permissions that the provider must have on the workspace's container resource group. This role definition cannot have permission to delete the resource group.
  [CustomPrivateSubnetNameValue <String>]: The value which should be used for this field.
  [CustomPublicSubnetNameValue <String>]: The value which should be used for this field.
  [CustomVirtualNetworkIdValue <String>]: The value which should be used for this field.
  [EnableNoPublicIP <Boolean?>]: The value which should be used for this field.
  [EncryptionKeyName <String>]: The name of KeyVault key.
  [EncryptionKeySource <KeySource?>]: The encryption keySource (provider). Possible values (case-insensitive):  Default, Microsoft.Keyvault
  [EncryptionKeyVaultUri <String>]: The Uri of KeyVault.
  [EncryptionKeyVersion <String>]: The version of KeyVault key.
  [PrepareEncryption <Boolean?>]: The value which should be used for this field.
  [RequireInfrastructureEncryption <Boolean?>]: The value which should be used for this field.
  [SkuName <String>]: The SKU name.
  [SkuTier <String>]: The SKU tier.
  [UiDefinitionUri <String>]: The blob URI where the UI definition file is located.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.databricks/new-azdatabricksworkspace
#>
function New-AzDatabricksWorkspace {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspace])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Alias('WorkspaceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
    [System.String]
    # The name of the workspace.
    ${Name},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IDatabricksIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The managed resource group Id.
    ${ManagedResourceGroupId},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The value which should be used for this field.
    ${AmlWorkspaceIdValue},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProviderAuthorization[]]
    # The workspace provider authorizations.
    # To construct, see NOTES section for AUTHORIZATION properties and create a hash table.
    ${Authorization},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # The value which should be used for this field.
    ${EnableNoPublicIPValue},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The name of KeyVault key.
    ${EncryptionKeyName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource])]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource]
    # The encryption keySource (provider).
    # Possible values (case-insensitive): Default, Microsoft.Keyvault
    ${EncryptionKeySource},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The Uri of KeyVault.
    ${EncryptionKeyVaultUri},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The version of KeyVault key.
    ${EncryptionKeyVersion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # The value which should be used for this field.
    ${PrepareEncryption},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The value which should be used for this field.
    ${PrivateSubnetName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The value which should be used for this field.
    ${PublicSubnetName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # The value which should be used for this field.
    ${RequireInfrastructureEncryption},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The SKU name.
    ${Sku},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The SKU tier.
    ${SkuTier},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The blob URI where the UI definition file is located.
    ${UiDefinitionUri},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The value which should be used for this field.
    ${VirtualNetworkId},

    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspace]
    # Information about workspace.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
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

    [Parameter()]
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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            CreateExpanded = 'Az.Databricks.private\New-AzDatabricksWorkspace_CreateExpanded';
            CreateViaIdentity = 'Az.Databricks.private\New-AzDatabricksWorkspace_CreateViaIdentity';
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
