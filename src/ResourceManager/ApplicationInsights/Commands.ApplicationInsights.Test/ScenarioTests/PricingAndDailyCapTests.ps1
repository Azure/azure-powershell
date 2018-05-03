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
Test Get-AzureRmApplicationInsightsPricingPlan
#>
function Test-GetApplicationInsightsPricingPlan
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
		
        $pricingPlan = Get-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -IncludePricingPlan;

		Assert-NotNull $pricingPlan
        Assert-AreEqual "Basic" $pricingPlan.PricingPlan
        
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
Test Set-AzureRmApplicationInsightsPricingPlan
#>
function Test-SetApplicationInsightsPricingPlan
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
		
        $pricingPlan = Get-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -IncludePricingPlan;

		Assert-NotNull $pricingPlan
        Assert-AreEqual "Basic" $pricingPlan.PricingPlan
        
		$planName = "Application Insights Enterprise";
		$dailyCapGB = 300;		
		$stopSendEmail = $True;
        Set-AzureRmApplicationInsightsPricingPlan -ResourceGroupName $rgname -Name $appName -PricingPlan $planName -DailyCapGB $dailyCapGB -DisableNotificationWhenHitCap;

		$pricingPlan2 = Get-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -IncludePricingPlan;
		Assert-NotNull $pricingPlan2
        Assert-AreEqual $planName $pricingPlan2.PricingPlan
		Assert-AreEqual $dailyCapGB $pricingPlan2.Cap
		Assert-AreEqual $stopSendEmail $pricingPlan2.StopSendNotificationWhenHitCap

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
Test Get-AzureRmApplicationInsightsDailyCap
#>
function Test-GetApplicationInsightsDailyCap
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
		
        $dailyCap = Get-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -IncludePricingPlan;

		Assert-NotNull $dailyCap
        Assert-AreEqual 100 $dailyCap.Cap
		Assert-AreEqual $False $dailyCap.StopSendNotificationWhenHitCap
        
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
Test Set-AzureRmApplicationInsightsDailyCap
#>
function Test-SetApplicationInsightsDailyCap
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
		
		$dailyCapGB = 300;
		$stopSendEmail = $True;
        Set-AzureRmApplicationInsightsDailyCap -ResourceGroupName $rgname -Name $appName -DailyCapGB $dailyCapGB -DisableNotificationWhenHitCap;

		$dailyCapInfo = Get-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -IncludePricingPlan;
		Assert-NotNull $dailyCapInfo        
		Assert-AreEqual $dailyCapGB $dailyCapInfo.Cap
		Assert-AreEqual $stopSendEmail $dailyCapInfo.StopSendNotificationWhenHitCap

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
Test Get-AzureRmApplicationInsightsDailyCapStatus
#>
function Test-GetApplicationInsightsDailyCapStatus
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
		
        $dailyCapStatus = Get-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -IncludeDailyCapStatus;

		Assert-NotNull $dailyCapStatus
		Assert-AreEqual $False $dailyCapStatus.IsCapped
        
        Remove-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}