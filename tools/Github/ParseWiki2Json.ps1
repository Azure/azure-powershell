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

<#
.SYNOPSIS
    Sync ADO wiki aliases content to fabricbot.json.

#>
param(
    [Parameter(Mandatory = $true)]
    [string]$ADOToken
)

# get wiki content
$username = ""
$password = $ADOToken
$pair = "{0}:{1}" -f ($username, $password)
$bytes = [System.Text.Encoding]::ASCII.GetBytes($pair)
$token = [System.Convert]::ToBase64String($bytes)
$headers = @{
    Authorization = "Basic {0}" -f ($token)
}

$response = Invoke-RestMethod 'https://dev.azure.com/azure-sdk/internal/_apis/wiki/wikis/internal.wiki/pages?path=/Engineering%20System/GitHub%20Repos/Issue%20Management/Service%20Team%20Label%20and%20Contact%20List&includeContent=True' -Headers $headers
$rows = ($response.content -split "\n") | Where-Object { $_ -like '|*' } | Select-Object -Skip 2
$aliases = [System.Collections.SortedList]::new()

foreach ($item in $rows) {
    $list = $item -split "\|"
    if ($list.Count -eq 1) { continue }
    if ($list[1].Trim().Length -gt 0) {
        if ($list.Count -gt 3) {
            $aliases.Add($list[1].Trim(), $list[3].Trim())
        }
        else {
            $aliases.Add($list[1].Trim(), "")
        }
    }
}

# change json file
$WholeJson = Get-Content -Raw -Path .github/fabricbot.json | ConvertFrom-Json

$WholeJson.tasks | ForEach-Object {
    if ($_.taskType -eq 'scheduledAndTrigger') {
        $labelsAndMentionsArrayList = New-Object System.Collections.ArrayList
        foreach ($entry in $aliases.GetEnumerator()) {
            if ($entry.Value -eq "") {
                continue
            }
            $labels = @("Service Attention", $entry.Key)
            $mentionees = @($entry.Value -split "," | ForEach-Object { $_.Trim() })
            $item = [PSCustomObject]@{
                labels     = $labels
                mentionees = $mentionees
            }
            [void]$labelsAndMentionsArrayList.Add($item)
        }
        $_.config.labelsAndMentions = $labelsAndMentionsArrayList.ToArray()
    }
}

($WholeJson | ConvertTo-Json -Depth 32) | Out-File  -FilePath .github/fabricbot.json
