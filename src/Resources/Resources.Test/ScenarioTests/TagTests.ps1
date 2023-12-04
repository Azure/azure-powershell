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
Utility method to test CreeteOrUpdate for Tags within tracked resources and subscription.
#>
function Test-TagCreateOrUpdateWithResourceIdParams($resourceId)
{
    # Setup
    $expected = @{"key1"="value1"; "key2"="value2";}

    try
    {
        # Test
        $res = New-AzTag -ResourceId $resourceId -Tag $expected
        [hashtable]$actual = $res.Properties.TagsProperty

        # Assert
        Assert-True { AreHashtableEqual $expected $actual }
    }
    finally
    {
        # Cleanup
        Remove-AzTag -ResourceId $resourceId
    } 
}

<#
.SYNOPSIS
Tests creating or updating tags on subscription.
#>
function Test-TagCreateOrUpdateWithResourceIdParamsForSubscription
{
    # Setup
    $resourceId = GetDefaultSubscriptionId

    Test-TagCreateOrUpdateWithResourceIdParams $resourceId  
}

<#
.SYNOPSIS
Tests creating or updating tags on tracked resource.
#>
function Test-TagCreateOrUpdateWithResourceIdParamsForResource
{
    # Setup
    $resourceId = NewTestResource

    Test-TagCreateOrUpdateWithResourceIdParams $resourceId
}

<#
.SYNOPSIS
Utility method to test async CreateOrUpdate for Tags within tracked resources and subscription.
#>
function Test-TagCreateOrUpdateAsyncWithResourceIdParams($resourceId)
{
    # Setup
    $expected = @{"key1"="value1"; "key2"="value2";}

    try
    {
        # Test
        $newTagres = New-AzTag -ResourceId $resourceId -Tag $expected
        Start-TestSleep -Seconds 120
        $res = Get-AzTag -ResourceId $resourceId
        
        [hashtable]$actual = $res.Properties.TagsProperty
        Assert-True { AreHashtableEqual $expected $actual }
    }
    finally
    {
        # Cleanup
        Remove-AzTag -ResourceId $resourceId
    } 
}

<#
.SYNOPSIS
Tests creating or updating tags on tracked resource.
#>
function Test-TagCreateOrUpdateAsyncWithResourceIdParamsForResource
{
    # Setup
    $resourceId = NewTestResourcePurviewAccount

    Test-TagCreateOrUpdateAsyncWithResourceIdParams $resourceId
}


<#
.SYNOPSIS
Utility method to test updating tags on subscription and tracked resource, including Merge, Replace, and Delete Operation.
#>
function Test-UpdateWithResourceIdParams($resourceId)
{
    # Setup
    $original = @{"key1"="value1"; "key2"="value2";}
    New-AzTag -ResourceId $resourceId -Tag $original
    Start-TestSleep -Seconds 2

    try
    {
        # Test
        {
            # merge operation
            $merged = @{"key1"="value1"; "key3"="value3";}
            $res = Update-AzTag -ResourceId $resourceId -Tag $merged -Operation Merge

            $expected = @{"key1"="value1"; "key2"="value2"; "key3"="value3";}
            [hashtable]$actual = $res.Properties.TagsProperty

            # Assert
            Assert-True { AreHashtableEqual $expected $actual }
        }

        {
            # repalce operation
            $replaced = @{"key1"="value1"; "key3"="value3";}
            $res = Update-AzTag -ResourceId $resourceId -Tag $replaced -Operation Replace

            $expected = $replaced
            [hashtable]$actual = $res.Properties.TagsProperty

            # Assert
            Assert-True { AreHashtableEqual $expected $actual }
        }

        {
            # delete operation
            $deleted = @{"key1"="value1"; "key3"="value3";}
            $res = Update-AzTag -ResourceId $resourceId -Tag $deleted -Operation Delete

            $expected = null
            [hashtable]$actual = $res.Properties.TagsProperty

            # Assert
            Assert-True { AreHashtableEqual $expected $actual }
        }
    }
    finally
    {
        # Cleanup
        Remove-AzTag -ResourceId $resourceId
    } 
}

