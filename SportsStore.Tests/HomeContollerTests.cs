using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Interfaces;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Tests
{
    public class HomeContollerTests
    {
        [Fact]
        public void Can_Use_Repository()
        {
            // Организация
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"}
                }).AsQueryable());
            HomeController controller = new HomeController(mock.Object);

            // Действие
            ProductsListViewModel? result = (controller.Index() as ViewResult)?.ViewData.Model
                as ProductsListViewModel;
            Product[]? prodArray = result?.Products.ToArray();

            // Утверждение
            Assert.True(prodArray?.Length == 2);
            Assert.Equal("P1", prodArray[0].Name);
            Assert.Equal("P2", prodArray[1].Name);
        }

        [Fact]
        public void Can_Paginate()
        {
            // Arrange - Организация
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(p => p.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }).AsQueryable());
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;

            // Act - Действие
            ProductsListViewModel? result = (controller.Index(2) as ViewResult)?.ViewData?.Model
                as ProductsListViewModel;
            Product[]? prodArray = result?.Products.ToArray();

            // Asserts - Утверждение
            Assert.True(prodArray?.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange - Организация
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(p => p.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }).AsQueryable());

            HomeController controller = new HomeController(mock.Object) { PageSize = 3 };

            // Act - Действие
            ProductsListViewModel? result = (controller.Index(2) as ViewResult)?.ViewData?.Model 
                as ProductsListViewModel;
            PagingInfo? pageInfo = result?.PagingInfo;

            // Asserts - Утверждения
            Assert.Equal(2, pageInfo?.CurrentPage);
            Assert.Equal(3, pageInfo?.ItemsPerPage);
            Assert.Equal(5, pageInfo?.TotalItems);
            Assert.Equal(2, pageInfo?.TotalPages);
        }
    }
}
