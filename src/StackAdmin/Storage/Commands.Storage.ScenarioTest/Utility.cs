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
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using MS.Test.Common.MsTestLib;

namespace Commands.Storage.ScenarioTest
{
    class Utility
    {
        /// <summary>
        /// Generate a random string for azure object name
        /// @prefix: usually it's a string of letters, to avoid naming rule breaking
        /// @len: the length of random string after the prefix
        /// </summary> 
        public static string GenNameString(string prefix, int len = 8)
        {
            return prefix + Guid.NewGuid().ToString().Replace("-", "").Substring(0, len);
        }

        /// <summary>
        /// Generate random base 64 string
        /// </summary>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static string GenBase64String(string seed = "")
        {
            string randomKey = Utility.GenNameString(seed);
            return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(randomKey));
        }

        /// <summary>
        /// Get Storage End Points
        /// </summary>
        /// <param name="storageAccountName">storage account name</param>
        /// <param name="useHttps">use https</param>
        /// <returns>A string array. 0 is blob endpoint, 1 is queue endpoint, 2 is table endpoint, 3 is file endpoint</returns>
        public static string[] GetStorageEndPoints(string storageAccountName, bool useHttps, string endPoint = "")
        {
            string protocol = "http";

            if (useHttps)
            {
                protocol = "https";
            }

            if (string.IsNullOrEmpty(endPoint))
            {
                string configEndPoint = Test.Data.Get("StorageEndPoint");
                if (string.IsNullOrEmpty(configEndPoint))
                {
                    endPoint = "core.windows.net";
                }
                else
                {
                    endPoint = configEndPoint;
                }
            }

            endPoint = endPoint.Trim();

            string[] storageEndPoints = new string[4]
                {
                    string.Format("{0}://{1}.blob.{2}/", protocol, storageAccountName, endPoint),
                    string.Format("{0}://{1}.queue.{2}/", protocol, storageAccountName, endPoint),
                    string.Format("{0}://{1}.table.{2}/", protocol, storageAccountName, endPoint),
                    string.Format("{0}://{1}.file.{2}/", protocol, storageAccountName, endPoint)
                };
            return storageEndPoints;
        }

        /// <summary>
        /// Get CloudStorageAccount with specified end point
        /// </summary>
        /// <param name="credential">StorageCredentials object</param>
        /// <param name="useHttps">use https</param>
        /// <param name="endPoint">end point</param>
        /// <returns>CloudStorageAccount object</returns>
        public static CloudStorageAccount GetStorageAccountWithEndPoint(StorageCredentials credential, bool useHttps, string endPoint = "")
        {
            string[] endPoints = GetStorageEndPoints(credential.AccountName, useHttps, endPoint);
            return new CloudStorageAccount(credential, new Uri(endPoints[0]), new Uri(endPoints[1]), new Uri(endPoints[2]), new Uri(endPoints[3]));
        }


        public static List<string> GenNameLists(string prefix, int count = 1, int len = 8)
        {
            List<string> names = new List<string>();

            for (int i = 0; i < count; i++)
            {
                names.Add(Utility.GenNameString(prefix, len));
            }

            return names;
        }

        /// <summary>
        /// Generate random string with 26 alphabet in upper case.
        /// </summary>
        /// <param name="size">String length</param>
        /// <returns>Random alphabet string</returns>
        public static string GenRandomAlphabetString(int size = 8)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(random.Next(0, 26) + 65);
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static string GenConnectionString(string StorageAccountName, string StorageAccountKey)
        {
            return String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", StorageAccountName, StorageAccountKey);
        }

        /// <summary>
        /// Generate the data for output comparision
        /// </summary> 
        public static Dictionary<string, object> GenComparisonData(StorageObjectType objType, string name)
        {
            Dictionary<string, object> dic = new Dictionary<string, object> { 
                {"Name", name },
                {"Context", null}
            };

            switch (objType)
            {
                case StorageObjectType.Container:
                    dic.Add("PublicAccess", BlobContainerPublicAccessType.Off);        // default value is Off
                    dic.Add("LastModified", null);
                    dic.Add("Permission", null);
                    break;
                case StorageObjectType.Blob:
                    dic.Add("BlobType", null);      // need to validate this later
                    dic.Add("Length", null);        // need to validate this later
                    dic.Add("ContentType", null);   // the return value of upload operation is always null
                    dic.Add("LastModified", null);  // need to validate this later
                    dic.Add("SnapshotTime", null);  // need to validate this later
                    break;
                case StorageObjectType.Queue:
                    dic.Add("ApproximateMessageCount", 0);
                    dic.Add("EncodeMessage", true);
                    break;
                case StorageObjectType.Table:
                    break;
                default:
                    throw new Exception(String.Format("Object type:{0} not identified!", objType));
            }

            return dic;
        }

