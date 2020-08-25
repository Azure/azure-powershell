
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
# TODO PLEASE FIX BEFORE RELEASE
Create a deployment in the specified subscription and resource group.
.Description
# TODO PLEASE FIX BEFORE RELEASE
Create a deployment in the specified subscription and resource group.
This has to be done only once, before enabling replication for first 
VmWare virtual machine.
Initialize-AzMigrateReplicationInfrastructure -ProjectName a -ResourceGroupName b -SubscriptionId c -Vmwareagentless
.Link
# TODO PLEASE FIX BEFORE RELEASE
https://docs.microsoft.com/en-us/powershell/module/az.migrate/initialize-azmigratereplicationinfrastructure
#>
function Start-AzMigrateServerMigration {
    [OutputType([System.Void])]
    [CmdletBinding(DefaultParameterSetName='VMwareCbt', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Name of an Azure Resource group.
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Name of an Azure Migrate project.
        ${ProjectName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Switch]
        # Name of an Azure Migrate project.
        ${Vmwareagentless},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Azure Subscription ID.
        ${SubscriptionId},

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
            # TODO PLEASE FIX BEFORE RELEASE
            Set-PSDebug -Step; foreach ($i in 1..3) {$i}
            if ($Vmwareagentless.IsPresent) {
                # TODO PLEASE FIX BEFORE RELEASE
                # Get Site name from project name
                
                $test = $PSBoundParameters
                $artifactName = "AzMigratePWSHTc8d1sitecentraluseuap"
                $Source = @"
using System;
public class HashFunctions
{
public static int hashForArtifact(String artifact)
    {
            int hash = 0;
            int al = artifact.Length;
            int tl = 0;
            char[] ac = artifact.ToCharArray();
            while (tl < al)
            {
                hash = ((hash << 5) - hash) + ac[tl++] | 0;
            }
            return Math.Abs(hash);
    }
}
"@
                Add-Type -TypeDefinition $Source -Language CSharp 
                $hash = [HashFunctions]::hashForArtifact($artifactName) 
                Write-Host $hash
               
                
            } else {
                # TODO PLEASE FIX BEFORE RELEASE
                Write-Host "Please specify -Vmwareagentless" -ForegroundColor Red -BackgroundColor Yellow
            }
        } catch {
           throw
        }
    }

}   