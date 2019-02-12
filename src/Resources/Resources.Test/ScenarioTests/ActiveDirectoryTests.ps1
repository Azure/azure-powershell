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
    $groups = Get-AzADGroup

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
    $groups = Get-AzADGroup -SearchString $displayName

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
    $groups = Get-AzADGroup -SearchString "BadSearchString"

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
    $groups = Get-AzADGroup -ObjectId $objectId

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
    $groups = Get-AzADGroup -ObjectId $objectId

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
    $groups = Get-AzADGroup -ObjectId "baadc0de-baad-c0de-baad-c0debaadc0de"

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
    $groups = Get-AzADGroup -ObjectId $objectId

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
    $members = Get-AzADGroupMember -GroupObjectId $groupObjectId

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
    Assert-Throws { Get-AzADGroupMember -GroupObjectId "baadc0de-baad-c0de-baad-c0debaadc0de" }
}

<#
.SYNOPSIS
Tests getting members from an Active Directory group.
#>
function Test-GetADGroupMemberWithUserObjectId
{
    param([string]$objectId)

    # Test
    Assert-Throws { Get-AzADGroupMember -GroupObjectId $objectId }
}

<#
.SYNOPSIS
Tests getting members from an Active Directory group.
#>
function Test-GetADGroupMemberFromEmptyGroup
{
    param([string]$objectId)

    # Test
    $members = Get-AzADGroupMember -GroupObjectId $objectId

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
    $servicePrincipals = Get-AzADServicePrincipal -ObjectId $objectId

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
    $servicePrincipals = Get-AzADServicePrincipal -ObjectId "baadc0de-baad-c0de-baad-c0debaadc0de"

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
    $servicePrincipals = Get-AzADServicePrincipal -ObjectId $objectId

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
    $servicePrincipals = Get-AzADServicePrincipal -ServicePrincipalName $SPN

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
    $servicePrincipals = Get-AzADServicePrincipal -ServicePrincipalName "badspn"

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
    $servicePrincipals = Get-AzADServicePrincipal -SearchString $displayName

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
    $servicePrincipals = Get-AzADServicePrincipal -SearchString "badsearchstring"

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
    $users = Get-AzADUser

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
    $users = Get-AzADUser -ObjectId $objectId

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
    $users = Get-AzADUser -Mail $mail

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
    $users = Get-AzADUser -ObjectId "baadc0de-baad-c0de-baad-c0debaadc0de"

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
    $users = Get-AzADUser -ObjectId $objectId

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
    $users = Get-AzADUser -UserPrincipalName $UPN

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
    $users = Get-AzADUser -UserPrincipalName "azsdkposhteam_outlook.com#EXT#@rbactest.onmicrosoft.com"

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
    $users = Get-AzADUser -UserPrincipalName "baduser@rbactest.onmicrosoft.com"

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
    $users = Get-AzADUser -SearchString $displayName

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
    $users = Get-AzADUser -SearchString "badsearchstring"

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
    $application = New-AzADApplication -DisplayName $displayName -HomePage $homePage -IdentifierUris $identifierUri

    # Assert
    Assert-NotNull $application
    $apps =  Get-AzADApplication
    Assert-NotNull $apps
    Assert-True { $apps.Count -ge 0 }

	# Get Application by ObjectId
	$app1 =  Get-AzADApplication -ObjectId $application.ObjectId
	Assert-NotNull $app1
	Assert-AreEqual $app1.Count 1

    # Get Application by ApplicationId
    $app1 =  Get-AzADApplication -ApplicationId $application.ApplicationId
    Assert-NotNull $app1
    Assert-AreEqual $app1.Count 1

    # Get Application by IdentifierUri
    $app1 = Get-AzADApplication -IdentifierUri $application.IdentifierUris[0]
    Assert-NotNull $app1
    Assert-AreEqual $app1.Count 1

    # Get Application by DisplayName
    $app1 = Get-AzADApplication -DisplayNameStartWith $application.DisplayName
    Assert-NotNull $app1
    Assert-True { $app1.Count -ge 1}

    $newDisplayName = getAssetName
    $newHomePage = "http://" + $newDisplayName + ".com"
    $newIdentifierUri = "http://" + $newDisplayName

    # Update displayName and HomePage
    Set-AzADApplication -ObjectId $application.ObjectId -DisplayName $newDisplayName -HomePage $newHomePage

    # Update identifierUri
    Set-AzADApplication -ApplicationId $application.ApplicationId -IdentifierUris $newIdentifierUri

    # Get application and verify updated properties
    $app1 =  Get-AzADApplication -ObjectId $application.ObjectId
    Assert-NotNull $app1
    Assert-AreEqual $app1.Count 1
    Assert-AreEqual $app1.DisplayName $newDisplayName
    Assert-AreEqual $app1.HomePage $newHomePage
    Assert-AreEqual $app1.IdentifierUris[0] $newIdentifierUri

    # Delete
    Remove-AzADApplication -ObjectId $application.ObjectId -Force
}

