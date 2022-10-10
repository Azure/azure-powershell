<#
    .SYNOPSIS
    Custom rule for parameter name and value.
    .NOTES
    File: ParameterNameAndValue.psm1
    Import-Module should be at the beginning of the rule to avoid thread conflict.
#>
Get-Item "$PSScriptRoot\..\..\..\..\artifacts\Debug\Az.*\Az.*.psd1" | Import-Module -Global

. $PSScriptRoot\..\utils.ps1

enum RuleNames {
    Unknown_Parameter_Set
    Invalid_Parameter_Name
    Duplicate_Parameter_Name
    Unassigned_Parameter
    Unassigned_Variable
    Unbinded_Expression
    Mismatched_Parameter_Value_Type
}

$global:UtilityOutputTypePair = @{"ConvertTo-Json" = [string]; "ConvertFrom-Json" = [hashtable]}

<#
    .SYNOPSIS
    Gets the actual name of the parameter, not alias.
#>
function Get-ParameterNameNotAlias {
    param (
        [System.Management.Automation.CommandInfo]$GetCommand,
        [string]$ParameterName
    )

    return ($GetCommand.Parameters.Values | Where-Object {
        $ParameterName -in @($_.Name) + @($_.Aliases)
    }).Name
}

<#
    .SYNOPSIS
    Gets the final actual value from ast.
#>
function Get-FinalVariableValue {
    param([System.Management.Automation.Language.Ast]$CommandElementAst,
    [System.Management.Automation.Language.VariableExpressionAst]$VariableExpressionAst = $null)
    while ($true) {
        if ($null -ne $CommandElementAst.Expression) {
            $CommandElementAst = $CommandElementAst.Expression
        }
        elseif ($null -ne $CommandElementAst.Left) {
            if($CommandElementAst.Left -eq $VariableExpressionAst){
                if($CommandElementAst.Right -eq $VariableExpressionAst){
                    $CommandElementAst = $null
                }
                else{
                    $CommandElementAst = $CommandElementAst.Right
                }
            }
            else{
                $CommandElementAst = $CommandElementAst.Left
            }
        }
        elseif ($null -ne $CommandElementAst.Target) {
            $CommandElementAst = $CommandElementAst.Target
        }
        elseif ($null -ne $CommandElementAst.Pipeline) {
            $CommandElementAst = $CommandElementAst.Pipeline
        }
        elseif ($null -ne $CommandElementAst.PipelineElements) {
            $LastElement = $CommandElementAst.PipelineElements[-1].Extent.Text
            # If the LastElement contains "where" or "sort", then the type isnot changed. 
            if($LastElement -match "where" -or $LastElement -match "sort"){
                $CommandElementAst = $CommandElementAst.PipelineElements[0]
            }
            else{
                $CommandElementAst = $CommandElementAst.PipelineElements[-1]
            }
        }
        elseif($null -ne $CommandElementAst.Elements){
            $CommandElementAst = $CommandElementAst.Elements[0]
        }
        elseif($null -ne $CommandElementAst.SubExpression){
            $CommandElementAst = $CommandElementAst.SubExpression
        }
        else {
            break
        }
    }
    return $CommandElementAst
}

<#
    .SYNOPSIS
    Gets the recovered value type from the ReturnType of the final actual value from ast.
