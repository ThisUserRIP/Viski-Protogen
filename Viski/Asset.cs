using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200006E RID: 110
	public class Asset
	{
		// Token: 0x06000269 RID: 617 RVA: 0x00015174 File Offset: 0x00013374
		public static void Get()
		{
			if (!Directory.Exists(Viski1.AppdatYol + "/DarkNight/CustomScreenShot"))
			{
				Directory.CreateDirectory(Viski1.AppdatYol + "/DarkNight/CustomScreenShot");
			}
			AssetBundle assetBundle = AssetBundle.LoadFromMemory(new WebClient().DownloadData("http://93.127.131.185/dn"));
			if (assetBundle)
			{
				NotificationWindow.AddNotification("<b>[!]</b>    Assets Loaded");
			}
			foreach (Shader shader in assetBundle.LoadAllAssets<Shader>())
			{
				Asset.Shaders.Add(shader.name, shader);
			}
			foreach (Texture2D texture2D in assetBundle.LoadAllAssets<Texture2D>())
			{
				if (texture2D.name != "Font Texture")
				{
					Asset.Textures.Add(texture2D.name, texture2D);
				}
			}
			Asset.Lightening2 = Asset.Textures["shadertex"];
			Asset.Lightening = Asset.Textures["LighteningTex"];
			Asset.WireFrame = Asset.Textures["WireFrame"];
			Asset.Farm = Asset.Textures["Farm"];
			Asset.Resources = Asset.Textures["Resources"];
			Asset.NPC = Asset.Textures["NPC"];
			Asset.DNLogo = Asset.Textures["DNLogo"];
			Asset.AimbotIcon = Asset.Textures["AimbotIcon"];
			Asset.MiscIcon = Asset.Textures["Misc"];
			Asset.SettingsIcon = Asset.Textures["SettingIcon"];
			Asset.PlayerIcon = Asset.Textures["PlayerIcon"];
			Asset.BacktrackIcon = Asset.Textures["PlayerIcon"];
			Asset.VisualIcon = Asset.Textures["VisualIcon"];
			Asset.SkinIcon = Asset.Textures["SkinIcon"];
			Asset.KeyboardIcon = Asset.Textures["Keyboard"];
			Asset.DNLogo = Asset.Textures["DNLogo"];
			Asset.Battleye = Asset.Textures["Battleye"];
			Asset.Player = Asset.Textures["NormalPlayer"];
			Asset.ChamsPlayer = Asset.Textures["ChamsPlayer"];
			Asset.Zombie = Asset.Textures["Zombie"];
			Asset.Sentry = Asset.Textures["Sentry"];
			Asset.Yatak = Asset.Textures["Yatak"];
			Asset.Vehicle = Asset.Textures["Vehicle"];
			Asset.ClaimFlag = Asset.Textures["ClaimFlag"];
			Asset.Locker = Asset.Textures["Locker"];
			Asset.Item = Asset.Textures["Item"];
			Asset.Airdrop = Asset.Textures["Airdrop"];
			Asset.XrayPlayer = Asset.Textures["XrayPlayer"];
			Asset.Skin = assetBundle.LoadAllAssets<GUISkin>().First<GUISkin>();
		}

		// Token: 0x040002BA RID: 698
		public static Dictionary<string, Shader> Shaders = new Dictionary<string, Shader>();

		// Token: 0x040002BB RID: 699
		public static GUISkin Skin;

		// Token: 0x040002BC RID: 700
		public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

		// Token: 0x040002BD RID: 701
		public static Texture2D Lightening2;

		// Token: 0x040002BE RID: 702
		public static Texture2D Lightening;

		// Token: 0x040002BF RID: 703
		public static Texture2D WireFrame;

		// Token: 0x040002C0 RID: 704
		public static Texture2D Farm;

		// Token: 0x040002C1 RID: 705
		public static Texture2D Resources;

		// Token: 0x040002C2 RID: 706
		public static Texture2D NPC;

		// Token: 0x040002C3 RID: 707
		public static Texture2D AimbotIcon;

		// Token: 0x040002C4 RID: 708
		public static Texture2D VisualIcon;

		// Token: 0x040002C5 RID: 709
		public static Texture2D MiscIcon;

		// Token: 0x040002C6 RID: 710
		public static Texture2D SettingsIcon;

		// Token: 0x040002C7 RID: 711
		public static Texture2D SkinIcon;

		// Token: 0x040002C8 RID: 712
		public static Texture2D KeyboardIcon;

		// Token: 0x040002C9 RID: 713
		public static Texture2D DNLogo;

		// Token: 0x040002CA RID: 714
		public static Texture2D Battleye;

		// Token: 0x040002CB RID: 715
		public static Texture2D Player;

		// Token: 0x040002CC RID: 716
		public static Texture2D ChamsPlayer;

		// Token: 0x040002CD RID: 717
		public static Texture2D XrayPlayer;

		// Token: 0x040002CE RID: 718
		public static Texture2D Zombie;

		// Token: 0x040002CF RID: 719
		public static Texture2D Sentry;

		// Token: 0x040002D0 RID: 720
		public static Texture2D Locker;

		// Token: 0x040002D1 RID: 721
		public static Texture2D Yatak;

		// Token: 0x040002D2 RID: 722
		public static Texture2D Item;

		// Token: 0x040002D3 RID: 723
		public static Texture2D Airdrop;

		// Token: 0x040002D4 RID: 724
		public static Texture2D Vehicle;

		// Token: 0x040002D5 RID: 725
		public static Texture2D ClaimFlag;

		// Token: 0x040002D6 RID: 726
		public static Texture2D PlayerIcon;

		// Token: 0x040002D7 RID: 727
		public static Texture2D BacktrackIcon;
	}
}
