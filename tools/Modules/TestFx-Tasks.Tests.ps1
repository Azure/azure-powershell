
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

Import-Module $PSScriptRoot/TestFx-Tasks
Describe "Test-NewCredentialNewServicePrincipal"{
	Context "Creates a correctly formatted ServicePrincipal"{
        Login-AzureRmAccount -AccessToken "12345678" -SkipValidation -AccountId "testaccount" -TenantId "8bc48661-1801-4b7a-8ca1-6a3cadfb4870" -Subscription "8bc48661-1801-4b7a-8ca1-6a3cadfb4870" -GraphAccessToken "12345678"
        Mock -ModuleName TestFx-Tasks Get-AzureRmADServicePrincipal { return @() }
        Mock -ModuleName TestFx-Tasks New-AzureRMADServicePrincipal { return @{"ApplicationId" = "8bc48661-1801-4b7a-8ca1-6a3cadfb4870"; "Id" = "8bc48661-1801-4b7a-8ca1-6a3cadfb4870"} }
        Mock -ModuleName TestFx-Tasks New-AzureRMRoleAssignment { return $true }
        Mock -ModuleName TestFx-Tasks Get-AzureRMRoleAssignment { return $true }
        $context = Get-AzureRmContext
        $secureSecret = ConvertTo-SecureString -String "testpassword" -AsPlainText -Force
        New-TestCredential -ServicePrincipalDisplayName "credentialtestserviceprincipal" -ServicePrincipalSecret $secureSecret -SubscriptionId $context.Subscription.Id -TenantId $context.Tenant.Id -RecordMode "Playback" -Force
        $filePath = $Env:USERPROFILE + "\.azure\testcredentials.json"
        It "writes correct information to file" {
            $filePath | Should Contain "ServicePrincipal":  "8bc48661-1801-4b7a-8ca1-6a3cadfb4870"
            $filePath | Should Contain "ServicePrincipalSecret":  "testpassword"
        }
    }
	
	Context "Connection string is properly set" {
        $filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\bin\Debug\Microsoft.Azure.Commands.ScenarioTest.Common.dll"
        $assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
        $envHelper = New-Object Microsoft.WindowsAzure.Commands.ScenarioTest.EnvironmentSetupHelper -ArgumentList @()
        $envHelper.SetEnvironmentVariableFromCredentialFile()
        It "creates correctly formatted environment string" {
            $Env:AZURE_TEST_MODE | Should Match "Playback"
            $Env:TEST_CSM_ORGID_AUTHENTICATION | Should Match "SubscriptionId=" + $context.Subscription.Id + ";HttpRecorderMode=Playback;Environment=Prod;ServicePrincipal=" + 
            "8bc48661-1801-4b7a-8ca1-6a3cadfb4870" + ";ServicePrincipalSecret=testpassword;" + "AADTenant=" + $context.Tenant.Id
        }
    }

	# Clean-up
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
	$filePath = $Env:USERPROFILE + "\.azure\testcredentials.json"
	Remove-Item -LiteralPath $filePath -Force
	$directoryPath = $Env:USERPROFILE + "\.azure\"
	$directoryEmpty = Get-ChildItem $directoryPath | Measure-Object
	if ($directoryEmpty.Count -eq 0)
	{
		Remove-Item $directoryPath -Recurse -Force
	}
}

Describe "Test-NewCredentialExistingServicePrincipal" {
	Context "Finds and uses a ServicePrincipal"{
        Login-AzureRmAccount -AccessToken "12345678" -SkipValidation -AccountId "testaccount" -TenantId "8bc48661-1801-4b7a-8ca1-6a3cadfb4870" -Subscription "8bc48661-1801-4b7a-8ca1-6a3cadfb4870" -GraphAccessToken "12345678"
        Mock -ModuleName TestFx-Tasks Get-AzureRmADServicePrincipal { return @(@{"ApplicationId" = "1234"; "Id" = "5678"; "DisplayName" = "credentialtestserviceprincipal"}) }
        $context = Get-AzureRmContext
        $secureSecret = ConvertTo-SecureString -String "testpassword" -AsPlainText -Force
        New-TestCredential -ServicePrincipalDisplayName "credentialtestserviceprincipal" -ServicePrincipalSecret $secureSecret -SubscriptionId $context.Subscription.Id -TenantId $context.Tenant.Id -RecordMode "Record" -Force
        $filePath = $Env:USERPROFILE + "\.azure\testcredentials.json"
        It "writes correct information to file" {
            $filePath | Should Contain "ServicePrincipal":  "1234"
            $filePath | Should Contain "ServicePrincipalSecret":  "testpassword"
        }
    }

    Context "Connection string is properly set" {
        $filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\bin\Debug\Microsoft.Azure.Commands.ScenarioTest.Common.dll"
        $assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
        $envHelper = New-Object Microsoft.WindowsAzure.Commands.ScenarioTest.EnvironmentSetupHelper -ArgumentList @()
        $envHelper.SetEnvironmentVariableFromCredentialFile()
        It "creates correctly formatted environment string" {
            $Env:AZURE_TEST_MODE | Should Match "Record"
            $Env:TEST_CSM_ORGID_AUTHENTICATION | Should Match "SubscriptionId=" + $context.Subscription.Id + ";HttpRecorderMode=Record;Environment=Prod;ServicePrincipal=" + 
                "1234" + ";ServicePrincipalSecret=testpassword;" + "AADTenant=" + $context.Tenant.Id
        }
    }

	# Clean-up
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
	$filePath = $Env:USERPROFILE + "\.azure\testcredentials.json"
	Remove-Item -LiteralPath $filePath -Force
	$directoryPath = $Env:USERPROFILE + "\.azure\"
	$directoryEmpty = Get-ChildItem $directoryPath | Measure-Object
	if ($directoryEmpty.Count -eq 0)
	{
		Remove-Item $directoryPath -Recurse -Force
	}
}

