using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        string email = "EMAIL-OR-USERNAME-HERE"; // replace with email or username given to you
        string password = "PASSWORD-HERE"; // replace with password given to you

        // Step 1: Login
        using (var client = new HttpClient())
        {                
            var loginData = new StringContent(System.Text.Json.JsonSerializer.Serialize(new
            {
                email = email,
                password = password
            }), 
            Encoding.UTF8, "application/json");

            var loginResponse = await client.PostAsync("https://challenger.code100.dev/login", loginData);
            var contentJson = await loginResponse.Content.ReadAsStringAsync();
            if (!loginResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Error: " + contentJson);
                return;
            }
            
            var content = JsonConvert.DeserializeObject<dynamic>(contentJson);
            string token = content.token;
            Console.WriteLine("Token: " + token);

            // Step 2: Call Authenticated Endpoint
            client.DefaultRequestHeaders.Authorization = new 
                System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var authResponse = await client.GetAsync("https://challenger.code100.dev/testauthroute");
            var result = await authResponse.Content.ReadAsStringAsync();
            Console.WriteLine(result);

            // Step 3: Get the puzzle
            var puzzleResponse = await client.GetAsync("https://challenger.code100.dev/getpuzzle");
            var puzzleJson = await puzzleResponse.Content.ReadAsStringAsync();
            var puzzle = JsonConvert.DeserializeObject<dynamic>(puzzleJson);
            Console.WriteLine("Puzzle: " + puzzle);

            // Step 4: Solve the puzzle

            ////////////////////////////
            ////// Your code here //////
            ////////////////////////////
            
            var answer = new StringContent(System.Text.Json.JsonSerializer.Serialize(new
            {
                answer = "some answer in required format"
            }),
            Encoding.UTF8, "application/json");


            // Step 5: Submit the answer
            var submitResponse = await client.PostAsync("https://challenger.code100.dev/postanswer", answer);
            var submitResult = await submitResponse.Content.ReadAsStringAsync();
            Console.WriteLine(submitResult);
        }
    }
}