﻿using RestSharp;

namespace IntercomDotNet.Resources
{
    public class Users : Resource
    {
        public Users(Client client, string baseUrl) : base(client, baseUrl)
        {
        }

        public dynamic Post(object hash)
        {
            return Client.Execute(BaseUrl, Method.POST, request =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }

        public dynamic Delete(object hash)
        {
            return Client.Execute(BaseUrl, Method.DELETE, request =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }

        public dynamic Get(string email = null, int? userId = null)
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
                {
                    if (email != null)
                        request.AddParameter("email", email);

                    if (userId != null)
                        request.AddParameter("user_id", userId.Value);
                });
        }

        public dynamic Get(int page = 1, int perPage = 500, string tagId = null, string tagName = null, string sort = null, string order = null)
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
                {
                    request.AddParameter("page", page);
                    request.AddParameter("per_page", perPage);

                    if (tagId != null)
                        request.AddParameter("tag_id", tagId);

                    if (tagName != null)
                        request.AddParameter("tag_name", tagName);

                    if (sort != null)
                        request.AddParameter("sort", sort);

                    if (order != null)
                        request.AddParameter("order", order);
                });
        }
    }
}
