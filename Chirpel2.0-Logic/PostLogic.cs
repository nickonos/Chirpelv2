using Chirpel2._0_Common.Interfaces.Data;

namespace Chirpel2._0_Logic
{
    public class PostLogic
    {
        private readonly IPostData _postData;
        public PostLogic(IPostData postData)
        {
            _postData = postData;
        }
    }
}