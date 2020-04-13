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
Get the defualt Iot security analytics
#>
function Get-AzureRmIotSecurityAnalytics-SolutionScope-Single
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$analytics = Get-AzIotSecurityAnalytics -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName -Defualt
	Validate-Analytics $analytics
}

<#
.SYNOPSIS
Get list of all Iot security analytics
#>
function Get-AzureRmIotSecurityAnalytics-SolutionScope-List
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$analytic = Get-AzIotSecurityAnalytics -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName
	Validate-Analytic $analytic
}

<#
.SYNOPSIS
Disable Iot aggregated security alert (dismiss)
#>
function Disable-AzureRmIotSecurityAnalyticsAggregatedAlert-SolutionLevelResource
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$Name = "IoT_SucessfulLocalLogin/2020-03-15"
	Disable-AzIotSecurityAnalyticsAggregatedAlert -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName -Name $Name
}

<#
.SYNOPSIS
Disable Iot aggregated security alert (dismiss)
#>
function Disable-AzureRmIotSecurityAnalyticsAggregatedAlert-InputObject
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$Name = "IoT_SucessfulLocalLogin/2020-03-15"
	$analytic = Get-AzIotSecurityAnalyticsAggregatedAlert -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName -Name $Name
	Disable-AzIotSecurityAnalyticsAggregatedAlert -InputObject $analytic
}

<#
.SYNOPSIS
Disable Iot aggregated security alert (dismiss)
#>
function Disable-AzureRmIotSecurityAnalyticsAggregatedAlert-ResourceId
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$Name = "IoT_SucessfulLocalLogin/2020-03-15"
	$analytic = Get-AzIotSecurityAnalyticsAggregatedAlert -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName -Name $Name
	Disable-AzIotSecurityAnalyticsAggregatedAlert -ResourceId $analytic.Id
}

<#
.SYNOPSIS
Get Iot aggregated security alerts
#>
function Get-AzureRmIotSecurityAnalyticsAggregatedAlert-SolutionScope
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$analytics = Get-AzIotSecurityAnalyticsAggregatedAlert -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName
	Validate-Analytics $analytics
}

<#
.SYNOPSIS
Get Iot aggregated security alert
#>
function Get-AzureRmIotSecurityAnalyticsAggregatedAlert-SolutionLevelResource
{
    $ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$Name = "IoT_CryptoMiner/2020-03-15"
	$analytic = Get-AzIotSecurityAnalyticsAggregatedAlert -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName -Name $Name
	Validate-Analytic $analytic
}

<#
.SYNOPSIS
Get Iot aggregated security recommendations
#>
function Get-AzureRmIotSecurityAnalyticsAggregatedRecommendation-SolutionScope
{
    $ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$analytics = Get-AzIotSecurityAnalyticsAggregatedRecommendation -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName
	Validate-Analytics $analytics
}

<#
.SYNOPSIS
Get Iot aggregated security recommendation
#>
function Get-AzureRmIotSecurityAnalyticsAggregatedRecommendation-SolutionLevelResource
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$Name = "iot_openports"
	$analytic = Get-AzIotSecurityAnalyticsAggregatedRecommendation -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName -Name $Name
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