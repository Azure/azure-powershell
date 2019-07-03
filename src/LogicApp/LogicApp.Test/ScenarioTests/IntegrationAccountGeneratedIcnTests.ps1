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

# Constants used in the tests.
# To see up new resources for the tests, see "how-to-create-a-session.md"
$SESSION_RG = "flowrg"
$SESSION_IA = "PS-Tests-Sessions"
$AGREEMENT_X12_Name = "PS-X12-Agreement"
$AGREEMENT_Edifact_Name = "PS-Edifact-Agreement"

<#
.SYNOPSIS
Test Get-AzIntegrationAccountGeneratedIcn command
#>
function Test-GetGeneratedControlNumber()
{
	# Because there is no actual B2B connector activity, no generated control number will exist by default.
	# We also do not expose a Create cmdlet on generated control numbers because this is a dataplane only creation.
	# So working this around by using a pregenerated session in a hardcoded location.
	$resultNoType =  Get-AzIntegrationAccountGeneratedIcn -ResourceGroupName $SESSION_RG -Name $SESSION_IA -AgreementName $AGREEMENT_X12_Name
	Assert-AreEqual "1234" $resultNoType.ControlNumber
	Assert-AreEqual "X12" $resultNoType.MessageType

	$resultX12 =  Get-AzIntegrationAccountGeneratedIcn -ResourceGroupName $SESSION_RG -Name $SESSION_IA -AgreementName $AGREEMENT_X12_Name -AgreementType "X12"
	Assert-AreEqual "1234" $resultX12.ControlNumber
	Assert-AreEqual "X12" $resultX12.MessageType

	$resultEdifact =  Get-AzIntegrationAccountGeneratedIcn -ResourceGroupName $SESSION_RG -Name $SESSION_IA -AgreementName $AGREEMENT_Edifact_Name -AgreementType "Edifact"
	Assert-AreEqual "1234" $resultEdifact.ControlNumber
	Assert-AreEqual "Edifact" $resultEdifact.MessageType
}

<#
.SYNOPSIS
Test Set-AzIntegrationAccountGeneratedIcn command
#>
function Test-UpdateGeneratedControlNumber()
{
	# Because there is no actual B2B connector activity, no generated control number will exist by default.
	# We also do not expose a Create cmdlet on generated control numbers because this is a dataplane only creation.
	# So working this around by using a pregenerated session in a hardcoded location.
	$updatedControlNumber = Set-AzIntegrationAccountGeneratedIcn -AgreementType "X12" -ResourceGroupName $SESSION_RG -Name $SESSION_IA -AgreementName $AGREEMENT_X12_Name -ControlNumber "4321"
	Assert-AreEqual "4321" $updatedControlNumber.ControlNumber

	$updatedControlNumber = Set-AzIntegrationAccountGeneratedIcn -AgreementType "X12" -ResourceGroupName $SESSION_RG -Name $SESSION_IA -AgreementName $AGREEMENT_X12_Name -ControlNumber "1234"
	Assert-AreEqual "1234" $updatedControlNumber.ControlNumber
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccountGeneratedIcn command : paging test
#>
function Test-ListGeneratedControlNumber()
{
	# Because there is no actual B2B connector activity, no generated control number will exist by default.
	# We also do not expose a Create cmdlet on generated control numbers because this is a dataplane only creation.
	# So working this around by using a pregenerated session in a hardcoded location.
	$results =  Get-AzIntegrationAccountGeneratedIcn -ResourceGroupName $SESSION_RG -Name $SESSION_IA

	Assert-AreEqual "1234" $results[0].ControlNumber
}