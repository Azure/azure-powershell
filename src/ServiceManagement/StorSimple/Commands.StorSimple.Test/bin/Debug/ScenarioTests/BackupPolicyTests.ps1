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
Sets context to default resource
#>
function Set-DefaultResource
{
    $selectedResource = Select-AzureStorSimpleResource -ResourceName OneSDK-Resource -RegistrationKey "1975530557201809476:eOqMQdvHon3lGwKVYctxZVnwpZcqi8ZS1uyCLJAl6Wg=:JovQDqP1KyWdh4m3mYkdzQ==#4edfc1cde41104e5"
}

<#
.SYNOPSIS
Tests creating new resource group and a simple resource.
#>
function Test-NewBackupPolicyAddConfig
{
    Set-DefaultResource
	$config = New-AzureStorSimpleDeviceBackupScheduleAddConfig -BackupType LocalSnapshot -RecurrenceType Daily -RecurrenceValue 1 -RetentionCount 1 -Enabled 0 -StartFromDateTime "10/23/2014 7:00 AM"
	Assert-AreEqual $config.BackupType LocalSnapshot 'BackupType doesnt match'
	Assert-AreEqual $config.Recurrence.RecurrenceType 'Daily' 'RecurrenceType doesnt match'
	Assert-AreEqual $config.Recurrence.RecurrenceValue 1 'RecurrentValue doesnt match'
	Assert-AreEqual $config.Status Disabled 'Status doesnt match'
	#Assert-AreEqual $config.StartTime 2014-10-23T07:00:00+05:30 'StartTime doesnt match'	#timezone specific test
	Assert-AreEqual $config.RetentionCount 1 'RetentionCount doesnt match'
}

function Test-NewBackupPolicyAddConfig-DefaultValues
{
    Set-DefaultResource
	$currenttime = get-date
	$config = New-AzureStorSimpleDeviceBackupScheduleAddConfig -BackupType CloudSnapshot -RecurrenceType Daily -RecurrenceValue 10 -RetentionCount 10 -Enabled 1
	$startTimeFromConfig = [datetime]::ParseExact($config.StartTime,"yyyy-MM-ddTHH:mm:sszzz",$null)
	$timespan = $startTimeFromConfig - $currenttime

	Assert-AreEqual $config.BackupType CloudSnapshot 'BackupType doesnt match'
	Assert-AreEqual $config.Recurrence.RecurrenceType 'Daily' 'RecurrenceType doesnt match'
	Assert-AreEqual $config.Recurrence.RecurrenceValue 10 'RecurrentValue doesnt match'
	Assert-AreEqual $config.Status Enabled 'Status doesnt match'
	Assert-AreEqual $config.RetentionCount 10 'RetentionCount doesnt match'
}