<#
.SYNOPSIS
Tests updating tags on subscription.
#>
function Test-TagUpdateWithResourceIdParamsForSubscription
{
    # Setup
    $resourceId = GetDefaultSubscriptionId

    Test-UpdateWithResourceIdParams $resourceId
}

<#
.SYNOPSIS
Tests updating tags on tracked resource.
#>
function Test-TagUpdateWithResourceIdParamsForResource
{
    # Setup
    $resourceId = NewTestResource

    Test-UpdateWithResourceIdParams $resourceId
}

<#
.SYNOPSIS
Utility method to test async updating tags on subscription and tracked resource, including Merge, Replace, and Delete Operation.
#>
function Test-UpdateAsyncWithResourceIdParams($resourceId)
{
    # Setup
    $original = @{"key1"="value1"; "key2"="value2";}
    New-AzTag -ResourceId $resourceId -Tag $original
    Start-TestSleep -Seconds 120

    try
    {
        # Test
        {
            # merge operation
            $merged = @{"key1"="value1"; "key3"="value3";}
            $res = Update-AzTag -ResourceId $resourceId -Tag $merged -Operation Merge
            Start-TestSleep -Seconds 120
    
            $expected = @{"key1"="value1"; "key2"="value2"; "key3"="value3";}
            [hashtable]$actual = $res.Properties.TagsProperty

            # Assert
            Assert-True { AreHashtableEqual $expected $actual }
        }

        {
            # replace operation
            $replaced = @{"key1"="value1"; "key3"="value3";}
            $res = Update-AzTag -ResourceId $resourceId -Tag $replaced -Operation Replace
            Start-TestSleep -Seconds 120

            $expected = $replaced
            [hashtable]$actual = $res.Properties.TagsProperty

            # Assert
            Assert-True { AreHashtableEqual $expected $actual }
        }

        {
            # delete operation
            $deleted = @{"key1"="value1"; "key3"="value3";}
            $res = Update-AzTag -ResourceId $resourceId -Tag $deleted -Operation Delete
            Start-TestSleep -Seconds 120

            $expected = null
            [hashtable]$actual = $res.Properties.TagsProperty

            # Assert
            Assert-True { AreHashtableEqual $expected $actual }
        }
    }
    finally
    {
        # Cleanup
        Remove-AzTag -ResourceId $resourceId
    } 
}

<#
.SYNOPSIS
Tests async updating tags on tracked resource.
#>
function Test-TagUpdateAsyncWithResourceIdParamsForResource
{
    # Setup
    $resourceId = NewTestResourcePurviewAccount

    Test-UpdateAsyncWithResourceIdParams $resourceId
}

<#
.SYNOPSIS
Utility method to test Get for Tags within tracked resources and subscription.
#>
function Test-TagGetWithResourceIdParams($resourceId)
{
    # Setup
    $expected = @{"key1"="value1"; "key2"="value2";}
    New-AzTag -ResourceId $resourceId -Tag $expected
    Start-TestSleep -Seconds 2

    try
    {
        # Test
        $res = Get-AzTag -ResourceId $resourceId
        [hashtable]$actual = $res.Properties.TagsProperty

        # Assert
        Assert-True { AreHashtableEqual $expected $actual }
    }
    finally
    {
        # Cleanup
        Remove-AzTag -ResourceId $resourceId
    } 
}

<#
.SYNOPSIS
Tests getting tags on subscription.
#>
function Test-TagGetWithResourceIdParamsForSubscription
{
    # Setup
    $resourceId = GetDefaultSubscriptionId

    Test-TagGetWithResourceIdParams $resourceId   
}

<#
.SYNOPSIS
Tests getting tags on tracked resource.
#>
function Test-TagGetWithResourceIdParamsForResource
{
    # Setup
    $resourceId = NewTestResource

    Test-TagGetWithResourceIdParams $resourceId
}

<#
.SYNOPSIS
Utility method to test Delete for Tags within tracked resources and subscription.
#>
function Test-TagDeleteWithResourceIdParams($resourceId)
{
    # Setup
    $original = @{"key1"="value1"; "key2"="value2";}
    New-AzTag -ResourceId $resourceId -Tag $original
    Start-TestSleep -Seconds 2

    try 
    {
        # Test
        Remove-AzTag -ResourceId $resourceId  
        Start-TestSleep -Seconds 2
        $actual = Get-AzTag -ResourceId $resourceId

        # Assert
        Assert-AreEqual $actual.Properties.TagsProperty.Count 0
    }
    finally
    {
        # Cleanup
        Remove-AzTag -ResourceId $resourceId
    }        
}

