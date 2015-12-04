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


$testCertData = [Convert]::FromBase64String("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")
$testCert = New-Object -TypeName System.Security.Cryptography.X509Certificates.X509Certificate2
$testCert.Import($testCertData)

# The subscription ID to use for live tests
$testValidSubscription = "c9cbd920-c00c-427c-852b-8aaf38badaeb";
$testCreds = $(createTestCredential "test@mail.com" "TestPassw0rd")

function Create-Profile
{
    param([string] $token, [string] $user, [string] $sub)   
    New-AzureProfile -SubscriptionId $sub -AccessToken $token -AccountId $user
}


<#
.SYNOPSIS
Tests creating new azure profile with certificate
#>
function Test-CreatesNewAzureProfileWithCertificate
{
	# Test
    $actual = New-AzureProfile -SubscriptionId "058de55e-28e0-49e7-8cf2-6701d4a88ef5" -StorageAccount myStorage -Certificate $testCert

    # Assert
    Assert-AreEqual "058de55e-28e0-49e7-8cf2-6701d4a88ef5" $actual.Context.Subscription.Id
	Assert-AreEqual "AzureCloud" $actual.Context.Environment.Name
	Assert-AreEqual "Certificate" $actual.Context.Account.Type
}

<#
.SYNOPSIS
Tests creating new azure profile with user creds
#>
function Test-CreatesNewAzureProfileWithUserCredentials
{
	# Test
    $actual = New-AzureProfile -SubscriptionId "058de55e-28e0-49e7-8cf2-6701d4a88ef5" -StorageAccount myStorage -Credentials $testCreds -Tenant "testTenant"

    # Assert
    Assert-AreEqual "058de55e-28e0-49e7-8cf2-6701d4a88ef5" $actual.Context.Subscription.Id
	Assert-AreEqual "AzureCloud" $actual.Context.Environment.Name
	Assert-AreEqual "test@mail.com" $actual.Context.Account.Id
	Assert-AreEqual "User" $actual.Context.Account.Type
}

<#
.SYNOPSIS
Tests creating new azure profile with access token
#>
function Test-CreatesNewAzureProfileWithAccessToken
{
	# Test
    $actual = New-AzureProfile -SubscriptionId "058de55e-28e0-49e7-8cf2-6701d4a88ef5" -StorageAccount myStorage -AccessToken "123456" -AccountId myAccount

    # Assert
    Assert-AreEqual "058de55e-28e0-49e7-8cf2-6701d4a88ef5" $actual.Context.Subscription.Id
	Assert-AreEqual "AzureCloud" $actual.Context.Environment.Name
	Assert-AreEqual "myAccount" $actual.Context.Account.Id
	Assert-AreEqual "AccessToken" $actual.Context.Account.Type
}

<#
.SYNOPSIS
Tests creating an empty profile.
#>
function Test-NewEmptyProfile
{
    $actual = New-AzureProfile
	Clear-AzureProfile -Force
	$cloud = Get-AzureEnvironment -Name AzureCloud -Profile $actual
	$chinaCloud = Get-AzureEnvironment -Name AzureChinaCloud -Profile $actual
	Assert-NotNull $cloud
	Assert-NotNull $chinaCloud 
}

<#
.SYNOPSIS
Tests creating an empty profile with a new environment.
#>
function Test-NewEmptyProfileWithEnvironment
{
   $newEnv = Add-AzureEnvironment -Name "NewEnv" -OnPremise $true -ManagementPortalUrl = "https://manage.windowsazure.com"
   Clear-AzureProfile -Force
   $actual = New-AzureProfile -Environment $newEnv
   $checkEnv = Get-AzureEnvironment -Name "NewEnv" -Profile $actual
   Assert-NotNull $checkEnv
}

<#
.SYNOPSIS
Tests using a profile to run an RDFE cmdlet
#>
function Test-NewAzureProfileInRDFEMode
{
    param([string] $token, [string] $user, [string] $sub)
    $profile = $(Create-Profile $token $user $sub)
    Assert-AreEqual "AzureCloud" $Profile.Context.Environment.Name
    Clear-AzureProfile -Force
    $locations = Get-AzureLocation -Profile $profile
    Assert-NotNull $locations
    Assert-True {$locations.Count -gt 1}
}

<#
.SYNOPSIS
Tests using a profile to run an ARM cmdlet
#>
function Test-NewAzureProfileInARMMode
{
    param([string] $token, [string] $user, [string] $sub)
    $profile = $(Create-Profile $token $user $sub)
	Assert-AreEqual "AzureCloud" $($Profile.Context.Environment.Name) "Expecting the azure cloud environment"
	Clear-AzureProfile -Force
	$locations = Get-AzureLocation -Profile $profile
	Assert-NotNull $locations
	Assert-True {$locations.Count -gt 1}
}

<#
.SYNOPSIS
Tests using the pipeline with environment cmdlets
#>
function Test-EnvironmentPipeline
{
    Clear-AzureProfile -Force
    $env = Get-AzureEnvironment -Name AzureCloud
	$env.Name = "EditedAzureCloud"
	$env.AdTenant = "NewAdTenant"
	$newEnv = $env | Add-AzureEnvironment
	$envs = Get-AzureEnvironment
	Assert-AreEqual "EditedAzureCloud" $newEnv.Name
	Assert-AreEqual "NewAdTenant" $newEnv.AdTenant
	Assert-AreEqual 3 $envs.Count
	$removedEnv = $newEnv | Remove-AzureEnvironment -Force
	Assert-AreEqual "EditedAzureCloud" $removedEnv.Name
	$envs = Get-AzureEnvironment
	Assert-AreEqual 2 $envs.Count
}
