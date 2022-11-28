using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIV1.Entities
{
    public record Employee
    {
        [Name("Identifier")]
        [Index(0)]
        [BindRequired]
        public string Email { get; init; }
        [Index(1)]
        [BindRequired]
        public string Firstname { get; set; }
        [Index(2)]
        [BindRequired]
        public string Lastname { get; set; }
        [Index(3)]
        public string PhoneNumber { get; set; }
        [Index(4)]
        public string TimeInterval { get; set; }
        [Index(5)]
        public string LinkedinURL { get; set; }
        [Index(6)]
        public string GithubURL { get; set; }
        [Index(7)]
        [BindRequired]
        public string Comment { get; set; }
    }
}