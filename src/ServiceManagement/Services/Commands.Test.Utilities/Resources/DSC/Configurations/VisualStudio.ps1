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

Configuration VisualStudio
{
    Import-DscResource -ModuleName xPSDesiredStateConfiguration
    Node localhost {
        xPackage VS
        {
            Ensure="Present"
            Name = "Microsoft Visual Studio Ultimate 2013"
            Path = "\\products\public\PRODUCTS\Developers\Visual Studio 2013\ultimate\vs_ultimate.exe"
            Arguments = "/quiet /noweb /Log c:\temp\vc.log"
            ProductId = ""
        }
    }
}

. VisualStudio