﻿using System;
using FourDO.Emulation.GameSource;
using FourDO.FileSystem;
using FourDO.Utilities;

namespace FourDO.UI.DiscBrowser
{
	internal class DiscFileReader : IFileReader
	{
		private IGameSource _gameSource;
		private uint _currentByte;

		public DiscFileReader(IGameSource gameSource)
		{
			_gameSource = gameSource;
		}

		public bool Read(IntPtr buf, uint bufLength, ref uint bytesRead)
		{
			unsafe
			{
				int sectorNumber = (int)(_currentByte / 2048);
				int offset = (int)(_currentByte % 2048);
				byte[] sectorBytes = new byte[2048];
				IntPtr bufWriteIntPtr = buf;
				int bytesCopied = 0;

				fixed (byte* sectorBytesPointer = sectorBytes)
				{
					while (bytesCopied < bufLength)
					{
						IntPtr sectorBytesIntPtr = new IntPtr((int) sectorBytesPointer);
						_gameSource.ReadSector(new IntPtr((int) sectorBytesPointer), sectorNumber);
						sectorBytesIntPtr = new IntPtr((int) sectorBytesPointer + offset);

						int bytesToCopy = Math.Min((int) (2048 - offset), (int) (bufLength - bytesCopied));
						Memory.CopyMemory(bufWriteIntPtr, sectorBytesIntPtr, bytesToCopy);
						bytesCopied += bytesToCopy;
						bufWriteIntPtr = new IntPtr(buf.ToInt32() + offset);

						offset = 0;
						sectorNumber++;
					}
				}
				_currentByte += (uint)bytesCopied;
				bytesRead = (uint)bytesCopied;
			}
			return true;
		}

		public bool SeekToByte(uint byteNumber, bool relative)
		{
			if (!relative)
				_currentByte = (uint) byteNumber;
			else
				_currentByte += (uint) byteNumber;
			return true;
		}

		public uint CurrentByte
		{
			get { return _currentByte; }
		}
	}
}
