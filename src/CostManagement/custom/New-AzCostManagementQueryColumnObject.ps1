
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the \"License\");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an \"AS IS\" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for QueryColumn
.Description
Create a in-memory object for QueryColumn

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryColumn
.Link
https://docs.microsoft.com/en-us/powershell/module/az.CostManagement/new-AzCostManagementQueryColumnObject
#>
function New-AzCostManagementQueryColumnObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryColumn')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="The name of column.")]
        [string]
        $Name,
        [Parameter(HelpMessage="The type of column.")]
        [string]
        $Type
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryColumn]::New()

        $Object.Name = $Name
        $Object.Type = $Type
        return $Object
    }
}

