# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.internal
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

# This file is a temporary approach to prompt the user for a survey.
# It doesn't cover every case well or not tested well:
# 1. Allow two or more modules to show the survey link.
# 2. When the major version is changed.
# 3. Not sure about the way to handle survey id or if it's needed in future.
# 4. The file format is also subject to change in future.

$escape = $([char]27)
    Write-Host "`n$escape[7mHow was your experience using Az.Compute?      $escape[27m`n" -NoNewline; Write-Host "$escape[7mhttp://aka.ms/azcomputesurvey$escape[27m" -NoNewline
    Write-Host "`n"