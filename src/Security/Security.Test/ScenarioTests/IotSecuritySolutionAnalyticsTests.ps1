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
Get Iot security analytics
#>
function Get-AzureRmIotSecurityAnalytics-SolutionScope
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$analytics = Get-AzIotSecurityAnalytics -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName
	Validate-Analytics $analytics
}

<#
.SYNOPSIS
Get Iot security analytics
#>
function Get-AzureRmIotSecurityAnalytics-SolutionLevelResource
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$analytic = Get-AzIotSecurityAnalytics -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName
	Validate-Analytic $analytic
}

<#
.SYNOPSIS
Set Iot aggregated security alerts (dismiss)
#>
function Set-AzureRmIotSecurityAnalyticsAggregatedAlerts-SolutionLevelResource
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$Name = "IoT_SucessfulLocalLogin/2020-03-15"
	Set-AzIotSecurityAnalyticsAggregatedAlerts -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName -Name $Name
}

<#
.SYNOPSIS
Get Iot aggregated security alerts
#>
function Get-AzureRmIotSecurityAnalyticsAggregatedAlerts-SolutionScope
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$analytics = Get-AzIotSecurityAnalyticsAggregatedAlerts -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName
	Validate-Analytics $analytics
}

<#
.SYNOPSIS
Get Iot aggregated security alert
#>
function Get-AzureRmIotSecurityAnalyticsAggregatedAlerts-SolutionLevelResource
{
    $ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$Name = "IoT_CryptoMiner/2020-03-15"
	$analytic = Get-AzIotSecurityAnalyticsAggregatedAlerts -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName -Name $Name
	Write-Debug $analytic
	Validate-Analytic $analytic
}

<#
.SYNOPSIS
Get Iot aggregated security recommendations
#>
function Get-AzureRmIotSecurityAnalyticsAggregatedRecommendations-SolutionScope
{
    $ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$analytics = Get-AzIotSecurityAnalyticsAggregatedRecommendations -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName
	Validate-Analytics $analytics
}

<#
.SYNOPSIS
Get Iot aggregated security recommendation
#>
function Get-AzureRmIotSecurityAnalyticsAggregatedRecommendations-SolutionLevelResource
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$Name = "iot_openports"
	$analytic = Get-AzIotSecurityAnalyticsAggregatedRecommendations -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName -Name $Name
	Validate-Analytic $analytic
}

<#
.SYNOPSIS
Validates a list of iot security solutions
#>
function Validate-Analytics
{
	param($analytics)

    Assert-NotNull $analytics

	Foreach($analytic in $analytics)
	{
		Validate-Analytic $analytic
	}
}

<#
.SYNOPSIS
Validates a single contact
#>
function Validate-Analytic
{
	param($analytic)

	Assert-NotNull $analytic
}