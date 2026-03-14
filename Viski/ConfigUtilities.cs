using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Viski
{
	// Token: 0x0200007B RID: 123
	public class ConfigUtilities
	{
		// Token: 0x060002A4 RID: 676 RVA: 0x0001BFCC File Offset: 0x0001A1CC
		private static string smethod_0(string string_1 = "DarkNightDefault")
		{
			return ConfigUtilities.string_0 + string_1 + ".config";
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0001BFF0 File Offset: 0x0001A1F0
		public static void CreateEnvironment()
		{
			if (!Directory.Exists(ConfigUtilities.string_0))
			{
				Directory.CreateDirectory(ConfigUtilities.string_0);
			}
			if (!File.Exists(ConfigUtilities.smethod_0("DarkNightDefault")))
			{
				ConfigUtilities.SaveConfig("DarkNightDefault", false);
			}
			else
			{
				ConfigUtilities.LoadConfig("DarkNightDefault");
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0001C048 File Offset: 0x0001A248
		public static void SaveConfig(string name = "DarkNightDefault", bool setconfig = false)
		{
			string path = ConfigUtilities.smethod_0(name);
			string contents = JsonConvert.SerializeObject(G.Settings, 1);
			File.WriteAllText(path, contents);
			if (setconfig)
			{
				ConfigUtilities.SelectedConfig = name;
			}
			NotificationWindow.AddNotification("Save Configs - " + name);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0001C090 File Offset: 0x0001A290
		public static void LoadConfig(string name = "DarkNightDefault")
		{
			string text = File.ReadAllText(ConfigUtilities.smethod_0(name));
			Config settings = JsonConvert.DeserializeObject<Config>(text);
			G.Settings = settings;
			ConfigUtilities.SelectedConfig = name;
			C.AddColors();
			Hotkeys.AddKey();
			NotificationWindow.AddNotification("Load Configs - " + name);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0001C0DC File Offset: 0x0001A2DC
		public static List<string> GetConfigs(bool Extensions = false)
		{
			List<string> list = new List<string>();
			DirectoryInfo directoryInfo = new DirectoryInfo(ConfigUtilities.string_0);
			FileInfo[] files = directoryInfo.GetFiles("*.config");
			foreach (FileInfo fileInfo in files)
			{
				if (Extensions)
				{
					list.Add(fileInfo.Name.Substring(0, fileInfo.Name.Length));
				}
				else
				{
					list.Add(fileInfo.Name.Substring(0, fileInfo.Name.Length - 7));
				}
			}
			return list;
		}

		// Token: 0x0400030D RID: 781
		public static string AppdatYol = Environment.ExpandEnvironmentVariables("%appdata%");

		// Token: 0x0400030E RID: 782
		public static string SelectedConfig = "DarkNightDefault";

		// Token: 0x0400030F RID: 783
		private static string string_0 = ConfigUtilities.AppdatYol + "/DarkNight/Configs/";
	}
}
