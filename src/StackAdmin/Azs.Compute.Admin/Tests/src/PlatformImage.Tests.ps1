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
    Run AzureStack Compute admin edge gateway tests.

.DESCRIPTION
    Run AzureStack Compute admin edge gateway tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\SubscriberPlatformImage.Tests.ps1
    Describing SubscriberPlatformImages
	 [+] TestListSubscriberPlatformImages 81ms
	 [+] TestGetSubscriberPlatformImage 73ms
	 [+] TestGetAllSubscriberPlatformImages 66ms

.NOTES
    Author: Jeffrey Robinson
	Copyright: Microsoft
    Date:   August 24, 2017
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Compute.Admin {

    Describe "PlatformImages" -Tags @('SubscriberPlatformImage', 'Azs.Compute.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function Create() {

            }

            function ValidatePlatformImage {
                param(
                    [Parameter(Mandatory = $true)]
                    $PlatformImage
                )

                $PlatformImage          | Should Not Be $null

                # Resource
                $PlatformImage.Id       | Should Not Be $null
                $PlatformImage.Type     | Should Not Be $null

                # Subscriber Usage Aggregate
                $PlatformImage.OsDisk    | Should Not Be $null
                $PlatformImage.ProvisioningState    | Should Not Be $null
            }

            function AssertSame {
                param(
                    $Expected,
                    $Found
                )
            }
        }

		AfterEach {
			$global:Client = $null
		}

        It "TestListPlatformImages" -Skip:$('TestListPlatformImages' -in $global:SkippedTests) {
            $global:TestName = 'TestListPlatformImages'

            $platformImages = Get-AzsPlatformImage -Location $global:Location

            $platformImages  | Should Not Be $null
            foreach ($platformImage in $platformImages) {
                ValidatePlatformImage -PlatformImage $platformImage
            }
        }

        It "TestGetPlatformImage" -Skip:$('TestGetPlatformImage' -in $global:SkippedTests) {
            $global:TestName = 'TestGetPlatformImage'

            $platformImages = Get-AzsPlatformImage -Location $global:Location
            $platformImages  | Should Not Be $null

            foreach ($platformImage in $platformImages) {
                $result = Get-AzsPlatformImage -Location $global:Location -Publisher $platformImage.publisher -Offer $platformImage.offer -Sku $platformImage.sku -Version $platformImage.version
                AssertSame -Expected $platformImage -Found $result
                break
            }
        }

        It "TestGetAllPlatformImages" -Skip:$('TestGetAllPlatformImages' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllPlatformImages'

            $platformImages = Get-AzsPlatformImage -Location $global:Location
            $platformImages  | Should Not Be $null
            foreach ($platformImage in $platformImages) {
                $result = $platformImage | Get-AzsPlatformImage
                AssertSame -Expected $platformImage -Found $result
            }
        }

        It "TestCreatePlatformImage" -Skip:$('TestCreatePlatformImage' -in $global:SkippedTests) {
            $global:TestName = 'TestCreatePlatformImage'

            $script:Location = $global:Location;
            $script:Publisher = "Canonical";
            $script:Offer = "UbuntuServer";
            $script:Sku = "16.04-LTS";
            $script:Version = "1.0.0";

            $image = Add-AzsPlatformImage `
                -Location $script:Location `
                -Publisher $script:Publisher `
                -Offer $script:Offer `
                -Sku $script:Sku `
                -Version $script:Version `
                -OsType "Linux" `
                -OsUri $global:VHDUri `
                -Force

            $image | Should Not Be $null
            $image.OsDisk.Uri | Should be $global:VHDUri
            $image.OsDisk.OsType | Should be "Linux"

            while ($image.ProvisioningState -eq "Creating") {
                # Start-Sleep -Seconds 30
                Write-host $script:Location
                $image = Get-AzsPlatformImage `
                    -Location $script:Location `
                    -Publisher $script:Publisher `
                    -Offer $script:Offer `
                    -Version $script:version
            }

            $image.ProvisioningState | Should be "Succeeded"

        }

        It "TestCreateAndDeletePlatformImage" -Skip:$('TestCreateAndDeletePlatformImage' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateAndDeletePlatformImage'

            $script:Location = $global:Location;
            $script:Publisher = "Microsoft";
            $script:Offer = "UbuntuServer";
            $script:Sku = "16.04-LTS";
            $script:Version = "1.0.0";

            $image = Add-AzsPlatformImage `
                -Location $script:Location `
                -Publisher $script:Publisher `
                -Offer $script:Offer `
                -Sku $script:Sku `
                -Version $script:Version `
                -OsType "Linux" `
                -OsUri $global:VHDUri `
                -Force

            $image | Should Not Be $null
            $image.OsDisk.Uri | Should be $global:VHDUri

            while ($image.ProvisioningState -ne "Succeeded") {
                $image = Get-AzsPlatformImage `
                    -Location $script:Location `
                    -Publisher $script:Publisher `
                    -Offer $script:Offer `
                    -Version $script:version
            }
            $image.ProvisioningState | Should be "Succeeded"
            Remove-AzsPlatformImage -Location $script:Location -Publisher $script:Publisher -Offer $script:Offer -Version $script:version -Sku $script:Sku -Force
        }
    }
}
