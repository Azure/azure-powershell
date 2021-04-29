function GetAttributeSpecificMessage
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
    $Method = $attribute.GetType().GetMethod('GetAttributeSpecificMessage', [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)

    return $Method.Invoke($attribute, @())
}

function DetectParameterBreakingChange
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
            return GetAttributeSpecificMessage($attribute)
        }
    }

    return $null
}

function DetectCmdletBreakingChange
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
            $tmp = GetAttributeSpecificMessage($customAttribute)
            $result.Add($customAttribute.TypeId.Name, $tmp)
        }
    }
    $ParameterBreakingChanges = @{}
    foreach ($parameterInfo in $CmdletInfo.Parameters.values)
    {
        $ParameterBreakingChange = DetectParameterBreakingChange($parameterInfo)
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
        $cmdletBreakingChangeInfo = DetectCmdletBreakingChange($cmdletInfo)
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