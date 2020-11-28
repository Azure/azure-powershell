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
	#Create bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
	#Create bookmark
	$bookmark2 = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DisplayName "PoshModuleTest2" -Query "SecurityAlert | take 1"
	
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
	#Create $bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
		
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
    #Create $bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
		
	# Validate
	Validate-Bookmark $bookmark

	#Cleanup
	Remove-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark.Name)
}

<#
.SYNOPSIS
Update Bookmark
#>
function Set-AzSentinelBookmark-Update
{
	#Create $bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
		
	#update $bookmark
	$bookmark2 = Set-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark.Name) -Etag ($bookmark.etag) -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1" -Notes "PoshModuleTest"
	
	# Validate
	Validate-Bookmark $bookmark

	#Cleanup
	Remove-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -BookmarkId ($bookmark.Name)
	
	
	}

	function Set-AzSentinelBookmark-InputObject
{
	#Create $bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
	$bookmark.Notes = "testnotes"
	#update $bookmark
	$bookmark2 = $bookmark | Set-AzSentinelBookmark
	
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
	#Create $bookmark
	$bookmark = New-AzSentinelBookmark -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -DisplayName "PoshModuleTest" -Query "SecurityAlert | take 1"
	
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