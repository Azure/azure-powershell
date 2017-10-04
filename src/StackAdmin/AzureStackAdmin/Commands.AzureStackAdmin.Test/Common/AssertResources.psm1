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
.Synopsis
   Verify that the resourcegroup is deleted
#>
# TODO: Change this assertion to query on Location resposne of the delete call
function Assert-ResourceGroupDeletion
{
    param
    (
        [Parameter(Mandatory=$true)]
        [String] $ResourceGroupName,

        [String] $SubscriptionId = $Global:AzureStackConfig.SubscriptionId
    )

    Assert-Throws {Retry-Function {Get-ResourceGroup -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId} -maxTries 12 -intervalInSeconds 20}
}

<#
.Synopsis
   Verify that the resource is deleted
#>
function Assert-ResourceDeletion
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ScriptBlock] $ScriptBlock
    )

    Assert-ThrowsContains {Retry-Function {&$ScriptBlock} -maxTries 12 -intervalInSeconds 20 } -compare "ResourceNotFound"
}

<#
.Synopsis
   Verify that the subscription is deleted
#>
function Assert-SubscriptionDeletion
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ScriptBlock] $ScriptBlock
    )

    Assert-ThrowsContains {Retry-Function {&$ScriptBlock} -maxTries 12 -intervalInSeconds 20 } -compare "SubscriptionNotFound"
}


<#
.Synopsis
   Verify that the sqldatabase is deleted
#>
function Assert-SqlDatabaseDeletion
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ScriptBlock] $ScriptBlock
    )

    Assert-Throws {Retry-Function {&$ScriptBlock} -maxTries 12 -intervalInSeconds 20 }
}
