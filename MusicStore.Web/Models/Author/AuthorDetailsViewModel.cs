using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Web.Models.Author
{
    public class AuthorDetailsViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int Age { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "last Name")]
        public string LastName { get; set; }

        [Display(Name = "Pseudonym")]
        public string Nickname { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Photo { get; set; }
       
    }
}