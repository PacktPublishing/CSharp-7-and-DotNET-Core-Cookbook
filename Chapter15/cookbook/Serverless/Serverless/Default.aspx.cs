using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using http = System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace Serverless
{
    public partial class _Default : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            //CallAzureFunction();

        }

        //public async Task CallAzureFunction()
        //{
        //    http.HttpClient client = new http.HttpClient();
        //    string url = "https://funccredits.azurewebsites.net/api/HttpTriggerCSharp1?code=77yzSRmnRcguSoESONfUzoVa4itkv4av/PdnrvGyFaDibe5SgfHZtA==";
        //    Person person = new Person { Name = "Dirk Strauss" };

        //    string jobj = JsonConvert.SerializeObject(person);
        //    lblResponse.Text = "none";

        //    await callFunc(client, url, jobj);

        //    var response = callFunc(client, url, jobj);
            
        //}

        //private async Task callFunc(http.HttpClient client, string url, string jobj)
        //{
        //    var response = await client.PostAsync(url,
        //        new StringContent(jobj, Encoding.UTF8, "application/json"));

        //    string reponseString = "";
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        reponseString = await response.Content.ReadAsStringAsync();
        //        lblResponse.Text = reponseString;
        //    }

            
        //}

        
    }

    public class Person
    {
        public string Name { get; set; }
    }

    
}