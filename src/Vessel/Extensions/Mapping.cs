using System.Net;


namespace Vessel.Extensions
{
    public static class Mapping
    {
        public static Status ToStatus(this HttpStatusCode @this)
        {
            return @this switch
            {
                HttpStatusCode.OK => Status.Success,
                HttpStatusCode.Unauthorized => Status.Unauthorized,
                _ => Status.Failed
            };
        }
    }
}
