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
Tests AzureRmDtlVMsPerLabPolicy
#>
function Test-AzureRmDtlVMsPerLabPolicy
{
    # Max VMs per lab policy
    $policy = Set-AzureRmDtlVMsPerLabPolicy -MaxVMs 5 -LabName $labName -ResourceGroupName $rgname
    $readBack = Get-AzureRmDtlVMsPerLabPolicy -LabName $labName -ResourceGroupName $rgname

    Invoke-For-Both $policy $readBack `
    {
        Param($x)
        Assert-AreEqual "Enabled" $x.Status
        Assert-AreEqual "5" $x.Threshold
    }
}

<#
.SYNOPSIS
Tests AzureRmDtlVMsPerUserPolicy
#>
function Test-AzureRmDtlVMsPerUserPolicy
{
    $policy = Set-AzureRmDtlVMsPerUserPolicy -MaxVMs 5 -LabName $labName -ResourceGroupName $rgname
    $readBack = Get-AzureRmDtlVMsPerUserPolicy -LabName $labName -ResourceGroupName $rgname
    Invoke-For-Both $policy $readBack `
    {
        Param($x)
        Assert-AreEqual "Enabled" $x.Status
        Assert-AreEqual "5" $x.Threshold
    }
}

<#
.SYNOPSIS
Tests AzureRmDtlAllowedVMSizesPolicy
#>
function Test-AzureRmDtlAllowedVMSizesPolicy
{
    $policy = Set-AzureRmDtlAllowedVMSizesPolicy -Enable -LabName $labName -ResourceGroupName $rgname -VmSizes Standard_A3, Standard_A0
    $readBack = Get-AzureRmDtlAllowedVMSizesPolicy -LabName $labName -ResourceGroupName $rgname
    Invoke-For-Both $policy $readBack `
    {
        Param($x)
        Assert-AreEqual "Enabled" $x.Status
        Assert-AreEqual '["Standard_A3","Standard_A0"]' $x.Threshold
    }
}

<#
.SYNOPSIS
Tests AzureRmDtlAllowedVMSizesPolicy
#>
function Test-AzureRmDtlAutoShutdownPolicy
{
    $policy = Set-AzureRmDtlAutoShutdownPolicy -Time "13:30:00" -LabName $labName -ResourceGroupName $rgname
    $readBack = Get-AzureRmDtlAutoShutdownPolicy -LabName $labName -ResourceGroupName $rgname
    Invoke-For-Both $policy $readBack `
    {
        Param($x)
        Assert-AreEqual "Enabled" $x.Status
        Assert-AreEqual "1330" $x.DailyRecurrence.Time
    }
}

<#
.SYNOPSIS
Tests AzureRmDtlAutoStartPolicy
#>
function Test-AzureRmDtlAutoStartPolicy
{
    $policy = Set-AzureRmDtlAutoStartPolicy -Time "13:30:00" -LabName $labName -ResourceGroupName $rgname
    $readBack = Get-AzureRmDtlAutoStartPolicy -LabName $labName -ResourceGroupName $rgname
    Invoke-For-Both $policy $readBack `
    {
        Param($x)
        Assert-AreEqual "Enabled" $x.Status
        Assert-AreEqual "1330" $x.WeeklyRecurrence.Time
    }

    $policy = Set-AzureRmDtlAutoStartPolicy -Time "13:30:00" -LabName $labName -ResourceGroupName $rgname -Days Monday, Tuesday
    $readBack = Get-AzureRmDtlAutoStartPolicy -LabName $labName -ResourceGroupName $rgname
    Invoke-For-Both $policy $readBack `
    {
        Param($x)
        Assert-AreEqual "Enabled" $x.Status
        Assert-AreEqual "1330" $x.WeeklyRecurrence.Time
        Assert-AreEqualArray ([System.DayOfWeek]::Monday, [System.DayOfWeek]::Tuesday) $x.WeeklyRecurrence.Weekdays
    }
}
