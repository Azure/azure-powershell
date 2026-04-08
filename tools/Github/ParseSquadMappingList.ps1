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

    $insertions = [System.Collections.Generic.List[object]]::new()

    for ($i = 0; $i -lt $Lines.Count; $i++) {
        $line = $Lines[$i]
        if ($line -match '^\s*(then|actions):\s*$') {
            $baseIndentLength = GetIndentLength -Line $line
            $labelsFromConditions = GetLabelsFromConditions -Lines $Lines -ThenLineIndex $i -BaseIndentLength $baseIndentLength
            $j = $i + 1
            while ($j -lt $Lines.Count -and $Lines[$j].Trim().Length -eq 0) { $j++ }
            if ($j -ge $Lines.Count) { continue }

            $listLine = $Lines[$j]
            $listIndentLength = GetIndentLength -Line $listLine
            if ($listIndentLength -lt $baseIndentLength -or -not ($listLine -match '^\s*-\s+')) { continue }

            $k = $j
            while ($k -lt $Lines.Count) {
                $lineAtK = $Lines[$k]
                if ($lineAtK.Trim().Length -ne 0 -and (GetIndentLength -Line $lineAtK) -lt $baseIndentLength) { break }
                if ($lineAtK -match '^\s*description:' -and (GetIndentLength -Line $lineAtK) -eq $baseIndentLength) { break }
                $k++
            }

            $labelsPresent = @{}
            $lastAddLabelEnd = -1
            for ($b = $j; $b -lt $k; $b++) {
                $lineAtB = $Lines[$b]
                if ($lineAtB -match '^\s*-\s+addLabel:\s*$' -and (GetIndentLength -Line $lineAtB) -eq $listIndentLength) {
                    $labelValue = $null
                    for ($c = $b + 1; $c -lt $k; $c++) {
                        $lineAtC = $Lines[$c]
                        if ($lineAtC -match '^\s*-\s+' -and (GetIndentLength -Line $lineAtC) -eq $listIndentLength) { break }
                        $labelValue = TryParseLabelValue -Line $lineAtC
                        if ($null -ne $labelValue) { $lastAddLabelEnd = $c; break }
                    }
                    if (![string]::IsNullOrWhiteSpace($labelValue)) { $labelsPresent[$labelValue] = $true }
                }
            }

            foreach ($condLabel in $labelsFromConditions) {
                if (-not [string]::IsNullOrWhiteSpace($condLabel)) { $labelsPresent[$condLabel] = $true }
            }

            $labelsToAdd = [System.Collections.Generic.List[string]]::new()
            $sortedLabels = $labelsPresent.Keys | Sort-Object -CaseSensitive
            foreach ($label in $sortedLabels) {
                if ($LabelToSquad.ContainsKey($label)) {
                    $squadLabel = $LabelToSquad[$label]
                    if (-not $labelsPresent.ContainsKey($squadLabel) -and -not $labelsToAdd.Contains($squadLabel)) {
                        $labelsToAdd.Add($squadLabel)
                    }
                }
            }

            if ($labelsToAdd.Count -gt 0) {
                if ($lastAddLabelEnd -lt 0) { $lastAddLabelEnd = $k - 1 }
                if ($lastAddLabelEnd -ge 0) {
                    $insertLines = [System.Collections.Generic.List[string]]::new()
                    foreach ($squadLabel in $labelsToAdd) {
                        $insertLines.Add((" " * $listIndentLength) + "- addLabel:")
                        $insertLines.Add((" " * $listIndentLength) + "    label: $squadLabel")
                    }
                    $insertions.Add([PSCustomObject]@{ Index = $lastAddLabelEnd + 1; Lines = $insertLines })
                }

                $isPR = $false
                for ($p = $i - 1; $p -ge 0; $p--) {
                    if ($Lines[$p] -match '^\s*description:') { break }
                    if ($Lines[$p] -match 'payloadType:\s*Pull_Request') { $isPR = $true; break }
                }
                if ($isPR) {
                    $lastReviewEnd = -1
                    $reviewIndent = $listIndentLength + 4
                    $existingReviewers = @{}
                    for ($b = $j; $b -lt $k; $b++) {
                        if ($Lines[$b] -match '^\s*-\s+requestReview:\s*$' -and (GetIndentLength -Line $Lines[$b]) -eq $listIndentLength) {
                            for ($c = $b + 1; $c -lt $k; $c++) {
                                if ($Lines[$c] -match '^\s*-\s+' -and (GetIndentLength -Line $Lines[$c]) -eq $listIndentLength) { break }
                                if ($Lines[$c] -match '^\s*reviewer:\s*(\S+)\s*$') {
                                    $existingReviewers[$Matches[1]] = $true
                                    $lastReviewEnd = $c
                                }
                            }
                        }
                    }
                    if ($lastReviewEnd -lt 0) { $lastReviewEnd = $lastAddLabelEnd }
                    if ($lastReviewEnd -lt 0) { $lastReviewEnd = $k - 1 }
                    if ($lastReviewEnd -ge 0) {
                        $reviewInsertLines = [System.Collections.Generic.List[string]]::new()
                        foreach ($squadLabel in $labelsToAdd) {
                            if (-not $existingReviewers.ContainsKey($squadLabel)) {
                                $reviewInsertLines.Add((" " * $listIndentLength) + "- requestReview:")
                                $reviewInsertLines.Add((" " * $reviewIndent) + "reviewer: $squadLabel")
                            }
                        }
                        if ($reviewInsertLines.Count -gt 0) {
                            $insertions.Add([PSCustomObject]@{ Index = $lastReviewEnd + 1; Lines = $reviewInsertLines })
                        }
                    }
                }

                $mentionUsersIndex = -1
                $mentioneesIndent = -1
                $mentionItemIndent = -1
                $existingMentions = @{}
                $lastMentionEnd = -1
                for ($b = $j; $b -lt $k; $b++) {
                    $lineAtB = $Lines[$b]
                    $indentAtB = GetIndentLength -Line $lineAtB
                    if ($lineAtB -match '^\s*-\s+mentionUsers:\s*$' -and $indentAtB -eq $listIndentLength) { $mentionUsersIndex = $b; continue }
                    if ($mentionUsersIndex -ge 0) {
                        if ($lineAtB.Trim().Length -ne 0 -and $indentAtB -le $listIndentLength -and $lineAtB -match '^\s*-\s+') { break }
                        if ($lineAtB -match '^\s*mentionees:\s*$') { $mentioneesIndent = $indentAtB; continue }
                        if ($lineAtB -match '^\s*-\s+(\S+)\s*$') {
                            if ($mentionItemIndent -lt 0) { $mentionItemIndent = $indentAtB }
                            $existingMention = $Matches[1]
                            $existingMentions[$existingMention] = $true
                            $existingMentions[(NormalizeMentioneeValue -Mentionee $existingMention)] = $true
                            $lastMentionEnd = $b
                        }
                    }
                }
                if ($mentionUsersIndex -ge 0 -and $lastMentionEnd -ge 0) {
                    if ($mentionItemIndent -lt 0) { $mentionItemIndent = ($mentioneesIndent -gt 0) ? $mentioneesIndent : ($listIndentLength + 4) }
                    $mentionInsertLines = [System.Collections.Generic.List[string]]::new()
                    foreach ($squadLabel in $labelsToAdd) {
                        $mentioneeValue = NormalizeMentioneeValue -Mentionee $squadLabel
                        if (-not $existingMentions.ContainsKey($mentioneeValue)) {
                            $mentionInsertLines.Add((" " * $mentionItemIndent) + "- $mentioneeValue")
                        }
                    }
                    if ($mentionInsertLines.Count -gt 0) {
                        $insertions.Add([PSCustomObject]@{ Index = $lastMentionEnd + 1; Lines = $mentionInsertLines })
                    }
                }
            }
        }
    }

    if ($insertions.Count -eq 0) { return $Lines }
    $sortedInsertions = $insertions | Sort-Object Index -Descending
    $lineList = [System.Collections.Generic.List[string]]::new(); $lineList.AddRange($Lines)
    foreach ($insertion in $sortedInsertions) { $lineList.InsertRange($insertion.Index, $insertion.Lines) }
    return $lineList.ToArray()
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
$updatedContent = [string]::Join($lineEnding, $updatedLines)
if (-not $endsWithNewline -and $updatedContent.EndsWith($lineEnding)) { $updatedContent = $updatedContent.Substring(0, $updatedContent.Length - $lineEnding.Length) }
[System.IO.File]::WriteAllText($yamlConfigPath, $updatedContent)
