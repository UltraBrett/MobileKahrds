using System;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Net.Http;

namespace MobileKahrds
{
	// http://bertt.wordpress.com/2013/03/19/using-geonames-webservices-from-portable-class-library-pcl/

	public class KahrdsWebService
	{
		private const string BASEADDR = "http://www.kahrds.com/api/";
		private string USERNAME = "";
		private string PASSWD = "";
		private const string AUTH = "cac115357e04060e810b48ded2d115c067c85521";
		private String SESSION = "bed30db943f7f6daf511206c1eae52164a84bdd07d12ef647210f4595757f2172b1220f91d85e0c469a20b485e87dec3d0e6075260a4c20acc484c42f3042bdc";


		public KahrdsWebService(){
			var account = App.Database.GetAccount();
			foreach (var kv in account){
				USERNAME = kv.Username;
				PASSWD = kv.Password;
			}
		}

		public async Task<String> AccountTest(string blackjack, string hookers){
			var client = new HttpClient ();
			client.BaseAddress = new Uri (BASEADDR);
			string uri = String.Format("login?user={0}&passwd={1}&auth_token={2}", blackjack, hookers, AUTH);
			var response = await client.PostAsync (uri, new System.Net.Http.StringContent ("") );
			var respStream = response.Content.ReadAsStreamAsync ().Result;
			var reader = new StreamReader (respStream, Encoding.UTF8);
			var sessionJson = reader.ReadToEnd ();

			return sessionJson;
		}

//		public async Task<String> GetSessionToken(){
//			var client = new HttpClient ();
//			client.BaseAddress = new Uri (BASEADDR);
//			string uri = String.Format("login?user={0}&passwd={1}&auth_token={2}", USERNAME, PASSWD, AUTH);
//			var response = await client.PostAsync (uri, new System.Net.Http.StringContent ("") );
//			// asynchronously wait for response
//			var respStream = response.Content.ReadAsStreamAsync ().Result;
//			var reader = new StreamReader (respStream, Encoding.UTF8);
//			var sessionJson = reader.ReadToEnd ();
//
//			return sessionJson;
//		}

		public async Task<String> GetSessionToken(string username, string password){
			var client = new HttpClient ();
			client.BaseAddress = new Uri (BASEADDR);
			string uri = String.Format("login?user={0}&passwd={1}&auth_token={2}", username, password, AUTH);
			var response = await client.PostAsync (uri, new System.Net.Http.StringContent ("") );
			// asynchronously wait for response
			var respStream = response.Content.ReadAsStreamAsync ().Result;
			var reader = new StreamReader (respStream, Encoding.UTF8);
			var sessionJson = reader.ReadToEnd ();

			return sessionJson;
		}


		public async Task<String> GetMyList(){
			var client = new System.Net.Http.HttpClient ();
			client.BaseAddress = new Uri (BASEADDR);
			string uri = String.Format ("{0}/kahrd_sets?auth_token={1}&session_token={2}", USERNAME, AUTH, SESSION);
			var response = await client.GetAsync (uri);
			// asynchronously wait for response
			var respJson = response.Content.ReadAsStreamAsync ().Result;
			var reader = new StreamReader (respJson, Encoding.UTF8);
			return reader.ReadToEnd();
		}


		public async Task<String> GetOneSetofKahrds(String setId)
		{ //gets a single set of cards.
			var client = new System.Net.Http.HttpClient ();
			client.BaseAddress = new Uri (BASEADDR);
			string uri = String.Format ("{0}/kahrd_sets/{1}?auth_token={2}&session_token={3}", USERNAME, setId, AUTH, SESSION );
			var response = await client.GetAsync (uri);
			// asynchronously wait for response
			var respJson = response.Content.ReadAsStreamAsync ().Result;
			var reader = new StreamReader (respJson, Encoding.UTF8);
			return reader.ReadToEnd();
		}

		public async Task<String> UploadNewSet ()
		{
			//returns the ID of the newly created set on the user's web account.
			var client = new System.Net.Http.HttpClient ();
			client.BaseAddress = new Uri (BASEADDR);
			string uri = String.Format ("{0}/kahrd_sets?auth_token={1}&session_token={2}", USERNAME, AUTH, SESSION );

//				make sure to add the HEADERS Content-Type application/json
//				in the body put a json string

			var jsonRequest = "";
//			var jsonRequest = JsonConvert.SerializeObject(obj);
			System.Net.Http.StringContent content  = new System.Net.Http.StringContent(jsonRequest, Encoding.UTF8, "text/json");
			var response = await client.PostAsync(uri, content);
			// asynchronously wait for response
			var respJson = response.Content.ReadAsStreamAsync ().Result;
			var reader = new StreamReader (respJson, Encoding.UTF8);
			return reader.ReadToEnd();
		}


		//TODO UPLOAD overwrite existing set on the website




		/// <summary>
		/// 
		/// </summary>
		/// <returns>The kahrd community.</returns>

		public async Task<String> GetKahrdCommunity(){
			var client = new System.Net.Http.HttpClient ();
			client.BaseAddress = new Uri (BASEADDR);
			string uri = String.Format ("community/en-us?auth_token={0}", AUTH);
			var response = await client.GetAsync (uri);
			// asynchronously wait for response
			var respJson = response.Content.ReadAsStreamAsync ().Result;
			var reader = new StreamReader (respJson, Encoding.UTF8);
			return reader.ReadToEnd();
		}
	}
}

