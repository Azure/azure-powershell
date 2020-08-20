
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
Create an environment in the specified subscription and resource group.
.Description
Create an environment in the specified subscription and resource group.
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
THIS IS FOR DEMO PURPOSE ONLY. HAS TO BE REMOVED .>>>>>>>>>>>>>>>>>>>>>
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
.Link
https://docs.microsoft.com/en-us/powershell/module/az.timeseriesinsights/new-aztimeseriesinsightsenvironment
#>
function New-AzMigratePolicy {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicy])]
    [CmdletBinding(DefaultParameterSetName='VMwareCbt', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Name of the environment
        ${PolicyName},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Name of an Azure Resource group.
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Name of an Azure Resource group.
        ${ResourceName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Azure Subscription ID.
        ${SubscriptionId},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter({param ( $CommandName, $ParameterName, $WordToComplete, $CommandAst, $FakeBoundParameters ) return @('VMwareCbt')})]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
        [System.String]
        # The kind of the environment.
        ${ProviderSpecificInputInstanceType},

        [Parameter(ParameterSetName='VMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
        [System.Int32]
        # The capacity of the sku.
        # For Gen1 environments, this value can be changed to support scale out of environments after they have been created.
        ${AppConsistentFrequencyInMinutes},

        [Parameter(ParameterSetName='VMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
        [System.Int32]
        # The capacity of the sku.
        # For Gen1 environments, this value can be changed to support scale out of environments after they have been created.
        ${CrashConsistentFrequencyInMinutes},

        [Parameter(ParameterSetName='VMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
        [System.Int32]
        # The capacity of the sku.
        # For Gen1 environments, this value can be changed to support scale out of environments after they have been created.
        ${RecoveryPointHistoryInMinutes},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    

    
    process {
        try {
            Set-PSDebug -Step; foreach ($i in 1..3) {$i}
            if ($PSBoundParameters['ProviderSpecificInputInstanceType'] -eq 'VMwareCbt') {
                $test = $PSBoundParameters
                $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CreatePolicyInput]::new()
                $Parameter.ProviderSpecificInputInstanceType = $PSBoundParameters['ProviderSpecificInputInstanceType']
                $Parameter.Property = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CreatePolicyInputProperties]::new()
                $Parameter.Property.ProviderSpecificInput = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtPolicyCreationInput]::new()
                $Parameter.Property.ProviderSpecificInput.CrashConsistentFrequencyInMinute = $PSBoundParameters['AppConsistentFrequencyInMinutes']
                $Parameter.Property.ProviderSpecificInput.AppConsistentFrequencyInMinute = $PSBoundParameters['CrashConsistentFrequencyInMinutes']
                $Parameter.Property.ProviderSpecificInput.RecoveryPointHistoryInMinute = $PSBoundParameters['RecoveryPointHistoryInMinutes']
                $Parameter.Property.ProviderSpecificInput.InstanceType  = $PSBoundParameters['ProviderSpecificInputInstanceType']
                $null = $PSBoundParameters.Remove('ProviderSpecificInputInstanceType')
                $null = $PSBoundParameters.Remove('AppConsistentFrequencyInMinutes')
                $null = $PSBoundParameters.Remove('CrashConsistentFrequencyInMinutes')
                $null = $PSBoundParameters.Remove('RecoveryPointHistoryInMinutes')
                $null = $PSBoundParameters.Add('Input', $Parameter)
                Az.Migrate\New-AzMigrateReplicationPolicy @PSBoundParameters
            } else {
                Write-Host "error" -ForegroundColor Red -BackgroundColor Yellow
            }

            
        } catch {
           Write-Host $Error[0]
           throw
        }
    }
}   