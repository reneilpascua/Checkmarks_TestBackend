namespace testBackend.Models
{
    public class NewContact
    {
        // does not encompass all fields that a contact contains,
        // but is enough for this web app.
        public string Etag {get; set;}
        public string Name {get; set;}
        public string First_name {get; set;}
        public string Last_name {get; set;}
        public string Primary_email_address {get;set;}
        public string Primary_phone_number {get;set;}
        public string Type {get;set;}
    }
}