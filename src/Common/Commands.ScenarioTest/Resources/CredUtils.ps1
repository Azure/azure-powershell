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

.".\Common.ps1"
#######################################
#
# Import the given subscription if it has not already been imported
#
#    param [string] $subscriptionName: the subscription to import
#    param [string] $publishFile     : the path to the publishsettings file with crednentials for the 
#     given subscription
#######################################
function Import-SubscriptionIfNecessary 
{
    param( [String] $subscriptionName, [String] $publishFile)
    Write-Log "[import-subscriptionifnecessary]: Setting subscription with $subscriptionName, using publish settings file $publishFile\r\n"
    $subscription = Get-AzureSubscription $subscriptionName
    if ($subscription -eq $NULL) 
	{
       Write-Log "[import-subsctiptionifnecessary]: subscription $subscriptionName not found, importing publish settings file $publishFile\r\n"
       Import-AzurePublishSettingsFile $publishFile
    }
    
    Select-AzureSubscription $subscriptionName
    $currentSub = Get-AzureSubscription -Current
	Write-Log $currentSub
    if ($subscriptionName -ne $currentSub.SubscriptionName) 
	{
        throw "[import-subscriptionIfNecessary]: Unable to set current subscription to $subscriptionName"
    }
    
    return $currentSub | Select-Object SubscriptionName,SubscriptionId
}

################################
#
# Remove all subscriptions from the current context
################################
function Remove-AllSubscriptions 
{
    try {
    foreach ($subscription in  Get-AzureSubscription) 
	{
	  $toss = Remove-AzureSubscription $subscription.SubscriptionName
	}
	
	Assert-True { (Get-AzureSubscription) -eq $nul} "[Remove-AllSubscriptions]: all subscriptions not removed"
	}
	catch
	{
	    Assert-True {$_.Exception.Message -eq "Could not find publish settings. Please run Import-AzurePublishSettingsFile."}
	}
}
############################################
#
# Select only the relevant columns from a subscription
#
#    parm [SubscriptionData] $subscription: the subscription object to write out
############################################
function Format-Subscription 
{
    [CmdletBinding()]
    param([Parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$false)] [Microsoft.WindowsAzure.Commands.Utilities.Common.SubscriptionData] $subscription)
	PROCESS
	{
	    Select-Object -InputObject $subscription -Property SubscriptionName,SubscriptionId,ServiceEndpoint,IsDefault | Format-List | Out-String
	}
}


function Check-SubscriptionMatch
{
    param([string] $baseSubscriptionName, [Microsoft.WindowsAzure.Commands.Utilities.Common.SubscriptionData] $checkedSubscription)
	Write-Log ("[CheckSubscriptionMatch]: base subscription: '$baseSubscriptionName', validating '" + ($checkedSubscription.SubscriptionName)+ "'")
	Format-Subscription $checkedSubscription | Write-Log
	if ($baseSubscriptionName -ne $checkedSubscription.SubscriptionName) 
	{
	    throw ("[Check-SubscriptionMatch]: Subscription Match Failed '" + ($baseSubscriptionName) + "' != '" + ($checkedSubscription.SubscriptionName) + "'")
	}
	
    Write-Log ("CheckSubscriptionMatch]: subscription check succeeded.")
}

##########################
#
#  Find a subscription in a list of expected subscriptions
#    param $input: A list of subscriptiondata
##########################
function Find-Subscription
{
    param( [Microsoft.WindowsAzure.Commands.Utilities.Common.SubscriptionData] $subscription, [array] $subscriptions)
    $subscriptions | Where-Object {$_.Name -eq $subscription.SubscriptionName}
}
############################################
#
# Import the given publish settings file and verify that that the given subscriptions are present and 
#  current subscription is set appropriately
#
#    param [string] $settingsPath       : Path to the setting file to import
#    param [string] $currentSubscription: The subscription that should be current after import
#    param [array] $subscriptions       : The set of subscriptions that should be imported
############################################
function ImportAndVerify-PublishSettingsFile 
{
    param([string] $settingsPath, [string] $currentSubscription, [array] $subscriptions)
	Remove-AllSubscriptions
	Write-Log "[importandverify-publishsettingsfile]: Importing publish settings file: $settingsPath"
	Import-AzurePublishSettingsFile $settingsPath
	Write-Log "[importandverify-publishsettingsfile]: Checking Current subscription."
	Check-SubscriptionMatch $currentSubscription (Get-AzureSubscription -Current)
	Write-Log "[importandverify-publishsettingsfile]: Checking Default subscription."
	Check-SubscriptionMatch $currentSubscription (Get-AzureSubscription -Default)
	Write-Log "[importandverify-publishsettingsfile]: Checking all existing subscriptions."
	$allSubscriptions = (Get-AzureSubscription)
	$allSubscriptions | Format-Subscription | Write-Log
	foreach ($subscription in $allSubscriptions)
	{
	    Write-Log ("[importandverify-publishsettingsfile]: Checking subscription '" + $subscription.SubscriptionName + "'")
		Assert-True {(Find-Subscription $subscription $subscriptions) -ne $nul} ("[importandverify-publishsettings]: Could not find subscription '" + $subscription.SubscriptionName + "'")
	}
	
	Write-Log "[importandverify-publishsettingsfile]: Checking each subscription individually."
	foreach ($subscription in $subscriptions)
	{
	    $subData = Get-AzureSubscription $subscription.Name
		Write-Log ("[importandverify-publishsettingsfile]: Subscription data: " + $subscription.Name)
		Format-Subscription $subData | Write-Verbose
		if ($subData.SubscriptionId -ne $subscription.Id) 
		{
		    throw "[importandverify-publishsettingsfile]: Unable to find subscription $subscription.Name in imported set"
		}
		else 
		{
		    Remove-AzureSubscription $subscription.Name
		}
	}
	return $true
}

##########################
#
# Get subscription information from a publish settings file via xpath, used to validate import
#
#    param [string] $settingsFile: The publish settings file to check
#
##########################
function Get-Subscriptions
{
   param([string] $settingsFile)
   Write-Log "[get-subscriptions]: Reading subscriptions from publish settings file '$settingsFile'"
   $subscriptionList = @()
   $settings = New-Object System.Xml.XmlDocument
   $settingsPath = Get-FullName $settingsFile
   $settings.load($settingsPath)
   $xpath = $settings.CreateNavigator()
   foreach ($subscriptionNode in $xpath.Select("//Subscription")) 
   {
      $subName = $subscriptionNode.GetAttribute("Name", "")
	  $subId = $subscriptionNode.GetAttribute("Id", "")
      $subscription = New-Object System.Object 
	  $subscription | Add-Member -MemberType NoteProperty -Name "Name" -Value $subName 
	  $subscription | Add-Member -MemberType NoteProperty -Name "Id" -Value $subId
	  $subscriptionList += $subscription
   }
   
   return $subscriptionList
}
