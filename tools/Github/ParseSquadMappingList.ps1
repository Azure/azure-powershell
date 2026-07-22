# ----------------------------------------------------------------------------------
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

param(
    [Parameter(Mandatory = $true)]
    [string] $AccessToken
)

function GetIndentLength {
    [CmdletBinding()]
    param([string] $Line)
    return ([regex]::Match($Line, '^\s*').Value).Length
}

function TryParseLabelValue {
    [CmdletBinding()]
    param([string] $Line)
    if ($Line -match '^\s*label:\s*(.+)\s*$') {
        $value = $Matches[1].Trim()
        if (($value.StartsWith('"') -and $value.EndsWith('"')) -or ($value.StartsWith("'") -and $value.EndsWith("'"))) {
            $value = $value.Substring(1, $value.Length - 2)
        }
        return $value
    }
    return $null
}

function NormalizeMentioneeValue {
    [CmdletBinding()]
    param([string] $Mentionee)

    if ([string]::IsNullOrWhiteSpace($Mentionee)) {
        return $Mentionee
    }

    if ($Mentionee -match '^[^/]+/[^/]+$') {
        return $Mentionee
    }

    if ($Mentionee -match '^act-[a-z0-9-]+-squad$') {
        return "Azure/$Mentionee"
    }

    return $Mentionee
}

function IsSquadValue {
    [CmdletBinding()]
    param([string] $Value)

    if ([string]::IsNullOrWhiteSpace($Value)) {
        return $false
    }

    return $Value.Trim() -match '^(Azure/)?act-[a-z0-9-]+-squad$'
}

function ToSquadLabel {
    [CmdletBinding()]
    param([string] $Squad)

    if ($Squad -match '^Azure/(act-[a-z0-9-]+-squad)$') {
        return $Matches[1]
    }

    return $Squad
}

function NormalizeSquadTeamForms {
    [CmdletBinding()]
    param([string[]] $Lines)

    # Squad reviewers and mentionees must reference the GitHub team as Azure/<slug>;
    # squad labels (addLabel) stay as the bare <slug>.
    $result = [string[]]::new($Lines.Length)
    for ($i = 0; $i -lt $Lines.Length; $i++) {
        $line = $Lines[$i]

        if ($line -match '^(\s*)reviewer:\s*(act-[a-z0-9-]+-squad)\s*$') {
            $line = "$($Matches[1])reviewer: Azure/$($Matches[2])"
        }
        elseif ($line -match '^(\s*)-\s+(act-[a-z0-9-]+-squad)\s*$') {
            $line = "$($Matches[1])- Azure/$($Matches[2])"
        }

        $result[$i] = $line
    }

    return $result
}

function GetSquadMapping {
    [CmdletBinding()]
    param([string] $AccessToken)

    if ([string]::IsNullOrWhiteSpace($AccessToken)) {
        throw "AccessToken is required to load Squad Mapping."
    }

    $username = ""
    $password = $AccessToken
    $pair = "{0}:{1}" -f ($username, $password)
    $bytes = [System.Text.Encoding]::ASCII.GetBytes($pair)
    $token = [System.Convert]::ToBase64String($bytes)
    $headers = @{ Authorization = "Basic {0}" -f ($token) }
    $wikiUrl = 'https://dev.azure.com/azclitools/internal/_apis/wiki/wikis/internal.wiki/pages?path=/Squad%20Mapping&includeContent=true'
    $response = Invoke-RestMethod $wikiUrl -Headers $headers -ErrorAction Stop
    $rows = ($response.content -split "\n") | Where-Object { $_ -like '|*' } | Select-Object -Skip 2

    $mapping = @{}
    foreach ($row in $rows) {
        $columns = $row -split "\|"
        if ($columns.Count -lt 3) { continue }
        $label = $columns[1].Trim()
        $squad = $columns[2].Trim()
        if (![string]::IsNullOrWhiteSpace($label) -and ![string]::IsNullOrWhiteSpace($squad)) {
            $mapping[$label] = $squad
        }
    }
    return $mapping
}

