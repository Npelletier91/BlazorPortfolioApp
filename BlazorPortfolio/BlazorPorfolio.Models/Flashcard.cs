using System.ComponentModel.DataAnnotations;

namespace BlazorPorfolio.Models
{
    public class Flashcard
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Front text is required")]
        public string FrontText { get; set; }


        [Required(ErrorMessage = "Back text is required")]
        public string BackText { get; set; }

        public int UserID { get; set; }

    }
    public class FlashcardSet
    {
        public string SetName { get; set; }
        public List<Flashcard> Flashcards { get; set; } = new List<Flashcard>();
    }

}
