using ResumeBlazorWASMApp.Models;

namespace ResumeBlazorWASMApp.Services;

public class SkillsFinder
{
    public static void FindBackEndSkillsFromResume(string pageText, BackEndSkills backEndSkills)
    {
        if (pageText.Contains("visual studio"))
        {
            backEndSkills.UsesVisualStudio = true;
        }

        if (pageText.Contains("c#"))
        {
            backEndSkills.UsesCSharp = true;
        }

        if (pageText.Contains("asp.net") || (pageText.Contains("asp")))
        {
            backEndSkills.UsesAspnet = true;
        }

        if (pageText.Contains("sql"))
        {
            backEndSkills.UsesSql = true;
        }
    }

    public static void FindFrontEndSkillsFromResume(string pageText, FrontEndSkills frontEndSkills)
    {
        if (pageText.Contains("javascript"))
        {
            frontEndSkills.UsesJavaScript = true;
        }

        if (pageText.Contains("css"))
        {
            frontEndSkills.UsesCss = true;
        }

        if (pageText.Contains("react"))
        {
            frontEndSkills.UsesReact = true;
        }
    }
}