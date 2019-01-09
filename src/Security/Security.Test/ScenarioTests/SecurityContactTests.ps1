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
Get security contacts on a subscription
#>
function Get-AzureRmSecurityContact-SubscriptionScope
{
	Set-AzSecurityContact -Name "default1" -Email "ascasc@microsoft.com" -Phone "123123123" -AlertAdmin -NotifyOnAlert

    $contacts = Get-AzSecurityContact
	Validate-Contacts $contacts
}

<#
.SYNOPSIS
Get a security contact
#>
function Get-AzureRmSecurityContact-SubscriptionLevelResource
{
	Set-AzSecurityContact -Name "default1" -Email "ascasc@microsoft.com" -Phone "123123123" -AlertAdmin -NotifyOnAlert

    $contact = Get-AzSecurityContact -Name "default1"
	Validate-Contact $contact
}

<#
.SYNOPSIS
Get a security contact by resource ID
#>
function Get-AzureRmSecurityContact-ResourceId
{
	$contact = Set-AzSecurityContact -Name "default1" -Email "ascasc@microsoft.com" -Phone "123123123" -AlertAdmin -NotifyOnAlert

    $fetchedContact = Get-AzSecurityContact -ResourceId $contact.Id
	Validate-Contact $fetchedContact
}

<#
.SYNOPSIS
Set a security contact on a subscription
#>
function Set-AzureRmSecurityContact-SubscriptionLevelResource
{
    Set-AzSecurityContact -Name "default1" -Email "ascasc@microsoft.com" -Phone "123123123" -AlertAdmin -NotifyOnAlert
}

<#
.SYNOPSIS
Set a security contact on a subscription
#>
function Set-AzureRmSecurityContact-SubscriptionLevelResource-Secondary
{
    Set-AzSecurityContact -Name "default2" -Email "ascasc@microsoft.com"
}

<#
.SYNOPSIS
Delete a security contact on a subscription
#>
function Remove-AzureRmSecurityContact-SubscriptionLevelResource
{
	Set-AzSecurityContact -Name "default1" -Email "ascasc@microsoft.com" -Phone "123123123" -AlertAdmin -NotifyOnAlert
    Remove-AzSecurityContact -Name "default1"
}

<#
.SYNOPSIS
Validates a list of security contacts
#>
function Validate-Contacts
{
	param($contacts)

    Assert-True { $contacts.Count -gt 0 }

	Foreach($contact in $contacts)
	{
		Validate-Contact $contact
	}
}

<#
.SYNOPSIS
Validates a single contact
#>
function Validate-Contact
{
	param($contact)

	Assert-NotNull $contact
}