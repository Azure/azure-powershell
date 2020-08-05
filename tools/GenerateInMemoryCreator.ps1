
function New-InMemoryObjectScriptCreator {
    Param(
        [Parameter(Mandatory, HelpMessage="Path of the generated cs file.")]
        [string]
        $CsPath,
        [Parameter(HelpMessage="Output folder of generated .ps1 file. Default value is .\custom.")]
        [string]
        $OutputDir,
        [Parameter(HelpMessage="Module name of the generated cmdlet. Default value is the name of current folder.")]
        [string]
        $ModuleName
    )

    if (($null -eq $OutputDir) -or ("" -eq $OutputDir)) {
        $OutputDir = '.\custom'
    }
    if (($null -eq $ModuleName) -or ("" -eq $ModuleName)) {
        $ModuleName = (Get-Item -Path ".\").Name
    }

    $Content = Get-Content $CsPath -Raw
    $Tree = [Microsoft.CodeAnalysis.CSharp.SyntaxFactory]::ParseCompilationUnit($Content)
    $Nodes = $Tree.ChildNodes().ChildNodes()
    
    $InterfaceNode = $Nodes | Where-Object { ($_.Keyword.value -eq 'interface') -and (-not $_.Identifier.value.Contains("Internal")) }
    $ClassNode = $Nodes | Where-Object { ($_.Keyword.value -eq 'class') }

    $Namespace = $Tree.Members.Name
    $ObjectType = $ClassNode.Identifier.Value
    $ObjectTypeWithNamespace = "${Namespace}.${ObjectType}"
    $OutputPath = Join-Path -ChildPath "New-Az${ModuleName}${ObjectType}Object.ps1" -Path $OutputDir

    $ParameterDefineScriptList = New-Object System.Collections.Generic.List[string]
    $ParameterAssignScriptList = New-Object System.Collections.Generic.List[string]

    foreach ($Member in $InterfaceNode.Members) {
        $Arguments = $Member.AttributeLists.Attributes.ArgumentList.Arguments
        $Required = $false
        $Description = ""
        $Readonly = $False
        foreach ($Argument in $Arguments) {
            if ($Argument.NameEquals.Name.Identifier.Value -eq "Required") {
                $Required = $Argument.Expression.Token.Value
            }
            if ($Argument.NameEquals.Name.Identifier.Value -eq "Description") {
                $Description = $Argument.Expression.Token.Value.Trim('.').replace('"', '`"')
            }
            if ($Argument.NameEquals.Name.Identifier.Value -eq "Readonly") {
                $Readonly = $Argument.Expression.Token.Value
            }
        }
        if ($Readonly) {
            continue
        }
        $Identifier = $Member.Identifier.Value
        $Type = $Member.Type.ToString().replace('?', '')
        $ParameterDefinePropertyList = New-Object System.Collections.Generic.List[string]
        if ($Required) {
            $ParameterDefinePropertyList.Add("Mandatory")
        }
        if ($Description -ne "") {
            $ParameterDefinePropertyList.Add("HelpMessage=`"${Description}.`"")
        }
        $ParameterDefineProperty = [System.String]::Join(", ", $ParameterDefinePropertyList)
        $ParameterDefineScript = "
        [Parameter($ParameterDefineProperty)]
        [${Type}]
        `$${Identifier}"
        $ParameterDefineScriptList.Add($ParameterDefineScript)
        $ParameterAssignScriptList.Add("
        `$Object.${Identifier} = `$${Identifier}")
    }

    $ParameterDefineScript = $ParameterDefineScriptList | Join-String -Separator ","
    $ParameterAssignScript = $ParameterAssignScriptList | Join-String -Separator ""

    $Script = "
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the \`"License\`");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an \`"AS IS\`" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for ${ObjectType}
.Description
Create a in-memory object for ${ObjectType}

.Outputs
${ObjectTypeWithNamespace}
.Link
https://docs.microsoft.com/en-us/powershell/module/az.${ModuleName}/new-Az${ModuleName}${ObjectType}Object
#>
function New-Az${ModuleName}${ObjectType}Object {
    [OutputType('${ObjectTypeWithNamespace}')]
    [CmdletBinding(PositionalBinding=`$false)]
    Param(
${ParameterDefineScript}
    )

    process {
        `$Object = [${ObjectTypeWithNamespace}]::New()
${ParameterAssignScript}
        return `$Object
    }
}
"
    Set-Content -Path $OutputPath -Value $Script
}

# Export-ModuleMember New-InMemoryObjectScriptCreator