#>
function Get-RecoveredValueType{
    param(
        [System.Management.Automation.Language.Ast]$CommandElementAst,
        [System.Reflection.TypeInfo]$Type
    )
    $Items = @()
    while ($true) {
        if ($global:AssignmentLeftAndRight.ContainsKey($CommandElementAst.Extent.Text)){
            $CommandElementAst = $global:AssignmentLeftAndRight.($CommandElementAst.Extent.Text)
        }
        elseif ($null -ne $CommandElementAst.Left) {
            if($CommandElementAst.Left -eq $VariableExpressionAst){
                if($CommandElementAst.Right -eq $VariableExpressionAst){
                    $CommandElementAst = $null
                }
                else{
                    $CommandElementAst = $CommandElementAst.Right
                }
            }
            else{
                $CommandElementAst = $CommandElementAst.Left
            }
        }
        elseif ($null -ne $CommandElementAst.Expression) {
            if($null -ne $CommandElementAst.Member){
                $Items += $CommandElementAst.Member
            }
            $CommandElementAst = $CommandElementAst.Expression
        }
        elseif ($null -ne $CommandElementAst.Target) {
            $Items += "Target"
            $CommandElementAst = $CommandElementAst.Target
        }
        else {
            break
        }
    }
    for($j = $Items.Length - 1; $j -ge 0; $j--){
        if($Items[$j] -eq "Target"){
            if($Type.IsGenericType){
                $Type = $Type.GetGenericArguments()[0]
            }
        }
        else{
            if($Items[$j].Value -eq "new"){
                return $Type
            }
            $Member = $Type.GetMembers() | Where-Object {$_.Name -eq $Items[$j]}
            if($null -eq $Member -and $null -ne $Type.ImplementedInterfaces){
                for($i = 0; $i -lt $Type.ImplementedInterfaces.Length; $i++){
                    $Member = $Type.ImplementedInterfaces[$i].GetMembers() | Where-Object {$_.Name -eq $Items[$j]}
                    if($null -ne $Member){
                        break
                    }
                }
            }
            if($null -eq $Member){
                 return $null
            }
            if($Member -is [array]){
                $Member = $Member[0]
            }
            if($null -ne $Member.PropertyType){
                $Type = $Member.PropertyType
            }
            elseif($null -ne $Member.ReturnType){
                $Type = $Member.ReturnType
            }
            else{
                return $null
            }
        }
    }
    return $Type
}

<#
    .SYNOPSIS
    Measure whether the actual type matches the expected type.
#>
function Measure-IsTypeMatched{
    param (
        [System.Reflection.TypeInfo]$ExpectedType,
        [System.Reflection.TypeInfo]$ActualType
    )
    if($ActualType -eq $null) {
        return $false
    }
    if($ActualType.IsArray) {
        $ActualType = $ActualType.GetElementType()
    }
    if($ActualType.IsGenericType){
        $ActualType = $ActualType.GetGenericArguments()[0]
    }
    $Converter = [System.ComponentModel.TypeDescriptor]::GetConverter($ExpectedType)  
    if ($ActualType -eq $ExpectedType -or
        $ActualType.GetInterfaces().Contains($ExpectedType) -or 
        $ExpectedType.GetInterfaces().Contains($ActualType) -or 
        $ActualType.IsSubclassOf($ExpectedType) -or 
        $Converter.CanConvertFrom($ActualType)) {
        return $true
    }
    return $false
}

<#
    .SYNOPSIS
    Gets the expression's actual value and type, if the parameter is assigned with a value.
