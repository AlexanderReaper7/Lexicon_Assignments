using System.Text.Json.Serialization;

namespace Personalregister;

[Serializable]
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
   
    [JsonIgnore]
    public string FullName => $"{FirstName} {LastName}";

    public Person(string firstName, string lastName, string socialSecurityNumber, string phoneNumber, string street, string zipCode, string city)
    {
        FirstName = firstName;
        LastName = lastName;
        SocialSecurityNumber = socialSecurityNumber;
        PhoneNumber = phoneNumber;
        Street = street;
        ZipCode = zipCode;
        City = city;
    }

    public override string ToString()
    {
        return $"{FullName}\n    SSN: {SocialSecurityNumber}\n    Phone: {PhoneNumber}\n    Address: {Street}, {ZipCode} {City}";
    }
}

