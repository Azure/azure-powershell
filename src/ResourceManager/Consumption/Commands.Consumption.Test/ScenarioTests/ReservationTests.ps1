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

# Instructions of recording tests
# Recording of reservation related tests requires a subscription with
# reserved instances. You can create them and find reservation order id
# and reservation id from Azure portal. For any recording question, 
# please contact Prem.Prakash@microsoft.com

<#
.SYNOPSIS
List monthly reservation summaries with reservation order Id
#>
function Test-ListReservationSummariesMonthlyWithOrderId
{
    $reservationSummaries = Get-AzureRmConsumptionReservationSummary -Grain monthly -ReservationOrderId ca69259e-bd4f-45c3-bf28-3f353f9cce9b
	Assert-NotNull $reservationSummaries	
	Foreach($reservationSummary in $reservationSummaries)
	{
		Assert-NotNull $reservationSummary.AveUtilizationPercentage
		Assert-NotNull $reservationSummary.Id
		Assert-NotNull $reservationSummary.MaxUtilizationPercentage
		Assert-NotNull $reservationSummary.MinUtilizationPercentage
		Assert-NotNull $reservationSummary.Name
		Assert-NotNull $reservationSummary.ReservationId
		Assert-NotNull $reservationSummary.ReservationOrderId
		Assert-NotNull $reservationSummary.ReservedHour
		Assert-NotNull $reservationSummary.SkuName
		Assert-NotNull $reservationSummary.Type
		Assert-NotNull $reservationSummary.UsageDate
		Assert-NotNull $reservationSummary.UsedHour
	}
}

<#
.SYNOPSIS
List monthly reservation summaries with reservation order Id and reservation Id
#>
function Test-ListReservationSummariesMonthlyWithOrderIdAndId
{
    $reservationSummaries = Get-AzureRmConsumptionReservationSummary -Grain monthly -ReservationOrderId ca69259e-bd4f-45c3-bf28-3f353f9cce9b -ReservationId f37f4b70-52ba-4344-a8bd-28abfd21d640
	Assert-NotNull $reservationSummaries	
	Foreach($reservationSummary in $reservationSummaries)
	{
		Assert-NotNull $reservationSummary.AveUtilizationPercentage
		Assert-NotNull $reservationSummary.Id
		Assert-NotNull $reservationSummary.MaxUtilizationPercentage
		Assert-NotNull $reservationSummary.MinUtilizationPercentage
		Assert-NotNull $reservationSummary.Name
		Assert-NotNull $reservationSummary.ReservationId
		Assert-NotNull $reservationSummary.ReservationOrderId
		Assert-NotNull $reservationSummary.ReservedHour
		Assert-NotNull $reservationSummary.SkuName
		Assert-NotNull $reservationSummary.Type
		Assert-NotNull $reservationSummary.UsageDate
		Assert-NotNull $reservationSummary.UsedHour
	}
}

<#
.SYNOPSIS
List daily reservation summaries with reservation order Id
#>
function Test-ListReservationSummariesDailyWithOrderId
{
    $reservationSummaries = Get-AzureRmConsumptionReservationSummary -Grain daily -ReservationOrderId ca69259e-bd4f-45c3-bf28-3f353f9cce9b -StartDate 2017-10-01 -EndDate 2017-12-07
	Assert-NotNull $reservationSummaries	
	Foreach($reservationSummary in $reservationSummaries)
	{
		Assert-NotNull $reservationSummary.AveUtilizationPercentage
		Assert-NotNull $reservationSummary.Id
		Assert-NotNull $reservationSummary.MaxUtilizationPercentage
		Assert-NotNull $reservationSummary.MinUtilizationPercentage
		Assert-NotNull $reservationSummary.Name
		Assert-NotNull $reservationSummary.ReservationId
		Assert-NotNull $reservationSummary.ReservationOrderId
		Assert-NotNull $reservationSummary.ReservedHour
		Assert-NotNull $reservationSummary.SkuName
		Assert-NotNull $reservationSummary.Type
		Assert-NotNull $reservationSummary.UsageDate
		Assert-NotNull $reservationSummary.UsedHour
	}
}

