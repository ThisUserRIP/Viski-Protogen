using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace Viski
{
	// Token: 0x02000031 RID: 49
	public static class DiscordWbhService
	{
		// Token: 0x060000C8 RID: 200 RVA: 0x0000AD10 File Offset: 0x00008F10
		public static void PostMessage(string WbhURL, WbhMessage message)
		{
			HttpWebRequest httpWebRequest = WebRequest.CreateHttp(WbhURL);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/json";
			string s = JsonConvert.SerializeObject(message);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			httpWebRequest.ContentLength = (long)bytes.Length;
			using (Stream requestStream = httpWebRequest.GetRequestStream())
			{
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Flush();
			}
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000ADAC File Offset: 0x00008FAC
		public static void PostMessageAsync(string WbhURL, WbhMessage message)
		{
			DiscordWbhService.<PostMessageAsync>d__1 <PostMessageAsync>d__ = new DiscordWbhService.<PostMessageAsync>d__1();
			<PostMessageAsync>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<PostMessageAsync>d__.WbhURL = WbhURL;
			<PostMessageAsync>d__.message = message;
			<PostMessageAsync>d__.<>1__state = -1;
			<PostMessageAsync>d__.<>t__builder.Start<DiscordWbhService.<PostMessageAsync>d__1>(ref <PostMessageAsync>d__);
		}
	}
}
