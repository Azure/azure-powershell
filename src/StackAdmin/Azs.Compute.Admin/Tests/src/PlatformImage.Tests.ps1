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

. $PSScriptRoot\CommonModules.ps1

$global:VHDUri = "https://test.blob.local.azurestack.external/test/xenial-server-cloudimg-amd64-disk1.vhd"
$global:TestName = ""

InModuleScope Azs.Compute.Admin {

    Describe "PlatformImages" -Tags @('SubscriberPlatformImage', 'Azs.Compute.Admin') {

        BeforeEach {

            . $PSScriptRoot\Common.ps1

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

        It "TestListPlatformImages" {
            $global:TestName = 'TestListPlatformImages'

            $platformImages = Get-AzsPlatformImage -Location "local"

            $platformImages  | Should Not Be $null
            foreach ($platformImage in $platformImages) {
                ValidatePlatformImage -PlatformImage $platformImage
            }
        }

        It "TestGetPlatformImage" {
            $global:TestName = 'TestGetPlatformImage'

            $platformImages = Get-AzsPlatformImage -Location "local"
            $platformImages  | Should Not Be $null

            foreach ($platformImage in $platformImages) {

                $part = $platformImage.Id.Split("/")
                $publisher = $part[10]
                $offer = $part[12]
                $sku = $part[14]
                $version = $part[16]

                $result = Get-AzsPlatformImage -Location "local" -Publisher $publisher -Offer $offer -Sku $sku -Version $version

                AssertSame -Expected $platformImage -Found $result
                break
            }
        }

        It "TestGetAllPlatformImages" {
            $global:TestName = 'TestGetAllPlatformImages'

            $platformImages = Get-AzsPlatformImage -Location "local"
            $platformImages  | Should Not Be $null
            foreach ($platformImage in $platformImages) {
                $result = $platformImage | Get-AzsPlatformImage
                AssertSame -Expected $platformImage -Found $result
            }
        }

        It "TestCreatePlatformImage" {
            $global:TestName = 'TestCreatePlatformImage'

            $Location = "Canonical";
            $Publisher = "Test";
            $Offer = "UbuntuServer";
            $Sku = "16.04-LTS";
            $Version = "1.0.0";

            $image = Add-AzsPlatformImage -Location $Location -Publisher $Publisher -Offer $Offer -Sku $Sku -Version $Version -OsType "Linux" -OsUri $global:VHDUri -Force

            $image | Should Not Be $null
            $image.OsDisk.Uri | Should be $global:VHDUri
            $image.OsDisk.OsType | Should be "Linux"

            while ($image.ProvisioningState -eq "Creating") {
                # Start-Sleep -Seconds 30
                $image = Get-AzsPlatformImage -Location $Location -Publisher $Publisher -Offer $Offer -Version $version
            }

            $image.ProvisioningState | Should be "Succeeded"

        }

        It "TestCreateAndDeletePlatformImage" {
            $global:TestName = 'TestCreateAndDeletePlatformImage'

            $Publisher = "Microsoft";
            $Offer = "UbuntuServer";
            $Sku = "16.04-LTS";
            $Version = "1.0.0";

            $image = Add-AzsPlatformImage -Location $Location -Publisher $Publisher -Offer $Offer -Sku $Sku -Version $Version -OsType "Linux" -OsUri $global:VHDUri -Force
            $image | Should Not Be $null
            $image.OsDisk.Uri | Should be $global:VHDUri

            while ($image.ProvisioningState -ne "Succeeded") {
                $image = Get-AzsPlatformImage -Location $Location -Publisher $Publisher -Offer $Offer -Sku $Sku -Version $version
            }
            $image.ProvisioningState | Should be "Succeeded"

            Remove-AzsPlatformImage -Location $Location -Publisher $Publisher -Offer $Offer -Version $version -Sku $Sku -Force

        }
    }
}
