using EksiSozlukAPI.API;
using EksiSozlukAPI.Application.Features.Commands.User.CreateUser;
using EksiSozlukAPI.Application.Features.Commands.User.LoginUser;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace EksiSozlukTest
{
    public class UnitTest1 : IClassFixture<TestFactory<Program>>
    {
        private TestFactory<Program> _factory;
        private HttpClient _client;

        public UnitTest1(TestFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public void UserLoginTest()
        {
            UserCreateTest();
            var login = new LoginUserCommandRequest()
            {
                Nickname = "string",
                Password = "string"
            };
            var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var response = _client.PostAsync("https://localhost:7181/api/Auth", content).Result.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<LoginUserCommandResponse>(response);

            Assert.True(data.Success);
        }

        [Fact]
        public void UserCreateTest()
        {

            var create = new CreateUserCommandRequest()
            {
                Nickname = "string",
                Password = "string",
                Email = "string",           
            };

            var content = new StringContent(JsonConvert.SerializeObject(create), Encoding.UTF8, "application/json");
            var response = _client.PostAsync("https://localhost:7181/api/User", content).Result.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<LoginUserCommandResponse>(response);

            Assert.True(data.Success);
        }
    }
}