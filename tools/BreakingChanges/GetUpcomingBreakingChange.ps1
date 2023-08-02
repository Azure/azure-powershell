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

# To get upcoming breaking change info, you need to build az first
# ```powershell
# dotnet msbuild build.proj /t:build /p:configuration=Debug
# Import-Module ./tools/BreakingChanges/GetUpcomingBreakingChange.ps1
# Export-AllBreakingChangeMessageUnderArtifacts -ArtifactsPath .\artifacts\Debug\ -MarkdownPath UpcommingBreakingChange.md
# ```

$AllParameterSetsName = "AllParameterSets"

Function Test-TypeIsGenericBreakingChangeAttribute
{
    [CmdletBinding()]
    Param(
        [Parameter()]
        [System.Reflection.TypeInfo[]]
        $type
    )
    ForEach ($loopType in $type)
    {
        While ($loopType.Name -ne "Object")
        {
            If ($loopType.Name -eq "GenericBreakingChangeAttribute")
            {
                Return $True
            }
            $loopType = $loopType.BaseType
        }
    }
    Return $False
}

Function Test-TypeIsGenericBreakingChangeWithVersionAttribute
{
    [CmdletBinding()]
    Param(
        [Parameter()]
        [System.Reflection.TypeInfo[]]
        $type
    )
    ForEach ($loopType in $type)
    {
        While ($loopType.Name -ne "Object")
        {
            If ($loopType.Name -eq "GenericBreakingChangeWithVersionAttribute")
            {
                Return $True
            }
            $loopType = $loopType.BaseType
        }
    }
    Return $False
}

Function Get-AttributeSpecificMessage
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [System.Object]
        $attribute
    )
    If ($Null -ne $attribute.ChangeDescription)
    {
        $Message = $attribute.ChangeDescription
    }
    Else
    {
        # GenericBreakingChangeAttribute is the base class of the BreakingChangeAttribute classes and have a protected method named as Get-AttributeSpecIficMessage.
        # We can use this to get the specIfic message to show on document.
        $Method = $attribute.GetType().GetMethod('GetAttributeSpecificMessage', [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)

        $Message = $Method.Invoke($attribute, @()).Trim()
    }
    If (-Not ($Message.StartsWith("-")))
    {
        $Message = "- $Message"
    }
    $Message += "`n- This change is expected to take effect from version: $($attribute.DeprecateByVersion) and Az version: $($attribute.DeprecateByAzVersion)"
    Return $Message
}

# Get the breaking change info of the cmdlet Parameter.
Function Find-ParameterBreakingChange
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [System.Management.Automation.ParameterMetadata]
        $ParameterInfo
    )

    ForEach ($attribute In $ParameterInfo.Attributes)
    {
        If (Test-TypeIsGenericBreakingChangeWithVersionAttribute $attribute.TypeId)
        {
            Return Get-AttributeSpecIficMessage($attribute)
        }
    }

    Return $Null
}

# Get the breaking change info of the cmdlet.
Function Find-CmdletBreakingChange
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [System.Management.Automation.CommandInfo]
        $CmdletInfo
    )
    $Result = @{}
    #Region get breaking change info of cmdlet
    $customAttributes = $CmdletInfo.ImplementingType.GetTypeInfo().GetCustomAttributes([System.object], $true)
    ForEach ($customAttribute In $customAttributes)
    {
        If (Test-TypeIsGenericBreakingChangeWithVersionAttribute $customAttribute.TypeId)
        {
            $tmp = Get-AttributeSpecIficMessage($customAttribute)
            If (-not $Result.ContainsKey($AllParameterSetsName))
            {
                $Null = $Result.Add($AllParameterSetsName, @{
                    CmdletBreakingChange = [System.Collections.ArrayList]::New(@($tmp))
                })
            }
            ElseIf (-not $Result[$AllParameterSetsName].ContainsKey("CmdletBreakingChange"))
            {
                $Result[$AllParameterSetsName]["CmdletBreakingChange"] = [System.Collections.ArrayList]::New(@(tmp))
            }
            Else
            {
                $Null = $Result[$AllParameterSetsName]["CmdletBreakingChange"].Add($tmp)
            }
        }
    }
    #EndRegion

    #Region get breaking change info of parameters
    $ParameterBreakingChanges = @{}
    ForEach ($ParameterInfo In $CmdletInfo.Parameters.values)
    {
        $ParameterBreakingChange = Find-ParameterBreakingChange($ParameterInfo)
        If ($Null -ne $ParameterBreakingChange)
        {
            $Null = $ParameterBreakingChanges.Add($ParameterInfo.Name, $ParameterBreakingChange)
        }
    }
    If ($ParameterBreakingChanges.Count -ne 0)
    {
        If (-not $Result.ContainsKey($AllParameterSetsName))
        {
            $Null = $Result.Add($AllParameterSetsName, @{
                ParameterBreakingChange = $ParameterBreakingChanges
            })
        }
        Else
        {
            $Result[$AllParameterSetsName].Add("ParameterBreakingChange", $ParameterBreakingChanges)
        }
    }
    #EndRegion

    Return $Result
}

