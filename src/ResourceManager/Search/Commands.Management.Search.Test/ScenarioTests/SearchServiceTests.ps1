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
Test New-AzureRmSearchService
#>
function Test-NewAzureRmSearchService
{
	    # Arrange
	$rgname = "TestAzureSearchPsGroup"
	$loc = "West US"
	$svcName = "pstestazuresearch"
	$sku = "Standard2"
	$partitionCount = 2
	$replicaCount = 2
	$hostingMode = "Default"

	try
    {
		New-AzureRmResourceGroup -Name $rgname -Location $loc
		
		# Act
		$newSearchService = New-AzureRmSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode
		
		# Assert
		Assert-NotNull $newSearchService
		Assert-AreEqual $newSearchService.Name $svcName
		Assert-AreEqual $newSearchService.Sku $sku
		Assert-AreEqual $newSearchService.Location $loc
		Assert-AreEqual $newSearchService.PartitionCount $partitionCount
		Assert-AreEqual $newSearchService.ReplicaCount $replicaCount
		Assert-AreEqual $newSearchService.HostingMode $hostingMode
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmSearchService
#>
function Test-GetAzureRmSearchService
{
    # Arrange
	$rgname = "TestAzureSearchPsGroup"
	$loc = "West US"
	$svcName = "pstestazuresearch"
	$sku = "Standard"

	try
    {
		New-AzureRmResourceGroup -Name $rgname -Location $loc
		
		# Act
		$newSearchService = New-AzureRmSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc

		# By ResourceGroup + Name
		$retrievedSearchService1 = Get-AzureRmSearchService -ResourceGroupName $rgname -Name $svcName

		# By ResourceId
		$retrievedSearchService2 = Get-AzureRmSearchService -ResourceId $newSearchService.Id
		
		# Assert
		Assert-NotNull $retrievedSearchService1
		Assert-NotNull $retrievedSearchService2

		Assert-AreEqual $newSearchService.Name $retrievedSearchService1.Name
		Assert-AreEqual $newSearchService.Name $retrievedSearchService2.Name

		Assert-AreEqual $newSearchService.Location $retrievedSearchService1.Location
		Assert-AreEqual $newSearchService.Location $retrievedSearchService2.Location

		Assert-AreEqual $newSearchService.Sku $retrievedSearchService1.Sku
		Assert-AreEqual $newSearchService.Sku $retrievedSearchService2.Sku

		# Create anther one in the same ResourceGroup.
		$svcName2 = "pstestazuresearch2"
		$newSearchService2 = New-AzureRmSearchService -ResourceGroupName $rgname -Name $svcName2 -Sku $sku -Location $loc

		# By ResourceGroup only = list
		$allSearchServices = Get-AzureRmSearchService -ResourceGroupName $rgname

		Assert-AreEqual 2 $allSearchServices.Count
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Remove-AzureRmSearchService
#>
function Test-RemoveAzureRmSearchService
{
    # Arrange
	$rgname = "TestAzureSearchPsGroup"
	$loc = "West US"
	$sku = "Standard"

	try
    {
		New-AzureRmResourceGroup -Name $rgname -Location $loc
		
		# 1
		# Act - Create
		$newSearchService = New-AzureRmSearchService -ResourceGroupName $rgname -Name "pstestazuresearch1" -Sku $sku -Location $loc

		# Can Get
		#$retrievedSvc = Get-AzureRmSearchService -ResourceId $newSearchService.Id
		Assert-NotNull $retrievedSvc

		# Remove by InputObject
		$retrievedSvc | Remove-AzureRmSearchService

		# Assert Get nothing
		$retrievedSvc = Get-AzureRmSearchService -ResourceId $newSearchService.Id
		Assert-Null $retrievedSvc
		
		# 2
		# Act - Create
		$newSearchService = New-AzureRmSearchService -ResourceGroupName $rgname -Name "pstestazuresearch2" -Sku $sku -Location $loc
		
		# Can Get
		$retrievedSvc = Get-AzureRmSearchService -ResourceId $newSearchService.Id
		Assert-NotNull $retrievedSvc
		
		# Remove by ResourceId
		Remove-AzureRmSearchService -ResourceId $retrievedSvc.Id

		# Assert Get nothing
		$retrievedSvc = Get-AzureRmSearchService -ResourceId $newSearchService.Id
		Assert-Null $retrievedSvc

		# 3
		# Act - Create
		$newSearchService = New-AzureRmSearchService -ResourceGroupName $rgname -Name "pstestazuresearch3" -Sku $sku -Location $loc
		
		# Can Get
		$retrievedSvc = Get-AzureRmSearchService -ResourceId $newSearchService.Id
		Assert-NotNull $retrievedSvc
		
		# Remove by ResourceGroup + Name
		Remove-AzureRmSearchService -ResourceGroupName $rgname -Name $svcName

		# Assert Get nothing
		$retrievedSvc = Get-AzureRmSearchService -ResourceId $newSearchService.Id
		Assert-Null $retrievedSvc
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}