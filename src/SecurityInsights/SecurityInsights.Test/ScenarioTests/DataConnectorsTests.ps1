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
	
	#Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
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
	#Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	
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
function New-AzSentinelDataConnector-CreateFusion
{
    #Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	
	# Validate
	Validate-DataConnector $DataConnector

	#Cleanup
	Remove-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId ($DataConnector.Name)
}

<#
.SYNOPSIS
Update DataConnector
#>
function Set-AzSentinelDataConnector-Update
{
	#Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	
	#Update Data Connector
    $DataConnector = Set-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId ($DataConnector.Name) -Etag ($DataConnector.Etag) -AzureSecurityCenter -Alerts Disabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	# Validate
	Validate-DataConnector $DataConnector

	#Cleanup
	Remove-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DataConnectorId ($DataConnector.Name)
}

function Set-AzSentinelDataConnector-InputObject
{
	#Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	$DataConnector.DataTypes.Alerts.State = "disabled"
	#Update Data Connector
    $DataConnector2 = $DataConnector | Set-AzSentinelDataConnector
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
	#Create Data Connector
	$DataConnector = New-AzSentinelDataConnector -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)
	
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