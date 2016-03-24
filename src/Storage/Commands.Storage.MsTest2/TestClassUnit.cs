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

    public class TestClassUnit
    {
        private Type m_testGroupClass;
        private TestClassAttribute m_attr;
        private IgnoreAttribute m_ignoreAttr;
        private TestMethodUnit[] m_testCaseUnits;

        public MethodInfo AssemblyInitMethod = null;
        public MethodInfo AssemblyCleanupMethod = null;

        public MethodInfo ClassInitMethod = null;
        public MethodInfo ClassCleanupMethod = null;

        public MethodInfo TestInitMethod = null;
        public MethodInfo TestCleanupMethod = null;

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

        private bool enable;

        public bool Enable
        {
            get { return enable; }
            set {
                enable = value;
                if (!enable)
                {
                    foreach (TestMethodUnit testCase in TestCaseUnits)
                    {
                        testCase.Enable = false;
                    }
                }
            }
        }

        private int activeCases=0;

        public int ActiveCases
        {
            get { return activeCases; }
            set { activeCases = value; }
        }

       
        public static TestClassUnit[] GetTestGroupUnits(Assembly assembly)
        {
            List<TestClassUnit> units = new List<TestClassUnit>();

            foreach (Type type in assembly.GetTypes())
            {
                if (null != GetTestGroupAttribute(type))
                {
                    units.Add(new TestClassUnit(type));
                }

            }
            return units.ToArray();
        }

        private TestClassUnit(Type type)
        {
            m_testGroupClass = type;
            m_attr = GetTestGroupAttribute(type);
            m_ignoreAttr = GetTestIgnoreAttribute(type);
            m_testCaseUnits = TestMethodUnit.GetTestCaseUnits(type);
            
            name = type.FullName;




            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                foreach (Attribute attr in methodInfo.GetCustomAttributes(true))
                {
                    if ((attr as AssemblyInitializeAttribute) != null)
                    {
                        AssemblyInitMethod = methodInfo;
                    }

                    if ((attr as AssemblyCleanupAttribute) != null)
                    {
                        AssemblyCleanupMethod = methodInfo;
                    }

                    if ((attr as ClassInitializeAttribute) != null)
                    {
                        ClassInitMethod = methodInfo;
                    }

                    if ((attr as ClassCleanupAttribute) != null)
                    {
                        ClassCleanupMethod = methodInfo;
                    }

                    if ((attr as TestInitializeAttribute) != null)
                    {
                        TestInitMethod = methodInfo;
                    }

                    if ((attr as TestCleanupAttribute) != null)
                    {
                        TestCleanupMethod = methodInfo;
                    }

                }
            }

            
            // default is all enabled
            enable = true;
            if (m_testCaseUnits.Length == 0)
            {
                enable = false;
            }

            //if the Ignore attribute is specified, disable the test group

            if (m_ignoreAttr != null)
            {
                this.Enable = false;
            }


        }


        static private TestClassAttribute GetTestGroupAttribute(Type type)
        {
            TestClassAttribute testGroupAttr = null;
            foreach (Attribute attr in type.GetCustomAttributes(true))
            {
                testGroupAttr = attr as TestClassAttribute;
                if (null != testGroupAttr)
                {
                    return testGroupAttr;
                }
            }
            return null;
        }

        static private IgnoreAttribute GetTestIgnoreAttribute(Type type)
        {
            IgnoreAttribute ignoreAttr = null;
            foreach (Attribute attr in type.GetCustomAttributes(true))
            {
                ignoreAttr = attr as IgnoreAttribute;
                if (null != ignoreAttr)
                {
                    return ignoreAttr;
                }
            }
            return null;
        }


        public Type TestGroupClass
        {
            get
            {
                return m_testGroupClass;
            }
        }


        /// <summary>
        /// All test cases within the test group
        /// </summary>
        public TestMethodUnit[] TestCaseUnits
        {
            get
            {
                return m_testCaseUnits;
            }
        }

        public TestClassAttribute Attribute
        {
            get
            {
                return m_attr;
            }
        }
    }

}
