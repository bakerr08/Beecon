
        public void GetUser(int query_user_id, Action completion)
        {
            _Completion = completion;
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("user_id", User.UserId.ToString());
            d.Add("authentication_token", User.AuthenticationToken);
            d.Add("query_user_id", User.AuthenticationToken);

            string post_json = Newtonsoft.Json.JsonConvert.SerializeObject(d);
            PostDataWithOperation("getuser", post_json);
          
        }