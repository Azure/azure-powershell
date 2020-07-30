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
Gets an application control VM/server group.
#>
function Get-AzSecurityAdaptiveApplicationControlGroup-ResourceGroupScope
{
    $app = Get-AzSecurityAdaptiveApplicationControlGroup -GroupName REVIEWGROUP6 -AscLocation centralus
	Validate-SecurityAdaptiveApplicationControl $app
}

<#
.SYNOPSIS
Gets a list of application control VM/server groups for the subscription.
#>
function Get-AzSecurityAdaptiveApplicationControl-SubscriptionScope
{
	$app = Get-AzSecurityAdaptiveApplicationControl
	Validate-SecurityAdaptiveApplicationControlList $app
}

<#
.SYNOPSIS
Validates a list of Adaptive Application Controls
#>
function Validate-SecurityAdaptiveApplicationControlList
{
	param($SecurityAdaptiveApplicationControl)

    Assert-True { $securityAdaptiveApplicationControl.Count -gt 0 }

	Foreach($SecurityAdaptiveApplicationControl in $securityAdaptiveApplicationControl)
	{
		Validate-SecurityAdaptiveApplicationControl $SecurityAdaptiveApplicationControl
	}
}

<#
.SYNOPSIS
Validates a single group of Adaptive Application Controls
#>
function Validate-SecurityAdaptiveApplicationControl
{
	param($SecurityAdaptiveApplicationControl)

	Assert-NotNull $SecurityAdaptiveApplicationControl
}