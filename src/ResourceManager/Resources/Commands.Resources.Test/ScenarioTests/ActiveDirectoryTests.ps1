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
Tests getting Active Directory groups.
#>
function Test-GetAllADGroups
{
    # Test
    $groups = Get-AzureRmADGroup

    # Assert
    Assert-NotNull($groups)
    foreach($group in $groups) {
        Assert-NotNull($group.DisplayName)
        Assert-NotNull($group.Id)
    }
}

<#
.SYNOPSIS
Tests getting Active Directory groups.
#>
function Test-GetADGroupWithSearchString 
{
    param([string]$displayName)
    
    # Test
    # Select at most 10 groups. Groups are restricted to contain "test" to fasten the test
    $groups = Get-AzureRmADGroup -SearchString $displayName

    # Assert
    Assert-AreEqual $groups.Count 1
    Assert-NotNull $groups[0].Id
    Assert-AreEqual $groups[0].DisplayName $displayName
}

<#
.SYNOPSIS
Tests getting Active Directory groups.
#>
function Test-GetADGroupWithBadSearchString
{
    # Test
    # Select at most 10 groups. Groups are restricted to contain "test" to fasten the test
    $groups = Get-AzureRmADGroup -SearchString "BadSearchString"

    # Assert
    Assert-Null($groups)
}

<#
.SYNOPSIS
Tests getting Active Directory groups.
#>
function Test-GetADGroupWithObjectId
{
    param([string]$objectId)
    
    # Test
    $groups = Get-AzureRmADGroup -ObjectId $objectId

    # Assert
    Assert-AreEqual $groups.Count 1
    Assert-AreEqual $groups[0].Id $objectId
    Assert-NotNull($groups[0].DisplayName)
}

<#
.SYNOPSIS
Tests getting Active Directory group with security enabled .
#>
function Test-GetADGroupSecurityEnabled
{
    param([string]$objectId, [string]$securityEnabled)
    
    # Test
    $groups = Get-AzureRmADGroup -ObjectId $objectId

    # Assert
    Assert-AreEqual $groups.Count 1
    Assert-AreEqual $groups[0].Id $objectId
    Assert-AreEqual $groups[0].SecurityEnabled $securityEnabled
    Assert-NotNull($groups[0].DisplayName)
}

<#
.SYNOPSIS
Tests getting Active Directory groups.
#>
function Test-GetADGroupWithBadObjectId
{
    # Test
    $groups = Get-AzureRmADGroup -ObjectId "baadc0de-baad-c0de-baad-c0debaadc0de"

    # Assert
    Assert-Null $groups
}

<#
.SYNOPSIS
Tests getting Active Directory groups.
#>
function Test-GetADGroupWithUserObjectId
{
    param([string]$objectId)

    # Test
    $groups = Get-AzureRmADGroup -ObjectId $objectId

    # Assert
    Assert-Null $groups
}

<#
.SYNOPSIS
Tests getting members from an Active Directory group.
#>
function Test-GetADGroupMemberWithGroupObjectId
{
    param([string]$groupObjectId, [string]$userObjectId, [string]$userName)

    # Test
    $members = Get-AzureRmADGroupMember -GroupObjectId $groupObjectId
    
    # Assert 
    Assert-AreEqual $members.Count 1
    Assert-AreEqual $members[0].Id $userObjectId
    Assert-AreEqual $members[0].DisplayName $userName
}

<#
.SYNOPSIS
Tests getting members from an Active Directory group.
#>
function Test-GetADGroupMemberWithBadGroupObjectId
{
    # Test
    Assert-Throws { Get-AzureRmADGroupMember -GroupObjectId "baadc0de-baad-c0de-baad-c0debaadc0de" }    
}

<#
.SYNOPSIS
Tests getting members from an Active Directory group.
#>
function Test-GetADGroupMemberWithUserObjectId
{
    param([string]$objectId)

    # Test
    Assert-Throws { Get-AzureRmADGroupMember -GroupObjectId $objectId }    
}

<#
.SYNOPSIS
Tests getting members from an Active Directory group.
#>
function Test-GetADGroupMemberFromEmptyGroup
{
    param([string]$objectId)

    # Test
    $members = Get-AzureRmADGroupMember -GroupObjectId $objectId
    
    # Assert 
    Assert-Null($members)
}

