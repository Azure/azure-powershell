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

using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.Compute
{
    public sealed class ImageVersion
    {
        public string Original { get; }

        public ulong[] Parts { get; }

        ImageVersion(string original, ulong[] parts)
        {
            Original = original;
            Parts = parts;
        }

        public int CompareTo(ImageVersion version)
        {
            var sign = Parts
                .Zip(version.Parts, (a, b) => a.CompareTo(b))
                .FirstOrDefault(s => s != 0);
            return sign == 0 ? Parts.Length.CompareTo(version.Parts.Length) : sign;
        }

        public static ImageVersion Parse(string version)
            => new ImageVersion(version, version.Split('.').Select(ulong.Parse).ToArray());

        public override string ToString()
            => Original;
    }
}
