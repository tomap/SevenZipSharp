namespace SevenZip
{
    using System;
    using System.Runtime.InteropServices;
#if MONO
    using SevenZip.Mono.COM;
#endif

#if UNMANAGED
    internal static class NativeMethods
    {
        #if !WINCE && !MONO
        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int CreateObjectDelegate(
            [In] ref Guid classID,
            [In] ref Guid interfaceID,
            [MarshalAs(UnmanagedType.Interface)] out object outObject);

        #endregion

        [DllImport("kernel32.dll", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string procName);
		#endif
		
		#if WINCE
        [DllImport("7z.dll", EntryPoint="CreateObject")]
        public static extern int CreateCOMObject(
            [In] ref Guid classID,
            [In] ref Guid interfaceID,
            [MarshalAs(UnmanagedType.Interface)] out object outObject);	
		#endif

        public static T SafeCast<T>(PropVariant var, T def)
        {
            object obj;
            try
            {
                obj = var.Object;
            }
            catch (Exception)
            {
                return def;
            }
            if (obj != null && obj is T)
            {
                return (T) obj;
            }            
            return def;
        }
    }
#endif
}