#>
function Get-AssignedParameterExpression {
    param (
        [System.Management.Automation.CommandInfo]$GetCommand,
        [string]$ParameterName,
        [System.Management.Automation.Language.Ast]$CommandElement
    )
    $ParameterNameNotAlias = Get-ParameterNameNotAlias $GetCommand $ParameterName
    $CommandElement_Copy = Get-FinalVariableValue $CommandElement
    while ($CommandElement_Copy -is [System.Management.Automation.Language.VariableExpressionAst]) {
        # Skip Automatic Variable
        $VariableName = $CommandElement_Copy.VariablePath
        if($null -ne (Get-Variable | Where-Object {$_.Name -eq $VariableName})){
            break
        }
        # Get the actual value
        $CommandElement_Copy = Get-FinalVariableValue $global:AssignmentLeftAndRight.($CommandElement_Copy.Extent.Text) $CommandElement_Copy
        if ($null -eq $CommandElement_Copy) {
            # Variable is not assigned with a value.
            # Unassigned_Variable
            $ExpressionToParameter = $CommandElement.Extent.Text + " is a null-valued parameter value."
            return $ExpressionToParameter
        }
    }
    if($CommandElement_Copy.Extent.Text -match "foreach" -or $CommandElement_Copy.Extent.Text -match "select"){
        Write-Debug "The CommandElement contains 'foreach' or 'select'. This situation can not be handled now."
        return $null
    }
    $ExpectedType = $GetCommand.Parameters.$ParameterNameNotAlias.ParameterType
    if($CommandElement_Copy -is [System.Management.Automation.Language.HashtableAst]){
        # If ExpectedType is ValueType, then it cannot be created by Hashtable.
        if($ExpectedType.IsValueType){
            # Mismatched_Parameter_Value_Type
            $ExpressionToParameter = "$($CommandElement.Extent.Text)-#-$ExpectedType, created by hashtable but is value type."
            return $ExpressionToParameter
        }
        return $null
    }
    if($CommandElement_Copy -is [System.Management.Automation.Language.ConvertExpressionAst]){
        $CommandElement_Copy = $CommandElement_Copy.Type
    }
    while ($ExpectedType.IsArray) {
        $ExpectedType = $ExpectedType.GetElementType()
    }
    if($ExpectedType.IsGenericType){
        $ExpectedType = $ExpectedType.GetGenericArguments()[0]
    }
    if ($CommandElement_Copy -is [System.Management.Automation.Language.CommandAst]) {
        # Value is an command
        # If the value is created by "New-Object", then get the type behind "New-Object".
        if($CommandElement_Copy.CommandElements[0].Extent.Text -eq "New-Object"){
            if($CommandElement_Copy.CommandElements[1].Extent.Text -eq "-TypeName"){
                $TypeName = $CommandElement_Copy.CommandElements[2].Extent.Text -replace "`""
                $TypeName = $TypeName -replace "'"
            }
            else{
                $TypeName = $CommandElement_Copy.CommandElements[1].Extent.Text -replace "`""
                $TypeName = $TypeName -replace "'"
            }
            $OutputType = $TypeName -as [Type]
            $OutputTypes = @() + $OutputType
        }
        else{
            $GetElementCommand = Get-Command $CommandElement_Copy.CommandElements[0].Extent.Text -ErrorAction SilentlyContinue
            if ($null -eq $GetElementCommand) {
                # CommandName is not valid.
                # will be reported in next CommandAst
                return $null
            }
            $OutputTypes = @()
            if($global:UtilityOutputTypePair.ContainsKey($GetElementCommand.Name)){
                $OutputType = $global:UtilityOutputTypePair.($GetElementCommand.Name)
                $OutputTypes += $OutputType
            }
            else{
                $j = 0
                while($GetElementCommand.OutputType[$j]){
                    $OutputTypes += $GetElementCommand.OutputType[$j].Type
                    $j++
                }
            }
        }
        $flag = $true
        $j = 0
        while($OutputTypes[$j]){
            $ReturnType = $OutputTypes[$j]
            $j++
            $ActualType = Get-RecoveredValueType $CommandElement $ReturnType
            if($null -eq $ActualType){
                Continue
            }
            if(Measure-IsTypeMatched $ExpectedType $ActualType){
                $flag = $false
                break
            }
        }
        if($flag){
            # Mismatched_Parameter_Value_Type
            $ExpressionToParameter = "$($CommandElement.Extent.Text)-#-$ExpectedType. Now the type is $ActualType.(Command)"
            return $ExpressionToParameter
        }
    }
    elseif($CommandElement_Copy -is [System.Management.Automation.Language.TypeExpressionAst] -or
    $CommandElement_Copy -is [System.Management.Automation.Language.TypeConstraintAst]){
        $ReturnType = $CommandElement_Copy.TypeName.ToString() -as [Type]
        if($null -eq $ReturnType){
            $ActualType = $null
        }
        else{
            $ActualType = Get-RecoveredValueType $CommandElement $ReturnType
        }
        if (!(Measure-IsTypeMatched $ExpectedType $ActualType)) {
            # Mismatched_Parameter_Value_Type
            $ExpressionToParameter = "$($CommandElement.Extent.Text)-#-$ExpectedType. Now the type is $ActualType.(Type)"
            return $ExpressionToParameter
        }
    }
    elseif($CommandElement_Copy -is [System.Management.Automation.Language.ExpressionAst]) {
        # Value is a constant expression                   
        $ConvertedObject = $CommandElement_Copy.Extent.text -as $ExpectedType
        # Value of Automatic Variable
        if($null -eq $ConvertedObject){
            if($null -ne (Get-Variable | Where-Object {$_.Name -eq $CommandElement_Copy.VariablePath})){
                $value = (Get-Variable | Where-Object {$_.Name -eq $CommandElement_Copy.VariablePath}).Value
            }
            $ConvertedObject = $value -as $ExpectedType
        }
        $StaticType = $CommandElement_Copy.StaticType
        if (!(Measure-IsTypeMatched $ExpectedType $StaticType) -and $null -eq $ConvertedObject) {
            # Mismatched_Parameter_Value_Type
            $ExpressionToParameter = "$($CommandElement.Extent.Text)-#-$ExpectedType. Now the type is $StaticType.(Static)"
            return $ExpressionToParameter
        }
    }
    return $null
}

