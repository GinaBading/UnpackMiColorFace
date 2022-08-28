﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnpackMiColorFace.Helpers
{
    public class BmpHelper
    {
        static byte[] headerRgb565 = {
                0x42, 0x4D, 0xF6, 0xDC, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7A, 0x00, 0x00, 0x00, 0x6C, 0x00,
                0x00, 0x00, 0x03, 0x01, 0x00, 0x00, 0xB5, 0x00, 0x00, 0x00, 0x01, 0x00, 0x10, 0x00, 0x03, 0x00,
                0x00, 0x00, 0x7C, 0xDC, 0x02, 0x00, 0xC4, 0x0E, 0x00, 0x00, 0xC4, 0x0E, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF8, 0x00, 0x00, 0xE0, 0x07, 0x00, 0x00, 0x1F, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x42, 0x47, 0x52, 0x73, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            };

        static byte[] headerARgb32 = {
                0x42, 0x4D, 0xF6, 0xDC, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7A, 0x00, 0x00, 0x00, 0x6C, 0x00,
                0x00, 0x00, 0x03, 0x01, 0x00, 0x00, 0xB5, 0x00, 0x00, 0x00, 0x01, 0x00, 0x20, 0x00, 0x03, 0x00,
                0x00, 0x00, 0x7C, 0xDC, 0x02, 0x00, 0xC4, 0x0E, 0x00, 0x00, 0xC4, 0x0E, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00,
                0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x42, 0x47, 0x52, 0x73, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            };

        static byte[] headerARgb32_GTR = {
                0x42, 0x4D, 0xF6, 0xDC, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7A, 0x00, 0x00, 0x00, 0x6C, 0x00,
                0x00, 0x00, 0x03, 0x01, 0x00, 0x00, 0xB5, 0x00, 0x00, 0x00, 0x01, 0x00, 0x20, 0x00, 0x03, 0x00,
                0x00, 0x00, 0x7C, 0xDC, 0x02, 0x00, 0xC4, 0x0E, 0x00, 0x00, 0xC4, 0x0E, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00, 0xFF, 0x00, 0x00, 0xFF, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x42, 0x47, 0x52, 0x73, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            };

        static byte[] headerIndex8  = {
                0x42, 0x4D, 0x56, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x04, 0x00, 0x00, 0x28, 0x00,
                0x00, 0x00, 0x6E, 0x00, 0x00, 0x00, 0x6E, 0x00, 0x00, 0x00, 0x01, 0x00, 0x08, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC4, 0x0E, 0x00, 0x00, 0xC4, 0x0E, 0x00, 0x00, 0x00, 0x01,
                0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x01, 0x01, 0x01, 0xFF, 0x04, 0x04, 0x03, 0xFF, 0x05, 0x05,
                0x05, 0xFF, 0x07, 0x08, 0x07, 0xFF, 0x08, 0x08, 0x07, 0xFF, 0x08, 0x07, 0x08, 0xFF, 0x07, 0x08,
                0x08, 0xFF, 0x09, 0x09, 0x09, 0xFF, 0x0C, 0x0B, 0x0B, 0xFF, 0x0B, 0x0C, 0x0B, 0xFF, 0x0C, 0x0C,
                0x0B, 0xFF, 0x0B, 0x0B, 0x0C, 0xFF, 0x0C, 0x0B, 0x0C, 0xFF, 0x0B, 0x0C, 0x0C, 0xFF, 0x0D, 0x0D,
                0x0D, 0xFF, 0x10, 0x0E, 0x0F, 0xFF, 0x0E, 0x10, 0x0E, 0xFF, 0x0F, 0x0E, 0x10, 0xFF, 0x0F, 0x11,
                0x10, 0xFF, 0x11, 0x11, 0x11, 0xFF, 0x14, 0x13, 0x13, 0xFF, 0x13, 0x14, 0x13, 0xFF, 0x14, 0x14,
                0x13, 0xFF, 0x14, 0x13, 0x14, 0xFF, 0x13, 0x14, 0x14, 0xFF, 0x15, 0x15, 0x15, 0xFF, 0x17, 0x18,
                0x17, 0xFF, 0x18, 0x18, 0x17, 0xFF, 0x17, 0x17, 0x18, 0xFF, 0x18, 0x17, 0x18, 0xFF, 0x17, 0x18,
                0x18, 0xFF, 0x19, 0x19, 0x19, 0xFF, 0x1C, 0x1A, 0x1B, 0xFF, 0x1B, 0x1C, 0x1B, 0xFF, 0x1B, 0x1B,
                0x1C, 0xFF, 0x1C, 0x1B, 0x1C, 0xFF, 0x1B, 0x1C, 0x1C, 0xFF, 0x1D, 0x1D, 0x1D, 0xFF, 0x1F, 0x20,
                0x1E, 0xFF, 0x20, 0x20, 0x1F, 0xFF, 0x20, 0x1F, 0x20, 0xFF, 0x1F, 0x20, 0x20, 0xFF, 0x21, 0x21,
                0x21, 0xFF, 0x24, 0x23, 0x23, 0xFF, 0x23, 0x24, 0x23, 0xFF, 0x24, 0x24, 0x23, 0xFF, 0x24, 0x23,
                0x24, 0xFF, 0x23, 0x24, 0x24, 0xFF, 0x25, 0x25, 0x25, 0xFF, 0x28, 0x27, 0x27, 0xFF, 0x27, 0x28,
                0x27, 0xFF, 0x28, 0x28, 0x27, 0xFF, 0x27, 0x27, 0x28, 0xFF, 0x28, 0x26, 0x28, 0xFF, 0x27, 0x28,
                0x28, 0xFF, 0x29, 0x29, 0x29, 0xFF, 0x2C, 0x2A, 0x2A, 0xFF, 0x2B, 0x2C, 0x2B, 0xFF, 0x2C, 0x2C,
                0x2B, 0xFF, 0x2B, 0x2B, 0x2C, 0xFF, 0x2C, 0x2B, 0x2C, 0xFF, 0x2B, 0x2C, 0x2C, 0xFF, 0x2D, 0x2D,
                0x2D, 0xFF, 0x30, 0x2F, 0x2F, 0xFF, 0x2F, 0x30, 0x2F, 0xFF, 0x30, 0x30, 0x2F, 0xFF, 0x2E, 0x2E,
                0x30, 0xFF, 0x30, 0x2E, 0x30, 0xFF, 0x2F, 0x30, 0x30, 0xFF, 0x31, 0x31, 0x31, 0xFF, 0x34, 0x33,
                0x33, 0xFF, 0x33, 0x34, 0x33, 0xFF, 0x34, 0x34, 0x33, 0xFF, 0x33, 0x33, 0x34, 0xFF, 0x34, 0x32,
                0x34, 0xFF, 0x33, 0x34, 0x34, 0xFF, 0x35, 0x35, 0x35, 0xFF, 0x38, 0x36, 0x37, 0xFF, 0x36, 0x38,
                0x37, 0xFF, 0x38, 0x38, 0x37, 0xFF, 0x37, 0x37, 0x38, 0xFF, 0x38, 0x36, 0x38, 0xFF, 0x37, 0x38,
                0x38, 0xFF, 0x39, 0x39, 0x39, 0xFF, 0x3C, 0x3A, 0x3B, 0xFF, 0x3A, 0x3C, 0x3A, 0xFF, 0x3C, 0x3C,
                0x3B, 0xFF, 0x3B, 0x3B, 0x3C, 0xFF, 0x3C, 0x3B, 0x3C, 0xFF, 0x3D, 0x3D, 0x3D, 0xFF, 0x40, 0x3E,
                0x3F, 0xFF, 0x3E, 0x40, 0x3F, 0xFF, 0x40, 0x40, 0x3F, 0xFF, 0x3F, 0x3E, 0x40, 0xFF, 0x40, 0x3F,
                0x40, 0xFF, 0x3F, 0x40, 0x40, 0xFF, 0x43, 0x43, 0x43, 0xFF, 0x48, 0x46, 0x47, 0xFF, 0x47, 0x48,
                0x47, 0xFF, 0x48, 0x48, 0x47, 0xFF, 0x47, 0x46, 0x48, 0xFF, 0x49, 0x47, 0x49, 0xFF, 0x47, 0x48,
                0x48, 0xFF, 0x4B, 0x4B, 0x4B, 0xFF, 0x50, 0x4E, 0x4F, 0xFF, 0x4F, 0x50, 0x4E, 0xFF, 0x50, 0x50,
                0x4F, 0xFF, 0x4E, 0x4E, 0x50, 0xFF, 0x50, 0x4F, 0x50, 0xFF, 0x4F, 0x50, 0x50, 0xFF, 0x53, 0x53,
                0x53, 0xFF, 0x58, 0x56, 0x56, 0xFF, 0x56, 0x58, 0x56, 0xFF, 0x58, 0x58, 0x57, 0xFF, 0x57, 0x56,
                0x58, 0xFF, 0x58, 0x57, 0x58, 0xFF, 0x57, 0x58, 0x58, 0xFF, 0x5B, 0x5B, 0x5B, 0xFF, 0x60, 0x5E,
                0x5F, 0xFF, 0x5F, 0x60, 0x5F, 0xFF, 0x60, 0x60, 0x5F, 0xFF, 0x5F, 0x5E, 0x60, 0xFF, 0x60, 0x5F,
                0x60, 0xFF, 0x5F, 0x60, 0x60, 0xFF, 0x63, 0x63, 0x63, 0xFF, 0x68, 0x66, 0x66, 0xFF, 0x66, 0x68,
                0x66, 0xFF, 0x68, 0x68, 0x67, 0xFF, 0x67, 0x66, 0x68, 0xFF, 0x68, 0x67, 0x68, 0xFF, 0x67, 0x68,
                0x68, 0xFF, 0x6B, 0x6B, 0x6B, 0xFF, 0x70, 0x6E, 0x6F, 0xFF, 0x6E, 0x70, 0x6E, 0xFF, 0x70, 0x70,
                0x6F, 0xFF, 0x6E, 0x6E, 0x70, 0xFF, 0x70, 0x6E, 0x70, 0xFF, 0x6F, 0x70, 0x70, 0xFF, 0x73, 0x73,
                0x73, 0xFF, 0x78, 0x77, 0x76, 0xFF, 0x76, 0x78, 0x77, 0xFF, 0x78, 0x78, 0x77, 0xFF, 0x76, 0x76,
                0x78, 0xFF, 0x78, 0x77, 0x78, 0xFF, 0x77, 0x78, 0x78, 0xFF, 0x7B, 0x7B, 0x7B, 0xFF, 0x80, 0x7F,
                0x7F, 0xFF, 0x7F, 0x80, 0x7F, 0xFF, 0x80, 0x80, 0x7F, 0xFF, 0x7E, 0x7F, 0x80, 0xFF, 0x80, 0x7F,
                0x80, 0xFF, 0x7E, 0x80, 0x80, 0xFF, 0x83, 0x83, 0x83, 0xFF, 0x88, 0x86, 0x86, 0xFF, 0x87, 0x88,
                0x86, 0xFF, 0x88, 0x88, 0x87, 0xFF, 0x86, 0x87, 0x88, 0xFF, 0x88, 0x87, 0x88, 0xFF, 0x87, 0x88,
                0x88, 0xFF, 0x8B, 0x8B, 0x8B, 0xFF, 0x90, 0x8E, 0x8E, 0xFF, 0x8F, 0x90, 0x8E, 0xFF, 0x90, 0x90,
                0x8F, 0xFF, 0x8F, 0x8E, 0x90, 0xFF, 0x90, 0x8E, 0x90, 0xFF, 0x8F, 0x90, 0x90, 0xFF, 0x93, 0x93,
                0x93, 0xFF, 0x98, 0x97, 0x97, 0xFF, 0x96, 0x98, 0x96, 0xFF, 0x98, 0x98, 0x97, 0xFF, 0x96, 0x96,
                0x98, 0xFF, 0x98, 0x97, 0x98, 0xFF, 0x97, 0x98, 0x98, 0xFF, 0x9B, 0x9B, 0x9B, 0xFF, 0xA0, 0x9E,
                0x9E, 0xFF, 0x9E, 0xA0, 0x9E, 0xFF, 0xA0, 0xA0, 0x9F, 0xFF, 0x9E, 0x9E, 0xA0, 0xFF, 0xA0, 0x9F,
                0xA0, 0xFF, 0x9F, 0xA0, 0xA0, 0xFF, 0xA3, 0xA3, 0xA3, 0xFF, 0xA8, 0xA6, 0xA7, 0xFF, 0xA6, 0xA8,
                0xA6, 0xFF, 0xA8, 0xA8, 0xA7, 0xFF, 0xA7, 0xA7, 0xA8, 0xFF, 0xA8, 0xA7, 0xA8, 0xFF, 0xA6, 0xA8,
                0xA8, 0xFF, 0xAB, 0xAB, 0xAB, 0xFF, 0xB0, 0xAF, 0xAE, 0xFF, 0xAE, 0xB0, 0xAE, 0xFF, 0xB0, 0xB0,
                0xAF, 0xFF, 0xAF, 0xAE, 0xB0, 0xFF, 0xB0, 0xAF, 0xB0, 0xFF, 0xAF, 0xB0, 0xB0, 0xFF, 0xB3, 0xB3,
                0xB3, 0xFF, 0xB8, 0xB6, 0xB6, 0xFF, 0xB7, 0xB8, 0xB7, 0xFF, 0xB8, 0xB8, 0xB7, 0xFF, 0xB7, 0xB6,
                0xB8, 0xFF, 0xB8, 0xB7, 0xB8, 0xFF, 0xB7, 0xB8, 0xB8, 0xFF, 0xBB, 0xBB, 0xBB, 0xFF, 0xC0, 0xBF,
                0xBE, 0xFF, 0xBE, 0xC0, 0xBE, 0xFF, 0xC0, 0xC0, 0xBF, 0xFF, 0xBF, 0xBE, 0xC0, 0xFF, 0xC0, 0xBE,
                0xC0, 0xFF, 0xBF, 0xC0, 0xC0, 0xFF, 0xC3, 0xC3, 0xC3, 0xFF, 0xC8, 0xC6, 0xC7, 0xFF, 0xC7, 0xC8,
                0xC7, 0xFF, 0xC8, 0xC8, 0xC7, 0xFF, 0xC6, 0xC7, 0xC8, 0xFF, 0xC8, 0xC7, 0xC8, 0xFF, 0xC7, 0xC8,
                0xC8, 0xFF, 0xCB, 0xCB, 0xCB, 0xFF, 0xCF, 0xD0, 0xCF, 0xFF, 0xD0, 0xD0, 0xCF, 0xFF, 0xCF, 0xCF,
                0xD0, 0xFF, 0xD0, 0xCF, 0xD0, 0xFF, 0xCF, 0xD0, 0xD0, 0xFF, 0xD3, 0xD3, 0xD3, 0xFF, 0xD8, 0xD7,
                0xD7, 0xFF, 0xD7, 0xD8, 0xD6, 0xFF, 0xD8, 0xD8, 0xD7, 0xFF, 0xD7, 0xD6, 0xD8, 0xFF, 0xD8, 0xD6,
                0xD8, 0xFF, 0xD7, 0xD8, 0xD8, 0xFF, 0xDB, 0xDB, 0xDB, 0xFF, 0xE0, 0xDF, 0xDF, 0xFF, 0xDF, 0xE0,
                0xDF, 0xFF, 0xE0, 0xE0, 0xDF, 0xFF, 0xDF, 0xDF, 0xE0, 0xFF, 0xE0, 0xDF, 0xE0, 0xFF, 0xDF, 0xE0,
                0xE0, 0xFF, 0xE3, 0xE3, 0xE3, 0xFF, 0xE8, 0xE6, 0xE7, 0xFF, 0xE7, 0xE8, 0xE6, 0xFF, 0xE6, 0xE7,
                0xE8, 0xFF, 0xE8, 0xE7, 0xE8, 0xFF, 0xEB, 0xEB, 0xEB, 0xFF, 0xF0, 0xEF, 0xEF, 0xFF, 0xEF, 0xF0,
                0xEF, 0xFF, 0xF0, 0xF0, 0xEF, 0xFF, 0xEF, 0xEF, 0xF0, 0xFF, 0xF0, 0xEF, 0xF0, 0xFF, 0xEF, 0xF0,
                0xF0, 0xFF, 0xF3, 0xF3, 0xF3, 0xFF, 0xF6, 0xF8, 0xF6, 0xFF, 0xF8, 0xF8, 0xF7, 0xFF, 0xF8, 0xF6,
                0xF8, 0xFF, 0xFC, 0xFC, 0xFC, 0xFF, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00,
                0x00, 0xFF, 0x00, 0x00, 0x00, 0xFF
        };

        static byte[] headerIndex8v2 = {
                0x42, 0x4D, 0x56, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x04, 0x00, 0x00, 0x28, 0x00,
                0x00, 0x00, 0x6E, 0x00, 0x00, 0x00, 0x6E, 0x00, 0x00, 0x00, 0x01, 0x00, 0x08, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC4, 0x0E, 0x00, 0x00, 0xC4, 0x0E, 0x00, 0x00, 0x00, 0x01,
                0x00, 0x00, 0x00, 0x01, 0x00, 0x00,
        };

        public static byte[] ConvertToBmp(byte[] data, int width, int height, int type, byte[] clut = null)
        {
            int lenRaw = data.Length;

            //if (type == 0x04)
            //    data = UncompressRLE(data, width * height * 4);

            byte[] header = headerRgb565;

            switch (type)
            {
                case 2: header = headerIndex8;
                    break;
                case 1: header = headerARgb32;
                    break;
                default:
                    header = headerRgb565;
                    break;
            }

            if (type == 0)
                data = AlignRowData(data, width, height, type);

            lenRaw = data.Length;

            data = FlipImageData(data, width, height, type);

            data = header.Concat(data).ToArray();

            int len = data.Length;

            data.SetDWord(0x02, (uint)len);

            if (type == 2)
            {
                data.SetByteArray(0x36, clut);
            }
            else
            {
                data.SetDWord(0x22, (uint)lenRaw);
            }

            data.SetDWord(0x12, (uint)width);
            data.SetDWord(0x16, (uint)height);


            return data;
        }

        public static byte[] ConvertToBmpGTR(byte[] data, int width, int height, int type, byte[] clut = null)
        {
            int lenRaw = data.Length;

            //if (type == 0x04)
            //    data = UncompressRLE(data, width * height * 4);

            byte[] header = headerRgb565;

            switch (type)
            {
                case 4:
                    header = headerARgb32_GTR;
                    break;
                case 3:
                    header = headerRgb565;
                    break;
                case 2:
                    header = headerRgb565;
                    break;
                case 1:
                    header = headerIndex8;
                    break;
                default:
                    header = headerRgb565;
                    break;
            }

            int newWidth = 0;

            if (type != 4)
                data = AlignRowData(data, width, height, type, out newWidth);
            else
                newWidth = width;

            lenRaw = data.Length;
            width = newWidth;

            data = FlipImageData(data, width, height, type);

            data = header.Concat(data).ToArray();

            int len = data.Length;

            data.SetDWord(0x02, (uint)len);

            if (type == 1)
            {
                data.SetByteArray(0x36, clut);
            }
            else
            {
                data.SetDWord(0x22, (uint)lenRaw);
            }

            data.SetDWord(0x12, (uint)width);
            data.SetDWord(0x16, (uint)height);

            return data;
        }

        internal static byte[] ConvertToBmpGTRv2(byte[] data, int width, int height, int type)
        {
            int lenRaw = data.Length;

            byte[] header = headerIndex8v2;
            switch (type)
            {
                case 4:
                    header = headerARgb32_GTR;
                    break;
                case 1:
                default:
                    header = headerIndex8v2;
                    break;
            }

            //lenRaw = data.Length;
            //width = newWidth;
            int cnt = 0x100;

            if (type == 1)
            {
                byte count = 0;

                if (count != 0)
                    cnt = count;

                int colorLen = cnt << 2;

                byte[] palette = data.Take(colorLen).ToArray();

                data = FlipImageData(data.Skip(colorLen).ToArray(), width, height, 1);
                data = header.Concat(palette).Concat(data).ToArray();
            }
            else
            {
                data = FlipImageData(data, width, height, type);
                data = header.Concat(data).ToArray();
            }

            data.SetDWord(0x02, (uint)data.Length);
            data.SetDWord(0x12, (uint)width);
            data.SetDWord(0x16, (uint)height);

            if (type == 1)
            {
                data.SetDWord(0x2E, (uint)cnt);
                data.SetDWord(0x32, (uint)cnt);
            }
            else
            {
                data.SetDWord(0x22, (uint)lenRaw);
            }

            return data;
        }


        private static byte[] AlignRowData(byte[] src, int width, int height, int type)
        {
            uint mul = 2u;
            if (type == 1) mul = 4u;
            if (type == 2) mul = 1u;

            uint rowLen = (uint)width * mul;
            uint rowLenA = (uint)(width + (width % 2)) * mul;

            byte[] dst = new byte[rowLenA * height];
            uint srcOffset = 0;

            for (int i = 0; i < height; i++)
            {
                dst.SetByteArray((int)(i * rowLenA), src.GetByteArray(srcOffset, rowLen));
                srcOffset += rowLen;
            }

            return dst;
        }

        private static byte[] AlignRowData(byte[] src, int width, int height, int type, out int dstWidth)
        {
            uint rowLen = (uint)(width * type);
            dstWidth = width + (width % 4);
            uint rowLenNew = (uint)(dstWidth * type);

            byte[] dst = new byte[rowLenNew * height];
            uint srcOffset = 0;

            for (int i = 0; i < height; i++)
            {
                dst.SetByteArray((int)(i * rowLenNew), src.GetByteArray(srcOffset, rowLen));
                srcOffset += rowLen;
            }

            return dst;
        }

        private static byte[] FlipImageData(byte[] src, int width, int height, int type)
        {
            uint rowLen = (uint)(width * type);
        
            byte[] dst = new byte[src.Length];
            uint srcOffset = (uint)src.Length - rowLen;

            for (int i = 0; i < height; i++)
            {
                dst.SetByteArray((int)(i * rowLen), src.GetByteArray(srcOffset, rowLen));
                srcOffset -= rowLen;
            }

            return dst;
        }

        internal static byte[] UncompressRLE(byte[] data, int destLen)
        {
            uint offset = 0;
            int lenUnpacked = 0;
            byte[] point = null;
            byte[] dataNew = new byte[destLen];

            try
            {

                do
                {
                    byte control = data[offset];
                    offset += 1;

                    if (control == 0xFF) break;

                    byte size = 0;
                    if ((control & 0x80) == 0x80)
                    {
                        // repeated data
                        size = (byte)(control & 0x7F);
                        point = data.GetByteArray(offset, 4);
                        for (int i = 0; i <= size; i++)
                        {
                            dataNew.SetByteArray(lenUnpacked, point);
                            lenUnpacked += 4;
                        }
                        offset += 4;
                    }
                    else
                    {
                        // unique data
                        size = control;
                        for (int i = 0; i <= size; i++)
                        {
                            point = data.GetByteArray(offset, 4);
                            dataNew.SetByteArray(lenUnpacked, point);
                            lenUnpacked += 4;
                            offset += 4;
                        }
                    }

                } while (offset < data.Length);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                Debug.WriteLine("offset: " + offset.ToString("X4"));
                Debug.WriteLine("len: " + data.Length.ToString("X4"));
                Debugger.Break();
            }

            return dataNew;
        }

        internal static byte[] UncompressRLEv2(byte[] data, int destLen)
        {
            uint offset = 0;
            int lenUnpacked = 0;
            byte point = 0;
            byte[] dataNew = new byte[destLen];

            try
            {

                do
                {
                    byte control = data[offset];
                    offset += 1;

                    //if (control == 0xFF) break;

                    byte size = 0;
                    if ((control & 0x80) == 0x00)
                    {
                        if (offset >= data.Length) break;

                        // repeated data
                        size = (byte)(control & 0x7F);
                        point = data.GetByte(offset);
                        for (int i = 0; i < size; i++)
                        {
                            if (lenUnpacked >= dataNew.Length)
                                break;

                            dataNew[lenUnpacked] = point;
                            lenUnpacked += 1;
                        }
                        offset += 1;
                    }
                    else
                    {
                        // unique data
                        size = (byte)(control & 0x7F);
                        for (int i = 0; i < size; i++)
                        {
                            if (lenUnpacked >= dataNew.Length)
                                break;

                            point = data.GetByte(offset);
                            dataNew[lenUnpacked] = point;
                            lenUnpacked += 1;
                            offset += 1;
                        }
                    }

                } while (offset < data.Length);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                Debug.WriteLine("offset: " + offset.ToString("X4"));
                Debug.WriteLine("len: " + data.Length.ToString("X4"));
                Debugger.Break();
            }

            return dataNew;
        }

        internal static byte[] UncompressRLEv1(byte[] data, int destLen)
        {
            uint offset = 0;
            int lenUnpacked = 0;
            byte[] point = null;
            byte[] dataNew = new byte[destLen];

            try
            {
                do
                {
                    byte control = data[offset];
                    offset += 1;

                    //if (control == 0xFF) break;

                    byte size = 0;
                    if ((control & 0x80) == 0x00)
                    {
                        if (offset >= data.Length - 4) break;

                        // repeated data
                        size = (byte)(control & 0x7F);
                        point = data.GetByteArray(offset, 4);
                        for (int i = 0; i < size; i++)
                        {
                            dataNew.SetByteArray(lenUnpacked, point);
                            lenUnpacked += 4;
                        }
                        offset += 4;
                    }
                    else
                    {
                        // unique data
                        size = (byte)(control & 0x7F);
                        for (int i = 0; i < size; i++)
                        {
                            point = data.GetByteArray(offset, 4);
                            dataNew.SetByteArray(lenUnpacked, point);
                            lenUnpacked += 4;
                            offset += 4;
                        }
                    }

                } while (offset < data.Length);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                Debug.WriteLine("offset: " + offset.ToString("X4"));
                Debug.WriteLine("len: " + data.Length.ToString("X4"));
                Debugger.Break();
            }

            return dataNew;
        }

    }
}
