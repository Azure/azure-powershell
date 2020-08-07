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

function ConvertTagHashtableToString {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory)]
        [hashtable]
        $TagHashtable
    )

    $keys = $TagHashtable.Keys
    $tagStrings = foreach ($key in $keys) {
        $tag = $key
        if ($TagHashtable[$key] -and $TagHashtable[$key].GetType() -eq [string]) {
            $tag += "=$($TagHashtable[$key])"
        }
        $tag
    }

    return [string]::Join(',', $tagStrings)
}

filter HandleShowResult {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory, ValueFromPipeline)]
        [string]
        $ShowResult,

        [Parameter(Mandatory)]
        [string]
        $ResourceGroupName,

        [Parameter(Mandatory)]
        [string]
        $SubscriptionId
    )

    # Get name of machine registered
    $selectStrResult = $ShowResult | Select-String -Pattern "^Resource Name\s+:(?<resourceName>.*)\n"
    $Name = $selectStrResult.Matches.Groups |
        Where-Object Name -EQ resourceName |
        Select-Object -ExpandProperty Value

    # Return the ConnectedMachine object.
    Get-AzConnectedMachine -Name $Name -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId
}
