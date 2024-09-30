using System.ComponentModel.DataAnnotations;

namespace ResumeBlazorWASMApp.Models;

public class Candidate
{
    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; }
    public string PdfResume { get; set; }
    public bool IsResumeVisible { get; set; }
    public BackEndSkills BackEndSkills { get; set; } = new BackEndSkills();
    public FrontEndSkills FrontEndSkills { get; set; } = new FrontEndSkills();
    public bool IsFavorited { get; set; }
    public bool PdfUploaded { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Candidate other)
        {
            return FirstName == other.FirstName && LastName == other.LastName && Email == other.Email;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, Email);
    }
}