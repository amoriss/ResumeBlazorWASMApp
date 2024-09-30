using ResumeBlazorWASMApp.Models;

namespace ResumeBlazorWASMApp.Services;

public class CandidateService
{
    public static List<Candidate> EligibleCandidates { get; set; } = new List<Candidate>();

    public static void AddEligibleCandidate(Candidate candidate)
    {
        EligibleCandidates.Add(candidate);
    }

    public static void DeleteEligibleCandidate(Candidate candidate)
    {
        EligibleCandidates.Remove(candidate);
    }

    public static List<Candidate> GetAllEligibleCandidates()
    {
        return EligibleCandidates;
    }

    public static void LoadEligibleCandidates(List<Candidate> candidates)
    {
        EligibleCandidates = candidates;
    }
}