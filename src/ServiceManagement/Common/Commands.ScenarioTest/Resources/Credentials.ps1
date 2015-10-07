.".\CredUtils.ps1"
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

################################
#
# Verify that selecting a subscription correctly changes the current subscription
#
#    param [string] $Name: The name of the subscription
#    param [string] $Id  : The subscription Id
################################
function Test-SelectSubscription
{
   [CmdletBinding()]
    param(
	  [string] 
	  [Parameter(Mandatory=$true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)] 
	  $Name,
	  [string]  
	  [Parameter(Mandatory=$true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)] 
	  $Id
	)
	PROCESS
	{
	    Assert-True {($Name -and $Id)} "[select-subscription]: You must specify a Name and Id"
		Select-AzureSubscription -SubscriptionName $Name
		Write-Log "Selected subscription '$Name'"
		$subscription = Get-AzureSubscription -Current
		$subscription | Format-Subscription | Write-Log
		Assert-True { (($subscription.SubscriptionName -eq $Name) -and ($subscription.SubscriptionId -eq $Id))} "[Select-Subscription]: current subscription does not match '$Name'"
	}
}

######################################
#
# Select each subscription in a given puvlish settings file as the current subscription
#
#    param [string] $settingsFile: The publish settings file that contains the subscriptions
######################################
function Test-SelectValidSubscriptions
{
    param([string] $settingsFile)
	Remove-AllSubscriptions
	$subscriptions = @()
	$subscriptions += Get-Subscriptions $settingsFile
	Import-AzurePublishSettingsFile $settingsFile
	$subscriptions | Test-SelectSubscription
	Write-Log "Checking current subscription after remove all"
	Remove-AllSubscriptions
	Test-GetEmptyCurrentSubscription
}

##########################################
#
# Attempt to view the current subscription after clearing it
#
#    param [string] $settingsFile: The publish settings file that contains the subscriptions
##########################################
function Test-SelectSubscriptionAfterClear
{
    param([string] $settingsFile)
	Remove-AllSubscriptions
	$subscriptions = @()
	$subscriptions += Get-Subscriptions $settingsFile
	Import-AzurePublishSettingsFile $settingsFile
    Select-AzureSubscription ($subscriptions[0].Name)
	Select-AzureSubscription -Clear
	Test-GetEmptyCurrentSubscription
}

#######################################
#
# Test importing a publish settings file - determine the subscriptions that should be imported and validate
#   that they are imported correctly by the commandlet
#
#    param [string] $settingsFile: The publish settings file to import and validate
#######################################
function Test-ImportPublishSettingsFile
{
   param([string] $settingsFile)
   $subscriptions = @()
   $subscriptions += Get-Subscriptions $settingsFile
   return ImportAndVerify-PublishSettingsFile $settingsFile $subscriptions[0].Name $subscriptions
}

##############################################
#
# Test that an error is correctly thrown when attempting to import an invalid publishsettings file
#    param [string] $settingsFile: The path to the publishsettingsFile
#
##############################################
function Test-ImportInvalidPublishSettingsFile
{
    param([string] $settingsFile)
	$fileName = Get-FullName $settingsFile
    $message = "The provided publish settings file $fileName has invalid content. Please get valid by running cmdlet Get-AzurePublishSettingsFile"
	Assert-Throws {Import-AzurePublishSettingsFile $settingsFile} $message
}

##################################################
#
# Test that an appropriate error is thrown when attempting to import a non-existent publish settings file
##################################################
function Test-ImportNonExistentPublishSettingsFile
{
    $pathName = Get-FullName .\
	$fileName = [System.IO.Path]::Combine($pathName, "barrybar.publishsettings")
	$message = "Cannot find path '$fileName' because it does not exist."
	Assert-Throws {Import-AzurePublishSettingsFile $fileName} $message
}

#######################################
#
#  Validate that an informative error is thrown when attempting to remove an invalid subscription
#######################################
function Test-RemoveInvalidSubscription
{
    $message = "`"The subscription named 'foobar' cannot be found. Use Set-AzureSubscription to initialize the subscription data.`""
	Assert-Throws {Remove-AzureSubscription foobar} $message
}

#######################################
#
#  Validate that an informative error is thrown when attempting to remove an empty subscription
#######################################
function Test-RemoveEmptySubscription
{
    $message = "Cannot validate argument on parameter 'SubscriptionName'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again."
	Assert-Throws {Remove-AzureSubscription ""} $message
}

#######################################
#
#  Validate that nothing is returned when attempting to get an invalid subscription
#######################################
function Test-GetInvalidSubscription
{
    $foobar = "foobar"
	Assert-True {(Get-AzureSubscription $foobar) -eq $nul} "[test-getinvalidsubscription]: Getting an invalid subscription resulted in non-null output"
}

#######################################
#
#  Validate that an informative error is thrown when attempting to get an empty subscription
#######################################
function Test-GetEmptySubscription
{
    $message = "Cannot validate argument on parameter 'SubscriptionName'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again."
	Assert-Throws {Get-AzureSubscription ""} $message
}

#########################################
#
# Validate that an appropriate error is thrown when attempting to get a non-existent current subscription
#########################################
function Test-GetEmptyCurrentSubscription
{
    $message = "No subscription is currently selected. Use Select-Subscription to activate a subscription."
	Remove-AllSubscriptions
	Assert-Throws {Get-AzureSubscription -Current} $message
}

#########################################
#
# Validate that an appropriate error is thrown when attempting to get a non-existent current subscription
#########################################
function Test-GetEmptyDefaultSubscription
{
    $message = "No default subscription has been designated. Use Set-AzureSubscription -DefaultSubscription <subscriptionName> to set the default subscription."
	Remove-AllSubscriptions
	Assert-Throws {Get-AzureSubscription -Default} $message
}

#######################################
#
#  Validate that an informative error is thrown when attempting to select an invalid subscription
#######################################
function Test-SelectInvalidSubscription
{
    $message = "`"The subscription named 'foobar' cannot be found. Use Set-AzureSubscription to initialize the subscription data.`""
	Assert-Throws {Select-AzureSubscription foobar} $message
}

#######################################
#
#  Validate that an informative error is thrown when attempting to select an empty subscription
#######################################
function Test-SelectEmptySubscription
{
    $message = "Cannot validate argument on parameter 'SubscriptionName'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again."
	Assert-Throws {Select-AzureSubscription ""} $message
}