Function Get-BreakingChangeInfoOfModule
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [String]
        $ArtifactsPath,
        [Parameter()]
        [String]
        $ModuleName
    )
    $BreakingChangeMessages = @{}
    $ModuleRoot = [System.IO.Path]::Combine($ArtifactsPath, $ModuleName)

    #Region Generated modules
    $Dlls = Get-ChildItem -Path $ModuleRoot -Filter *.private.dll -Recurse
    ForEach ($Dll In $Dlls)
    {
        $CustomRoot = [System.IO.Path]::Combine($Dll, '..', '..', 'custom')
        $Psm1Path = Get-ChildItem -Path $CustomRoot -Filter *.psm1
        $BreakingChangeMessage = Get-BreakingChangeOfGeneratedModule -DllPath $Dll -Psm1Path $Psm1Path
        $BreakingChangeMessages += $BreakingChangeMessage
    }
    #EndRegion

    #Region SDK based modules
    If (-Not (Test-Path -Path ([System.IO.Path]::Combine($ModuleRoot, "generated"))))
    {
        $psd1Path = [System.IO.Path]::Combine($ModuleRoot, "$ModuleName.psd1")
        Import-Module $psd1Path
        $ModuleInfo = Get-Module $ModuleName
        ForEach ($cmdletInfo In $ModuleInfo.ExportedCmdlets.Values)
        {
            $cmdletBreakingChangeInfo = Find-CmdletBreakingChange($cmdletInfo)
            If ($cmdletBreakingChangeInfo.Count -ne 0)
            {
                $BreakingChangeMessages.Add($cmdletInfo.Name, $cmdletBreakingChangeInfo)
            }
        }
    }
    #EndRegion

    Return $BreakingChangeMessages
}

Function Get-BreakingChangeMessageFromGeneratedAttribute
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [Object]
        $Attribute,
        [Parameter()]
        [Object]
        $AttributeType
    )
    $StringBuilder = [System.Text.StringBuilder]::New()

    # $GetAttributeSpecificMessageMethod = $AttributeType.GetMethod('GetAttributeSpecificMessage', [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
    # $BreakingChangeMessage = $GetAttributeSpecificMessageMethod.Invoke($Attribute, @())
    # $Null = $StringBuilder.Append($BreakingChangeMessage)

    $PrintCustomAttributeInfo = [System.Action[System.String]]{
        Param([System.String] $s)
        $StringBuilder.Append($s)
    }
    $PrintCustomAttributeInfoMethod = $AttributeType.GetMethod('PrintCustomAttributeInfo', [System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Instance)
    $Null = $PrintCustomAttributeInfoMethod.Invoke($Attribute, @($PrintCustomAttributeInfo))

    Return $StringBuilder.ToString().Trim()
}