<#
.SYNOPSIS
Tests getting Active Directory service principals.
#>
function Test-GetADServicePrincipalWithObjectId
{
    param([string]$objectId)

    # Test
    $servicePrincipals = Get-AzureRmADServicePrincipal -ObjectId $objectId

    # Assert
    Assert-AreEqual $servicePrincipals.Count 1
    Assert-AreEqual $servicePrincipals[0].Id $objectId
}

<#
.SYNOPSIS
Tests getting Active Directory service principals.
#>
function Test-GetADServicePrincipalWithBadObjectId
{
    # Test
    $servicePrincipals = Get-AzureRmADServicePrincipal -ObjectId "baadc0de-baad-c0de-baad-c0debaadc0de"

    # Assert
    Assert-Null($servicePrincipals)
}

<#
.SYNOPSIS
Tests getting Active Directory service principals.
#>
function Test-GetADServicePrincipalWithUserObjectId
{
    param([string]$objectId)

    # Test
    $servicePrincipals = Get-AzureRmADServicePrincipal -ObjectId $objectId

    # Assert
    Assert-Null($servicePrincipals)
}

<#
.SYNOPSIS
Tests getting Active Directory service principals.
#>
function Test-GetADServicePrincipalWithSPN
{
    param([string]$SPN)

    # Test
    $servicePrincipals = Get-AzureRmADServicePrincipal -ServicePrincipalName $SPN

    # Assert
    Assert-AreEqual $servicePrincipals.Count 1
    Assert-NotNull $servicePrincipals[0].Id
	Assert-True { $servicePrincipals[0].ServicePrincipalNames.Contains($SPN) }
}

<#
.SYNOPSIS
Tests getting Active Directory service principals.
#>
function Test-GetADServicePrincipalWithBadSPN
{
    # Test
    $servicePrincipals = Get-AzureRmADServicePrincipal -ServicePrincipalName "badspn"

    # Assert
    Assert-Null($servicePrincipals)
}

<#
.SYNOPSIS
Tests getting Active Directory service principals.
#>
function Test-GetADServicePrincipalWithSearchString
{
    param([string]$displayName)

    # Test
    $servicePrincipals = Get-AzureRmADServicePrincipal -SearchString $displayName

    # Assert
    Assert-AreEqual $servicePrincipals.Count 1
    Assert-AreEqual $servicePrincipals[0].DisplayName $displayName
    Assert-NotNull($servicePrincipals[0].Id)
    Assert-NotNull($servicePrincipals[0].ServicePrincipalNames)
	Assert-AreEqual $servicePrincipals[0].ServicePrincipalNames.Count 2
}

<#
.SYNOPSIS
Tests getting Active Directory service principals.
#>
function Test-GetADServicePrincipalWithBadSearchString
{
    # Test
    $servicePrincipals = Get-AzureRmADServicePrincipal -SearchString "badsearchstring"

    # Assert
    Assert-Null($servicePrincipals)
}

<#
.SYNOPSIS
Tests getting Active Directory users.
#>
function Test-GetAllADUser
{
    # Test
    $users = Get-AzureRmADUser

    # Assert
    Assert-NotNull($users)
    foreach($user in $users) {
        Assert-NotNull($user.DisplayName)
        Assert-NotNull($user.Id)
    }
}

<#
.SYNOPSIS
Tests getting Active Directory users.
#>
function Test-GetADUserWithObjectId
{
    param([string]$objectId)

    # Test
    $users = Get-AzureRmADUser -ObjectId $objectId

    # Assert
    Assert-AreEqual $users.Count 1
    Assert-AreEqual $users[0].Id $objectId
    Assert-NotNull($users[0].DisplayName)
    Assert-NotNull($users[0].UserPrincipalName)
}


<#
.SYNOPSIS
Tests getting Active Directory users by mail.
#>
function Test-GetADUserWithMail
{
    param([string]$mail)

    # Test
    $users = Get-AzureRmADUser -Mail $mail

    # Assert
    Assert-AreEqual $users.Count 1
    #Assert-AreEqual $users[0].Mail $mail
    Assert-NotNull($users[0].DisplayName)
    Assert-NotNull($users[0].UserPrincipalName)
}

