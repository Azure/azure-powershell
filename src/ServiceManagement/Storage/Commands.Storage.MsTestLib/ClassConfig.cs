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

using System.Collections.Generic;

namespace MS.Test.Common.MsTestLib
{

    public class ClassConfig
    {
        public ClassConfig()
        {
            classParams = new Dictionary<string, string>();
            classMethods = new Dictionary<string, MethodConfig>();
        }

        private Dictionary<string, string> classParams;

        public Dictionary<string, string> ClassParams
        {
            get { return classParams; }
            set { classParams = value; }
        }

        private Dictionary<string, MethodConfig> classMethods;

        public MethodConfig this[string methodName]
        {
            get
            {
                if (classMethods.ContainsKey(methodName))
                {
                    return classMethods[methodName];
                }
                else
                {
                    return null;
                }
            }

            set
            {
                classMethods[methodName] = value;
            }

        }

    }

}
