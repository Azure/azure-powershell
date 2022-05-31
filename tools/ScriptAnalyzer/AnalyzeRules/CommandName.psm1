<#
    .SYNOPSIS
    Custom rule for command name.
    .NOTES
    File: CommandName.psm1
#>

Import-Module (Get-ChildItem -Path ./artifacts/Debug).FullName -Scope Global

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

                #find all command in .ps1
                if ($Ast -is [System.Management.Automation.Language.CommandAst]) {
                    [System.Management.Automation.Language.CommandAst]$CommandAst = $Ast
                    if ($CommandAst.InvocationOperator -eq "Unknown") {
                        # $CommandName = $CommandAst.GetCommandName()
                        $CommandName = $CommandAst.CommandElements[0].Extent.Text
                        $GetCommand = Get-Command $CommandName -ErrorAction SilentlyContinue
                        if ($GetCommand -eq $null) {
                            # CommandName is not valid.
                            $global:CommandParameterPair += @{
                                CommandName = $CommandName
                                ParameterName = "<is not valid>"
                            }
                            return $true
                        }
                        else {
                            if ($GetCommand.CommandType -eq "Alias") {
                                # CommandName is an alias.
                                $global:CommandParameterPair += @{
                                    CommandName = $CommandName
                                    ParameterName = "<is an alias>"
                                }
                                return $true
                            }
                            if ($CommandName -cnotmatch "^([A-Z][a-z]+)+-([A-Z][a-z0-9]*)+$") {
                                # CommandName doesn't follow the Capitalization Conventions.
                                $global:CommandParameterPair += @{
                                    CommandName = $CommandName
                                    ParameterName = "<doesn't follow the Capitalization Conventions>"
                                }
                                return $true
                            }
                        }
                    }
                }

                return $false
            }

            # find all false scriptblock
            [System.Management.Automation.Language.Ast[]]$Asts = $ScriptBlockAst.FindAll($Predicate, $false)
            for ($i = 0; $i -lt $Asts.Count; $i++) {
                if ($global:CommandParameterPair[$i].ParameterName -eq "<is not valid>") {
                    $Message = "`"$($CommandParameterPair[$i].CommandName)`" is not a valid command name."
                    $RuleName = [RuleNames]::Invalid_Cmdlet
                }
                if ($global:CommandParameterPair[$i].ParameterName -eq "<is an alias>") {
                    $Message = "`"$($CommandParameterPair[$i].CommandName)`" is an alias of `"$((Get-Alias $CommandParameterPair[$i].CommandName)[0].ResolvedCommandName)`"."
                    $RuleName = [RuleNames]::Is_Alias
                }
                if ($global:CommandParameterPair[$i].ParameterName -eq "<doesn't follow the Capitalization Conventions>") {
                    $Message = "`"$($CommandParameterPair[$i].CommandName)`" doesn't follow the Capitalization Conventions."
                    $RuleName = [RuleNames]::Capitalization_Conventions_Violated
                }
                $Result = [Microsoft.Windows.PowerShell.ScriptAnalyzer.Generic.DiagnosticRecord]@{
                    Message = $Message;
                    Extent = $Asts[$i].Extent;
                    RuleName = $RuleName;
                    Severity = "Error"
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