<#
.SYNOPSIS
Tests getting Active Directory users.
#>
function Test-GetADUserWithBadObjectId
{
    # Test
    $users = Get-AzureRmADUser -ObjectId "baadc0de-baad-c0de-baad-c0debaadc0de"

    # Assert
    Assert-Null($users)
}

<#
.SYNOPSIS
Tests getting Active Directory users.
#>
function Test-GetADUserWithGroupObjectId
{
    param([string]$objectId)

    # Test
    $users = Get-AzureRmADUser -ObjectId $objectId

    # Assert
    Assert-Null($users)
}

<#
.SYNOPSIS
Tests getting Active Directory users.
#>
function Test-GetADUserWithUPN
{
    param([string]$UPN)

    # Test
    $users = Get-AzureRmADUser -UserPrincipalName $UPN

    # Assert
    Assert-AreEqual $users.Count 1
    Assert-AreEqual $users[0].UserPrincipalName $UPN
    Assert-NotNull($users[0].DisplayName)
    Assert-NotNull($users[0].Id)
}

<#
.SYNOPSIS
Tests getting Active Directory users.
#>
function Test-GetADUserWithFPOUPN
{
    # Test
    $users = Get-AzureRmADUser -UserPrincipalName "azsdkposhteam_outlook.com#EXT#@rbactest.onmicrosoft.com"

    # Assert
    Assert-AreEqual $users.Count 1
    Assert-AreEqual $users[0].UserPrincipalName "azsdkposhteam_outlook.com#EXT#@rbactest.onmicrosoft.com"
    Assert-NotNull($users[0].DisplayName)
    Assert-NotNull($users[0].Id)
}

<#
.SYNOPSIS
Tests getting Active Directory users.
#>
function Test-GetADUserWithBadUPN
{
    # Test
    $users = Get-AzureRmADUser -UserPrincipalName "baduser@rbactest.onmicrosoft.com"

    # Assert
    Assert-Null($users)
}

<#
.SYNOPSIS
Tests getting Active Directory users.
#>
function Test-GetADUserWithSearchString
{
    param([string]$displayName)

    # Test
    # Select at most 10 users. Users are restricted to contain "test" to fasten the test
    $users = Get-AzureRmADUser -SearchString $displayName

    # Assert
    Assert-NotNull($users)
    Assert-AreEqual $users[0].DisplayName $displayName
    Assert-NotNull($users[0].Id)
    Assert-NotNull($users[0].UserPrincipalName)
}

<#
.SYNOPSIS
Tests getting Active Directory users.
#>
function Test-GetADUserWithBadSearchString
{
    # Test
    # Select at most 10 users. Users are restricted to contain "test" to fasten the test
    $users = Get-AzureRmADUser -SearchString "badsearchstring"

    # Assert
    Assert-Null($users)
}

<#
.SYNOPSIS
Tests Creating and deleting application.
#>
function Test-NewADApplication
{
    # Setup
    $displayName = getAssetName
    $homePage = "http://" + $displayName + ".com"
    $identifierUri = "http://" + $displayName

    # Test
    $application = New-AzureRmADApplication -DisplayName $displayName -HomePage $homePage -IdentifierUris $identifierUri

    # Assert
    Assert-NotNull $application

	# Get Application by ObjectId
	$app1 =  Get-AzureRmADApplication -ObjectId $application.ObjectId
	Assert-NotNull $app1
	Assert-AreEqual $app1.Count 1

	# Get Application by ApplicationId
	$app1 =  Get-AzureRmADApplication -ApplicationId $application.ApplicationId
	Assert-NotNull $app1
	Assert-AreEqual $app1.Count 1

	# Get Application by IdentifierUri
	$app1 = Get-AzureRmADApplication -IdentifierUri $application.IdentifierUris[0]
	Assert-NotNull $app1
	Assert-AreEqual $app1.Count 1

	# Get Application by DisplayName
	$app1 = Get-AzureRmADApplication -DisplayNameStartWith $application.DisplayName
	Assert-NotNull $app1
	Assert-True { $app1.Count -ge 1}

	$newDisplayName = getAssetName
    $newHomePage = "http://" + $newDisplayName + ".com"
    $newIdentifierUri = "http://" + $newDisplayName
	
	# Update displayName and HomePage
	Set-AzureRmADApplication -ObjectId $application.ObjectId -DisplayName $newDisplayName -HomePage $newHomePage

	# Update identifierUri 
	Set-AzureRmADApplication -ApplicationId $application.ApplicationId -IdentifierUris $newIdentifierUri
	
	# Get application and verify updated properties
	$app1 =  Get-AzureRmADApplication -ObjectId $application.ObjectId
	Assert-NotNull $app1
	Assert-AreEqual $app1.Count 1
	Assert-AreEqual $app1.DisplayName $newDisplayName
	Assert-AreEqual $app1.HomePage $newHomePage
	Assert-AreEqual $app1.IdentifierUris[0] $newIdentifierUri

	# Delete 
	Remove-AzureRmADApplication -ObjectId $application.ObjectId -Force
}

