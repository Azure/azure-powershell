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

function Test-ListTagWithPagination
{
    $tag = Get-AzTag
    Assert-AreEqual 63 $tag.Length
    # there are two pages of tags in the test data, each has 32 tags, 1 overlapping

    Assert-AreEqual "tag1" $tag[0].Name
    Assert-AreEqual "tag63" $tag[-1].Name
}

function Test-ListTagWithoutPagination
{
    $tag = Get-AzTag

    Assert-AreEqual 32 $tag.Length

    Assert-AreEqual "tag1" $tag[0].Name
    Assert-AreEqual "tag32" $tag[-1].Name
}
