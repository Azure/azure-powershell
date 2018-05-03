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
Test Get-AzureRmApplicationInsightsApiKey
#>
function Test-GetApplicationInsightsApiKey
{
    # Setup
    $rgname = Get-ApplicationInsightsTestResourceName;

    try
    {
        # Test
		$appName = "app" + $rgname;
        $loc = Get-ProviderLocation ResourceManagement;
		$kind = "web";
        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -Location $loc -Kind $kind;
		
		$apiKeyName = "test";
		$permissions = @("ReadTelemetry", "WriteAnnotations", "AuthenticateSDKControlChannel");
		$apiKey = New-AzureRmApplicationInsightsApiKey -ResourceGroupName $rgname -Name $appName -Description $apiKeyName -Permissions $permissions;

        $apiKey2 = Get-AzureRmApplicationInsightsApiKey -ResourceGroupName $rgname -Name $appName -ApiKeyId $apiKey.Id;

        Assert-AreEqual $apiKeyName $apiKey2.Description
        Assert-NotNull $apiKey2.Id
		#we only return apikey once when it created, when doing get, it does not return back anymore.
        Assert-Null $apiKey2.ApiKey
		Assert-AreEqual 3 $apiKey2.Permissions.count

        $apiKeys = Get-AzureRmApplicationInsightsApiKey -ResourceGroupName $rgname -Name $appName;
        
		Assert-AreEqual 1 $apiKeys.count
		Assert-AreEqual $apiKeyName $apiKeys[0].Description
        Assert-NotNull $apiKeys[0].Id
		#we only return apikey once when it created, when doing get, it does not return back anymore.
        Assert-Null $apiKeys[0].ApiKey
		Assert-AreEqual 3 $apiKeys[0].Permissions.count

        Remove-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzureRmApplicationInsightsApiKey
#>
function Test-NewApplicationInsightsApiKey
{
    # Setup
    $rgname = Get-ApplicationInsightsTestResourceName;

    try
    {
        # Test
		$appName = "app" + $rgname;
        $loc = Get-ProviderLocation ResourceManagement;
		$kind = "web";
        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -Location $loc -Kind $kind;
		
		$apiKeyName = "test";
		$permissions = @("ReadTelemetry", "WriteAnnotations", "AuthenticateSDKControlChannel");
		$apiKey = New-AzureRmApplicationInsightsApiKey -ResourceGroupName $rgname -Name $appName -Description $apiKeyName -Permissions $permissions;

        Assert-AreEqual $apiKeyName $apiKey.Description
        Assert-NotNull $apiKey.Id
        Assert-NotNull $apiKey.ApiKey
		Assert-AreEqual 3 $apiKey.Permissions.count

        $apiKey2 = Get-AzureRmApplicationInsightsApiKey -ResourceGroupName $rgname -Name $appName -ApiKeyId $apiKey.Id;

        Assert-AreEqual $apiKeyName $apiKey2.Description
        Assert-NotNull $apiKey2.Id
		#we only return apikey once when it created, when doing get, it does not return back anymore.
        Assert-Null $apiKey2.ApiKey
		Assert-AreEqual 3 $apiKey2.Permissions.count

        Remove-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test Remove-AzureRmApplicationInsightsApiKey
#>
function Test-RemoveApplicationInsightsApiKey
{
    # Setup
    $rgname = Get-ApplicationInsightsTestResourceName;

    try
    {
        # Test
		$appName = "app" + $rgname;
        $loc = Get-ProviderLocation ResourceManagement;
		$kind = "web";
        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -Location $loc -Kind $kind;
		
		$apiKeyName = "test";
		$permissions = @("ReadTelemetry", "WriteAnnotations", "AuthenticateSDKControlChannel");
		$apiKey = New-AzureRmApplicationInsightsApiKey -ResourceGroupName $rgname -Name $appName -Description $apiKeyName -Permissions $permissions;

        Assert-AreEqual $apiKeyName $apiKey.Description
        Assert-NotNull $apiKey.Id
        Assert-NotNull $apiKey.ApiKey
		Assert-AreEqual 3 $apiKey.Permissions.count

        $apiKey2 = Get-AzureRmApplicationInsightsApiKey -ResourceGroupName $rgname -Name $appName -ApiKeyId $apiKey.Id;

        Assert-NotNull $apiKey2

        Remove-AzureRmApplicationInsightsApiKey -ResourceGroupName $rgname -Name $appName -ApiKeyId $apiKey.Id;

		Assert-ThrowsContains { Get-AzureRmApplicationInsightsApiKey -ResourceGroupName $rgname -Name $appName -ApiKeyId $apiKey.Id } "NotFound"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