<#
.SYNOPSIS
Tests Creating and deleting service principal.
#>
function Test-NewADServicePrincipal
{
    param([string]$applicationId)

    # Test
    $servicePrincipal = New-AzureRmADServicePrincipal -ApplicationId $applicationId

    # Assert
    Assert-NotNull $servicePrincipal

	# GetServicePrincipal by ObjectId
	$sp1 = Get-AzureRmADServicePrincipal -ObjectId $servicePrincipal.Id
	Assert-NotNull $sp1
	Assert-AreEqual $sp1.Count 1
	Assert-AreEqual $sp1.Id $servicePrincipal.Id

	# GetServicePrincipal by SPN
	$sp1 = Get-AzureRmADServicePrincipal -ServicePrincipalName $servicePrincipal.ServicePrincipalNames[0]
	Assert-NotNull $sp1
	Assert-AreEqual $sp1.Count 1
	Assert-True { $sp1.ServicePrincipalNames.Contains($servicePrincipal.ServicePrincipalNames[0]) }

	# Delete SP
	Remove-AzureRmADServicePrincipal -ObjectId $servicePrincipal.Id -Force
}

<#
.SYNOPSIS
Tests Creating and deleting service principal without an exisitng application.
#>
function Test-NewADServicePrincipalWithoutApp
{	
	# Setup
    $displayName = getAssetName

    # Test
    $servicePrincipal = New-AzureRmADServicePrincipal -DisplayName $displayName

    # Assert
    Assert-NotNull $servicePrincipal
	Assert-AreEqual $servicePrincipal.DisplayName $displayName

	# GetServicePrincipal by ObjectId
	$sp1 = Get-AzureRmADServicePrincipal -ObjectId $servicePrincipal.Id
	Assert-NotNull $sp1
	Assert-AreEqual $sp1.Count 1
	Assert-AreEqual $sp1.Id $servicePrincipal.Id

	# GetServicePrincipal by SPN
	$sp1 = Get-AzureRmADServicePrincipal -ServicePrincipalName $servicePrincipal.ServicePrincipalNames[0]
	Assert-NotNull $sp1
	Assert-AreEqual $sp1.Count 1
	Assert-True { $sp1.ServicePrincipalNames.Contains($servicePrincipal.ServicePrincipalNames[0]) }

	# Get Application by ApplicationId
	$app1 =  Get-AzureRmADApplication -ApplicationId $servicePrincipal.ApplicationId
	Assert-NotNull $app1
	Assert-AreEqual $app1.Count 1

	# update SP displayName
	$newDisplayName = getAssetName
	
	Set-AzureRmADServicePrincipal -ObjectId $servicePrincipal.Id -DisplayName $newDisplayName

	# Get SP and verify updated name
	$sp1 = Get-AzureRmADServicePrincipal -ObjectId $servicePrincipal.Id
	Assert-NotNull $sp1
	Assert-AreEqual $sp1.Count 1
	Assert-AreEqual $sp1.DisplayName $newDisplayName

	# Remove App should delete SP also
	Remove-AzureRmADApplication -ObjectId $app1.ObjectId -Force

	Assert-Throws { Remove-AzureRmADServicePrincipal -ObjectId $servicePrincipal.Id -Force}
}

