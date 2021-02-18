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
Get support ticket by name parameter set
#>
function Get-AzSupportTicketByNameParameterSet
{
	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"

	$queryResult = Get-AzSupportTicket -First 1
	$supportTicketName = $queryResult[0].Name

	$queryResult = Get-AzSupportTicket -Name $supportTicketName
	Assert-NotNull  $queryResult

	Assert-IsInstance $queryResult $cmdletReturnType
	Assert-PropertiesCount $queryResult $propertiesCount
	Assert-IsInstance $queryResult.Name String
}

<#
.SYNOPSIS
Get support tickets filtered by status
#>
function Get-AzSupportTicketFilterByStatus
{
	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"

	$queryResult = Get-AzSupportTicket -First 1 -Filter "Status eq 'Closed'"
	Assert-NotNull  $queryResult
	Assert-AreEqual 1 $queryResult.Count

	for ($i = 0; $i -lt $queryResult.Count; $i++)
	{
		Assert-IsInstance $queryResult[$i] $cmdletReturnType
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-IsInstance $queryResult[$i].Name String
		Assert-AreEqual "closed" $queryResult[$i].Status.ToLower()
	}
}

<#
.SYNOPSIS
Get support tickets using paging parameter
#>
function Get-AzSupportTicketPagingParameters
{
	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"

	$queryResult = Get-AzSupportTicket -First 1 -Skip 1
	Assert-NotNull  $queryResult
	Assert-AreEqual 1 $queryResult.Count

	for ($i = 0; $i -lt $queryResult.Count; $i++)
	{
		Assert-IsInstance $queryResult[$i] $cmdletReturnType
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-IsInstance $queryResult[$i].Name String
	}
}

<#
.SYNOPSIS
New support ticket
#>
function New-AzSupportTicketWithContactObject
{
 	$result = New-SupportTicketWith24X7Response

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $result
	Assert-IsInstance $result $cmdletReturnType
	Assert-PropertiesCount $result $propertiesCount
	Assert-IsInstance $result.Name String
	Assert-AreEqual "true" $result.Require24X7Response.ToString().ToLower()
	Assert-AreEqual "test ticket from azure powershell scenario test. please ignore and close" $result.Title
	Assert-AreEqual "test ticket from azure powershell scenario test. please ignore and close" $result.Description
	Assert-AreEqual "minimal" $result.Severity.ToString().ToLower()
	Assert-AreEqual "first" $result.ContactDetail.FirstName
	Assert-AreEqual "last" $result.ContactDetail.LastName
	Assert-AreEqual "usa" $result.ContactDetail.Country.ToLower()
	Assert-AreEqual "pacific standard time" $result.ContactDetail.PreferredTimeZone.ToLower()
	Assert-AreEqual "en-us" $result.ContactDetail.PreferredSupportLanguage.ToLower()
	Assert-AreEqual "2222" $result.ContactDetail.PhoneNumber
	Assert-AreEqual "user@contoso.com" $result.ContactDetail.PrimaryEmailAddress
	Assert-AreEqual "user2@contoso.com" $result.ContactDetail.AdditionalEmailAddresses[0]
	Assert-AreEqual "open" $result.Status
	Assert-NotNullOrEmpty $result.ServiceId
	Assert-NotNullOrEmpty $result.ServiceDisplayName
	Assert-NotNullOrEmpty $result.ProblemClassificationId
	Assert-NotNullOrEmpty $result.ProblemClassificationDisplayName
	Assert-NotNull $result.ServiceLevelAgreement
}

<#
.SYNOPSIS
New quota support ticket
#>
function New-AzSupportTicketQuotaWithContactObject
{
    $quotaChangeRequest = new-object Microsoft.Azure.Commands.Support.Models.PSQuotaChangeRequest
	$quotaChangeRequest.Region = "EastUS"
	$quotaChangeRequest.Payload = "{`"VMFamily`":`"Dv2 Series`",`"NewLimit`":516}"

    $quotaTicketDetail = new-object Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
	$quotaTicketDetail.QuotaChangeRequestVersion = "1.0"
	$quotaTicketDetail.QuotaChangeRequests = @($quotaChangeRequest)

	$result = New-SupportTicketWith24X7Response -serviceDisplayName "Service and subscription limits" -problemClassificationDisplayName "Compute" -quotaTicketDetails $quotaTicketDetail

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $result
	Assert-IsInstance $result $cmdletReturnType
	Assert-PropertiesCount $result $propertiesCount
	Assert-IsInstance $result.Name String
	Assert-AreEqual "true" $result.Require24X7Response.ToString().ToLower()
	Assert-NotNull $result.QuotaTicketDetail
	Assert-NotNull $result.QuotaTicketDetail.QuotaChangeRequests
	Assert-AreEqual 1 $result.QuotaTicketDetail.QuotaChangeRequests.Length
	Assert-AreEqual "1.0" $result.QuotaTicketDetail.QuotaChangeRequestVersion
}

