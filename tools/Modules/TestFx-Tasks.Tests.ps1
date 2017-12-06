
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

Describe "Test-NewCredentialNewServicePrincipal"{
	Context "Creates a correctly formatted ServicePrincipal"{
        Mock Get-AzureRmADServicePrincipal { return $null }
        Mock New-AzureRMADServicePrincipal { return @{"ApplicationId" = "1234"; "Id" = "5678"} }
        Mock New-AzureRMRoleAssignment { return $true }
        Mock Get-AzureRMRoleAssignment { return $true }
        $subscriptionId = "1234"
        $tenantId = "5678"
        $secureSecret = ConvertTo-SecureString -String "testpassword" -AsPlainText -Force
        New-TestCredential -ServicePrincipalDisplayName "credentialtestserviceprincipal" -ServicePrincipalSecret $secureSecret -SubscriptionId $subscriptionId -TenantId $tenantId -RecordMode "Record" -Force
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
            $Env:TEST_CSM_ORGID_AUTHENTICATION | Should Match "SubscriptionId=" + $subscriptionId + ";HttpRecorderMode=Record;Environment=Prod;ServicePrincipal=" + 
                "1234" + ";ServicePrincipalSecret=testpassword;" + "AADTenant=" + $tenantId
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
        Mock Get-AzureRmADServicePrincipal { return @{"ApplicationId" = "1234"; "Id" = "5678"} }
        $subscriptionId = "1234"
        $tenantId = "5678"
        $secureSecret = ConvertTo-SecureString -String "testpassword" -AsPlainText -Force
        New-TestCredential -ServicePrincipalDisplayName "credentialtestserviceprincipal" -ServicePrincipalSecret $secureSecret -SubscriptionId $subscriptionId -TenantId $tenantId -RecordMode "Record" -Force
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
            $Env:TEST_CSM_ORGID_AUTHENTICATION | Should Match "SubscriptionId=" + $subscriptionId + ";HttpRecorderMode=Record;Environment=Prod;ServicePrincipal=" + 
                "1234" + ";ServicePrincipalSecret=testpassword;" + "AADTenant=" + $tenantId
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
        $subscriptionId = "1234"
        $tenantId = "5678"
		New-TestCredential -UserId "testuser" -SubscriptionId $subscriptionId -RecordMode "Playback" -Force
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
            $Env:TEST_CSM_ORGID_AUTHENTICATION | Should Match "SubscriptionId=" + $subscriptionId + ";HttpRecorderMode=Playback;Environment=Prod;UserId=testuser"
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
		$subscriptionId = "1234"
        $tenantId = "5678"
		Mock Get-AzureRmADServicePrincipal { return @{"ApplicationId" = "1234"; "Id" = "5678"} }
		$NewServicePrincipal = Get-AzureRmADServicePrincipal
		Set-TestEnvironment -ServicePrincipalId $NewServicePrincipal.ApplicationId -ServicePrincipalSecret "testpassword" -SubscriptionId $subscriptionId -TenantId $tenantId -RecordMode "Record"
		It "creates correctly formatted environment string" {
            $Env:AZURE_TEST_MODE | Should Match "Record"
			$Env:TEST_CSM_ORGID_AUTHENTICATION | Should Match "SubscriptionId=" + $subscriptionId + ";HttpRecorderMode=Record;Environment=Prod;AADTenant=" +
				$tenantId + ";ServicePrincipal=" + "1234" + ";ServicePrincipalSecret=testpassword"
		}
	}

	# Clean-up
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
}

Describe "Test-SetEnvironmentUserId" {
	Context "Connection string is properly set" {
		$subscriptionId = "1234"
        $tenantId = "5678"
		Set-TestEnvironment -UserId "testuser" -SubscriptionId $subscriptionId -RecordMode "Playback"
		It "creates correctly formatted environment string" {
            $Env:AZURE_TEST_MODE | Should Match "Playback"
			$Env:TEST_CSM_ORGID_AUTHENTICATION | Should Match "SubscriptionId=" + $subscriptionId + ";HttpRecorderMode=Playback;Environment=Prod;UserId=testuser"
		}
	}

	# Clean-up
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
}