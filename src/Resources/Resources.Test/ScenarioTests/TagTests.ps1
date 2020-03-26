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
Utility method to test updating tags on subscription and tracked resource, including Merge, Replace, and Delete Operation.
#>
function Test-UpdateWithResourceIdParams($resourceId)
{
    # Setup
    $original = @{"key1"="value1"; "key2"="value2";}
    New-AzTag -ResourceId $resourceId -Tag $original
    Start-Sleep -s 2

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
Utility method to test Get for Tags within tracked resources and subscription.
#>
function Test-TagGetWithResourceIdParams($resourceId)
{
    # Setup
    $expected = @{"key1"="value1"; "key2"="value2";}
    New-AzTag -ResourceId $resourceId -Tag $expected
    Start-Sleep -s 2

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
    Start-Sleep -s 2

    try 
    {
        # Test
        Remove-AzTag -ResourceId $resourceId  
        Start-Sleep -s 2
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
    $rgName = "RG-Test05"
    $location = "Central US"

    $existed = Get-AzureRmResourceGroup -Name $rgName -ErrorVariable notPresent -ErrorAction SilentlyContinue

    if($notPresent) {
        $existed = New-AzureRmResourceGroup -Name $rgName -Location $location
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

    $resourceName = "RS-Test05"
    $resourceId = $rg.ResourceId + "/providers/microsoft.web/sites/" + $resourceName

    $location = "Central US"
    $property = @{test="test-tag"}
    $resourceType = "microsoft.web/sites"
    
    $existed = Get-AzureRmResource -ResourceId $resourceId -ErrorVariable notPresent -ErrorAction SilentlyContinue

    if($notPresent) {
        $existed = New-AzureRmResource -Location $location -Properties $property -ResourceName $resourceName -ResourceType $resourceType -ResourceGroupName $rg.ResourceGroupName -Force
	}
    
    return $resourceId
}

<#
.SYNOPSIS
Utility function to see if two simple hashtables equal (key is case insensitive; value is case sensitive)
#>
function AreHashtableEqual($hash1, $hash2)
{
    if($hash1 -eq $null -and $hash2 -eq $null)
    {
        return $true; 
    }
    if($hash1 -eq $null -or $hash2 -eq $null -or $hash1.Count -ne $hash2.Count)
    {
        return $false;
    }
    foreach($key in $hash1.Keys) 
    {
        if(!$hash2.ContainsKey($key))  # case insensitive
        {
            return $false;
	}
        if($hash1.$key -cne $hash2.$key)  # case sensitive
        {
            return $false;
	}
    }
    return $true;
}