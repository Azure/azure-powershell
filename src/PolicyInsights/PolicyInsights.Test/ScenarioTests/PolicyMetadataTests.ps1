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
Lists all policy metadata resources
#>
function PolicyMetadata-ListAll
{
   Get-AzPolicyMetadata | ForEach-Object {
      Validate-PolicyMetadata $_
   }
}

<#
.SYNOPSIS
Lists top 10 policy metadata resources
#>
function PolicyMetadata-ListTop
{
   $metadata = Get-AzPolicyMetadata -Top 10
   Assert-AreEqual 10 $metadata.Count

   $metadata | ForEach-Object {
      Validate-PolicyMetadata $_
   }
}

<#
.SYNOPSIS
Gets a single policy metadata resource by name
#>
function PolicyMetadata-GetNamedResource
{
   $metadata = Get-AzPolicyMetadata -Name ACF1348
   Validate-PolicyMetadata $metadata -validateExtendedProperties:$true
}