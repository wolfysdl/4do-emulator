using System;

namespace FourDO.Emulation.FreeDO
{
	internal class BitmapCrop : IComparable
	{
		public int Left { get; set; }
		public int Top { get; set; }
		public int Bottom { get; set; }
		public int Right { get; set; }

		public int CompareTo(object obj)
		{
			BitmapCrop otherCrop = obj as BitmapCrop;
			if (otherCrop != null)
			{
				if (this.Left > otherCrop.Left)
					return 1;
				else if (this.Left < otherCrop.Left)
					return -1;

				if (this.Top > otherCrop.Top)
					return 1;
				else if (this.Top < otherCrop.Top)
					return -1;

				if (this.Bottom > otherCrop.Bottom)
					return 1;
				else if (this.Bottom < otherCrop.Bottom)
					return -1;

				if (this.Right > otherCrop.Right)
					return 1;
				else if (this.Right < otherCrop.Right)
					return -1;

				return 0;
			}
			else
				throw new InvalidCastException("BitmapCrop comparable only to other BitmapCrop objects");
		}

		public void Mimic(BitmapCrop otherCrop)
		{
			this.Left = otherCrop.Left;
			this.Top = otherCrop.Top;
			this.Bottom = otherCrop.Bottom;
			this.Right = otherCrop.Right;
		}
	}
}
