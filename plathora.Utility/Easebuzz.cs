using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace plathora.Utility
{
	public class Easebuzz
	{

		public string easebuzz_action_url = string.Empty;
		public string gen_hash;
		public string txnid = String.Empty;
		public string easebuzz_merchant_key = string.Empty;
		public string salt = string.Empty;
		public string Key = string.Empty;
		public string env = string.Empty;
		public Easebuzz(string SALT, string KEY, string ENV)
		{
			salt = SALT;
			Key = KEY;
			env = ENV;
		}
		// this function is required to initiate payment
		public string initiatePaymentAPI(string Amount, String Firstname, String Email, String Phone, String Productinfo, String Surl, String Furl, String Txnid, String Udf1, String Udf2, String Udf3, String Udf4, String Udf5, String Show_payment_mode,string split_payments,string registerbyAffilateid)
		{
			string[] hashVarsSeq;
			string hash_string = string.Empty;
			string saltvalue = salt;
			string amount = Amount;
			string firstname = Firstname;
			string email = Email;
			string phone = Phone;
			string productinfo = Productinfo;
			string surl = Surl;
			string furl = Furl;
			string udf1 = Udf1;
			string udf2 = Udf2;
			string udf3 = Udf3;
			string udf4 = Udf4;
			string udf5 = Udf5;
			string ShowPaymentMode = Show_payment_mode;
			string split_payments1 = split_payments;
			// Generate transaction ID -> make sure this is unique for all transactions
			Random rnd = new Random();
			string strHash = Easebuzz_Generatehash512(rnd.ToString() + DateTime.Now);
			//txnid = strHash.ToString().Substring(0, 20);
			txnid = Txnid;

			string paymentUrl = getURL();
			// Get configs from web config
			easebuzz_action_url = paymentUrl + "/pay/secure";

			// generate hash table
			System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
			data.Add("txnid", txnid);
			data.Add("key", Key);
			//string AmountForm = Convert.ToDecimal(amount.Trim()).ToString("g29");// eliminating trailing zeros
			//amount = amount;
			data.Add("amount", amount);
			data.Add("firstname", firstname.Trim());
			data.Add("email", email.Trim());
			data.Add("phone", phone.Trim());
			data.Add("productinfo", productinfo.Trim());
			data.Add("surl", surl.Trim());
			data.Add("furl", furl.Trim());
			data.Add("udf1", udf1.Trim());
			data.Add("udf2", udf2.Trim());
			data.Add("udf3", udf3.Trim());
			data.Add("udf4", udf4.Trim());
			data.Add("udf5", udf5.Trim());
			data.Add("show_payment_mode", ShowPaymentMode.Trim());
			if (String.IsNullOrEmpty(registerbyAffilateid))
			{

			}
			else
			{
				//string test = "'" + "{\"YOG191362\" : 2.00,\"PLE010890\" : 2.17}" + "'";
				data.Add("split_payments", split_payments1);
			}

			// generate hash
			hashVarsSeq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10".Split('|'); // spliting hash sequence from config
			hash_string = "";
			foreach (string hash_var in hashVarsSeq)
			{
				hash_string = hash_string + (data.ContainsKey(hash_var) ? data[hash_var].ToString() : "");
				hash_string = hash_string + '|';
			}
			hash_string += salt;// appending SALT
			gen_hash = Easebuzz_Generatehash512(hash_string).ToLower();        //generating hash
			data.Add("hash", gen_hash);
			
			
			//data.Add("split_payments", split_payments1.Trim());
			string strForm = Easebuzz_PreparePOSTForm(easebuzz_action_url, data);

		//	string strForm = "<form id=\"PostForm\" name=\"PostForm\" action=\"https://pay.easebuzz.in/pay/secure\" method=\"POST\"><input type=\"hidden\" name=\"firstname\" value=\"YOGESH\"><input type=\"hidden\" name=\"hash\" value=\"caac45be61e52e4e5a71cb98d3bff35487237a98271c326afa3cbade72eb2588104ba41bcaebaa5191c118e0c6a9f97cb44232836245a5b9b52ff4ccdfca752c\"><input type=\"hidden\" name=\"amount\" value=\"2.36\">< input type =\"hidden\" name=\"split_payments\" value=\"\"><input type=\"hidden\" name=\"udf4\" value=\"\"><input type=\"hidden\" name=\"txnid\" value=\"110\"><input type=\"hidden\" name=\"furl\" value=\"https://localhost:44322/Admin/Customerprofile/FailureAction\"><input type=\"hidden\" name=\"phone\" value=\"7276541222\"><input type=\"hidden\" name=\"udf5\" value=\"\"><input type=\"hidden\" name=\"udf2\" value=\"\"><input type=\"hidden\" name=\"email\" value=\"manekar.yogesh1@gmail.com\"><input type=\"hidden\" name=\"key\" value=\"43JVTVB1CX\"><input type=\"hidden\" name=\"show_payment_mode\" value=\"NB,DC,CC,UPI\"><input type=\"hidden\" name=\"udf3\" value=\"\"><input type=\"hidden\" name=\"productinfo\" value=\"test\"><input type=\"hidden\" name=\"surl\" value=\"https://localhost:44322/Admin/Customerprofile/SuccessAction\"><input type=\"hidden\" name=\"udf1\" value=\"\"></form><script language='javascript'>var vPostForm = document.PostForm;vPostForm.submit();</script>";
			//string strForm = "<form id=\"PostForm\" name=\"PostForm\" action=\"https://pay.easebuzz.in/pay/secure\" method=\"POST\"><input type=\"hidden\" name=\"firstname\" value=\"YOGESH\"><input type=\"hidden\" name=\"amount\" value=\"2.36\"><input type=\"hidden\" name=\"udf5\" value=\"\"><input type=\"hidden\" name=\"hash\" value=\"5c12bdd89ded7e8f293a7ed0e68be6421af4addf1f5452934b9ec863d33292e2c2aacbbdb2e169deda2487f804e27bc58bdfaa9f70c96803f6dfd8f885fe12bb\"><input type=\"hidden\" name=\"furl\" value=\"https://localhost:44322/Admin/Customerprofile/FailureAction\"><input type=\"hidden\" name=\"phone\" value=\"7276541222\"><input type=\"hidden\" name=\"txnid\" value=\"97\"><input type=\"hidden\" name=\"show_payment_mode\" value=\"NB,DC,CC,UPI\"><input type=\"hidden\" name=\"key\" value=\"43JVTVB1CX\"><input type=\"hidden\" name=\"surl\" value=\"https://localhost:44322/Admin/Customerprofile/SuccessAction\"><input type=\"hidden\" name=\"udf3\" value=\"\"><input type=\"hidden\" name=\"split_payments\" value={\"YOG191362\" : 2.00, \"PLE010890\" : 2.00}><input type=\"hidden\" name=\"udf2\" value=\"\"><input type=\"hidden\" name=\"email\" value=\"manekar.yogesh1@gmail.com\"><input type=\"hidden\" name=\"productinfo\" value=\"test payment1\"><input type=\"hidden\" name=\"udf4\" value=\"\"><input type=\"hidden\" name=\"udf1\" value=\"\"></form><script language='javascript'>var vPostForm = document.PostForm;vPostForm.submit();</script>";
			return strForm;

		}

		//prepare a postform for redirection to payment gateway
		public string Easebuzz_PreparePOSTForm(string url, System.Collections.Hashtable data)
		{
			//Set a name for the form
			string formID = "PostForm";
			//Build the form using the specified data to be posted.
			StringBuilder strForm = new StringBuilder();
			strForm.Append("<form id=\"" + formID + "\" name=\"" +
						   formID + "\" action=\"" + url +
						   "\" method=\"POST\">");

			foreach (System.Collections.DictionaryEntry key in data)
			{
				if (key.Key.ToString().Contains("split_payments"))
				{
					//strForm.Append("<input type=\"hidden\" name=\"split_payments\" value='{\"YOG191362\" : 0.19,\"PLE010890\" : 2.17}'>");
					strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
							  "\" value=\'" + key.Value + "\'>");
				}
				else
				{
					strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
							   "\" value=\"" + key.Value + "\">");
				}

			}
			strForm.Append("</form>");
			//Build the JavaScript which will do the Posting operation.
			StringBuilder strScript = new StringBuilder();
			strScript.Append("<script language='javascript'>");
			strScript.Append("var v" + formID + " = document." +
							 formID + ";");
			strScript.Append("v" + formID + ".submit();");
			strScript.Append("</script>");
			//Return the form and the script concatenated.
			//(The order is important, Form then JavaScript)
			return strForm.ToString() + strScript.ToString();
		}

		// hashcode generation
		public string Easebuzz_Generatehash512(string text)
		{

			byte[] message = Encoding.UTF8.GetBytes(text);

			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] hashValue;
			SHA512Managed hashString = new SHA512Managed();
			string hex = "";
			hashValue = hashString.ComputeHash(message);
			foreach (byte x in hashValue)
			{
				hex += String.Format("{0:x2}", x);
			}
			return hex;

		}



		//get url using env varibale
		public string getURL()
		{
			if (env == "test")
			{
				string paymentUrl = "https://testpay.easebuzz.in";
				return paymentUrl;
			}
			else
			{
				string paymentUrl = "https://pay.easebuzz.in";
				return paymentUrl;
			}
		}

		//initiate refund api 
		public string RefundAPI(string txnid, string refund_amount, string phone, string amount, string email)
		{
			System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
			data.Add("txnid", txnid.Trim());
			data.Add("refund_amount", refund_amount.Trim());
			data.Add("key", Key);
			//string AmountForm = Convert.ToDecimal(amount.Trim()).ToString("g29");// eliminating trailing zeros
			//amount = AmountForm;
			data.Add("amount", amount);
			data.Add("email", email.Trim());
			data.Add("phone", phone.Trim());
			// generate hash
			string[] hashVarsSeq = "key|txnid|amount|refund_amount|email|phone".Split('|'); // spliting hash sequence from config
			string hash_string = "";
			foreach (string hash_var in hashVarsSeq)
			{
				hash_string = hash_string + (data.ContainsKey(hash_var) ? data[hash_var].ToString() : "");
				hash_string = hash_string + '|';
			}
			hash_string += salt;// appending SALT
			Console.WriteLine(hash_string);
			gen_hash = Easebuzz_Generatehash512(hash_string).ToLower();        //generating hash
			data.Add("hash", gen_hash);

			var postData = "txnid=" + txnid;
			postData += "&refund_amount=" + refund_amount;
			postData += "&phone=" + phone;
			postData += "&key=" + Key;
			postData += "&amount=" + amount;
			postData += "&email=" + email;
			postData += "&hash=" + gen_hash;

			string url = "https://dashboard.easebuzz.in/transaction/v1/refund";

			var request = (HttpWebRequest)WebRequest.Create(url);

			var Ndata = Encoding.ASCII.GetBytes(postData);

			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = Ndata.Length;

			using (var stream = request.GetRequestStream())
			{
				stream.Write(Ndata, 0, Ndata.Length);
			}

			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			return responseString;
		}

		//initiates transaction api 
		public string transactionAPI(string txnid, string amount, string email, string phone)
		{
			System.Collections.Hashtable data = new System.Collections.Hashtable();
			data.Add("key", Key);
			data.Add("txnid", txnid);
			data.Add("amount", amount);
			data.Add("email", email);
			data.Add("phone", phone);

			// generate hash
			string[] hashVarsSeq = "key|txnid|amount|email|phone".Split('|'); // spliting hash sequence from config
			string hash_string = "";
			foreach (string hash_var in hashVarsSeq)
			{
				hash_string = hash_string + (data.ContainsKey(hash_var) ? data[hash_var].ToString() : "");
				hash_string = hash_string + '|';
			}
			hash_string += salt;// appending SALT
			Console.WriteLine(hash_string);
			gen_hash = Easebuzz_Generatehash512(hash_string).ToLower();        //generating hash
			data.Add("hash", gen_hash);

			string url = "https://dashboard.easebuzz.in/transaction/v1/retrieve";
			var request = (HttpWebRequest)WebRequest.Create(url);

			var postData = "txnid=" + txnid;
			postData += "&amount=" + amount;
			postData += "&email=" + email;
			postData += "&phone=" + phone;
			postData += "&key=" + Key;
			postData += "&hash=" + gen_hash;

			var Ndata = Encoding.ASCII.GetBytes(postData);

			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = Ndata.Length;

			using (var stream = request.GetRequestStream())
			{
				stream.Write(Ndata, 0, Ndata.Length);
			}

			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			//Response.Write(responseString);
			//string testResponse = "take it or leave it </br>";
			return responseString;
		}

		//iniitiate transactionDateAPI api 
		public string transactionDateAPI(string merchant_email, string transaction_date)
		{
			System.Collections.Hashtable data = new System.Collections.Hashtable();
			data.Add("key", Key);
			data.Add("merchant_email", merchant_email);
			data.Add("transaction_date", transaction_date);
			// generate hash
			string[] hashVarsSeq = "key|merchant_email|transaction_date".Split('|'); // spliting hash sequence from config
			string hash_string = "";
			foreach (string hash_var in hashVarsSeq)
			{
				hash_string = hash_string + (data.ContainsKey(hash_var) ? data[hash_var].ToString() : "");
				hash_string = hash_string + '|';
			}
			hash_string += salt;// appending SALT
			gen_hash = Easebuzz_Generatehash512(hash_string).ToLower();        //generating hash
			data.Add("hash", gen_hash);

			string url = "https://dashboard.easebuzz.in/transaction/v1/retrieve/date";
			var request = (HttpWebRequest)WebRequest.Create(url);

			var postData = "merchant_key=" + Key;
			postData += "&merchant_email=" + merchant_email;
			postData += "&transaction_date=" + transaction_date;
			postData += "&hash=" + gen_hash;

			var Ndata = Encoding.ASCII.GetBytes(postData);

			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = Ndata.Length;

			using (var stream = request.GetRequestStream())
			{
				stream.Write(Ndata, 0, Ndata.Length);
			}

			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			return responseString;
		}

		//initiate payoutAPI api 
		public string payoutAPI(string merchant_email, string payout_date)
		{
			System.Collections.Hashtable data = new System.Collections.Hashtable();
			data.Add("key", Key);
			data.Add("merchant_email", merchant_email);
			data.Add("payout_date", payout_date);
			// generate hash
			string[] hashVarsSeq = "key|merchant_email|payout_date".Split('|'); // spliting hash sequence from config
			string hash_string = "";
			foreach (string hash_var in hashVarsSeq)
			{
				hash_string = hash_string + (data.ContainsKey(hash_var) ? data[hash_var].ToString() : "");
				hash_string = hash_string + '|';
			}
			hash_string += salt;// appending SALT
			gen_hash = Easebuzz_Generatehash512(hash_string).ToLower();        //generating hash
			data.Add("hash", gen_hash);

			string url = "https://dashboard.easebuzz.in/payout/v1/retrieve";
			var request = (HttpWebRequest)WebRequest.Create(url);

			var postData = "merchant_key=" + Key;
			postData += "&merchant_email=" + merchant_email;
			postData += "&payout_date=" + payout_date;
			postData += "&hash=" + gen_hash;
			var Ndata = Encoding.ASCII.GetBytes(postData);

			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = Ndata.Length;

			using (var stream = request.GetRequestStream())
			{
				stream.Write(Ndata, 0, Ndata.Length);
			}

			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			return responseString;
		}


	}

}
