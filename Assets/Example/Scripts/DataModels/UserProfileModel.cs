using System;

[Serializable]
public class UserProfileModel : IDataModel
{
    public string ModelName => "User Profile";

    public string UserName = "Guest";
    public int Level = 1;
    public int Experience = 0;
    public DateTime LastLoginTime = DateTime.Now;

    public void UpdateModelByLiteMessage(string message)
    {

    }

    public string GetLiteMessage(int deepH, out int maxDepth)
    {
        var sep = DepthSeparator.GetSeparator(deepH);
        maxDepth = deepH;
        return $"{UserName}{sep}{Level}{sep}{Experience}";
    }
}