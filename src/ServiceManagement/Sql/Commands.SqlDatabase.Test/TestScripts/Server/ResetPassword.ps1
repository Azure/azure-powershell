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
    $serverLocation
)
Write-Output "`$subscriptionID=$subscriptionID"
Write-Output "`$SerializedCert=$SerializedCert"
Write-Output "`$serverLocation=$serverLocation"

. .\CommonFunctions.ps1

Try
{
    Init-TestEnvironment
    Init-AzureSubscription -subscriptionID $subscriptionID -SerializedCert $SerializedCert
    $isTestPass = $False
    
    # Create Server
    $loginName="mylogin1"
    $loginPassword="Sql@zure1"
    Write-Output "Creating server ..."
    $server = New-AzureSqlDatabaseServer -AdministratorLogin $loginName -AdministratorLoginPassword $loginPassword -Location $serverLocation
    Assert {$server} "Server is not created"
    Write-Output "Server $($server.ServerName) created"
    
    # Connect to server
    Write-Output "Adding firewall rule to allow connection ..."
    New-AzureSqlDatabaseServerFirewallRule -ServerName $server.ServerName -RuleName all -StartIpAddress "0.0.0.0" -EndIpAddress "255.255.255.255"
    Write-Output "Connecting to server ..."
    $connString = "data source=$($server.ServerName).database.windows.net;User ID=$loginName;Password=$loginPassword"
    $conn = New-Object System.Data.SqlClient.SqlConnection($connString);
    $conn.Open()
    Write-Output "Connection success"
    
    # Reset Password
    $newPassword="Sql@zureNew"
    Write-Output "Resetting password ..."
    Set-AzureSqlDatabaseServer -ServerName $server.ServerName -AdminPassword $newPassword -Force
    Write-Output "Reset done"
    
    # Connect to server using new password
    Write-Output "Connecting to server using new password ..."
    $connString = "data source=$($server.ServerName).database.windows.net;User ID=$loginName;Password=$newPassword";
    $conn = New-Object System.Data.SqlClient.SqlConnection($connString);
    $conn.Open()
    Write-Output "Connection success"
    
    $isTestPass = $True
}
Finally
{
    Drop-Server $server
    Write-TestResult $IsTestPass
}

