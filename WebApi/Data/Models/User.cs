using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models
{
    public class User
    {
        [Key, MaxLength(2), NotNull]
        public string usernameID { get; set; }
        
        [MaxLength(15), NotNull]
        public string name { get; set; }
        
        [MaxLength(15), NotNull] 
        public string password { get; set; }
        


    }
}