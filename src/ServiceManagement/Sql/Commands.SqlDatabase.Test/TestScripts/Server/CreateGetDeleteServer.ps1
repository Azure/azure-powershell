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

[CmdletBinding()]
Param
(
    [Parameter(Mandatory=$true, Position=0)]
    [ValidateNotNullOrEmpty()]
    [string]
    $subscriptionID, 
    [Parameter(Mandatory=$true, Position=1)]
    [ValidateNotNullOrEmpty()]
    [String]
    $SerializedCert,
    [Parameter(Mandatory=$true, Position=2)]
    [ValidateNotNullOrEmpty()]
    [String]
    $serverLocation,
    [Parameter(Mandatory=$true, Position=3)]
    [ValidateNotNullOrEmpty()]
    [String]
    $Endpoint
)

Write-Output "`$subscriptionID=$subscriptionID"
Write-Output "`$SerializedCert=$SerializedCert"
Write-Output "`$serverLocation=$serverLocation"
Write-Output "`$Endpoint=$Endpoint"

. .\CommonFunctions.ps1

Try
{
	Init-TestEnvironment
    Init-AzureSubscription $subscriptionID $SerializedCert $Endpoint
    $loginName="mylogin1"
    $loginPassword="Sql@zure1"
    $isTestPass = $False
    
    # Create Server
    Write-Output "Creating server"
    $server = New-AzureSqlDatabaseServer -AdministratorLogin $loginName -AdministratorLoginPassword $loginPassword -Location $serverLocation
    Validate-SqlDatabaseServerOperationContext -Actual $server -expectedServerName $server.ServerName -expectedOperationDescription "New-AzureSqlDatabaseServer"
    Write-Output "Server $($server.ServerName) created"
    
    # Get Server
    Write-Output "Getting server"
    $getServer = Get-AzureSqlDatabaseServer | Where-Object {$_.ServerName -eq $server.ServerName}
    Assert {$getServer} "Can not get server $($server.ServerName)"
    Validate-SqlDatabaseServerContext -Actual $getServer -ExpectedAdministratorLogin $loginName -ExpectedLocation $serverLocation -ExpectedServerName $server.ServerName -ExpectedOperationDescription "Get-AzureSqlDatabaseServer"
    Write-Output "Got server $($server.ServerName)"
    
    $isTestPass = $True
}
Finally
{
    if($server)
    {
        # Drop server
        Drop-Server $server
        
        #Validate Drop server
        Write-Output 'Validating drop'
        $getDroppedServer = Get-AzureSqlDatabaseServer | Where-Object {$_.ServerName -eq $server.ServerName}
        Assert {!$getDroppedServer} "Server is not dropped"
        Write-Output "Validation successful"
    }
    Write-TestResult $IsTestPass
}