<#
.SYNOPSIS
New technical support ticket
#>
function New-AzSupportTicketTechnicalWithContactObject
{
	$resource = Get-AzureRmResource -ResourceType "Microsoft.Compute/virtualMachines"
	$result = New-SupportTicketWith24X7Response -serviceDisplayName "Virtual Machine" -technicalTicketResourceId $resource[0].Id

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $result
	Assert-IsInstance $result $cmdletReturnType
	Assert-PropertiesCount $result $propertiesCount
	Assert-IsInstance $result.Name String
	Assert-AreEqual "true" $result.Require24X7Response.ToString().ToLower()
	Assert-NotNullOrEmpty $result.TechnicalTicketResourceId
}

<#
.SYNOPSIS
New support ticket
#>
function New-AzSupportTicketWithContactDetail
{
 	$result = New-SupportTicketWithContactDetail

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $result
	Assert-IsInstance $result $cmdletReturnType
	Assert-PropertiesCount $result $propertiesCount
	Assert-IsInstance $result.Name String
	Assert-AreEqual "false" $result.Require24X7Response.ToString().ToLower()
	Assert-AreEqual "test ticket from azure powershell scenario test. please ignore and close" $result.Title
	Assert-AreEqual "test ticket from azure powershell scenario test. please ignore and close" $result.Description
	Assert-AreEqual "minimal" $result.Severity.ToString().ToLower()
	Assert-AreEqual "first" $result.ContactDetail.FirstName
	Assert-AreEqual "last" $result.ContactDetail.LastName
	Assert-AreEqual "usa" $result.ContactDetail.Country.ToLower()
	Assert-AreEqual "pacific standard time" $result.ContactDetail.PreferredTimeZone.ToLower()
	Assert-AreEqual "en-us" $result.ContactDetail.PreferredSupportLanguage.ToLower()
	Assert-AreEqual "2222" $result.ContactDetail.PhoneNumber
	Assert-AreEqual "user@contoso.com" $result.ContactDetail.PrimaryEmailAddress
	Assert-AreEqual "user2@contoso.com" $result.ContactDetail.AdditionalEmailAddresses[0]
	Assert-AreEqual "open" $result.Status
	Assert-NotNullOrEmpty $result.ServiceId
	Assert-NotNullOrEmpty $result.ServiceDisplayName
	Assert-NotNullOrEmpty $result.ProblemClassificationId
	Assert-NotNullOrEmpty $result.ProblemClassificationDisplayName
	Assert-NotNull $result.ServiceLevelAgreement
}

<#
.SYNOPSIS
New quota support ticket
#>
function New-AzSupportTicketQuotaWithContactDetail
{
    $quotaChangeRequest = new-object Microsoft.Azure.Commands.Support.Models.PSQuotaChangeRequest
	$quotaChangeRequest.Region = "EastUS"
	$quotaChangeRequest.Payload = "{`"VMFamily`":`"Dv2 Series`",`"NewLimit`":516}"

    $quotaTicketDetail = new-object Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
	$quotaTicketDetail.QuotaChangeRequestVersion = "1.0"
	$quotaTicketDetail.QuotaChangeRequests = @($quotaChangeRequest)

	$result = New-SupportTicketWithContactDetail -serviceDisplayName "Service and subscription limits" -problemClassificationDisplayName "Compute" -quotaTicketDetails $quotaTicketDetail

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $result
	Assert-IsInstance $result $cmdletReturnType
	Assert-PropertiesCount $result $propertiesCount
	Assert-IsInstance $result.Name String
	Assert-AreEqual "false" $result.Require24X7Response.ToString().ToLower()
	Assert-NotNull $result.QuotaTicketDetail
	Assert-NotNull $result.QuotaTicketDetail.QuotaChangeRequests
	Assert-AreEqual 1 $result.QuotaTicketDetail.QuotaChangeRequests.Length
	Assert-AreEqual "1.0" $result.QuotaTicketDetail.QuotaChangeRequestVersion
}

<#
.SYNOPSIS
New technical support ticket
#>
function New-AzSupportTicketTechnicalWithContactDetail
{
	$resource = Get-AzureRmResource -ResourceType Microsoft.Compute/virtualMachines

	$result = New-SupportTicketWithContactDetail -serviceDisplayName "Virtual Machine" -technicalTicketResourceId $resource[0].Id

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $result
	Assert-IsInstance $result $cmdletReturnType
	Assert-PropertiesCount $result $propertiesCount
	Assert-IsInstance $result.Name String
	Assert-AreEqual "false" $result.Require24X7Response.ToString().ToLower()
	Assert-NotNullOrEmpty $result.TechnicalTicketResourceId
}

