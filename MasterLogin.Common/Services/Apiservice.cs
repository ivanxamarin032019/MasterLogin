﻿using MasterLogin.Common.Request;
using MasterLogin.Common.Responses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MasterLogin.Common.Services
{
    public class ApiService : IApiService
    {

        public async Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request)
        {
            try
            {
                string requestString = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(requestString, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = token
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> RegisterUserAsync(string urlBase, string servicePrefix, string controller, UserRequest userRequest)
        {
            try
            {
                string request = JsonConvert.SerializeObject(userRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();
                Response obj = JsonConvert.DeserializeObject<Response>(answer);
                return obj;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> RecoverPasswordAsync(string urlBase, string servicePrefix, string controller, EmailRequest emailRequest)
        {
            try
            {
                string request = JsonConvert.SerializeObject(emailRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();
                Response obj = JsonConvert.DeserializeObject<Response>(answer);
                return obj;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> ModifyUserAsync(string urlBase, string servicePrefix, string controller, UserRequest userRequest, string token)
        {
            try
            {
                string request = JsonConvert.SerializeObject(userRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PutAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Response>(answer);
                }

                UserResponse user = JsonConvert.DeserializeObject<UserResponse>(answer);
                return new Response
                {
                    IsSuccess = true,
                    Result = user
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> ChangePasswordAsync(string urlBase, string servicePrefix, string controller, ChangePasswordRequest changePasswordRequest, string token)
        {
            try
            {
                string request = JsonConvert.SerializeObject(changePasswordRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();
                Response obj = JsonConvert.DeserializeObject<Response>(answer);
                return obj;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }


    }
}
