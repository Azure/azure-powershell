# -----------------------------------------------------------------------------------
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
Tests cmdlets Invoke-AzRest
#>

function Test-InvokeAzRest
{
    $put = "PUT"
    $get = "GET"
    $patch = "PATCH"
    $delete = "DELETE"
    $api = "2019-10-01"
    $name = "mockRG4Test"

    $tag = "`{`"tags`": `{`"key`": `"val`"`}`}"
    $payload = "`{`"Location`": `"eastus`"`}"

    $response = Invoke-AzRest -ResourceGroupName $name -ApiVersion $api -Method $put -payload $payload

    Assert-AreEqual 201 $response.StatusCode
    Assert-AreEqual $put $response.Method
    Assert-NotNull $response.Content

    $response = Invoke-AzRest -ResourceGroupName $name -ApiVersion $api

    Assert-AreEqual 200 $response.StatusCode
    Assert-AreEqual $get $response.Method
    Assert-NotNull $response.Content

    $response = Invoke-AzRest -ResourceGroupName $name -ApiVersion $api -Method $patch -payload $tag

    Assert-AreEqual 200 $response.StatusCode
    Assert-AreEqual $patch $response.Method
    Assert-NotNull $response.Content

    $response = Invoke-AzRest -ResourceGroupName $name -ApiVersion $api -Method $delete

    Assert-AreEqual 202 $response.StatusCode
    Assert-AreEqual $delete $response.Method
}

<#
.SYNOPSIS
Tests Pagination for Invoke-AzRest
.DESCRIPTION
SmokeTest for Pagination
#>
function Test-InvokeAzRest-Pagination
{
    $get = "GET"
    $subscriptionId = "111111aa-a11a-1111-1aaa-1a11aa1aaa1a"
    $providerName = "Microsoft.Compute"
    $resourceType = "virtualMachines"
    $apiVersion = "2023-03-01"

    # Make the REST call using ResourceType
    $response = Invoke-AzRest `
        -SubscriptionId $subscriptionId `
        -ResourceProviderName $providerName `
        -ResourceType $resourceType `
        -ApiVersion $apiVersion `
        -Method $get `
        -FollowNextLink `
   
    Assert-NotNull $response
    Assert-NotNull $response.Content
    Assert-AreEqual 1 $response.Count

    $paginatedContent = $response.Content | ConvertFrom-Json
    Assert-AreEqual 10 $paginatedContent.value.Count

    #error scenarios
    $invalidMethods = @("PUT", "POST", "DELETE")
    foreach ($method in $invalidMethods) {
        $warnings = @()
        $WarningPreference = 'Continue'
        Invoke-AzRest `
            -SubscriptionId $subscriptionId `
            -ResourceProviderName $providerName `
            -ResourceType $resourceType `
            -ApiVersion $apiVersion `
            -Method $method `
            -FollowNextLink `
            -WarningVariable warnings `
            
        $expectedWarning = "The FollowNextLink switch is set, but the Method is not GET. Pagination will not be applied."
        if (-not ($warnings -like "*$expectedWarning*")) {
            throw "Expected warning not found: $expectedWarning Returned: $warnings instead"
        }
    }
}