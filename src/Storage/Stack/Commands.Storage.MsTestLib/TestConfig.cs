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
using System.IO;
using System.Xml;

namespace MS.Test.Common.MsTestLib
{
    public class TestConfig
    {
        private string DefaultConfigFileName = "TestData.xml";

        public TestConfig(string configFile)
        {
            testParams = new Dictionary<string, string>();
            testClasses = new Dictionary<string, ClassConfig>();

            //Initialze: read default config file TestData.xml and then read configFile file
            if(string.IsNullOrEmpty(configFile))
            {
                configFile = "MyTestData.xml";
            }
            ReadConfig(DefaultConfigFileName);      //read default config file: TestData.xml

            if (File.Exists(configFile))
            {
                ReadConfig(configFile);                 //read configFile file: e.g MyTestData.xml, configuration in this file will cover settings in TestData.xml
            }
        }
        private void ReadConfig(string configFile)
        {
            if (string.IsNullOrEmpty(configFile))
            {
                throw new ArgumentNullException();  //illegal use
            }
            XmlDocument config = new XmlDocument();
            try
            {
                config.Load(configFile);
            }
            catch (FileNotFoundException)
            {
                string errorMsg = string.Format("{0} file not found", configFile);
                throw new FileNotFoundException(errorMsg);
            }
            catch (Exception)
            {
                throw;
            }
            XmlNode root = config.SelectSingleNode("TestConfig");
            if (root != null)
            {
                foreach (XmlNode node in root.ChildNodes)
                {
                    XmlElement eleNode = node as XmlElement;
                    if (eleNode == null)
                    {
                        continue;
                    }

                    if (string.Compare(eleNode.Name.ToLower(), "testclass") == 0 && eleNode.Attributes["name"] != null)
                    {
                        ClassConfig classConfig = this[eleNode.Attributes["name"].Value];
                        if(classConfig == null)
                            classConfig = new ClassConfig();
                        foreach (XmlNode subnode in eleNode.ChildNodes)
                        {
                            XmlElement eleSubnode = subnode as XmlElement;
                            if (eleSubnode == null)
                            {
                                continue;
                            }

                            if (string.Compare(eleSubnode.Name.ToLower(), "testmethod") == 0 && eleSubnode.Attributes["name"] != null)
                            {
                                MethodConfig methodConfig = classConfig[eleSubnode.Attributes["name"].Value];
                                if (methodConfig == null)
                                    methodConfig = new MethodConfig();
                                foreach (XmlNode methodParamNode in eleSubnode.ChildNodes)
                                {
                                    XmlElement eleMethodParamNode = methodParamNode as XmlElement;
                                    if (eleMethodParamNode == null)
                                    {
                                        continue;
                                    }
                                    methodConfig[eleMethodParamNode.Name] = eleMethodParamNode.InnerText;

                                }
                                classConfig[eleSubnode.Attributes["name"].Value] = methodConfig;
                                continue;
                            }

                            classConfig.ClassParams[eleSubnode.Name] = eleSubnode.InnerText;

                        }
                        this[eleNode.Attributes["name"].Value] = classConfig;
                        continue;

                    }

                    TestParams[eleNode.Name] = eleNode.InnerText;

                }
            }
        }

        private Dictionary<string, string> testParams = null;

        public Dictionary<string, string> TestParams
        {
            get { return testParams; }
            set { testParams = value; }
        }

        private Dictionary<string, ClassConfig> testClasses;

        public ClassConfig this[string className]
        {
            get
            {
                if (testClasses.ContainsKey(className))
                {
                    return testClasses[className];
                }
                else
                {
                    return null;
                }
            }

            set
            {
                testClasses[className] = value;
            }
        }

        public string Get(string paramName)
        {
            //first search the method params
            if (this[Test.FullClassName] != null)
            {
                if (this[Test.FullClassName][Test.MethodName] != null)
                {
                    if (this[Test.FullClassName][Test.MethodName].MethodParams.ContainsKey(paramName))
                    {
                        return this[Test.FullClassName][Test.MethodName].MethodParams[paramName].Trim();
                    }
                }

                if (this[Test.FullClassName].ClassParams.ContainsKey(paramName))
                {
                    return this[Test.FullClassName].ClassParams[paramName].Trim();
                }
            }

            if (TestParams.ContainsKey(paramName))
            {
                return TestParams[paramName].Trim();
            }

            throw new ArgumentException("The test param does not exist.", paramName);
        }

    }

}
