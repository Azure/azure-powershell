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

using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public static class TestUtilities
    {
        public static string GenerateName(string prefix = "azsmnet", [CallerMemberName] string methodName = "testframework_failed")
        {
            return HttpMockServer.GetAssetName(methodName, prefix);
        }

        public static Guid GenerateGuid([CallerMemberName] string methodName = "testframework_failed")
        {
            return HttpMockServer.GetAssetGuid(methodName);
        }

        public static void Wait(int milliseconds)
        {
            Wait(TimeSpan.FromMilliseconds(milliseconds));
        }

        public static void Wait(TimeSpan timeout)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                Thread.Sleep(timeout);
            }
        }

        public static string GetCurrentMethodName([CallerMemberName] string methodName = "testframework_failed_to_get_current_method_anem")
        {
            return methodName;
        }

#if NET452

        [MethodImpl(MethodImplOptions.NoInlining)] 
        public static string GetCurrentMethodName(int index = 1)
        { 
            StackTrace st = new StackTrace(); 
            StackFrame sf = st.GetFrame(index); 
 

            return sf.GetMethod().Name; 
        } 
 
        [MethodImpl(MethodImplOptions.NoInlining)] 
        public static string GetCallingClass(int index = 1)
        { 
            StackTrace st = new StackTrace(); 
            StackFrame sf = st.GetFrame(index); 
 

            return sf.GetMethod().ReflectedType.ToString(); 
        } 

#endif

        public static IDictionary<string, string> ParseConnectionString(string connectionString)
        {
            // Temporary connection string parser.  We should replace with more robust one
            IDictionary<string, string> settings = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(connectionString))
            {
                string[] pairs = connectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    foreach (string pair in pairs)
                    {
                        string[] keyValue = pair.Split(new char[] { '=' }, 2);
                        string key = keyValue[0].Trim();
                        string value = keyValue[1].Trim();
                        settings[key] = value;
                    }

                }
                catch (NullReferenceException ex)
                {
                    throw new ArgumentException(
                        string.Format("Connection string \"{0}\" is invalid", connectionString),
                        "connectionString", ex);
                }
            }
            return settings;
        }
    }
}
