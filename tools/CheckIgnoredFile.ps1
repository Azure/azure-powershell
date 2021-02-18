# ----------------------------------------------------------------------------------
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

$ignoredFiles = @(
    "src/DataFactory/DataFactoryV2.Test/SessionRecords/Microsoft.Azure.Commands.DataFactoryV2.Test.RunTests/TestRunV2.json"
)
$hasIssue = $false
foreach($file in $ignoredFiles) {
    if(Test-Path $file) {
        Write-Warning ("Contains: " + $file)
        $hasIssue = $true
    }
}

if($hasIssue) {
    throw "Above file(s) should be removed."
}