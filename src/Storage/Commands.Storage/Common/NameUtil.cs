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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Name utility
    /// </summary>
    internal class NameUtil
    {
        public const int MaxFileNameLength = 1024;

        /// <summary>
        /// Max file length in windows
        /// </summary>
        public const int WindowsMaxFileNameLength = 256;

        /// <summary>
        /// Max length for Stored Access Policy name
        /// </summary>
        public const int MaxStoredAccessPolicyNameLength = 64;

        /// <summary>
        /// Check whether the blob name is valid. If not throw an exception
        /// </summary>
        /// <param name="name">Blob name</param>
        public static void ValidateBlobName(string name)
        {
            if (!NameUtil.IsValidBlobName(name))
            {
                throw new ArgumentException(String.Format(
                    CultureInfo.CurrentCulture,
                    Resources.InvalidBlobName,
                    name));
            }
        }

        /// <summary>
        /// Check whether the container name is valid. If not throw an exception
        /// </summary>
        /// <param name="name">Container name</param>
        public static void ValidateContainerName(string name)
        {
            if (!NameUtil.IsValidContainerName(name))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidContainerName, name));
            }
        }

        /// <summary>
        /// Is valid container name <see cref="http://msdn.microsoft.com/en-us/library/windowsazure/dd135715.aspx"/>
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <returns>True for valid container name, otherwise return false</returns>
        public static bool IsValidContainerName(string containerName)
        {
            Regex regex = new Regex(@"^\$root$|^\$logs$|^[a-z0-9]([a-z0-9]|(?<=[a-z0-9])-(?=[a-z0-9])){2,62}$");
            return regex.IsMatch(containerName);
        }

        /// <summary>
        /// Is valid container prefix or not
        /// </summary>
        /// <param name="containerPrefix">Container prefix</param>
        /// <returns>True for valid container prefix, otherwise return false</returns>
        public static bool IsValidContainerPrefix(string containerPrefix)
        {
            if (containerPrefix.StartsWith("$"))
            {
                string root = "$root";
                string logs = "$logs";

                if (root.IndexOf(containerPrefix) == 0 || logs.IndexOf(containerPrefix) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (containerPrefix.Length > 0 && containerPrefix.Length < 3)
                {
                    containerPrefix = containerPrefix + "abc";
                };

                if (containerPrefix.EndsWith("-"))
                {
                    containerPrefix += "a";
                }

                return IsValidContainerName(containerPrefix);
            }
        }

        /// <summary>
        /// Is valid blob name <see cref="http://msdn.microsoft.com/en-us/library/windowsazure/dd135715.aspx"/>
        /// </summary>
        /// <param name="blobName">Blob name</param>
        /// <returns>True for valid blob name, otherwise return false</returns>
        public static bool IsValidBlobName(string blobName)
        {
            int minLength = 0;
            int maxLength = 1024;

            if (blobName.Length > minLength && blobName.Length <= maxLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Is valid blob prefix <see cref="http://msdn.microsoft.com/en-us/library/windowsazure/dd135715.aspx"/>
        /// </summary>
        /// <param name="blobName">Blob name</param>
        /// <returns>True for valid blob name, otherwise return false</returns>
        public static bool IsValidBlobPrefix(string blobPrefix)
        {
            return IsValidBlobName(blobPrefix);
        }


        /// <summary>
        /// Is valid table name <see cref="http://msdn.microsoft.com/en-us/library/windowsazure/dd179338.aspx"/>
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns>True for valid table name, otherwise return false</returns>
        public static bool IsValidTableName(string tableName)
        {
            //http://msdn.microsoft.com/en-us/library/windowsazure/hh343258.aspx
            string metricsPrefix = "$Metric";
            if (!String.IsNullOrEmpty(tableName) && tableName.StartsWith(metricsPrefix))
            {
                return true;
            }
            else
            {
                Regex regex = new Regex(@"^[A-Za-z][A-Za-z0-9]{2,62}$");
                return regex.IsMatch(tableName);
            }
        }

        /// <summary>
        /// Is valid table prefix
        /// </summary>
        /// <param name="tablePrefix">Table prefix</param>
        /// <returns>True for valid table prefix, otherwise return false</returns>
        public static bool IsValidTablePrefix(string tablePrefix)
        {
            if (tablePrefix.Length > 0 && tablePrefix.Length < 3)
            {
                tablePrefix = tablePrefix + "abc";
            };

            return IsValidTableName(tablePrefix);
        }


        /// <summary>
        /// Is valid queue name <see cref="http://msdn.microsoft.com/en-us/library/windowsazure/dd179349.aspx"/>
        /// </summary>
        /// <param name="queueName">Queue name</param>
        /// <returns>True for valid queue name, otherwise return false</returns>
        public static bool IsValidQueueName(string queueName)
        {
            Regex regex = new Regex(@"^[0-9a-z]([a-z0-9]|(?<=[a-z0-9])-(?=[a-z0-9])){1,61}[0-9a-z]$");
            return regex.IsMatch(queueName);
        }

        /// <summary>
        /// Is valid queue prefix
        /// </summary>
        /// <param name="queuePrefix">Queue prefix</param>
        /// <returns>True for valid queue prefix, otherwise return false</returns>
        public static bool IsValidQueuePrefix(string queuePrefix)
        {
            if (queuePrefix.Length > 0 && queuePrefix.Length < 3)
            {
                queuePrefix = queuePrefix + "abc";
            };

            if (queuePrefix.EndsWith("-"))
            {
                queuePrefix += "a";
            }

            return IsValidQueueName(queuePrefix);
        }

        /// <summary>
        /// Is valid file name in local machine
        /// </summary>
        /// <param name="fileName">FileName</param>
        /// <returns>True for valid file name, otherwise return false</returns>
        public static bool IsValidFileName(string fileName)
        {
            //http://msdn.microsoft.com/en-us/library/windows/desktop/aa365247(v=vs.85).aspx#maxpath

            if (string.IsNullOrEmpty(fileName) || fileName.Length > WindowsMaxFileNameLength)
            {
                return false;
            }
            else if (fileName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1)
            {
                return false;
            }
            else
            {
                string realName = Path.GetFileNameWithoutExtension(fileName);
                //http://en.wikipedia.org/wiki/Filename
                //In Windows and DOS utilities, some words might also be reserved and can not be used as filenames.
                //However, "CLOCK$", "COM0", "LPT0" are not forbidden name since they can be used as file name in command line prompt.
                string[] forbiddenList = { "CON", "PRN", "AUX", "NUL",
                    "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
                    "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };
                bool forbidden = forbiddenList.Contains(realName);
                return !forbidden;
            }
        }

        public static bool IsValidStoredAccessPolicyName(string policyName)
        {
            if (string.IsNullOrEmpty(policyName) || policyName.Length > MaxStoredAccessPolicyNameLength)
            {
                return false;
            }

            return true;
        }

        public static string ResolveBlobName(string blobName)
        {
            return blobName.Replace('\\', '/');
        }

        /// <summary>
        /// convert blob name into valid file name
        /// </summary>
        /// <param name="blobName">blob name</param>
        /// <returns>valid file name</returns>
        public static string ConvertBlobNameToFileName(string blobName, DateTimeOffset? snapshotTime)
        {
            string fileName = blobName;

            //replace dirctionary
            Dictionary<string, string> replaceRules = new Dictionary<string, string>()
                {
                    {"/", "\\"}
                };

            foreach (KeyValuePair<string, string> rule in replaceRules)
            {
                fileName = fileName.Replace(rule.Key, rule.Value);
            }

            if (snapshotTime != null)
            {
                int index = fileName.LastIndexOf('.');

                string prefix = string.Empty;
                string postfix = string.Empty;
                string timeStamp = string.Format("{0:u}", snapshotTime.Value);
                timeStamp = timeStamp.Replace(":", string.Empty).TrimEnd(new char[] { 'Z' });

                if (index == -1)
                {
                    prefix = fileName;
                    postfix = string.Empty;
                }
                else
                {
                    prefix = fileName.Substring(0, index);
                    postfix = fileName.Substring(index);
                }

                fileName = string.Format(Resources.FileNameFormatForSnapShot, prefix, timeStamp, postfix);
            }

            return fileName;
        }

        /// <summary>
        /// Get the prefix that don't contain wildcard
        /// </summary>
        /// <param name="pattern">Wildcard pattern</param>
        /// <returns>Non wildcard prefix</returns>
        public static string GetNonWildcardPrefix(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return string.Empty;

            for (int index = 0; index < pattern.Length; index++)
            {
                if (WildcardPattern.ContainsWildcardCharacters(pattern[index].ToString()))
                {
                    return pattern.Substring(0, index);
                }
            }

            return pattern;
        }
    }
}
