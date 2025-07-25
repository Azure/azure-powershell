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
    Sync ADO Wiki Service Contact List to resourceManagement.yml.

#>
param(
    [Parameter(Mandatory = $true)]
    [string] $AccessToken
)

function InitializeRequiredPackages {
    [CmdletBinding()]
    param ()

    $pkgYaml = Get-Package -Name YamlDotNet | Select-Object -ExpandProperty Source | Split-Path
    $dllYaml = Join-Path -Path $pkgYaml -ChildPath "lib" | Join-Path -ChildPath "netstandard2.0" | Join-Path -ChildPath "YamlDotNet.dll"
    Add-Type -LiteralPath $dllYaml
}

$ErrorActionPreference = "Stop"

# get wiki content
$username = ""
$password = $AccessToken
$pair = "{0}:{1}" -f ($username, $password)
$bytes = [System.Text.Encoding]::ASCII.GetBytes($pair)
$token = [System.Convert]::ToBase64String($bytes)
$headers = @{
    Authorization = "Basic {0}" -f ($token)
}

try {
    $response = Invoke-RestMethod ${env:ServiceContactsListUrl} -Headers $headers -ErrorAction Stop
    $contactsList = ($response.content -split "\n") | Where-Object { $_ -like '|*' } | Select-Object -Skip 2

    if ($null -ne $contactsList) {
        $idxServiceTeamLabel = 2
        $idxPSNotifyGithubHandler = 6
        $serviceContacts = [System.Collections.Generic.SortedList[System.String, PSCustomObject]]::new()

        foreach ($contacts in $contactsList) {
            $items = $contacts -split "\|"
            $colServiceTeamLabel = $items[$idxServiceTeamLabel]
            if (![string]::IsNullOrWhiteSpace($colServiceTeamLabel)) {
                $serviceTeamLabel = $colServiceTeamLabel.Trim()
                $colPSNotifyGithubHandler = $items[$idxPSNotifyGithubHandler]

                if (![string]::IsNullOrWhiteSpace($colPSNotifyGithubHandler)) {
                    $psNotifyGithubHandler = $colPSNotifyGithubHandler.Trim()
                    [array]$mentionees = $psNotifyGithubHandler.Split(",", [StringSplitOptions]::RemoveEmptyEntries) | ForEach-Object {
                        $_.Trim()
                    }

                    $serviceContacts.Add($serviceTeamLabel, [PSCustomObject]@{
                            if   = @(
                                [PSCustomObject]@{
                                    or = @(
                                        [PSCustomObject]@{
                                            labelAdded = [PSCustomObject]@{
                                                label = 'Service Attention'
                                            }
                                        },
                                        [PSCustomObject]@{
                                            labelAdded = [PSCustomObject]@{
                                                label = $serviceTeamLabel
                                            }
                                        }
                                    )
                                },
                                [PSCustomObject]@{
                                    hasLabel = [PSCustomObject]@{
                                        label = 'Service Attention'
                                    }
                                },
                                [PSCustomObject]@{
                                    hasLabel = [PSCustomObject]@{
                                        label = $serviceTeamLabel
                                    }
                                }
                            )
                            then = @(
                                [PSCustomObject]@{
                                    mentionUsers = [PSCustomObject]@{
                                        mentionees       = $mentionees
                                        replyTemplate    = 'Thanks for the feedback! We are routing this to the appropriate team for follow-up. cc ${mentionees}.'
                                        assignMentionees = 'False'
                                    }
                                }
                            )
                        })
                }
            }
        }
    }

    # Update yaml file
    InitializeRequiredPackages

    $yamlConfigPath = $PSScriptRoot | Split-Path | Split-Path | Join-Path -ChildPath ".github" | Join-Path -ChildPath "policies" | Join-Path -ChildPath "resourceManagement.yml"
    $yamlContent = Get-Content -Path $yamlConfigPath -Raw
    $yamlDeserializer = [YamlDotNet.Serialization.DeserializerBuilder]::new().Build()
    $yamlObjectGraph = $yamlDeserializer.Deserialize($yamlContent)
    $jsonSerializer = [YamlDotNet.Serialization.SerializerBuilder]::new().JsonCompatible().Build()
    $jsonObjectGraph = $jsonSerializer.Serialize($yamlObjectGraph) | ConvertFrom-Json

    $serviceContactsTask = $jsonObjectGraph.configuration.resourceManagementConfiguration.eventResponderTasks | Where-Object { $_.description -eq "Triage issues to the service team" }
    if ($null -ne $serviceContactsTask) {
        $serviceContactsTask.then = $serviceContacts.Values
    }

    $updatedJsonContent = $jsonObjectGraph | ConvertTo-Json -Depth 64
    $updatedJsonObjectGraph = [Newtonsoft.Json.JsonConvert]::DeserializeObject[System.Dynamic.ExpandoObject]($updatedJsonContent)
    $yamlSerializer = [YamlDotNet.Serialization.SerializerBuilder]::new().Build()
    $updatedYamlContent = $yamlSerializer.Serialize($updatedJsonObjectGraph)
    $updatedYamlContent | Out-File -FilePath $yamlConfigPath -NoNewline -Force

    # Remove trailing space on each line
    (Get-Content -Path $yamlConfigPath) | ForEach-Object { $_.TrimEnd() } | Set-Content -Path $yamlConfigPath
}
catch {
    Write-Error "Error occurred while updating the resourceManagement.yml file. Error Message: $($_.Exception.Message)"
    throw
}
