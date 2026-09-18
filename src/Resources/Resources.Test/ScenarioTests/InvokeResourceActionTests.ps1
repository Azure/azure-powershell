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
Tests invoking registering resource provider action
#>
function Test-InvokeResourceActionsWithResouceId
{
    # Setup
    $rpName = "Microsoft.AwsConnector"   
    $action = "Register"
    $subId = GetDefaultSubscriptionId
    $resourceId = $subId + "/providers/" + $rpName

    try
    {
        # Test
        $res = Invoke-AzResourceAction -ResourceId $resourceId -Action $action -Force

        # Assert
        Assert-AreEqual $res.registrationState Registering
        
        do {
            $rp = Get-AzResourceProvider | Where-Object ProviderNamespace -eq $rpName

            Start-TestSleep -Seconds 10
        } while ($rp.RegistrationState -ne "Registered")
        
        Assert-AreEqual $rp.RegistrationState Registered
    }
    finally
    {
        # Cleanup
        Unregister-AzResourceProvider -ProviderNamespace $rpName
    } 
}

<#
.SYNOPSIS
utility method to get default subscriptionId
#>
function GetDefaultSubscriptionId
{
    $context = Get-AzContext
    $subId = "/subscriptions/" + $context.Subscription.Id

    return $subId
}
