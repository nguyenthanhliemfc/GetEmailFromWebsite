private async Task<string> FindEmailFromWebsite(string website)
        {
            string email = "";
            try
            {                
                Regex regexString = new Regex(@"([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+)");

                HttpClient hpClient = new HttpClient();
                HttpResponseMessage requestMessage = await hpClient.GetAsync(website);
                var doc = new HtmlDocument();
                doc.LoadHtml(await requestMessage.Content.ReadAsStringAsync());

                var emails = regexString.Match(doc.ParsedText);

                return email = emails.Captures[0].ToString();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Find Email From Web error: " + e.Message);
                return null;
            }
        }