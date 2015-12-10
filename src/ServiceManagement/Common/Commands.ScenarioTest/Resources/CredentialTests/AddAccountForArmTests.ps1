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

### Helper functions for below tests ###
function Assert-Empty-Profile
{
    Assert-True { (Get-AzureSubscription).Length -eq 0 } "Assumed no subscriptions, but there is at least one"
    Assert-True { (Get-AzureAccount).Length -eq 0 }	"Assumed no accounts, but there is at least one"
}

### Add-AzureAccount Scenario Tests for CSM ####

<#
.SYNOPSIS
Tests that single user account can be used to log in and list resource groups
#>
function Test-AddOrgIdWithSingleSubscription
{
    Assert-Empty-Profile

    # Verify that account can be added and used to access the
    # expected subscription
    $accountInfo = Get-UserCredentials "OrgIdOneTenantOneSubscription"
    
    Add-AzureAccount -Credential $accountInfo.Credential -Environment $accountInfo.Environment

    # Is expected subscription added?
    $sub = (Get-AzureSubscription)[0]

    # does it have the right subscription id?
    Assert-True { $sub.SubscriptionId -eq $accountInfo.ExpectedSubscription }

    # It's set as current account and as default account
    Assert-True { $sub.IsCurrent }
    Assert-True { $sub.IsDefault }

    # It's using the expected account
    Assert-True { $sub.DefaultAccount -eq $accountInfo.UserId }

    # Can we use it to do something? If this passes then we're ok
    Get-AzureResourceGroup
}

<#
.SYNOPSIS
Login with Foreign Principal fails with non-interactive flow with reasonable error message
to output stream.
#>
function Test-NonInteractiveFPOLoginFails
{
    $accountInfo = Get-UserCredentials "OrgIdForeignPrincipal"
	Add-AzureAccount -Credential $accountInfo.Credential -Environment $accountInfo.Environment
	
    Assert-True { (Get-AzureSubscription).Length -eq 0 } "There should be no subscription"
}

<#
.SYNOPSIS
Attempt to login with Microsoft Account without user interaction fails with
a reasonable message to error stream.
#>
function Test-MicrosoftAccountNotSupportedForNonInteractiveLogin
{
    $accountInfo = Get-UserCredentials MicrosoftId
    Assert-ThrowsContains {
        Add-AzureAccount -Credential $accountInfo.Credential -Environment $accountInfo.Environment
    } "-Credential parameter can only be used with Organization ID credentials"
}

<#
.SYNOPSIS
Login with service principal with no other accounts
#>
function Test-AddServicePrincipalToEmptyProfile
{
    Assert-Empty-Profile
    $accountInfo = Get-UserCredentials ServicePrincipal
    Add-AzureAccount -ServicePrincipal -Credential $accountInfo.Credential -Environment $accountInfo.Environment -Tenant $accountInfo.TenantId

    Assert-True { (Get-AzureSubscription).Length -eq 1 } "Subscription was not added"
}

<#
.SYNOPSIS
Login with user, then SP, SP should be default account
#>
function Test-LoginWithUserAndServicePrincipal
{
    Assert-Empty-Profile
    $userAccount = Get-UserCredentials OrgIdOneTenantOneSubscription
    $servicePrincipalAccount = Get-UserCredentials ServicePrincipal

    Add-AzureAccount -Credential $userAccount.Credential -Environment $accountInfo.Environment
    Add-AzureAccount -ServicePrincipal -Credential $servicePrincipalAccount.Credential -Environment $servicePrincipalAccount.Environment -Tenant $servicePrincipalAccount.TenantId

    $sub = (Get-AzureSubscription)[0]
    Assert-True { $sub.DefaultAccount -eq $servicePrincipalAccount.UserId }
}

<#
.SYNOPSIS
Login with service principal, then user, user should be default account
#>
function Test-LoginWithServicePrincipalAndUser
{
    Assert-Empty-Profile
    $userAccount = Get-UserCredentials OrgIdOneTenantOneSubscription
    $servicePrincipalAccount = Get-UserCredentials ServicePrincipal

    Add-AzureAccount -ServicePrincipal -Credential $servicePrincipalAccount.Credential -Environment $servicePrincipalAccount.Environment -Tenant $servicePrincipalAccount.TenantId
    Add-AzureAccount -Credential $userAccount.Credential -Environment $accountInfo.Environment

    $sub = (Get-AzureSubscription)[0]
    Assert-True { $sub.DefaultAccount -eq $userAccount.UserId }
}

<#
.SYNOPSIS
Login then logout should result in exclusive subscription being removed
#>
function Test-ServicePrincipalExclusiveLogout
{
    Assert-Empty-Profile
    $servicePrincipalAccount = Get-UserCredentials ServicePrincipal

    Add-AzureAccount -ServicePrincipal -Credential $servicePrincipalAccount.Credential -Environment $servicePrincipalAccount.Environment -Tenant $servicePrincipalAccount.TenantId

    Assert-True { (Get-AzureSubscription).Length -eq 1 }

    Remove-AzureAccount $servicePrincipalAccount.UserId -Force

    Assert-True { (Get-AzureSubscription).Length -eq 0 }
    Assert-True { (Get-AzureAccount).Length -eq 0 }
}

<#
.SYNOPSIS
Login Service Principal and User, then logout Service principal.
#>
function Test-ServicePrincipalLogoutWithUserOnSameSubscription
{
    Assert-Empty-Profile
    Assert-Empty-Profile

    $userAccount = Get-UserCredentials OrgIdOneTenantOneSubscription
    $servicePrincipalAccount = Get-UserCredentials ServicePrincipal

    Add-AzureAccount -Credential $userAccount.Credential -Environment $accountInfo.Environment
    Add-AzureAccount -ServicePrincipal -Credential $servicePrincipalAccount.Credential -Environment $servicePrincipalAccount.Environment -Tenant $servicePrincipalAccount.TenantId

    $sub = (Get-AzureSubscription)[0]
    Assert-True { (Get-AzureSubscription).Length -eq 1 }
    Assert-True { $sub.DefaultAccount -eq $servicePrincipalAccount.UserId }

    Remove-AzureAccount $servicePrincipalAccount.UserId -Force

    $sub = (Get-AzureSubscription)[0]
    Assert-True { (Get-AzureSubscription).Length -eq 1 }
    Assert-True { $sub.DefaultAccount -eq $userAccount.UserId }
    Assert-True { (Get-AzureAccount).Length -eq 1 }
}
