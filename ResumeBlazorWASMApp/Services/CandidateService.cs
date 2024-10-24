using Blazored.LocalStorage;
using Blazored.LocalStorage.StorageOptions;
using ResumeBlazorWASMApp.Models;

namespace ResumeBlazorWASMApp.Services;

public class CandidateService
{
    public static List<Candidate> EligibleCandidates { get; set; } = new List<Candidate>();

    public static async Task AddEligibleCandidate(Candidate candidate, ILocalStorageService localStorage)
    {
        EligibleCandidates.Add(candidate);
        await localStorage.SetItemAsync("eligibleCandidates", EligibleCandidates);
       
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
        Console.WriteLine($"Loading {candidates.Count} candidates into the service.");
        EligibleCandidates = candidates;
    }
}