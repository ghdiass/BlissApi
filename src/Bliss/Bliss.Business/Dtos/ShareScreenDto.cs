namespace Bliss.Business.Dtos
{
    public class ShareScreenDto
    {
        public ShareScreenDto(string email, string url)
        {
            Email = email;
            Url = url;
        }

        public string Email { get; private set; }
        public string Url { get; private set; }
    }
}
