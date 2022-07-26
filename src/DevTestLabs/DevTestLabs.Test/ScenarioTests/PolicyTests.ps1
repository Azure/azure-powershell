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
function Test-AzDtlVMsPerLabPolicy
{
    $rgName = Get-ResourceGroupName
    $labName = Get-ResourceName "onesdk"

    try
    {
        # Max VMs per lab policy
        $policy = Set-AzDtlVMsPerLabPolicy -MaxVMs 5 -LabName $labName -ResourceGroupName $rgName
        $readBack = Get-AzDtlVMsPerLabPolicy -LabName $labName -ResourceGroupName $rgName

        Assert-AreEqual "Enabled" $policy.Status
        Assert-AreEqual "5" $policy.Threshold

        Assert-AreEqual "Enabled" $readBack.Status
        Assert-AreEqual "5" $readBack.Threshold

    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Tests AzureRmDtlVMsPerUserPolicy
#>
function Test-AzDtlVMsPerUserPolicy
{
    $rgName = Get-ResourceGroupName
    $labName = Get-ResourceName "onesdk"

    try
    {
        $policy = Set-AzDtlVMsPerUserPolicy -MaxVMs 5 -LabName $labName -ResourceGroupName $rgName
        $readBack = Get-AzDtlVMsPerUserPolicy -LabName $labName -ResourceGroupName $rgName

        Assert-AreEqual "Enabled" $policy.Status
        Assert-AreEqual "5" $policy.Threshold

        Assert-AreEqual "Enabled" $readBack.Status
        Assert-AreEqual "5" $readBack.Threshold
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Tests AzureRmDtlAllowedVMSizesPolicy
#>
function Test-AzDtlAllowedVMSizesPolicy
{
    $rgName = Get-ResourceGroupName
    $labName = Get-ResourceName "onesdk"

    try
    {
        $policy = Set-AzDtlAllowedVMSizesPolicy -Enable -LabName $labName -ResourceGroupName $rgName -VmSizes Standard_A3, Standard_A0
        $readBack = Get-AzDtlAllowedVMSizesPolicy -LabName $labName -ResourceGroupName $rgName

        Assert-AreEqual "Enabled" $policy.Status
        Assert-AreEqual '["Standard_A3","Standard_A0"]' $policy.Threshold

        Assert-AreEqual "Enabled" $readBack.Status
        Assert-AreEqual '["Standard_A3","Standard_A0"]' $readBack.Threshold
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Tests AzureRmDtlAllowedVMSizesPolicy
#>
function Test-AzDtlAutoShutdownPolicy
{
    $rgName = Get-ResourceGroupName
    $labName = Get-ResourceName "onesdk"

    try
    {
        $policy = Set-AzDtlAutoShutdownPolicy -Time "13:30:00" -LabName $labName -ResourceGroupName $rgName
        $readBack = Get-AzDtlAutoShutdownPolicy -LabName $labName -ResourceGroupName $rgName

        Assert-AreEqual "Enabled" $policy.Status
        Assert-AreEqual "1330" $policy.DailyRecurrence.Time

        Assert-AreEqual "Enabled" $readBack.Status
        Assert-AreEqual "1330" $readBack.DailyRecurrence.Time
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Tests AzureRmDtlAutoStartPolicy
#>
function Test-AzDtlAutoStartPolicy
{
    $rgName = Get-ResourceGroupName
    $labName = Get-ResourceName "onesdk"

    try
    {
        $policy = Set-AzDtlAutoStartPolicy -Time "13:30:00" -LabName $labName -ResourceGroupName $rgName
        $readBack = Get-AzDtlAutoStartPolicy -LabName $labName -ResourceGroupName $rgName

        Assert-AreEqual "Enabled" $policy.Status
        Assert-AreEqual "1330" $policy.WeeklyRecurrence.Time

        Assert-AreEqual "Enabled" $readBack.Status
        Assert-AreEqual "1330" $readBack.WeeklyRecurrence.Time

        $policy = Set-AzDtlAutoStartPolicy -Time "13:30:00" -LabName $labName -ResourceGroupName $rgName -Days Monday, Tuesday
        $readBack = Get-AzDtlAutoStartPolicy -LabName $labName -ResourceGroupName $rgName

        Assert-AreEqual "Enabled" $policy.Status
        Assert-AreEqual "1330" $policy.WeeklyRecurrence.Time
        Assert-AreEqualArray ([System.DayOfWeek]::Monday, [System.DayOfWeek]::Tuesday) $policy.WeeklyRecurrence.Weekdays
        
        Assert-AreEqual "Enabled" $readBack.Status
        Assert-AreEqual "1330" $readBack.WeeklyRecurrence.Time
        Assert-AreEqualArray ([System.DayOfWeek]::Monday, [System.DayOfWeek]::Tuesday) $readBack.WeeklyRecurrence.Weekdays
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}
