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
Test Smart Group change state
#>
function Test-SmartGroupChangeState
{
	$smartGroupId = "58dd8b7e-d8d5-4589-b2d3-2ebf0ca37ebe"
	$newState = "Acknowledged"
    $updatedSmartGroup = Update-AzSmartGroupState -SmartGroupId $smartGroupId -State $newState

	Assert-AreEqual $newState, $updatedSmartGroup.State
}