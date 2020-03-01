using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using BlazorApp.Service;

namespace BlazorApp.sql
{
    public class MyHttpClient : HttpClient
    {
        
        private string sError;
        public string GetError()
        {
            return sError;
        }

        public async Task<T> GetJsonAsync<T>(string requestUri)
        {
            T obj = default;
            HttpClient httpClient = new HttpClient();
            var httpContent = await httpClient.GetAsync(requestUri);
            try
            {

                string jsonContent = httpContent.Content.ReadAsStringAsync().Result;
                if (httpContent.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (!string.IsNullOrEmpty(jsonContent))
                        obj = JsonConvert.DeserializeObject<T>(jsonContent);
                    else
                        ;
                }
                else
                {
                    sError = jsonContent;
                    return await Task.FromResult<T>(obj);

                    //return (T)Convert.ChangeType(jsonContent, typeof(T));

                    //return await Task.FromResult<T>(jsonContent);
                }

                return obj;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return await Task.FromResult<T>(obj);
            }
            finally
                {
                if (httpContent != null)
                    httpContent.Dispose();
                if (httpClient != null)
                    httpClient.Dispose();
            }

        }
        public async Task<HttpResponseMessage> PostJsonAsync<T>(string requestUri, T content)
        {
            HttpClient httpClient = new HttpClient();
            string myContent = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(requestUri, stringContent);
            httpClient.Dispose();
            return response;
        }
        public async Task<HttpResponseMessage> PutJsonAsync<T>(string requestUri, T content)
        {
            HttpClient httpClient = new HttpClient();
            string myContent = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(requestUri, stringContent);
            httpClient.Dispose();
            return response;
        }
    }

}

