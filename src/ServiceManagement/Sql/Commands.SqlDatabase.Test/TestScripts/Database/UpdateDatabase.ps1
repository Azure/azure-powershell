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
    $Name,
    [Parameter(Mandatory=$true, Position=1)]
    [ValidateNotNullOrEmpty()]
    [string]
    $ManageUrl,
    [Parameter(Mandatory=$true, Position=2)]
    [ValidateNotNullOrEmpty()]
    [string]
    $UserName,
    [Parameter(Mandatory=$true, Position=3)]
    [ValidateNotNullOrEmpty()]
    [string]
    $Password,
    [Parameter(Mandatory=$true, Position=1)]
    [ValidateNotNullOrEmpty()]
    [string]
    $ServerName,
    [Parameter(Mandatory=$true, Position=2)]
    [ValidateNotNullOrEmpty()]
    [string]
    $SubscriptionID,
    [Parameter(Mandatory=$true, Position=3)]
    [ValidateNotNullOrEmpty()]
    [string]
    $SerializedCert,
    [Parameter(Mandatory=$true, Position=4)]
    [ValidateNotNullOrEmpty()]
    [string]
    $Endpoint
)

$IsTestPass = $False
Write-Output "`$Name=$Name"
Write-Output "`$ManageUrl=$ManageUrl"
Write-Output "`$UserName=$UserName"
Write-Output "`$Password=$Password"
Write-Output "`$ServerName=$ServerName"
Write-Output "`$SubscriptionID=$SubscriptionID"
Write-Output "`$SerializedCert=$SerializedCert"
Write-Output "`$Endpoint=$Endpoint"

. .\CommonFunctions.ps1
. .\Database\UpdateDatabase-ScenarioFunctions.ps1

Try
{
	Init-TestEnvironment
    
	# Update with Sql Auth
	try
	{
		$context = Get-ServerContextByManageUrlWithSqlAuth -ManageUrl $ManageUrl -UserName $UserName `
			-Password $Password
			
		$database = New-AzureSqlDatabase -Context $context -DatabaseName $Name

		Scenario1-UpdateWithObject -Context $context

		Scenario2-UpdateWithName -Context $context
		
		Scenario3-RenameDatabase -Context $context
	}
	finally
	{
		# Drop Database
		Drop-Databases $Context $Name
		$context = $null
	}

	# Update with Cert Auth
    try
	{
		
		Init-AzureSubscription $SubscriptionId $SerializedCert $Endpoint
		$sub = Get-AzureSubscription -Current
		$context = Get-ServerContextByServerNameWithCertAuth $ServerName	
			
		$database = New-AzureSqlDatabase -Context $context -DatabaseName $Name

		Scenario1-UpdateWithObject -Context $context

		Scenario2-UpdateWithName -Context $context
		
		Scenario3-RenameDatabase -Context $context
	}
	finally
	{
		# Drop Database
		Drop-Databases $Context $Name
		$context = $null
	}

	
	# Update with Cert Auth with Server Name
    try
	{
		Init-AzureSubscription $SubscriptionId $SerializedCert $Endpoint
		$sub = Get-AzureSubscription -Current

		$database = New-AzureSqlDatabase -ServerName $ServerName -DatabaseName $Name

		Scenario1-UpdateWithObject -ServerName $ServerName

		Scenario2-UpdateWithName -ServerName $ServerName
		
		Scenario3-RenameDatabase -ServerName $ServerName
	}
	finally
	{
		# Drop Database
		Drop-DatabasesWithServerName $ServerName $Name
		Remove-AzureSubscription $sub.SubscriptionName -Force
	}

    $IsTestPass = $True
}
finally
{
}

Write-TestResult $IsTestPass
