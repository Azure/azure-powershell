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
    Run AzureStack fabric admin edge gateway pool tests.

.DESCRIPTION
    Run AzureStack fabric admin edge gateway pool tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\RegionHealth.Tests.ps1
	Describing RegionHealths
	[+] TestListRegionHealths 182ms
	[+] TestGetRegionHealth 112ms
	[+] TestGetAllRegionHealths 113ms

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

InModuleScope Azs.Gallery.Admin {

    Describe "GalleryItem" -Tags @('RegionHealth', 'GalleryAdmin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateGalleryItem {
                param(
                    [Parameter(Mandatory = $true)]
                    $GalleryItem
                )

                $GalleryItem          | Should Not Be $null

                # Resource
                $GalleryItem.Id       | Should Not Be $null
                $GalleryItem.Name     | Should Not Be $null
                $GalleryItem.Type     | Should Not Be $null

                # Gallery Item
                $GalleryItem.AdditionalProperties	| Should Not Be $null
                $GalleryItem.Artifacts				| Should Not Be $null
                $GalleryItem.ChangedTime			| Should Not Be $null
                $GalleryItem.CreatedTime			| Should Not Be $null
                $GalleryItem.DefinitionTemplates	| Should Not Be $null
                $GalleryItem.Description			| Should Not Be $null
                $GalleryItem.IconFileUris			| Should Not Be $null
                $GalleryItem.Identity				| Should Not Be $null
                $GalleryItem.Images					| Should Not Be $null
                $GalleryItem.ItemDisplayName		| Should Not Be $null
                $GalleryItem.ItemName				| Should Not Be $null
                $GalleryItem.ItemType				| Should Not Be $null
                $GalleryItem.LongSummary			| Should Not Be $null
                $GalleryItem.Metadata				| Should Not Be $null
                $GalleryItem.Properties				| Should Not Be $null
                $GalleryItem.Publisher				| Should Not Be $null
                $GalleryItem.PublisherDisplayName	| Should Not Be $null
                $GalleryItem.Summary				| Should Not Be $null
                $GalleryItem.UiDefinitionUri		| Should Not Be $null
                $GalleryItem.Version				| Should Not Be $null

            }

            function AssertGalleryItemsAreSame {
                param(
                    [Parameter(Mandatory = $true)]
                    $Expected,

                    [Parameter(Mandatory = $true)]
                    $Found
                )
                if ($Expected -eq $null) {
                    $Found | Should Be $null
                } else {
                    $Found                  | Should Not Be $null

                    # Resource
                    $Found.Id               | Should Be $Expected.Id
                    $Found.Location         | Should Be $Expected.Location
                    $Found.Name             | Should Be $Expected.Name
                    $Found.Type             | Should Be $Expected.Type

                    # Gallery Item
                    if ($Expected.CategoryIds -and $Found.CategoryIds) {
                        $Found.CategoryIds				| Should Be $Expected.CategoryIds
                    } elseif (($null -ne $Expected.CategoryIds) -and ($null -eq $Found.CategoryIds)) {
                        throw "Category Ids do not match Expected: $($Expected.CategoryIds)"
                    }
                    $Found.Description				| Should Be $Expected.Description
                    $Found.LongSummary				| Should Be $Expected.LongSummary
                    $Found.Publisher				| Should Be $Expected.Publisher
                    $Found.PublisherDisplayName		| Should Be $Expected.PublisherDisplayName
                    $Found.UiDefinitionUri			| Should Be $Expected.UiDefinitionUri
                    $Found.Version					| Should Be $Expected.Version

                }
            }
        }

        AfterEach {
            $global:Client = $null
        }


        it "TestListAllGalleryItems" -Skip:$('TestListAllGalleryItems' -in $global:SkippedTests) {
            $global:TestName = 'TestListAllGalleryItems'

            $GalleryItems = Get-AzsGalleryItem
            $GalleryItems | Should Not Be $null
            foreach ($GalleryItem in $GalleryItems) {
                ValidateGalleryItem -GalleryItem $GalleryItem
            }
        }


        it "TestGetGalleryItem" -Skip:$('TestGetGalleryItem' -in $global:SkippedTests) {
            $global:TestName = 'TestGetGalleryItem'

            $GalleryItems = Get-AzsGalleryItem
            $GalleryItems | Should Not Be $null
            foreach ($GalleryItem in $GalleryItems) {
                $retrieved = Get-AzsGalleryItem -Name $GalleryItem.Name
                AssertGalleryItemsAreSame -Expected $GalleryItem -Found $retrieved
            }
        }

        it "TestCreateAndDeleteGalleryItem" -Skip:$('TestCreateAndDeleteGalleryItem' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateAndDeleteGalleryItem'

            $name = "microsoft.vmss.1.3.6"
            $uri = "https://github.com/Azure/AzureStack-Tools/raw/master/ComputeAdmin/microsoft.vmss.1.3.6.azpkg"
            Remove-AzsGalleryItem -Name $name -Force

            $GalleryItem = Add-AzsGalleryItem -GalleryItemUri $uri -Force
            $GalleryItem | Should Not Be $null

            Remove-AzsGalleryItem -Name $GalleryItem.Name -Force
        }

        it "TestCreateAndDeleteGalleryItemPiped" -Skip:$('TestCreateAndDeleteGalleryItem' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateAndDeleteGalleryItem'

            $name = "microsoft.vmss.1.3.6"
            $uri = "https://github.com/Azure/AzureStack-Tools/raw/master/ComputeAdmin/microsoft.vmss.1.3.6.azpkg"
            Remove-AzsGalleryItem -Name $name -Force

            $GalleryItem = Add-AzsGalleryItem -GalleryItemUri $uri -Force
            $GalleryItem | Should Not Be $null

            $GalleryItem | Remove-AzsGalleryItem -Force
        }
    }
}
