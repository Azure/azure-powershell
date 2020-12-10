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
.SYNOPSIS
List Data Connectors
#>
function Get-AzSentinelDataConnector-List
{
	$DataConnectorId = "934ce201-63c5-4911-9e04-50b348020378"
	#Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId $DataConnectorId -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	#Get Data Connector
    $DataConnectors = Get-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName)
	# Validate
	Validate-DataConnectors $DataConnectors

	Start-Sleep 15
	#Cleanup
	Remove-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId ($DataConnector.Name)
}

<#
.SYNOPSIS
Get Data Connector
#>
function Get-AzSentinelDataConnector-Get
{
	$DataConnectorId = "3da7055e-fcd4-4715-b2ab-72170ee57612"
	#Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId $DataConnectorId -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	
	#Get Data Connector
    $DataConnector = Get-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId ($DataConnector.Name)
	# Validate
	Validate-DataConnector $DataConnector

	#Cleanup
	Remove-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId ($DataConnector.Name)
}

<#
.SYNOPSIS
Create Data Connector
#>
function New-AzSentinelDataConnector-Create
{
    $DataConnectorId = "cd2f31a6-98db-4834-8696-36a184436387"
	#Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId $DataConnectorId -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	
	# Validate
	Validate-DataConnector $DataConnector

	#Cleanup
	Remove-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId ($DataConnector.Name)
}

<#
.SYNOPSIS
Update DataConnector
#>
function Update-AzSentinelDataConnector-Update
{
	$DataConnectorId = "f3abb0bf-9f8b-4f03-8865-8e71e2889ba2"
	#Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId $DataConnectorId -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	
	#Update Data Connector
    $DataConnector2 = Update-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId ($DataConnector.Name) -Alerts Disabled
	# Validate
	Validate-DataConnector $DataConnector2

	#Cleanup
	Remove-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId ($DataConnector.Name)
}

function Update-AzSentinelDataConnector-InputObject
{
	$DataConnectorId = "44c3bfc6-5361-41af-a50d-65232c3f9b13"
	#Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId $DataConnectorId -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	#Update Data Connector
    $DataConnector2 = $DataConnector | Update-AzSentinelDataConnector -Alerts Disabled
	# Validate
	Validate-DataConnector $DataConnector2

	#Cleanup
	Remove-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId ($DataConnector.Name)
}

<#
.SYNOPSIS
Delete Data Connector
#>
function Remove-AzSentinelDataConnector-Delete
{
	$DataConnectorId = "f2bc6c20-6785-4b98-8dd3-26767b7de5b4"
	#Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId $DataConnectorId -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	
	#Update Data Connector
    Remove-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId ($DataConnector.Name)
	
	# Validate
	Validate-DataConnector $DataConnector

}

<#
.SYNOPSIS
Validates a list of data connectors
#>
function Validate-DataConnectors
{
	param($DataConnectors)

    Assert-True { $DataConnectors.Count -gt 0 }

	Foreach($DataConnector in $DataConnectors)
	{
		Validate-DataConnector $DataConnector
	}
}

<#
.SYNOPSIS
Validates a single data connector
#>
function Validate-DataConnector
{
	param($DataConnector)

	Assert-NotNull $DataConnector
}