Function Get-BreakingChangeOfGeneratedModule
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [String]
        $DllPath,
        [Parameter()]
        [String]
        $Psm1Path
    )
    $AllBreakingChangeMessages = @{}

    #Region Dll
    $Dll = [Reflection.Assembly]::LoadFrom($DllPath)
    $Cmdlets = $Dll.ExportedTypes | Where-Object { $_.CustomAttributes.Attributetype.name -contains "GeneratedAttribute" }

    $BreakingChangeCmdlets = $Cmdlets | Where-Object { Test-TypeIsGenericBreakingChangeAttribute $_.CustomAttributes.Attributetype }
    ForEach ($BreakingChangeCmdlet in $BreakingChangeCmdlets)
    {
        $ParameterSetName = $BreakingChangeCmdlet.Name
        $CmdletAttribute = $BreakingChangeCmdlet.CustomAttributes | Where-Object { $_.AttributeType.Name -eq 'CmdletAttribute' }
        $Verb = $CmdletAttribute.ConstructorArguments[0].Value
        $Noun = $CmdletAttribute.ConstructorArguments[1].Value.Split('_')[0]
        $CmdletName = "$Verb-$Noun"

        $BreakingChangeAttributes = $BreakingChangeCmdlet.CustomAttributes | Where-Object { Test-TypeIsGenericBreakingChangeAttribute $_.Attributetype }
        ForEach ($BreakingChangeAttribute In $BreakingChangeAttributes)
        {
            $Attribute = $BreakingChangeAttribute.Constructor.Invoke(@($BreakingChangeAttribute.ConstructorArguments.value))
            $BreakingChangeMessage = Get-BreakingChangeMessageFromGeneratedAttribute -Attribute $Attribute -AttributeType $Attribute.GetType()

            If (-not $AllBreakingChangeMessages.ContainsKey($CmdletName))
            {
                $AllBreakingChangeMessages.Add($CmdletName, @{})
            }
            If (-not $AllBreakingChangeMessages[$CmdletName].ContainsKey($ParameterSetName))
            {
                $AllBreakingChangeMessages[$CmdletName].Add($ParameterSetName, @{
                    "CmdletBreakingChange" = [System.Collections.ArrayList]::New(@($BreakingChangeMessage))
                })
            }
            Else {
                $AllBreakingChangeMessages[$CmdletName][$ParameterSetName].Add($BreakingChangeMessage)
            }
        }
    }

    ForEach ($Cmdlet in $Cmdlets)
    {
        $ParameterBreakingChangeMessage = @{}
        $ParameterSetName = $Cmdlet.Name
        $CmdletAttribute = $Cmdlet.CustomAttributes | Where-Object { $_.AttributeType.Name -eq 'CmdletAttribute' }
        $Verb = $CmdletAttribute.ConstructorArguments[0].Value
        $Noun = $CmdletAttribute.ConstructorArguments[1].Value.Split('_')[0]
        $CmdletName = "$Verb-$Noun"

        $Parameters = $Cmdlet.DeclaredMembers | Where-Object { Test-TypeIsGenericBreakingChangeAttribute $_.CustomAttributes.Attributetype }
        ForEach ($Parameter In $Parameters)
        {
            $ParameterName = $Parameter.Name
            $ParameterAttribute = $Parameter.CustomAttributes | Where-Object { Test-TypeIsGenericBreakingChangeAttribute $_.AttributeType }
            $Attribute = $ParameterAttribute.Constructor.Invoke(@($ParameterAttribute.ConstructorArguments.value))
            $BreakingChangeMessage = Get-BreakingChangeMessageFromGeneratedAttribute -Attribute $Attribute -AttributeType $Attribute.GetType()
            $ParameterBreakingChangeMessage.Add($ParameterName, $BreakingChangeMessage)
        }
        If ($ParameterBreakingChangeMessage.Count -ne 0)
        {
            If (-not $AllBreakingChangeMessages.ContainsKey($CmdletName))
            {
                $AllBreakingChangeMessages.Add($CmdletName, @{})
            }
            If (-not $AllBreakingChangeMessages[$CmdletName].ContainsKey($ParameterSetName))
            {
                $AllBreakingChangeMessages[$CmdletName].Add($ParameterSetName, @{
                    "ParameterBreakingChange" = $ParameterBreakingChangeMessage
                })
            }
            Else {
                $AllBreakingChangeMessages[$CmdletName][$ParameterSetName].Add('ParameterBreakingChange', $ParameterBreakingChangeMessage)
            }
        }
    }
    #EndRegion

    #Region psm1
    Import-Module $Psm1Path -Force
    $ModuleName = (Get-Item $Psm1Path).BaseName
    $ModuleInfo = Get-Module $ModuleName
    $BreakingChangeCmdlets = $ModuleInfo.ExportedCommands.Values | Where-Object { Test-TypeIsGenericBreakingChangeAttribute $_.ScriptBlock.Attributes.TypeId }
    ForEach ($BreakingChangeCmdlet In $BreakingChangeCmdlets)
    {
        $CmdletName = $BreakingChangeCmdlet.Name
        $BreakingChangeAttributes = $BreakingChangeCmdlet.ScriptBlock.Attributes | Where-Object { Test-TypeIsGenericBreakingChangeAttribute $_.TypeId }
        ForEach ($BreakingChangeAttribute In $BreakingChangeAttributes)
        {
            $BreakingChangeMessage = Get-BreakingChangeMessageFromGeneratedAttribute -Attribute $BreakingChangeAttribute -AttributeType $BreakingChangeAttribute.TypeId
            If (-not $AllBreakingChangeMessages.ContainsKey($CmdletName))
            {
                $AllBreakingChangeMessages.Add($CmdletName, @{})
            }
            If (-not $AllBreakingChangeMessages[$CmdletName].ContainsKey($AllParameterSetsName))
            {
                $AllBreakingChangeMessages[$CmdletName].Add($AllParameterSetsName, @{
                    "CmdletBreakingChange" = [System.Collections.ArrayList]::New(@($BreakingChangeMessage))
                })
            }
            Else {
                $AllBreakingChangeMessages[$CmdletName][$AllParameterSetsName].Add($BreakingChangeMessage)
            }
        }
    }

    $Cmdlets = $ModuleInfo.ExportedCommands.Values
    ForEach ($Cmdlet In $Cmdlets)
    {
        $CmdletName = $Cmdlet.Name
        $ParameterBreakingChangeMessage = @{}
        $Parameters = $Cmdlet.Parameters.Values | Where-Object { Test-TypeIsGenericBreakingChangeAttribute $_.Attributes.TypeId }
        ForEach ($Parameter In $Parameters)
        {
            $ParameterName = $Parameter.Name
            $ParameterAttribute = $Parameter.Attributes | Where-Object { Test-TypeIsGenericBreakingChangeAttribute $_.TypeId }
            $BreakingChangeMessage = Get-BreakingChangeMessageFromGeneratedAttribute -Attribute $ParameterAttribute -AttributeType $ParameterAttribute.TypeId
            $ParameterBreakingChangeMessage.Add($ParameterName, $BreakingChangeMessage)
        }
        If ($ParameterBreakingChangeMessage.Count -ne 0)
        {
            If (-not $AllBreakingChangeMessages.ContainsKey($CmdletName))
            {
                $AllBreakingChangeMessages.Add($CmdletName, @{})
            }
            If (-not $AllBreakingChangeMessages[$CmdletName].ContainsKey($AllParameterSetsName))
            {
                $AllBreakingChangeMessages[$CmdletName].Add($AllParameterSetsName, @{
                    "ParameterBreakingChange" = $ParameterBreakingChangeMessage
                })
            }
            Else {
                $AllBreakingChangeMessages[$CmdletName][$AllParameterSetsName].Add('ParameterBreakingChange', $ParameterBreakingChangeMessage)
            }
        }
    }
    #EndRegion

    Return $AllBreakingChangeMessages
}

