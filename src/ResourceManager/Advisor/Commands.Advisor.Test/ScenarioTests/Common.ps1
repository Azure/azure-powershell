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
Validates a string is not null or empty
#>
function Assert-NotNullOrEmpty
{
	param([string]$value)

	Assert-False { [string]::IsNullOrEmpty($value) }
}

<#
.SYNOPSIS
Validates an object is instance of a type
#>
function Assert-IsInstance
{
	param([object] $obj, [Type] $type)

	Assert-AreEqual $obj.GetType() $type
}

<#
.SYNOPSIS
Validates property count of a custom object
#>
function Assert-PropertiesCount
{
	param([PSCustomObject] $obj, [int] $count)

	$properties = $obj.PSObject.Properties
	Assert-AreEqual $([System.Linq.Enumerable]::ToArray($properties).Count) $count
}