using System;
using Xunit;
using Telerik.JustMock;

namespace timestampapi.tests
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      Assert.True(1==1);
    }

    [Fact]
    public void TestDate()
    {
      var dateProviderStub = Mock.Create<IDateProvider>();
      Mock.Arrange(() => dateProviderStub.DayOfWeek()).Returns(DayOfWeek.Monday);
      
      Assert.True(DayOfWeek.Monday ==dateProviderStub.DayOfWeek());
    }
  }
}
