using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirpel2._0_Common.Models.DataModels
{
    public class PostModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Created {  get; set; }
        public List<UserModel> Likes { get; set; }
        public List<PostModel> Comments { get; set; }

        public PostModel() { }

        public PostModel(string content)
        {
            Id = Guid.NewGuid();
            Content = content;
            Created = DateTime.UtcNow;
            Likes = new List<UserModel>();
            Comments = new List<PostModel>();
        }
    }
}
