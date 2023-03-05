using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class Photo
    {
        [Key]
        public int Photo_Id {get; set;}
        
        public string Photo_Code {get; set;}

    }

    public class PhotoReturnType
    {
        public int id {get; set;}

    }
