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

using System;
using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication.ResourceManager
{
    /// <summary>
    /// Interface that allows abstracting away file access - allows for using specially protected files, or files from alternate sources
    /// </summary>
    public interface IFileProvider : IDisposable
    {
        string FilePath { get; }
        Stream Stream { get; }
        StreamReader Reader { get; }
        StreamWriter Writer { get; }
    }
}
