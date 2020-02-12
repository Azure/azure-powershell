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
Validates a string is not null or empty
#>
function Assert-NotNullOrEmpty
{
	param([string] $value)

	Assert-False { [string]::IsNullOrEmpty($value) }
}

<#
.SYNOPSIS
Validates an object is instance of a type
#>
function Assert-IsInstance
{
	param([object] $obj, [Type] $type)

	Assert-AreEqual $obj.GetType() $type
}

<#
.SYNOPSIS
Validates property count of a custom object
#>
function Assert-PropertiesCount
{
	param([PSCustomObject] $obj, [int] $count)

	$properties = $obj.PSObject.Properties
	Assert-AreEqual $([System.Linq.Enumerable]::ToArray($properties).Count) $count
}

<#
.SYNOPSIS
Creates a PSContactProfile object
#>
function Get-Contact
{
	param(
			[string] $firstName, 
			[string] $lastName, 
			[string] $primaryEmailAddress,	
			[string] $country,	
			[string] $preferredSupportLanguage, 
			[string] $preferredContactMethod, 
			[string] $preferredTimeZone,
			[string] $phoneNumber,
			[string[]] $additionalEmailAddresses
		 )

	$c=new-object Microsoft.Azure.Commands.Support.Models.PSContactProfile
	$c.FirstName = $firstName  
	$c.LastName = $lastName 
	$c.PrimaryEmailAddress = $primaryEmailAddress
	$c.Country = $country
	$c.PreferredSupportLanguage = $preferredSupportLanguage
	$c.PreferredContactMethod = $preferredContactMethod 
	$c.PreferredTimeZone = $preferredTimeZone
	$c.PhoneNumber = $phoneNumber
	$c.AdditionalEmailAddresses = $additionalEmailAddresses
	return $c
}

<#
.SYNOPSIS
Create a new support ticket
#>
function New-SupportTicketWith24X7Response
{
    param(
			[string] $serviceDisplayName = "billing", 
			[string] $problemClassificationDisplayName = $null,
			[string] $title = "test ticket from azure powershell scenario test. please ignore and close", 
			[string] $description = "test ticket from azure powershell scenario test. please ignore and close", 
			[string] $firstName = "first", 
			[string] $lastName = "last", 
			[string] $primaryEmailAddress = "user@contoso.com", 
			[string] $preferredContactMethod = "email",
			[string] $country = "USA",
			[string] $preferredSupportLanguage = "en-US",
			[string] $preferredTimeZone = "Pacific Standard Time",
			[string] $phoneNumber = "2222",
			[string[]]$additionalEmailAddresses = @('user2@contoso.com'),
			[string] $technicalTicketResourceId = $null,
			[Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail] $quotaTicketDetails = $null
		 )

	$service = Get-AzSupportService | where {$_.DisplayName.ToLower().Contains($serviceDisplayName.ToLower())}
	
	$problemClassification = ""
	
	if (!$problemClassificationDisplayName)
	{
		$problemClassifications = $service | Get-AzSupportProblemClassification 
		$problemClassification = $problemClassifications[0]
	}
	else
	{
		$problemClassification = $service | Get-AzSupportProblemClassification | where {$_.DisplayName.ToLower().Contains($problemClassificationDisplayName.ToLower())}
	}

	$contactDetails = Get-Contact -firstName $firstName -lastName $lastName -preferredContactMethod $preferredContactMethod -preferredTimeZone $preferredTimeZone -country $country -preferredSupportLanguage $preferredSupportLanguage -primaryEmailAddress $primaryEmailAddress -phoneNumber $phoneNumber -additionalEmailAddresses $additionalEmailAddresses

	$resourceName = getAssetName -preFix "PowershellScenarioTest"
	if (!$quotaTicketDetails -AND !$technicalTicketResourceId)
	{
		$result = New-AzSupportTicket -Name $resourceName -Title $title -Description $description -ProblemClassificationId $problemClassification.Id -Severity "minimal" -CustomerContactDetail $contactDetails -Require24X7Response
		return $result
	}
	elseif (!$quotaTicketDetails)
	{
		$result = New-AzSupportTicket -Name $resourceName -Title $title -Description $description -ProblemClassificationId $problemClassification.Id -Severity "minimal" -CustomerContactDetail $contactDetails -TechnicalTicketResourceId $technicalTicketResourceId -Require24X7Response
		return $result
	}
	else
	{
		$result = New-AzSupportTicket -Name $resourceName -Title $title -Description $description -ProblemClassificationId $problemClassification.Id -Severity "minimal" -CustomerContactDetail $contactDetails -QuotaTicketDetail $quotaTicketDetails -Require24X7Response
		return $result
	}
	return $result
}

