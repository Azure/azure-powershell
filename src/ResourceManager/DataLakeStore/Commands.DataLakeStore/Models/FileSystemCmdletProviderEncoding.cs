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

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    // This is a copy of Microsoft.PowerShell.Commands. This enum no longer exists in .NET Core.
    // TODO: Proper fix to be done in https://github.com/Azure/azure-powershell/issues/5742
    public enum FileSystemCmdletProviderEncoding
    {
        Unknown = 0,
        String = 1,
        Unicode = 2,
        Byte = 3,
        BigEndianUnicode = 4,
        UTF8 = 5,
        UTF7 = 6,
        UTF32 = 7,
        Ascii = 8,
        Default = 9,
        Oem = 10,
        BigEndianUTF32 = 11
    }
}
