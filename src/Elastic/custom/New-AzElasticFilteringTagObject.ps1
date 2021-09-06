
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
    Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.FilteringTag
    .Link
    https://docs.microsoft.com/powershell/module/az.Elastic/new-AzElasticFilteringTagObject
    #>
    function New-AzElasticFilteringTagObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.FilteringTag')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(HelpMessage="Valid actions for a filtering tag.")]
            [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Elastic.Support.TagAction])]
            [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Support.TagAction]
            $Action,
            [Parameter(HelpMessage="The name (also known as the key) of the tag.")]
            [string]
            $Name,
            [Parameter(HelpMessage="The value of the tag.")]
            [string]
            $Value
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.FilteringTag]::New()
    
            $Object.Action = $Action
            $Object.Name = $Name
            $Object.Value = $Value
            return $Object
        }
    }
    
