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

function Test-GetAzVMExtensionImageMetadata
{
    $location = "CentralUSEUAP"
    $publisherName = "Microsoft.Cplat.Core"
    $extensionType = "NullWindows2"
    $version = "2.17.0"

    $image = Get-AzVMExtensionImage `
        -Location $location `
        -PublisherName $publisherName `
        -Type $extensionType `
        -Version $version
    Assert-NotNull $image
    Assert-AreEqual $version $image.Version
    Assert-NotNull $image.ReleaseNotes
    Assert-NotNull $image.ReleaseNotes
    Assert-NotNull $image.ExtensionFeatureMetadata
    Assert-NotNull $image.ExtensionFeatureMetadata.ExtensionFeatureTags
    Assert-True { @($image.ExtensionFeatureMetadata.ExtensionFeatureTags).Count -gt 0 } "Extension feature tags should not be empty."
}

function Test-GetAzVMExtensionImageListWithExpand
{
    $images = Get-AzVMExtensionImage `
        -Location "EastUS2EUAP" `
        -PublisherName "Microsoft.Compute" `
        -Type "VMAccessAgent" `
        -FilterExpression "startswith(name,'2.4.16')" `
        -Expand Properties

    Assert-NotNull $images
    Assert-AreEqual 1 @($images).Count
    Assert-AreEqual "2.4.16" $images[0].Version
    Assert-AreEqual "BugFix" $images[0].ReleaseCategory
    Assert-AreEqual "Regular" $images[0].UrgencyLevel
    Assert-AreEqual "RunOnce" $images[0].RunProfile
}

function Test-GetAzVMExtensionImageListWithoutExpand
{
    $images = Get-AzVMExtensionImage `
        -Location "EastUS2EUAP" `
        -PublisherName "Microsoft.Compute" `
        -Type "VMAccessAgent" `
        -FilterExpression "startswith(name,'2.4.16')"

    Assert-NotNull $images
    Assert-AreEqual 1 @($images).Count
    Assert-AreEqual "2.4.16" $images[0].Version
    Assert-Null $images[0].ReleaseCategory
    Assert-Null $images[0].UrgencyLevel
    Assert-Null $images[0].RunProfile
}
