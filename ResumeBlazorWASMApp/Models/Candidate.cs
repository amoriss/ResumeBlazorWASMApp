namespace ResumeBlazorWASMApp.Models;

public class Candidate
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PdfResume { get; set; }
    public BackEndSkills BackEndSkills { get; set; } = new BackEndSkills();
    public FrontEndSkills FrontEndSkills { get; set; } = new FrontEndSkills();
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