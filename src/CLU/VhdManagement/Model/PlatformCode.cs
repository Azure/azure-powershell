// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    public enum PlatformCode
    {
        None = 0x0,
        Wi2R = 0x57693272,
        Wi2K = 0x5769326B,
        W2Ru = 0x57327275,
        W2Ku = 0x57326B75,
        Mac = 0x4D616320,
        MacX = 0x4D616358
    }
}