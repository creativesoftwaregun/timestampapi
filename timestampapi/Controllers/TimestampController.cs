using Microsoft.AspNetCore.Mvc;
using System;

namespace timestampapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TimestampController : ControllerBase
  {

    [HttpGet]
    public ContentResult Get()
    {
      return ProcessDateValue(string.Empty);
    }

    [HttpGet("{pDateValue}")]
    public ContentResult Get(string pDateValue)
    {
      return ProcessDateValue(pDateValue);
    }

    ContentResult ProcessDateValue(string pDateValue)
    {
      if (pDateValue == string.Empty)
      {
        pDateValue = DateTime.Now.ToString();
      }

      DateTime? dateVal = GetDate(pDateValue);

      if (!dateVal.HasValue)
      {
        return Content("{ error: Invalid Date }");
      }

      string dateFormat = "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'";
      string utcDateString = dateVal.Value.ToUniversalTime().ToString(dateFormat); ;
      string retVal = $"{{ \"unix\": {UnixTimeNow()}, \"utc\": \"{utcDateString}\" }}";

      return Content(retVal, "application/json");
    }

    private long UnixTimeNow()
    {
      var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
      return (long)timeSpan.TotalSeconds;
    }

    private DateTime? GetDate(string pVal)
    {
      DateTime dateVal;
      if (DateTime.TryParse(pVal, out dateVal))
      {
        return dateVal;
      }
      else
      {
        return null;
      }
    }
  }
}