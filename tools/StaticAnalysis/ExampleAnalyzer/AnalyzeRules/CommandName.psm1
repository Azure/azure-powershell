<#
    .SYNOPSIS
    Custom rule for command name.
    .NOTES
    File: CommandName.psm1
    Import-Module should be at the beginning of the rule to avoid thread conflict.
#>
Get-Item "$PSScriptRoot\..\..\..\..\artifacts\Debug\Az.*\Az.*.psd1" | Import-Module -Global

. $PSScriptRoot\..\utils.ps1

enum RuleNames {
    Invalid_Cmdlet
    Is_Alias
    Capitalization_Conventions_Violated
}

<#
    .SYNOPSIS
    Returns invaild, alias or unrecognized cmdlets.
#>
function Measure-CommandName {
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

        try {
            [ScriptBlock]$Predicate = {
                param([System.Management.Automation.Language.Ast]$Ast)
                $global:Ast = $Ast

                #Find all command in .ps1
                if ($Ast -is [System.Management.Automation.Language.CommandAst]) {
                    [System.Management.Automation.Language.CommandAst]$CommandAst = $Ast
                    # Get wrapper function name by command element
                    $funcAst = $CommandAst
                    while($funcAst -isnot [System.Management.Automation.Language.FunctionDefinitionAst] -and $null -ne $funcAst.Parent.Parent.Parent){
                        $funcAst = $funcAst.Parent
                    }
                    $ModuleCmdletExNum = $funcAst.name

                    if ($CommandAst.InvocationOperator -eq "Unknown") {
                        $CommandName = $CommandAst.CommandElements[0].Extent.Text
                        $GetCommand = Get-Command $CommandName -ErrorAction SilentlyContinue
                        if($null -eq $GetCommand){
                            # CommandName is not valid.
                            $global:CommandParameterPair += @{
                                CommandName = $CommandName
                                ParameterName = "<is not valid>"
                                ModuleCmdletExNum = $ModuleCmdletExNum
                            }
                            return $true
                        }

                        $ActualName = $GetCommand.Name
                        if ($GetCommand.CommandType -eq "Alias") {
                            # CommandName is an alias.
                            $global:CommandParameterPair += @{
                                CommandName = $CommandName
                                ParameterName = "<is an alias>"
                                ModuleCmdletExNum = $ModuleCmdletExNum
                            }
                            return $true
                        }
                        if ($CommandName -cne $ActualName) {
                            # CommandName doesn't follow the Capitalization Conventions.
                            $global:CommandParameterPair += @{
                                CommandName = "$CommandName#@#$ActualName"
                                ParameterName = "<doesn't follow the Capitalization Conventions>"
                                ModuleCmdletExNum = $ModuleCmdletExNum
                            }
                            return $true
                        }
                    }
                }

                return $false
            }

            # Find all false scriptblock
            [System.Management.Automation.Language.Ast[]]$Asts = $ScriptBlockAst.FindAll($Predicate, $false)
            for ($i = 0; $i -lt $Asts.Count; $i++) {
                if ($global:CommandParameterPair[$i].ParameterName -eq "<is not valid>") {
                    $Message = "$($CommandParameterPair[$i].CommandName) is not a valid command name."
                    $RuleName = [RuleNames]::Invalid_Cmdlet
                    $RuleSuppressionID = "5000"
                    $Remediation = "Check the spell of $($CommandParameterPair[$i].CommandName)."
                    $Severity = "Error"
                }
                if ($global:CommandParameterPair[$i].ParameterName -eq "<is an alias>") {
                    $Message = "$($CommandParameterPair[$i].CommandName) is an alias of `"$((Get-Alias $CommandParameterPair[$i].CommandName)[0].ResolvedCommandName)`"."
                    $RuleName = [RuleNames]::Is_Alias
                    $RuleSuppressionID = "5100"
                    $Remediation = "Use formal name `"$((Get-Alias $CommandParameterPair[$i].CommandName)[0].ResolvedCommandName)`" of the alias `"$($CommandParameterPair[$i].CommandName)`"."
                    $Severity = "Warning"
                }
                if ($global:CommandParameterPair[$i].ParameterName -eq "<doesn't follow the Capitalization Conventions>") {
                    $CommandName, $CorrectName = $CommandParameterPair[$i].CommandName -split "#@#"
                    $Message = "$CommandName doesn't follow the Capitalization Conventions."
                    $RuleName = [RuleNames]::Capitalization_Conventions_Violated
                    $RuleSuppressionID = "5101"
                    $Remediation = "Check the Capitalization Conventions. Suggest format: $CorrectName"
                    $Severity = "Error"
                }
                $ModuleCmdletExNum = $($CommandParameterPair[$i].ModuleCmdletExNum)
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