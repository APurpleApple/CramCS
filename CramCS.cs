using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CramCS
{
    public static unsafe partial class Cram
    {
        private const string nativeLibName = "Cram";

        [StructLayout(LayoutKind.Sequential)]
        public struct Cram_ContextCreateInfo
        {
            public IntPtr name;
            public uint maxDimension;
            public int padding;
            public byte trim;
        }

        public struct Cram_ImageData
        {
            public char* path;
            public int x;
            public int y;
            public int width;
            public int height;

            public int trimOffsetX;
            public int trimOffsetY;
            public int untrimmedWidth;
            public int untrimmedHeight;
        }

        [LibraryImport(nativeLibName)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial IntPtr Cram_Init(
            IntPtr createInfo
        );

        [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial void Cram_AddFile(
            IntPtr context,
            string path
        );

        [LibraryImport(nativeLibName)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial byte Cram_Pack(
            IntPtr context
        );

        [LibraryImport(nativeLibName)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial byte Cram_GetPixelData(
            IntPtr context,
            out IntPtr pixelDataPointer,
            out int width,
            out int height
        );

        [LibraryImport(nativeLibName)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial byte Cram_GetMetadata(
            IntPtr context,
            out IntPtr imageDataPointer,
            out int imageCount
        );

        [LibraryImport(nativeLibName)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial byte Cram_Destroy(
            IntPtr context
        );
    }
}
