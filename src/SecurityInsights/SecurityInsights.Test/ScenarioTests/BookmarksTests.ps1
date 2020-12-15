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
List Bookmarks
#>
function Get-AzSentinelBookmark-List
{
	$BookmarkId = "a85e3b3b-c95e-4f8d-b5d6-0e9bcbd2e664"
	$BookmarkId2 = "91c29052-8ec9-4395-ad6c-e5c6cf562eec"
	#Create bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId $BookmarkId -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
	#Create bookmark
	$bookmark2 = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId $BookmarkId2 -DisplayName "PoshModuleTest2" -Query "SecurityAlert | take 1"
	
	#Get Bookmarks
    $bookmarks = Get-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName)
	# Validate
	Validate-Bookmarks $bookmarks

	#Cleanup
	Remove-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark.Name)
	Remove-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark2.Name)
}

<#
.SYNOPSIS
Get Bookmark
#>
function Get-AzSentinelBookmark-Get
{
	$BookmarkId = "2032256f-9912-476d-805b-ea3f60243ac8"
	#Create $bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId $BookmarkId -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
		
	#Get Bookmark
    $bookmark = Get-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark.Name)
	# Validate
	Validate-Bookmark $bookmark

	#Cleanup
	Remove-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark.Name)
}

<#
.SYNOPSIS
Create Bookmark
#>
function New-AzSentinelBookmark-Create
{
    $BookmarkId = "3a1bd654-9986-4fb9-8584-36f9aba00356"
	#Create $bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId $BookmarkId -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
		
	# Validate
	Validate-Bookmark $bookmark

	#Cleanup
	Remove-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark.Name)
}

<#
.SYNOPSIS
Update Bookmark
#>
function Update-AzSentinelBookmark-Update
{
	$BookmarkId = "e1606ca5-cd05-42ba-ac77-cdf0da4b719f"
	#Create $bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId $BookmarkId -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
		
	#update $bookmark
	$bookmark2 = Update-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark.Name) -Note "PoshModuleTest"
	
	# Validate
	Validate-Bookmark $bookmark

	#Cleanup
	Remove-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark.Name)
	
	
	}

	function Update-AzSentinelBookmark-InputObject
{
	$BookmarkId = "4324441a-de38-42c2-83dd-bb93db929e7c"
	#Create $bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId $BookmarkId -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
	#update $bookmark
	$bookmark2 = Update-AzSentinelBookmark -Note "testnotes" -InputObject $bookmark 
	
	# Validate
	Validate-Bookmark $bookmark2

	#Cleanup
	Remove-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark.Name)
	
	
	}

<#
.SYNOPSIS
Delete Bookmark
#>
function Remove-AzSentinelBookmark-Remove
{
	$BookmarkId = "a18251f2-1a0f-45f2-bb0d-ad4121911fce"
	#Create $bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId $BookmarkId -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
	
	#delete
	Remove-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark.Name)
	# Validate
	Validate-Bookmark $bookmark

}

<#
.SYNOPSIS
Validates a list of bookmarks
#>
function Validate-Bookmarks
{
	param($bookmarks)

    Assert-True { $bookmarks.Count -gt 0 }

	Foreach($bookmark in $bookmarks)
	{
		Validate-Bookmark $bookmark
	}
}

<#
.SYNOPSIS
Validates a single bookmark
#>
function Validate-Bookmark
{
	param($bookmark)

	Assert-NotNull $bookmark
}