<#
.SYNOPSIS
New CSP support ticket
#>
function New-AzSupportTicketCspWithContactObject
{
	$result = New-CspSupportTicket -CSPHomeTenantId "8465bc54-690d-4169-b3fd-dc47631637c2"

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $result
	Assert-IsInstance $result $cmdletReturnType
	Assert-PropertiesCount $result $propertiesCount
	Assert-IsInstance $result.Name String
}

<#
.SYNOPSIS
Update support ticket by parent object paremeter set with contact object
#>
function Update-AzSupportTicketParentObjectParameterSetWithContactObject
{
	$newTicket = New-SupportTicketWithContactDetail
	$contactDetail = $newTicket.ContactDetail
	$contactDetail.FirstName = "first updated"
	$contactDetail.LastName = "last updated"
	$contactDetail.PrimaryEmailAddress = "user2@contoso.com"
	$contactDetail.PhoneNumber = "2222"
	$contactDetail.PreferredTimeZone = "Eastern Standard Time"
	$contactDetail.Country = "IND"
	$contactDetail.PreferredSupportLanguage = "ja-jp"
	$contactDetail.AdditionalEmailAddresses = @("user3@contoso.com")
	$updateTicket = $newTicket | Update-AzSupportTicket -CustomerContactDetail $contactDetail

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $updateTicket
	Assert-IsInstance $updateTicket $cmdletReturnType
	Assert-PropertiesCount $updateTicket $propertiesCount
	Assert-IsInstance $updateTicket.Name String
	Assert-AreEqual "first updated" $updateTicket.ContactDetail.FirstName
	Assert-AreEqual "last updated" $updateTicket.ContactDetail.LastName
	Assert-AreEqual "ind" $updateTicket.ContactDetail.Country.ToLower()
	Assert-AreEqual "eastern standard time" $updateTicket.ContactDetail.PreferredTimeZone.ToLower()
	Assert-AreEqual "ja-jp" $updateTicket.ContactDetail.PreferredSupportLanguage.ToLower()
	Assert-AreEqual "2222" $updateTicket.ContactDetail.PhoneNumber
	Assert-AreEqual "user2@contoso.com" $updateTicket.ContactDetail.PrimaryEmailAddress
	Assert-AreEqual "user3@contoso.com" $updateTicket.ContactDetail.AdditionalEmailAddresses[0]
}

<#
.SYNOPSIS
Update support ticket by parent object paremeter set with contact object
#>
function Update-AzSupportTicketParentObjectParameterSetUpdateSeverity
{
	$newTicket = New-SupportTicketWithContactDetail
	$updateTicket = $newTicket | Update-AzSupportTicket -Severity "Critical"

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $updateTicket
	Assert-IsInstance $updateTicket $cmdletReturnType
	Assert-PropertiesCount $updateTicket $propertiesCount
	Assert-IsInstance $updateTicket.Name String
	Assert-AreEqual "critical" $updateTicket.Severity.ToLower()
}

<#
.SYNOPSIS
Update support ticket by parent object paremeter set with contact object
#>
function Update-AzSupportTicketParentObjectParameterSetUpdateStatus
{
	$newTicket = New-SupportTicketWithContactDetail
	$updateTicket = $newTicket | Update-AzSupportTicket -Status "Closed"

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $updateTicket
	Assert-IsInstance $updateTicket $cmdletReturnType
	Assert-PropertiesCount $updateTicket $propertiesCount
	Assert-IsInstance $updateTicket.Name String
	Assert-AreEqual "closed" $updateTicket.Status.ToLower()
}

<#
.SYNOPSIS
Update support ticket by name parameter set with contact object
#>
function Update-AzSupportTicketNameParameterSetWithContactObject
{
	$newTicket = New-SupportTicketWithContactDetail
	$contactDetail = $newTicket.ContactDetail
	$contactDetail.FirstName = "first updated"
	$contactDetail.LastName = "last updated"
	$updateTicket = Update-AzSupportTicket -Name $newTicket.Name -CustomerContactDetail $contactDetail

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $updateTicket
	Assert-IsInstance $updateTicket $cmdletReturnType
	Assert-PropertiesCount $updateTicket $propertiesCount
	Assert-IsInstance $updateTicket.Name String
	Assert-AreEqual "first updated" $updateTicket.ContactDetail.FirstName
	Assert-AreEqual "last updated" $updateTicket.ContactDetail.LastName
}

