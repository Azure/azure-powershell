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
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolution -Name $SolutionName -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs
	$analytics = Get-AzIotSecurityAnalytics -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName -Default
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
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolution -Name $SolutionName -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs
	$analytic = Get-AzIotSecurityAnalytics -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName
	Validate-Analytic $analytic
}

<#
.SYNOPSIS
Get Iot aggregated security alerts
#>
function Get-AzureRmIotSecurityAnalyticsAggregatedAlert-SolutionScope
{
	$ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolution -Name $SolutionName -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs
	$analytics = Get-AzIotSecurityAnalyticsAggregatedAlert -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName
	Validate-Analytics $analytics
}

<#
.SYNOPSIS
Get Iot aggregated security recommendations
#>
function Get-AzureRmIotSecurityAnalyticsAggregatedRecommendation-SolutionScope
{
    $ResourceGroupName = "MichalResourceGroup"
	$SolutionName = "MichalDemoHub"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolution -Name $SolutionName -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs
	$analytics = Get-AzIotSecurityAnalyticsAggregatedRecommendation -ResourceGroupName $ResourceGroupName -SolutionName $SolutionName
	Validate-Analytics $analytics
}

<#
.SYNOPSIS
Validates a list of iot security solutions
#>
function Validate-Analytics
{
	param($analytics)
	
    if ($analytics -ne $null)
	{
		Foreach($analytic in $analytics)
		{
			Validate-Analytic $analytic
		}
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