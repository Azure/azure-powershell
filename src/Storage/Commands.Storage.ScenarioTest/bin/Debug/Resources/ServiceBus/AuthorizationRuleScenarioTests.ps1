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

########################################################################### General Service Bus Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests any cloud based cmdlet with invalid credentials and expect it'll throw an exception.
#>
function Test-WithInvalidCredentials
{
	param([ScriptBlock] $cloudCmdlet)
	
	# Setup
	Remove-AllSubscriptions

	# Test
	Assert-Throws $cloudCmdlet "No current subscription has been designated. Use Select-AzureSubscription -Current <subscriptionName> to set the current subscription."
}

########################################################################### New-AzureSBAuthorizationRule Scenario Tests ###########################################################################

<#
.SYNOPSIS
Test New-AzureSBAuthorizationRule when creating queue without passing any SAS keys.
#>
function Test-CreatesAuthorizationRuleWithoutKeys
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "Queue"
	$client = New-ServiceBusClientExtensions
	$client.CreateQueue($namespaceName, $entityName)

	# Test
	$actual = New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Manage", "Send", "Listen")

	# Assert
	$expectedConnectionString = $client.GetConnectionString($namespaceName, $entityName, $entityType, $actual.Name)
	Assert-AreEqual $ruleName $actual.Name
	Assert-AreEqual $expectedConnectionString $actual.ConnectionString
	Assert-AreEqual 3 $actual.Permission.Count
}

<#
.SYNOPSIS
Test New-AzureSBAuthorizationRule when creating topic with passing just primary key.
#>
function Test-CreatesAuthorizationRuleWithPrimaryKey
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "Topic"
	$client = New-ServiceBusClientExtensions
	$client.CreateTopic($namespaceName, $entityName)
	$primaryKey = [Microsoft.ServiceBus.Messaging.SharedAccessAuthorizationRule]::GenerateRandomKey()

	# Test
	$actual = New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Listen") -PrimaryKey $primaryKey

	# Assert
	$expectedConnectionString = $client.GetConnectionString($namespaceName, $entityName, $entityType, $actual.Name)
	Assert-AreEqual $ruleName $actual.Name
	Assert-AreEqual $expectedConnectionString $actual.ConnectionString
	Assert-AreEqual 1 $actual.Permission.Count
	Assert-AreEqual $primaryKey $actual.Rule.PrimaryKey
}

<#
.SYNOPSIS
Test New-AzureSBAuthorizationRule when creating relay with passing primary and secondary key.
#>
function Test-CreatesAuthorizationRuleWithPrimaryAndSecondaryKey
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "Relay"
	$client = New-ServiceBusClientExtensions
	$client.CreateRelay($namespaceName, $entityName, "Http")
	$primaryKey = [Microsoft.ServiceBus.Messaging.SharedAccessAuthorizationRule]::GenerateRandomKey()
	$secondaryKey = [Microsoft.ServiceBus.Messaging.SharedAccessAuthorizationRule]::GenerateRandomKey()

	# Test
	$actual = New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Send", "Listen") -PrimaryKey $primaryKey -SecondaryKey $secondaryKey

	# Assert
	$expectedConnectionString = $client.GetConnectionString($namespaceName, $entityName, $entityType, $actual.Name)
	Assert-AreEqual $ruleName $actual.Name
	Assert-AreEqual $expectedConnectionString $actual.ConnectionString
	Assert-AreEqual 2 $actual.Permission.Count
	Assert-AreEqual $primaryKey $actual.Rule.PrimaryKey
	Assert-AreEqual $secondaryKey $actual.Rule.SecondaryKey
}

<#
.SYNOPSIS
Test New-AzureSBAuthorizationRule on notification hub scope.
#>
function Test-CreatesAuthorizationRuleForNotificationHub
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "NotificationHub"
	$client = New-ServiceBusClientExtensions
	$client.CreateNotificationHub($namespaceName, $entityName)

	# Test
	$actual = New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Send")

	# Assert
	$expectedConnectionString = $client.GetConnectionString($namespaceName, $entityName, $entityType, $actual.Name)
	Assert-AreEqual $ruleName $actual.Name
	Assert-AreEqual $expectedConnectionString $actual.ConnectionString
	Assert-AreEqual 1 $actual.Permission.Count
}