function New-SupportTicketWithContactDetail
{
    param(
			[string] $serviceDisplayName = "billing", 
			[string] $problemClassificationDisplayName = $null,
			[string] $title = "test ticket from azure powershell scenario test. please ignore and close", 
			[string] $description = "test ticket from azure powershell scenario test. please ignore and close", 
			[string] $firstName = "first", 
			[string] $lastName = "last", 
			[string] $primaryEmailAddress = "user@contoso.com", 
			[string] $preferredContactMethod = "email",
			[string] $country = "USA",
			[string] $preferredSupportLanguage = "en-US",
			[string] $preferredTimeZone = "Pacific Standard Time",
			[string] $phoneNumber = "2222",
			[string[]] $additionalEmailAddresses = @('user2@contoso.com'),
			[string] $technicalTicketResourceId = $null,
			[Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail] $quotaTicketDetails = $null
		 )

	$service = Get-AzSupportService | where {$_.DisplayName.ToLower().Contains($serviceDisplayName.ToLower())}
	
	$problemClassification = ""
	
	if (!$problemClassificationDisplayName)
	{
		$problemClassifications = $service | Get-AzSupportProblemClassification 
		$problemClassification = $problemClassifications[0]
	}
	else
	{
		$problemClassification = $service | Get-AzSupportProblemClassification | where {$_.DisplayName.ToLower().Contains($problemClassificationDisplayName.ToLower())}
	}

	$contactDetails = Get-Contact -firstName $firstName -lastName $lastName -preferredContactMethod $preferredContactMethod -preferredTimeZone $preferredTimeZone -country $country -preferredSupportLanguage $preferredSupportLanguage -primaryEmailAddress $primaryEmailAddress -phoneNumber $phoneNumber -additionalEmailAddresses $additionalEmailAddresses

	$resourceName = getAssetName -preFix "PowershellScenarioTest"
	if (!$quotaTicketDetails -AND !$technicalTicketResourceId)
	{
		$result = New-AzSupportTicket -Name $resourceName -Title $title -Description $description -ProblemClassificationId $problemClassification.Id -Severity "minimal" -CustomerFirstName $contactDetails.FirstName -CustomerLastName $contactDetails.LastName -CustomerPrimaryEmailAddress $contactDetails.PrimaryEmailAddress -CustomerPreferredTimeZone $contactDetails.PreferredTimeZone -CustomerCountry $contactDetails.Country -CustomerPreferredSupportLanguage $contactDetails.PreferredSupportLanguage -PreferredContactMethod $contactDetails.PreferredContactMethod -CustomerPhoneNumber $contactDetails.PhoneNumber -AdditionalEmailAddress $contactDetails.AdditionalEmailAddresses
		return $result
	}
	elseif (!$quotaTicketDetails)
	{
		$result = New-AzSupportTicket -Name $resourceName -Title $title -Description $description -ProblemClassificationId $problemClassification.Id -Severity "minimal" -TechnicalTicketResourceId $technicalTicketResourceId -CustomerFirstName $contactDetails.FirstName -CustomerLastName $contactDetails.LastName -CustomerPrimaryEmailAddress $contactDetails.PrimaryEmailAddress -CustomerPreferredTimeZone $contactDetails.PreferredTimeZone -CustomerCountry $contactDetails.Country -CustomerPreferredSupportLanguage $contactDetails.PreferredSupportLanguage -PreferredContactMethod $contactDetails.PreferredContactMethod -CustomerPhoneNumber $contactDetails.PhoneNumber -AdditionalEmailAddress $contactDetails.AdditionalEmailAddresses
		return $result
	}
	else
	{
		$result = New-AzSupportTicket -Name $resourceName -Title $title -Description $description -ProblemClassificationId $problemClassification.Id -Severity "minimal" -QuotaTicketDetail $quotaTicketDetails -CustomerFirstName $contactDetails.FirstName -CustomerLastName $contactDetails.LastName -CustomerPrimaryEmailAddress $contactDetails.PrimaryEmailAddress -CustomerPreferredTimeZone $contactDetails.PreferredTimeZone -CustomerCountry $contactDetails.Country -CustomerPreferredSupportLanguage $contactDetails.PreferredSupportLanguage -PreferredContactMethod $contactDetails.PreferredContactMethod -CustomerPhoneNumber $contactDetails.PhoneNumber -AdditionalEmailAddress $contactDetails.AdditionalEmailAddresses
		return $result
	}
	return $result
}