<#
    .SYNOPSIS
    Detects parameter and expression error.
#>
function Measure-ParameterNameAndValue {
    [CmdletBinding()]
    [OutputType([Microsoft.Windows.PowerShell.ScriptAnalyzer.Generic.DiagnosticRecord[]])]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [System.Management.Automation.Language.ScriptBlockAst]
        $ScriptBlockAst
    )
    process {
        $Results = @()
        $global:CommandParameterPair = @()
        $global:Ast = $null
        $global:AssignmentLeftAndRight = @{}
        $global:ParameterSet = $null
        $global:AppearedParameters = @()
        $global:AppearedExpressions = @()
        $global:ParameterExpressionPair = @()
        $global:SkipNextCommandElementAst = $false

        try {
            [ScriptBlock]$Predicate = {
                param([System.Management.Automation.Language.Ast]$Ast)
                $global:Ast = $Ast
                if ($Ast -is [System.Management.Automation.Language.AssignmentStatementAst]) {
                    [System.Management.Automation.Language.AssignmentStatementAst]$AssignmentStatementAst = $Ast
                    if($AssignmentStatementAst.Left -is [System.Management.Automation.Language.ConvertExpressionAst]){
                        $global:AssignmentLeftAndRight.($AssignmentStatementAst.Left.Child.Extent.Text) = $AssignmentStatementAst.Left.Type
                    }
                    elseif($AssignmentStatementAst.Left -is [System.Management.Automation.Language.VariableExpressionAst]){
                        $global:AssignmentLeftAndRight.($AssignmentStatementAst.Left.Extent.Text) = $AssignmentStatementAst.Right
                    }
                }

                if ($Ast -is [System.Management.Automation.Language.CommandElementAst] -and $Ast.Parent -is [System.Management.Automation.Language.CommandAst]) {
                    [System.Management.Automation.Language.CommandElementAst]$CommandElementAst = $Ast
                    [System.Management.Automation.Language.CommandAst]$CommandAst = $CommandElementAst.Parent

                    # Skip all the statements with -ParameterName <Type>
                    if($Ast.Parent.Extent.Text -match "-\w+\s*<.*?>"){
                        Write-Debug "Skip $($Ast.Parent.Extent.Text)"
                        return $false
                    }
                    
                    if ($global:SkipNextCommandElementAst) {
                        $global:SkipNextCommandElementAst = $false
                        return $false
                    }

                    # Get wrapper function name by command element
                    $funcAst = $CommandElementAst
                    while($funcAst -isnot [System.Management.Automation.Language.FunctionDefinitionAst] -and $null -ne $funcAst.Parent.Parent.Parent){
                        $funcAst = $funcAst.Parent
                    }
                    $ModuleCmdletExNum = $funcAst.name

                    $CommandName = $CommandAst.CommandElements[0].Extent.Text
                    $GetCommand = Get-Command $CommandName -ErrorAction SilentlyContinue
                    if($null -eq $GetCommand){
                        return $false
                    }
                    # Get command from alias
                    if ($GetCommand.CommandType -eq "Alias") {
                        $CommandNameNotAlias = $GetCommand.ResolvedCommandName
                        $GetCommand = Get-Command $CommandNameNotAlias
                    }

                    if ($CommandElementAst -is [System.Management.Automation.Language.ExpressionAst] -and
                    $CommandAst.CommandElements.Extent.Text.IndexOf($CommandElementAst.Extent.Text) -eq 0) {
                        # This CommandElement is the first CommandElement of the command.
                        $global:AppearedParameters = @()
                        $global:AppearedExpressions = @()

                        # $AllParameters is the set of the command required to have
                        # Sort ParameterSets, move ParameterSets that have position parameters to the front.
                        $ParameterSets = @() +
                            ($GetCommand.ParameterSets | Sort-Object {($_.Parameters.Position | Where-Object {$_ -ge 0}).Count} -Descending)
                        foreach ($ParameterSet in $ParameterSets) {
                            # ParameterSets.Count is 0 when CommandName is an alias.
                            $AllParameterNamesInASet_Flag = $true
                            $Parameters = $ParameterSet.Parameters.Name + $ParameterSet.Parameters.Aliases
                            $AllParameters = $GetCommand.Parameters.Values.Name + $GetCommand.Parameters.Values.Aliases
                            foreach ($CommandElement in $CommandAst.CommandElements) {
                                if ($CommandElement -is [System.Management.Automation.Language.CommandParameterAst]) {
                                    $ParameterName = ([System.Management.Automation.Language.CommandParameterAst]$CommandElement).ParameterName
                                    if ($ParameterName -in $AllParameters -and $ParameterName -notin $Parameters) {
                                        # Exclude ParameterNames that are not in AllParameters. They will be reported later.
                                        $AllParameterNamesInASet_Flag = $false
                                        break
                                    }
                                }
                            }
                            if ($AllParameterNamesInASet_Flag) {
                                break
                            }
                        }
                        if ($AllParameterNamesInASet_Flag -eq $false) {
                            # Not all parameters in a same ParameterSet.
                            # Unknown_Parameter_Set
                            $global:ParameterSet = $null
                            $global:CommandParameterPair += @{
                                CommandName = $CommandAst.Extent.Text
                                ParameterName = ""
                                ExpressionToParameter = ""
                                ModuleCmdletExNum = $ModuleCmdletExNum
                            }
                            return $true
                        }
                        else {
                            # Create ParameterExpressionPair
                            $global:ParameterSet = $ParameterSet
                            $global:ParameterExpressionPair = @()
                            for ($i = 1; $i -lt $CommandAst.CommandElements.Count;$i++) {
                                $CommandElement = $CommandAst.CommandElements[$i]
                                $NextCommandElement = $CommandAst.CommandElements[$i + 1]

                                if ($CommandElement -is [System.Management.Automation.Language.CommandParameterAst]) {
                                    $CommandParameterElement = [System.Management.Automation.Language.CommandParameterAst]$CommandElement
                                    $ParameterName = $CommandParameterElement.ParameterName
                                    $ParameterNameNotAlias = Get-ParameterNameNotAlias $GetCommand $ParameterName
                                    if ($null -eq $ParameterNameNotAlias) {
                                        # ParameterName is not in AllParameters.
                                        # will report later.
                                        $global:ParameterExpressionPair += @{
                                            ParameterName = $ParameterName
                                            ExpressionToParameter = "<NonExistantParameterName>"
                                        }
                                        if ($null -ne $NextCommandElement -and $NextCommandElement -isnot [System.Management.Automation.Language.CommandParameterAst]) {
                                            $i += 1
                                        }
                                        continue
                                    }
                                    if ($GetCommand.Parameters.$ParameterNameNotAlias.SwitchParameter -eq $true) {
                                        # SwitchParameter
                                        $global:ParameterExpressionPair += @{
                                            ParameterName = $ParameterNameNotAlias
                                            ExpressionToParameter = "<SwitchParameter>"
                                        }
                                    }
                                    else {
                                        # not a SwitchParameter
                                        if ($null -eq $NextCommandElement -or $NextCommandElement -is [System.Management.Automation.Language.CommandParameterAst]) {
                                            # NonSwitchParameter + Parameter
                                            # Parameter must be assigned with a value.
                                            # will report later.
                                            $global:ParameterExpressionPair += @{
                                                ParameterName = $ParameterNameNotAlias
                                                ExpressionToParameter = "<NoValue>"
                                            }
                                        }
                                        else {
                                            # NonSwitchParameter + Expression
                                            $global:ParameterExpressionPair += @{
                                                ParameterName = $ParameterNameNotAlias
                                                ExpressionToParameter = $NextCommandElement
                                            }
                                            $i += 1
                                        }
                                    }
                                }
                                elseif ($CommandElement -is [System.Management.Automation.Language.VariableExpressionAst] -and
                                ([System.Management.Automation.Language.VariableExpressionAst]$CommandElement).Splatted -eq $true) {
                                    # @var
                                    $KeyValuePairs = $global:AssignmentLeftAndRight.$("$" + ([System.Management.Automation.Language.VariableExpressionAst]$CommandElement).VariablePath).Expression.KeyValuePairs
                                    $ParameterNames = $KeyValuePairs.Item1.Value
                                    foreach ($ParameterName in $ParameterNames) {
                                        $ParameterNameNotAlias = Get-ParameterNameNotAlias $GetCommand $ParameterName
                                        if ($null -eq $ParameterNameNotAlias) {
                                            # Non-existant parameter name.
                                            # will report later.
                                            $global:ParameterExpressionPair += @{
                                                ParameterName = $ParameterName
                                                ExpressionToParameter = "<NonExistantParameterName>"
                                            }
                                        }
                                        else {
                                            $global:ParameterExpressionPair += @{
                                                ParameterName = $ParameterNameNotAlias
                                                ExpressionToParameter = ($KeyValuePairs | Where-Object {$_.Item1.Value -eq $ParameterName}).Item2
                                            }
                                        }
                                    }
                                }
                                elseif ($CommandElement -is [System.Management.Automation.Language.ExpressionAst]) {
                                    $CommandExpressionElement = [System.Management.Automation.Language.ExpressionAst]$CommandElement
                                    $PositionMaximum = ($global:ParameterSet.Parameters.Position | Measure-Object -Maximum).Maximum
                                    for ($Position = 0; $Position -le $PositionMaximum; $Position++) {
                                        $PositionParameterName = ($global:ParameterSet.Parameters | Where-Object {$_.Position -eq $Position}).Name
                                        if ($null -ne $PositionParameterName -and $PositionParameterName -notin $global:ParameterExpressionPair.ParameterName) {
                                            $global:ParameterExpressionPair += @{
                                                ParameterName = $PositionParameterName
                                                ExpressionToParameter = $CommandExpressionElement
                                            }
                                            break
                                        }
                                    }
                                    if ($Position -gt $PositionMaximum) {
                                        # This expression doesn't belong to any parameters.
                                        # will report later.
                                        $global:ParameterExpressionPair += @{
                                            ParameterName = "<unknown>"
                                            ExpressionToParameter = $CommandExpressionElement
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if ($null -eq $global:ParameterSet) {
                        # Skip commands that can't determine their ParameterSets.
                        return $false
                    }

                    if ($CommandElementAst -is [System.Management.Automation.Language.CommandParameterAst]) {
                        # This CommandElement is CommandParameter.
                        $index = $CommandAst.CommandElements.Extent.Text.IndexOf($CommandElementAst.Extent.Text)
                        $NextCommandElement = $CommandAst.CommandElements[$index + 1]
                        $ParameterName = ([System.Management.Automation.Language.CommandParameterAst]$CommandElementAst).ParameterName
                        $ParameterNameNotAlias = Get-ParameterNameNotAlias $GetCommand $ParameterName
                        if ($null -eq $ParameterNameNotAlias) {
                            # ParameterName is not in AllParameters.
                            # Invalid_Parameter_Name
                            if ($NextCommandElement -is [System.Management.Automation.Language.ExpressionAst]) {
                                $global:SkipNextCommandElementAst = $true
                            }
                            $global:CommandParameterPair += @{
                                CommandName = $CommandName
                                ParameterName = $ParameterName
                                ExpressionToParameter = ""
                                ModuleCmdletExNum = $ModuleCmdletExNum
                            }
                            return $true
                        }
                        else {
                            # ParameterName is correct.
                            if ($ParameterNameNotAlias -in $global:AppearedParameters) {
                                # This parameter appeared more than once.
                                # Duplicate_Parameter_Name
                                $global:CommandParameterPair += @{
                                    CommandName = $CommandName
                                    ParameterName = $ParameterNameNotAlias
                                    ExpressionToParameter = "<duplicate>"
                                    ModuleCmdletExNum = $ModuleCmdletExNum
                                }
                                return $true
                            }
                            else {
                                $global:AppearedParameters += $ParameterNameNotAlias
                            }

                            if ($GetCommand.Parameters.$ParameterNameNotAlias.SwitchParameter -eq $false) {
                                # Parameter is not a SwitchParameter.
                                if ($null -eq $NextCommandElement -or $NextCommandElement -is [System.Management.Automation.Language.CommandParameterAst]) {
                                    # Parameter is not assigned with a value.
                                    # Unassigned_Parameter
                                    $global:CommandParameterPair += @{
                                        CommandName = $CommandName
                                        ParameterName = $ParameterName
                                        ExpressionToParameter = $null
                                        ModuleCmdletExNum = $ModuleCmdletExNum
                                    }
                                    return $true
                                }
                                else {
                                    # Parameter is assigned with a value.
                                    $global:SkipNextCommandElementAst = $true
                                    $ExpressionToParameter = Get-AssignedParameterExpression $GetCommand $ParameterName $NextCommandElement
                                    if($null -ne $ExpressionToParameter){
                                        $global:CommandParameterPair += @{
                                            CommandName = $CommandName
                                            ParameterName = $ParameterName
                                            ExpressionToParameter = $ExpressionToParameter
                                            ModuleCmdletExNum = $ModuleCmdletExNum
                                        }
                                        return $true
                                    }
                                }
                            }
                        }
                    }

                    if ($CommandElementAst -is [System.Management.Automation.Language.ExpressionAst] -and
                    $CommandAst.CommandElements.Extent.Text.IndexOf($CommandElementAst.Extent.Text) -ne 0) {
                        if ($CommandElementAst -is [System.Management.Automation.Language.VariableExpressionAst] -and
                        ([System.Management.Automation.Language.VariableExpressionAst]$CommandElementAst).Splatted -eq $true) {
                            # @var
                            $KeyValuePairs = $global:AssignmentLeftAndRight.$("$" + ([System.Management.Automation.Language.VariableExpressionAst]$CommandElementAst).VariablePath)
                            $ParameterNames = $KeyValuePairs.Item1.Value
                            foreach ($ParameterName in $ParameterNames) {
                                $ParameterNameNotAlias = Get-ParameterNameNotAlias $GetCommand $ParameterName
                                $Expression = ($KeyValuePairs | Where-Object {$_.Item1.Value -eq $ParameterName}).Item2
                                if ($null -eq $ParameterNameNotAlias) {
                                    # Non-existant parameter name.
                                    $global:CommandName_Parameter_Expression_Pair += @{
                                        CommandName = $CommandName
                                        ParameterName = ""
                                        ExpressionToParameter = $CommandElementAst.Extent.Text
                                    }
                                    return $true
                                }
                                else {
                                    $ExpressionToParameter = Get-AssignedParameterExpression $GetCommand $ParameterName $Expression
                                    if($null -ne $ExpressionToParameter){
                                        $global:CommandParameterPair += @{
                                            CommandName = $CommandName
                                            ParameterName = ""
                                            ExpressionToParameter = $ExpressionToParameter
                                            ModuleCmdletExNum = $ModuleCmdletExNum
                                        }
                                        return $true
                                    }
                                }
                            }
                        }
                        else {
                            # This CommandElement is an expression with implicit parameter and is not the first CommandElement.
                            # When there are same parameter values:
                            $index = ($global:AppearedExpressions | Where-Object {$_.Extent.Text -eq $CommandElementAst.Extent.Text}).Count
                            $PairWithThisExpression = $global:ParameterExpressionPair | Where-Object {$_.ExpressionToParameter.Extent.Text -eq $CommandElementAst.Extent.Text}
                            if ((@() + $PairWithThisExpression).Count -eq 1) {
                                $PositionParameterName = $PairWithThisExpression.ParameterName
                            }
                            else {
                                $PositionParameterName = $PairWithThisExpression[$index].ParameterName
                            }
                            $global:AppearedExpressions += $CommandElementAst

                            if ($PositionParameterName -eq "<unknown>") {
                                # This expression doesn't belong to any parameters.
                                # Unbinded_Expression
                                $global:CommandParameterPair += @{
                                    CommandName = $CommandName
                                    ParameterName = $PositionParameterName
                                    ExpressionToParameter = $CommandElementAst.Extent.Text
                                    ModuleCmdletExNum = $ModuleCmdletExNum
                                }
                                return $true
                            }
                            $ExpressionToParameter = Get-AssignedParameterExpression $GetCommand $PositionParameterName $CommandElementAst
                            if($null -ne $ExpressionToParameter){
                                $global:CommandParameterPair += @{
                                    CommandName = $CommandName
                                    ParameterName = "[-$PositionParameterName]"
                                    ExpressionToParameter = $ExpressionToParameter
                                    ModuleCmdletExNum = $ModuleCmdletExNum
                                }
                                return $true
                            }
                        }
                    }
                }
                return $false
            }

            [System.Management.Automation.Language.Ast[]]$Asts = $ScriptBlockAst.FindAll($Predicate, $false)
            for ($i = 0; $i -lt $Asts.Count; $i++) {
                if ($global:CommandParameterPair[$i].ParameterName -eq "" -and $global:CommandParameterPair[$i].ExpressionToParameter -eq "") {
                    $Message = "$($CommandParameterPair[$i].CommandName) has a parameter not in the same ParameterSet as others."
                    $RuleName = [RuleNames]::Unknown_Parameter_Set
                    $Severity = "Error"
                    $RuleSuppressionID = "5010"
                    $Remediation = "Make sure the parameters are from the same parameter set."
                }
                elseif ($global:CommandParameterPair[$i].ExpressionToParameter -eq "") {
                    $Message = "$($CommandParameterPair[$i].CommandName) -$($CommandParameterPair[$i].ParameterName) is not a valid parameter name."
                    $RuleName = [RuleNames]::Invalid_Parameter_Name
                    $Severity = "Error"
                    $RuleSuppressionID = "5011"
                    $Remediation = "Check validity of the parameter -$($CommandParameterPair[$i].ParameterName)."
                }
                elseif ($global:CommandParameterPair[$i].ExpressionToParameter -eq "<duplicate>") {
                    $Message = "$($CommandParameterPair[$i].CommandName) -$($CommandParameterPair[$i].ParameterName) appeared more than once."
                    $RuleName = [RuleNames]::Duplicate_Parameter_Name
                    $Severity = "Error"
                    $RuleSuppressionID = "5012"
                    $Remediation = "Remove redundant parameter -$($CommandParameterPair[$i].ParameterName)."
                }
                elseif ($null -eq $global:CommandParameterPair[$i].ExpressionToParameter) {
                    $Message = "$($CommandParameterPair[$i].CommandName) -$($CommandParameterPair[$i].ParameterName) must be assigned with a value."
                    $RuleName = [RuleNames]::Unassigned_Parameter
                    $Severity = "Error"
                    $RuleSuppressionID = "5013"
                    $Remediation = "Assign value for the parameter -$($CommandParameterPair[$i].ParameterName)."
                }
                elseif ($global:CommandParameterPair[$i].ExpressionToParameter.EndsWith(" is a null-valued parameter value.")) {
                    $Message = "$($CommandParameterPair[$i].CommandName) -$($CommandParameterPair[$i].ParameterName) $($CommandParameterPair[$i].ExpressionToParameter)"
                    $RuleName = [RuleNames]::Unassigned_Variable
                    $Severity = "Warning"
                    $RuleSuppressionID = "5110"
                    $variable = $CommandParameterPair[$i].ExpressionToParameter -replace " is a null-valued parameter value."
                    $Remediation = "Assign value for $variable."
                }
                elseif ($global:CommandParameterPair[$i].ParameterName -eq "<unknown>") {
                    $Message = "$($CommandParameterPair[$i].CommandName) $($CommandParameterPair[$i].ExpressionToParameter) is not explicitly assigned to a parameter."
                    $RuleName = [RuleNames]::Unbinded_Expression
                    $Severity = "Error"
                    $RuleSuppressionID = "5014"
                    $Remediation = "Assign $($CommandParameterPair[$i].ExpressionToParameter) explicitly to the parameter."
                }
                else {
                    $ExpressionToParameter = ($CommandParameterPair[$i].ExpressionToParameter -split "-#-")[0]
                    $ExpectedType = ($CommandParameterPair[$i].ExpressionToParameter -split "-#-")[1]
                    $Message = "$($CommandParameterPair[$i].CommandName) -$($CommandParameterPair[$i].ParameterName) $ExpressionToParameter is not an expected parameter value type."
                    $RuleName = [RuleNames]::Mismatched_Parameter_Value_Type
                    $Severity = "Warning"
                    $RuleSuppressionID = "5111"
                    $Remediation = "Use correct parameter value type. Expected Type is $ExpectedType."
                }
                $Result = [Microsoft.Windows.PowerShell.ScriptAnalyzer.Generic.DiagnosticRecord]@{
                    Message = "$Message#@#$Remediation";
                    Extent = $Asts[$i].Extent;
                    RuleName = $RuleName;
                    Severity = $Severity
                    RuleSuppressionID = $RuleSuppressionID
                }
                $Results += $Result
            }
            return $Results
        }
        catch {
            $Result = [Microsoft.Windows.PowerShell.ScriptAnalyzer.Generic.DiagnosticRecord]@{
                Message = $_.Exception.Message;
                Extent = $global:Ast.Extent;
                RuleName = $PSCmdlet.MyInvocation.InvocationName;
                Severity = "Error"
            }
            $Results += $Result
            return $Results
        }
    }
}

Export-ModuleMember -Function Measure-*