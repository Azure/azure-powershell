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
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MS.Test.Common.MsTestLib
{

    public class TestMethodUnit
    {
        private MethodInfo m_testCase;

        private TestMethodAttribute m_attr;

        private TimeoutAttribute m_timeoutAttr;
        private IList<string> m_tagAttrs;

        private IgnoreAttribute m_ignoreAttr;

        private bool enable;

        public bool Enable
        {
            get { return enable; }
            set { enable = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Timeout
        {
            get
            {
                if (m_timeoutAttr != null)
                {
                    return m_timeoutAttr.Timeout;
                }
                else
                {
                    return int.MaxValue;
                }

            }
        }

        public bool Ignore
        {
            get
            {
                if (m_ignoreAttr != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IList<string> Tag
        {
            get
            {
                return m_tagAttrs;
            }
        }


        public static TestMethodUnit[] GetTestCaseUnits(Type type)
        {

            List<TestMethodUnit> testCases = new List<TestMethodUnit>();
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                if (null != GetTestMethodAttribute<TestMethodAttribute>(methodInfo))
                {
                    testCases.Add(new TestMethodUnit(methodInfo));
                }
            }

            return testCases.ToArray();
        }

        private TestMethodUnit(MethodInfo testCase)
        {
            m_testCase = testCase;
            name = testCase.Name;
            m_tagAttrs = new List<string>();

            foreach (Attribute attr in testCase.GetCustomAttributes(true))
            {
                if (null != (attr as TestMethodAttribute))
                {
                    m_attr= (TestMethodAttribute) attr;
                }

                if (null != (attr as TimeoutAttribute))
                {
                    m_timeoutAttr=(TimeoutAttribute) attr;
                }

                if (null != (attr as TestCategoryAttribute))
                {
                    m_tagAttrs.Add (((TestCategoryAttribute) attr).TestCategories[0]);
                }

                if (null != (attr as IgnoreAttribute))
                {
                    m_ignoreAttr = (IgnoreAttribute) attr;
                }

            }

            //default is all enabled if not ignored
            if (Ignore)
            {
                enable = false;
            }
            else
            {
                enable = true;
            }
        }

        static private T GetTestMethodAttribute<T>(MethodInfo method) where T:Attribute
        {
            T testCaseAttr = null;
            foreach (Attribute attr in method.GetCustomAttributes(true))
            {
                testCaseAttr = attr as T;
                if (null != testCaseAttr)
                {
                    return testCaseAttr;
                }
            }
            return null;
        }
                
        static public MethodInfo GetAssemblyInitMethod(Type type)
        {
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                foreach (Attribute attr in methodInfo.GetCustomAttributes(true))
                {
                    if ((attr as AssemblyInitializeAttribute) != null)
                    {
                        return methodInfo;
                    }
                }
            }

            return null;

        }

        static public MethodInfo GetAssemblyCleanMethod(Type type)
        {
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                foreach (Attribute attr in methodInfo.GetCustomAttributes(true))
                {
                    if ((attr as AssemblyCleanupAttribute) != null)
                    {
                        return methodInfo;
                    }
                }
            }

            return null;

        }

        static public MethodInfo GetClassInitMethod(Type type)
        {
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                foreach (Attribute attr in methodInfo.GetCustomAttributes(true))
                {
                    if ((attr as ClassInitializeAttribute) != null)
                    {
                        return methodInfo;
                    }
                }
            }

            return null;

        }

        static public MethodInfo GetClassCleanupMethod(Type type)
        {
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                foreach (Attribute attr in methodInfo.GetCustomAttributes(true))
                {
                    if ((attr as ClassCleanupAttribute) != null)
                    {
                        return methodInfo;
                    }
                }
            }

            return null;

        }

        static public MethodInfo GetTestInitMethod(Type type)
        {
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                foreach (Attribute attr in methodInfo.GetCustomAttributes(true))
                {
                    if ((attr as TestInitializeAttribute) != null)
                    {
                        return methodInfo;
                    }
                }
            }

            return null;

        }

        static public MethodInfo GetTestCleanupMethod(Type type)
        {
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                foreach (Attribute attr in methodInfo.GetCustomAttributes(true))
                {
                    if ((attr as TestCleanupAttribute) != null)
                    {
                        return methodInfo;
                    }
                }
            }

            return null;

        }






        public MethodInfo TestCase
        {
            get
            {
                return m_testCase;
            }
        }

        public TestMethodAttribute Attribute
        {
            get
            {
                return m_attr;
            }
        }


    }

}