<#
.SYNOPSIS
Test New-AzureSBAuthorizationRule on namespace scope.
#>
function Test-CreatesAuthorizationRuleForNamespace
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$ruleName = $namespaceName
	$client = New-ServiceBusClientExtensions

	# Test
	$actual = New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -Permission $("Send")

	# Assert
	$expectedConnectionString = $client.GetConnectionString($namespaceName, $actual.Name)
	Assert-AreEqual $ruleName $actual.Name
	Assert-AreEqual $expectedConnectionString $actual.ConnectionString
	Assert-AreEqual 1 $actual.Permission.Count
}

########################################################################### Set-AzureSBAuthorizationRule Scenario Tests ###########################################################################

<#
.SYNOPSIS
Test Set-AzureSBAuthorizationRule when creating queue and renewing primary key.
#>
function Test-SetsAuthorizationRuleRenewPrimaryKey
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$permission = $("Manage", "Send", "Listen")
	$entityType = "Queue"
	$client = New-ServiceBusClientExtensions
	$client.CreateQueue($namespaceName, $entityName)
	$actual = New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $permission
	$oldPrimaryKey = $actual.Rule.PrimaryKey

	# Test
	Set-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType

	# Assert
	$actual = $client.GetAuthorizationRule($namespaceName, $entityName, $entityType, $actual.Name)
	Assert-AreEqual $ruleName $actual.Name
	Assert-AreNotEqual $oldPrimaryKey $actual.Rule.PrimaryKey
	Assert-AreEqualArray $permission $actual.Permission
}

<#
.SYNOPSIS
Test Set-AzureSBAuthorizationRule when creating topic and setting secondary key.
#>
function Test-SetsAuthorizationRuleSecondaryKey
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "Topic"
	$permission = $("Manage", "Send", "Listen")
	$client = New-ServiceBusClientExtensions
	$client.CreateTopic($namespaceName, $entityName)
	$actual = New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $permission
	$oldSecondaryKey = $actual.Rule.SecondaryKey
	$newSecondaryKey = [Microsoft.ServiceBus.Messaging.SharedAccessAuthorizationRule]::GenerateRandomKey()

	# Test
	Set-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -SecondaryKey $newSecondaryKey

	# Assert
	$actual = $client.GetAuthorizationRule($namespaceName, $entityName, $entityType, $actual.Name)
	Assert-AreEqual $ruleName $actual.Name
	Assert-AreEqual $newSecondaryKey $actual.Rule.SecondaryKey
	Assert-AreEqualArray $permission $actual.Permission
}

<#
.SYNOPSIS
Test Set-AzureSBAuthorizationRule when creating notification hub and changing the permissions.
#>
function Test-SetsAuthorizationRuleForPermission
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$permission = $("Manage", "Send", "Listen")
	$entityType = "NotificationHub"
	$client = New-ServiceBusClientExtensions
	$client.CreateNotificationHub($namespaceName, $entityName)
	$actual = New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $permission
	$newPermission = $("Send")

	# Test
	Set-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $newPermission

	# Assert
	$actual = $client.GetAuthorizationRule($namespaceName, $entityName, $entityType, $actual.Name)
	$actualPermission = $actual.Permission
	Assert-AreEqual $ruleName $actual.Name
	Assert-AreNotEqual $oldPrimaryKey $actual.Rule.PrimaryKey
	Assert-AreEqualArray $newPermission $actualPermission
}

<#
.SYNOPSIS
Test Set-AzureSBAuthorizationRule on namespace level.
#>
function Test-SetsAuthorizationRuleOnNamespace
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$ruleName = $namespaceName
	$permission = $("Manage", "Send", "Listen")
	$client = New-ServiceBusClientExtensions
	$actual = New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -Permission $permission
	$newPermission = $("Send")

	# Test
	Set-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -Permission $newPermission

	# Assert
	$actual = $client.GetAuthorizationRule($namespaceName, $actual.Name)
	Assert-AreEqual $ruleName $actual.Name
	Assert-AreNotEqual $oldPrimaryKey $actual.Rule.PrimaryKey
	Assert-AreEqualArray $newPermission $actual.Permission
}

########################################################################### Remove-AzureSBAuthorizationRule Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests removing a namespace level authorization rule.
#>
function Test-RemovesNamespaceAuthorizationRule
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$ruleName = $namespaceName
	$client = New-ServiceBusClientExtensions
	New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -Permission $("Send")

	# Test
	$removed = Remove-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -PassThru

	# Assert
	Assert-Null $client.GetAuthorizationRule($namespaceName, $ruleName)
	Assert-True { $removed }
}

