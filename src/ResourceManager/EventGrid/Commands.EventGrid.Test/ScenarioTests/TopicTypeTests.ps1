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
Tests EventGrid TopicType operations.
#>
function TopicTypeTests_Operations {
    Write-Debug "Getting topic types"
    $topicTypes = Get-AzureRmEventGridTopicType
    Assert-True {$topicTypes.Count -ge 3}

    $storage = "Microsoft.Storage.StorageAccounts"

    Write-Debug "Getting topic type info for Storage"
    $returnedTopicTypes1 = Get-AzureRmEventGridTopicType -Name $storage
    Assert-True {$returnedTopicTypes1.Count -eq 1}
    Assert-True {$returnedTopicTypes1[0].TopicTypeName -eq $storage}
    Assert-True {$returnedTopicTypes1[0].EventTypes -eq $null}

    Write-Debug "Getting topic type info for Storage, with event types"
    $returnedTopicTypes2 = Get-AzureRmEventGridTopicType -Name $storage -IncludeEventTypeData
    Assert-True {$returnedTopicTypes2.Count -eq 1}
    Assert-True {$returnedTopicTypes2[0].TopicTypeName -eq $storage}
    Assert-True {$returnedTopicTypes2[0].EventTypes -ne $null}
    Assert-True {$returnedTopicTypes2[0].EventTypes.Count -ge 1}
}
