using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    //zad2
    public class Book 
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the book
        /// </summary>
        [Required(ErrorMessage = "Name can not be empty!")]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Name of The Author
        /// </summary>
        [Required(ErrorMessage = "Author name can not be empty!")]
        public string AuthorName { get; set; }

        /// <summary>
        /// Genre
        /// </summary>
        [Range(1, byte.MaxValue, ErrorMessage = "Genre can not be empty!")]
        public Genre Genre { get; set; }

        /// <summary>
        /// GenreID
        /// </summary>
        [Required(ErrorMessage = "GenreId can not be empty!")]
        public byte GenreId { get; set; }

        /// <summary>
        /// Date Added
        /// </summary>
        [Required(ErrorMessage = "DateAdded can not be empty!")]
        [Display(Name = "DateAdded Date")]
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// Release Date
        /// </summary>
        [Required(ErrorMessage = "Release can not be empty!")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Number In Stock
        /// </summary>
        [Required(ErrorMessage = "Number in stock can not be empty!")]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "Should be in range between 1 and 20")]
        public int? NumberInStock { get; set; }

        /// <summary>
        /// Number Available
        /// </summary>
        [Required(ErrorMessage = "Number Available in stock can not be empty!")]
        public int NumberAvailable { get; set; }

    }
}
