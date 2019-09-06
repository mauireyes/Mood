using System;
namespace Doom.Common.Events
{
    public class UserCreated : IEvent
    {

        public string Email { get;}
        public string Name { get;}
        //only use getters


            //create this tso serializer will not have any issues
        protected UserCreated()
        {
        }

        public UserCreated(string email, string name)
        {
            Email = email;
            Name = name; 
        }
    }
}
