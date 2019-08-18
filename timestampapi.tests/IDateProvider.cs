using System;
using Xunit;

namespace timestampapi.tests
{
  public interface IDateProvider
  {
    DayOfWeek DayOfWeek();
    string Hello();
  }
}