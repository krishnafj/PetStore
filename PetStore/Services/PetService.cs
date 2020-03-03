using PetStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace PetStore.Services
{
    /// <summary>
    /// Pet Service class to get all the details about Pets
    /// </summary>
    public class PetService
    {
        private string _apiUri;

        public enum statusEnum
        {
            available,
            pending,
            sold
        }

        public PetService(string apiUri)
        {
            _apiUri = apiUri;
        }

        /// <summary>
        /// Gets a list f pets by status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Pet> GetPetByStatus(statusEnum status)
        {
            List<Pet> pets = new List<Pet>();
            string apiUriPath = $"{_apiUri}findByStatus?status={status}";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(apiUriPath);
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = string.Empty;

                    using (var stream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(stream))
                        {
                            content = sr.ReadToEnd();
                        }
                    }

                    pets = JsonConvert.DeserializeObject<List<Pet>>(content);
                }
            }
            catch (Exception ex)
            {
                pets = null;
            }

            return pets;
        }
    }
}