function GetLabelsFromConditions {
    [CmdletBinding()]
    param([string[]] $Lines, [int] $ThenLineIndex, [int] $BaseIndentLength)
    $labels = [System.Collections.Generic.List[string]]::new()
    $ifLineIndex = -1
    for ($p = $ThenLineIndex - 1; $p -ge 0; $p--) {
        $lineAtP = $Lines[$p]
        $indentAtP = GetIndentLength -Line $lineAtP
        if ($lineAtP -match '^\s*-\s+if:\s*$' -and $indentAtP -le $BaseIndentLength) { $ifLineIndex = $p; break }
        if ($indentAtP -lt $BaseIndentLength - 2) { break }
    }
    if ($ifLineIndex -lt 0) { return $labels }
    for ($q = $ifLineIndex + 1; $q -lt $ThenLineIndex; $q++) {
        $candidate = TryParseLabelValue -Line $Lines[$q]
        if ($null -ne $candidate -and -not [string]::IsNullOrWhiteSpace($candidate)) {
            if (-not $labels.Contains($candidate)) { $labels.Add($candidate) }
        }
    }
    return $labels
}

function AddSquadLabelsToYaml {
    [CmdletBinding()]
    param([string[]] $Lines, [hashtable] $LabelToSquad)

    # For each rule, the squads applied are derived from the rule's component
    # (module) labels via the wiki mapping. Existing squad label/reviewer/mentionee
    # lines are OVERWRITTEN in place with the current mapping (replace, not append)
    # so a rule never accumulates a stale squad when ownership changes.
    $work = [System.Collections.Generic.List[string]]::new()
    $work.AddRange($Lines)

    $insertions = [System.Collections.Generic.List[object]]::new()

    for ($i = 0; $i -lt $work.Count; $i++) {
        $line = $work[$i]
        if ($line -notmatch '^(\s*)(then|actions):\s*$') {
            continue
        }
        $baseIndentLength = $Matches[1].Length

        $j = $i + 1
        while ($j -lt $work.Count -and $work[$j].Trim().Length -eq 0) {
            $j++
        }
        if ($j -ge $work.Count) {
            continue
        }

        $listLine = $work[$j]
        $listIndentLength = GetIndentLength -Line $listLine
        if ($listIndentLength -lt $baseIndentLength -or -not ($listLine -match '^\s*-\s+')) {
            continue
        }

        $k = $j
        while ($k -lt $work.Count) {
            $lineAtK = $work[$k]
            if ($lineAtK.Trim().Length -ne 0 -and (GetIndentLength -Line $lineAtK) -lt $baseIndentLength) {
                break
            }
            if ($lineAtK -match '^\s*description:' -and (GetIndentLength -Line $lineAtK) -eq $baseIndentLength) {
                break
            }
            $k++
        }

        $componentLabels = [System.Collections.Generic.List[string]]::new()
        $addLabelSquadLines = [System.Collections.Generic.List[int]]::new()
        $lastAddLabelLine = -1
        $reviewerSquadLines = [System.Collections.Generic.List[int]]::new()
        $lastReviewerLine = -1
        $mentioneeSquadLines = [System.Collections.Generic.List[int]]::new()
        $lastMentionLine = -1
        $mentionItemIndent = -1
        $hasMentionees = $false

        for ($b = $j; $b -lt $k; $b++) {
            $lineAtB = $work[$b]
            $indentAtB = GetIndentLength -Line $lineAtB

            if ($lineAtB -match '^\s*-\s+addLabel:\s*$' -and $indentAtB -eq $listIndentLength) {
                for ($c = $b + 1; $c -lt $k; $c++) {
                    $lineAtC = $work[$c]
                    if ($lineAtC -match '^\s*-\s+' -and (GetIndentLength -Line $lineAtC) -eq $listIndentLength) {
                        break
                    }
                    $labelValue = TryParseLabelValue -Line $lineAtC
                    if ($null -ne $labelValue) {
                        $lastAddLabelLine = $c
                        if (IsSquadValue -Value $labelValue) {
                            $addLabelSquadLines.Add($c)
                        } elseif (-not [string]::IsNullOrWhiteSpace($labelValue) -and -not $componentLabels.Contains($labelValue)) {
                            $componentLabels.Add($labelValue)
                        }
                        break
                    }
                }
                continue
            }

            if ($lineAtB -match '^\s*-\s+requestReview:\s*$' -and $indentAtB -eq $listIndentLength) {
                for ($c = $b + 1; $c -lt $k; $c++) {
                    $lineAtC = $work[$c]
                    if ($lineAtC -match '^\s*-\s+' -and (GetIndentLength -Line $lineAtC) -eq $listIndentLength) {
                        break
                    }
                    if ($lineAtC -match '^\s*reviewer:\s*(.+?)\s*$') {
                        $reviewerValue = $Matches[1].Trim()
                        if (($reviewerValue.StartsWith("'") -and $reviewerValue.EndsWith("'")) -or ($reviewerValue.StartsWith('"') -and $reviewerValue.EndsWith('"'))) {
                            $reviewerValue = $reviewerValue.Substring(1, $reviewerValue.Length - 2).Trim()
                        }
                        $lastReviewerLine = $c
                        if (IsSquadValue -Value $reviewerValue) {
                            $reviewerSquadLines.Add($c)
                        }
                        break
                    }
                }
                continue
            }

            if ($lineAtB -match '^\s*-\s+mentionUsers:\s*$' -and $indentAtB -eq $listIndentLength) {
                $hasMentionees = $true
                for ($c = $b + 1; $c -lt $k; $c++) {
                    $lineAtC = $work[$c]
                    $indentAtC = GetIndentLength -Line $lineAtC
                    if ($lineAtC.Trim().Length -ne 0 -and $indentAtC -le $listIndentLength -and $lineAtC -match '^\s*-\s+') {
                        break
                    }
                    if ($lineAtC -match '^\s*-\s+(\S+)\s*$') {
                        if ($mentionItemIndent -lt 0) { $mentionItemIndent = $indentAtC }
                        $lastMentionLine = $c
                        if (IsSquadValue -Value $Matches[1]) {
                            $mentioneeSquadLines.Add($c)
                        }
                    }
                }
                continue
            }
        }

        $labelsFromConditions = GetLabelsFromConditions -Lines $Lines -ThenLineIndex $i -BaseIndentLength $baseIndentLength
        foreach ($condLabel in $labelsFromConditions) {
            if (-not [string]::IsNullOrWhiteSpace($condLabel) -and -not (IsSquadValue -Value $condLabel) -and -not $componentLabels.Contains($condLabel)) {
                $componentLabels.Add($condLabel)
            }
        }

        $targets = [System.Collections.Generic.List[string]]::new()
        foreach ($componentLabel in $componentLabels) {
            if ($LabelToSquad.ContainsKey($componentLabel)) {
                $squad = $LabelToSquad[$componentLabel]
                if (-not [string]::IsNullOrWhiteSpace($squad) -and -not $targets.Contains($squad)) {
                    $targets.Add($squad)
                }
            }
        }

        if ($targets.Count -eq 0) {
            continue
        }

        $isPR = $false
        for ($p = $i - 1; $p -ge 0; $p--) {
            if ($Lines[$p] -match '^\s*description:') { break }
            if ($Lines[$p] -match 'payloadType:\s*Pull_Request') { $isPR = $true; break }
        }

        $labelExtraLines = [System.Collections.Generic.List[string]]::new()
        for ($t = 0; $t -lt $targets.Count; $t++) {
            $squadLabel = ToSquadLabel -Squad $targets[$t]
            if ($t -lt $addLabelSquadLines.Count) {
                $lineIndex = $addLabelSquadLines[$t]
                $indent = " " * (GetIndentLength -Line $work[$lineIndex])
                $work[$lineIndex] = "${indent}label: $squadLabel"
            } elseif ($lastAddLabelLine -ge 0) {
                $labelExtraLines.Add((" " * $listIndentLength) + "- addLabel:")
                $labelExtraLines.Add((" " * $listIndentLength) + "    label: $squadLabel")
            }
        }
        if ($labelExtraLines.Count -gt 0) {
            $insertions.Add([PSCustomObject]@{ Index = $lastAddLabelLine + 1; Lines = $labelExtraLines })
        }

        $reviewerAnchor = if ($lastReviewerLine -ge 0) { $lastReviewerLine } else { $lastAddLabelLine }
        $reviewerExtraLines = [System.Collections.Generic.List[string]]::new()
        for ($t = 0; $t -lt $targets.Count; $t++) {
            $reviewerTeam = NormalizeMentioneeValue -Mentionee $targets[$t]
            if ($t -lt $reviewerSquadLines.Count) {
                $lineIndex = $reviewerSquadLines[$t]
                $indent = " " * (GetIndentLength -Line $work[$lineIndex])
                $work[$lineIndex] = "${indent}reviewer: $reviewerTeam"
            } elseif ($isPR -and $reviewerAnchor -ge 0) {
                $reviewerExtraLines.Add((" " * $listIndentLength) + "- requestReview:")
                $reviewerExtraLines.Add((" " * ($listIndentLength + 4)) + "reviewer: $reviewerTeam")
            }
        }
        if ($reviewerExtraLines.Count -gt 0) {
            $insertions.Add([PSCustomObject]@{ Index = $reviewerAnchor + 1; Lines = $reviewerExtraLines })
        }

        $mentionIndent = if ($mentionItemIndent -ge 0) { $mentionItemIndent } else { $listIndentLength + 4 }
        $mentionExtraLines = [System.Collections.Generic.List[string]]::new()
        for ($t = 0; $t -lt $targets.Count; $t++) {
            $mentionTeam = NormalizeMentioneeValue -Mentionee $targets[$t]
            if ($t -lt $mentioneeSquadLines.Count) {
                $lineIndex = $mentioneeSquadLines[$t]
                $indent = " " * (GetIndentLength -Line $work[$lineIndex])
                $work[$lineIndex] = "${indent}- $mentionTeam"
            } elseif ($hasMentionees -and $lastMentionLine -ge 0) {
                $mentionExtraLines.Add((" " * $mentionIndent) + "- $mentionTeam")
            }
        }
        if ($mentionExtraLines.Count -gt 0) {
            $insertions.Add([PSCustomObject]@{ Index = $lastMentionLine + 1; Lines = $mentionExtraLines })
        }
    }

    if ($insertions.Count -eq 0) {
        return $work.ToArray()
    }

    $sortedInsertions = $insertions | Sort-Object Index -Descending
    foreach ($insertion in $sortedInsertions) {
        $work.InsertRange($insertion.Index, $insertion.Lines)
    }

    return $work.ToArray()
}