<#
.SYNOPSIS
Tests removing a queue entity authorization rule.
#>
function Test-RemovesQueueAuthorizationRule
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "Queue"
	$client = New-ServiceBusClientExtensions
	$client.CreateQueue($namespaceName, $entityName)
	New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Manage", "Send", "Listen")

	# Test
	$removed = Remove-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -PassThru

	# Assert
	$actual = $client.GetAuthorizationRule($namespaceName, $entityName, $entityType, $ruleName)
	Assert-Null $actual
	Assert-True { $removed }
}

<#
.SYNOPSIS
Tests removing a topic entity authorization rule.
#>
function Test-RemovesTopicAuthorizationRule
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "Topic"
	$client = New-ServiceBusClientExtensions
	$client.CreateTopic($namespaceName, $entityName)
	New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Manage", "Send", "Listen")

	# Test
	$removed = Remove-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -PassThru

	# Assert
	$actual = $client.GetAuthorizationRule($namespaceName, $entityName, $entityType, $ruleName)
	Assert-Null $actual
	Assert-True { $removed }
}

<#
.SYNOPSIS
Tests removing a relay entity authorization rule.
#>
function Test-RemovesRelayAuthorizationRule
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "Relay"
	$client = New-ServiceBusClientExtensions
	$client.CreateRelay($namespaceName, $entityName, "Http")
	New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Manage", "Send", "Listen")

	# Test
	$removed = Remove-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -PassThru

	# Assert
	$actual = $client.GetAuthorizationRule($namespaceName, $entityName, $entityType, $ruleName)
	Assert-Null $actual
	Assert-True { $removed }
}

<#
.SYNOPSIS
Tests removing a notification hub entity authorization rule.
#>
function Test-RemovesNotificationHubAuthorizationRule
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "NotificationHub"
	$client = New-ServiceBusClientExtensions
	$client.CreateNotificationHub($namespaceName, $entityName)
	New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Manage", "Send", "Listen")

	# Test
	$removed = Remove-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -PassThru

	# Assert
	$actual = $client.GetAuthorizationRule($namespaceName, $entityName, $entityType, $ruleName)
	Assert-Null $actual
	Assert-True { $removed }
}

########################################################################### Get-AzureSBAuthorizationRule Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests getting all authorization rules on a given namespace.
#>
function Test-GetsNamespaceAuthorizationRules
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$ruleName = $namespaceName
	$client = New-ServiceBusClientExtensions
	New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -Permission $("Manage", "Send", "Listen")
	New-AzureSBAuthorizationRule -Name "onesdktestrule21" -Namespace $namespaceName -Permission $("Manage", "Send", "Listen")

	# Test
	$actual = Get-AzureSBAuthorizationRule -Namespace $namespaceName

	# Assert
	Assert-AreEqual 3 $actual.Count
}

<#
.SYNOPSIS
Tests getting specific authorization rules on a queue.
#>
function Test-GetsQueueSpecificAuthorizationRule
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "NotificationHub"
	$client = New-ServiceBusClientExtensions
	$client.CreateNotificationHub($namespaceName, $entityName)
	New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Manage", "Send", "Listen")

	# Test
	$actual = Get-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType

	# Assert
	Assert-AreEqual $ruleName $actual.Name
}

<#
.SYNOPSIS
Tests getting all authorization rules on a notification hub filtered by Permission.
#>
function Test-FilterAuthorizationRulesByPermission
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "NotificationHub"
	$client = New-ServiceBusClientExtensions
	$client.CreateNotificationHub($namespaceName, $entityName)
	New-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Send", "Listen")
	New-AzureSBAuthorizationRule -Name "onesdkrulehub1" -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Listen")
	New-AzureSBAuthorizationRule -Name "onesdkrulehub2" -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Send")

	# Test
	$actual = Get-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType -Permission $("Send")

	# Assert
	Assert-AreEqual 1 $actual.Count
}

<#
.SYNOPSIS
Tests getting authorization rules on a topic that does not have any authorization rules.
#>
function Test-GetsEmptyListForTopic
{
	# Setup
	Initialize-NamespaceTest
	New-Namespace 1
	$namespaceName = $createdNamespaces[0]
	$entityName = $namespaceName
	$ruleName = $namespaceName
	$entityType = "Topic"
	$client = New-ServiceBusClientExtensions
	$client.CreateTopic($namespaceName, $entityName)

	# Test
	$actual = Get-AzureSBAuthorizationRule -Name $ruleName -Namespace $namespaceName -EntityName $entityName `
		-EntityType $entityType

	# Assert
	Assert-AreEqual 0 $actual.Count
}