# To get upcoming breaking change info, you need to build the debug version of az first
# ```powershell
# dotnet msbuild build.proj /t:build /p:configuration=debug
# Import-Module tools/BreakingChanges/GetUpcomingBreakingChange.ps1
# Export-BreakingChangeMsg, this will create UpcommingBreakingChanges.md under current path
# ```

function Get-AttributeSpecificMessage
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [System.Object]
        $attribute
    )
    if ($attribute.ChangeDescription -ne $Null)
    {
        return $attribute.ChangeDescription
    }
    # GenericBreakingChangeAttribute is the base class of the BreakingChangeAttribute classes and have a protected method named as Get-AttributeSpecificMessage.
    # We can use this to get the specific message to show on document.
    $Method = $attribute.GetType().GetMethod('Get-AttributeSpecificMessage', [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)

    return $Method.Invoke($attribute, @())
}

# Get the breaking change info of the cmdlet parameter.
function Find-ParameterBreakingChange
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [System.Management.Automation.ParameterMetadata]
        $ParameterInfo
    )

    foreach ($attribute in $ParameterInfo.Attributes)
    {
        if ($attribute.TypeId.BaseType.Name -eq 'GenericBreakingChangeAttribute')
        {
            return Get-AttributeSpecificMessage($attribute)
        }
    }

    return $null
}

# Get the breaking change info of the cmdlet.
function Find-CmdletBreakingChange
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [System.Management.Automation.CommandInfo]
        $CmdletInfo
    )
    $Result = @{}
    $customAttributes = $CmdletInfo.ImplementingType.GetTypeInfo().GetCustomAttributes([System.object], $true)
    foreach ($customAttribute in $customAttributes)
    {
        if ($customAttribute.TypeId.BaseType.Name -eq 'GenericBreakingChangeAttribute')
        {
            $tmp = Get-AttributeSpecificMessage($customAttribute)
            $result.Add($customAttribute.TypeId.Name, $tmp)
        }
    }
    $ParameterBreakingChanges = @{}
    foreach ($parameterInfo in $CmdletInfo.Parameters.values)
    {
        $ParameterBreakingChange = Find-ParameterBreakingChange($parameterInfo)
        if ($ParameterBreakingChange -ne $null)
        {
            $ParameterBreakingChanges.Add($parameterInfo.Name, $ParameterBreakingChange)
        }
    }
    if ($ParameterBreakingChanges.Count -ne 0)
    {
        $Result.Add("Parameter", $ParameterBreakingChanges)
    }

    return $Result
}

# Get the upcoming breaking change document of the module.
function Get-ModuleBreakingChangeMsg
{
    [CmdletBinding()]
    param (
        [Parameter()]
        [String]
        $ModuleName
    )
    $psd1Path = [System.IO.Path]::Combine($PSScriptRoot, "..", "..", "artifacts", "Debug", "$ModuleName", "$ModuleName.psd1")
    Import-Module $psd1Path
    $ModuleInfo = Get-Module $ModuleName
    $Result = @{}
    foreach ($cmdletInfo in $ModuleInfo.ExportedCmdlets.Values)
    {
        $cmdletBreakingChangeInfo = Find-CmdletBreakingChange($cmdletInfo)
        if ($cmdletBreakingChangeInfo.Count -ne 0)
        {
            $Result.Add($cmdletInfo.Name, $cmdletBreakingChangeInfo)
        }
    }
    if ($Result.Count -ne 0)
    {
        $Msg = "# $ModuleName`n"
        foreach ($cmdletName in $Result.Keys)
        {
            $Msg += "`n## $cmdletName`n"
            $cmdletBreakingChangeInfo = $Result[$cmdletName]
            foreach ($key in $cmdletBreakingChangeInfo.Keys)
            {
                if ($key -ne 'Parameter')
                {
                    $Msg += $cmdletBreakingChangeInfo[$key]
                }
                else
                {
                    foreach ($parameterName in $cmdletBreakingChangeInfo['Parameter'].Keys)
                    {
                        $Msg += "### $parameterName`n"
                        $Msg += ($cmdletBreakingChangeInfo['Parameter'][$parameterName] + "`n")
                    }
                }
            }
        }
        return $Msg
    }
}

function Export-BreakingChangeMsg
{
    [CmdletBinding()]
    param ()
    $artifactsPath = [System.IO.Path]::Combine($PSScriptRoot, "..", "..", "artifacts", "Debug")
    $moduleList = (Get-ChildItem -Path $artifactsPath).Name
    $totalResult = ''
    foreach ($moduleName in $moduleList)
    {
        $msg = Get-ModuleBreakingChangeMsg($moduleName)
        if ($msg -ne $Null)
        {
            $totalResult += "`n`n$msg"
        }
    }

    $totalResult | Out-File -LiteralPath "UpcommingBreakingChanges.md"
}