<#
.SYNOPSIS
Tests Creating and deleting service principal without an exisitng application.
#>
function Test-CreateDeleteAppPasswordCredentials
{	
    # Setup
    $displayName = getAssetName
    $identifierUri = "http://" + $displayName
	$password = getAssetName

    # Test - Add application with a password cred
    $application = New-AzureRmADApplication -DisplayName $displayName -IdentifierUris $identifierUri -Password $password

    # Assert
    Assert-NotNull $application

	# Get Application by ObjectId
	$app1 =  Get-AzureRmADApplication -ObjectId $application.ObjectId
	Assert-NotNull $app1

	# Get credential should fetch 1 credential
	$cred1 = Get-AzureRmADAppCredential -ObjectId $application.ObjectId
	Assert-NotNull $cred1
	Assert-AreEqual $cred1.Count 1

	# Add 1 more password credential to the same app
	$start = (Get-Date).ToUniversalTime()
	$end = $start.AddYears(1)
	$cred = New-AzureRmADAppCredential -ObjectId $application.ObjectId -Password $password -StartDate $start -EndDate $end
	Assert-NotNull $cred

	# Get credential should fetch 2 credentials
	$cred2 = Get-AzureRmADAppCredential -ObjectId $application.ObjectId
	Assert-NotNull $cred2
	Assert-AreEqual $cred2.Count 2
	$credCount = $cred2 | where {$_.KeyId -in $cred1.KeyId, $cred.KeyId}
	Assert-AreEqual $credCount.Count 2

	# Remove cred by KeyId
	Remove-AzureRmADAppCredential -ApplicationId $application.ApplicationId -KeyId $cred.KeyId -Force
	$cred3 = Get-AzureRmADAppCredential -ApplicationId $application.ApplicationId 
	Assert-NotNull $cred3
	Assert-AreEqual $cred3.Count 1
	Assert-AreEqual $cred3[0].KeyId $cred1.KeyId

	# Remove All creds
	Remove-AzureRmADAppCredential -ObjectId $application.ObjectId -All -Force
	$cred3 = Get-AzureRmADAppCredential -ObjectId $application.ObjectId
	Assert-Null $cred3

	# Remove App 
	Remove-AzureRmADApplication -ObjectId $application.ObjectId -Force
}


<#
.SYNOPSIS
Tests Creating and deleting service principal without an exisitng application.
#>
function Test-CreateDeleteSpPasswordCredentials
{	
    # Setup
    $displayName = getAssetName
	$password = getAssetName

    # Test - Add SP with a password cred
	$servicePrincipal = New-AzureRmADServicePrincipal -DisplayName $displayName  -Password $password

    # Assert
    Assert-NotNull $servicePrincipal

	# Get service principal by ObjectId
	$sp1 =  Get-AzureRmADServicePrincipal -ObjectId $servicePrincipal.Id
	Assert-NotNull $sp1.Id

	# Get credential should fetch 1 credential
	$cred1 = Get-AzureRmADSpCredential -ObjectId $servicePrincipal.Id
	Assert-NotNull $cred1
	Assert-AreEqual $cred1.Count 1

	# Add 1 more passowrd credential to the same app
	$start = (Get-Date).ToUniversalTime()
	$end = $start.AddYears(1)
	$cred = New-AzureRmADSpCredential -ObjectId $servicePrincipal.Id -Password $password -StartDate $start -EndDate $end
	Assert-NotNull $cred

	# Get credential should fetch 2 credentials
	$cred2 = Get-AzureRmADSpCredential -ObjectId $servicePrincipal.Id
	Assert-NotNull $cred2
	Assert-AreEqual $cred2.Count 2
	$credCount = $cred2 | where {$_.KeyId -in $cred1.KeyId, $cred.KeyId}
	Assert-AreEqual $credCount.Count 2

	# Remove cred by KeyId
	Remove-AzureRmADSpCredential -ServicePrincipalName $servicePrincipal.ServicePrincipalNames[0] -KeyId $cred.KeyId -Force
	$cred3 = Get-AzureRmADSpCredential -ServicePrincipalName $servicePrincipal.ServicePrincipalNames[0] 
	Assert-NotNull $cred3
	Assert-AreEqual $cred3.Count 1
	Assert-AreEqual $cred3[0].KeyId $cred1.KeyId

	# Remove All creds
	Remove-AzureRmADSpCredential -ObjectId $servicePrincipal.Id -All -Force
	$cred3 = Get-AzureRmADSpCredential -ObjectId $servicePrincipal.Id
	Assert-Null $cred3

	# Remove App 
	$app =  Get-AzureRmADApplication -ApplicationId $servicePrincipal.ApplicationId
	Remove-AzureRmADApplication -ObjectId $app.ObjectId -Force
}