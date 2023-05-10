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
Updates a ServiceBus namespace
.Description
Updates a ServiceBus namespace
#>

function Set-AzServiceBusNamespace{
    [Alias("Set-AzServiceBusNamespaceV2")]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.ISbNamespace])]
    [CmdletBinding(DefaultParameterSetName = 'SetExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
	param(
        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of ServiceBusNamespace")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        ${Name},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of the ResourceGroupName.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The ID of the target subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'SetViaIdentityExpanded', HelpMessage = "Identity parameter. To construct, see NOTES section for INPUTOBJECT properties and create a hash table.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter(HelpMessage = "Alternate name for namespace")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.String]
        ${AlternateName},
        
        [Parameter(HelpMessage = "This property disables SAS authentication for the Service Bus namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${DisableLocalAuth},
		
        [Parameter(HelpMessage = "Properties of KeyVault")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.IKeyVaultProperties[]]
        ${KeyVaultProperty},

        [Parameter(HelpMessage = "Enable Infrastructure Encryption (Double Encryption)")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${RequireInfrastructureEncryption},

        [Parameter(HelpMessage = "Type of managed service identity.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.ManagedServiceIdentityType]
        ${IdentityType},

        [Parameter(HelpMessage = "Properties for User Assigned Identities")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.String[]]
        ${UserAssignedIdentityId},

        [Parameter(HelpMessage = "The minimum TLS version for the cluster to support, e.g. '1.2'")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        #[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.TlsVersion]
        [System.String]
        ${MinimumTlsVersion},

        [Parameter(HelpMessage = "This determines if traffic is allowed over public network. By default it is enabled.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.PublicNetworkAccess]
        ${PublicNetworkAccess},

        [Parameter(HelpMessage = "Name of this SKU.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.SkuName]
        ${SkuName},

        [Parameter(HelpMessage = "The specified messaging units for the tier. For Premium tier, capacity are 1,2 and 4.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Int32]
        ${SkuCapacity},

        [Parameter(HelpMessage = "Resource tags.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Collections.Hashtable]
        ${Tag},

        [Parameter(HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(HelpMessage = "Run the command as a job")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(HelpMessage = "Run the command asynchronously")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
	)
	process{
	    try{
                $hasAlternateName = $PSBoundParameters.Remove('AlternateName')
                $hasDisableLocalAuth = $PSBoundParameters.Remove('DisableLocalAuth')
                $hasKeyVaultProperty = $PSBoundParameters.Remove('KeyVaultProperty')
                $hasUserAssignedIdentityId = $PSBoundParameters.Remove('UserAssignedIdentityId')
                $hasIdentityType = $PSBoundParameters.Remove('IdentityType')
                $hasMinimumTlsVersion = $PSBoundParameters.Remove('MinimumTlsVersion')
                $hasRequireInfrastructureEncryption = $PSBoundParameters.Remove('RequireInfrastructureEncryption')
                $hasPublicNetworkAccess = $PSBoundParameters.Remove('PublicNetworkAccess')
                $hasSkuCapacity = $PSBoundParameters.Remove('SkuCapacity')
                $hasTag = $PSBoundParameters.Remove('Tag')
                $hasDefaultProfile = $PSBoundParameters.Remove('DefaultProfile')
                $hasAsJob = $PSBoundParameters.Remove('AsJob')
                $null = $PSBoundParameters.Remove('WhatIf')
                $null = $PSBoundParameters.Remove('Confirm')
                $serviceBusNamespace = Get-AzServiceBusNamespace @PSBoundParameters

                # 2. PUT
                $null = $PSBoundParameters.Remove('InputObject')
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                $null = $PSBoundParameters.Remove('NamespaceName')
                $null = $PSBoundParameters.Remove('Name')
                $null = $PSBoundParameters.Remove('SubscriptionId')

                if ($hasAlternateName) {
                    $serviceBusNamespace.AlternateName = $AlternateName
                }
                if ($hasDisableLocalAuth) {
                    $serviceBusNamespace.DisableLocalAuth = $DisableLocalAuth
                }
                if ($hasKeyVaultProperty) {
                    $serviceBusNamespace.KeyVaultProperty = $KeyVaultProperty
                    $serviceBusNamespace.KeySource = 'Microsoft.KeyVault'
                }
                if ($hasIdentityType) {
                    $serviceBusNamespace.IdentityType = $IdentityType
                }
                if($hasRequireInfrastructureEncryption){
                    $serviceBusNamespace.RequireInfrastructureEncryption = $RequireInfrastructureEncryption
                }
                if ($hasUserAssignedIdentityId) {
                    $identityHashTable = @{}
	            
		    foreach ($resourceID in $UserAssignedIdentityId){
		        $identityHashTable.Add($resourceID, [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.UserAssignedIdentity]::new())
	            }
                    
		    $serviceBusNamespace.UserAssignedIdentity = $identityHashTable
               }
               if ($hasMinimumTlsVersion) {
                    $serviceBusNamespace.MinimumTlsVersion = $MinimumTlsVersion
               }
               if ($hasPublicNetworkAccess) {
                    $serviceBusNamespace.PublicNetworkAccess = $PublicNetworkAccess
               }
               if ($hasSkuCapacity) {
                    $serviceBusNamespace.SkuCapacity = $SkuCapacity
               }
               if ($hasTag) {
                    $serviceBusNamespace.Tag = $Tag
               }
               if ($hasAsJob) {
                    $PSBoundParameters.Add('AsJob', $true)
               }

               if ($PSCmdlet.ShouldProcess("ServiceBusNamespace $($serviceBusNamespace.Name)", "Create or update")) {
                    Az.ServiceBus.private\New-AzServiceBusNamespace_CreateViaIdentity -InputObject $serviceBusNamespace -Parameter $serviceBusNamespace @PSBoundParameters
               }
	}
	catch{
	    throw
	}
    }
}
