using contoso_pizza_backend.Models.ContosoPizzaDB;
using contoso_pizza_backend.Models.DTO;
using contoso_pizza_backend.Controllers;
using contoso_pizza_backend.Tests.Utils;
using FluentAssertions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace contoso_pizza_backend.Tests.Controllers
{
    [Collection("Database")]
    public sealed class CustomersControllerTests : IClassFixture<ContosoPizzaWebApplicationFactory>
    {
        private readonly ContosoPizzaWebApplicationFactory _factory;

        public CustomersControllerTests(ContosoPizzaWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Create_ShouldCreateCustomer()
        {
            // Arrange
            var createRequest = new CustomerDTO
            {
                FirstName = "test1",
                LastName = "test1",
                Address = "testAddress",
                Phone = "58963147",
                Email = "test@gmail.com" 
            };

            var client = _factory.CreateClient();

            // Act
            var postResponse = await client.PostAsync("/api/Customer/AddCustomer", new JsonContent<CustomerDTO>(createRequest));
            postResponse.EnsureSuccessStatusCode();
            var customerCreateResponse = await postResponse.Content.ReadAsJsonAsync<Customer>();

            // Assert - by calling the Get/id and comparing the results
            var getResponse = await client.GetAsync($"/api/Customer/GetCustomer/{customerCreateResponse.Id}");
            var customerGetResponse =  await getResponse.Content.ReadAsJsonAsync<Customer>();

            customerGetResponse.Should().BeEquivalentTo(customerCreateResponse);
        }

        [Fact]
        public async Task Update_ShouldUpdateCustomerFirstName()
        {
            // Arrange
            var client = _factory.CreateClient();

            var initialCustomer = await CreateRandomCustomer(client);

            //var updateRequest = new CustomerDTO(cu => cu.Id == initialCustomer.Id && cu.FirstName == Guid.NewGuid().ToString());
            
            var updateRequest = new CustomerDTO
            {
                // not a real FirstName but just something random.. we don't have any validation for now
                Id = initialCustomer.Id,
                FirstName = Guid.NewGuid().ToString(),
                LastName  = Guid.NewGuid().ToString(),
                Address = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString()
            };

            // Act
            System.Console.WriteLine("****************************************"+initialCustomer.Id+"****************************************");
            var response = await client.PutAsync("/api/Customer/UpdateCustomer", new JsonContent<CustomerDTO>(updateRequest));
            response.EnsureSuccessStatusCode();

            // Assert
            var getResponse = await client.GetAsync($"/api/Customer/GetCustomer/{initialCustomer.Id}");
            var actual = await getResponse.Content.ReadAsJsonAsync<Customer>();

            Assert.Equal(updateRequest.FirstName, actual.FirstName);
        }

        private async ValueTask<Customer> CreateRandomCustomer(HttpClient client)
        {
            // Arrange
            var createRequest = new CustomerDTO
            {
                FirstName = "testU",
                LastName = "testU",
                Address = "testAddressU",
                Phone = "23000789",
                Email = "testU@gmail.com" 
            };

            // Act
            var postResponse = await client.PostAsync("/api/Customer/AddCustomer", new JsonContent<CustomerDTO>(createRequest));
            postResponse.EnsureSuccessStatusCode();
            return await postResponse.Content.ReadAsJsonAsync<Customer>();
        }

        
    }
}