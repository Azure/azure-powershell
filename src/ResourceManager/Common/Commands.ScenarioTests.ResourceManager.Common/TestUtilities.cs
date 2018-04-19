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

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.ScenarioTest
{
    public static class TestUtilities
    {
        /// <summary> 
        /// Get the method name of the calling method 
        /// </summary> 
        /// <param name="index">How deep into the strack trace to look - here we want the caller's caller.</param> 
        /// <returns>The name of the declaring method</returns> 
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethodName(int index = 1)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(index);


            return sf.GetMethod().Name;
        }

        /// <summary> 
        /// Get the typename of the callling class 
        /// </summary> 
        /// <param name="index">How deep into the strack trace to look - here we want the caller's caller.</param> 
        /// <returns>The name of the declaring type</returns> 
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCallingClass(int index = 1)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(index);


            return sf.GetMethod().ReflectedType.ToString();
        }
    }
}
