
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
Mock
.Description
Mock
.Link
https://docs.microsoft.com/en-us/powershell/module/az.migrate/new-azmigrateserverreplication
#>
function Mock-AzMigrateGetRunAsAccountId {
    [OutputType([System.Management.Automation.PSObject])]
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
        ${SiteName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Azure Subscription ID.
        ${SubscriptionId}
    )
    
    process {
        
        $headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
	$headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImppYk5ia0ZTU2JteFBZck45Q0ZxUms0SzRndyIsImtpZCI6ImppYk5ia0ZTU2JteFBZck45Q0ZxUms0SzRndyJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuYXp1cmUuY29tLyIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0Ny8iLCJpYXQiOjE1OTg5NjgwNDQsIm5iZiI6MTU5ODk2ODA0NCwiZXhwIjoxNTk5MDU0NzQ0LCJhaW8iOiJFMkJnWUtqK3ZyUnFUK0ExcFRDUndNV0NPMnpOQVE9PSIsImFwcGlkIjoiNzA2ZGRiNzktOWE2NC00OTVjLWFlYjYtMWFhMDU5MmRmMjAxIiwiYXBwaWRhY3IiOiIxIiwiaWRwIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3LyIsIm9pZCI6ImY1ZjUyNWM2LWYyZDEtNDg1MS1hNWFhLWQ4Mjg2ZTdmNDU0NCIsInJoIjoiMC5BUUVBdjRqNWN2R0dyMEdScXkxODBCSGJSM25iYlhCa21seEpycllhb0ZrdDhnRWFBQUEuIiwic3ViIjoiZjVmNTI1YzYtZjJkMS00ODUxLWE1YWEtZDgyODZlN2Y0NTQ0IiwidGlkIjoiNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3IiwidXRpIjoieS1lNjVSWmhNVW10OUFLazRVd0RBQSIsInZlciI6IjEuMCIsInhtc190Y2R0IjoxMjg5MjQxNTQ3fQ.ggjScFJxGS5LfafmiKWJDfx8nn81EFo7Cd85czyQw99mY7WVD1aAjp-WWHBS7705CLip7CgR1zkCUc7nQINWVF4eY3-lPsUB0LFgbuFLbJEHkXmVPGDXBgujEIxh9juvHL0EFbuou3tAMPVk3ZPDd0XSAQIusJtBSR01hfw51eDUk6LuSJjrOWhqn65ljb2b9HFF3FjeT35pOIdZRrGxd-_U8THwIlpj_QebQ_cfBU1aXVU5yNf62C-29EVSkbpaRhd_WCjUWzHWuXGmb1Qg1FbMylyE3JfsajaZjFIaMcGYVmdm5casyTBc2Ab3bx5bUopR_bM5Sv1wjtodVUWC5Q")

	$response = Invoke-RestMethod 'https://management.azure.com/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.OffAzure/VMwareSites/AzMigratePWSHTc8d1site/runAsAccounts?api-version=2020-01-01' -Method 'GET' -Headers $headers -Body $body
	return $response
    }

}   