
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
    Create a in-memory object for FilteringTag
    .Description
    Create a in-memory object for FilteringTag

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.FilteringTag
    .Link
    https://docs.microsoft.com/powershell/module/az.Logz/new-AzLogzFilteringTagObject
    #>
    function New-AzLogzFilteringTagObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.FilteringTag')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(HelpMessage="Valid actions for a filtering tag. Exclusion takes priority over inclusion.")]
            [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Logz.Support.TagAction])]
            [Microsoft.Azure.PowerShell.Cmdlets.Logz.Support.TagAction]
            $Action,
            [Parameter(HelpMessage="The name (also known as the key) of the tag.")]
            [string]
            $Name,
            [Parameter(HelpMessage="The value of the tag.")]
            [string]
            $Value
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.FilteringTag]::New()
    
            $Object.Action = $Action
            $Object.Name = $Name
            $Object.Value = $Value
            return $Object
        }
    }
    