Function Merge-BreakingChangeInfoOfModule
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [HashTable]
        $ModuleBreakingChangeInfo
    )
    $Result = @{}
    ForEach ($CmdletName In $ModuleBreakingChangeInfo.Keys)
    {
        $Result[$CmdletName] = Merge-BreakingChangeInfoOfCmdlet $ModuleBreakingChangeInfo[$CmdletName]
    }

    Return $Result
}

# This function use to merge the breaking changes in all the parameter sets into key $AllParameterSetsName
# and remove them from their parameter set. Also remove the empty properties after this.
Function Merge-BreakingChangeInfoOfCmdlet
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [HashTable]
        $CmdletBreakingChangeInfo
    )
    If ($CmdletBreakingChangeInfo.ContainsKey($AllParameterSetsName))
    {
        $AllParameterSets = $CmdletBreakingChangeInfo[$AllParameterSetsName]
        $CmdletBreakingChangeInfo.Remove($AllParameterSetsName)
    }
    Else
    {
        $AllParameterSets = @{
            CmdletBreakingChange = [System.Collections.ArrayList]::New();
            ParameterBreakingChange = @{}
        }
    }
    $ParameterSets = [System.Collections.ArrayList]::New($CmdletBreakingChangeInfo.Keys)
    ForEach ($ParameterSetName In $ParameterSets)
    {
        $ParameterSetBreakingChange = $CmdletBreakingChangeInfo[$ParameterSetName]
        #Region Move the CmdletBreakingChange contains in all parameter sets to AllParameterSets
        If ($ParameterSetBreakingChange.ContainsKey("CmdletBreakingChange"))
        {
            $CmdletBreakingChanges = [System.Collections.ArrayList]::New($ParameterSetBreakingChange["CmdletBreakingChange"])
            ForEach ($CmdletBreakingChange In $CmdletBreakingChanges)
            {
                $ContainsInAllParameterSets = $True
                ForEach ($PSN In $CmdletBreakingChangeInfo.Keys)
                {
                    If ($CmdletBreakingChangeInfo[$PSN].ContainsKey("CmdletBreakingChange"))
                    {
                        If (-not $CmdletBreakingChangeInfo[$PSN]["CmdletBreakingChange"].Contains($CmdletBreakingChange))
                        {
                            $ContainsInAllParameterSets = $False
                        }
                    }
                    Else
                    {
                        $ContainsInAllParameterSets = $False
                    }
                }
                If ($ContainsInAllParameterSets)
                {
                    $Null = $AllParameterSets['CmdletBreakingChange'].Add($CmdletBreakingChange)
                    ForEach ($PSN In $CmdletBreakingChangeInfo.Keys)
                    {
                        $Null = $CmdletBreakingChangeInfo[$PSN]["CmdletBreakingChange"].Remove($CmdletBreakingChange)
                    }
                }
            }
        }
        #EndRegion

        #Region Move the ParameterBreakingChange contains in all parameter sets to AllParameterSets
        If ($ParameterSetBreakingChange.ContainsKey("ParameterBreakingChange"))
        {
            $ParameterBreakingChange = $ParameterSetBreakingChange["ParameterBreakingChange"]
            $Parameters = [System.Collections.ArrayList]::New($ParameterBreakingChange.Keys)
            ForEach ($ParameterName In $Parameters)
            {
                $ContainsInAllParameterSets = $True
                ForEach ($PSN In $CmdletBreakingChangeInfo.Keys)
                {
                    If ($CmdletBreakingChangeInfo[$PSN].ContainsKey("ParameterBreakingChange"))
                    {
                        If (-Not $CmdletBreakingChangeInfo[$PSN]["ParameterBreakingChange"].Contains($ParameterName))
                        {
                            $ContainsInAllParameterSets = $False
                        }
                        ElseIf ($CmdletBreakingChangeInfo[$PSN]["ParameterBreakingChange"][$ParameterName] -Ne $ParameterBreakingChange[$ParameterName])
                        {
                            $ContainsInAllParameterSets = $False
                        }
                    }
                    Else
                    {
                        $ContainsInAllParameterSets = $False
                    }
                }
                If ($ContainsInAllParameterSets)
                {
                    $Null = $AllParameterSets["ParameterBreakingChange"].Add($ParameterName, $ParameterBreakingChange[$ParameterName])
                    ForEach ($PSN In $CmdletBreakingChangeInfo.Keys)
                    {
                        $CmdletBreakingChangeInfo[$PSN]["ParameterBreakingChange"].Remove($ParameterName)
                    }
                }
            }
        }
        #EndRegion

        #Region Clear the empty properties
        If ($ParameterSetBreakingChange.ContainsKey("CmdletBreakingChange") -and
            $ParameterSetBreakingChange["CmdletBreakingChange"].Count -eq 0)
        {
            $Null = $ParameterSetBreakingChange.Remove("CmdletBreakingChange")
        }
        If ($ParameterSetBreakingChange.ContainsKey("ParameterBreakingChange") -and
            $ParameterSetBreakingChange["ParameterBreakingChange"].Count -eq 0)
        {
            $Null = $ParameterSetBreakingChange.Remove("ParameterBreakingChange")
        }
        If ($ParameterSetBreakingChange.Count -eq 0)
        {
            $Null = $CmdletBreakingChangeInfo.Remove($ParameterSetName)
        }
        #EndRegion
    }

    #Region Add AllParameterSets to result
    If ($AllParameterSets['CmdletBreakingChange'].Count -eq 0)
    {
        $Null = $AllParameterSets.Remove("CmdletBreakingChange")
    }
    If ($AllParameterSets['ParameterBreakingChange'].Count -eq 0)
    {
        $Null = $AllParameterSets.Remove("ParameterBreakingChange")
    }
    $CmdletBreakingChangeInfo[$AllParameterSetsName] = $AllParameterSets
    #EndRegion

    Return $CmdletBreakingChangeInfo
}

