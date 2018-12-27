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

using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd
{
    /// <summary>
    /// A stream with additional extent information.
    /// </summary>
    /// <remarks>
    /// Extent information reveals the ranges of the stream that contain non-zero data.  Clients may use 
    /// the extent information to optimize reads to the stream.   The stream supports reads over any range,
    /// regardless of the extents.
    /// </remarks>
    public abstract class SparseStream : Stream
    {
        public abstract IEnumerable<StreamExtent> Extents { get; }
    }

    /// <summary>
    /// An extent.
    /// </summary>
    public struct StreamExtent
    {
        public Guid Owner;
        public long StartOffset;
        public long EndOffset;

        public long Length
        {
            get
            {
                return (this.EndOffset - this.StartOffset) + 1;
            }
        }

        public IndexRange Range { get; set; }
    }
}
