using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MovieMagnet.Pages;

public class Index_Tests : MovieMagnetWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
