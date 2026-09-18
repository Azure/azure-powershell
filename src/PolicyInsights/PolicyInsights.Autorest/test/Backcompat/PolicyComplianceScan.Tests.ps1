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

# setup the Pester environment
. (Join-Path $PSScriptRoot 'Common.ps1') 'Start-AzPolicyComplianceScan'

Describe 'Start-AzPolicyComplianceScan' {
  
    It 'SubscriptionScopeScan' {
        Assert-True { Start-AzPolicyComplianceScan -PassThru }
    }
    
    It 'SubscriptionScope-AsJob' {
        $job = Start-AzPolicyComplianceScan -PassThru -AsJob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        Assert-True { $job | Receive-Job }
    }

    It 'ResourceGroupScopeScan' {
        Assert-True { Start-AzPolicyComplianceScan -ResourceGroupName $env.firstRgName -PassThru }
    }
}