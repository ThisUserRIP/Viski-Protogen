using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Viski
{
	// Token: 0x0200002F RID: 47
	public class LUG
	{
		// Token: 0x060000C2 RID: 194 RVA: 0x0000A8C8 File Offset: 0x00008AC8
		public LUG(string WbhURL)
		{
			this.WbhURLL = new Uri(WbhURL);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000A8E8 File Offset: 0x00008AE8
		public void PostMessage(WbhMessage message)
		{
			HttpWebRequest httpWebRequest = WebRequest.CreateHttp(this.WbhURLL);
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

		// Token: 0x060000C4 RID: 196 RVA: 0x0000A988 File Offset: 0x00008B88
		public Task PostMessageAsync(WbhMessage message)
		{
			LUG.<PostMessageAsync>d__3 <PostMessageAsync>d__ = new LUG.<PostMessageAsync>d__3();
			<PostMessageAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<PostMessageAsync>d__.<>4__this = this;
			<PostMessageAsync>d__.message = message;
			<PostMessageAsync>d__.<>1__state = -1;
			<PostMessageAsync>d__.<>t__builder.Start<LUG.<PostMessageAsync>d__3>(ref <PostMessageAsync>d__);
			return <PostMessageAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0400011A RID: 282
		public Uri WbhURLL;
	}
}
