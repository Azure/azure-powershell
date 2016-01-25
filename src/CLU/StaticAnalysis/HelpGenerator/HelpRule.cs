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

namespace StaticAnalysis.HelpGenerator
{
    public abstract class HelpRule<T>
    {
        public void Apply(T helpTarget)
        {
            if (Match(helpTarget))
            {
                ApplyRule(helpTarget);
            }
            else if (Inner != null)
            {
                Inner.Apply(helpTarget);
            }
        }

        public abstract bool Match(T helpTarget);
        public abstract void ApplyRule(T helpTarget);
        public HelpRule<T> Inner { get; private set; }

        public static HelpRule<T> CreateChain(params HelpRule<T>[] rules)
        {
            if (rules == null || rules.Length < 1)
            {
                throw new ArgumentException("You must pass one or more rules");
            }
            var current = rules[0];
            for (int i = 1; i < rules.Length; ++i)
            {
                current.Inner = rules[i];
                current = current.Inner;
            }

            return rules[0];
        }
    }
}
