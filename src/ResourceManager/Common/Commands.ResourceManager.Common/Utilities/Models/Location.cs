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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Utilities.Models
{
    public class LocationConstraint
    {
        ICollection<string> _locations = new List<string>();

        public LocationConstraint(params string[] locations)
        {
            foreach (var inputLocation in locations)
            {
                if (string.IsNullOrEmpty(inputLocation))
                {
                    throw new ArgumentNullException(nameof(inputLocation));
                }

                _locations.Add(Canonicalize(inputLocation));
            }
        }
        static string Canonicalize(string input)
        {
            var builder = new StringBuilder();
            var skipChars = new[] { ' ', '-' };
            foreach (char c in input.ToLowerInvariant())
            {
                if (!skipChars.Contains(c))
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }

        public bool Match(string other)
        {
            if (!string.IsNullOrWhiteSpace(other))
            {

                var canonical = Canonicalize(other);
                foreach (var location in _locations)
                {
                    if (string.Equals(location, canonical, StringComparison.Ordinal))
                    {
                        return true;
                    }
                }
            }

            return _locations.Count == 0;
        }
    }
}
