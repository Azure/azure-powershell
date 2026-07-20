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

function Test-NewAzResourceSimpleByResourceName
{
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        # Act
        $resource = New-AzResource -ResourceGroupName $rgName -Name $rName -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Properties @{ minimumTlsVersion = "TLS1_2" } -Tag @{ testtag = "testval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Assert
        Assert-NotNull $resource
        Assert-AreEqual $rgName $resource.ResourceGroupName
        Assert-AreEqual $rName $resource.Name
        Assert-AreEqual $resourceType $resource.ResourceType
        Assert-AreEqual "Standard_LRS" $resource.Sku.name
        Assert-AreEqual "TLS1_2" $resource.Properties.minimumTlsVersion
        Assert-AreEqual "testval" $resource.Tags["testtag"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-NewAzResourceSimpleByResourceId
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $resourceId = "/subscriptions/$($subscriptionId)/resourceGroups/$rgName/providers/$resourceType/$rName"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        # Act
        $resource = New-AzResource -ResourceId $resourceId -Location $location -Sku @{ Name = "Standard_LRS" } -Properties @{ minimumTlsVersion = "TLS1_2" } -Tag @{ testtag = "testval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Assert
        Assert-NotNull $resource
        Assert-AreEqual $rgName $resource.ResourceGroupName
        Assert-AreEqual $rName $resource.Name
        Assert-AreEqual $resourceType $resource.ResourceType
        Assert-AreEqual "Standard_LRS" $resource.Sku.name
        Assert-AreEqual "TLS1_2" $resource.Properties.minimumTlsVersion
        Assert-AreEqual "testval" $resource.Tags["testtag"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-NewAzResourceWithApiVersion
{
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $rNamePre = Get-ResourceName
    $resourceType = "Microsoft.Sql/servers"
    $location = "eastus"
    $apiVersion = "2023-08-01"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        # Act
        $resource = New-AzResource -ResourceGroupName $rgName -Name $rName -Location $location -ResourceType $resourceType -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.2" } -Tag @{ testtag = "testval" } -ApiVersion $apiVersion -Force
        $preResource = New-AzResource -ResourceGroupName $rgName -Name $rNamePre -Location $location -ResourceType $resourceType -Properties @{ administratorLogin = "preadminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.2" } -Tag @{ pretesttag = "pretestval" } -Pre -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Assert
        Assert-NotNull $resource
        Assert-AreEqual $rgName $resource.ResourceGroupName
        Assert-AreEqual $rName $resource.Name
        Assert-AreEqual $resourceType $resource.ResourceType
        Assert-AreEqual "adminuser" $resource.Properties.administratorLogin
        Assert-AreEqual "1.2" $resource.Properties.minimalTlsVersion
        Assert-AreEqual "testval" $resource.Tags["testtag"]

        Assert-NotNull $preResource
        Assert-AreEqual $rgName $preResource.ResourceGroupName
		Assert-AreEqual $rNamePre $preResource.Name
		Assert-AreEqual $resourceType $preResource.ResourceType
		Assert-AreEqual "preadminuser" $preResource.Properties.administratorLogin
		Assert-AreEqual "1.2" $preResource.Properties.minimalTlsVersion
		Assert-AreEqual "pretestval" $preResource.Tags["pretesttag"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-NewAzResourceComplexByResourceName
{
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        # Act
        $parentResource = New-AzResource -ResourceGroupName $rgName -Name $rNameParent -Location $location -ResourceType $resourceTypeParent -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.2" } -Tag @{ parenttesttag = "parenttestval" } -Force
        $childResource = New-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -Location $location -ResourceType $resourceTypeChild -Properties @{ collation = "Latin1_General_CI_AS" } -Tag @{ childtesttag = "childtestval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Assert
        Assert-NotNull $parentResource
        Assert-AreEqual $rgName $parentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $parentResource.ResourceName
        Assert-AreEqual $rNameParent $parentResource.Name
        Assert-AreEqual $resourceTypeParent $parentResource.ResourceType
        Assert-AreEqual "adminuser" $parentResource.Properties.administratorLogin
        Assert-AreEqual "1.2" $parentResource.Properties.minimalTlsVersion
        Assert-AreEqual "parenttestval" $parentResource.Tags["parenttesttag"]

        Assert-NotNull $childResource
        Assert-AreEqual $rgName $childResource.ResourceGroupName
        Assert-AreEqual "$rNameParent/$rNameChild" $childResource.ResourceName
        Assert-AreEqual $rNameChild $childResource.Name
        Assert-AreEqual $resourceTypeChild $childResource.ResourceType
        Assert-AreEqual "Latin1_General_CI_AS" $childResource.Properties.collation
        Assert-AreEqual "childtestval" $childResource.Tags["childtesttag"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-NewAzResourceComplexByResourceId
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $resourceIdParent = "/subscriptions/$($subscriptionId)/resourceGroups/$rgName/providers/$resourceTypeParent/$rNameParent"
    $resourceIdChild = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/$resourceTypeParent/$rNameParent/databases/$rNameChild"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        # Act
        $parentResource = New-AzResource -ResourceId $resourceIdParent -Location $location -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.2" } -Tag @{ parenttesttag = "parenttestval" } -Force
        $childResource = New-AzResource -ResourceId $resourceIdChild -Location $location -Properties @{ collation = "Latin1_General_CI_AS" } -Tag @{ childtesttag = "childtestval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Assert
        Assert-NotNull $parentResource
        Assert-AreEqual $rgName $parentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $parentResource.ResourceName
        Assert-AreEqual $rNameParent $parentResource.Name
        Assert-AreEqual $resourceTypeParent $parentResource.ResourceType
        Assert-AreEqual "adminuser" $parentResource.Properties.administratorLogin
        Assert-AreEqual "1.2" $parentResource.Properties.minimalTlsVersion
        Assert-AreEqual "parenttestval" $parentResource.Tags["parenttesttag"]

        Assert-NotNull $childResource
        Assert-AreEqual $rgName $childResource.ResourceGroupName
        Assert-AreEqual "$rNameParent/$rNameChild" $childResource.ResourceName
        Assert-AreEqual $rNameChild $childResource.Name
        Assert-AreEqual $resourceTypeChild $childResource.ResourceType
        Assert-AreEqual "Latin1_General_CI_AS" $childResource.Properties.collation
        Assert-AreEqual "childtestval" $childResource.Tags["childtesttag"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-GetAzResourceByResourceName
{
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rNameParent -Location $location -ResourceType $resourceTypeParent -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.2" } -Tag @{ parenttesttag = "parenttestval" } -Force
        New-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -Location $location -ResourceType $resourceTypeChild -Properties @{ collation = "Latin1_General_CI_AS" } -Tag @{ childtesttag = "childtestval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Act
        $parentResource = Get-AzResource -ResourceGroupName $rgName -Name $rNameParent -ExpandProperties
        $childResource = Get-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -ExpandProperties

        # Assert
        Assert-NotNull $parentResource
        Assert-AreEqual $rgName $parentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $parentResource.Name
        Assert-AreEqual $resourceTypeParent $parentResource.ResourceType
        Assert-AreEqual "adminuser" $parentResource.Properties.administratorLogin
        Assert-AreEqual "1.2" $parentResource.Properties.minimalTlsVersion
        Assert-AreEqual "parenttestval" $parentResource.Tags["parenttesttag"]

        Assert-NotNull $childResource
        Assert-AreEqual $rgName $childResource.ResourceGroupName
        Assert-AreEqual $rNameChild $childResource.Name
        Assert-AreEqual $resourceTypeChild $childResource.ResourceType
        Assert-AreEqual "Latin1_General_CI_AS" $childResource.Properties.collation
        Assert-AreEqual "childtestval" $childResource.Tags["childtesttag"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-GetAzResourceByResourceId
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $resourceIdParent = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/$resourceTypeParent/$rNameParent"
    $resourceIdChild = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/$resourceTypeParent/$rNameParent/databases/$rNameChild"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceId $resourceIdParent -Location $location -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.2" } -Tag @{ parenttesttag = "parenttestval" } -Force
        New-AzResource -ResourceId $resourceIdChild -Location $location -Properties @{ collation = "Latin1_General_CI_AS" } -Tag @{ childtesttag = "childtestval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Act
        $parentResource = Get-AzResource -ResourceId $resourceIdParent -ExpandProperties
        $childResource = Get-AzResource -ResourceId $resourceIdChild -ExpandProperties

        # Assert
        Assert-NotNull $parentResource
        Assert-AreEqual $rgName $parentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $parentResource.Name
        Assert-AreEqual $resourceTypeParent $parentResource.ResourceType
        Assert-AreEqual "adminuser" $parentResource.Properties.administratorLogin
        Assert-AreEqual "1.2" $parentResource.Properties.minimalTlsVersion
        Assert-AreEqual "parenttestval" $parentResource.Tags["parenttesttag"]

        Assert-NotNull $childResource
        Assert-AreEqual $rgName $childResource.ResourceGroupName
        Assert-AreEqual $rNameChild $childResource.Name
        Assert-AreEqual $resourceTypeChild $childResource.ResourceType
        Assert-AreEqual "Latin1_General_CI_AS" $childResource.Properties.collation
        Assert-AreEqual "childtestval" $childResource.Tags["childtesttag"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-GetAzResourceByTag
{
    $rgName = Get-ResourceGroupName
    $rName1 = Get-ResourceName
    $rName2 = Get-ResourceName
	$rName3 = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rName1 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Tag @{ ScenarioTestTag = "ScenarioTestVal" } -Force
        New-AzResource -ResourceGroupName $rgName -Name $rName2 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Tag @{ ScenarioTestTag = $null } -Force
        New-AzResource -ResourceGroupName $rgName -Name $rName3 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Tag @{ ScenarioTestTag = "RandomTestVal"; RandomTestVal = "ScenarioTestVal" } -Force
        
        # Wait for the resources to be ready
		Start-TestSleep -Seconds 30

        # Act
        $resource = Get-AzResource -Tag @{ ScenarioTestTag = "ScenarioTestVal" }

        # Assert
        Assert-NotNull $resource
        Assert-AreEqual @($resource).Length 1
        Assert-AreEqual $rgName $resource.ResourceGroupName
        Assert-AreEqual $rName1 $resource.Name
        Assert-AreEqual $resourceType $resource.ResourceType

        # Act
        $resource = Get-AzResource -TagName "ScenarioTestTag" -TagValue "ScenarioTestVal"

        # Assert
        Assert-NotNull $resource
        Assert-AreEqual @($resource).Length 1
        Assert-AreEqual $rgName $resource.ResourceGroupName
        Assert-AreEqual $rName1 $resource.Name
        Assert-AreEqual $resourceType $resource.ResourceType

        # Act
        $resources = Get-AzResource -Tag @{ ScenarioTestTag = $null }

        # Assert
        Assert-NotNull $resources
        Assert-AreEqual @($resources).Length 3

        # Act
        $resources = Get-AzResource -TagName "ScenarioTestTag"

        # Assert
        Assert-NotNull $resources
        Assert-AreEqual @($resources).Length 3

        # Act
        $resources = Get-AzResource -TagValue "ScenarioTestVal"
        $resourceNames = $resources | Select-Object -ExpandProperty Name

        # Assert
        Assert-NotNull $resources
        Assert-AreEqual @($resources).Length 2
        Assert-True { $resourceNames -contains $rName1 }
        Assert-True { $resourceNames -contains $rName3 }
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-GetAzResourceViaPiping
{
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rNameParent -Location $location -ResourceType $resourceTypeParent -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.2" } -Tag @{ parenttesttag = "parenttestval" } -Force
        New-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -Location $location -ResourceType $resourceTypeChild -Properties @{ collation = "Latin1_General_CI_AS" } -Tag @{ childtesttag = "childtestval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Act
        $resources = Get-AzResource -ResourceGroupName $rgName | Get-AzResource -ExpandProperties

        $parentResource = $resources | Where-Object { $_.Name -eq $rNameParent -and $_.ResourceType -eq $resourceTypeParent }
        $childResource = $resources | Where-Object { $_.Name -eq $rNameChild -and $_.ResourceType -eq $resourceTypeChild }

        # Assert
        Assert-NotNull $resources
        Assert-AreEqual 3 @($resources).Length

        Assert-NotNull $parentResource
        Assert-AreEqual $rgName $parentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $parentResource.Name
        Assert-AreEqual $resourceTypeParent $parentResource.ResourceType
        Assert-AreEqual "adminuser" $parentResource.Properties.administratorLogin
        Assert-AreEqual "1.2" $parentResource.Properties.minimalTlsVersion
        Assert-AreEqual "parenttestval" $parentResource.Tags["parenttesttag"]

        Assert-NotNull $childResource
        Assert-AreEqual $rgName $childResource.ResourceGroupName
        Assert-AreEqual $rNameChild $childResource.Name
        Assert-AreEqual $resourceTypeChild $childResource.ResourceType
        Assert-AreEqual "Latin1_General_CI_AS" $childResource.Properties.collation
        Assert-AreEqual "childtestval" $childResource.Tags["childtesttag"]
    }
    finally
	{
		Clean-ResourceGroup $rgName
	}
}

function Test-GetAzResourceWithExpandProperties
{
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rNameParent -Location $location -ResourceType $resourceTypeParent -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.2" } -Tag @{ parenttesttag = "parenttestval" } -Force
        New-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -Location $location -ResourceType $resourceTypeChild -Properties @{ collation = "Latin1_General_CI_AS" } -Tag @{ childtesttag = "childtestval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Act
        $parentResource = Get-AzResource -ResourceGroupName $rgName -Name $rNameParent
        $childResource = Get-AzResource -ResourceGroupName $rgName -Name $rNameChild

        # Assert
        Assert-NotNull $parentResource
        Assert-AreEqual $rgName $parentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $parentResource.Name
        Assert-AreEqual $resourceTypeParent $parentResource.ResourceType
        Assert-Null $parentResource.Properties
        Assert-AreEqual "parenttestval" $parentResource.Tags["parenttesttag"]

        Assert-NotNull $childResource
        Assert-AreEqual $rgName $childResource.ResourceGroupName
        Assert-AreEqual "$rNameParent/$rNameChild" $childResource.Name
        Assert-AreEqual $resourceTypeChild $childResource.ResourceType
        Assert-Null $childResource.Properties
        Assert-AreEqual "childtestval" $childResource.Tags["childtesttag"]

        # Act
        $parentResource = Get-AzResource -ResourceGroupName $rgName -Name $rNameParent -ExpandProperties
        $childResource = Get-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -ExpandProperties

        # Assert
        Assert-NotNull $parentResource
        Assert-AreEqual $rgName $parentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $parentResource.Name
        Assert-AreEqual $resourceTypeParent $parentResource.ResourceType
        Assert-AreEqual "adminuser" $parentResource.Properties.administratorLogin
        Assert-AreEqual "1.2" $parentResource.Properties.minimalTlsVersion
        Assert-AreEqual "parenttestval" $parentResource.Tags["parenttesttag"]

        Assert-NotNull $childResource
        Assert-AreEqual $rgName $childResource.ResourceGroupName
        Assert-AreEqual $rNameChild $childResource.Name
        Assert-AreEqual $resourceTypeChild $childResource.ResourceType
        Assert-AreEqual "Latin1_General_CI_AS" $childResource.Properties.collation
        Assert-AreEqual "childtestval" $childResource.Tags["childtesttag"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-GetAzAResourceWithWildcard
{
    $rgName1 = (Get-ResourceGroupName) + "resourcegroup1"
    $rgName2 = (Get-ResourceGroupName) + "resourcegroup2"
    $rgName3 = (Get-ResourceGroupName) + "rsrgrp3"
    $rName11 = (Get-ResourceName) + "resource11"
    $rName12 = (Get-ResourceName) + "resource12"
    $rName21 = (Get-ResourceName) + "resource2"
    $rName22 = (Get-ResourceName) + "rsr2"
    $rName31 = (Get-ResourceName) + "rsr3"
    $rName32 = (Get-ResourceName) + "resource3"
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName1 -Location $location
        New-AzResourceGroup -Name $rgName2 -Location $location
        New-AzResourceGroup -Name $rgName3 -Location $location

        New-AzResource -ResourceGroupName $rgName1 -Name $rName11 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force
        New-AzResource -ResourceGroupName $rgName1 -Name $rName12 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force
        New-AzResource -ResourceGroupName $rgName2 -Name $rName21 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force
        New-AzResource -ResourceGroupName $rgName2 -Name $rName22 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force
        New-AzResource -ResourceGroupName $rgName3 -Name $rName31 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force
        New-AzResource -ResourceGroupName $rgName3 -Name $rName32 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force

        # Wait for the resources to be ready
		Start-TestSleep -Seconds 30

        # Act
		$resources = Get-AzResource -ResourceGroupName "*resourcegroup*"

        # Assert
        Assert-NotNull $resources
        Assert-AreEqual 4 @($resources).Length

        # Act
        $resources = Get-AzResource -Name "*rsr*"

        # Assert
        Assert-NotNull $resources
        Assert-AreEqual 2 @($resources).Length

        # Act
        $resources = Get-AzResource -ResourceGroupName "*resourcegroup*" -Name "*resource*"

		# Assert
		Assert-NotNull $resources
		Assert-AreEqual 3 @($resources).Length
    }
    finally
    {
        Clean-ResourceGroup $rgName1
        Clean-ResourceGroup $rgName2
        Clean-ResourceGroup $rgName3
    }
}

function Test-GetAzResourceFromEmptyResourceGroup
{
    $rgName = Get-ResourceGroupName
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        # Act
        $resources = Get-AzResource -ResourceGroupName $rgName

        # Assert
        Assert-Null $resources
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-GetAzResourceFromNonExisingResourceGroup
{
    # Arrange
    $rgName = Get-ResourceGroupName

    # Assert
    Assert-ThrowsContains { Get-AzResource -ResourceGroupName $rgName } "Resource group '$rgName' could not be found."
}

function Test-GetAzResourceForNonExisingResource
{
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceTypeSql = "Microsoft.Sql/servers"
    $resourceTypeWeb = "Microsoft.Web/sites"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        # Act + Assert
        Assert-ThrowsContains { Get-AzResource -ResourceGroupName $rgName -Name $rName -ResourceType $resourceTypeSql } "The Resource '$resourceTypeSql/$rName' under resource group '$rgName' was not found."
        Assert-ThrowsContains { Get-AzResource -ResourceGroupName $rgName -Name $rName -ResourceType $resourceTypeWeb } "The Resource '$resourceTypeWeb/$rName' under resource group '$rgName' was not found."
        Assert-ThrowsContains { Get-AzResource -ResourceGroupName $rgName -Name $rName -ResourceType 'Microsoft.FakeProvider/fakeType' } "The resource namespace 'Microsoft.FakeProvider' is invalid."
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-GetAzResourceForNonExisingResourceType
{
    # Arrange
    $resources = Get-AzResource -ResourceType 'Microsoft.FakeProvider/fakeType'

    # Assert
    Assert-Null $resources
}

function Test-MoveAzResourceByResourceId
{
    $rgNameSrc = Get-ResourceGroupName
    $rgNameDst = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgNameSrc -Location $location

        New-AzResource -ResourceGroupName $rgNameSrc -Name $rNameParent -Location $location -ResourceType $resourceTypeParent -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.2" } -Tag @{ parenttesttag = "parenttestval" } -Force
        New-AzResource -ResourceGroupName $rgNameSrc -Name "$rNameParent/$rNameChild" -Location $location -ResourceType $resourceTypeChild -Properties @{ collation = "Latin1_General_CI_AS" } -Tag @{ childtesttag = "childtestval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        New-AzResourceGroup -Name $rgNameDst -Location $location

        $srcResources = Get-AzResource -ResourceGroupName $rgNameSrc
        $dstResources = Get-AzResource -ResourceGroupName $rgNameDst

        $srcParentResource = Get-AzResource -ResourceGroupName $rgNameSrc -Name $rNameParent
        $srcChildResource = Get-AzResource -ResourceGroupName $rgNameSrc -Name $rNameChild

        # Assert before move
        Assert-NotNull $srcResources
        Assert-AreEqual 3 @($srcResources).Length

        Assert-NotNull $srcParentResource
        Assert-NotNull $srcChildResource

        Assert-Null $dstResources

        # Act
        Move-AzResource -ResourceId $srcParentResource.ResourceId -DestinationResourceGroupName $rgNameDst -Force

        $srcResources = Get-AzResource -ResourceGroupName $rgNameSrc
        $dstResources = Get-AzResource -ResourceGroupName $rgNameDst

        $dstParentResource = Get-AzResource -ResourceGroupName $rgNameDst -Name $rNameParent -ResourceType $resourceTypeParent -ExpandProperties
        $dstChildResource = Get-AzResource -ResourceGroupName $rgNameDst -Name "$rNameParent/$rNameChild" -ResourceType $resourceTypeChild -ExpandProperties

        # Assert after move
        Assert-Null $srcResources

        Assert-NotNull $dstResources
        Assert-AreEqual 3 @($dstResources).Length

        Assert-NotNull $dstParentResource
        Assert-AreEqual $rgNameDst $dstParentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $dstParentResource.Name
        Assert-AreEqual $resourceTypeParent $dstParentResource.ResourceType
        Assert-AreEqual "adminuser" $dstParentResource.Properties.administratorLogin
        Assert-AreEqual "1.2" $dstParentResource.Properties.minimalTlsVersion
        Assert-AreEqual "parenttestval" $dstParentResource.Tags["parenttesttag"]

        Assert-NotNull $dstChildResource
        Assert-AreEqual $rgNameDst $dstChildResource.ResourceGroupName
        Assert-AreEqual $rNameChild $dstChildResource.Name
        Assert-AreEqual $resourceTypeChild $dstChildResource.ResourceType
        Assert-AreEqual "Latin1_General_CI_AS" $dstChildResource.Properties.collation
        Assert-AreEqual "childtestval" $dstChildResource.Tags["childtesttag"]
    }
    finally
    {
        Clean-ResourceGroup $rgNameSrc
        Clean-ResourceGroup $rgNameDst
    }
}

function Test-MoveAzResourceInDifferentResourceGroups
{
    $rgNameSrc1 = Get-ResourceGroupName
    $rgNameSrc2 = Get-ResourceGroupName
    $rgNameDst = Get-ResourceGroupName
    $rName1 = Get-ResourceName
    $rName2 = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup $rgNameSrc1 -Location $location
        New-AzResourceGroup $rgNameSrc2 -Location $location
        New-AzResourceGroup $rgNameDst -Location $location

        $resource1 = New-AzResource -ResourceGroupName $rgNameSrc1 -Name $rName1 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force
        $resource2 = New-AzResource -ResourceGroupName $rgNameSrc2 -Name $rName2 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force

        # Act + Assert
        Assert-ThrowsContains { Move-AzResource -ResourceId $resource1.ResourceId, $resource2.ResourceId -DestinationResourceGroupName $rgNameDst -Force } "The resources being moved must all reside in the same resource group."
    }
    catch
    {
		Clean-ResourceGroup $rgNameSrc1
        Clean-ResourceGroup $rgNameSrc2
		Clean-ResourceGroup $rgNameDst
    }
}

function Test-MoveAzResourceToNonExistingResourceGroup
{
    $rgNameSrc = Get-ResourceGroupName
    $rgNameDst = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup $rgNameSrc -Location $location

        $resource = New-AzResource -ResourceGroupName $rgNameSrc -Name $rName -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force

        # Act + Assert
        Assert-ThrowsContains { Move-AzResource -ResourceId $resource.ResourceId -DestinationResourceGroupName $rgNameDst -Force } "ResourceGroupNotFound : Resource group '$rNameDst' could not be found."
    }
    catch
    {
		Clean-ResourceGroup $rgNameSrc
    }
}

function Test-MoveAzResourceNonExisting
{
    # Act + Assert
    Assert-Throws { Get-AzResource | Where-Object Name -eq "NonExistingResource" | Move-AzResource -DestinationResourceGroupName "AnyResourceGroup" } "At least one valid resource Id must be provided."
}

function Test-SetAzResourceByResourceName
{
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rNameParent -Location $location -ResourceType $resourceTypeParent -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.1" } -Tag @{ parenttesttag = "parenttestval" } -Force
        New-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -Location $location -ResourceType $resourceTypeChild -Sku @{ Name = "GP_Gen5"; Capacity = "6" } -Properties @{ collation = "Latin1_General_CI_AS"; maxSizeBytes = "1073741824" } -Tag @{ childtesttag = "childtestval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Act
        $parentResource = Set-AzResource -ResourceGroupName $rgName -Name $rNameParent -ResourceType $resourceTypeParent -Properties @{ minimalTlsVersion = "1.2" } -Tag @{ parenttesttagnew = "parenttestvalnew" } -Force
        $childResource = Set-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -ResourceType $resourceTypeChild -Sku @{ Name = "GP_S_Gen5"; Capacity = "8" } -Properties @{ maxSizeBytes = "2147483648" } -Tag @{ childtesttagnew = "childtestvalnew" } -Force

        # Assert
        Assert-NotNull $parentResource
        Assert-AreEqual $rgName $parentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $parentResource.ResourceName
        Assert-AreEqual $rNameParent $parentResource.Name
        Assert-AreEqual $resourceTypeParent $parentResource.ResourceType
        Assert-AreEqual "adminuser" $parentResource.Properties.administratorLogin
        Assert-AreEqual "1.2" $parentResource.Properties.minimalTlsVersion
        Assert-Null $parentResource.Tags["parenttesttag"]
        Assert-AreEqual "parenttestvalnew" $parentResource.Tags["parenttesttagnew"]

        Assert-NotNull $childResource
        Assert-AreEqual $rgName $childResource.ResourceGroupName
        Assert-AreEqual "$rNameParent/$rNameChild" $childResource.ResourceName
        Assert-AreEqual $rNameChild $childResource.Name
        Assert-AreEqual $resourceTypeChild $childResource.ResourceType
        Assert-AreEqual "GP_S_Gen5" $childResource.Sku.Name
        Assert-AreEqual "8" $childResource.Sku.Capacity
        Assert-AreEqual "2147483648" $childResource.Properties.maxSizeBytes
        Assert-Null $childResource.Tags["childtesttag"]
        Assert-AreEqual "childtestvalnew" $childResource.Tags["childtesttagnew"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-SetAzResourceByResourceId
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $resourceIdParent = "/subscriptions/$($subscriptionId)/resourceGroups/$rgName/providers/$resourceTypeParent/$rNameParent"
    $resourceIdChild = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/$resourceTypeParent/$rNameParent/databases/$rNameChild"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        $parentResource = New-AzResource -ResourceId $resourceIdParent -Location $location -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.1" } -Tag @{ parenttesttag = "parenttestval" } -Force
        $childResource = New-AzResource -ResourceId $resourceIdChild -Location $location -Sku @{ Name = "GP_Gen5"; Capacity = "6" } -Properties @{ collation = "Latin1_General_CI_AS"; maxSizeBytes = "1073741824" } -Tag @{ childtesttag = "childtestval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Act
        $parentResource = Set-AzResource -ResourceId $resourceIdParent -Properties @{ minimalTlsVersion = "1.2" } -Tag @{ parenttesttagnew = "parenttestvalnew" } -Force
        $childResource = Set-AzResource -ResourceId $resourceIdChild -Sku @{ Name = "GP_S_Gen5"; Capacity = "8" } -Properties @{ maxSizeBytes = "2147483648" } -Tag @{ childtesttagnew = "childtestvalnew" } -Force

        # Assert
        Assert-NotNull $parentResource
        Assert-AreEqual $rgName $parentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $parentResource.ResourceName
        Assert-AreEqual $rNameParent $parentResource.Name
        Assert-AreEqual $resourceTypeParent $parentResource.ResourceType
        Assert-AreEqual "adminuser" $parentResource.Properties.administratorLogin
        Assert-AreEqual "1.2" $parentResource.Properties.minimalTlsVersion
        Assert-Null $parentResource.Tags["parenttesttag"]
        Assert-AreEqual "parenttestvalnew" $parentResource.Tags["parenttesttagnew"]

        Assert-NotNull $childResource
        Assert-AreEqual $rgName $childResource.ResourceGroupName
        Assert-AreEqual "$rNameParent/$rNameChild" $childResource.ResourceName
        Assert-AreEqual $rNameChild $childResource.Name
        Assert-AreEqual $resourceTypeChild $childResource.ResourceType
        Assert-AreEqual "GP_S_Gen5" $childResource.Sku.Name
        Assert-AreEqual "8" $childResource.Sku.Capacity
        Assert-AreEqual "2147483648" $childResource.Properties.maxSizeBytes
        Assert-Null $childResource.Tags["childtesttag"]
        Assert-AreEqual "childtestvalnew" $childResource.Tags["childtesttagnew"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-SetAzResourceByResourceObject
{
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rNameParent -Location $location -ResourceType $resourceTypeParent -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.1" } -Tag @{ parenttesttag = "parenttestval" } -Force
        New-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -Location $location -ResourceType $resourceTypeChild -Sku @{ Name = "GP_Gen5"; Capacity = "6" } -Properties @{ collation = "Latin1_General_CI_AS"; maxSizeBytes = "1073741824" } -Tag @{ childtesttag = "childtestval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        $parentResource = Get-AzResource -ResourceGroupName $rgName -Name $rNameParent -ExpandProperties
        $childResource = Get-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -ExpandProperties

        # Act
        $parentResource = Set-AzResource -InputObject $parentResource -Properties @{ minimalTlsVersion = "1.2" } -Tag @{ parenttesttagnew = "parenttestvalnew" } -Force
        $childResource = Set-AzResource -InputObject $childResource -Sku @{ Name = "GP_S_Gen5"; Capacity = "8" } -Properties @{ maxSizeBytes = "2147483648" } -Tag @{ childtesttagnew = "childtestvalnew" } -Force
        
        # Assert
        Assert-NotNull $parentResource
        Assert-AreEqual $rgName $parentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $parentResource.ResourceName
        Assert-AreEqual $rNameParent $parentResource.Name
        Assert-AreEqual $resourceTypeParent $parentResource.ResourceType
        Assert-AreEqual "adminuser" $parentResource.Properties.administratorLogin
        Assert-AreEqual "1.2" $parentResource.Properties.minimalTlsVersion
        Assert-Null $parentResource.Tags["parenttesttag"]
        Assert-AreEqual "parenttestvalnew" $parentResource.Tags["parenttesttagnew"]

        Assert-NotNull $childResource
        Assert-AreEqual $rgName $childResource.ResourceGroupName
        Assert-AreEqual "$rNameParent/$rNameChild" $childResource.ResourceName
        Assert-AreEqual $rNameChild $childResource.Name
        Assert-AreEqual $resourceTypeChild $childResource.ResourceType
        Assert-AreEqual "GP_S_Gen5" $childResource.Sku.Name
        Assert-AreEqual "8" $childResource.Sku.Capacity
        Assert-AreEqual "2147483648" $childResource.Properties.maxSizeBytes
        Assert-Null $childResource.Tags["childtesttag"]
        Assert-AreEqual "childtestvalnew" $childResource.Tags["childtesttagnew"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-SetAzResourceViaPiping
{
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rNameParent -Location $location -ResourceType $resourceTypeParent -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password"; minimalTlsVersion = "1.1" } -Tag @{ parenttesttag = "parenttestval" } -Force
        New-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -Location $location -ResourceType $resourceTypeChild -Sku @{ Name = "GP_Gen5"; Capacity = "6" } -Properties @{ collation = "Latin1_General_CI_AS"; maxSizeBytes = "1073741824" } -Tag @{ childtesttag = "childtestval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        $parentResource = Get-AzResource -ResourceGroupName $rgName -Name $rNameParent -ExpandProperties
        $childResource = Get-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -ExpandProperties

        # Act
        $parentResource | Set-AzResource -Properties @{ minimalTlsVersion = "1.2" } -Tag @{ parenttesttagnew = "parenttestvalnew" } -Force
        $childResource | Set-AzResource -Sku @{ Name = "GP_S_Gen5"; Capacity = "8" } -Properties @{ maxSizeBytes = "2147483648" } -Tag @{ childtesttagnew = "childtestvalnew" } -Force
        
        $parentResource = Get-AzResource -ResourceGroupName $rgName -Name $rNameParent -ExpandProperties
        $childResource = Get-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -ExpandProperties

        # Assert
        Assert-NotNull $parentResource
        Assert-AreEqual $rgName $parentResource.ResourceGroupName
        Assert-AreEqual $rNameParent $parentResource.Name
        Assert-AreEqual $resourceTypeParent $parentResource.ResourceType
        Assert-AreEqual "adminuser" $parentResource.Properties.administratorLogin
        Assert-AreEqual "1.2" $parentResource.Properties.minimalTlsVersion
        Assert-Null $parentResource.Tags["parenttesttag"]
        Assert-AreEqual "parenttestvalnew" $parentResource.Tags["parenttesttagnew"]

        Assert-NotNull $childResource
        Assert-AreEqual $rgName $childResource.ResourceGroupName
        Assert-AreEqual $rNameChild $childResource.Name
        Assert-AreEqual $resourceTypeChild $childResource.ResourceType
        Assert-AreEqual "GP_S_Gen5" $childResource.Sku.Name
        Assert-AreEqual "8" $childResource.Sku.Capacity
        Assert-AreEqual "2147483648" $childResource.Properties.maxSizeBytes
        Assert-Null $childResource.Tags["childtesttag"]
        Assert-AreEqual "childtestvalnew" $childResource.Tags["childtesttagnew"]
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-SetAzResourceWithPatch
{
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rName -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Properties @{ minimumTlsVersion = "TLS1_1" } -Tag @{ testtag = "testval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Act
        $resource = Set-AzResource -ResourceGroupName $rgName -Name $rName -ResourceType $resourceType -Properties @{ minimumTlsVersion = "TLS1_2" } -Tag @{ testtagnew = "testvalnew" } -UsePatchSemantics -Force

        # Assert
        Assert-AreEqual $rgName $resource.ResourceGroupName
        Assert-AreEqual $rName $resource.Name
        Assert-AreEqual $resourceType $resource.ResourceType
        Assert-AreEqual "Standard_LRS" $resource.Sku.Name
        Assert-AreEqual "TLS1_2" $resource.Properties.minimumTlsVersion
        Assert-Null $resource.Tags["testtag"]
        Assert-AreEqual "testvalnew" $resource.Tags["testtagnew"]
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

function Test-SetAzResourceTags
{
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        $resource = New-AzResource -ResourceGroupName $rgName -Name $rName -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Tag @{ testtag = "testval" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Assert before set
        Assert-True { $resource.Tags.ContainsKey("testtag") }
        Assert-True { !$resource.Tags.ContainsKey("TESTtag") }

        Assert-True { $resource.Tags.testtag -ceq "testval" }
        Assert-True { $resource.Tags.testtag -cne "testVAL" }
 
        # Act
        Set-AzResource -ResourceGroupName $rgName -Name $rName -ResourceType $resourceType -Tag @{ testtag = "testval"; testTag2 = "TestVal2" } -Force

        $resource = Get-AzResource -ResourceGroupName $rgName -Name $rName -ResourceType $resourceType
        
        # Assert
        Assert-True { $resource.Tags.ContainsKey("testtag") }
        Assert-True { !$resource.Tags.ContainsKey("TESTtag") }

        Assert-True { $resource.Tags.ContainsKey("testTag2") }
        Assert-True { !$resource.Tags.ContainsKey("TestTag2") }
        
        Assert-True { $resource.Tags.testtag -ceq "testval" }
        Assert-True { $resource.Tags.testtag -cne "testVAL" }
        
        Assert-True { $resource.Tags.testTag2 -ceq "TestVal2" }
        Assert-True { $resource.Tags.testTag2 -cne "testval2" }
 
        # Act
        $resource | Set-AzResource -Tag @{ testTag = "testVAL"; testtag2 = "Testval2" } -Force

        $resource = Get-AzResource -ResourceGroupName $rgName -Name $rName -ResourceType $resourceType
       
        # Assert
        Assert-True { $resource.Tags.ContainsKey("testTag") }
        Assert-True { !$resource.Tags.ContainsKey("testtag") }

        Assert-True { $resource.Tags.ContainsKey("testtag2") }
        Assert-True { !$resource.Tags.ContainsKey("testTag2") }

        Assert-True { $resource.Tags.testTag -ceq "testVAL" }
        Assert-True { $resource.Tags.testTag -cne "testval" }
        
        Assert-True { $resource.Tags.testtag2 -ceq "Testval2" }
        Assert-True { $resource.Tags.testtag2 -cne "TestVal2" }
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-SetAzResourceForNonExistingResourceGroup
{
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    # Act + Assert
    Assert-ThrowsContains { Set-AzResource -ResourceGroupName $rgName -Name $rName -ResourceType $resourceType -Properties @{ propname = "propval" } -Force } "ResourceGroupNotFound : Resource group '$rgName' could not be found."
}

function Test-SetAzResourceForNonExistingResource
{
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        # Act + Assert
        Assert-ThrowsContains { Set-AzResource -ResourceGroupName $rgName -Name $rName -ResourceType $resourceType -Properties @{ propname = "propval" } -Force } "ResourceNotFound : The Resource '$resourceType/$rName' under resource group '$rgName' was not found."
    }
    catch
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-SetAzResourceForNonExistingResourceType
{
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rName -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force

        # Act + Assert
        Assert-ThrowsContains { Set-AzResource -ResourceGroupName $rgName -Name $rName -ResourceType "Microsoft.FakeProvider/fakeType" -Properties @{ propname = "propval" } -Force } "InvalidResourceNamespace : The resource namespace 'Microsoft.FakeProvider' is invalid."
    }
    catch
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-RemoveAzResourceByResourceName
{
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rName -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Act
        Remove-AzResource -ResourceGroupName -$rgName -Name $rName -ResourceType $resourceType -Force

        $resource = Get-AzResource -ResourceGroupName $rgName -Name $rName

        # Assert
        Assert-Null $resource
    }
    catch
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-RemoveAzResourceByResourceId
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $resourceId = "/subscriptions/$($subscriptionId)/resourceGroups/$rgName/providers/$resourceType/$rName"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceId $resourceId -Location $location -Sku @{ Name = "Standard_LRS" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Act
        Remove-AzResource -ResourceId $resourceId -Force

        $resource = Get-AzResource -ResourceGroupName $rgName -Name $rName

        # Assert
        Assert-Null $resource
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-RemoveAzResourceViaPiping
{
    $rgName = Get-ResourceGroupName
    $rName = Get-ResourceName
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rName -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        # Act
        Get-AzResource -ResourceGroupName $rgName -Name $rName | Remove-AzResource -Force

        $resource = Get-AzResource -ResourceGroupName $rgName -Name $rName

        # Assert
        Assert-Null $resource
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-RemoveAzResourceParentResourceType
{
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rNameParent -Location $location -ResourceType $resourceTypeParent -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password" } -Force
        New-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild" -Location $location -ResourceType $resourceTypeChild -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        $parentResource = Get-AzResource -ResourceGroupName $rgName -Name $rNameParent

        # Assert before remove
		Assert-NotNull $parentResource

        # Act
        $parentResource | Remove-AzResource -Force

		$resources = Get-AzResource -ResourceGroupName $rgName

        # Assert
        Assert-Null $resources
    }
    catch
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-RemoveAzResourceChildResourceType
{
    $rgName = Get-ResourceGroupName
    $rNameParent = Get-ResourceName
    $rNameChild1 = Get-ResourceName
    $rNameChild2 = Get-ResourceName
    $resourceTypeParent = "Microsoft.Sql/servers"
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName -Location $location

        New-AzResource -ResourceGroupName $rgName -Name $rNameParent -Location $location -ResourceType $resourceTypeParent -Properties @{ administratorLogin = "adminuser"; administratorLoginPassword = "Password" } -Force
        New-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild1" -Location $location -ResourceType $resourceTypeChild -Force
        New-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild2" -Location $location -ResourceType $resourceTypeChild -Force

        # Wait for the resources to be ready
        Start-TestSleep -Seconds 30

        $childResource1 = Get-AzResource -ResourceGroupName $rgName -Name $rNameChild1
        $childResource2 = Get-AzResource -ResourceGroupName $rgName -Name $rNameChild2

        # Assert before remove
		Assert-NotNull $childResource1
        Assert-NotNull $childResource2
		
        # Act
        Remove-AzResource -ResourceGroupName $rgName -Name "$rNameParent/$rNameChild1" -ResourceType $resourceTypeChild -Force
        $childResource2 | Remove-AzResource -Force

        $childResource1 = Get-AzResource -ResourceGroupName $rgName -Name $rNameChild1
	    $childResource2 = Get-AzResource -ResourceGroupName $rgName -Name $rNameChild2

        # Assert
        Assert-Null $childResource1
	    Assert-Null $childResource2
    }
    catch
    {
        Clean-ResourceGroup $rgName
    }
}

function Test-RemoveAzResourceWithWildcard
{
    $rgName1 = (Get-ResourceGroupName) + "resourcegroup1"
    $rgName2 = (Get-ResourceGroupName) + "resourcegroup2"
    $rgName3 = (Get-ResourceGroupName) + "rsrgrp3"
    $rName11 = (Get-ResourceName) + "resource11"
    $rName12 = (Get-ResourceName) + "resource12"
    $rName21 = (Get-ResourceName) + "resource2"
    $rName22 = (Get-ResourceName) + "rsr2"
    $rName31 = (Get-ResourceName) + "rsr3"
    $rName32 = (Get-ResourceName) + "resource3"
    $resourceType = "Microsoft.Storage/storageAccounts"
    $location = "eastus"

    try
    {
        # Arrange
        New-AzResourceGroup -Name $rgName1 -Location $location
        New-AzResourceGroup -Name $rgName2 -Location $location
        New-AzResourceGroup -Name $rgName3 -Location $location

        New-AzResource -ResourceGroupName $rgName1 -Name $rName11 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force
        New-AzResource -ResourceGroupName $rgName1 -Name $rName12 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force
        New-AzResource -ResourceGroupName $rgName2 -Name $rName21 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force
        New-AzResource -ResourceGroupName $rgName2 -Name $rName22 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force
        New-AzResource -ResourceGroupName $rgName3 -Name $rName31 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force
        New-AzResource -ResourceGroupName $rgName3 -Name $rName32 -Location $location -ResourceType $resourceType -Sku @{ Name = "Standard_LRS" } -Force

        # Wait for the resources to be ready
		Start-TestSleep -Seconds 30

        # Act
        Get-AzResource -Name "*rsr*" | Remove-AzResource -Force

        $resources1 = Get-AzResource -ResourceGroupName $rgName1
        $resources2 = Get-AzResource -ResourceGroupName $rgName2
        $resources3 = Get-AzResource -ResourceGroupName $rgName3
        
        # Assert
        Assert-NotNull $resources1
        Assert-AreEqual 2 @($resources1).Length

        Assert-NotNull $resources2
		Assert-AreEqual 1 @($resources2).Length

        Assert-NotNull $resources3
		Assert-AreEqual 1 @($resources3).Length

        # Act
		Get-AzResource -ResourceGroupName "*resourcegroup*" -Name "*resource*" | Remove-AzResource -Force

        $resources1 = Get-AzResource -ResourceGroupName $rgName1
        $resources2 = Get-AzResource -ResourceGroupName $rgName2
        $resources3 = Get-AzResource -ResourceGroupName $rgName3
        
        # Assert
        Assert-Null $resources1

        Assert-Null $resources2

        Assert-NotNull $resources3
		Assert-AreEqual 1 @($resources3).Length
    }
    finally
    {
        Clean-ResourceGroup $rgName1
        Clean-ResourceGroup $rgName2
        Clean-ResourceGroup $rgName3
    }
}
