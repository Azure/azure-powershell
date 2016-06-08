# ----------------------------------------------------------------------------------
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http:#www.apache.org/licenses/LICENSE-2.0
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
    $SloManageUrl, 
    [Parameter(Mandatory=$true, Position=1)]
    [ValidateNotNullOrEmpty()]
    [string]
    $subscriptionID, 
    [Parameter(Mandatory=$true, Position=2)]
    [ValidateNotNullOrEmpty()]
    [String]
    $SerializedCert,
    [Parameter(Mandatory=$true, Position=3)]
    [ValidateNotNullOrEmpty()]
    [String]
    $serverLocation,
    [Parameter(Mandatory=$true, Position=4)]
    [ValidateNotNullOrEmpty()]
    [String]
    $Endpoint,
    [Parameter(Mandatory=$true, Position=5)]
    [ValidateNotNullOrEmpty()]
    [String]
    $Username,
    [Parameter(Mandatory=$true, Position=6)]
    [ValidateNotNullOrEmpty()]
    [String]
    $Password
)

$isTestPass = $False

Write-Output "`$subscriptionID=$subscriptionID" 
Write-Output "`$SerializedCert=$SerializedCert"
Write-Output "`$serverLocation=$serverLocation"

. .\CommonFunctions.ps1

Try
{
    Init-TestEnvironment
    Init-AzureSubscription $SubscriptionId $SerializedCert $Endpoint
	
    $securePassword = ConvertTo-SecureString $Password -AsPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential ($UserName, $securePassword)
    
    $context = New-AzureSqlDatabaseServerContext -ManageUrl $SloManageUrl -Credential $credential
    
    Write-Output "Testing: Get all quotas"
    $quota = $context | Get-AzureSqlDatabaseServerQuota
    Assert {$quota} "Failed to get the quotas from the server"
    Write-Output $quota

    
    Write-Output "\nTesting: Get Premium_Databases quota"
    $quota = $context | Get-AzureSqlDatabaseServerQuota -QuotaName "Premium_Databases"
    Assert {$quota.Name -eq "Premium_Databases"} "Failed to get the quotas from the server"
    Write-Output $quota

    $isTestPass = $True
}
Finally
{
}

Write-TestResult $IsTestPass
