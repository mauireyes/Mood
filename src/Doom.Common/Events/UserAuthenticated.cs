using System;
namespace Doom.Common.Events
{
    public class UserAuthenticated : IEvent
    {

        public string Email { get; set; }

        //let them know that user with this email is authentitcated

        protected UserAuthenticated()
        {

        }
        public UserAuthenticated(string email)
        {
            Email = email;
            //what happens if user is not authenticated 
        }
    }
}
