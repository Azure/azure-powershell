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

namespace Microsoft.WindowsAzure.Setup
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;

    // IShellLink.ShowCmd fFlags
    [Flags]
    public enum ShowCmd
    {
        SW_SHOWNORMAL = 1,
        SW_SHOWMAXIMIZED = 3,
        SW_SHOWMINNOACTIVE = 7
    }

    // IShellLink.Resolve fFlags
    [Flags]
    public enum SLR_FLAGS
    {
        SLR_NO_UI = 0x1,
        SLR_ANY_MATCH = 0x2,
        SLR_UPDATE = 0x4,
        SLR_NOUPDATE = 0x8,
        SLR_NOSEARCH = 0x10,
        SLR_NOTRACK = 0x20,
        SLR_NOLINKINFO = 0x40,
        SLR_INVOKE_MSI = 0x80
    }

    // IShellLink.GetPath fFlags
    [Flags]
    public enum SLGP_FLAGS
    {
        SLGP_SHORTPATH = 0x1,
        SLGP_UNCPRIORITY = 0x2,
        SLGP_RAWPATH = 0x4
    }

    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Matching COM Names")]
    [ComImport,
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid("000214F9-0000-0000-C000-000000000046")]
    public interface IShellLinkW
    {
        void GetPath(
            [Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile,
            int cchMaxPath,
            out WIN32_FIND_DATAW pfd,
            SLGP_FLAGS fFlags);

        void GetIDList(
            out IntPtr ppidl);

        void SetIDList(
            IntPtr pidl);

        void GetDescription(
            [Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName,
            int cchMaxName);

        void SetDescription(
            [MarshalAs(UnmanagedType.LPWStr)] string pszName);

        void GetWorkingDirectory(
            [Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir,
            int cchMaxPath);

        void SetWorkingDirectory(
            [MarshalAs(UnmanagedType.LPWStr)] string pszDir);

        void GetArguments(
            [Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs,
            int cchMaxPath);

        void SetArguments(
            [MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

        void GetHotkey(
            out short pwHotkey);

        void SetHotkey(
            short wHotkey);

        void GetShowCmd(
            out int piShowCmd);

        void SetShowCmd(
            int iShowCmd);

        void GetIconLocation(
            [Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath,
            int cchIconPath,
            out int piIcon);

        void SetIconLocation(
            [MarshalAs(UnmanagedType.LPWStr)] string pszIconPath,
            int iIcon);

        void SetRelativePath(
            [MarshalAs(UnmanagedType.LPWStr)] string pszPathRel,
            int dwReserved);

        void Resolve(
            IntPtr hwnd,
            SLR_FLAGS fFlags);

        void SetPath(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }

    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Matching COM Names")]
    [ComImport,
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid("45E2b4AE-B1C3-11D0-B92F-00A0C90312E1")]
    public interface IShellLinkDataList
    {
        void AddDataBlock(
            IntPtr pDataBlock);

        void CopyDataBlock(
            uint dwSig,
            out IntPtr ppDataBlock);

        void RemoveDataBlock(
            uint dwSig);

        void GetFlags(
            out int dwFlags);

        void SetFlags(
            uint dwFlags);
    }

    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Matching COM Names")]
    [ComImport,
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid("0000010B-0000-0000-C000-000000000046")]
    public interface IPersistFile
    {
        #region Methods inherited from IPersist

        void GetClassID(
            out Guid pClassID);

        #endregion

        [PreserveSig]
        int IsDirty();

        void Load(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            int dwMode);

        void Save(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            [MarshalAs(UnmanagedType.Bool)] bool fRemember);

        void SaveCompleted(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFileName);

        void GetCurFile(
            out IntPtr ppszFileName);
    }

    // Win32 COORD
    [StructLayout(LayoutKind.Sequential)]
    public struct COORD
    {
        public short X;
        public short Y;
    }

    // IShellDataLink NT_CONSOLE_PROPS
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Matching Windows Struct Names")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Matching Windows Struct Names")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NT_CONSOLE_PROPS
    {
        public int cbSize;                 // Size of this extra data block
        public uint dwSignature;            // signature of this extra data block
        public ushort wFillAttribute;         // fill attribute for console
        public ushort wPopupFillAttribute;    // fill attribute for console popups
        public COORD dwScreenBufferSize;     // screen buffer size for console
        public COORD dwWindowSize;           // window size for console
        public COORD dwWindowOrigin;         // window origin for console
        public int nFont;
        public int nInputBufferSize;
        public COORD dwFontSize;
        public uint uFontFamily;
        public uint uFontWeight;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string FaceName;
        public uint uCursorSize;
        public bool bFullScreen;
        public bool bQuickEdit;
        public bool bInsertMode;
        public bool bAutoPosition;
        public uint uHistoryBufferSize;
        public uint uNumberOfHistoryBuffers;
        public bool bHistoryNoDup;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] ColorTable;
    }

    // WIN32_FIND_DATA
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Matching Windows Struct Names")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Matching Windows Struct Names")]
    public struct WIN32_FIND_DATAW
    {
        public int dwFileAttributes;
        public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
        public int nFileSizeHigh;
        public int nFileSizeLow;
        public int dwReserved0;
        public int dwReserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAXPATH)]
        public string cFileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternateFileName;
        private const int MAXPATH = 260;
    }

    public class ShellLink
    {
        private IShellLinkW shellLink;
        private NT_CONSOLE_PROPS consoleProperties;

        public ShellLink(string path)
        {
            this.shellLink = Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("00021401-0000-0000-C000-000000000046"))) as IShellLinkW;
            if (File.Exists(path))
            {
                IntPtr consoleProperties = IntPtr.Zero;
                ((IPersistFile)this.shellLink).Load(path, 0);

                try
                {
                    ((IShellLinkDataList)this.shellLink).CopyDataBlock(0xA0000002, out consoleProperties);
                    this.consoleProperties = (NT_CONSOLE_PROPS)Marshal.PtrToStructure(consoleProperties, typeof(NT_CONSOLE_PROPS));
                }
                catch (Exception)
                {
                }
            }
            else
            {
                ((IPersistFile)this.shellLink).Save(path, true);
            }

            // Initialize default Console Properties (TODO: Fix this bug too)
            if (this.consoleProperties.dwSignature != 0xA0000002)
            {
                this.consoleProperties = new NT_CONSOLE_PROPS();
                this.consoleProperties.cbSize = Marshal.SizeOf(this.consoleProperties);
                this.consoleProperties.dwSignature = 0xA0000002;
                this.consoleProperties.ColorTable = new uint[16];
                for (int i = 0; i < 16; i++)
                {
                    this.consoleProperties.ColorTable[i] = 0xffffffff;
                }
            }
        }

        public IShellLinkW IShellLink
        {
            get { return this.shellLink; }
        }

        public string Path
        {
            get
            {
                StringBuilder sb = new StringBuilder(260);
                WIN32_FIND_DATAW pfd = new WIN32_FIND_DATAW();
                this.IShellLink.GetPath(sb, 260, out pfd, SLGP_FLAGS.SLGP_RAWPATH);
                return sb.ToString();
            }
            set
            {
                this.IShellLink.SetPath(value);
            }
        }

        public string Description
        {
            get
            {
                StringBuilder sb = new StringBuilder(2048);
                this.IShellLink.GetDescription(sb, 2048);
                return sb.ToString();
            }
            set { this.IShellLink.SetDescription(value); }
        }

        public string WorkingDirectory
        {
            get
            {
                StringBuilder sb = new StringBuilder(260);
                this.IShellLink.GetWorkingDirectory(sb, 260);
                return sb.ToString();
            }
            set { this.IShellLink.SetWorkingDirectory(value); }
        }

        public ShowCmd ShowCmd
        {
            get
            {
                int showCmd;
                this.IShellLink.GetShowCmd(out showCmd);
                return (ShowCmd)Enum.ToObject(typeof(ShowCmd), showCmd);
            }
            set
            {
                this.IShellLink.SetShowCmd((int)value);
            }
        }

        public NT_CONSOLE_PROPS ConsoleProperties
        {
            get { return this.consoleProperties; }
            set { this.consoleProperties = value; }
        }

        public bool QuickEditMode
        {
            get { return this.consoleProperties.bQuickEdit; }
            set { this.consoleProperties.bQuickEdit = value; }
        }

        public bool InsertMode
        {
            get { return this.consoleProperties.bInsertMode; }
            set { this.consoleProperties.bInsertMode = value; }
        }

        public bool AutoPosition
        {
            get { return this.consoleProperties.bAutoPosition; }
            set { this.consoleProperties.bAutoPosition = value; }
        }

        public uint CommandHistoryBufferSize
        {
            get { return this.consoleProperties.uHistoryBufferSize; }
            set { this.consoleProperties.uHistoryBufferSize = value; }
        }

        public uint CommandHistoryBufferCount
        {
            get { return this.consoleProperties.uNumberOfHistoryBuffers; }
            set { this.consoleProperties.uNumberOfHistoryBuffers = value; }
        }

        public byte ScreenBackgroundColor
        {
            set
            {
                this.consoleProperties.wFillAttribute &= 0x000f;
                this.consoleProperties.wFillAttribute += (ushort)(value << 4);
            }
        }

        public byte ScreenTextColor
        {
            set
            {
                this.consoleProperties.wFillAttribute &= 0x00f0;
                this.consoleProperties.wFillAttribute += value;
            }
        }

        public byte PopUpBackgroundColor
        {
            set
            {
                this.consoleProperties.wPopupFillAttribute &= 0x000f;
                this.consoleProperties.wPopupFillAttribute += (ushort)(value << 4);
            }
        }

        public byte PopUpTextColor
        {
            set
            {
                this.consoleProperties.wPopupFillAttribute &= 0x00f0;
                this.consoleProperties.wPopupFillAttribute += value;
            }
        }

        public void Save(string path)
        {
            this.SetConsoleProperties();
            ((IPersistFile)this.shellLink).Save(path, true);
        }

        public void Save()
        {
            this.SetConsoleProperties();
            ((IPersistFile)this.shellLink).Save(null, true);
        }

        public void SetScreenBufferSize(short x, short y)
        {
            COORD c = new COORD();
            c.X = x;
            c.Y = y;
            this.consoleProperties.dwScreenBufferSize = c;
        }

        public void SetWindowSize(short x, short y)
        {
            COORD c = new COORD();
            c.X = x;
            c.Y = y;
            this.consoleProperties.dwWindowSize = c;
        }

        public void SetFont()
        {
            this.consoleProperties.FaceName = "Lucida Console";
            this.consoleProperties.uFontFamily = 54;
            this.consoleProperties.uFontWeight = 400;
            this.consoleProperties.uCursorSize = 25;
        }

        // This does more than console colors
        private void SetConsoleProperties()
        {
            IntPtr consoleProperties = Marshal.AllocCoTaskMem(this.consoleProperties.cbSize);
            Marshal.StructureToPtr(this.consoleProperties, consoleProperties, true);
            ((IShellLinkDataList)this.shellLink).RemoveDataBlock(0xA0000002);
            ((IShellLinkDataList)this.shellLink).AddDataBlock(consoleProperties);
        }
    }
}