Function Export-BreakingChangeMessageOfCmdlet
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [HashTable]
        $CmdletBreakingChangeInfo
    )
    $Result = ''
    ForEach ($ParameterSetName In ($CmdletBreakingChangeInfo.Keys | Sort-Object))
    {
        If ($CmdletBreakingChangeInfo[$ParameterSetName].ContainsKey('CmdletBreakingChange'))
        {
            If ($ParameterSetName -ne $AllParameterSetsName)
            {
                $Result += "`n- Cmdlet breaking-change will happen to parameter set ``$ParameterSetName```n"
            }
            Else
            {
                $Result += "`n- Cmdlet breaking-change will happen to all parameter set`n"
            }
            ForEach ($breakingChangeMsg In $CmdletBreakingChangeInfo[$ParameterSetName]['CmdletBreakingChange'])
            {
                $Result += (("$breakingChangeMsg" -Split "`n" | ForEach-Object { Return "  $_" }) -Join "`n")
                $Result += "`n"
            }
        }
        If ($CmdletBreakingChangeInfo[$ParameterSetName].ContainsKey('ParameterBreakingChange'))
        {
            If ($ParameterSetName -eq $AllParameterSetsName)
            {
                $Result += "`n- Parameter breaking-change will happen to all parameter sets`n"
            }
            Else
            {
                $Result += "`n- Parameter breaking-change will happen to parameter set ``$ParameterSetName```n"
            }
            ForEach ($parameterName In ($CmdletBreakingChangeInfo[$ParameterSetName]['ParameterBreakingChange'].Keys | Sort-Object))
            {
                $Result += "  - ``-$parameterName```n"
                $Result += ((($CmdletBreakingChangeInfo[$ParameterSetName]['ParameterBreakingChange'][$parameterName] -Split "`n" | ForEach-Object { Return "    $_" }) -Join "`n") + "`n")
            }
        }
    }

    Return $Result
}

