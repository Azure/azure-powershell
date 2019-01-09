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
Test Get-AzureRmApplicationInsights
#>
function Test-GetApplicationInsights
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

        $app = New-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -Location $loc -Kind $kind

        Assert-AreEqual $app.Name $appName
        Assert-AreEqual $app.Kind $kind
        Assert-NotNull $app.InstrumentationKey

        $apps = Get-AzureRmApplicationInsights -ResourceGroupName $rgname;

		Assert-AreEqual $apps.count 1
        Assert-AreEqual $apps[0].Name $appName
        Assert-AreEqual $apps[0].Kind $kind
        Assert-NotNull $apps[0].InstrumentationKey

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
Test New-AzureRmApplicationInsights
#>
function Test-NewApplicationInsights
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

        $app = New-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -Location $loc -Kind $kind

        Assert-AreEqual $app.Name $appName
        Assert-AreEqual $app.Kind $kind
        Assert-NotNull $app.InstrumentationKey

        $app = Get-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName;
		
        Assert-AreEqual $app.Name $appName
        Assert-AreEqual $app.Kind $kind
        Assert-NotNull $app.InstrumentationKey

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
Test Remove-AzureRmApplicationInsights
#>
function Test-RemoveApplicationInsights
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
        New-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -Location $loc -Kind $kind

        $app = Get-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName;
		
		Assert-NotNull $app
        Assert-AreEqual $app.Name $appName
        Assert-AreEqual $app.Kind $kind
        Assert-NotNull $app.InstrumentationKey

        Remove-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName;

		Assert-ThrowsContains { Get-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName } "not found"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

