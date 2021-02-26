using System;

namespace UserProfileDemo.Models
{
    // tag::userprofile[]
    public class UserProfile
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string BirhDate { get; set; }
        public byte[] ImageData { get; set; }
        public string Age { get; set; }
        public string Description { get; set; }
    }
    // end::userprofile[]
}