<#
.SYNOPSIS
Update support ticket by name parameter set with contact object
#>
function Update-AzSupportTicketNameParameterSetUpdateSeverity
{
	$newTicket = New-SupportTicketWithContactDetail
	$updateTicket = Update-AzSupportTicket -Name $newTicket.Name -Severity "Critical"

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $updateTicket
	Assert-IsInstance $updateTicket $cmdletReturnType
	Assert-PropertiesCount $updateTicket $propertiesCount
	Assert-IsInstance $updateTicket.Name String
	Assert-AreEqual "critical" $updateTicket.Severity.ToLower()
}

<#
.SYNOPSIS
Update support ticket by name parameter set with contact object
#>
function Update-AzSupportTicketNameParameterSetUpdateStatus
{
	$newTicket = New-SupportTicketWithContactDetail
	$updateTicket = Update-AzSupportTicket -Name $newTicket.Name -Status "Closed"

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $updateTicket
	Assert-IsInstance $updateTicket $cmdletReturnType
	Assert-PropertiesCount $updateTicket $propertiesCount
	Assert-IsInstance $updateTicket.Name String
	Assert-AreEqual "closed" $updateTicket.Status.ToLower()
}

<#
.SYNOPSIS
Update support ticket by parent object paremeter set with contact detail
#>
function Update-AzSupportTicketParentObjectParameterSetWithContactDetail
{
	$newTicket = New-SupportTicketWithContactDetail
	$updateTicket = $newTicket | Update-AzSupportTicket -CustomerFirstName "first updated" -CustomerLastName "last updated" -CustomerPrimaryEmailAddress "user2@contoso.com" -CustomerCountry "IND" -CustomerPreferredTimeZone "Eastern Standard Time" -CustomerPreferredSupportLanguage "ja-jp" -AdditionalEmailAddress @("user3@contoso.com")

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $updateTicket
	Assert-IsInstance $updateTicket $cmdletReturnType
	Assert-PropertiesCount $updateTicket $propertiesCount
	Assert-IsInstance $updateTicket.Name String
	Assert-AreEqual "first updated" $updateTicket.ContactDetail.FirstName
	Assert-AreEqual "last updated" $updateTicket.ContactDetail.LastName
	Assert-AreEqual "ind" $updateTicket.ContactDetail.Country.ToLower()
	Assert-AreEqual "eastern standard time" $updateTicket.ContactDetail.PreferredTimeZone.ToLower()
	Assert-AreEqual "ja-jp" $updateTicket.ContactDetail.PreferredSupportLanguage.ToLower()
	Assert-AreEqual "2222" $updateTicket.ContactDetail.PhoneNumber
	Assert-AreEqual "user2@contoso.com" $updateTicket.ContactDetail.PrimaryEmailAddress
	Assert-AreEqual "user3@contoso.com" $updateTicket.ContactDetail.AdditionalEmailAddresses[0]
}

<#
.SYNOPSIS
Update support ticket by name parameter set with contact detail
#>
function Update-AzSupportTicketNameParameterSetWithContactDetail
{
	$newTicket = New-SupportTicketWithContactDetail
	$updateTicket = Update-AzSupportTicket -Name $newTicket.Name -CustomerFirstName "first updated" -CustomerLastName "last updated" -CustomerPrimaryEmailAddress "user2@contoso.com" -CustomerCountry "IND" -CustomerPreferredTimeZone "Eastern Standard Time" -CustomerPreferredSupportLanguage "ja-jp" -AdditionalEmailAddress @("user3@contoso.com")

	$propertiesCount = 23
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicket"
	Assert-NotNull  $updateTicket
	Assert-IsInstance $updateTicket $cmdletReturnType
	Assert-PropertiesCount $updateTicket $propertiesCount
	Assert-IsInstance $updateTicket.Name String
    Assert-AreEqual "first updated" $updateTicket.ContactDetail.FirstName
	Assert-AreEqual "last updated" $updateTicket.ContactDetail.LastName
	Assert-AreEqual "ind" $updateTicket.ContactDetail.Country.ToLower()
	Assert-AreEqual "eastern standard time" $updateTicket.ContactDetail.PreferredTimeZone.ToLower()
	Assert-AreEqual "ja-jp" $updateTicket.ContactDetail.PreferredSupportLanguage.ToLower()
	Assert-AreEqual "2222" $updateTicket.ContactDetail.PhoneNumber
	Assert-AreEqual "user2@contoso.com" $updateTicket.ContactDetail.PrimaryEmailAddress
	Assert-AreEqual "user3@contoso.com" $updateTicket.ContactDetail.AdditionalEmailAddresses[0]
}