<#
.SYNOPSIS
Tests Creating and deleting service principal.
#>
function Test-NewADServicePrincipal
{
    param([string]$applicationId)

    # Test
    $servicePrincipal = New-AzADServicePrincipal -ApplicationId $applicationId

    # Assert
    Assert-NotNull $servicePrincipal

    # GetServicePrincipal by ObjectId
    $sp1 = Get-AzADServicePrincipal -ObjectId $servicePrincipal.Id
    Assert-NotNull $sp1
    Assert-AreEqual $sp1.Count 1
    Assert-AreEqual $sp1.Id $servicePrincipal.Id

    # GetServicePrincipal by SPN
    $sp1 = Get-AzADServicePrincipal -ServicePrincipalName $servicePrincipal.ServicePrincipalNames[0]
    Assert-NotNull $sp1
    Assert-AreEqual $sp1.Count 1
    Assert-True { $sp1.ServicePrincipalNames.Contains($servicePrincipal.ServicePrincipalNames[0]) }

    # Delete SP
    Remove-AzADServicePrincipal -ObjectId $servicePrincipal.Id -Force
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
    $servicePrincipal = New-AzADServicePrincipal -DisplayName $displayName
	$role = Get-AzRoleAssignment -ObjectId $servicePrincipal.Id

    # Assert
    Assert-NotNull $servicePrincipal
    Assert-AreEqual $servicePrincipal.DisplayName $displayName
	Assert-Null $role

    # GetServicePrincipal by ObjectId
    $sp1 = Get-AzADServicePrincipal -ObjectId $servicePrincipal.Id
    Assert-NotNull $sp1
    Assert-AreEqual $sp1.Count 1
    Assert-AreEqual $sp1.Id $servicePrincipal.Id

    # GetServicePrincipal by SPN
    $sp1 = Get-AzADServicePrincipal -ServicePrincipalName $servicePrincipal.ServicePrincipalNames[0]
    Assert-NotNull $sp1
    Assert-AreEqual $sp1.Count 1
    Assert-True { $sp1.ServicePrincipalNames.Contains($servicePrincipal.ServicePrincipalNames[0]) }

    # Get Application by ApplicationId
    $app1 =  Get-AzADApplication -ApplicationId $servicePrincipal.ApplicationId
    Assert-NotNull $app1
    Assert-AreEqual $app1.Count 1

    # update SP displayName
    $newDisplayName = getAssetName

    Set-AzADServicePrincipal -ObjectId $servicePrincipal.Id -DisplayName $newDisplayName

    # Get SP and verify updated name
    $sp1 = Get-AzADServicePrincipal -ObjectId $servicePrincipal.Id
    Assert-NotNull $sp1
    Assert-AreEqual $sp1.Count 1
    Assert-AreEqual $sp1.DisplayName $newDisplayName

    # Remove App should delete SP also
    Remove-AzADApplication -ObjectId $app1.ObjectId -Force

    Assert-Throws { Remove-AzADServicePrincipal -ObjectId $servicePrincipal.Id -Force}
}

