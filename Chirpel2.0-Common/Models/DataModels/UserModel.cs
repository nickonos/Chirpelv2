using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirpel2._0_Common.Models.DataModels
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email {  get; private set; }
        public string Password {  get; private set; }
        public bool IsPrivate { get; private set; }
        public string? Biography {  get; private set; }
        public string? ProfilePicture { get; private set; }
        public List<PostModel> Posts {  get; private set; }
        public List<UserModel> Following { get; private set; }

        public UserModel(){}

        public UserModel(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            IsPrivate = false;
            Biography = null;
            ProfilePicture = null;
            Posts = new List<PostModel>();
            Following = new List<UserModel>();
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void ChangePrivacy(bool isPrivate)
        {
            IsPrivate = isPrivate;
        }

        public void ChangeBiography(string? biography)
        {
            Biography = biography;
        }

        public void RemovePost(PostModel post)
        {
            Posts.Remove(post);
        }
    }
}
