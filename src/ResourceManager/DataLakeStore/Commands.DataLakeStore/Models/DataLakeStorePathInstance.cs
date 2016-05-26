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

using Microsoft.Azure.Commands.DataLakeStore.Properties;
using System;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// The object that is passed in and parsed for all Data Lake paths.
    /// </summary>
    public class DataLakeStorePathInstance
    {
        public string TransformedPath { get; set; }
        public string OriginalPath { get; set; }

        public static DataLakeStorePathInstance Parse(string path)
        {
            // reverse all slashes to the correct slash type
            path = path.Replace('\\', '/');

            // all paths must start with a slash and be account relative.
            if (!path.StartsWith("/"))
            {
                throw new ArgumentException(string.Format(Resources.InvalidPath, path));
            }

            return new DataLakeStorePathInstance
            {
                TransformedPath = path.TrimStart('/').TrimEnd('/'),
                OriginalPath = path // return the original path they gave
            };
        }
    }
}