<#
.SYNOPSIS
Tests creating a service principal with reader permissions
#>
function Test-NewADServicePrincipalWithReaderRole
{
	# Setup
	$displayName = getAssetName
	$roleDefinitionName = "Reader"

	# Test
	$servicePrincipal = New-AzADServicePrincipal -DisplayName $displayName -Role $roleDefinitionName
	Assert-NotNull $servicePrincipal
	Assert-AreEqual $servicePrincipal.DisplayName $displayName

	try
	{
		$role = Get-AzRoleAssignment -ObjectId $servicePrincipal.Id
		Assert-AreEqual $role.Count 1
		Assert-AreEqual $role.DisplayName $servicePrincipal.DisplayName
		Assert-AreEqual $role.ObjectId $servicePrincipal.Id
		Assert-AreEqual $role.RoleDefinitionName $roleDefinitionName
		Assert-AreEqual $role.ObjectType "ServicePrincipal"
	}
	finally
	{
		Remove-AzADApplication -ApplicationId $servicePrincipal.ApplicationId -Force
		Remove-AzRoleAssignment -ObjectId $servicePrincipal.Id -RoleDefinitionName $roleDefinitionName
	}
}

<#
.SYNOPSIS
Tests creating a service principal with permissions over a custom scope
#>
function Test-NewADServicePrincipalWithCustomScope
{
	# Setup
	$displayName = getAssetName
	$defaultRoleDefinitionName = "Contributor"
	$subscription = Get-AzSubscription | Select -Last 1 -Wait
	$resourceGroup = Get-AzResourceGroup | Select -Last 1 -Wait
	$scope = "/subscriptions/" + $subscription.Id + "/resourceGroups/" + $resourceGroup.ResourceGroupName

	# Test
	$servicePrincipal = New-AzADServicePrincipal -DisplayName $displayName -Scope $scope
	Assert-NotNull $servicePrincipal
	Assert-AreEqual $servicePrincipal.DisplayName $displayName

	try
	{
		$role = Get-AzRoleAssignment -ObjectId $servicePrincipal.Id
		Assert-AreEqual $role.Count 1
		Assert-AreEqual $role.DisplayName $servicePrincipal.DisplayName
		Assert-AreEqual $role.ObjectId $servicePrincipal.Id
		Assert-AreEqual $role.RoleDefinitionName $defaultRoleDefinitionName
		Assert-AreEqual $role.Scope $scope
		Assert-AreEqual $role.ObjectType "ServicePrincipal"
	}
	finally
	{
		Remove-AzADApplication -ApplicationId $servicePrincipal.ApplicationId -Force
		Remove-AzRoleAssignment -ObjectId $servicePrincipal.Id -Scope $scope -RoleDefinitionName $defaultRoleDefinitionName
	}
}

