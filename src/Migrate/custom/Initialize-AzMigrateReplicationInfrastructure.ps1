
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
Initializes the replication infrastructure.
.Description
The Initialize-AzMigrateReplicationInfrastructure deploys and configures the replication infrastructure used for server migration in the Azure Migrate project Resource Group.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.migrate/initialize-azmigratereplicationinfrastructure
#>
function Initialize-AzMigrateReplicationInfrastructure {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='ByNameVMwareCbt', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='ByNameVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Resource Group of the Azure Migrate Project in the current subscription.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='ByNameVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the name of the Azure Migrate project to be used for server migration.
        ${ProjectName},

        [Parameter(ParameterSetName='ByInputObjectVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProject]

        # Specifies the Azure Migrate project for server migration. The project object can be retrieved using the Get-AzMigrateProject cmdlet.
        ${InputObject},

        [Parameter(ParameterSetName='ByIdVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Resource Group of the Azure Migrate Project in the current subscription.
        ${ResourceGroupID},

        [Parameter(ParameterSetName='ByIdVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the name of the Azure Migrate project to be used for server migration.
        ${ProjectID},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        # Specifies the server migration scenario for which the replication infrastructure needs to be initialized.
        ${Vmwareagentless},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the target Azure region for server migrations.
        ${TargetRegion},
    
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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru},
    
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
           <#  # TODO PLEASE FIX BEFORE RELEASE
            Set-PSDebug -Step; foreach ($i in 1..3) {$i}
            # TODO
            $ParameterSetName = $PSCmdlet.ParameterSetName
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('ProjectName')
            $null = $PSBoundParameters.Remove('InputObject')
            $null = $PSBoundParameters.Remove('ResourceGroupID')
            $null = $PSBoundParameters.Remove('ProjectID')
            $null = $PSBoundParameters.Remove('Vmwareagentless')
            $null = $PSBoundParameters.Remove('TargetRegion')
            
            $availableRegions = Get-AzLocation
            $isTargetRegionValid = $false
            foreach($location in $availableRegions){
                if ($location.Location -eq $TargetRegion){
                    $isTargetRegionValid = $true
                break}
            }
            if ($isTargetRegionValid -eq $false){
                throw "Target region doesn't exist" 
            }

            if($ParameterSetName -eq 'ByInputObjectVMwareCbt'){
                #TODO $SiteName
                $idArray = $InputObject.Id.Split("/")
                $ResourceGroupName = $idArray[4]
                $ProjectName = $idArray[8]
            }elseif ($ParameterSetName -eq 'ByIdVMwareCbt') {
                $ResourceGroupName = $ResourceGroupID.Split("/")[4]
                $ProjectName = $ProjectID.Split("/")[8]
            }else{

            }
            $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
            # $null = $PSBoundParameters.Add('MigrateProjectName', )
            # $SiteName = Az.Migrate\Get-AzMigrateSolution -Name <String> -ResourceGroupName <String>
            
            # $HashCodeInput = $SiteName + $TargetRegion

            
            # TODO PLEASE FIX BEFORE RELEASE
            # Get Site name from project name
            $SiteName = "AzMigratePWSHTc8d1site"
            $test = $PSBoundParameters
            # $artifactName = "AzMigratePWSHTc8d1sitecentraluseuap"
            $HashCodeInput = $SiteName + $TargetRegion
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
            $hash = [HashFunctions]::hashForArtifact($HashCodeInput) 
            # Write-Host $hash

            $MigratePrefix = "migrate"            
            $LogStorageAcName = $MigratePrefix + "lsa" + $hash
            $GateWayStorageAcName = $MigratePrefix + "gwsa" + $hash
            $StorageType = "Microsoft.Storage/storageAccounts"
            $StorageApiVersion = "2017-10-01" 
            $LogStorageProperties =  @{
                encryption=@{
                    services=@{
                        blob=@{enabled=$true};
                        file=@{enabled=$true};
                        table=@{enabled=$true};
                        queue=@{enabled=$true}
                        };
                    keySource="Microsoft.Storage"
                };
                supportsHttpsTrafficOnly=$true
               }
            $ResourceTag =  @{"Migrate Project"=$ProjectName}
            $StorageSku = @{name="Standard_LRS"}
            $ResourceKind = "Storage"
            $null = $PSBoundParameters.Add('Location' , $TargetRegion)
            $null = $PSBoundParameters.Add('Properties' , $LogStorageProperties)
            $null = $PSBoundParameters.Add('ResourceName' , $LogStorageAcName)
            $null = $PSBoundParameters.Add('ResourceType' , $StorageType)
            $null = $PSBoundParameters.Add('ApiVersion' , $StorageApiVersion)
            $null = $PSBoundParameters.Add('Kind' , $ResourceKind)
            $null = $PSBoundParameters.Add('Sku' , $StorageSku)
            $null = $PSBoundParameters.Add('Tag' , $ResourceTag)

            New-AzResource @PSBoundParameters

            $null = $PSBoundParameters.Remove('ResourceName')
            $null = $PSBoundParameters.Add('ResourceName' , $GateWayStorageAcName)

            New-AzResource @PSBoundParameters

            $null = $PSBoundParameters.Remove('Properties')
            $null = $PSBoundParameters.Remove('ResourceName')
            $null = $PSBoundParameters.Remove('ResourceType')
            $null = $PSBoundParameters.Remove('ApiVersion')
            $null = $PSBoundParameters.Remove('Kind')
            $null = $PSBoundParameters.Remove('Sku')

            $ServiceBusNamespace = $MigratePrefix + "sbns" + $hash
            $ServiceBusType = "Microsoft.ServiceBus/namespaces"
            $ServiceBusApiVersion = "2017-04-01"
            $ServiceBusSku = @{
                    name = "Standard";
                    tier = "Standard"
            }
            $ServiceBusProperties = @{}
            $ServieBusKind = "ServiceBusNameSpace"

            $null = $PSBoundParameters.Add('Properties' , $ServiceBusProperties)
            $null = $PSBoundParameters.Add('ResourceName' , $ServiceBusNamespace)
            $null = $PSBoundParameters.Add('ResourceType' , $ServiceBusType)
            $null = $PSBoundParameters.Add('ApiVersion' , $ServiceBusApiVersion)
            $null = $PSBoundParameters.Add('Kind' , $ServieBusKind)
            $null = $PSBoundParameters.Add('Sku' , $ServiceBusSku)

            New-AzResource @PSBoundParameters

            $KeyVaultName = $MigratePrefix + "kv" + $hash
            $KeyVaultType = "Microsoft.KeyVault/vaults"
            $KeyVaultApiVersion = "2016-10-01"
            $KeyVaultKind = "KeyVault"
            $keyVaultSKu = @{
                family = "A";
                name = "standard"
            }
            $context = Get-AzContext
            $keyVaultTenantID = $context.Tenant.TenantId 
            
            $KeyVaultKeys =@("Get","List","Create","Update","Delete")
            $KeyVaultSecrets = @("Get","Set","List","Delete")
            $KeyVaultCertificates = @("Get","List")
            $KeyVaultStorage = @("get","list","delete","set","update","regeneratekey","getsas",
            "listsas","deletesas","setsas","recover","backup","restore","purge")
            $KeyVaultPermissions = @{keys=$KeyVaultKeys;secrets=$KeyVaultSecrets;
                certificates=$KeyVaultCertificates;storage=$KeyVaultStorage}

            $CloudEnvironMent = $context.Environment.Name
            $HyperVManagerAppId = "b8340c3b-9267-498f-b21a-15d5547fd85e"
            if($CloudEnvironMent -eq "AzureUSGovernment"){
                $HyperVManagerAppId = "AFAE2AF7-62E0-4AA4-8F66-B11F74F56326"
            }
            if($PassThru.IsPresent){
                return $true
            } #>
            
       
    }

}   