using System;
using System.Globalization;

namespace Viski
{
	// Token: 0x02000033 RID: 51
	public static class DiscordHelpers
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000B124 File Offset: 0x00009324
		public static string DateTimeToISO(DateTime dateTime)
		{
			return DiscordHelpers.DateTimeToISO(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000B164 File Offset: 0x00009364
		public static string DateTimeToISO(int year, int month, int day, int hour, int minute, int second)
		{
			return new DateTime(year, month, day, hour, minute, second, 0, DateTimeKind.Local).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
		}
	}
}