<#
.SYNOPSIS
Tests Creating and deleting application using App Credentials.
#>
function Test-CreateDeleteAppCredentials
{
    # Setup
	$getAssetName = ConvertTo-SecureString "test" -AsPlainText -Force
    $displayName = "test"
    $identifierUri = "http://" + $displayName
    $password = $getAssetName
	$keyId1 = "316af45c-83ff-42a5-a1d1-8fe9b2de3ac1"
	$keyId2 = "9b7fda23-cb39-4504-8aa6-3570c4239620"
	$keyId3 = "4141b479-4ca0-4919-8451-7e155de6aa0f"

    # Test - Add application with a password cred
    $application = New-AzADApplication -DisplayName $displayName -IdentifierUris $identifierUri -Password $password

    # Assert
    Assert-NotNull $application
	Try {
    # Get Application by ObjectId
    $app1 =  Get-AzADApplication -ObjectId $application.ObjectId
    Assert-NotNull $app1

    # Get credential should fetch 1 credential
    $cred1 = Get-AzADAppCredential -ObjectId $application.ObjectId
    Assert-NotNull $cred1
    Assert-AreEqual $cred1.Count 1

    # Add 1 more password credential to the same app
    $start = (Get-Date).ToUniversalTime()
    $end = $start.AddYears(1)
    $cred = New-AzADAppCredentialWithId -ObjectId $application.ObjectId -Password $password -StartDate $start -EndDate $end -KeyId $keyId1
    Assert-NotNull $cred

    # Get credential should fetch 2 credentials
    $cred2 = Get-AzADAppCredential -ObjectId $application.ObjectId
    Assert-NotNull $cred2
    Assert-AreEqual $cred2.Count 2
    $credCount = $cred2 | where {$_.KeyId -in $cred1.KeyId, $cred.KeyId}
    Assert-AreEqual $credCount.Count 2
	$cred2 = $cred

	# Add 1 key credential to the same app
	$certPath = Join-Path $ResourcesPath "certificate.pfx"
	$cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($certPath)

	$binCert = $cert.GetRawCertData()
	$credValue = [System.Convert]::ToBase64String($binCert)
	$start = (Get-Date).ToUniversalTime()
	$end = $start.AddDays(1)
	$cred = New-AzADAppCredentialWithId -ObjectId $application.ObjectId -CertValue $credValue -StartDate $start -EndDate $end -KeyId $keyId2
    Assert-NotNull $cred

    # Get credential should fetch 3 credentials
    $cred3 = Get-AzADAppCredential -ObjectId $application.ObjectId
    Assert-NotNull $cred3
    Assert-AreEqual $cred3.Count 3
    $credCount = $cred3 | where {$_.KeyId -in $cred1.KeyId, $cred2.KeyId, $cred.KeyId}
    Assert-AreEqual $credCount.Count 3
	$cred3 = $cred

	# Add 1 more key credential to the same app
	$binCert = $cert.GetRawCertData()
	$credValue = [System.Convert]::ToBase64String($binCert)
	$start = (Get-Date).ToUniversalTime()
	$end = $start.AddDays(1)
	$cred = New-AzADAppCredentialWithId -ObjectId $application.ObjectId -CertValue $credValue -StartDate $start -EndDate $end -KeyId $keyId3
    Assert-NotNull $cred

    # Get credential should fetch 4 credentials
    $cred4 = Get-AzADAppCredential -ObjectId $application.ObjectId
    Assert-NotNull $cred4
    Assert-AreEqual $cred4.Count 4
    $credCount = $cred4 | where {$_.KeyId -in $cred1.KeyId, $cred2.KeyId, $cred3.KeyId, $cred.KeyId}
    Assert-AreEqual $credCount.Count 4

    # Remove cred by KeyId
    Remove-AzADAppCredential -ApplicationId $application.ApplicationId -KeyId $cred.KeyId -Force
    $cred5 = Get-AzADAppCredential -ApplicationId $application.ApplicationId
    Assert-NotNull $cred5
    Assert-AreEqual $cred5.Count 3
    Assert-AreEqual $cred5[2].KeyId $cred1.KeyId

    # Remove All creds
    Remove-AzADAppCredential -ObjectId $application.ObjectId -Force
    $cred5 = Get-AzADAppCredential -ObjectId $application.ObjectId
    Assert-Null $cred5                     
	 
    $newApplication = Get-AzADApplication -DisplayNameStartWith "PowershellTestingApp"
    Assert-Throws { New-AzADAppCredential -ApplicationId $newApplication.ApplicationId -Password "Somedummypwd"}
	}
	Finally{
		# Remove App
		Remove-AzADApplication -ObjectId $application.ObjectId -Force
	}
}