<#
.SYNOPSIS
Tests getting tags on subscription.
#>
function Test-TagDeleteWithResourceIdParamsForSubscription
{
    # Setup
    $resourceId = GetDefaultSubscriptionId

    Test-TagDeleteWithResourceIdParams $resourceId
}

<#
.SYNOPSIS
Tests getting tags on tracked resource.
#>
function Test-TagDeleteWithResourceIdParamsForResource
{
    # Setup
    $resourceId = NewTestResource

    Test-TagDeleteWithResourceIdParams $resourceId
}

<#
.SYNOPSIS
Utility method to test Delete for Tags within tracked resources and subscription.
#>
function Test-TagDeleteAsyncWithResourceIdParams($resourceId)
{
    # Setup
    $original = @{"key1"="value1"; "key2"="value2";}
    New-AzTag -ResourceId $resourceId -Tag $original
    Start-TestSleep -Seconds 120

    try 
    {
        # Test
        Remove-AzTag -ResourceId $resourceId  
        Start-TestSleep -Seconds 120
        $actual = Get-AzTag -ResourceId $resourceId

        # Assert
        Assert-AreEqual $actual.Properties.TagsProperty.Count 0
    }
    finally
    {
        # Cleanup
        Remove-AzTag -ResourceId $resourceId
    }        
}

<#
.SYNOPSIS
Tests getting tags on tracked resource.
#>
function Test-TagDeleteAsyncWithResourceIdParamsForResource
{
    # Setup
    $resourceId = NewTestResourcePurviewAccount

    Test-TagDeleteAsyncWithResourceIdParams $resourceId
}

<#
.SYNOPSIS
utility method to get default subscriptionId
#>
function GetDefaultSubscriptionId
{
    $context = Get-AzContext
    $subId = "/subscriptions/" + $context.Subscription.Id

    return $subId
}

<#
.SYNOPSIS
utility method to create resource group
#>
function NewTestResourceGroup
{
    $rgName = Get-ResourceGroupName
    $location = "Central US"

    $existed = Get-AzResourceGroup -Name $rgName -ErrorVariable notPresent -ErrorAction SilentlyContinue

    if($notPresent) {
        $existed = New-AzResourceGroup -Name $rgName -Location $location
	}
  
    return $existed
}

<#
.SYNOPSIS
utility method to create resource
#>
function NewTestResource
{
    $rg = NewTestResourceGroup

    $resourceName = Get-ResourceName
    $resourceId = $rg.ResourceId + "/providers/microsoft.web/sites/" + $resourceName

    $location = "West Central US"
    $property = @{test="test-tag"}
    $resourceType = "microsoft.web/sites"
    
    $existed = Get-AzResource -ResourceId $resourceId -ErrorVariable notPresent -ErrorAction SilentlyContinue

    if($notPresent) {
        $existed = New-AzResource -Location $location -Properties $property -ResourceName $resourceName -ResourceType $resourceType -ResourceGroupName $rg.ResourceGroupName -Force
	}
    
    return $resourceId
}

<#
.SYNOPSIS
utility method to creare resource
#>
function NewTestResourcePurviewAccount
{
    $rg = NewTestResourceGroup
    $resourceName = Get-ResourceName
    $resourceId = $rg.ResourceId + "/providers/Microsoft.Purview/accounts/" + $resourceName

    $location = "westus"
    $property = @{test="test-tag"}
    $resourceType = "microsoft.purview/accounts"

    $existed = Get-AzResource -ResourceId $resourceId -ErrorVariable notPresent -ErrorAction SilentlyContinue
    if ($notPresent) {
        $existed = New-AzPurviewAccount -Name $resourceName -ResourceGroupName $rg.ResourceGroupName -IdentityType SystemAssigned -Location $location -Tag $property -SkuCapacity 4 -SkuName Standard
    }

    return $resourceId
}