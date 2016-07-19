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
Test New-AzureRmIntegrationAccountAgreement command
#>
function Test-CreateIntegrationAccountAgreementX12
{
	$agreementX12FilePath = "$TestOutputRoot\Resources\IntegrationAccountX12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)	

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountX12AgreementName = getAssetname
	$integrationAccountX12AgreementName1 = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$hostPartnerName = getAssetname	
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @{"AA" = "AA"; "BB" = "BB" }
	$guestBusinessIdentities = @{"ZZ" = "ZZ"; "XX" = "XX" }
	
	$hostPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities 
	$guestPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities
	
	$childItems = New-Object PSObject |
	   Add-Member -PassThru NoteProperty Item1 'ChildItem' |
	   Add-Member -PassThru NoteProperty Item2 1 |
	   Add-Member -PassThru NoteProperty Item3 ("Prop1","Prop2","Prop3") 

	$items = (New-Object PSObject |
	   Add-Member -PassThru NoteProperty Property1 'Main' |
	   Add-Member -PassThru NoteProperty Property2 $childItems
	)
	$metadata = $items | ConvertTo-JSON -Compress
	
	Assert-ThrowsContains {New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContent $agreementX12Content -Metadata "test" } "Invalid metadata."

	$integrationAccountAgreement0 =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContent $agreementX12Content -Metadata $metadata
	Assert-AreEqual $integrationAccountX12AgreementName $integrationAccountAgreement0.Name

	$integrationAccountAgreement1 =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName1 -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContentFilePath $agreementX12FilePath
	Assert-AreEqual $integrationAccountX12AgreementName1 $integrationAccountAgreement1.Name

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test New-AzureRmIntegrationAccountAgreement command
#>
function Test-CreateIntegrationAccountAgreementAS2
{
	$agreementAS2FilePath = "$TestOutputRoot\Resources\IntegrationAccountAS2AgreementContent.json"
	$agreementAS2Content = [IO.File]::ReadAllText($agreementAS2FilePath)	

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountAS2AgreementName = getAssetname
	$integrationAccountAS2AgreementName1 = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$hostPartnerName = getAssetname	
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @{"AA" = "AA"; "BB" = "BB" }
	$guestBusinessIdentities = @{"ZZ" = "ZZ"; "XX" = "XX" }
	$hostPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement3 =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAS2AgreementName -AgreementType "AS2" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContent $agreementAS2Content
	Assert-AreEqual $integrationAccountAS2AgreementName $integrationAccountAgreement3.Name

	$integrationAccountAgreement4 =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAS2AgreementName1 -AgreementType "AS2" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContentFilePath $agreementAS2FilePath
	Assert-AreEqual $integrationAccountAS2AgreementName1 $integrationAccountAgreement4.Name

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test New-AzureRmIntegrationAccountAgreement command
#>
function Test-CreateIntegrationAccountAgreementEdifact
{
	$agreementEdifactFilePath = "$TestOutputRoot\Resources\IntegrationAccountEdifactAgreementContent.json"
	$agreementEdifactContent = [IO.File]::ReadAllText($agreementEdifactFilePath)	
	
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountEdifactAgreementName = getAssetname
	$integrationAccountEdifactAgreementName1 = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$hostPartnerName = getAssetname	
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @{"AA" = "AA"; "BB" = "BB" }
	$guestBusinessIdentities = @{"ZZ" = "ZZ"; "XX" = "XX" }
	$hostPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement5 =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountEdifactAgreementName -AgreementType "Edifact" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContent $agreementEdifactContent
	Assert-AreEqual $integrationAccountEdifactAgreementName $integrationAccountAgreement5.Name

	$integrationAccountAgreement6 =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountEdifactAgreementName1 -AgreementType "Edifact" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContentFilePath $agreementEdifactFilePath
	Assert-AreEqual $integrationAccountEdifactAgreementName1 $integrationAccountAgreement6.Name

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}


<#
.SYNOPSIS
Test New-AzureRmIntegrationAccountAgreement command with negative scenario.
#>
function Test-CreateIntegrationAccountAgreementWithFailure
{
	$agreementX12FilePath = "$TestOutputRoot\Resources\IntegrationAccountX12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)	

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountX12AgreementName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$hostPartnerName = getAssetname	
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @{"AA" = "AA"; "BB" = "BB" }
	$guestBusinessIdentities = @{"ZZ" = "ZZ"; "XX" = "XX" }
	$hostPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities
	
	Assert-ThrowsContains {New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner "TestGuest" -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContent $agreementX12Content} "The partner 'TestGuest' could not be found in integration account '$integrationAccountName'."

	Assert-ThrowsContains {New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner "TestHost" -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContent $agreementX12Content} "The partner 'TestHost' could not be found in integration account '$integrationAccountName'."

	Assert-ThrowsContains {New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "BB" -HostIdentityQualifier "AA" -AgreementContent $agreementX12Content} "The qualifier 'BB' for partner '$guestPartnerName' is invalid."

	Assert-ThrowsContains {New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "OO" -AgreementContent $agreementX12Content} "The qualifier 'OO' for partner '$hostPartnerName' is invalid."

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountAgreement command
#>
function Test-GetIntegrationAccountAgreement
{
	$agreementX12FilePath = "$TestOutputRoot\Resources\IntegrationAccountX12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)	

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountX12AgreementName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$hostPartnerName = getAssetname	
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @{"AA" = "AA"; "BB" = "BB" }
	$guestBusinessIdentities = @{"ZZ" = "ZZ"; "XX" = "XX" }
	$hostPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement0 =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContent $agreementX12Content

	$result =  Get-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName
	Assert-AreEqual $integrationAccountX12AgreementName $result.Name

	$result1 =  Get-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName
	Assert-True { $result1.Count -gt 0 }	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzureRmIntegrationAccountAgreement command
#>
function Test-RemoveIntegrationAccountAgreement
{
	$agreementX12FilePath = "$TestOutputRoot\Resources\IntegrationAccountX12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)	

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountX12AgreementName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$hostPartnerName = getAssetname	
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @{"AA" = "AA"; "BB" = "BB" }
	$guestBusinessIdentities = @{"ZZ" = "ZZ"; "XX" = "XX" }
	$hostPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement0 =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContent $agreementX12Content

	Remove-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -Force	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountAgreement command
#>
function Test-UpdateIntegrationAccountAgreement
{
	$agreementX12FilePath = "$TestOutputRoot\Resources\IntegrationAccountX12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)	
	
	$agreementAS2FilePath = "$TestOutputRoot\Resources\IntegrationAccountAS2AgreementContent.json"
	$agreementAS2Content = [IO.File]::ReadAllText($agreementAS2FilePath)

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountAgreementName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$hostPartnerName = getAssetname	
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @{"AA" = "AA"; "BB" = "BB" }
	$guestBusinessIdentities = @{"ZZ" = "ZZ"; "XX" = "XX" }
	$hostPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -AgreementContent $agreementX12Content
	Assert-AreEqual $integrationAccountAgreementName $integrationAccountAgreement.Name
	Assert-AreEqual "X12" $integrationAccountAgreement.AgreementType

	$updatedIntegrationAccountAgreement =  Set-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "AS2" -AgreementContent $agreementAS2Content -Force
	Assert-AreEqual "AS2" $updatedIntegrationAccountAgreement.AgreementType

	$updatedIntegrationAccountAgreement =  Set-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "AS2" -AgreementContentFilePath $agreementAS2FilePath -Force
	Assert-AreEqual "AS2" $updatedIntegrationAccountAgreement.AgreementType

	$updatedIntegrationAccountAgreement =  Set-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -GuestIdentityQualifier "XX" -Force
	Assert-AreEqual "XX" $updatedIntegrationAccountAgreement.GuestIdentity.Qualifier
	Assert-AreEqual "XX" $updatedIntegrationAccountAgreement.GuestIdentity.Value

	$updatedIntegrationAccountAgreement =  Set-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -HostIdentityQualifier "BB" -Force
	Assert-AreEqual "BB" $updatedIntegrationAccountAgreement.HostIdentity.Qualifier
	Assert-AreEqual "BB" $updatedIntegrationAccountAgreement.HostIdentity.Value

	Assert-ThrowsContains {Set-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner "TestGuest" -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -Force} "The partner 'TestGuest' could not be found in integration account '$integrationAccountName'."

	Assert-ThrowsContains {Set-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner "TestHost" -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -Force} "The partner 'TestHost' could not be found in integration account '$integrationAccountName'."

	Assert-ThrowsContains {Set-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "BB" -HostIdentityQualifier "AA" -Force} "The qualifier 'BB' for partner '$guestPartnerName' is invalid."

	Assert-ThrowsContains {Set-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "OO" -Force} "The qualifier 'OO' for partner '$hostPartnerName' is invalid."

	$updatedIntegrationAccountAgreement =  Set-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -GuestPartner $hostPartnerName -HostPartner $guestPartnerName -Force
	Assert-AreEqual $hostPartnerName $updatedIntegrationAccountAgreement.GuestPartner
	Assert-AreEqual $guestPartnerName $updatedIntegrationAccountAgreement.HostPartner

	$childItems = New-Object PSObject |
	   Add-Member -PassThru NoteProperty Item1 'ChildItem' |
	   Add-Member -PassThru NoteProperty Item2 1 |
	   Add-Member -PassThru NoteProperty Item3 ("Prop1","Prop2","Prop3") 

	$items = (New-Object PSObject |
	   Add-Member -PassThru NoteProperty Property1 'Main' |
	   Add-Member -PassThru NoteProperty Property2 $childItems
	)

	$metadata = $items | ConvertTo-JSON -Compress

	Assert-ThrowsContains {Set-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -Metadata "test" -Force} "Invalid metadata."

	$updatedIntegrationAccountAgreement =  Set-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -Metadata $metadata	-Force
	
	$result = $updatedIntegrationAccountAgreement.Metadata.ToString() | ConvertFrom-JSON 
	Assert-AreEqualObjectProperties $items $result 
	
	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}