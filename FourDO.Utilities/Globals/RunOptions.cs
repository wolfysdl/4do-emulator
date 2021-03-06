namespace FourDO.Utilities.Globals
{
	/// <summary>
	/// Access to global, one-time-only run options (usually set at the command line).
	/// </summary>
	public class RunOptions
	{
		public enum StartupFormOption
		{
			None = 0,
			ConfigureInput = 1,
		}

		public static string StartLoadFile { get; set; }
		public static char? StartLoadDrive { get; set; }
		public static bool StartFullScreen { get; set; }

		public static bool LogAudioDebug { get; set; }
		public static bool LogAudioTiming { get; set; }
		public static bool LogCPUTiming { get; set; }

		public static StartupFormOption StartupForm { get; set; }

		public static bool PrintKPrint { get; set; }
		public static bool ForceGdiRendering { get; set; }
		public static bool StartupPaused { get; set; }
	}
}
