using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GodtSkoddFAQ_mappe3_s198611.Models
{
    public class Category
    {
        //[Display(Name = "Id")]
        public int id { get; set; }

        /*[Display(Name = "Navn")]
        [Required(ErrorMessage = "Navn på kategori må oppgis")]
        [RegularExpression(@"[A-ZÆØÅa-zæøå\s]{1,30}", ErrorMessage = "Navn på kategori kan bare inneholde bokstaver fra A-Å")]*/
        public String name { get; set; }
    }

    public class FAQ
    {
        //[Display(Name = "Id")]
        public int id { get; set; }

        /*[Display(Name = "Spørsmål")]
        [Required(ErrorMessage = "Spørsmål må oppgis")]
        [RegularExpression(@"[A-ZÆØÅa-zæøå\s0-9\-\.]{1,40}", ErrorMessage = "Spørsmålet inneholder ugyldige tegn")]*/
        public String question { get; set; }

        /*[Display(Name = "Svar")]
        [Required(ErrorMessage = "Svar må oppgis")]
        [RegularExpression(@"[A-ZÆØÅa-zæøå\s0-9\-\.]{1,80}", ErrorMessage = "Svaret inneholder ugyldige tegn")]*/
        public String answer { get; set; }

        /*[Display(Name = "Kategori Id")]
        [Required(ErrorMessage = "Kategori Id må oppgis")]
        [RegularExpression(@"[0-9]{1,3}", ErrorMessage = "Kategori Id må være et tall")]*/
        public int categoryId { get; set; }
    }

    public class Request    // Senders and Messages
    {
        //[Display(Name = "Id")]
        public int id { get; set; }

        /*[Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        [RegularExpression(@"[A-ZÆØÅa-zæøå\s]{1,30}", ErrorMessage = "Fornavn kan bare inneholde bokstaver fra A-Å")]*/
        public String senderFirstName { get; set; }

        /*[Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis")]
        [RegularExpression(@"[A-ZÆØÅa-zæøå\s]{1,30}", ErrorMessage = "Etternavn kan bare inneholde bokstaver fra A-Å")]*/
        public String senderLastName { get; set; }

        /*[Display(Name = "E-post")]
        [Required(ErrorMessage = "E-post må oppgis")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "E-post")]*/
        public String senderEmail { get; set; }

        /*[Display(Name = "Tema")]
        [Required(ErrorMessage = "Tema må oppgis")]
        [RegularExpression(@"[A-ZÆØÅa-zæøå\s]{1,30}", ErrorMessage = "Tema kan bare inneholde bokstaver fra A-Å")]*/
        public String subject { get; set; }

        /*[Display(Name = "Spørsmål")]
        [Required(ErrorMessage = "Spørsmål må oppgis")]
        [RegularExpression(@"[A-ZÆØÅa-zæøå\s0-9\-\.]{1,80}", ErrorMessage = "Spørsmålet inneholder ugyldige tegn")]*/
        public String question { get; set; }

        //[Display(Name = "Tidspunkt")]
        public DateTime date { get; set; }

        //[Display(Name = "Besvart")]
        public bool answered { get; set; }
    }
}