<#
.SYNOPSIS
List daily reservation summaries with reservation order Id and reservation Id
#>
function Test-ListReservationSummariesDailyWithOrderIdAndId
{
    $reservationSummaries = Get-AzureRmConsumptionReservationSummary -Grain daily -ReservationOrderId ca69259e-bd4f-45c3-bf28-3f353f9cce9b -ReservationId f37f4b70-52ba-4344-a8bd-28abfd21d640 -StartDate 2017-10-01 -EndDate 2017-12-07
	Assert-NotNull $reservationSummaries	
	Foreach($reservationSummary in $reservationSummaries)
	{
		Assert-NotNull $reservationSummary.AveUtilizationPercentage
		Assert-NotNull $reservationSummary.Id
		Assert-NotNull $reservationSummary.MaxUtilizationPercentage
		Assert-NotNull $reservationSummary.MinUtilizationPercentage
		Assert-NotNull $reservationSummary.Name
		Assert-NotNull $reservationSummary.ReservationId
		Assert-NotNull $reservationSummary.ReservationOrderId
		Assert-NotNull $reservationSummary.ReservedHour
		Assert-NotNull $reservationSummary.SkuName
		Assert-NotNull $reservationSummary.Type
		Assert-NotNull $reservationSummary.UsageDate
		Assert-NotNull $reservationSummary.UsedHour
	}
}

<#
.SYNOPSIS
List reservation details with reservation order Id
#>
function Test-ListReservationDetailsWithOrderId
{
    $reservationDetails = Get-AzureRmConsumptionReservationDetail -ReservationOrderId ca69259e-bd4f-45c3-bf28-3f353f9cce9b -StartDate 2017-10-01 -EndDate 2017-12-07
	Assert-NotNull $reservationDetails	
	Foreach($reservationDetail in $reservationDetails)
	{
		Assert-NotNull $reservationDetail.Id
		Assert-NotNull $reservationDetail.InstanceId
		Assert-NotNull $reservationDetail.Name
		Assert-NotNull $reservationDetail.ReservationId
		Assert-NotNull $reservationDetail.ReservationOrderId
		Assert-NotNull $reservationDetail.ReservedHour
		Assert-NotNull $reservationDetail.SkuName
		Assert-NotNull $reservationDetail.TotalReservedQuantity
		Assert-NotNull $reservationDetail.Type
		Assert-NotNull $reservationDetail.UsageDate
		Assert-NotNull $reservationDetail.UsedHour
	}
}

<#
.SYNOPSIS
List reservation details with reservation order Id and reservation Id
#>
function Test-ListReservationDetailsWithOrderIdAndId
{
    $reservationDetails = Get-AzureRmConsumptionReservationDetail -ReservationOrderId ca69259e-bd4f-45c3-bf28-3f353f9cce9b -ReservationId f37f4b70-52ba-4344-a8bd-28abfd21d640 -StartDate 2017-10-01 -EndDate 2017-12-07
	Assert-NotNull $reservationDetails	
	Foreach($reservationDetail in $reservationDetails)
	{
		Assert-NotNull $reservationDetail.Id
		Assert-NotNull $reservationDetail.InstanceId
		Assert-NotNull $reservationDetail.Name
		Assert-NotNull $reservationDetail.ReservationId
		Assert-NotNull $reservationDetail.ReservationOrderId
		Assert-NotNull $reservationDetail.ReservedHour
		Assert-NotNull $reservationDetail.SkuName
		Assert-NotNull $reservationDetail.TotalReservedQuantity
		Assert-NotNull $reservationDetail.Type
		Assert-NotNull $reservationDetail.UsageDate
		Assert-NotNull $reservationDetail.UsedHour
	}
}