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
Tests creating new azure profile with access token
#>
function Test-StorageAccountIsNotCleaned
{
    Set-AzureSubscription -SubscriptionId 2c224e7e-3ef5-431d-a57b-e71f4662e3a6 -CurrentStorageAccount teststorage1220 
    Select-AzureSubscription -SubscriptionId 2c224e7e-3ef5-431d-a57b-e71f4662e3a6
    $subscription = Get-AzureSubscription -SubscriptionId 2c224e7e-3ef5-431d-a57b-e71f4662e3a6
    Assert-NotNull $($subscription.CurrentStorageAccountName)
}

<#
.SYNOPSIS
Tests creating new azure profile with access token
#>
function Test-GetSubscriptionPipeToSetSubscription
{
	Get-AzureSubscription -Current | Set-AzureSubscription -CurrentStorageAccount teststorage1220 
    $subscription = Get-AzureSubscription -Current
    Assert-NotNull $($subscription.CurrentStorageAccountName)
}
