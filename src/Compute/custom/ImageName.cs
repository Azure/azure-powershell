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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.Compute
{
    public struct ImageName : IArgumentCompleter, IEquatable<ImageName>
    {
        public static ImageName CentOS = "CentOS";
        public static ImageName CoreOS = "CoreOS";
        public static ImageName Debian = "Debian";
        public static ImageName openSUSE_Leap = "openSUSE-Leap";
        public static ImageName RHEL = "RHEL";
        public static ImageName SLES = "SLES";
        public static ImageName UbuntuLTS = "UbuntuLTS";
        public static ImageName Win2016Datacenter = "Win2016Datacenter";
        public static ImageName Win2012R2Datacenter = "Win2012R2Datacenter";
        public static ImageName Win2012Datacenter = "Win2012Datacenter";
        public static ImageName Win2008R2SP1 = "Win2008R2SP1";
        public static ImageName Win10 = "Win10";

        private string _value { get; set; }

        private ImageName (string other)
        {
            _value = other;
        }

        internal static object CreateFrom(object value)
        {
            return new ImageName(Convert.ToString(value));
        }


        public static bool operator !=(ImageName s, ImageName t)
        {
            return !s.Equals(t);
        }
        public static bool operator ==(ImageName s, ImageName t)
        {
            return s.Equals(t);
        }

        public static implicit operator String(ImageName name)
        {
            return name._value;
        }

        public static implicit operator ImageName(string value)
        {
            return new ImageName(value);
        }

        public IEnumerable<CompletionResult> CompleteArgument(string commandName, string parameterName, string wordToComplete, CommandAst commandAst, IDictionary fakeBoundParameters)
        {
            string[] args = new[] { "CentOS",
            "CoreOS",
            "Debian",
            "openSUSE-Leap",
            "RHEL",
            "SLES",
            "UbuntuLTS",
            "Win2016Datacenter",
            "Win2012R2Datacenter",
            "Win2012Datacenter",
            "Win2008R2SP1",
            "Win10"};

            foreach (var entry in args)
            {
                if (string.IsNullOrWhiteSpace(wordToComplete) || entry.ToLower().StartsWith(wordToComplete.ToLower()))
                {
                    yield return new CompletionResult(entry, entry, CompletionResultType.ParameterValue, string.Empty);
                }
            }
        }

        public override string ToString()
        {
            return _value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is ImageName && Equals((ImageName)obj);
        }

        public bool Equals(ImageName other)
        {
            return string.Equals(_value, other._value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