$labelToSquad = GetSquadMapping -AccessToken $AccessToken
if ($labelToSquad.Count -eq 0) { throw "No squad mappings found." }

$yamlConfigPath = $PSScriptRoot | Split-Path | Split-Path | Join-Path -ChildPath ".github" | Join-Path -ChildPath "policies" | Join-Path -ChildPath "resourceManagement.yml"
$yamlContent = [System.IO.File]::ReadAllText($yamlConfigPath)
$lineEnding = "`n"
if ($yamlContent.Contains("`r`n")) { $lineEnding = "`r`n" }
$endsWithNewline = $yamlContent.EndsWith("`n")
$yamlLines = [regex]::Split($yamlContent, "\r?\n", [System.Text.RegularExpressions.RegexOptions]::None)
$updatedLines = AddSquadLabelsToYaml -Lines $yamlLines -LabelToSquad $labelToSquad
$updatedLines = NormalizeSquadTeamForms -Lines $updatedLines
$updatedContent = [string]::Join($lineEnding, $updatedLines)
if (-not $endsWithNewline -and $updatedContent.EndsWith($lineEnding)) { $updatedContent = $updatedContent.Substring(0, $updatedContent.Length - $lineEnding.Length) }
[System.IO.File]::WriteAllText($yamlConfigPath, $updatedContent)