Describe "Test-NewCredentialUserId" {
    Context "Creates correct file" {
        $context = Get-AzureRmContext
		New-TestCredential -UserId "testuser" -SubscriptionId $context.Subscription.Id -RecordMode "Playback" -Force
		$filePath = $Env:USERPROFILE + "\.azure\testcredentials.json"
        It "writes correct information to file" {
            $filePath | Should Contain "UserId":  "testuser"
            $filePath | Should Contain "HttpRecorderMode":  "Playback"
        }
    }
	
	Context "Connection string is properly set" {
        $filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\bin\Debug\Microsoft.Azure.Commands.ScenarioTest.Common.dll"
        $assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
        $envHelper = New-Object Microsoft.WindowsAzure.Commands.ScenarioTest.EnvironmentSetupHelper -ArgumentList @()
        $envHelper.SetEnvironmentVariableFromCredentialFile()
        It "creates correctly formatted environment string" {
            $Env:AZURE_TEST_MODE | Should Match "Playback"
            $Env:TEST_CSM_ORGID_AUTHENTICATION | Should Match "SubscriptionId=" + $context.Subscription.Id + ";HttpRecorderMode=Playback;Environment=Prod;UserId=testuser"
		}
	}

	# Clean-up
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
	$filePath = $Env:USERPROFILE + "\.azure\testcredentials.json"
	Remove-Item -LiteralPath $filePath -Force
	$directoryPath = $Env:USERPROFILE + "\.azure\"
	$directoryEmpty = Get-ChildItem $directoryPath | Measure-Object
	if ($directoryEmpty.Count -eq 0)
	{
		Remove-Item $directoryPath -Recurse -Force
	}
}

Describe "Test-SetEnvironmentServicePrincipal" {
	Context "Connection string is properly set" {
		$context = Get-AzureRmContext
		$NewServicePrincipal = @{"ApplicationId" = "1234"; "Id" = "5678"; "DisplayName" = "credentialtestserviceprincipal"}
		Set-TestEnvironment -ServicePrincipalId $NewServicePrincipal.ApplicationId -ServicePrincipalSecret "testpassword" -SubscriptionId $context.Subscription.Id -TenantId $context.Tenant.Id -RecordMode "Record"
		It "creates correctly formatted environment string" {
            $Env:AZURE_TEST_MODE | Should Match "Record"
			$Env:TEST_CSM_ORGID_AUTHENTICATION | Should Match "SubscriptionId=" + $context.Subscription.Id + ";HttpRecorderMode=Record;Environment=Prod;AADTenant=" +
				$context.Tenant.Id + ";ServicePrincipal=" + "1234" + ";ServicePrincipalSecret=testpassword"
		}
	}

	# Clean-up
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
}

Describe "Test-SetEnvironmentUserId" {
	Context "Connection string is properly set" {
		$context = Get-AzureRmContext
		Set-TestEnvironment -UserId "testuser" -SubscriptionId $context.Subscription.Id -RecordMode "Playback"
		It "creates correctly formatted environment string" {
            $Env:AZURE_TEST_MODE | Should Match "Playback"
			$Env:TEST_CSM_ORGID_AUTHENTICATION | Should Match "SubscriptionId=" + $context.Subscription.Id + ";HttpRecorderMode=Playback;Environment=Prod;UserId=testuser"
		}
	}

	# Clean-up
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
}