Function Export-BreakingChangeMessageOfModule
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [String]
        $ArtifactsPath,
        [Parameter()]
        [String]
        $ModuleName
    )
    $ModuleBreakingChangeInfo = Get-BreakingChangeInfoOfModule -ModuleName $ModuleName -ArtifactsPath $ArtifactsPath
    $ModuleBreakingChangeInfo = Merge-BreakingChangeInfoOfModule -ModuleBreakingChangeInfo $ModuleBreakingChangeInfo
    If ($ModuleBreakingChangeInfo.Count -eq 0)
    {
        Return ""
    }
    $Result = "`n## $ModuleName`n"

    ForEach ($CmdletName In ($ModuleBreakingChangeInfo.Keys | Sort-Object))
    {
        $Result += "`n### ``$CmdletName```n"
        $Result += Export-BreakingChangeMessageOfCmdlet $ModuleBreakingChangeInfo[$CmdletName]
    }

    Return $Result
}

Function Export-AllBreakingChangeMessageUnderArtifacts
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [String]
        $ArtifactsPath,
        [Parameter()]
        [String]
        $MarkdownPath
    )
    $Result = "# Upcoming breaking changes in Azure PowerShell`n"
    $AllModuleList = Get-ChildItem -Path $ArtifactsPath -Filter Az.* | ForEach-Object { $_.Name }
    ForEach ($ModuleName In $AllModuleList)
    {
        $Result += Export-BreakingChangeMessageOfModule -ArtifactsPath $ArtifactsPath -ModuleName $ModuleName
    }
    $Result | Out-File -FilePath $MarkdownPath -Force
}