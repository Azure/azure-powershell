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
New communication using name parameter set
#>
function New-AzSupportTicketCommunicationNameParameterSet
{
    $propertiesCount = 9
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicketCommunication"

 	$ticket = New-SupportTicketWith24X7Response 
    $result = New-SupportTicketCommunication -supportTicketName $ticket.Name

    Assert-NotNull  $result
	Assert-IsInstance $result $cmdletReturnType
	Assert-PropertiesCount $result $propertiesCount
	Assert-IsInstance $result.Name String
}

<#
.SYNOPSIS
New communication using parent object parameter set
#>
function New-AzSupportTicketCommunicationParentObjectParameterSet
{
    $propertiesCount = 9
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicketCommunication"

 	$ticket = New-SupportTicketWith24X7Response 
    $communicationResourceName = getAssetName -preFix "testmessage"
    $result = $ticket | New-AzSupportTicketCommunication -Name $communicationResourceName -Body "test body from powershell scenario test" -Subject "test subject from powershell scenario test" -Sender "user@contoso.com"

    Assert-NotNull  $result
	Assert-IsInstance $result $cmdletReturnType
	Assert-PropertiesCount $result $propertiesCount
	Assert-IsInstance $result.Name String
}

<#
.SYNOPSIS
Gets communication by name
#>
function Get-AzSupportTicketCommunicationByNameParameterSet
{
    $propertiesCount = 9
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicketCommunication"

    $ticket = New-SupportTicketWith24X7Response 
    $communication = New-SupportTicketCommunication -supportTicketName $ticket.Name

    $result = Get-AzSupportTicketCommunication -SupportTicketName $ticket.Name -Name $communication.Name

    Assert-NotNull  $result
	Assert-IsInstance $result $cmdletReturnType
	Assert-PropertiesCount $result $propertiesCount
	Assert-IsInstance $result.Name String
}

<#
.SYNOPSIS
Gets communication using parent object parameter set
#>
function Get-AzSupportTicketCommunicationByParentObjectParameterSet
{
    $propertiesCount = 9
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicketCommunication"

    $ticket = New-SupportTicketWith24X7Response 
    $communication = New-SupportTicketCommunication -supportTicketName $ticket.Name

    $result = $ticket | Get-AzSupportTicketCommunication -Name $communication.Name

    Assert-NotNull  $result
	Assert-IsInstance $result $cmdletReturnType
	Assert-PropertiesCount $result $propertiesCount
	Assert-IsInstance $result.Name String
}

<#
.SYNOPSIS
Gets communications by paging parameters
#>
function Get-AzSupportTicketCommunicationPagingParameters
{
    $propertiesCount = 9
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicketCommunication"

    $ticket = New-SupportTicketWith24X7Response 
    $communication1 = New-SupportTicketCommunication -supportTicketName $ticket.Name
    $communication2 = New-SupportTicketCommunication -supportTicketName $ticket.Name

    $queryResult = Get-AzSupportTicketCommunication -SupportTicketName $ticket.Name -First 1 -Skip 1

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
Gets communication by filter parameter
#>
function Get-AzSupportTicketCommunicationFilterByCommunicationType
{
	$propertiesCount = 9
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportTicketCommunication"

    $ticket = New-SupportTicketWith24X7Response 
    $communication1 = New-SupportTicketCommunication -supportTicketName $ticket.Name
    $communication2 = New-SupportTicketCommunication -supportTicketName $ticket.Name

    $queryResult = Get-AzSupportTicketCommunication -SupportTicketName $ticket.Name -Filter "CommunicationType eq 'Web'" -First 1 -Skip 1

    Assert-NotNull  $queryResult
	Assert-AreEqual 1 $queryResult.Count

	for ($i = 0; $i -lt $queryResult.Count; $i++)
	{
		Assert-IsInstance $queryResult[$i] $cmdletReturnType
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-IsInstance $queryResult[$i].Name String
	}
}


