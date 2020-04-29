namespace testBackend.Models
{
    class Contact
    {
        // does not encompass all fields that a contact contains,
        // but is enough for this web app.
        int id {get; set;}
        string etag {get; set;}
        string name {get; set;}
        string first_name {get; set;}
        string last_name {get; set;}
        string primary_email_address {get;set;}
        string primary_phone_number {get;set;}
    }
}