        /// <summary>
        /// Generate the data for output comparision
        /// </summary> 
        public static string GenComparisonData(string FunctionName, bool Success)
        {
            return String.Format("{0} operation should {1}.", FunctionName, Success ? "succeed" : "fail");
        }

        /// <summary>
        /// Compare two entities, usually one from XSCL, one from PowerShell
        /// </summary> 
        public static bool CompareEntity<T>(T v1, T v2)
        {
            bool bResult = true;

            if (v1 == null || v2 == null)
            {
                if (v1 == null && v2 == null)
                {
                    Test.Info("Skip compare null objects");
                    return true;
                }
                else
                {
                    Test.AssertFail(string.Format("v1 is {0}, but v2 is {1}", v1, v2));
                    return false;
                }
            }
            
            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                if (propertyInfo.Name.Equals("ServiceClient"))
                    continue;

                object o1 = null;
                object o2 = null;

                try
                {
                    o1 = propertyInfo.GetValue(v1, null);
                    o2 = propertyInfo.GetValue(v2, null);
                }
                catch
                { 
                    //skip the comparison when throw exception
                    string msg = string.Format("Skip compare '{0}' property in type {1}", propertyInfo.Name, typeof(T));
                    Trace.WriteLine(msg);
                    Test.Warn(msg);
                    continue;
                }

                if (propertyInfo.Name.Equals("Metadata"))
                {
                    if (v1.GetType() == typeof(CloudBlobContainer) 
                        || v1.GetType() == typeof(CloudBlockBlob)
                        || v1.GetType() == typeof(CloudPageBlob)
                        || v1.GetType() == typeof(CloudQueue)
                        || v1.GetType() == typeof(CloudTable))
                    {
                        bResult = ((IDictionary<string, string>)o1).SequenceEqual((IDictionary<string, string>)o2);
                    }
                    else
                    {
                        bResult = o1.Equals(o2);
                    }
                }
                else if (propertyInfo.Name.Equals("Properties"))
                {
                    if (v1.GetType() == typeof(CloudBlockBlob)
                        || v1.GetType() == typeof(CloudPageBlob))
                    {
                        bResult = CompareEntity((BlobProperties)o1, (BlobProperties)o2);
                    }
                    else if (v1.GetType() == typeof(CloudBlobContainer))
                    {
                        bResult = CompareEntity((BlobContainerProperties)o1, (BlobContainerProperties)o2);
                    }
                }
                else if (propertyInfo.Name.Equals("SharedAccessPolicies"))
                {
                    if (v1.GetType() == typeof(BlobContainerPermissions))
                    {
                        bResult = CompareEntity((SharedAccessBlobPolicies)o1, (SharedAccessBlobPolicies)o2);
                    }
                    else
                    {
                        bResult = o1.Equals(o2);
                    }
                }
                else
                {
                    if (o1 == null)
                    {
                        if (o2 != null)
                            bResult = false;
                    }
                    else
                    {
                        //compare according to type
                        if (o1 is ICollection<string>)
                        {
                            bResult = ((ICollection<string>)o1).SequenceEqual((ICollection<string>)o2);
                        }
                        else if (o1 is ICollection<SharedAccessBlobPolicy>)
                        {
                            bResult = CompareEntity((ICollection<SharedAccessBlobPolicy>)o1, (ICollection<SharedAccessBlobPolicy>)o2);
                        }
                        else
                        {
                            bResult = o1.Equals(o2);
                        }
                    }
                }

                if (bResult == false)
                {
                    Test.Error("Property Mismatch: {0} in type {1}. {2} != {3}", propertyInfo.Name, typeof(T), o1, o2);
                    break;
                }
                else
                {
                    Test.Verbose("Property {0} in type {1}: {2} == {3}", propertyInfo.Name, typeof(T), o1, o2);
                }
            }
            return bResult;
        }
    }
}
