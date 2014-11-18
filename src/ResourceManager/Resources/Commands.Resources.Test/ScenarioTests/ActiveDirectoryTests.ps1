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
    $groups = Get-AzureADGroup

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
    $groups = Get-AzureADGroup -SearchString $displayName

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
    $groups = Get-AzureADGroup -SearchString "BadSearchString"

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
    $groups = Get-AzureADGroup -ObjectId $objectId

    # Assert
    Assert-AreEqual $groups.Count 1
    Assert-AreEqual $groups[0].Id $objectId
    Assert-NotNull($groups[0].DisplayName)
}

<#
.SYNOPSIS
Tests getting Active Directory groups.
#>
function Test-GetADGroupWithBadObjectId
{
    # Test
    $groups = Get-AzureADGroup -ObjectId "baadc0de-baad-c0de-baad-c0debaadc0de"

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
    $groups = Get-AzureADGroup -ObjectId $objectId

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
    $members = Get-AzureADGroupMember -GroupObjectId $groupObjectId
    
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
    $members = Get-AzureADGroupMember -GroupObjectId "baadc0de-baad-c0de-baad-c0debaadc0de"
    
    # Assert 
    Assert-Null($members)
}

<#
.SYNOPSIS
Tests getting members from an Active Directory group.
#>
function Test-GetADGroupMemberWithUserObjectId
{
    param([string]$objectId)

    # Test
    $members = Get-AzureADGroupMember -GroupObjectId $objectId
    
    # Assert 
    Assert-Null($members)
}

<#
.SYNOPSIS
Tests getting members from an Active Directory group.
#>
function Test-GetADGroupMemberFromEmptyGroup
{
    param([string]$objectId)

    # Test
    $members = Get-AzureADGroupMember -GroupObjectId $objectId
    
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
    $servicePrincipals = Get-AzureADServicePrincipal -ObjectId $objectId

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
    $servicePrincipals = Get-AzureADServicePrincipal -ObjectId "baadc0de-baad-c0de-baad-c0debaadc0de"

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
    $servicePrincipals = Get-AzureADServicePrincipal -ObjectId $objectId

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
    $servicePrincipals = Get-AzureADServicePrincipal -ServicePrincipalName $SPN

    # Assert
    Assert-AreEqual $servicePrincipals.Count 1
    Assert-NotNull $servicePrincipals[0].Id
    Assert-AreEqual $servicePrincipals[0].ServicePrincipalName $SPN
}

<#
.SYNOPSIS
Tests getting Active Directory service principals.
#>
function Test-GetADServicePrincipalWithBadSPN
{
    # Test
    $servicePrincipals = Get-AzureADServicePrincipal -ServicePrincipalName "badspn"

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
    $servicePrincipals = Get-AzureADServicePrincipal -SearchString $displayName

    # Assert
    Assert-AreEqual $servicePrincipals.Count 1
    Assert-AreEqual $servicePrincipals[0].DisplayName $displayName
    Assert-NotNull($servicePrincipals[0].Id)
    Assert-NotNull($servicePrincipals[0].ServicePrincipalName)
}

<#
.SYNOPSIS
Tests getting Active Directory service principals.
#>
function Test-GetADServicePrincipalWithBadSearchString
{
    # Test
    $servicePrincipals = Get-AzureADServicePrincipal -SearchString "badsearchstring"

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
    $users = Get-AzureADUser

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
    $users = Get-AzureADUser -ObjectId $objectId

    # Assert
    Assert-AreEqual $users.Count 1
    Assert-AreEqual $users[0].Id $objectId
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
    $users = Get-AzureADUser -ObjectId "baadc0de-baad-c0de-baad-c0debaadc0de"

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
    $users = Get-AzureADUser -ObjectId $objectId

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
    $users = Get-AzureADUser -UserPrincipalName $UPN

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
    $users = Get-AzureADUser -UserPrincipalName "azsdkposhteam_outlook.com#EXT#@rbactest.onmicrosoft.com"

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
    $users = Get-AzureADUser -UserPrincipalName "baduser@rbactest.onmicrosoft.com"

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
    $users = Get-AzureADUser -SearchString $displayName

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
    $users = Get-AzureADUser -SearchString "badsearchstring"

    # Assert
    Assert-Null($users)
}