<#
.SYNOPSIS
Tests Creating and deleting application using Service Principal Credentials.
#>
function Test-CreateDeleteSpCredentials
{
	param([string]$applicationId)

    # Setup
	$getAssetName = ConvertTo-SecureString "test" -AsPlainText -Force
    $displayName = "test"
    $identifierUri = "http://" + $displayName
	$password = $getAssetName
	$keyId1 = "316af45c-83ff-42a5-a1d1-8fe9b2de3ac1"
	$keyId2 = "9b7fda23-cb39-4504-8aa6-3570c4239620"
	$keyId3 = "4141b479-4ca0-4919-8451-7e155de6aa0f"

    # Test - Add SP
    $servicePrincipal = New-AzADServicePrincipal -DisplayName $displayName -ApplicationId $applicationId

    # Assert
    Assert-NotNull $servicePrincipal

    Try
    {
    # Get service principal by ObjectId
    $sp1 =  Get-AzADServicePrincipal -ObjectId $servicePrincipal.Id
    Assert-NotNull $sp1.Id

    # Get credential should fetch 1 credential
    $cred1 = Get-AzADSpCredential -ObjectId $servicePrincipal.Id
    Assert-NotNull $cred1
    Assert-AreEqual $cred1.Count 1

    # Add 1 more password credential to the same app
    $start = (Get-Date).ToUniversalTime()
    $end = $start.AddYears(1)
    $cred = New-AzADSpCredentialWithId -ObjectId $servicePrincipal.Id -StartDate $start -EndDate $end -KeyId $keyId1
    Assert-NotNull $cred

    # Get credential should fetch 2 credentials
    $cred2 = Get-AzADSpCredential -ObjectId $servicePrincipal.Id
    Assert-NotNull $cred2
    Assert-AreEqual $cred2.Count 2
    $credCount = $cred2 | where {$_.KeyId -in $cred1.KeyId, $cred.KeyId}
    Assert-AreEqual $credCount.Count 2
	$cred2 = $cred

	# Add 1 key credential to the same app
	$certPath = Join-Path $ResourcesPath "certificate.pfx"
	$cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($certPath)

	$binCert = $cert.GetRawCertData()
	$credValue = [System.Convert]::ToBase64String($binCert)
	$start = (Get-Date).ToUniversalTime()
	$end = $start.AddDays(1)
	$cred = New-AzADSpCredentialWithId -ObjectId $servicePrincipal.Id -CertValue $credValue -StartDate $start -EndDate $end -KeyId $keyId2
    Assert-NotNull $cred

    # Get credential should fetch 3 credentials
    $cred3 = Get-AzADSpCredential -ObjectId $servicePrincipal.Id
    Assert-NotNull $cred3
    Assert-AreEqual $cred3.Count 3
    $credCount = $cred3 | where {$_.KeyId -in $cred1.KeyId, $cred2.KeyId, $cred.KeyId}
    Assert-AreEqual $credCount.Count 3
	$cred3 = $cred

	# Add 1 more key credential to the same app
	$binCert = $cert.GetRawCertData()
	$credValue = [System.Convert]::ToBase64String($binCert)
	$start = (Get-Date).ToUniversalTime()
	$end = $start.AddDays(1)
	$cred = New-AzADSpCredentialWithId -ObjectId $servicePrincipal.Id -CertValue $credValue -StartDate $start -EndDate $end -KeyId $keyId3
    Assert-NotNull $cred

    # Get credential should fetch 4 credentials
    $cred4 = Get-AzADSpCredential -ObjectId $servicePrincipal.Id
    Assert-NotNull $cred4
    Assert-AreEqual $cred4.Count 4
    $credCount = $cred4 | where {$_.KeyId -in $cred1.KeyId, $cred2.KeyId, $cred3.KeyId, $cred.KeyId}
    Assert-AreEqual $credCount.Count 4


    # Remove cred by KeyId
    Remove-AzADSpCredential -ServicePrincipalName $servicePrincipal.ServicePrincipalNames[0] -KeyId $cred.KeyId -Force
    $cred5 = Get-AzADSpCredential -ServicePrincipalName $servicePrincipal.ServicePrincipalNames[0]
    Assert-NotNull $cred5
    Assert-AreEqual $cred5.Count 3
    Assert-AreEqual $cred5[2].KeyId $cred1.KeyId

    # Remove All creds
    Remove-AzADSpCredential -ObjectId $servicePrincipal.Id -Force
    $cred5 = Get-AzADSpCredential -ObjectId $servicePrincipal.Id
    Assert-Null $cred5
    }
    Finally
    {
		# Remove Service Principal
		Remove-AzADServicePrincipal -ObjectId $servicePrincipal.Id -Force
    }
}