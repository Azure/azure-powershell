
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
Creates a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.
.Description
Creates a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.
#>
function New-AzSapMonitorProviderInstance {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstance])]
    [CmdletBinding(DefaultParameterSetName = 'ByString', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    [Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSAvoidUsingPlainTextForPassword', 'HanaDatabasePasswordKeyVaultResourceId', Justification = 'Not a password')]
    [Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSAvoidUsingPlainTextForPassword', 'HanaDatabasePasswordSecretId', Justification = 'Not a password')]
    param(
        [Parameter(Mandatory)]
        [Alias('ProviderInstanceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
        [System.String]
        # Name of the provider instance.
        ${Name},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
        [System.String]
        # Name of the resource group.
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
        [System.String]
        # Name of the SAP monitor resource.
        ${SapMonitorName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription ID which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.Collections.Hashtable]
        # A JSON string containing metadata of the provider instance.
        ${Metadata},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # The type of provider instance. Supported values are: "SapHana".
        ${ProviderType},

        [Parameter(ParameterSetName = 'ByString', Mandatory)]
        [Parameter(ParameterSetName = 'ByKeyVault', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # The hostname of SAP HANA instance.
        ${HanaHostname},

        [Parameter(ParameterSetName = 'ByString', Mandatory)]
        [Parameter(ParameterSetName = 'ByKeyVault', Mandatory)]
        [Alias('HanaDbName')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # The database name of SAP HANA instance.
        ${HanaDatabaseName},

        [Parameter(ParameterSetName = 'ByString', Mandatory)]
        [Parameter(ParameterSetName = 'ByKeyVault', Mandatory)]
        [Alias('HanaDbSqlPort')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.Int32]
        # The SQL port of the database of SAP HANA instance.
        ${HanaDatabaseSqlPort},

        [Parameter(ParameterSetName = 'ByString', Mandatory)]
        [Parameter(ParameterSetName = 'ByKeyVault', Mandatory)]
        [Alias('HanaDbUsername')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # The username of the database of SAP HANA instance.
        ${HanaDatabaseUsername},

        [Parameter(ParameterSetName = 'ByDict', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.Collections.Hashtable]
        # The property of HANA instance.
        ${InstanceProperty},

        [Parameter(ParameterSetName = 'ByString', Mandatory)]
        [Alias('HanaDbPassword')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [SecureString]
        # The password of the database of SAP HANA instance.
        ${HanaDatabasePassword},

        [Parameter(ParameterSetName = 'ByKeyVault', Mandatory)]
        [Alias('HanaDbPasswordKeyVaultId', 'KeyVaultId')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # Resource ID of the Key Vault that contains the HANA credentials.
        ${HanaDatabasePasswordKeyVaultResourceId},

        [Parameter(ParameterSetName = 'ByKeyVault', Mandatory)]
        [Alias('HanaDbPasswordSecretId', 'SecretId')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # Secret identifier to the Key Vault secret that contains the HANA credentials.
        ${HanaDatabasePasswordSecretId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        $null = $PSBoundParameters.Remove('ResourceGroupName')
        $null = $PSBoundParameters.Remove('Name')
        $null = $PSBoundParameters.Remove('SapMonitorName')
        $null = $PSBoundParameters.Remove('ProviderType')
        $null = $PSBoundParameters.Remove('Metadata')

        $null = $PSBoundParameters.Remove('HanaHostname')
        $null = $PSBoundParameters.Remove('HanaDatabaseName')
        $null = $PSBoundParameters.Remove('HanaDatabaseSqlPort')
        $null = $PSBoundParameters.Remove('HanaDatabaseUsername')
        $null = $PSBoundParameters.Remove('HanaDatabasePasswordSecretId')
        $null = $PSBoundParameters.Remove('HanaDatabasePasswordKeyVaultResourceId')

        $null = $PSBoundParameters.Remove('Confirm')
        $null = $PSBoundParameters.Remove('WhatIf')
        $hasAsJob = $PSBoundParameters.Remove('AsJob')

        $parameterSet = $PSCmdlet.ParameterSetName
        switch ($parameterSet) {
            'ByString' {
                $null = $PSBoundParameters.Remove('HanaDatabasePassword')
                $property = @{
                    hanaHostname   = $HanaHostname
                    hanaDbName     = $HanaDatabaseName
                    hanaDbSqlPort  = $HanaDatabaseSqlPort
                    hanaDbUsername = $HanaDatabaseUsername
                    # To suppport descryption accross different platforms and PowerShell versions, we implement a script Unprotect-SecureString.ps1
                    # to convert securesting to plaintext
                    hanaDbPassword = . "$PSScriptRoot/../utils/Unprotect-SecureString.ps1" $HanaDatabasePassword
                }
            }
            'ByKeyVault' {
                # Referencing to CLI's implementation
                # https://github.com/Azure/azure-hanaonazure-cli-extension/blob/master/azext_hanaonazure/custom.py#L312-L338

                # 1. Get MSI
                $sapMonitor = Get-AzSapMonitor -ResourceGroupName $ResourceGroupName -Name $SapMonitorName @PSBoundParameters
                $managedResourceGroupName = $sapMonitor.ManagedResourceGroupName
                $sapMonitorId = $managedResourceGroupName.Split("-")[2]

                $msiName = "sapmon-msi-$sapMonitorId"
                $msi = Az.HanaOnAzure.internal\Get-AzUserAssignedIdentity -ResourceGroupName $managedResourceGroupName -ResourceName $msiName @PSBoundParameters

                # 2. Grant key vault access to MSI
                $null = $HanaDatabasePasswordKeyVaultResourceId -match "^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.KeyVault/vaults/(?<vaultName>[^/]+)$"
                $vaultSubscriptionId = $Matches['subscriptionId']
                $vaultResourceGroupName = $Matches['resourceGroupName']
                $vaultName = $Matches['vaultName']

                # Need to use vault's sub ID, not the sub ID of this cmdlet
                $null = $PSBoundParameters.Remove('SubscriptionId')
                $null = Az.HanaOnAzure.internal\Set-AzVaultAccessPolicy -OperationKind add -ResourceGroupName $vaultResourceGroupName -VaultName $vaultName -SubscriptionId $vaultSubscriptionId -AccessPolicy @{
                    ObjectId         = $msi.PrincipalId
                    TenantId         = (Get-AzContext).Tenant.Id
                    PermissionSecret = 'get'
                } @PSBoundParameters
                $PSBoundParameters.Add('SubscriptionId', $SubscriptionId)

                # Service accepts secret ID without port
                # but (Get-AzKeyVaultSecret).Id contains port (":443")
                # need to remove it
                $vaultPort = ":443"
                if ($HanaDatabasePasswordSecretId.Contains($vaultPort)) {
                    $HanaDatabasePasswordSecretId = $HanaDatabasePasswordSecretId.Replace($vaultPort, "")
                }

                $property = @{
                    hanaHostname                   = $HanaHostname
                    hanaDbName                     = $HanaDatabaseName
                    hanaDbSqlPort                  = $HanaDatabaseSqlPort
                    hanaDbUsername                 = $HanaDatabaseUsername
                    hanaDbPasswordKeyVaultUrl      = $HanaDatabasePasswordSecretId
                    keyVaultId                     = $HanaDatabasePasswordKeyVaultResourceId # key vault id is keyvault resource id
                    keyVaultCredentialsMsiClientID = $msi.ClientId # FIXME: this property is not needed in newer service backend, can we remove it?
                }
            }
            'ByDict' {
                $property = $InstanceProperty
                $null = $PSBoundParameters.remove('InstanceProperty')
            }
        }
        $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
        $PSBoundParameters.Add('Name', $Name)
        $PSBoundParameters.Add('SapMonitorName', $SapMonitorName)
        $PSBoundParameters.Add('ProviderType', $ProviderType)
        $PSBoundParameters.Add('Metadata', ($Metadata | ConvertTo-Json))

        $PSBoundParameters.Add('ProviderInstanceProperty', ($property | ConvertTo-Json))

        if ($hasAsJob) {
            $PSBoundParameters.Add('AsJob', $true)
        }

        if ($PSCmdlet.ShouldProcess("SAP monitor provider instance $Name", "Create")) {
            Az.HanaOnAzure.internal\New-AzSapMonitorProviderInstance @PSBoundParameters
        }
    }
}