using Moq;
using System.Web.Http.Results;
using ProductSoat;
using Xunit;

namespace Product.Test
{
    public class ProductTest
    {      
        [Fact]
        public void ShouldAddByProductRequest()
        {
            var productRequest = Mock.Of<ProductRequest>();
            var mock = new Mock<IProductService>();
            mock.Setup(s => s.Add(productRequest)).Returns(true);

            ProductController controller = new ProductController(mock.Object);
            var result = controller.Post(productRequest);
            Assert.IsType<OkResult>(result);
        }
    }
}