function New-CspSupportTicket
{
    param(
			[string] $serviceDisplayName = "billing", 
			[string] $problemClassificationDisplayName = $null,
			[string] $title = "test ticket from azure powershell scenario test. please ignore and close", 
			[string] $description = "test ticket from azure powershell scenario test. please ignore and close", 
			[string] $firstName = "first", 
			[string] $lastName = "last", 
			[string] $primaryEmailAddress = "user@contoso.com", 
			[string] $preferredContactMethod = "email",
			[string] $country = "USA",
			[string] $preferredSupportLanguage = "en-US",
			[string] $preferredTimeZone = "Pacific Standard Time",
			[string] $phoneNumber = "2222",
			[string[]]$additionalEmailAddresses = @('user2@contoso.com'),
			[string] $technicalTicketResourceId = $null,
			[Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail] $quotaTicketDetails = $null,
			[string] $cspHomeTenantId
		 )

	$service = Get-AzSupportService | where {$_.DisplayName.ToLower().Contains($serviceDisplayName.ToLower())}
	
	$problemClassification = ""
	
	if (!$problemClassificationDisplayName)
	{
		$problemClassifications = $service | Get-AzSupportProblemClassification 
		$problemClassification = $problemClassifications[0]
	}
	else
	{
		$problemClassification = $service | Get-AzSupportProblemClassification | where {$_.DisplayName.ToLower().Contains($problemClassificationDisplayName.ToLower())}
	}

	$contactDetails = Get-Contact -firstName $firstName -lastName $lastName -preferredContactMethod $preferredContactMethod -preferredTimeZone $preferredTimeZone -country $country -preferredSupportLanguage $preferredSupportLanguage -primaryEmailAddress $primaryEmailAddress -phoneNumber $phoneNumber -additionalEmailAddresses $additionalEmailAddresses

	$resourceName = getAssetName -preFix "PowershellScenarioTest"
	if (!$quotaTicketDetails -AND !$technicalTicketResourceId)
	{
		$result = New-AzSupportTicket -Name $resourceName -Title $title -Description $description -ProblemClassificationId $problemClassification.Id -Severity "minimal" -CustomerContactDetail $contactDetails -CSPHomeTenantId $cspHomeTenantId
		return $result
	}
	elseif (!$quotaTicketDetails)
	{
		$result = New-AzSupportTicket -Name $resourceName -Title $title -Description $description -ProblemClassificationId $problemClassification.Id -Severity "minimal" -CustomerContactDetail $contactDetails -TechnicalTicketResourceId $technicalTicketResourceId -CSPHomeTenantId $cspHomeTenantId
		return $result
	}
	else
	{
		$result = New-AzSupportTicket -Name $resourceName -Title $title -Description $description -ProblemClassificationId $problemClassification.Id -Severity "minimal" -CustomerContactDetail $contactDetails -QuotaTicketDetail $quotaTicketDetails -CSPHomeTenantId $cspHomeTenantId
		return $result
	}
	return $result
}

<#
.SYNOPSIS
Create a new support ticket communication
#>
function New-SupportTicketCommunication
{
    param(
			[Parameter(Mandatory=$true)]
			[string] $supportTicketName, 
			[string] $subject = "this is a test subject from powershell scenario test", 
			[string] $body = "this is a test subject from powershell scenario test",
			[string] $senderAddress = "user@contoso.com"
		 )

	$resourceName = getAssetName -preFix "testmessage"
	$result = New-AzSupportTicketCommunication -Name $resourceName -SupportTicketName $supportTicketName -Subject $subject -Body $body -Sender $senderAddress

	return $result
}