<#
    .SYNOPSIS
    Custom rule for parameter name and value.
    .NOTES
    File: ParameterNameAndValue.psm1
#>

# Import-Module AzPreview
# Import-Module AzureRM

enum RuleNames {
    Unknown_Parameter_Set
    Invalid_Parameter_Name
    Duplicate_Parameter_Name
    Unassigned_Parameter
    Unassigned_Variable
    Unbinded_Parameter_Name
    Mismatched_Parameter_Value_Type
}


<#
    .SYNOPSIS
    Gets the actual value from ast.
#>
function Get-ActualVariableValue {
    param([System.Management.Automation.Language.Ast]$CommandElementAst)

    while ($true) {
        if ($CommandElementAst.Expression -ne $null) {
            $CommandElementAst = $CommandElementAst.Expression
        }
        elseif ($CommandElementAst.Target -ne $null) {
            $CommandElementAst = $CommandElementAst.Target
        }
        elseif ($CommandElementAst.Pipeline -ne $null) {
            $CommandElementAst = $CommandElementAst.Pipeline
        }
        elseif ($CommandElementAst.PipelineElements -ne $null) {
            $CommandElementAst = $CommandElementAst.PipelineElements[-1]
        }
        else {
            break
        }
    }
    return $CommandElementAst
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
                    if ($global:AssignmentLeftAndRight.ContainsKey($AssignmentStatementAst.Left.Extent.Text)) {
                        $global:AssignmentLeftAndRight.($AssignmentStatementAst.Left.Extent.Text) = $AssignmentStatementAst.Right
                    }
                    else {
                        $global:AssignmentLeftAndRight += @{
                            $AssignmentStatementAst.Left.Extent.Text = $AssignmentStatementAst.Right
                        }
                    }
                }

                if ($Ast -is [System.Management.Automation.Language.CommandElementAst] -and $Ast.Parent -is [System.Management.Automation.Language.CommandAst]) {
                    [System.Management.Automation.Language.CommandElementAst]$CommandElementAst = $Ast
                    if ($global:SkipNextCommandElementAst) {
                        $global:SkipNextCommandElementAst = $false
                        return $false
                    }

                    $CommandAst = $CommandElementAst.Parent
                    # $CommandName = $CommandAst.GetCommandName()
                    $CommandName = $CommandAst.CommandElements[0].Extent.Text
                    $GetCommand = Get-Command $CommandName -ErrorAction SilentlyContinue
                    if ($GetCommand -eq $null) {
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
                        $global:AppearedParameters = @() #empty
                        $global:AppearedExpressions = @() #empty

                        # $AllParameters is the set of the command required to have
                        # sort ParameterSets, move ParameterSets that have position parameters to the front.
                        $ParameterSets = @() +
                            # ($GetCommand.ParameterSets | where {$_.Name -eq $GetCommand.DefaultParameterSet}) +
                            ($GetCommand.ParameterSets | Sort-Object {($_.Parameters.Position | where {$_ -ge 0}).Count} -Descending)
                        foreach ($ParameterSet in $ParameterSets) {
                            # ParameterSets.Count is 0 when CommandName is an alias.
                            $AllParameterNamesInASet_Flag = $true
                            $Parameters = $ParameterSet.Parameters.Name + $ParameterSet.Parameters.Aliases
                            $AllParameters = $GetCommand.Parameters.Values.Name + $GetCommand.Parameters.Values.Aliases
                            foreach ($CommandElement in $CommandAst.CommandElements) {
                                if ($CommandElement -is [System.Management.Automation.Language.CommandParameterAst]) {
                                    $ParameterName = ([System.Management.Automation.Language.CommandParameterAst]$CommandElement).ParameterName
                                    # Unknown_Parameter_Set
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
                            $global:ParameterSet = $null
                            $global:CommandParameterPair += @{
                                CommandName = $CommandAst.Extent.Text
                                ParameterName = ""
                                ExpressionToParameter = ""
                            }
                            return $true
                        }
                        else {
                            # Create ParameterExpressionPair
                            $global:ParameterSet = $ParameterSet
                            $global:ParameterExpressionPair = @()
                            for ($i = 1; $i -lt $CommandAst.CommandElements.Count;) {
                                $CommandElement = $CommandAst.CommandElements[$i]
                                $NextCommandElement = $CommandAst.CommandElements[$i + 1]
                                # $PositionParameters = $global:ParameterSet.Parameters | where {$_.Position -ge 0}
                                # $PositionParameters = $PositionParameters.Name + $PositionParameters.Aliases

                                if ($CommandElement -is [System.Management.Automation.Language.CommandParameterAst]) {
                                    $CommandParameterElement = [System.Management.Automation.Language.CommandParameterAst]$CommandElement
                                    $ParameterName = $CommandParameterElement.ParameterName
                                    $ParameterNameNotAlias = $GetCommand.Parameters.Values.Name | where {
                                        $ParameterName -in $GetCommand.Parameters.$_.Name -or
                                        $ParameterName -in $GetCommand.Parameters.$_.Aliases
                                    }
                                    # Invalid_Parameter_Name
                                    if ($ParameterNameNotAlias -eq $null) {
                                        # ParameterName is not in AllParameters.
                                        # will report later.
                                        $global:ParameterExpressionPair += @{
                                            ParameterName = $ParameterName
                                            ExpressionToParameter = "<NonExistantParameterName>"
                                        }
                                        if ($NextCommandElement -eq $null -or $NextCommandElement -is [System.Management.Automation.Language.CommandParameterAst]) {
                                            $i += 1
                                        }
                                        else {
                                            $i += 2
                                        }
                                        continue
                                    }
                                    if ($GetCommand.Parameters.$ParameterNameNotAlias.SwitchParameter -eq $true) {
                                        # SwitchParameter
                                        $global:ParameterExpressionPair += @{
                                            ParameterName = $ParameterNameNotAlias
                                            ExpressionToParameter = "<SwitchParameter>"
                                        }
                                        $i += 1
                                    }
                                    else {
                                        # Unassigned_Parameter
                                        # not a SwitchParameter
                                        if ($NextCommandElement -eq $null -or $NextCommandElement -is [System.Management.Automation.Language.CommandParameterAst]) {
                                            # NonSwitchParameter + Parameter
                                            # Parameter must be assigned with a value.
                                            # will report later.
                                            $global:ParameterExpressionPair += @{
                                                ParameterName = $ParameterNameNotAlias
                                                ExpressionToParameter = "<NoValue>"
                                            }
                                            $i += 1
                                        }
                                        else {
                                            # NonSwitchParameter + Expression
                                            $global:ParameterExpressionPair += @{
                                                ParameterName = $ParameterNameNotAlias
                                                ExpressionToParameter = $NextCommandElement
                                            }
                                            $i += 2
                                        }
                                    }
                                }
                                elseif ($CommandElement -is [System.Management.Automation.Language.ExpressionAst]) {
                                    # Expression
                                    $CommandExpressionElement = [System.Management.Automation.Language.ExpressionAst]$CommandElement
                                    $PositionMaximum = ($global:ParameterSet.Parameters.Position | Measure-Object -Maximum).Maximum
                                    for ($Position = 0; $Position -le $PositionMaximum; $Position++) {
                                        $ImplicitParameterName = @() + ($global:ParameterSet.Parameters | where {$_.Position -eq $Position}).Name
                                        if ($ImplicitParameterName.Count -ne 0 -and $ImplicitParameterName -notin $global:ParameterExpressionPair.ParameterName) {
                                            $global:ParameterExpressionPair += @{
                                                ParameterName = $ImplicitParameterName[0]
                                                ExpressionToParameter = $CommandExpressionElement
                                            }
                                            $i += 1
                                            break
                                        }
                                    }
                                    # Unbinded_Parameter_Name
                                    if ($Position -gt $PositionMaximum) {
                                        # This expression doesn't belong to any parameters.
                                        $global:ParameterExpressionPair += @{
                                            ParameterName = "<non-existant>"
                                            ExpressionToParameter = $CommandExpressionElement
                                        }
                                        $i += 1
                                    }
                                }
                            }
                        }
                    }

                    if ($global:ParameterSet -eq $null) {
                        # skip commands that can't determine their ParameterSets.
                        return $false
                    }

                    if ($CommandElementAst -is [System.Management.Automation.Language.CommandParameterAst]) {
                        # This CommandElement is CommandParameter.
                        $index = $CommandAst.CommandElements.Extent.Text.IndexOf($CommandElementAst.Extent.Text)
                        $NextCommandElement = $CommandAst.CommandElements[$index + 1]
                        $ParameterName = ([System.Management.Automation.Language.CommandParameterAst]$CommandElementAst).ParameterName
                        $ParameterNameNotAlias = $GetCommand.Parameters.Values.Name | where {
                            $ParameterName -in $GetCommand.Parameters.$_.Name -or
                            $ParameterName -in $GetCommand.Parameters.$_.Aliases
                        }
                        if ($ParameterNameNotAlias -eq $null) {
                            # ParameterName is not in AllParameters.
                            # Invalid_Parameter_Name
                            if ($NextCommandElement -is [System.Management.Automation.Language.ExpressionAst]) {
                                $global:SkipNextCommandElementAst = $true
                            }
                            $global:CommandParameterPair += @{
                                CommandName = $CommandName
                                ParameterName = $ParameterName
                                ExpressionToParameter = ""
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
                                    ExpressionToParameter = "<2>"
                                }
                                return $true
                            }
                            else {
                                $global:AppearedParameters += $ParameterNameNotAlias
                            }

                            if ($GetCommand.Parameters.$ParameterNameNotAlias.SwitchParameter -eq $false) {
                                # Parameter is not a SwitchParameter.
                                if ($NextCommandElement -eq $null -or $NextCommandElement -is [System.Management.Automation.Language.CommandParameterAst]) {
                                    # Parameter is not assigned with a value.
                                    # Unassigned_Parameter
                                    $global:CommandParameterPair += @{
                                        CommandName = $CommandName
                                        ParameterName = $ParameterName
                                        ExpressionToParameter = $null
                                    }
                                    return $true
                                }
                                else {
                                    # Parameter is assigned with a value.
                                    $global:SkipNextCommandElementAst = $true
                                    $NextCommandElement_Copy = Get-ActualVariableValue $NextCommandElement

                                    while ($NextCommandElement_Copy -is [System.Management.Automation.Language.VariableExpressionAst]) {
                                        # get the actual value
                                        $NextCommandElement_Copy = Get-ActualVariableValue $global:AssignmentLeftAndRight.($NextCommandElement_Copy.Extent.Text)
                                        if ($NextCommandElement_Copy -eq $null) {
                                            # Variable is not assigned with a value.
                                            # Unassigned_Variable
                                            $global:CommandParameterPair += @{
                                                CommandName = $CommandName
                                                ParameterName = "-$ParameterName"
                                                ExpressionToParameter = $NextCommandElement.Extent.Text + " is a null-valued parameter value."
                                            }
                                            return $true
                                        }
                                    }
                                    if ($NextCommandElement_Copy -is [System.Management.Automation.Language.CommandAst]) {
                                        # value is an command
                                        $GetNextElementCommand = Get-Command $NextCommandElement_Copy.CommandElements[0].Extent.Text -ErrorAction SilentlyContinue
                                        if ($GetNextElementCommand -eq $null) {
                                            # CommandName is not valid.
                                            # will be reported in next CommandAst
                                            return $false
                                        }
                                        $ReturnType = $GetNextElementCommand.OutputType[0].Type
                                        if ($ReturnType -eq $null)
                                        {
                                            $ReturnType = [Object]
                                        }
                                        $ExpectedType = $GetCommand.Parameters.$ParameterNameNotAlias.ParameterType
                                        # Mismatched_Parameter_Value_Type
                                        if ($ReturnType -ne $ExpectedType -and $ReturnType -isnot $ExpectedType -and
                                        !$ReturnType.GetInterfaces().Contains($ExpectedType) -and !$ReturnType.GetInterfaces().Contains($ExpectedType.GetElementType())) {
                                                $global:CommandParameterPair += @{
                                                CommandName = $CommandName
                                                ParameterName = "-$ParameterName"
                                                ExpressionToParameter = $NextCommandElement.Extent.Text
                                            }
                                            return $true
                                        }
                                    }
                                    else {
                                        # value is a constant expression
                                        $ExpectedType = $GetCommand.Parameters.$ParameterNameNotAlias.ParameterType
                                        $ConvertedObject = $NextCommandElement_Copy.Extent.Text -as $ExpectedType
                                        # Mismatched_Parameter_Value_Type
                                        if ($NextCommandElement_Copy.StaticType -ne $ExpectedType -and $ConvertedObject -eq $null) {
                                            $global:CommandParameterPair += @{
                                                CommandName = $CommandName
                                                ParameterName = "-$ParameterName"
                                                ExpressionToParameter = $NextCommandElement.Extent.Text
                                            }
                                            return $true
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if ($CommandElementAst -is [System.Management.Automation.Language.ExpressionAst] -and
                    $CommandAst.CommandElements.Extent.Text.IndexOf($CommandElementAst.Extent.Text) -ne 0) {
                        # This CommandElement is an expression with implicit parameter and is not the first CommandElement.
                        # When there are same parameter values:
                        $index = ($global:AppearedExpressions | where {$_.Extent.Text -eq $CommandElementAst.Extent.Text}).Count
                        $PairWithThisExpression = $global:ParameterExpressionPair | where {$_.ExpressionToParameter.Extent.Text -eq $CommandElementAst.Extent.Text}
                        if ((@() + $PairWithThisExpression).Count -eq 1) {
                            # Convert to Array
                            $ImplicitParameterName = $PairWithThisExpression.ParameterName
                        }
                        else {
                            $ImplicitParameterName = $PairWithThisExpression[$index].ParameterName
                        }
                        $global:AppearedExpressions += $CommandElementAst

                        if ($ImplicitParameterName -eq "<non-existant>") {
                            $global:CommandParameterPair += @{
                                CommandName = $CommandName
                                ParameterName = $ImplicitParameterName
                                ExpressionToParameter = $CommandElementAst.Extent.Text
                            }
                            return $true
                        }

                        $CommandElementAst_Copy = Get-ActualVariableValue $CommandElementAst
                        while ($CommandElementAst_Copy -is [System.Management.Automation.Language.VariableExpressionAst]) {
                            # get the actual value
                            $CommandElementAst_Copy = Get-ActualVariableValue $global:AssignmentLeftAndRight.($CommandElementAst_Copy.Extent.Text)
                            if ($CommandElementAst_Copy -eq $null) {
                                # Variable is not assigned with a value.
                                $global:CommandParameterPair += @{
                                    CommandName = $CommandName
                                    ParameterName = "[-$ImplicitParameterName]"
                                    ExpressionToParameter = $CommandElementAst.Extent.Text + " is a null-valued parameter value."
                                }
                                return $true
                            }
                        }
                        if ($CommandElementAst_Copy -is [System.Management.Automation.Language.CommandAst]) {
                            # value is an command
                            $GetElementCommand = Get-Command $CommandElementAst_Copy.CommandElements[0].Extent.Text -ErrorAction SilentlyContinue
                            if ($GetElementCommand -eq $null) {
                                # CommandName is not valid.
                                # will be reported in next CommandAst
                                return $false
                            }
                            $ReturnType = $GetElementCommand.OutputType[0].Type
                            if ($ReturnType -eq $null)
                            {
                                $ReturnType = [Object]
                            }
                            $ExpectedType = $GetCommand.Parameters.$ImplicitParameterName.ParameterType
                            if ($ReturnType -ne $ExpectedType -and $ReturnType -isnot $ExpectedType -and
                            !$ReturnType.GetInterfaces().Contains($ExpectedType) -and !$ReturnType.GetInterfaces().Contains($ExpectedType.GetElementType())) {
                                    $global:CommandParameterPair += @{
                                    CommandName = $CommandName
                                    ParameterName = "[-$ImplicitParameterName]"
                                    ExpressionToParameter = $CommandElementAst.Extent.Text
                                }
                                return $true
                            }
                        }
                        else {
                            # value is a constant expression
                            $ExpectedType = $GetCommand.Parameters.$ImplicitParameterName.ParameterType
                            $ConvertedObject = $CommandElementAst_Copy.Extent.Text -as $ExpectedType
                            if ($CommandElementAst_Copy.StaticType -ne $ExpectedType -and $ConvertedObject -eq $null) {
                                $global:CommandParameterPair += @{
                                    CommandName = $CommandName
                                    ParameterName = "[-$ImplicitParameterName]"
                                    ExpressionToParameter = $CommandElementAst.Extent.Text
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
                    $Message = "`"$($CommandParameterPair[$i].CommandName)`" has a parameter not in the same ParameterSet as others."
                    $RuleName = [RuleNames]::Unknown_Parameter_Set
                    $Severity = "Error"
                }
                elseif ($global:CommandParameterPair[$i].ExpressionToParameter -eq "") {
                    $Message = "`"$($CommandParameterPair[$i].CommandName) -$($CommandParameterPair[$i].ParameterName)`" is not a valid parameter name."
                    $RuleName = [RuleNames]::Invalid_Parameter_Name
                    $Severity = "Error"
                }
                elseif ($global:CommandParameterPair[$i].ExpressionToParameter -eq "<2>") {
                    $Message = "`"$($CommandParameterPair[$i].CommandName) -$($CommandParameterPair[$i].ParameterName)`" appeared more than once."
                    $RuleName = [RuleNames]::Duplicate_Parameter_Name
                    $Severity = "Error"
                }
                elseif ($global:CommandParameterPair[$i].ExpressionToParameter -eq $null) {
                    $Message = "`"$($CommandParameterPair[$i].CommandName) -$($CommandParameterPair[$i].ParameterName)`" must be assigned with a value."
                    $RuleName = [RuleNames]::Unassigned_Parameter
                    $Severity = "Error"
                }
                elseif ($global:CommandParameterPair[$i].ExpressionToParameter.EndsWith(" is a null-valued parameter value.")) {
                    $Message = "`"$($CommandParameterPair[$i].CommandName) $($CommandParameterPair[$i].ParameterName) $($CommandParameterPair[$i].ExpressionToParameter)`""
                    $RuleName = [RuleNames]::Unassigned_Variable
                    $Severity = "Warning"
                }
                elseif ($global:CommandParameterPair[$i].ParameterName -eq "<non-existant>") {
                    $Message = "`"$($CommandParameterPair[$i].CommandName) $($CommandParameterPair[$i].ExpressionToParameter)`" is not explicitly assigned to a parameter."
                    $RuleName = [RuleNames]::Unbinded_Parameter_Name
                    $Severity = "Warning"
                }
                else {
                    $Message = "`"$($CommandParameterPair[$i].CommandName) $($CommandParameterPair[$i].ParameterName) $($CommandParameterPair[$i].ExpressionToParameter)`" is not an expected parameter value type."
                    $RuleName = [RuleNames]::Mismatched_Parameter_Value_Type
                    $Severity = "Warning"
                }
                $Result = [Microsoft.Windows.PowerShell.ScriptAnalyzer.Generic.DiagnosticRecord]@{
                    Message = $Message;
                    Extent = $Asts[$i].Extent;
                    RuleName = $RuleName;
                    Severity = $Severity
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
